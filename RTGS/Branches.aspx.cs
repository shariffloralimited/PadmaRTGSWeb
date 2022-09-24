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
    public partial class Branches : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.Cookies["RoleCD"].Value != "RTAD")
            {
                Response.Redirect("AccessDenied.aspx");
            }
            if (!Page.IsPostBack)
            {
                BindBankList();
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindBranchData();
        }
        private void BindBranchData()
        {
            BranchesDB db = new BranchesDB();
            MyDataGrid.DataSource = db.GetBranchesByBankCD(BankList.SelectedValue);
            MyDataGrid.DataBind();
        }

        private void BindBankList()
        {
            BanksDB db = new BanksDB();
            BankList.DataSource = db.GetAllBanks();
            BankList.DataBind();
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
                int BranchID = (int) MyDataGrid.DataKeys[e.Item.ItemIndex];

                TextBox txtRoutingNo = (TextBox)e.Item.FindControl("RoutingNo");
                TextBox txtBranchName = (TextBox)e.Item.FindControl("BranchName");

                if (txtRoutingNo.Text.Trim().Length < 9)
                {
                    lblMsg.Text = "Routing No. must be 9 digits.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (txtBranchName.Text.Trim()== "") 
                {
                    lblMsg.Text = "Branch Name missing.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                lblMsg.Text = db.UpdateBranch(BranchID, txtRoutingNo.Text.Trim(), txtBranchName.Text.Trim());

                MyDataGrid.EditItemIndex = -1;
                lblMsg.ForeColor = System.Drawing.Color.Blue;
            }
            if (e.CommandName == "Insert")
            {
                if (Request.Cookies["RoleCD"].Value != "RTAD")
                {
                    Response.Redirect("AccessDenied.aspx");
                }

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
