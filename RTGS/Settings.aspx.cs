//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Globalization;

//namespace RTGS
//{
//    public partial class Settings : System.Web.UI.Page
//    {
//        protected void Page_Init(object sender, EventArgs e)
//        {
//            if (Request.Cookies["RoleCD"].Value != "RTAD")
//            {
//                Response.Redirect("AccessDenied.aspx");
//            }
//        }
//        protected void Page_PreRender(object sender, EventArgs e)
//        {
//            BindData();
//        }
//        private void BindData()
//        {
//            SettingsGrid.DataSource = GetData();
//            SettingsGrid.DataBind();
//        }
//        private DataTable GetData()
//        {

//            DataTable table = new DataTable();
//            table.Columns.Add("ItemID", typeof(string));
//            table.Columns.Add("FieldName", typeof(string));
//            table.Columns.Add("FieldValue", typeof(int));
//            table.Columns.Add("FieldDesc", typeof(string));

//            SettingsDB db = new SettingsDB();
//            SqlDataReader dr = db.GetSettings();
//            while (dr.Read())
//            {
//                table.Rows.Add("HVCT", "Outward HV Return (ORE) Cutoff", Int32.Parse((string) dr["HVCT"]), "24H System, example 5.30PM you should write 1730 no decimal or colon.");
//                table.Rows.Add("RVCT", "Outward RV Return(ORE) Cutoff", Int32.Parse((string)dr["RVCT"]), "24H System, example 5.30PM you should write 1730 no decimal or colon.");
//                table.Rows.Add("OHVCT", "Outward HV (OCE) Cutoff", Int32.Parse((string)dr["OHVCT"]), "24H System, example 5.30PM you should write 1730 no decimal or colon.");
//                table.Rows.Add("ORVCT", "Outward RV (OCE) Cutoff", Int32.Parse((string)dr["ORVCT"]), "24H System, example 5.30PM you should write 1730 no decimal or colon.");

//                table.Rows.Add("HVBBChrg", "HV Bangladesh Bank Charge plus VAT", (int)dr["HVBBChrg"], "Total Charge with VAT in poisa. No decimal.");
//                table.Rows.Add("HVChrg", "HV Bank Charge", (int)dr["HVChrg"], "Total Charge without VAT in poisa. No decimal.");
//                table.Rows.Add("HVVat", "HV Bank VAT", (int)dr["HVVat"], "Total VAT in poisa. No decimal.");
                
//                table.Rows.Add("RVBBChrg", "RV Bangladesh Bank Charge plus VAT (50,000 to 5 lacs)", (int)dr["RVBBChrg"], "Total Charge with VAT in poisa. No decimal.");
//                table.Rows.Add("RVChrg", "RV Bank Charge (50,000 to 5 lacs)", (int)dr["RVChrg"], "Total Charge without VAT in poisa. No decimal.");
//                table.Rows.Add("RVVat", "RV Bank VAT (50,000 to 5 lacs)", (int)dr["RVVat"], "Total VAT in poisa. No decimal.");
                
//                table.Rows.Add("RVHBBChrg", "RV Bangladesh Bank Charge(5 lacs and above)", (int)dr["RVHBBChrg"], "Total Charge with VAT in poisa. No decimal.");
//                table.Rows.Add("RVHChrg", "RV Bank Charge (5 lacs and above)", (int)dr["RVHChrg"], "Total Charge without VAT in poisa. No decimal.");
//                table.Rows.Add("RVHVat", "RV Bank VAT (5 lacs and above)", (int)dr["RVHVat"], "Total VAT in poisa. No decimal.");
//            }
//            dr.Close();
//            dr.Dispose();

//            return table;
//        }

//        protected void SettingsGrid_ItemCommand(object source, DataGridCommandEventArgs e)
//        {
//            if (Request.Cookies["RoleCD"].Value != "RTAD")
//            {
//                Response.Redirect("AccessDenied.aspx");
//            }
//            if (e.CommandName == "Cancel")
//            {
//                SettingsGrid.EditItemIndex = -1;
//            }
//            if (e.CommandName == "Edit")
//            {
//                SettingsGrid.EditItemIndex = e.Item.ItemIndex;

//            }
//            if (e.CommandName == "Update")
//            {
//                SettingsDB db = new SettingsDB();
//                string FieldName = (string)SettingsGrid.DataKeys[e.Item.ItemIndex];
//                int Val;
//                TextBox FieldValue = (TextBox)e.Item.FindControl("TxtValue");

//                if (FieldValue.Text == "")
//                {
//                    Msg.Text = "** Value Cannot be blank. No changes occured.";
//                    return;
//                }

//                try
//                {
//                    Val = Int32.Parse(FieldValue.Text);
//                }
//                catch
//                {
//                    Msg.Text = "** Value must be numeric and no decimal. No changes occured.";
//                    return;
//                }
//                db.UpdateValue(FieldName, Val);
//                Msg.Text = "";
//                //db.UpdateSingleUser(UserID, Int32.Parse(txtUserRole.SelectedValue), txtLoginID.Text, txtUsername.Text, txtDepartment.Text, txtContactNo.Text, Int32.Parse(Context.User.Identity.Name), Request.UserHostAddress);
//                SettingsGrid.EditItemIndex = -1;
//            }

//        }
//    }
//}
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
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if ((Request.Cookies["RoleCD"].Value != "RTAD") && (Request.Cookies["RoleCD"].Value != "RTFM"))
            {
                Response.Redirect("AccessDenied.aspx");
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindSettingsData();
            BindCCYData();
        }
        private void BindSettingsData()
        {
            FloraSoft.BankSettingsDB db = new FloraSoft.BankSettingsDB();
            FloraSoft.BankSettings bs = db.GetBankSettings();

            txtAutoMXAmnt.Text = bs.AutoMXAmnt.ToString("F2");
            txtCamtInterval.Text = bs.CamtInterval.ToString();
            chkSkipCBS.Checked = bs.SkipCBS;
            txtOutParkingGL.Text = bs.OutParkingGL;
            MorningCutOffHrList.SelectedValue = bs.MorCutOffHr.ToString();
            MorningCutOffMinList.SelectedValue = bs.MorCutOffMin.ToString();
            AfternoonCutOffHrList.SelectedValue = bs.AftrCutOffHr.ToString();
            AfternoonCutOffMinList.SelectedValue = bs.AftrCutOffMin.ToString();
        }

        private void BindCCYData()
        {
            CCYDB db = new CCYDB();
            MyDataGrid.DataSource = db.GetCCYList();
            MyDataGrid.DataBind();

            MyDataGrid.Items[0].Cells[2].Enabled = false;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            FloraSoft.BankSettingsDB db = new FloraSoft.BankSettingsDB();
            try
            {
                decimal AutoMXAmnt = 0;
                try
                {
                    AutoMXAmnt = decimal.Parse(txtAutoMXAmnt.Text);
                }
                catch { }
                int CamtInterval = 0;
                try
                {
                    CamtInterval = Int32.Parse(txtCamtInterval.Text);
                }
                catch { }

                bool SkipCBS = chkSkipCBS.Checked;
                string OutParkingGL = txtOutParkingGL.Text;

                int MorningCutOffHr = Int32.Parse(MorningCutOffHrList.SelectedValue);
                int MorningCutOffMin = Int32.Parse(MorningCutOffMinList.SelectedValue);

                int AfternoonCutOffHr = Int32.Parse(AfternoonCutOffHrList.SelectedValue);
                int AfternoonCutOffMin = Int32.Parse(AfternoonCutOffMinList.SelectedValue);

                db.UpdateBankSettings(AutoMXAmnt, CamtInterval, SkipCBS, OutParkingGL, MorningCutOffHr, MorningCutOffMin, AfternoonCutOffHr, AfternoonCutOffMin);
                Msg.Text = "Succesfully saved.";
            }
            catch (Exception ex)
            {
                Msg.Text = "Invalid Data: " + ex.Message;
            }

        }

        protected void MyDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            CCYDB db = new CCYDB();
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
                string CCY = (string)MyDataGrid.DataKeys[e.Item.ItemIndex];

                TextBox txtRate = (TextBox)e.Item.FindControl("Rate");
                TextBox txtPacs8 = (TextBox)e.Item.FindControl("Pacs08MinLimit");
                TextBox txtPacs9 = (TextBox)e.Item.FindControl("Pacs09MinLimit");

                decimal rate = 0;
                try
                {
                    rate = decimal.Parse(txtPacs8.Text);
                }
                catch { }
                if (rate != 0)
                {
                    db.UpdateRate(CCY, decimal.Parse(txtRate.Text), decimal.Parse(txtPacs8.Text), decimal.Parse(txtPacs9.Text));
                    lblMsg.Text = "Updated successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    lblMsg.Text = "Invalid rate";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                MyDataGrid.EditItemIndex = -1;
            }
        }

    }
}
