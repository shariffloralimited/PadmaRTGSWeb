using RTGSImporter;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace RTGS.Forms
{
    public partial class PaymentReturnChecker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            string outwardID = base.Request.QueryString["OutwardID"];
            TeamGreenDB teamGreenDB = new TeamGreenDB();
            Pacs004 singleOutward = teamGreenDB.GetSingleOutward04(outwardID);
            this.lblAccountNo.Text = singleOutward.CdtrAcctId;
            this.lblSettlmentAmount.Text = string.Format("{0:N}", singleOutward.TxRefIntrBkSttlmAmt);
            this.lblCCY.Text = singleOutward.TxRefIntrBkSttlmCcy;
            this.lblReceivingBank.Text = singleOutward.DbtrAgtBICFINm;
            this.lblReceivingBranch.Text = singleOutward.FrBranch;
            this.lblReceiverName.Text = singleOutward.DbtrNm;
            this.lblReceiverAccountNo.Text = singleOutward.DbtrAcctId;
            this.lblReturnReason.Text = singleOutward.RtrRsnPrtry;
            this.lblMsg.Text = string.Concat(new string[]
			{
				"<a target=\"_new\" href=\"Inward08Long.aspx?InwardID=",
				singleOutward.InwardID,
				"\">REVERSAL OF ",
				singleOutward.OrgnlMsgId,
				"</a>"
			});
            string value = base.Request.Cookies["RoleCD"].Value;
            decimal d = decimal.Parse(base.Request.Cookies["TransLimit"].Value);
            if (value == "RTCK" && singleOutward.StatusID == 2)
            {
                this.ButtonPanel.Visible = true;
            }
            if (value == "RTAU" && singleOutward.StatusID == 3)
            {
                this.ButtonPanel.Visible = true;
            }
            if (d < singleOutward.TxRefIntrBkSttlmAmt)
            {
                this.ButtonPanel.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string outwardID = base.Request.Params["OutwardID"];
            string value = base.Request.Cookies["RoleCD"].Value;
            TeamGreenDB teamGreenDB = new TeamGreenDB();
            if (value == "RTCK")
            {
                teamGreenDB.ApproveOutward04(outwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }
            if (value == "RTAU")
            {
                teamGreenDB.AuthOutward04(outwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }
            base.Response.Redirect("../OutwardListChecker.aspx");
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("../OutwardListChecker.aspx");
        }

        protected void btnRejectTransaction_Click(object sender, EventArgs e)
        {
            TeamGreenDB teamGreenDB = new TeamGreenDB();
            teamGreenDB.RejectOutward04(base.Request.QueryString["OutwardID"], base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            base.Response.Redirect("../OutwardListChecker.aspx");
        }
    }
}

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {           
//                BindData();
//            }
//        }

//        private void BindData()
//        {
//            string OutwardID = Request.QueryString["OutwardID"];

//            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
//            RTGSImporter.Pacs004 pacs = db.GetSingleOutward04(OutwardID);

//            lblAccountNo.Text           = pacs.CdtrAcctId;
//            lblSettlmentAmount.Text     = string.Format("{0:N}", pacs.TxRefIntrBkSttlmAmt);
//            lblCCY.Text                 = pacs.TxRefIntrBkSttlmCcy;
//            lblReceivingBank.Text       = pacs.DbtrAgtBICFINm;
//            lblReceivingBranch.Text     = pacs.FrBranch;
//            lblReceiverName.Text        = pacs.DbtrNm;
//            lblReceiverAccountNo.Text   = pacs.DbtrAcctId;
//            lblReturnReason.Text        = pacs.RtrRsnPrtry;

//            lblMsg.Text = "<a target=\"_new\" href=\"Inward08Long.aspx?InwardID=" + pacs.InwardID + "\">REVERSAL OF " + pacs.OrgnlMsgId + "</a>";
            
//            string RoleCD = Request.Cookies["RoleCD"].Value;
//            Decimal TransLimit = Decimal.Parse(Request.Cookies["TransLimit"].Value);

//            if ((RoleCD == "RTCK") && (pacs.StatusID == 2))
//            {
//                ButtonPanel.Visible = true;
//            }
//            if ((RoleCD == "RTAU") && (pacs.StatusID == 3))
//            {
//                ButtonPanel.Visible = true;
//            }
//            if (TransLimit < pacs.TxRefIntrBkSttlmAmt)
//            {
//                ButtonPanel.Visible = false;
//            }
//        }
//        protected void btnSend_Click(object sender, EventArgs e)
//        {
//            string OutwardID = Request.Params["OutwardID"];
//            string RoleCD = Request.Cookies["RoleCD"].Value;

//            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
//            if (RoleCD == "RTCK")
//            {
//                db.ApproveOutward04(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            }
//            if (RoleCD == "RTAU")
//            {
//                db.AuthOutward04(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            }
//            Response.Redirect("../OutwardListChecker.aspx");
//        }
//        protected void btnCancelTrans_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("../OutwardListChecker.aspx");
//        }
//        protected void btnRejectTransaction_Click(object sender, EventArgs e)
//        {
//            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
//            db.RejectOutward04(Request.QueryString["OutwardID"], Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            Response.Redirect("../OutwardListChecker.aspx");
//        }
//    }
//}