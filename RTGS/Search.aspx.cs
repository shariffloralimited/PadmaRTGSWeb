using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RTGS
{
    public class SearchData
    {
        public int      FormID            = 1;
        public int      DeptID            = 0;
        public string   BranchID          = "";
        public string   SenderActNo       = "";
        public string   ReceiversAct      = "";
        public string   FrSettlementDate  = "";
        public string   ToSettlementDate = "";
        public string   CCY = "All";
        public string   OtherBank         = "";
        public string   Comparer          = "=";
        public decimal  Amount            = 0;
        public string   RtrRsnAddtlInf = "";

    }
    public partial class Search : System.Web.UI.Page
    {
        SearchData data = new SearchData();
        private HttpResponse httpResponse;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlFrDay.SelectedValue   = System.DateTime.Today.Day.ToString().PadLeft(2, '0');
                ddlFrMonth.SelectedValue = System.DateTime.Today.Month.ToString().PadLeft(2,'0');
                ddlFrYear.SelectedValue  = System.DateTime.Today.Year.ToString();

                DateTime NextDate = DateTime.Today.AddDays(0);
              //  DateTime NextDate = DateTime.Today.AddDays(1);

                ddlToDay.SelectedValue = NextDate.Day.ToString().PadLeft(2, '0');
                ddlToMonth.SelectedValue = NextDate.Month.ToString().PadLeft(2, '0');
                ddlToYear.SelectedValue = NextDate.Year.ToString();

                BindBanks();
                BindCCY();
                if (Request.Cookies["DeptBanking"].Value != "False")
                {
                    ChkDept.Text = "Department";
                    ddlBranchList.Visible = false;
                    ddlDeptList.Visible = true;
                    BindDept();
                }
                else
                {
                    ChkDept.Text = "Branch";
                    ddlBranchList.Visible = true;
                    ddlDeptList.Visible = false;
                    BindBranch();
                }


            }
        }
        private void BindBanks()
        {
            BanksDB db = new BanksDB();

            ddListOtherBank.DataSource = db.GetSendBanks();
            ddListOtherBank.DataBind();

        }
        private void BindDept()
        {
            DeptDB db = new DeptDB();

            ddlDeptList.DataSource = db.GetDepts();
            ddlDeptList.DataBind();
        }
        private void BindBranch()
        {
            BranchesDB db = new BranchesDB();
            ddlBranchList.DataSource = db.GetSendBranches();
            ddlBranchList.DataBind();
            if (Request.Cookies["AllBranch"].Value != "False")
            {
                ddlBranchList.SelectedValue = "0";
            }
            else
            {
                ddlBranchList.SelectedValue = Request.Cookies["RoutingNo"].Value;
                ddlBranchList.Enabled = false;
                ChkDept.Checked = true;
                ChkDept.Enabled = false;
            }
        }
        private void BindCCY()
        {
            CCYDB db = new CCYDB();
            ddListCCY.DataSource = db.GetCCYList();
            ddListCCY.DataBind();
        }
        private void SetData()
        {
            if (ChkSenderActNo.Checked)
            {
                data.SenderActNo = TxtSenderActNo.Text.Trim();
            }
            if (ChkReceiversAct.Checked)
            {
                data.ReceiversAct = TxtReceiversAct.Text.Trim();
            }
            if (ChkDept.Checked)
            {
                if (Request.Cookies["DeptBanking"].Value != "False")
                {
                    data.DeptID = Int32.Parse(ddlDeptList.SelectedValue);
                }
                else
                {
                    data.BranchID = ddlBranchList.SelectedValue;
                }
            }

           data.FrSettlementDate = ddlFrYear.SelectedValue + "-" + ddlFrMonth.SelectedValue + "-" + ddlFrDay.SelectedValue;
           data.ToSettlementDate = ddlToYear.SelectedValue + "-" + ddlToMonth.SelectedValue + "-" + ddlToDay.SelectedValue;
           if (ChkCCY.Checked)
            {
                data.CCY = ddListCCY.SelectedItem.Text;
            }
            if (ChkOtherBank.Checked)
            {
                data.OtherBank = ddListOtherBank.SelectedValue;
            }
            
            if(ChkAmount.Checked)
            {
                data.Comparer = ddlListComparer.SelectedItem.Text;
                try
                {
                    data.Amount = Decimal.Parse(TxtAmount.Text);
                }
                catch
                {
                    data.Amount = 0;
                }
            }
            data.FormID = Int32.Parse(ddlFormID.SelectedValue);           
        }
        private DataTable GetData()
        {
            SetData();

            DataTable dt;
            SearchDB db = new SearchDB();


            if (data.FormID < 11)
            {
                dt = db.SearchOutward(data);
            }
            else
            {
                dt = db.SearchInward(data);
            }
            return dt;
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
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
                return;
            }

            DataTable dt = GetData();
            SearchGrid.DataSource = dt;
            SearchGrid.DataBind();

            lblRowCount.Text = dt.Rows.Count.ToString() + " row(s) found.";

            dt.Dispose();
            SearchGrid.Dispose();
        }
        protected void ExcelBtn_Click(object sender, EventArgs e)
        {

            DataTable dt = GetData();

            if (dt.Rows.Count > 0)
            {
                string xlsFileName = "NetSettlementReport-D" + System.DateTime.Today.ToString("yyyyMMdd") + "-T" + System.DateTime.Now.ToString("HHmmss") + ".xlsx";

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

                httpResponse.End();

            }
        }
        private void PrintDeptPDF(string FileName)
        {
            DataTable dt = GetData();

            if (dt.Rows.Count == 0)
            {
                return;
            }
            string BankName = Request.Cookies["BankName"].Value;
            string UserName = Request.Cookies["UserName"].Value;
            string LogoImage = Server.MapPath("images") + "\\Bank Logo\\" + BankName + ".gif";

            Response.ClearContent();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);

            Document document = new Document(PageSize.A4.Rotate(), 10, 10, 8, 8);
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);

            Font fnt = new Font(Font.HELVETICA, 6);
            Font fntblue = new Font(Font.HELVETICA, 6);
            fntblue.Color = new Color(0, 0, 255);
            Font fntbld = new Font(Font.HELVETICA, 6);
            fntbld.SetStyle(Font.BOLD);

            string spacer = "            -              ";

            string str = UserName + spacer;
            str = str + BankName + ": All Rights Reserved" + spacer;
            str = str + "Confidential: internal use only" + spacer;
            str = str + "Powered By Flora Limited";

            
            HeaderFooter footer = new HeaderFooter(new Phrase(str, fnt), false);
            footer.Alignment = Element.ALIGN_CENTER;
            

            document.Footer = footer;
            document.Open();

            iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance(LogoImage);
            jpeg.Alignment = Element.ALIGN_RIGHT;
            Cell logocell = new Cell();
            logocell.Add(jpeg);

            iTextSharp.text.Table headertable = new iTextSharp.text.Table(3);
            headertable.DefaultCell.Border = Rectangle.NO_BORDER;
            headertable.DefaultCell.VerticalAlignment = Cell.ALIGN_BOTTOM;
            headertable.Cellpadding = 0;
            headertable.Cellspacing = 0;
            headertable.Border = 0;
            headertable.Width = 100;

            string headphrase = "Report Date and Time: " + System.DateTime.Now.ToString("dd/MM/yyyy hh:mm");

            headertable.AddCell(new Phrase(headphrase, fntblue));

            headertable.AddCell(logocell);

            document.Add(headertable);

            document.Add(new iTextSharp.text.Paragraph(" "));
            iTextSharp.text.pdf.PdfPTable datatable = new iTextSharp.text.pdf.PdfPTable(12);
            datatable.DefaultCell.Padding = 4;
            datatable.DefaultCell.BorderColor = new iTextSharp.text.Color(200, 200, 200);
            //float[] headerwidths = { 6, 6, 12, 10, 8, 6, 16, 8, 16, 8, 6 };
            float[] headerwidths = { 6, 14, 8, 14, 9, 11, 8, 10, 12, 6, 7, 5 };
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 99;

            iTextSharp.text.pdf.BaseFont bf = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.WINANSI, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);

            datatable.DefaultCell.BorderWidth = 0.5f;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            datatable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(200, 200, 200);
            //------------------------------------------

            datatable.AddCell(new iTextSharp.text.Phrase("Form", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("MsgID", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Bank", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Branch", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Dept", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Amount", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("CCY", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Sender", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Senders A/C", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Receivers", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Receivers A/C", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Status", fnt));

            datatable.HeaderRows = 1;
            datatable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(255, 255, 255);
            datatable.DefaultCell.BorderWidth = 0.25f;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["FormName"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["BizMsgIdr"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["BankBIC"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["Branch"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DeptName"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase(((decimal)dt.Rows[i]["SttlmAmt"]).ToString("0.00"), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["Ccy"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DbtrNm"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DbtrAcctId"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CdtrNm"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CdtrAcctId"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["StatusName"]).ToString(), fnt));

            }

            //-------------TOTAL IN FOOTER --------------------
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase(Utilities.ToMoney(dt.Compute("SUM(SttlmAmt)", "").ToString()), fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            //-------------END TOTAL -------------------------

            document.Add(datatable);

            //////////////////////////////////////////////

            document.Close();
            Response.End();
        }
        private void PrintPDF(string FileName)
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
                return;
            }

            DataTable dt = GetData();

            if (dt.Rows.Count == 0)
            {
                return;
            }
            string BankName = Request.Cookies["BankName"].Value;
            string UserName = Request.Cookies["UserName"].Value;
            string LogoImage = Server.MapPath("images") + "\\Bank Logo\\" + BankName + ".gif";

            Response.ClearContent();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);

            Document document = new Document(PageSize.A4.Rotate(), 10, 10, 8, 8);
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);

            Font fnt = new Font(Font.HELVETICA, 6);
            Font fntblue = new Font(Font.HELVETICA, 13);
            fntblue.Color = new Color(0, 0, 255);
            Font fntbld = new Font(Font.HELVETICA, 8);
            fntbld.SetStyle(Font.BOLD);

            string spacer = "            -              ";

            string str = UserName + spacer;
            str = str + BankName + ": All Rights Reserved" + spacer;
            str = str + "Confidential: internal use only" + spacer;
            str = str + "Powered By Flora Limited";

            HeaderFooter footer = new HeaderFooter(new Phrase(str, fnt), false);
            footer.Alignment = Element.ALIGN_CENTER;

            document.Footer = footer;
            document.Open();

            iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance(LogoImage);
           jpeg.Alignment = Element.ALIGN_RIGHT;
           Cell logocell = new Cell();
            logocell.Add(jpeg);

            iTextSharp.text.Table headertable = new iTextSharp.text.Table(3);
            headertable.DefaultCell.Border = Rectangle.NO_BORDER;
            headertable.DefaultCell.VerticalAlignment = Cell.ALIGN_LEFT;
            headertable.Cellpadding = 0;
            headertable.Cellspacing = 0;
            headertable.Border = 0;
            headertable.Width = 100;
           
            string ReportType = "Inward";
            if (data.FormID < 11)
            {
                ReportType = "Outward";
            }
            string Test = "Report Date and Time: " + System.DateTime.Now.ToString("dd/MM/yyyy hh:mm");

           headertable.AddCell(new Phrase("", fntblue));

            string headphrase = "RTGS " + ReportType + " Search Report" + "\n" + Test;

            headertable.AddCell(headphrase +  "\n");
            headertable.AddCell(logocell);

            document.Add(headertable);

            document.Add(new iTextSharp.text.Paragraph(" "));
            iTextSharp.text.pdf.PdfPTable datatable = new iTextSharp.text.pdf.PdfPTable(12);
            datatable.DefaultCell.Padding = 1;
            datatable.DefaultCell.BorderColor = new iTextSharp.text.Color(200, 200, 200);
            float[] headerwidths = { 6, 12, 7, 10, 10, 12, 9, 12, 12, 5, 8, 7 };
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 99;

            iTextSharp.text.pdf.BaseFont bf = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.WINANSI, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);

            datatable.DefaultCell.BorderWidth = 0.5f;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            datatable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(200, 200, 200);

            //------------------------------------------
            if (data.FormID < 11)
            {
                datatable.AddCell(new iTextSharp.text.Phrase("Stlmnt Date", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("MsgID", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Trans Type", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Sending Branch", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Sender Name", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Sender A/C No", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Receiving Bank", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Receiver Name", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Receiver A/C No", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("CCY", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Amount", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Status", fnt));
            }
            else
            {

                datatable.AddCell(new iTextSharp.text.Phrase("Stlmnt Date", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("MsgID", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Trans Type", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Receiving Branch", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Receiver Name", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Receiver A/C No", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Sender Bank", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Sender Name", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Sender A/C No", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("CCY", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Amount", fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("Status", fnt));
            }
            //------------------------------------------


            datatable.HeaderRows = 1;
            datatable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(255, 255, 255);
            datatable.DefaultCell.BorderWidth = 0.25f;
            if (data.FormID < 11)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["SttlmDt"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["BizMsgIdr"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["FormName"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["Branch"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DbtrNm"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DbtrAcctId"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["BankBIC"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CdtrNm"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CdtrAcctId"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CCY"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase(((decimal)dt.Rows[i]["SttlmAmt"]).ToString("0.00"), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["StatusName"]).ToString(), fnt));

                }

                //-------------TOTAL IN FOOTER --------------------
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("Total", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Compute("COUNT(FormName)", "").ToString()), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                //datatable.AddCell(new iTextSharp.text.Phrase((dt.Compute("COUNT(DbtrAcctId)", "").ToString()), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("Total", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase(Utilities.ToMoney(dt.Compute("SUM(SttlmAmt)", "").ToString()), fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            }

            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["SttlmDt"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["BizMsgIdr"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["FormName"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["Branch"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CdtrNm"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CdtrAcctId"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["BankBIC"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DbtrNm"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DbtrAcctId"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CCY"]).ToString(), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase(((decimal)dt.Rows[i]["SttlmAmt"]).ToString("0.00"), fnt));
                    datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["StatusName"]).ToString(), fnt));
               
                
                }

                //-------------TOTAL IN FOOTER --------------------
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("Total", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Compute("COUNT(FormName)", "").ToString()), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                //datatable.AddCell(new iTextSharp.text.Phrase((dt.Compute("COUNT(DbtrAcctId)", "").ToString()), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("Amount", fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase(Utilities.ToMoney(dt.Compute("SUM(SttlmAmt)", "").ToString()), fntbld));
                datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            }
            
            document.Add(datatable);

            document.Close();
            Response.End();
        }
        protected void PdfBtn_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["DeptBanking"].Value != "False")
            {
                PrintDeptPDF("SearchResult.pdf");
            }
            else
            {
                PrintPDF("SearchResult.pdf");
            }
        }
    }
}

