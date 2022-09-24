using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;

namespace FloraSoft
{
    public class MTGenerator
    {
           public void GenMT103(string OutwardID)
           {
                RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
                RTGSImporter.Pacs008 pacs = db.GetSingleOutward08(OutwardID);

                string sessionno = "001";
                string sequenceno = System.DateTime.Now.ToString("hhmmss");
                string senderinputtime = System.DateTime.Now.ToString("hhmm");
                string recievroutputdt = System.DateTime.Now.ToString("yyMMdd");

                string SettlementAmount = pacs.IntrBkSttlmAmt.ToString("F2").Replace(".", ",");

                string txt = "{1:F"+"01"+pacs.FrBICFI.Substring(0,4)+ sessionno + sequenceno+ "}";
                txt = txt + "{2:O" + "103" + senderinputtime + recievroutputdt + pacs.FrBICFI.Substring(0,4)+ sessionno + sequenceno + "N}{3:{108:" + pacs.BizMsgIdr + "}}\r\n";
                txt = txt + "{4:\r\n";
                txt = txt + ":20:"+pacs.BizMsgIdr+"\r\n";
                txt = txt + ":23B:CRED\r\n";
                txt = txt + ":32A:"+ DateTime.Now.ToString("yyMMdd") + pacs.Ccy + SettlementAmount + "\r\n";
                txt = txt + ":50K:/" + pacs.DbtrAcctOthrId + "\r\n";
                txt = txt + pacs.DbtrNm + "\r\n";
                txt = txt + ":52A:" + pacs.FrBICFI + "\r\n";
                txt = txt + ":57A:" + pacs.CdtrAgtBICFI + "\r\n";
                txt = txt + ":59A:/" + pacs.CdtrAcctOthrId + "\r\n";
                txt = txt + pacs.CdtrNm + "\r\n";
                txt = txt + ":70:" + pacs.PmntRsn + "\r\n";
                txt = txt + ":71A:" + pacs.ChrgBr.Substring(0,3) +"\r\n";
                txt = txt + "-}\r\n";

                string filename = pacs.BizMsgIdr + ".txt";
                string path = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MT\\" + filename;
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs))
                    {
                        w.Write(txt);
                    }
                }

           }
           
           public void GenMT202(string OutwardID)
           {
               RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
               RTGSImporter.Pacs009 pacs = db.GetSingleOutward09(OutwardID);

               string SettlementAmount = pacs.IntrBkSttlmAmt.ToString("F2").Replace(".", ",");

               string txt = ":20:" + pacs.BizMsgIdr + "\r\n";
               txt = txt + ":21:" + DateTime.Now.ToString("dd MMM yyyy").ToUpper() + "\r\n";
               txt = txt + ":32A:" + DateTime.Now.ToString("yyMMdd") + pacs.IntrBkSttlmCcy + SettlementAmount + "\r\n";
               txt = txt + ":52A:" + pacs.FrBICFI + "XXX\r\n";
               txt = txt + ":56A:BBHOBDDHRTG\r\n";
               txt = txt + ":58A:" + pacs.CdtrBICFI + "\r\n";
               txt = txt + ":72:/XXX/XXXXXX\r\n";

               string filename = pacs.BizMsgIdr + ".txt";
               string path = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MT\\" + filename;
               using (FileStream fs = new FileStream(path, FileMode.Create))
               {
                   using (StreamWriter w = new StreamWriter(fs))
                   {
                       w.Write(txt);
                   }
               }
           }
    }
}