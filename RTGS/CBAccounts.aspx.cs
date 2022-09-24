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
    public partial class CBAccounts : System.Web.UI.Page
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
            BindAccountData();
        }
        private void BindAccountData()
        {
            CBAccountsDB db = new CBAccountsDB();
            MyDataGrid.DataSource = db.GetCBAccountsByBIC(BankList.SelectedValue);
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
            CBAccountsDB db = new CBAccountsDB();

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
                int AcctID = (int) MyDataGrid.DataKeys[e.Item.ItemIndex];

                TextBox txtAcctNo = (TextBox)e.Item.FindControl("AcctNo");

                db.UpdateCBAccount(AcctID, txtAcctNo.Text.Trim());

                lblMsg.Text = "Updated.";

               

                MyDataGrid.EditItemIndex = -1;
                lblMsg.ForeColor = System.Drawing.Color.Blue;
            }
            if (e.CommandName == "Insert")
            {
                DropDownList CCYList = (DropDownList)e.Item.FindControl("AddCCY");
                DropDownList AcctTypeList = (DropDownList)e.Item.FindControl("AddAcctType");
                TextBox txtAcctNo = (TextBox)e.Item.FindControl("AddAcctNo");

                lblMsg.Text = db.InsertCBAccount(BankList.SelectedValue, CCYList.SelectedItem.Text, AcctTypeList.SelectedItem.Text, txtAcctNo.Text);
                

                MyDataGrid.EditItemIndex = -1;
                lblMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

    }
}
