using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS
{
    public partial class RedirectMaker : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            int StatusID = 0;
            string previousPage = Page.Request.UrlReferrer.ToString();

            if ((Request.Params["StatusID"] != null) && (Request.Params["StatusID"] != ""))
            {
                StatusID = Int32.Parse(Request.Params["StatusID"]);
            }

                
            if ((Request.Params["OutwardID"] != null) && (Request.Params["OutwardID"] != ""))
            {
                if ((StatusID != 1) || (Request.Cookies["RoleCD"].Value != "RTMK"))
                {
                    if ((previousPage != null) && (previousPage != ""))
                    {
                        Response.Redirect(previousPage);
                    }
                    else
                    {
                        Response.Redirect("OutwardList.aspx");
                    }
                }
                string OutwardID = Request.Params["OutwardID"];

                string Form = Request.Params["Form"];

                if (Form == "Pacs.008")
                {
                    Response.Redirect("Forms/Outward08LongMaker.aspx?OutwardID=" + OutwardID);
                }
                if (Form == "Pacs.009")
                {
                    Response.Redirect("Forms/Outward09LongMaker.aspx?OutwardID=" + OutwardID);
                }
            }
            else
            {
                string InwardID = Request.Params["InwardID"];

                if ((StatusID != 3) || (Request.Cookies["RoleCD"].Value != "RTMK"))
                {
                    if ((previousPage != null) && (previousPage != ""))
                    {
                        Response.Redirect(previousPage);
                    }
                    else
                    {
                        Response.Redirect("InwardList.aspx");
                    }
                }

                string Form = Request.Params["Form"];

                if (Form == "pacs.004")
                {
                    Response.Redirect("Forms/Inward04Long.aspx?FormName=pacs.008&InwardID=" + InwardID);
                } 

                if (Form == "pacs.008")
                {
                    Response.Redirect("Forms/Inward08Long.aspx?FormName=pacs.008&InwardID=" + InwardID);
                }
                if (Form == "pacs.009")
                {
                    Response.Redirect("Forms/Inward09Long.aspx?FormName=pacs.009&InwardID=" + InwardID);
                }


            }
        }
    }
}