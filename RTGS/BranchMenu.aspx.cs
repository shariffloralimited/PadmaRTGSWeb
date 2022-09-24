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

namespace RTGS
{
    public partial class BranchMenu : System.Web.UI.Page
    {
//        protected void Page_Init(object sender, EventArgs e)
//        {
//            try
//            {
//                if (!Global.cancontinue)
//                {
//                    HttpContext.Current.Response.End();
//                }
//            }
//            catch
//            {
//                HttpContext.Current.Response.End();
//            }
//        }
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            string RoleCD = Request.Cookies["RoleCD"].Value;
//            if ((RoleCD != "RTMK") && (RoleCD != "RTCK") && (RoleCD != "RTAU"))
//            {
//                Response.Redirect("AccessDenied.aspx");
//            }
//        }
//    }
//}
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (!Global.cancontinue)
                {
                    HttpContext.Current.Response.End();
                }
            }
            catch
            {
                HttpContext.Current.Response.End();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string value = base.Request.Cookies["RoleCD"].Value;
            if (value != "RTMK" && value != "RTCK" && value != "RTAU")
            {
                base.Response.Redirect("AccessDenied.aspx");
            }
        }
    }
}
