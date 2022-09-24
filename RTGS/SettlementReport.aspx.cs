using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace RTGS
{
    public partial class SettlementReport : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string RoleCD = Request.Cookies["RoleCD"].Value;

            if ((RoleCD != "RTAD") && (RoleCD != "RTFM"))
            {
                if (Request.Cookies["AllBranch"].Value == "False")
                {
                    Response.Redirect("AccessDenied.aspx");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlDay.SelectedValue = System.DateTime.Today.Day.ToString().PadLeft(2, '0');
                ddlMonth.SelectedValue = System.DateTime.Today.Month.ToString().PadLeft(2, '0');
                ddlYear.SelectedValue = System.DateTime.Today.Year.ToString();
            }
        }

        private void BindData()
        {
            DataTable dt = GetData();
            BatchChecksGrid.DataSource = dt;
            try
            {
                BatchChecksGrid.Columns[1].FooterText = dt.Compute("SUM(iOCE)", "").ToString();
                BatchChecksGrid.Columns[2].FooterText = Utilities.ToMoney(dt.Compute("SUM(OCE)", "").ToString());
                BatchChecksGrid.Columns[3].FooterText = dt.Compute("SUM(iICE)", "").ToString();
                BatchChecksGrid.Columns[4].FooterText = Utilities.ToMoney(dt.Compute("SUM(ICE)", "").ToString());
            }
            catch 
            {
                BatchChecksGrid.Columns[1].FooterText = "0";
                BatchChecksGrid.Columns[2].FooterText = "0.00";
                BatchChecksGrid.Columns[3].FooterText = "0";
                BatchChecksGrid.Columns[4].FooterText = "0.00";
            }

            BatchChecksGrid.DataBind();
        }
        private DataTable GetData()
        {
            string SettlementDate = ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + ddlDay.SelectedValue;
            string Ccy = CurrencyList.SelectedValue;

            SettlementDB db = new SettlementDB();
            DataTable dt;
            if (SearchType.SelectedValue == "0")
            {
                dt = db.GetBankSettlement(SettlementDate, Ccy);
            }
            else
            {
                dt = db.GetBranchSettlement(SettlementDate, Ccy);
            }
            return dt;
        }

        protected void BtnGO_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void StartBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = GetData();

            if (dt.Rows.Count > 0)
            {
                string SettlementDate = ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + ddlDay.SelectedValue;
                string xlsFileName = "NetSettlementReport(" + SettlementDate + ")-D" + System.DateTime.Today.ToString("yyyyMMdd") + "-T" + System.DateTime.Now.ToString("HHmmss") + ".xlsx";

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

        public System.Web.HttpResponse httpResponse { get; set; }

        protected void PdfBtn_Click(object sender, EventArgs e)
        {
            PrintPDF("NetSettlementReport.pdf");
        }
        private void PrintPDF(string FileName)
        {
            DataTable dt = GetData();

            if (dt.Rows.Count == 0)
            {
                return;
            }
            string BankName  = Request.Cookies["BankName"].Value;
            string UserName  = Request.Cookies["UserName"].Value;
            string LogoImage = Server.MapPath("images") + "\\Bank Logo\\" + BankName + ".gif";

            Response.ClearContent();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);

            Document document = new Document(PageSize.A4, 10, 10, 8, 8);
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

            iTextSharp.text.Table headertable = new iTextSharp.text.Table(2);
            headertable.DefaultCell.Border = Rectangle.NO_BORDER;
            headertable.DefaultCell.VerticalAlignment = Cell.ALIGN_MIDDLE;
            headertable.Cellpadding = 0;
            headertable.Cellspacing = 0;
            headertable.Border = 0;
            headertable.Width = 99;

            //string headphrase = "Report Date and Time: " + System.DateTime.Now.ToString("dd/MM/yyyy hh:mm");

            //headertable.AddCell(new Phrase(headphrase, fntblue));

            string SettlementDate = ddlDay.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + ddlYear.SelectedValue + "\n";

            headertable.AddCell("RTGS Net Settlement Report for " + SettlementDate);
            headertable.AddCell(logocell);

            document.Add(headertable);

            document.Add(new iTextSharp.text.Paragraph(" "));
            iTextSharp.text.pdf.PdfPTable datatable = new iTextSharp.text.pdf.PdfPTable(5);
            datatable.DefaultCell.Padding = 4;
            datatable.DefaultCell.BorderColor = new iTextSharp.text.Color(200, 200, 200);
            float[] headerwidths = { 40, 10,20,10,20 };
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 99;

            iTextSharp.text.pdf.BaseFont bf = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.WINANSI, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);

            datatable.DefaultCell.BorderWidth = 0.5f;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            datatable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(200, 200, 200);
            //------------------------------------------

            PdfPCell c0 = new PdfPCell(new iTextSharp.text.Phrase("Bank Name", fnt));
            c0.BorderWidth = 0.5f;
            c0.HorizontalAlignment = Cell.ALIGN_LEFT;
            c0.BackgroundColor = new iTextSharp.text.Color(200, 200, 200);
            c0.BorderColor = new iTextSharp.text.Color(200, 200, 200);
            c0.Padding = 4;
            datatable.AddCell(c0);
            datatable.AddCell(new iTextSharp.text.Phrase("Outward Quantity", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Outward Amount", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Inward Quantity", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Inward Amount", fnt));

            datatable.HeaderRows = 1;
            datatable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(255, 255, 255);
            datatable.DefaultCell.BorderWidth = 0.25f;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PdfPCell c1 = new PdfPCell(new iTextSharp.text.Phrase((string)dt.Rows[i]["Name"],fnt));
                c1.BorderWidth = 0.5f;
                c1.HorizontalAlignment = Cell.ALIGN_LEFT;
                c1.BorderColor = new iTextSharp.text.Color(200, 200, 200);
                c1.Padding = 4;
                datatable.AddCell(c1);
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["iOCE"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase(((decimal)dt.Rows[i]["OCE"]).ToString("0.00"), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["iICE"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase(((decimal)dt.Rows[i]["ICE"]).ToString("0.00"), fnt));
            }

            //-------------TOTAL IN FOOTER --------------------
            datatable.AddCell(new iTextSharp.text.Phrase("TOTAL", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase(dt.Compute("SUM(iOCE)", "").ToString(), fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase(Utilities.ToMoney(dt.Compute("SUM(OCE)", "").ToString()), fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase(dt.Compute("SUM(iICE)", "").ToString(), fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase(Utilities.ToMoney(dt.Compute("SUM(ICE)", "").ToString()), fntbld));
            //-------------END TOTAL -------------------------

            document.Add(datatable);

            //////////////////////////////////////////////

            document.Close();
            Response.End();
        }
    }
}
