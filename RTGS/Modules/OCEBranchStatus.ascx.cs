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
    public partial class OCEBranchStatus : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            OCEDB db = new OCEDB();
            DataTable dt;
            dt = db.GetBranchStatus();

            BranchGrid.DataSource = dt;
            BranchGrid.DataBind();


            try
            {
                Branch.Text = "Total";
                Maker.Text = dt.Compute("SUM(Maker)", "").ToString();
                Checker.Text = dt.Compute("SUM(Checker)", "").ToString();
                Authorizer.Text = dt.Compute("SUM(Authorizer)", "").ToString();
                Debited.Text = dt.Compute("SUM(CBS)", "").ToString();
                Admin.InnerHtml = "0";
                Sent.Text = dt.Compute("SUM(STP)", "").ToString();
                Rejected.Text = dt.Compute("SUM(Rejected)", "").ToString();
                Queued.Text = dt.Compute("SUM(Queued)", "").ToString();
                Canceled.Text = dt.Compute("SUM(Canceled)", "").ToString();
                Completed.Text = dt.Compute("SUM(Completed)", "").ToString(); 
                
                BranchGrid.FooterRow.Font.Bold = true;

                Admin.InnerHtml = "<a href=\"GenerateOutwardXML.aspx\"><font color=green>" + dt.Compute("SUM([Admin])", "").ToString() + "</font></a>";
                
                if (dt.Compute("SUM([Admin])", "").ToString() != "0")
                {
                    admincol.Style.Add("background", "yellow");
                    Admin.InnerHtml = "<a href=\"GenerateOutwardXML.aspx\"><font color=red>" + dt.Compute("SUM([Admin])", "").ToString() + "</font></a>";
                }
            }
            catch
            {
            }
            dt.Dispose();

            if (Request.Cookies["AuthorizerEnabled"].Value == "False")
            {
                BranchGrid.Columns[3].Visible = false;
                AuthCol.Visible = false;
            }
            BranchGrid.Dispose();
        }
    }
}