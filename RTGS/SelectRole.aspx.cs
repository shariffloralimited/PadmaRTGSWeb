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
using System.Data.SqlClient;

namespace RTGS
{
    public partial class SelectUserRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Context.User.Identity.Name == "")
            {
                base.Response.Redirect("Login.aspx");
            }
            if (!this.Context.User.Identity.IsAuthenticated)
            {
                base.Response.Redirect("Login.aspx");
            }
            if (!base.IsPostBack)
            {
                this.BindUserRole();
            }
        }

        private void BindUserRole()
        {
            RoleDB roleDB = new RoleDB();
            this.ddluserrole.DataSource = roleDB.GetUserRoles(int.Parse(this.Context.User.Identity.Name));
            this.ddluserrole.DataBind();
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string value = this.ddluserrole.SelectedItem.Value;
            string[] array = value.Split(new char[]
			{
				','
			});
            string value2 = array[0];
            string text = array[1];
            string value3 = array[2];
            base.Response.Cookies["RoleID"].Value = value2;
            base.Response.Cookies["RoleCD"].Value = text;
            base.Response.Cookies["TransLimit"].Value = value3;
            base.Response.Cookies["RoleName"].Value = this.ddluserrole.SelectedItem.Text;
            if (text == "RTMK")
            {
                base.Response.Redirect("BranchMessages.aspx");
            }
            if (text == "RTCK")
            {
                base.Response.Redirect("BranchMessages.aspx");
            }
            if (text == "RTAD")
            {
                base.Response.Redirect("Default.aspx");
            }
            if (text == "RTFM")
            {
                base.Response.Redirect("Default.aspx");
            }
            if (text == "RTSA")
            {
                base.Response.Redirect("ReportViewerMenu.aspx");
            }
            if (text == "RTRV")
            {
                base.Response.Redirect("ReportViewerMenu.aspx");
            }
            if (text == "RTAU")
            {
                base.Response.Redirect("BranchMessages.aspx");
            }
        }
    }
}

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Context.User.Identity.Name == "")
//            {
//                Response.Redirect("Login.aspx");
//            }
//            if(!Context.User.Identity.IsAuthenticated)
//            {
//                Response.Redirect("Login.aspx");
//            }
//            if (!IsPostBack)
//            {
//                BindUserRole();
//            }
//        }

//        private void BindUserRole()
//        {
//            RoleDB Role = new RoleDB();

//            ddluserrole.DataSource = Role.GetUserRoles(Int32.Parse(Context.User.Identity.Name));
//            ddluserrole.DataBind();
//        }

     
//        protected void Login_Click(object sender, EventArgs e)
//        {
//            string SelectedRole = ddluserrole.SelectedItem.Value;
//            string[] a = SelectedRole.Split(',');
//            string RoleID = a[0];
//            string RoleCD = a[1];
//            string TransLimit = a[2];

//            Response.Cookies["RoleID"].Value = RoleID;
//            Response.Cookies["RoleCD"].Value = RoleCD;
//            Response.Cookies["TransLimit"].Value = TransLimit;

//            Response.Cookies["RoleName"].Value = ddluserrole.SelectedItem.Text;

//            if (RoleCD == "RTMK")
//            {
//                Response.Redirect("BranchMessages.aspx");
//            }
//            if (RoleCD == "RTCK")
//            {
//                Response.Redirect("BranchMessages.aspx");
//            }
//            if (RoleCD == "RTAD")
//            {
//                Response.Redirect("Default.aspx");
//            }
//            if (RoleCD == "RTFM")
//            {
//                Response.Redirect("Default.aspx");
//            }

//            if (RoleCD == "RTSA")
//            {
//                Response.Redirect("ReportViewerMenu.aspx");
//            }
//            if (RoleCD == "RTRV")
//            {
//                Response.Redirect("ReportViewerMenu.aspx");
//            }

//            if (RoleCD == "RTAU")
//            {
//                Response.Redirect("BranchMessages.aspx");
//            }
//        }
//    }
//}
