using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace RTGS
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ChangePwdNow"].Value.ToUpper() == "TRUE")
            {
                HdrMsg.Text = "YOU MUST CHANGE YOUR PASSWORD NOW.";
            }
        }

        protected void ChangePwdBtn_Click(object sender, EventArgs e)
        {
            Msg.Text = "";
            if (Page.IsValid)
            {
                if (NewPassword.Text != ConfirmPassword.Text)
                {
                    Msg.Text = "New and confirm passwords did not match.";
                }
                else
                {
                    PasswordPolicy policy = new PasswordPolicy();
                    string result = policy.PasswordPolicyTest(NewPassword.Text, Int32.Parse(Context.User.Identity.Name));
                    if (result == "OK")
                    {
                        UserDB db = new UserDB();
                        int Status = db.ChangePassword(Int32.Parse(Context.User.Identity.Name), db.Encrypt(OldPassword.Text), db.Encrypt(NewPassword.Text), Request.UserHostAddress);
                        if (Status == 1)
                        {
                            Msg.Text = "Password Successfully Changed. You have been logged out.";
                            HdrMsg.Text = "";
                            ChangePwdBtn.Visible = false;
                            GoToLoginBtn.Visible = true;
                            LogOut();
                        }
                        if (Status == 0)
                        {
                            Msg.Text = "Old Password was not correct.";
                        }
                    }
                    else
                    {
                        Msg.Text = result;
                    }
                }
            }
        }
        private void LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            Response.Cookies["ChangePwdNow"].Value = "False";
        }

        protected void GoToLoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
