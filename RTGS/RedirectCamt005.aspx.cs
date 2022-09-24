using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS
{
    public partial class RedirectCamt005 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string previousPage = Page.Request.UrlReferrer.ToString();

            if ((Request.Params["StatusID"] != null) && (Request.Params["StatusID"] != ""))
            {
                int StatusID = Int32.Parse(Request.Params["StatusID"]);
                if ( StatusID> 4)
                {
                    if ((Request.Params["OutwardID"] != null) && (Request.Params["OutwardID"] != ""))
                    {

                        string OutwardID = Request.Params["OutwardID"];

                        if ((Request.Params["FormName"] != null) && (Request.Params["FormName"] != ""))
                        {
                            string FormName = Request.Params["FormName"];
                            FloraSoft.CamtGenerator camt = new FloraSoft.CamtGenerator();

                            if (FormName == "Pacs.008")
                            {
                                RTGSImporter.TeamRedDB red = new RTGSImporter.TeamRedDB();
                                RTGSImporter.Pacs008 pacs = red.GetSingleOutward08(OutwardID);
                                camt.GenCamt05(OutwardID, "Pacs.008", pacs.TxId, "STAT");
                            }
                            if (FormName == "Pacs.009")
                            {
                                RTGSImporter.TeamBlueDB red = new RTGSImporter.TeamBlueDB();
                                RTGSImporter.Pacs009 pacs = red.GetSingleOutward09(OutwardID);
                                camt.GenCamt05(OutwardID, "Pacs.009", pacs.TxId, "STAT");
                            }
                            if (FormName == "Pacs.004")
                            {
                                RTGSImporter.TeamGreenDB red = new RTGSImporter.TeamGreenDB();
                                RTGSImporter.Pacs004 pacs = red.GetSingleOutward04(OutwardID);
                                camt.GenCamt05(OutwardID, "Pacs.004", pacs.OrgnlTxId, "STAT");
                            }
                        }
                    }
                }

                


                if ((previousPage != null) && (previousPage != ""))
                {
                    Response.Redirect(previousPage);
                }
                else
                {
                    Response.Redirect("OutwardList.aspx");
                }
            }

        }
    }
}