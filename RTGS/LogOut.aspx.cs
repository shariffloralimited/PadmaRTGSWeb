using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RTGS;
namespace RTGS
{
    public partial class LogOut : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    FormsAuthentication.SignOut();
        //    Session.Abandon();

        //    // clear authentication cookie
        //    HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
        //    cookie1.Expires = DateTime.Now.AddYears(-1);
        //    Response.Cookies.Add(cookie1);

        //    // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
        //    HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
        //    cookie2.Expires = DateTime.Now.AddYears(-1);
        //    Response.Cookies.Add(cookie2);

        //    FormsAuthentication.RedirectToLoginPage();
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserDB db = new UserDB();
                int UserID = Int32.Parse(Context.User.Identity.Name);
                db.LogOut(UserID, Request.UserHostAddress);
            }
            catch
            {
            }

            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            FormsAuthentication.RedirectToLoginPage();
        }
    }
}
