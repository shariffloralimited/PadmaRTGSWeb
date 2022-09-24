using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using ClosedXML.Excel;

namespace RTGS
{
    public partial class CustomerCreditBulk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["RoleCD"].Value != "RTMK")
            {
                Response.Redirect("../AccessDenied.aspx");
            }
            if (!Page.IsPostBack)
            {
                DeletePastDocuments();
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../OutwardListMaker.aspx");
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            LoadExcel();
        }
        private void LoadExcel()
        {
            if (upload1.HasFile)
            {
                HdnTick.Value = System.DateTime.Now.Ticks.ToString();

                FloraSoft.HUBFile hf = new FloraSoft.HUBFile();

                //string ContentType = upload1.PostedFile.ContentType;
                //if (ContentType != "text/plain")
                //{
                //    Msg.Text = "Uploaded File is not an excel file.";
                //    return;
                //}

                string Maker = Request.Cookies["UserName"].Value;
                string MakerIP = HttpContext.Current.Request.UserHostAddress;
                string BranchCD = Request.Cookies["BranchCD"].Value;
                string Tick = HdnTick.Value;

                string postedfilename = upload1.FileName;
                string AppPath = Server.MapPath(".").Replace("\\Forms","");

                string FileName = AppPath + "/Documents/" + DateTime.Today.Day.ToString() + "-" + Tick + ".xls";
                upload1.SaveAs(FileName);

                
                hf.ExecuteSQL("DELETE RTGSD.dbo.Outward08 WHERE Day <> "+ System.DateTime.Today.Day.ToString());

                string returnmessage = hf.BulkExcelUpload(Maker, MakerIP, BranchCD, Tick, FileName, "RTGSD.dbo.Outward08");

                hf.ValidateData08(Tick);

                //Validate(Tick);

                int RowsUploaded = hf.MoveToMain08(Tick);

                //Msg.Text = returnmessage;

                BindInvalidList(Tick);

                int RowsFailed = InvalidList.Rows.Count;

                Msg.Text = RowsUploaded.ToString() + " rows uploaded. " + RowsFailed.ToString() + " rows invalid.";
                btnProcess.Visible = true;
            }
        }

        private void DeletePastDocuments()
        {
            string AppPath = Server.MapPath(".").Replace("\\Forms", "") + "/Documents";
            
            string[] files = Directory.GetFiles(AppPath);
            foreach (string file in files)
            {
                if (File.GetCreationTime(file).Day != System.DateTime.Today.Day)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        private void BindInvalidList(string Tick)
        {
            TransSearchDB db = new TransSearchDB();
            InvalidList.DataSource = db.GetInvalidList("Pacs.008", HdnTick.Value);
            InvalidList.DataBind();
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Response.Redirect("../OutwardListMaker.aspx");
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            TransSearchDB db = new TransSearchDB();
            DataTable dt = db.GetInvalidList("Pacs.008", HdnTick.Value);

            dt.Columns.RemoveAt(4);
            dt.Columns.RemoveAt(3);
            dt.Columns.RemoveAt(2);
            dt.Columns.RemoveAt(1);
            dt.Columns.RemoveAt(0);

            if (dt.Rows.Count > 0)
            {
                string xlsFileName = "Invalid_List" + System.DateTime.Today.ToString("yyyyMMdd") + "-T" + System.DateTime.Now.ToString("HHmmss") + ".xlsx";

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

        //protected void ValidateCBS(string Tick)
        //{
        //    RTGSWS.Service1 ws = new RTGSWS.Service1();
        //    CustomerInfo ci = new CustomerInfo();

        //    TransSearchDB db = new TransSearchDB();
        //    SqlDataReader dr = db.GetValidList(Tick);
        //    while (dr.Read())
        //    {
        //        string RefNo = (string) dr["RefNo"];
        //        string ActNo = (string) dr["DebitorAccountNo"];
        //        decimal amnt = Decimal.Parse(dr["Amount"].ToString());
        //        string CCY = (string)dr["CCY"];
        //        string str = ws.GetAccountInfo(ActNo, amnt, CCY);
        //        if (str.IndexOf("Result=NOT FOUND") > -1)
        //        {
        //            db.UpdateRow(Tick, true, RefNo, "Result=NOT FOUND");
        //        }
        //        else
        //        {
        //            DataTable dt = ci.GetCustomerTable(str);
        //            string Msg = ValidateUBSAccount(ActNo, CCY, amnt, dt);
        //            if (Msg == "OK")
        //            {
        //                db.UpdateRow(Tick, false, RefNo, RefNo + '-' + str);
        //            }
        //            else
        //            {
        //                db.UpdateRow(Tick, true, RefNo, Msg);
        //            }

        //            dt.Dispose();
        //        }
        //    }
        //    dr.Close();
        //    dr.Dispose();
        //}
        //private string ValidateUBSAccount(string ActNo, string CCY, decimal amnt, DataTable dt)
        //{
        //    string AccountNo = dt.Rows[0][1].ToString();
        //    string ActCCY = dt.Rows[2][1].ToString();
        //    string CurrentBalance = dt.Rows[3][1].ToString();
        //    string Success = dt.Rows[4][1].ToString();
        //    string Blocked = dt.Rows[5][1].ToString();
        //    string Dormant = dt.Rows[6][1].ToString();
        //    string Closed = dt.Rows[7][1].ToString();
        //    string Deceased = dt.Rows[8][1].ToString();
        //    string AccountName = dt.Rows[10][1].ToString();

        //    string branchCD = Request.Cookies["BranchCD"].Value;
        //    string AcctCD = AccountNo.Substring(0, 3);
        //    string Msg = "OK";

        //    if ((ActCCY != "BDT") && (branchCD != AcctCD))
        //    {
        //        Msg = "Foreign Currency transaction is not allowed from this Branch";

        //    }
        //    if (ActCCY == "")
        //    {
        //        Msg = "Account Verification Needed.";
        //    }
        //    if (AccountNo != ActNo)
        //    {
        //        Msg = "Account Verification Needed.";
        //    }
        //    if (CCY != ActCCY)
        //    {
        //        Msg = "Wrong Currency.";
        //    }

        //    Decimal currentbalance = Decimal.Parse(CurrentBalance);
        //    if (currentbalance < amnt)
        //    {
        //        Msg = "Insufficient Balance.";
        //    }
        //    return Msg;
        //}
        public HttpResponse httpResponse { get; set; }
    }
}