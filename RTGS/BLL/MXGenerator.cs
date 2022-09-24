using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Configuration;

namespace FloraSoft
{
    public class MXGenerator
    {
        public void GenPacs008(string OutwardID, string CartID, string Priority, string UserName, string UserIP)
        {
            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            RTGSImporter.XmlString str = new RTGSImporter.XmlString();

            RTGSImporter.Pacs008 pacs = db.GetSingleCartOutward08(OutwardID, CartID);

            if (pacs.PacsID == "")
                return;

            string xml = str.GetPacs8(pacs, Priority);

            string filename = pacs.BizMsgIdr + ".xml";
            string path = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX\\" + filename;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            if(File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;
                if (length > 2024)
                {
                    db.SendOutward08(OutwardID, UserName, UserIP);
                }
            }

        }
        public void GenPacs009(string OutwardID, string CartID, string  Priority, string UserName, string UserIP)
        {
            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
            RTGSImporter.XmlString str = new RTGSImporter.XmlString();

            RTGSImporter.Pacs009 pacs = db.GetSingleCartOutward09(OutwardID, CartID);
            if (pacs.PacsID == "")
                return;

            string xml = str.GetPacs9(pacs, Priority);

            string filename = pacs.BizMsgIdr + ".xml";
            string path = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX\\" + filename;


            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            if (File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;
                if (length > 2024)
                {
                    db.SendOutward09(OutwardID, UserName, UserIP);
                } 
            }

        }
        public void GenPacs004(string OutwardID, string CartID, string Priority, string UserName, string UserIP)
        {
            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
            RTGSImporter.XmlString str = new RTGSImporter.XmlString();

            //RTGSImporter.Pacs004 pacs = db.GetSingleCartOutward04(OutwardID, CartID);
            RTGSImporter.Pacs004 pacs = db.GetSingleOutward04(OutwardID);

            if (pacs.Pacs004ID == "")
                return;
            string xml = str.GetPacs4(pacs, Priority);

            string filename = pacs.BizMsgIdr + ".xml";
            string path = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX\\" + filename;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(path);

            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines);

            if (File.Exists(path))
            {
                db.SendOutward04(OutwardID, UserName, UserIP);
            }
            pacs = null;
        }
    }
}