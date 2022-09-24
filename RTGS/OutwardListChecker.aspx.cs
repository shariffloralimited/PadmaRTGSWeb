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
    public partial class OutwardListChecker : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.Cookies["DeptBanking"].Value != "False")
            {
                Response.Redirect("OutwardDeptListChecker.aspx");
            }  
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindBranch();
                if ((Request.Params["SelectedBranch"] != null) && (Request.Params["SelectedBranch"] != ""))
                {
                    BranchList.SelectedValue = Request.Params["SelectedBranch"];
                }
            }
        }
        private void BindBranch()
        {
            BranchesDB db = new BranchesDB();
            BranchList.DataSource = db.GetSendBranches();
            BranchList.DataBind();
            BranchList.Items.Add(new ListItem("All", "0"));
            if (Request.Cookies["AllBranch"].Value != "False")
            {
                BranchList.SelectedValue = "0";
            }
            else
            {
                BranchList.SelectedValue = Request.Cookies["RoutingNo"].Value;
                BranchList.Enabled = false;
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            int StatusID = 2;
            if (Request.Cookies["RoleCD"].Value == "RTAU")
            {
                StatusID = 3;
            }
            OutwardDB db = new OutwardDB();
            DataTable dt = db.GetOutwardList(BranchList.SelectedValue, StatusID);

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