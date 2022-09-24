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

namespace RTGS.modules
{
    public partial class ICEBranchStatus : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ICEDB db                = new ICEDB();
            DataTable dt;
            dt = db.GetBranchStatus();
            BranchGrid.DataSource   = dt;
            BranchGrid.DataBind();
            try
            {
                Received.Text = dt.Compute("SUM(Received)", "").ToString();
                Approved.Text = dt.Compute("SUM(Approved)", "").ToString();
                Maker.Text = dt.Compute("SUM(Maker)", "").ToString();
                Checker.Text = dt.Compute("SUM(Checker)", "").ToString();
                Authorizer.Text = dt.Compute("SUM(Authorizer)", "").ToString();
                Reversed.Text = dt.Compute("SUM(Reversed)", "").ToString();
            }
            catch
            {
                Received.Text = "0";
                Approved.Text = "0";
                Maker.Text = "0";
                Checker.Text = "0";
                Authorizer.Text = "0";
                Reversed.Text = "0";
            }
            try
            {
                BranchGrid.FooterRow.Font.Bold = true;
            }
            catch
            {
            }
            dt.Dispose();

            if (Request.Cookies["AuthorizerEnabled"].Value == "False")
            {
                BranchGrid.Columns[5].Visible = false;
                AuthCol.Visible = false;
            }
            BranchGrid.Dispose();
        }
        
    }
}