using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS
{
    public partial class RedirectChecker : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string OutwardID = Request.Params["OutwardID"];
            string Form = Request.Params["Form"];

            if (Form == "Pacs.008")
            {
                Response.Redirect("Forms/Outward08LongChecker.aspx?OutwardID=" + OutwardID);
            }
            if (Form == "Pacs.009")
            {
                Response.Redirect("Forms/Outward09LongChecker.aspx?OutwardID=" + OutwardID);
            }
            if (Form == "Pacs.004")
            {
                Response.Redirect("Forms/PaymentReturnChecker.aspx?OutwardID=" + OutwardID);
            }  
        }
    }
}