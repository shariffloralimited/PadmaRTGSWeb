using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Data;
using System.Collections;

namespace RTGS
{
    public class NRBService
    {
        public string GetCBSData(string AccountNo)
        {
            string BrnCd = AccountNo.Substring(0, 3);
            string ActNo = AccountNo;
            string result = "";
            WebRequest req = null;
            WebResponse rsp = null;
            try
            {
                string uri = ConfigurationManager.AppSettings["CBSURI"] + "/FCUBSAccService/FCUBSAccService?WSDL";
                req = (HttpWebRequest)WebRequest.Create(uri);
                req.Method = "POST";   
                req.ContentType = "text/xml";  
                req.Credentials = CredentialCache.DefaultNetworkCredentials;
                StreamWriter writer = new StreamWriter(req.GetRequestStream());
                writer.WriteLine(GetAccountInquiryXML(BrnCd, ActNo));
                writer.Close();
                rsp = (HttpWebResponse)req.GetResponse(); 

                StreamReader sr = new StreamReader(rsp.GetResponseStream());
                result = sr.ReadToEnd();
                sr.Close();

            }
            catch (WebException webEx)
            {
                System.Console.WriteLine(webEx.Message.ToString());
                System.Console.WriteLine(webEx.StackTrace.ToString());
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                System.Console.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                if (req != null) req.GetRequestStream().Close();
                if (rsp != null) rsp.GetResponseStream().Close();
            }
             return result;
        }

        private string GetTextFromXMLFile(string file)
        {
            StreamReader reader = new StreamReader(file);
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }
        private string GetAccountInquiryXML(string BranchCode, string AccountNo)
        {
            string str = 
                "<env:Envelope xmlns:env=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                 "<env:Header/>"+
                 "<env:Body>"+ 
                  "<QUERYCUSTACC_IOFS_REQ xmlns=\"http://fcubs.ofss.com/service/FCUBSAccService\">"+ 
                   "<FCUBS_HEADER>"+
                    "<SOURCE>" + ConfigurationManager.AppSettings["Source"] + "</SOURCE>" + 
                    "<UBSCOMP>FCUBS</UBSCOMP>"+ 
                    "<MSGID/>"+ 
                    "<CORRELID/>"+ 
                    "<USERID>SYSTEM</USERID>"+ 
                    "<BRANCH>" +BranchCode + "</BRANCH>"+ 
                    "<MODULEID>ST</MODULEID>"+ 
                    "<SERVICE>FCUBSAccService</SERVICE>"+ 
                    "<OPERATION>QueryCustAcc</OPERATION>"+ 
                    "<SOURCE_OPERATION>QueryCustAcc</SOURCE_OPERATION>"+ 
                    "<SOURCE_USERID/>"+ 
                    "<DESTINATION/>"+ 
                    "<MULTITRIPID/>"+ 
                    "<FUNCTIONID/>"+ 
                    "<ACTION/>"+ 
                    "<MSGSTAT>SUCCESS</MSGSTAT>"+ 
                    "<PASSWORD/>"+ 
                    "<ADDL>"+ 
                     "<PARAM>"+ 
                      "<NAME/>"+ 
                      "<VALUE/>"+ 
                     "</PARAM>"+ 
                    "</ADDL>"+ 
                   "</FCUBS_HEADER>"+ 
                  "<FCUBS_BODY>"+ 
                    "<Cust-Account-IO>"+
                     "<BRN>" + BranchCode + "</BRN>" +
                     "<ACC>" + AccountNo + "</ACC>" + 
                     "<CRS_STST_REQD>N</CRS_STST_REQD>"+ 
                    "</Cust-Account-IO>"+ 
                   "</FCUBS_BODY>"+ 
                  "</QUERYCUSTACC_IOFS_REQ>"+ 
                 "</env:Body>"+ 
                "</env:Envelope>";

            return str;
        }


    }
}