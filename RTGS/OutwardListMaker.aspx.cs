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
    public partial class OutwardListMaker : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.Cookies["DeptBanking"].Value != "False")
            {
                Response.Redirect("OutwardDeptListMaker.aspx");
            }  
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string RoleCD = Request.Cookies["RoleCD"].Value;
            if ((RoleCD == "RTCK") || (RoleCD == "RTAU"))
            {
                Response.Redirect("OutwardListChecker.aspx");
                btnNewEntry.Visible = false;
            }

            if (!Page.IsPostBack)
            {
                BranchesDB db = new BranchesDB();
                BranchList.DataSource = db.GetSendBranches();
                BranchList.DataBind();
                BranchList.Items.Add(new ListItem("All", "0"));

                if (Request.Cookies["AllBranch"].Value != "False")
                {
                    BranchList.SelectedValue = "0";
                    BranchList.Enabled = true;
                }
                else
                {
                    BranchList.SelectedValue = Request.Cookies["RoutingNo"].Value;
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
            OutwardDB db = new OutwardDB();
            DataTable dt = db.GetOutwardList(BranchList.SelectedValue, 1);

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

        protected void btnNewEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("OutwardEntryChoice.aspx");
        }
    }

}