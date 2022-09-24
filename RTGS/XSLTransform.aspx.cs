using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

namespace RTGS
{
    public partial class XSLTransform : System.Web.UI.Page
    {
        //if we like to load from real file.
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    XslCompiledTransform myXslTrans = new XslCompiledTransform();
        //    myXslTrans.Load(Server.MapPath(".") + "/Xsl/camt052.xsl");
        //    myXslTrans.Transform("D:/STP/Import/bak/camt.052.xml", "D:/STP/Import/bak/result.html"); 
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            string RoleCD = Request.Cookies["RoleCD"].Value;
            if ((RoleCD != "RTAD") && (RoleCD != "RTFM"))
            {
                Response.Redirect("AccessDenied.aspx");
            } 
            
            if ((Request.Params["BBID"] == null) || (Request.Params["BBID"] == ""))
            {
                Response.Write("THIS FORM CANNOT BE DISPLAYED");
                Response.End();
            }
               
            if ((Request.Params["FormName"] == null) || (Request.Params["FormName"] == ""))
            {
                Response.Write("THIS FORM CANNOT BE DISPLAYED");
                Response.End();
            }

            try
            {
                Transform(Request.Params["FormName"], Request.Params["BBID"]);
            }
            catch(Exception ex)
            {
                Response.Write("THIS FORM CANNOT BE DISPLAYED");
                System.Console.Write(ex.Message);
            }
       }

        protected void Transform(string FormName, string BBID)
        {
            Response.Write("<TITLE>"+FormName + "</TITLE>");
            FloraSoft.CamtDB camt = new FloraSoft.CamtDB();
            String XmlData = camt.GetCamtXML(BBID);

            string XlsPath = Server.MapPath(".") + "/Xsl/"+FormName+".xsl";
            if (!File.Exists(XlsPath))
            {
                //XlsPath = Server.MapPath(".") + "/Xsl/camt.other.xsl";
                XlsPath = Server.MapPath(".") + "/Xsl/other.xsl";
            }

            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(XmlData));
            reader.Read();

            System.Xml.Xsl.XslCompiledTransform XForm = new XslCompiledTransform();
            XForm.Load(XlsPath);

            StringWriter SWriter = new StringWriter();
            XmlWriter XWriter = new XmlTextWriter(SWriter);

            XForm.Transform(reader, XWriter);
            Response.Write(SWriter.ToString());
        }
    }
}