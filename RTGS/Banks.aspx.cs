using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace RTGS
{
    public partial class Banks : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string RoleCD = Request.Cookies["RoleCD"].Value;
            if (RoleCD != "RTAD")
            {
                Response.Redirect("AccessDenied.aspx");
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindBankData();
        }

        protected DataTable BindBranchList()
        {
            BranchesDB db = new BranchesDB();
            return db.GetBranchesByBankCD("020");
        }
        private void BindBankData()
        {
            BanksDB db = new BanksDB();
            MyDataGrid.DataSource = db.GetAllBanks();
            MyDataGrid.DataBind();
        }

        protected void MyDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            BranchesDB db = new BranchesDB();

            if (e.CommandName == "Cancel")
            {
                MyDataGrid.EditItemIndex = -1;
            }
            if (e.CommandName == "Edit")
            {
                MyDataGrid.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "Update")
            {

                //lblMsg.Text = db.UpdateBranch(BranchID, txtRoutingNo.Text.Trim(), txtBranchName.Text.Trim());

                MyDataGrid.EditItemIndex = -1;
                lblMsg.ForeColor = System.Drawing.Color.Blue;
            }
            if (e.CommandName == "Insert")
            {

                TextBox txtRoutingNo = (TextBox)e.Item.FindControl("AddRoutingNo");
                TextBox txtBranchName = (TextBox)e.Item.FindControl("AddBranchName");

                if (txtRoutingNo.Text.Trim().Length < 9)
                {
                    lblMsg.Text = "Routing No. must be 9 digits.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (txtBranchName.Text.Trim() == "")
                {
                    lblMsg.Text = "Branch Name missing.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                lblMsg.Text = db.InsertBranch(txtRoutingNo.Text.Trim(), txtBranchName.Text.Trim());

                MyDataGrid.EditItemIndex = -1;
                lblMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

    }
}
