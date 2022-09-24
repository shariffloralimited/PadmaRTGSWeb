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
    public partial class OutwardBatchStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BranchesDB db = new BranchesDB();
                BranchList.DataSource = db.GetSendBranches();
                BranchList.DataBind();

                BranchList.SelectedValue = Request.Cookies["RoutingNo"].Value;

               
                if ((Request.Cookies["RoleID"].Value != "4") && (Request.Cookies["RoleID"].Value != "10") && (Request.Cookies["RoleID"].Value != "11") && (Request.Cookies["BranchID"].Value != "1"))
                {
                    BranchList.Enabled = false;
                }
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            OCEBatchDB db = new OCEBatchDB();
            DataTable dt = db.GetBatchStatus(Int32.Parse(BranchList.SelectedValue));

            MyDataGrid.DataSource = dt;
            MyDataGrid.DataBind();
            try
            {
                MyDataGrid.FooterRow.Cells[2].Text  = dt.Compute("SUM(TotalChecks)", "").ToString();
                MyDataGrid.FooterRow.Cells[3].Text  = dt.Compute("SUM(BatchTotal)", "").ToString();
                MyDataGrid.FooterRow.Cells[11].Text = dt.Compute("SUM(Presented)", "").ToString();
                MyDataGrid.FooterRow.Cells[12].Text = dt.Compute("SUM(Accepted)", "").ToString();
                MyDataGrid.FooterRow.Cells[13].Text = dt.Compute("SUM(Rejected)", "").ToString();
            }
            catch
            {
            }
            dt.Dispose();
            MyDataGrid.Dispose();

        }

       
    }

}