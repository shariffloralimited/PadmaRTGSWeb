using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

using ClosedXML.Excel;

namespace RTGS.Forms
{
    public partial class FinInstitutionCreditTransferBulk : System.Web.UI.Page
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
                string AppPath = Server.MapPath(".").Replace("\\Forms", "");

                string FileName = AppPath + "/Documents/" + DateTime.Today.Day.ToString() + "-" + Tick + ".xls";
                upload1.SaveAs(FileName);

                hf.ExecuteSQL("DELETE RTGSD.dbo.Outward09 WHERE Day <> " + System.DateTime.Today.Day.ToString());

                string returnmessage = hf.BulkExcelUpload(Maker, MakerIP, BranchCD, Tick, FileName, "RTGSD.dbo.Outward09");

                int RowsUploaded = hf.MoveToMain09(Tick);

                Msg.Text = returnmessage;

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
            InvalidList.DataSource = db.GetInvalidList("Pacs.009", HdnTick.Value);
            InvalidList.DataBind();
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Response.Redirect("../OutwardListMaker.aspx");
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            TransSearchDB db = new TransSearchDB();
            DataTable dt = db.GetInvalidList("Pacs.009", HdnTick.Value);

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

        public HttpResponse httpResponse { get; set; }
    }
}