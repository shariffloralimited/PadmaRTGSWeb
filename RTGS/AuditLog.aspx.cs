using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.IO;

namespace RTGS
{
    public partial class AuditLog : System.Web.UI.Page
    {
        private System.Web.HttpResponse httpResponse;
        protected void Page_Init(object sender, EventArgs e)
        {
            string RoleCD = Request.Cookies["RoleCD"].Value;
            if ((RoleCD != "RTAD") && (RoleCD != "RTFM") && (RoleCD != "RTSA"))
            {
                Response.Redirect("AccessDenied.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime StartDate = System.DateTime.Today.AddDays(-1);
          
                ddlFrDay.SelectedValue = StartDate.Day.ToString().PadLeft(2, '0');
                ddlFrMonth.SelectedValue = System.DateTime.Today.Month.ToString().PadLeft(2, '0');
                ddlFrYear.SelectedValue = System.DateTime.Today.Year.ToString();



                //ddlFrDay.SelectedValue = System.DateTime.Today.Day.ToString().PadLeft(2, '0');
                //ddlFrMonth.SelectedValue = System.DateTime.Today.Month.ToString().PadLeft(2, '0');
                //ddlFrYear.SelectedValue = System.DateTime.Today.Year.ToString();

                DateTime NextDate = DateTime.Today.AddDays(0);

                ddlToDay.SelectedValue = NextDate.Day.ToString().PadLeft(2, '0');
                ddlToMonth.SelectedValue = NextDate.Month.ToString().PadLeft(2, '0');
                ddlToYear.SelectedValue = NextDate.Year.ToString();

                BindBranchList();
            }
        }

        private void BindBranchList()
        {
            BranchesDB db = new BranchesDB();
            BranchList.DataSource = db.GetSendBranches();
            BranchList.DataBind();

            //{
            //    BranchesDB db = new BranchesDB();
            //    BranchList.DataSource = db.GetSendBranches();
            //    BranchList.DataBind();
            //    BranchList.Items.Add(new System.Web.UI.WebControls.ListItem("All", "0"));
            //    BranchList.SelectedValue = "0";
            //    if (Request.Cookies["AllBranch"].Value != "False")
            //    {
            //        BranchList.SelectedValue = "0";
            //    }
            //    else
            //    {
            //        BranchList.SelectedValue = Request.Cookies["RoutingNo"].Value;
            //        BranchList.Enabled = false;
            //    }
            }
        
        private void BindEmpList()
        {
            UserDB db = new UserDB();
            EmpList.DataSource = db.GetUserByRoutingNo(BranchList.SelectedValue);
            EmpList.DataBind();
           EmpList.Items.Add(new ListItem("All"));
        }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            DateTime BeginDate;
            DateTime EndDate;

            try
            {
                BeginDate = new DateTime(Int32.Parse(ddlFrYear.SelectedValue), Int32.Parse(ddlFrMonth.SelectedValue), Int32.Parse(ddlFrDay.SelectedValue));
                EndDate = new DateTime(Int32.Parse(ddlToYear.SelectedValue), Int32.Parse(ddlToMonth.SelectedValue), Int32.Parse(ddlToDay.SelectedValue));
            }
            catch
            {
                BeginDate = System.DateTime.Today.AddDays(1);
                EndDate = System.DateTime.Today.AddDays(1);
            }

            TimeSpan t = EndDate - BeginDate;
            double NrOfDays = t.TotalDays;
            if (NrOfDays > 31)
            {
                lblRowCount.Text = "Date range can not be more than 31 days.";
                SearchGrid.Visible = false;
                return;
            }
            SearchGrid.Visible = true;

            DataTable dt = GetData();
            SearchGrid.DataSource = dt;
            SearchGrid.DataBind();

            lblRowCount.Text = dt.Rows.Count.ToString() + " row(s) found.";
            dt.Dispose();
            SearchGrid.Dispose();
        }



        private DataTable GetData()
        {
            string FrDt = ddlFrYear.SelectedValue + "-" + ddlFrMonth.SelectedValue + "-" + ddlFrDay.SelectedValue;
            string ToDt = ddlToYear.SelectedValue + "-" + ddlToMonth.SelectedValue + "-" + ddlToDay.SelectedValue;
            string EmpName = "All";
            if (EmpList.Items.Count > 0)
            {
                EmpName = EmpList.SelectedItem.Text;
            }

            AuditDB db = new AuditDB();
            DataTable dt = db.AuditSearch(ClearingType.SelectedItem.Text, FrDt, ToDt, BranchList.SelectedValue, EmpName, InputData.Text.Trim());

            return dt;
        }

        protected void ExcelBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = GetData();

            if (dt.Rows.Count > 0)
            {
                string xlsFileName = "AuditLog-D"+ System.DateTime.Today.ToString("yyyyMMdd") + "-T" + System.DateTime.Now.ToString("HHmmss") + ".xlsx";

                XLWorkbook workbook = new XLWorkbook();
                workbook.Worksheets.Add(dt, "Sheet1");

                // Prepare the response
                httpResponse = Response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string attachment = "attachment; filename=" + xlsFileName;
                httpResponse.AddHeader("content-disposition", attachment);

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                    memoryStream.Close();
                }

                dt.Dispose();
                httpResponse.End();

            }
        }

        protected void BranchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmpList();
        }

        public string Amount { get; set; }
    }
}