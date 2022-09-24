using System;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace RTGS
{
    public class ReportGen
    {
        public void SetDoc(Document document, string title, string str, string LogoImage, DataTable dt, string SettlementDate)
        {
            Font fnt = new Font(Font.HELVETICA, 6);
            Font fntblue = new Font(Font.HELVETICA, 6);
            fntblue.Color = new Color(0, 0, 255);
            Font fntbld = new Font(Font.HELVETICA, 6);
            fntbld.SetStyle(Font.BOLD);

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

            headertable.AddCell(title + " for " + SettlementDate + "\n");
            headertable.AddCell(logocell);
          
            document.Add(headertable);

            document.Add(new iTextSharp.text.Paragraph(" "));
            iTextSharp.text.pdf.PdfPTable datatable = new iTextSharp.text.pdf.PdfPTable(11);
            datatable.DefaultCell.Padding = 4;
            datatable.DefaultCell.BorderColor = new iTextSharp.text.Color(200, 200, 200);
            float[] headerwidths = { 6, 10, 10, 10, 10, 8, 10, 8, 6, 8, 6 };
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 99;

            iTextSharp.text.pdf.BaseFont bf = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.WINANSI, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);

            datatable.DefaultCell.BorderWidth = 0.5f;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            datatable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(200, 200, 200);
            //------------------------------------------
            datatable.AddCell(new iTextSharp.text.Phrase("Trans Type", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("MsgID", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Sending Branch", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Sender A/C No", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Sender Name", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Receiver A/C No", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Receiver Name", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Recieving Bank", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Amount", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("CCY", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Status", fnt));

            datatable.HeaderRows = 1;
            datatable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(255, 255, 255);
            datatable.DefaultCell.BorderWidth = 0.25f;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["FormName"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["MsgID"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["Branch"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DbtrAcctId"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DbtrNm"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CdtrAcctId"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CdtrNm"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["Bank"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase(((decimal)dt.Rows[i]["SttlmAmt"]).ToString("0.00"), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CCY"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["StatusName"]).ToString(), fnt));

            }

            //-------------TOTAL IN FOOTER --------------------
            datatable.AddCell(new iTextSharp.text.Phrase("Total Trans", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase((dt.Compute("COUNT(FormName)", "").ToString()), fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("Total Amount", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase(Utilities.ToMoney(dt.Compute("SUM(SttlmAmt)", "").ToString()), fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            //-------------END TOTAL -------------------------

            document.Add(datatable);

            //////////////////////////////////////////////

            document.Close();
            dt.Dispose();
        }

    }
}