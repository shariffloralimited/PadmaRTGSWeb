using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS
{
    public partial class DeleteTransaction : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string MsgID = Request.Params["MsgID"];

            DAC.OutwardDB db = new DAC.OutwardDB();
            db.DeleteAdnReverseCBS(MsgID, Request.Cookies["UserName"].Value, Request.UserHostAddress);
            Response.Redirect("GenerateOutwardXML.aspx");
        }
    }
}