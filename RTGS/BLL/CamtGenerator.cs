using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Configuration;

namespace FloraSoft
{
    public class CamtGenerator
    {
        public void GenCam03(string CCY)
        {
            RTGS.BankAccountsDB dbo = new RTGS.BankAccountsDB();
            string AcctId = dbo.GetSingleBankAccount(CCY);

            FloraSoft.BankSettingsDB db = new FloraSoft.BankSettingsDB();
            FloraSoft.BankSettings bs = db.GetBankSettings();

            string MsgId = bs.BIC.Substring(0, 4) + "3"  + System.DateTime.Today.ToString("MMdd")+ System.DateTime.Now.ToString("HHmmss");
            string CreDtTm = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            //string QryNm = "STAT";
            string OrgIdAnyBIC = bs.BIC;

            string xmlstr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            xmlstr = xmlstr + " <Saa:DataPDU xmlns:Saa=\"urn:swift:saa:xsd:saa.2.0\" xmlns:Sw=\"urn:swift:snl:ns.Sw\" xmlns:SwGbl=\"urn:swift:snl:ns.SwGbl\" xmlns:SwInt=\"urn:swift:snl:ns.SwInt\" xmlns:SwSec=\"urn:swift:snl:ns.SwSec\">";
            xmlstr = xmlstr + " <Saa:Body>";

            xmlstr = xmlstr + "<AppHdr xmlns:auto-ns1=\"urn:swift:saa:xsd:saa.2.0\" xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">";
            xmlstr = xmlstr + "<Fr>";
            xmlstr = xmlstr + "<FIId>";
            xmlstr = xmlstr + "<FinInstnId>";
            xmlstr = xmlstr + "<BICFI>" + bs.BIC + "</BICFI>";
            xmlstr = xmlstr + "</FinInstnId>";
            xmlstr = xmlstr + "</FIId>";
            xmlstr = xmlstr + "</Fr>";
            xmlstr = xmlstr + "<To>";
            xmlstr = xmlstr + "<FIId>";
            xmlstr = xmlstr + "<FinInstnId>";
            xmlstr = xmlstr + "<BICFI>" + bs.BBBIC + "</BICFI>";
            xmlstr = xmlstr + "</FinInstnId>";
            xmlstr = xmlstr + "</FIId>";
            xmlstr = xmlstr + "</To>";
            xmlstr = xmlstr + "<BizMsgIdr>" + MsgId + "</BizMsgIdr>";
            xmlstr = xmlstr + "<MsgDefIdr>camt.003.001.05</MsgDefIdr>";
            xmlstr = xmlstr + "<BizSvc>RTGS</BizSvc>";
            xmlstr = xmlstr + "<CreDt>" + CreDtTm + "Z" + "</CreDt>";
            xmlstr = xmlstr + "</AppHdr>";

            xmlstr = xmlstr + "<Document xmlns=\"urn:swift:xsd:camt.003.001.05\"  xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">";
            xmlstr = xmlstr + "<GetAcct>";
            xmlstr = xmlstr + "<MsgHdr>";
            xmlstr = xmlstr + "<MsgId>" + MsgId + "</MsgId>";
            xmlstr = xmlstr + "<CreDtTm>" + CreDtTm + "</CreDtTm>";
            xmlstr = xmlstr + "</MsgHdr>";
            xmlstr = xmlstr + "<AcctQryDef>";
            xmlstr = xmlstr + "<AcctCrit>";
            //xmlstr = xmlstr + "<QryNm>" + QryNm + "</QryNm>";
            xmlstr = xmlstr + "<NewCrit>";
            xmlstr = xmlstr + "<SchCrit>";
            xmlstr = xmlstr + "<AcctId>";
            xmlstr = xmlstr + "<EQ>";
            xmlstr = xmlstr + "<Othr>";
            xmlstr = xmlstr + "<Id>" + AcctId + "</Id>";
            xmlstr = xmlstr + "</Othr>";
            xmlstr = xmlstr + "</EQ>";
            xmlstr = xmlstr + "</AcctId>";
            xmlstr = xmlstr + "<AcctOwnr>";
            xmlstr = xmlstr + "<Id>";
            xmlstr = xmlstr + "<OrgId>";
            xmlstr = xmlstr + "<AnyBIC>" + OrgIdAnyBIC + "</AnyBIC>";
            xmlstr = xmlstr + "</OrgId>";
            xmlstr = xmlstr + "</Id>";
            xmlstr = xmlstr + "</AcctOwnr>";
            xmlstr = xmlstr + "</SchCrit>";
            xmlstr = xmlstr + "</NewCrit>";
            xmlstr = xmlstr + "</AcctCrit>";
            xmlstr = xmlstr + "</AcctQryDef>";
            xmlstr = xmlstr + "</GetAcct>";
            xmlstr = xmlstr + "</Document>";
            xmlstr = xmlstr + " </Saa:Body>";
            xmlstr = xmlstr + "</Saa:DataPDU>";

            string FolderName = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX\\";
            string FileName = MsgId + ".xml";
            string path = FolderName + FileName;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            if (File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;
                if (length > 1024)
                {
                    RTGS.BBOutwardDB bbdb = new RTGS.BBOutwardDB();
                    bbdb.InsertBBOutwardDB("camt.003", "", MsgId, "", "", "", "00000000-0000-0000-0000-000000000000", "");
                }
            }

        }
        public void GenCamt05(string OutwardID, string FormName, string TxId, string PrtryId)   //Stat of Transfer : Queue Summary : Duplicate Copy
        {
            BankSettingsDB db = new BankSettingsDB();
            BankSettings bs = db.GetBankSettings();

            //string MsgId = bs.BIC.Substring(0, 4) + System.DateTime.Today.ToString("yyMMdd") + "05" + System.DateTime.Now.ToString("HHmmss");  
            string MsgId = bs.BIC.Substring(0, 4) + "05" + System.DateTime.Today.ToString("MMdd") + System.DateTime.Now.ToString("HHmmss");
            
            string CrDtTm = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            string xmlstr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

            //xmlstr = xmlstr + "<Saa:DataPDU xmlns:Saa=\"urn:swift:saa:xsd:saa.2.0\" xmlns:Sw=\"urn:swift:snl:ns.Sw\" xmlns:SwGbl=\"urn:swift:snl:ns.SwGbl\" xmlns:SwInt=\"urn:swift:snl:ns.SwInt\" xmlns:SwSec=\"urn:swift:snl:ns.SwSec\">";

            xmlstr = xmlstr + "<Saa:DataPDU xmlns:Saa=\"urn:swift:saa:xsd:saa.2.0\" xmlns:Sw=\"urn:swift:snl:ns.Sw\" xmlns:SwGbl=\"urn:swift:snl:ns.SwGbl\" xmlns:SwInt=\"urn:swift:snl:ns.SwInt\" xmlns:SwSec=\"urn:swift:snl:ns.SwSec\">";
            
            xmlstr = xmlstr + "<Saa:Body>";
            //xmlstr = xmlstr + "<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:camt.005.001.05\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";

            xmlstr = xmlstr + "<AppHdr:AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\" xmlns:AppHdr=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
            xmlstr = xmlstr + "<Fr>";
            xmlstr = xmlstr + "<FIId>";
            xmlstr = xmlstr + "<FinInstnId>";
            xmlstr = xmlstr + "<BICFI>" + bs.BIC + "</BICFI>";
            xmlstr = xmlstr + "</FinInstnId>";
            xmlstr = xmlstr + "</FIId>";
            xmlstr = xmlstr + "</Fr>";
            xmlstr = xmlstr + "<To>";
            xmlstr = xmlstr + "<FIId>";
            xmlstr = xmlstr + "<FinInstnId>";
            xmlstr = xmlstr + "<BICFI>" + bs.BBBIC + "</BICFI>";
            xmlstr = xmlstr + "</FinInstnId>";
            xmlstr = xmlstr + "</FIId>";
            xmlstr = xmlstr + "</To>";
            xmlstr = xmlstr + "<BizMsgIdr>" + MsgId + "</BizMsgIdr>";
            xmlstr = xmlstr + "<MsgDefIdr>camt.005.001.05</MsgDefIdr>";
            xmlstr = xmlstr + "<BizSvc>RTGS</BizSvc>";
            xmlstr = xmlstr + "<CreDt>" + CrDtTm + "Z" + "</CreDt>";
            xmlstr = xmlstr + "</AppHdr:AppHdr>";
            
            xmlstr = xmlstr + "<Document xmlns=\"urn:swift:xsd:camt.005.001.05\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">";
            xmlstr = xmlstr + "<GetTx>";
            xmlstr = xmlstr + "<MsgHdr>";
            xmlstr = xmlstr + "<MsgId>" + MsgId + "</MsgId>";
            xmlstr = xmlstr + "<CreDtTm>" + CrDtTm + "Z" + "</CreDtTm>";
            xmlstr = xmlstr + "<ReqTp>";
            xmlstr = xmlstr + "<Prtry>";
            xmlstr = xmlstr + "<Id>" + PrtryId + "</Id>";
            xmlstr = xmlstr + "</Prtry>";
            xmlstr = xmlstr + "</ReqTp>";
            xmlstr = xmlstr + "</MsgHdr>";
            xmlstr = xmlstr + "<TxQryDef>";
            xmlstr = xmlstr + "<TxCrit>";
            xmlstr = xmlstr + "<NewCrit>";
            xmlstr = xmlstr + "<SchCrit>";
            xmlstr = xmlstr + "<PmtFr>";
            xmlstr = xmlstr + "<MmbId>";
            xmlstr = xmlstr + "<FinInstnId>";
            xmlstr = xmlstr + "<BICFI>" + bs.BIC + "</BICFI>";
            xmlstr = xmlstr + "</FinInstnId>";
            xmlstr = xmlstr + "</MmbId>";
            xmlstr = xmlstr + "</PmtFr>";
            xmlstr = xmlstr + "<PmtSch>";
            xmlstr = xmlstr + "<TxId>" + TxId + "</TxId>";
            xmlstr = xmlstr + "<IntrBkSttlmDt>"+ System.DateTime.Now.ToString("yyyy-MM-dd") +"</IntrBkSttlmDt>";
            xmlstr = xmlstr + "</PmtSch>";
            xmlstr = xmlstr + "</SchCrit>";
            xmlstr = xmlstr + "</NewCrit>";
            xmlstr = xmlstr + "</TxCrit>";
            xmlstr = xmlstr + "</TxQryDef>";
            xmlstr = xmlstr + "</GetTx>";
            xmlstr = xmlstr + "</Document>";

            xmlstr = xmlstr + "</Saa:Body>";
            xmlstr = xmlstr + "</Saa:DataPDU>";

            string filename = MsgId + ".xml";
            string path = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX\\" + filename;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            if (File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;
                if (length > 1024)
                {
                    RTGS.BBOutwardDB bbdb = new RTGS.BBOutwardDB();
                    bbdb.InsertBBOutwardDB("camt.005", "", MsgId, "", TxId, "", OutwardID, FormName);
                }
            }

        }
        public void GenCamt07(string OutwardID, string FormName, string PrtryId)                //Change Priority
        {
            BankSettingsDB bsdb = new BankSettingsDB();
            BankSettings bs = bsdb.GetBankSettings();

            string BizMsgIdr = bs.BIC.Substring(0, 4) + System.DateTime.Today.ToString("yyyyMMdd") + "107" + System.DateTime.Now.ToString("HHmmssf");
            //string MsgId = bs.BIC.Substring(0, 4) + System.DateTime.Today.ToString("yyMMdd") + "07" + System.DateTime.Now.ToString("HHmmss");
            string MsgId = bs.BIC.Substring(0, 4) + "07" + System.DateTime.Today.ToString("MMdd") + System.DateTime.Now.ToString("HHmmss");
            
            string CreDtTm = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            string txid = "";
            string sttldt = "";

            if (FormName == "Pacs.008")
            {
                RTGSImporter.Pacs008 pacs = new RTGSImporter.Pacs008();
                RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();

                pacs  = db.GetSingleOutward08(OutwardID);
                txid  = pacs.TxId;
                sttldt = pacs.IntrBkSttlmDt;
            }
            if(FormName == "Pacs.009")
            {
                RTGSImporter.Pacs009 pacs = new RTGSImporter.Pacs009();
                RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();

                pacs  = db.GetSingleOutward09(OutwardID);
                txid  = pacs.TxId;
                sttldt = pacs.IntrBkSttlmDt;
            }
            if (MsgId == "")
                return;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<Saa:DataPDU xmlns:Saa=\"urn:swift:saa:xsd:saa.2.0\" xmlns:Sw=\"urn:swift:snl:ns.Sw\" xmlns:SwGbl=\"urn:swift:snl:ns.SwGbl\" xmlns:SwInt=\"urn:swift:snl:ns.SwInt\" xmlns:SwSec=\"urn:swift:snl:ns.SwSec\">");
            
            sb.Append("<Saa:Body>");
            sb.Append("<AppHdr xmlns:auto-ns1=\"urn:swift:saa:xsd:saa.2.0\" xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">");
            sb.Append("<Fr>");
            sb.Append("<FIId>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>"+bs.BIC+"</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</FIId>");
            sb.Append("</Fr>");
            sb.Append("<To>");
            sb.Append("<FIId>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>"+bs.BBBIC+"</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</FIId>");
            sb.Append("</To>");
            sb.Append("<BizMsgIdr>" + BizMsgIdr + "</BizMsgIdr>");
            sb.Append("<MsgDefIdr>camt.007.001.05</MsgDefIdr>");
            sb.Append("<BizSvc>RTGS</BizSvc>");
            sb.Append("<CreDt>"+ CreDtTm + "Z" +"</CreDt>");
            sb.Append("</AppHdr>");
            //sb.Append("<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:camt.007.001.05\">");
            sb.Append("<Document xmlns=\"urn:swift:xsd:camt.007.001.05\">");
            sb.Append("<ModfyTx>");
            sb.Append("<MsgHdr>");
            sb.Append("<MsgId>"+ MsgId +"</MsgId>");
            sb.Append("<CreDtTm>" + CreDtTm + "</CreDtTm>");
            sb.Append("</MsgHdr>");
            sb.Append("<Mod>");
            sb.Append("<PmtId>");
            sb.Append("<ShrtBizId>");
            sb.Append("<TxId>"+ txid +"</TxId>");
            sb.Append("<IntrBkSttlmDt>" + sttldt + "</IntrBkSttlmDt>");
            sb.Append("<InstgAgt>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>"+ bs.BIC +"</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</InstgAgt>");
            sb.Append("</ShrtBizId>");
            sb.Append("</PmtId>");
            sb.Append("<NewPmtValSet>");
            sb.Append("<Prty>");
            sb.Append("<PrtryCd>" + PrtryId + "</PrtryCd>");
            sb.Append("</Prty>");
            sb.Append("</NewPmtValSet>");
            sb.Append("</Mod>");
            sb.Append("</ModfyTx>");
            sb.Append("</Document>");
            sb.Append("</Saa:Body>");
            sb.Append("</Saa:DataPDU>");

            string filename = MsgId + ".xml";
            string path = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX\\" + filename;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            if (File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;
                if (length > 1024)
                {
                    RTGS.BBOutwardDB bbdb = new RTGS.BBOutwardDB();
                    bbdb.InsertBBOutwardDB("camt.007", BizMsgIdr, MsgId, "", txid, "", OutwardID, FormName);
                }
            }

        }
        public void GenCamt08(string OutwardID, string FormName)                                //Cancel Trans
        {
            BankSettingsDB bsdb = new BankSettingsDB();
            BankSettings bs = bsdb.GetBankSettings();

            string BizMsgIdr = bs.BIC.Substring(0, 4) + System.DateTime.Today.ToString("yyyyMMdd") + "108" + System.DateTime.Now.ToString("HHmmssf");
            //string MsgId = bs.BIC.Substring(0, 4) + System.DateTime.Today.ToString("yyMMdd") + "08" + System.DateTime.Now.ToString("HHmmss");
            string MsgId = bs.BIC.Substring(0, 4) + "08" + System.DateTime.Today.ToString("MMdd") + System.DateTime.Now.ToString("HHmmss");

            string CreDtTm = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            string txid = "";
            string sttldt = "";

            if (FormName == "Pacs.008")
            {
                RTGSImporter.Pacs008 pacs = new RTGSImporter.Pacs008();
                RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();

                pacs = db.GetSingleOutward08(OutwardID);
                txid = pacs.TxId;
                sttldt = pacs.IntrBkSttlmDt;
            }
            if (FormName == "Pacs.009")
            {
                RTGSImporter.Pacs009 pacs = new RTGSImporter.Pacs009();
                RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();

                pacs = db.GetSingleOutward09(OutwardID);
                txid = pacs.TxId;
                sttldt = pacs.IntrBkSttlmDt;
            }
            if (MsgId == "")
                return;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
 
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<Saa:DataPDU xmlns:Saa=\"urn:swift:saa:xsd:saa.2.0\" xmlns:Sw=\"urn:swift:snl:ns.Sw\" xmlns:SwGbl=\"urn:swift:snl:ns.SwGbl\" xmlns:SwInt=\"urn:swift:snl:ns.SwInt\" xmlns:SwSec=\"urn:swift:snl:ns.SwSec\">");
            sb.Append("<Saa:Body>");
            sb.Append("<AppHdr xmlns:auto-ns1=\"urn:swift:saa:xsd:saa.2.0\" xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">");
            sb.Append("<Fr>");
            sb.Append("<FIId>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>"+bs.BIC+"</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</FIId>");
            sb.Append("</Fr>");
            sb.Append("<To>");
            sb.Append("<FIId>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>"+bs.BBBIC+"</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</FIId>");
            sb.Append("</To>");
            sb.Append("<BizMsgIdr>" + BizMsgIdr + "</BizMsgIdr>");
            sb.Append("<MsgDefIdr>camt.008.001.05</MsgDefIdr>");
            sb.Append("<BizSvc>RTGS</BizSvc>");
            sb.Append("<CreDt>"+ CreDtTm+ "Z"+ "</CreDt>");
            sb.Append("</AppHdr>");
            //sb.Append("<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:camt.008.001.05\">");
            sb.Append("<Document xmlns=\"urn:swift:xsd:camt.008.001.05\">");
            sb.Append("<CclTx>");
            sb.Append("<MsgHdr>");
            sb.Append("<MsgId>"+ MsgId +"</MsgId>");
            sb.Append("<CreDtTm>"+ CreDtTm +"</CreDtTm>");
            sb.Append("</MsgHdr>");
            sb.Append("<PmtId>");
            sb.Append("<ShrtBizId>");
            sb.Append("<TxId>"+ txid+"</TxId>");
            sb.Append("<IntrBkSttlmDt>"+ sttldt +"</IntrBkSttlmDt>");
            sb.Append("<InstgAgt>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>"+ bs.BIC +"</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</InstgAgt>");
            sb.Append("</ShrtBizId>");
            sb.Append("</PmtId>");
            sb.Append("</CclTx>");
            sb.Append("</Document>");
            sb.Append("</Saa:Body>");
            sb.Append("</Saa:DataPDU>");

            string filename = MsgId + ".xml";
            string path = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX\\" + filename;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);
            
            if (File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;
                if (length > 1024)
                {
                    RTGS.BBOutwardDB bbdb = new RTGS.BBOutwardDB();
                    bbdb.InsertBBOutwardDB("camt.008", BizMsgIdr, MsgId, "", txid, "", OutwardID, FormName);
                }
            }
       
        }
        public void GenCamt18()     //Business Day
        {
            BankSettingsDB db = new BankSettingsDB();
            BankSettings bs = db.GetBankSettings();

            string BizMsgIdr = bs.BIC.Substring(0, 4) + System.DateTime.Today.ToString("yyyyMMdd") + "118" + System.DateTime.Now.ToString("HHmmssf");
            //string MsgId = bs.BIC.Substring(0, 4) + System.DateTime.Today.ToString("yyMMdd") + "18" + System.DateTime.Now.ToString("HHmmss");
            string MsgId = bs.BIC.Substring(0, 4) + "18" + System.DateTime.Today.ToString("MMdd") + System.DateTime.Now.ToString("HHmmss");

            string CrDtTm = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            string xmlstr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            xmlstr = xmlstr + "<Saa:DataPDU xmlns:Saa=\"urn:swift:saa:xsd:saa.2.0\" xmlns:Sw=\"urn:swift:snl:ns.Sw\" xmlns:SwGbl=\"urn:swift:snl:ns.SwGbl\" xmlns:SwInt=\"urn:swift:snl:ns.SwInt\" xmlns:SwSec=\"urn:swift:snl:ns.SwSec\">";
            xmlstr = xmlstr + "<Saa:Body>";
            xmlstr = xmlstr + "<AppHdr xmlns:auto-ns1=\"urn:swift:saa:xsd:saa.2.0\" xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">";
            xmlstr = xmlstr + "<Fr>";
            xmlstr = xmlstr + "<FIId>";
            xmlstr = xmlstr + "<FinInstnId>";
            xmlstr = xmlstr + "<BICFI>" + bs.BIC + "</BICFI>";
            xmlstr = xmlstr + "</FinInstnId>";
            xmlstr = xmlstr + "</FIId>";
            xmlstr = xmlstr + "</Fr>";
            xmlstr = xmlstr + "<To>";
            xmlstr = xmlstr + "<FIId>";
            xmlstr = xmlstr + "<FinInstnId>";
            xmlstr = xmlstr + "<BICFI>" + bs.BBBIC + "</BICFI>";
            xmlstr = xmlstr + "</FinInstnId>";
            xmlstr = xmlstr + "</FIId>";
            xmlstr = xmlstr + "</To>";
            xmlstr = xmlstr + "<BizMsgIdr>" + MsgId + "</BizMsgIdr>";
            xmlstr = xmlstr + "<MsgDefIdr>camt.018.001.03</MsgDefIdr>";
            xmlstr = xmlstr + "<BizSvc>RTGS</BizSvc>";
            xmlstr = xmlstr + "<CreDt>" + CrDtTm + "Z" + "</CreDt>";
            xmlstr = xmlstr + "</AppHdr>";
            //xmlstr = xmlstr + "<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:camt.018.001.03\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
            xmlstr = xmlstr + "<Document xmlns=\"urn:swift:xsd:camt.018.001.03\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
            xmlstr = xmlstr + "<GetBizDayInf>";
            xmlstr = xmlstr + "<MsgHdr>";
            xmlstr = xmlstr + "<MsgId>" + MsgId + "</MsgId>";
            xmlstr = xmlstr + "<CreDtTm>" + CrDtTm + "</CreDtTm>";
            xmlstr = xmlstr + "</MsgHdr>";
            xmlstr = xmlstr + "<BizDayInfQryDef>";
            xmlstr = xmlstr + "<Crit>";
            xmlstr = xmlstr + "<NewCrit>";
            xmlstr = xmlstr + "<SchCrit>";
            xmlstr = xmlstr + "<EvtTp>";
            xmlstr = xmlstr + "<Prtry>";
            xmlstr = xmlstr + "<Id>GETBUSINESSDAYPERIOD</Id>";
            xmlstr = xmlstr + "</Prtry>";
            xmlstr = xmlstr + "</EvtTp>";
            xmlstr = xmlstr + "</SchCrit>";
            xmlstr = xmlstr + "</NewCrit>";
            xmlstr = xmlstr + "</Crit>";
            xmlstr = xmlstr + "</BizDayInfQryDef>";
            xmlstr = xmlstr + "</GetBizDayInf>";
            xmlstr = xmlstr + "</Document>";
            xmlstr = xmlstr + "</Saa:Body>";
            xmlstr = xmlstr + "</Saa:DataPDU>";

            string filename = MsgId + ".xml";
            string path = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX\\" + filename;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            if (File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;
                if (length > 1024)
                {
                    RTGS.BBOutwardDB bbdb = new RTGS.BBOutwardDB();
                    bbdb.InsertBBOutwardDB("camt.018", BizMsgIdr, MsgId, "", "", "", "00000000-0000-0000-0000-000000000000", "");
                }
            }
        }
        public void GenCamt60(string CCY)       //Interim Settlement Report
        {
            RTGS.BankAccountsDB dbo = new RTGS.BankAccountsDB();
            string AcctId = dbo.GetSingleBankAccount(CCY);
            
            BankSettingsDB db = new BankSettingsDB();
            BankSettings bs = db.GetBankSettings();

            string BizMsgIdr = bs.BIC.Substring(0, 4) + System.DateTime.Today.ToString("yyyyMMdd") + "160" + System.DateTime.Now.ToString("HHmmssf");
            //string MsgId = bs.BIC.Substring(0, 4) + System.DateTime.Today.ToString("yyMMdd") + "60" + System.DateTime.Now.ToString("HHmmss");
            string MsgId = bs.BIC.Substring(0, 4) + "60" + System.DateTime.Today.ToString("MMdd") + System.DateTime.Now.ToString("HHmmss");

            string CrDtTm = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            string xmlstr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            xmlstr = xmlstr + "<Saa:DataPDU xmlns:Saa=\"urn:swift:saa:xsd:saa.2.0\" xmlns:Sw=\"urn:swift:snl:ns.Sw\" xmlns:SwGbl=\"urn:swift:snl:ns.SwGbl\" xmlns:SwInt=\"urn:swift:snl:ns.SwInt\" xmlns:SwSec=\"urn:swift:snl:ns.SwSec\">";
            xmlstr = xmlstr + "<Saa:Body>";
            xmlstr = xmlstr + "<AppHdr xmlns:auto-ns1=\"urn:swift:saa:xsd:saa.2.0\" xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">";
            xmlstr = xmlstr + "<Fr><FIId><FinInstnId><BICFI>"+bs.BIC+"</BICFI></FinInstnId></FIId></Fr>";
            xmlstr = xmlstr + "<To><FIId><FinInstnId><BICFI>" + bs.BBBIC + "</BICFI></FinInstnId></FIId></To>";
            xmlstr = xmlstr + "<BizMsgIdr>" + BizMsgIdr + "</BizMsgIdr>";
            xmlstr = xmlstr + "<MsgDefIdr>camt.060.001.03</MsgDefIdr>";
            xmlstr = xmlstr + "<BizSvc>RTGS</BizSvc>";
            xmlstr = xmlstr + "<CreDt>" + CrDtTm + "Z" + "</CreDt>";
            xmlstr = xmlstr + "</AppHdr>";
            xmlstr = xmlstr + "<Document xmlns:auto-ns1=\"urn:swift:saa:xsd:saa.2.0\" xmlns=\"urn:iso:std:iso:20022:tech:xsd:camt.060.001.03\">";
            xmlstr = xmlstr + "<AcctRptgReq>";
            xmlstr = xmlstr + "<GrpHdr>";
            xmlstr = xmlstr + "<MsgId>" + MsgId + "</MsgId>";
            xmlstr = xmlstr + "<CreDtTm>" + CrDtTm + "</CreDtTm>";
            xmlstr = xmlstr + "</GrpHdr>";
            xmlstr = xmlstr + "<RptgReq>";
            xmlstr = xmlstr + "<Id>"+ System.DateTime.Now.ToString("HHmmss")+ "</Id>";
            xmlstr = xmlstr + "<ReqdMsgNmId>camt.052.001.04</ReqdMsgNmId>";
            xmlstr = xmlstr + "<Acct>";
            xmlstr = xmlstr + "<Id>";
            xmlstr = xmlstr + "<Othr>";
            xmlstr = xmlstr + "<Id>" + AcctId + "</Id>";
            xmlstr = xmlstr + "</Othr>";
            xmlstr = xmlstr + "</Id>";
            xmlstr = xmlstr + "</Acct>";
            xmlstr = xmlstr + "<AcctOwnr>";
            xmlstr = xmlstr + "<Agt>";
            xmlstr = xmlstr + "<FinInstnId>";
            xmlstr = xmlstr + "<BICFI>" + bs.BIC + "</BICFI>";
            xmlstr = xmlstr + "</FinInstnId>";
            xmlstr = xmlstr + "</Agt>";
            xmlstr = xmlstr + "</AcctOwnr>";
            xmlstr = xmlstr + "</RptgReq>";
            xmlstr = xmlstr + "</AcctRptgReq>";
            xmlstr = xmlstr + "</Document>";
            xmlstr = xmlstr + "</Saa:Body>";
            xmlstr = xmlstr + "</Saa:DataPDU>";

            string filename = MsgId + ".xml";
            string path = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX\\" + filename;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            if (File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;
                if (length > 1024)
                {
                    RTGS.BBOutwardDB bbdb = new RTGS.BBOutwardDB();
                    bbdb.InsertBBOutwardDB("camt.060", BizMsgIdr, MsgId, "", "", "", "00000000-0000-0000-0000-000000000000", "");
                }
            }
        
        }
    }
}