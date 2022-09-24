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
using RTGS.DAC;

namespace RTGS
{
    public partial class PostTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["RoleCD"].Value != "RTFM")
            {
                Response.Redirect("AccessDenied.aspx");
            }
            if (!Page.IsPostBack)
            {
                lblSvcLvlPrtry.Text = Request.Params["SvcLvlPrtry"];
            }
        }

        protected void BtnChangePriority_Click(object sender, EventArgs e)
        {
            FloraSoft.CamtGenerator camt = new FloraSoft.CamtGenerator();
            string OutwardID = Request.Params["OutwardID"];
            string FormName  = Request.Params["FormName"];
            string SvcLvlPrtry   = TxtNewSvcLvlPrtry.Text;

            camt.GenCamt07(OutwardID, FormName, SvcLvlPrtry);
            Response.Redirect("Default.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            FloraSoft.CamtGenerator camt = new FloraSoft.CamtGenerator();
            string OutwardID = Request.Params["OutwardID"];
            string FormName = Request.Params["FormName"];

            camt.GenCamt08(OutwardID, FormName);
            Response.Redirect("Default.aspx");
        }
    }

}