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
    public partial class InwardRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ReturnCD"] != null)
            {
                if (Request.QueryString["ReturnCD"] == "")
                {
                    Session["ReturnCD"] = "0";
                }
                else
                {
                    Session["ReturnCD"] = Request.QueryString["ReturnCD"];
                }

                Response.Redirect("InwardList.aspx?RoutingNo=" + Request.QueryString["RoutingNo"] + "&ClearingType=" + Request.QueryString["ClearingType"]);
            }
            string QueryString = "";
            if (Request.QueryString["CheckID"] != null)
            {
                QueryString = "?CheckID=" + Request.Params["CheckID"];
            }
            if ((Request.Cookies["RoleCD"].Value == "5") || (Request.Cookies["RoleCD"].Value == "11"))
            {
                Response.Redirect("InwardMaker.aspx" + QueryString);
            }
            if ((Request.Cookies["RoleID"].Value == "6") || (Request.Cookies["RoleID"].Value == "12"))
            {
                Response.Redirect("InwardChecker.aspx" + QueryString);
            }
            Response.Redirect("AccessDenied.aspx");
        }
    }
}
