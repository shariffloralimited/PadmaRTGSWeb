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
    public partial class BranchSettlement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CCy = "BDT";
            if (Parent.Page.ToString() != "ASP.default_aspx")
            {
                RTGS.DeptDefault homepage = (RTGS.DeptDefault)Parent.Page;
                CCy = homepage.CCYBranch;
            }
            else
            {
                RTGS._Default homepage = (RTGS._Default)Parent.Page;
                CCy = homepage.CCYBranch;
            }

            SettlementDB db = new SettlementDB();
            DataTable dt = db.GetDASHBranchSettlement(CCy);
            SettlementGrid.DataSource = dt;
            SettlementGrid.DataBind();

            LblTotal.Text = "Total";

            try
            {
                OCE.Text = Utilities.ToMoney(dt.Compute("SUM(OCE)", "").ToString());
                ICE.Text = Utilities.ToMoney(dt.Compute("SUM(ICE)", "").ToString());

                iOCE.Text = dt.Compute("SUM(iOCE)", "").ToString();
                iICE.Text = dt.Compute("SUM(iICE)", "").ToString();
            }
            catch
            {
            }
            dt.Dispose();
            SettlementGrid.Dispose();
        }
    }
}