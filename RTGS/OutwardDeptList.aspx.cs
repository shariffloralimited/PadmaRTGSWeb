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
    public partial class OutwardDeptList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDept();
                BindStatusList();
                if ((Request.Params["SelectedDept"] != null) && (Request.Params["SelectedDept"] != ""))
                {
                    DeptList.SelectedValue = Request.Params["SelectedDept"];
                }
            }
        }
        private void BindDept()
        {
            DeptDB db = new DeptDB();
            DeptList.DataSource = db.GetDepts();
            DeptList.DataBind();
            DeptList.Items.Add(new ListItem("All", "0"));
            DeptList.SelectedValue = "0";
        }
        private void BindStatusList()
        {
            StatusDB db = new StatusDB();
            StatusList.DataSource = db.GetStatusByClearingType(0);
            StatusList.DataBind();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            OutwardDB db = new OutwardDB();
            DataTable dt = db.GetOutwardDeptList(Int32.Parse(DeptList.SelectedValue),0);

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

        protected void BtnChangeStatus_Click(object sender, EventArgs e)
        {
            OutwardDB db = new OutwardDB();
            db.ChangeStatus(MsgID.Text, Int32.Parse(StatusList.SelectedValue), Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
        }
    }

}