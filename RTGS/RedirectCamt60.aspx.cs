using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS
{
    public partial class RedirectCamt60 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string previousPage = Page.Request.UrlReferrer.ToString();

            if ((Request.Params["CCY"] != null) && (Request.Params["CCY"] != ""))
            {
                string CCY = Request.Params["CCY"];
                FloraSoft.CamtGenerator camt = new FloraSoft.CamtGenerator();
                camt.GenCamt60(CCY);
            }

            if ((previousPage != null) && (previousPage != ""))
            {
                Response.Redirect(previousPage);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}