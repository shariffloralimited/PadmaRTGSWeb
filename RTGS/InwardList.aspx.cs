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
    public partial class InwardList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindBranch();
                if ((Request.Params["SelectedBranch"] != null) && (Request.Params["SelectedBranch"] != ""))
                {
                    BranchList.SelectedValue = Request.Params["SelectedBranch"];
                }
                else
                {
                    StatusList.SelectedValue = "3";
                }
                string RoleCD = Request.Cookies["RoleCD"].Value;
                if ((RoleCD == "RTMK") || (RoleCD == "RTCK") || (RoleCD == "RTAU"))
                {
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

            }
        }
        private void BindBranch()
        {
            BranchesDB db = new BranchesDB();
            BranchList.DataSource = db.GetSendBranches();
            BranchList.DataBind();
            BranchList.Items.Add(new ListItem("All", "0"));
            BranchList.SelectedValue = "0";
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            InwardDB db = new InwardDB();
            string RoutingNo = BranchList.SelectedValue;
            int StatusID = Int32.Parse(StatusList.SelectedValue);
            string Form = FormList.SelectedItem.Text;
            Decimal Amount = 0;
            try
            {
                Amount = decimal.Parse(txtAmount.Text.Trim());
            }
            catch { }

            //if (Amount != 0)
            //{
            //    StatusList.SelectedValue = "0";
            //    FormList.SelectedIndex = 0;
            //}
            DataTable dt = db.GetInwardList(RoutingNo, StatusID, Form, Amount);

            MyDataGrid.DataSource = dt;
            MyDataGrid.DataBind();

            lblRowCount.Text = dt.Rows.Count.ToString() + " row(s) found.";
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