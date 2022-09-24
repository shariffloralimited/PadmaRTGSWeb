using RTGSImporter;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward09LongChecker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.LoadData();
            }
        }

        private void LoadData()
        {
            string outwardID = base.Request.Params["OutwardID"];
            TeamBlueDB teamBlueDB = new TeamBlueDB();
            Pacs009 singleOutward = teamBlueDB.GetSingleOutward09(outwardID);
            if (singleOutward.PmntRsn != "")
            {
                this.lblMsg.Text = string.Concat(new string[]
				{
					"<a target=\"_new\" href=\"Inward09Long.aspx?InwardID=",
					singleOutward.PmntRsn,
					"\">REVERSAL OF ",
					singleOutward.MsgId,
					"</a>"
				});
            }
            this.lblFrBICFI.Text = singleOutward.FrBICFI;
            this.lblToBICFI.Text = singleOutward.ToBICFI;
            this.lblBizMsgIdr.Text = singleOutward.BizMsgIdr;
            this.lblMsgDefIdr.Text = singleOutward.MsgDefIdr;
            this.lblBizSvc.Text = singleOutward.BizSvc;
            this.lblCreDt.Text = singleOutward.CreDt;
            this.lblMsgId.Text = singleOutward.MsgId;
            this.lblCreDtTm.Text = singleOutward.CreDtTm;
            this.lblNbOfTxs.Text = singleOutward.NbOfTxs.ToString();
            this.lblInstgAgtBICFI.Text = singleOutward.InstgAgtBICFI;
            this.lblInstgAgtNm.Text = singleOutward.InstgAgtNm;
            this.lblInstgAgtBranchId.Text = singleOutward.InstgAgtBranchId;
            this.lblInstdAgtBICFI.Text = singleOutward.InstdAgtBICFI;
            this.lblInstdAgtNm.Text = singleOutward.InstdAgtNm;
            this.lblInstdAgtBranchId.Text = singleOutward.InstdAgtBranchId;
            this.lblIntrmyAgt1BICFI.Text = singleOutward.IntrmyAgt1BICFI;
            this.lblIntrmyAgt1Nm.Text = singleOutward.IntrmyAgt1Nm;
            this.lblIntrmyAgt1BranchId.Text = singleOutward.IntrmyAgt1BranchId;
            this.lblIntrmyAgt1AcctId.Text = singleOutward.IntrmyAgt1AcctId;
            this.lblIntrmyAgt1AcctTp.Text = singleOutward.IntrmyAgt1AcctTp;
            this.lblLclInstrmPrtry.Text = singleOutward.LclInstrmPrtry;
            this.lblSvcLvlPrtry.Text = singleOutward.SvcLvlPrtry;
            this.lblCtgyPurpPrtry.Text = singleOutward.CtgyPurpPrtry;
            this.lblInstrId.Text = singleOutward.InstrId;
            this.lblTxId.Text = singleOutward.TxId;
            this.lblEndToEndId.Text = singleOutward.EndToEndId;
            this.lblIntrBkSttlmCcy.Text = singleOutward.IntrBkSttlmCcy;
            this.lblIntrBkSttlmAmt.Text = singleOutward.IntrBkSttlmAmt.ToString("0.00");
            this.lblIntrBkSttlmDt.Text = singleOutward.IntrBkSttlmDt;
            this.lblDbtrBICFI.Text = singleOutward.DbtrBICFI;
            this.lblDbtrNm.Text = singleOutward.DbtrNm;
            this.lblDbtrBranchId.Text = singleOutward.DbtrBranchId;
            this.lblDbtrAcctId.Text = singleOutward.DbtrAcctId;
            this.lblDbtrAcctTp.Text = singleOutward.DbtrAcctTp;
            this.lblCdtrAgtBICFI.Text = singleOutward.CdtrAgtBICFI;
            this.lblCdtrAgtBranchId.Text = singleOutward.CdtrAgtBranchId;
            this.lblCdtrAgtAcctId.Text = singleOutward.CdtrAgtAcctId;
            this.lblCdtrAgtAcctTp.Text = singleOutward.CdtrAgtAcctTp;
            this.lblCdtrBICFI.Text = singleOutward.CdtrBICFI;
            this.lblCdtrNm.Text = singleOutward.CdtrNm;
            this.lblCdtrBranchId.Text = singleOutward.CdtrBranchId;
            this.lblCdtrAcctId.Text = singleOutward.CdtrAcctId;
            this.lblCdtrAcctTp.Text = singleOutward.CdtrAcctTp;
            this.lblInstrInf.Text = singleOutward.InstrInf;
            this.ChkNoCBS.Checked = singleOutward.NoCBS;
            this.lblCBSResponse.Text = singleOutward.CBSResponse;
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
            if (d < singleOutward.IntrBkSttlmAmt)
            {
                this.ButtonPanel.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string outwardID = base.Request.Params["OutwardID"];
            string value = base.Request.Cookies["RoleCD"].Value;
            TeamBlueDB teamBlueDB = new TeamBlueDB();
            if (value == "RTCK")
            {
                teamBlueDB.ApproveOutward09(outwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }
            if (value == "RTAU")
            {
                teamBlueDB.AuthOutward09(outwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }
            base.Response.Redirect("../OutwardListChecker.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (this.txtReturnReason.Text != "")
            {
                string outwardID = base.Request.Params["OutwardID"];
                TeamBlueDB teamBlueDB = new TeamBlueDB();
                if (this.lblMsg.Text == "")
                {
                    teamBlueDB.ReturnOutward09(outwardID, this.txtReturnReason.Text, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
                }
                else
                {
                    teamBlueDB.RejectOutward09(outwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
                }
                base.Response.Redirect("../OutwardListChecker.aspx");
            }
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("../OutwardListChecker.aspx");
        }
    }
}

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                LoadData();
//            }
//        }
//        private void LoadData()
//        {
//            string OutwardID = Request.Params["OutwardID"];

//            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
//            RTGSImporter.Pacs009 pacs = db.GetSingleOutward09(OutwardID);
//            if (pacs.PmntRsn != "")
//            {
//                lblMsg.Text = "<a target=\"_new\" href=\"Inward09Long.aspx?InwardID=" + pacs.PmntRsn + "\">REVERSAL OF " + pacs.MsgId + "</a>";
//            }

//            lblFrBICFI.Text = pacs.FrBICFI;
//            lblToBICFI.Text = pacs.ToBICFI;
//            lblBizMsgIdr.Text = pacs.BizMsgIdr;
//            lblMsgDefIdr.Text = pacs.MsgDefIdr;
//            lblBizSvc.Text = pacs.BizSvc;
//            lblCreDt.Text = pacs.CreDt;
//            lblMsgId.Text = pacs.MsgId;
//            lblCreDtTm.Text = pacs.CreDtTm;
//            lblNbOfTxs.Text = pacs.NbOfTxs.ToString();
//            lblInstgAgtBICFI.Text = pacs.InstgAgtBICFI;
//            lblInstgAgtNm.Text = pacs.InstgAgtNm;
//            lblInstgAgtBranchId.Text = pacs.InstgAgtBranchId;
//            lblInstdAgtBICFI.Text = pacs.InstdAgtBICFI;
//            lblInstdAgtNm.Text = pacs.InstdAgtNm;
//            lblInstdAgtBranchId.Text = pacs.InstdAgtBranchId;
//            lblIntrmyAgt1BICFI.Text = pacs.IntrmyAgt1BICFI;
//            lblIntrmyAgt1Nm.Text = pacs.IntrmyAgt1Nm;
//            lblIntrmyAgt1BranchId.Text = pacs.IntrmyAgt1BranchId;
//            lblIntrmyAgt1AcctId.Text = pacs.IntrmyAgt1AcctId;
//            lblIntrmyAgt1AcctTp.Text = pacs.IntrmyAgt1AcctTp;
//            lblLclInstrmPrtry.Text = pacs.LclInstrmPrtry;
//            lblSvcLvlPrtry.Text = pacs.SvcLvlPrtry;
//            lblCtgyPurpPrtry.Text = pacs.CtgyPurpPrtry;
//            lblInstrId.Text = pacs.InstrId;
//            lblTxId.Text = pacs.TxId;
//            lblEndToEndId.Text = pacs.EndToEndId;
//            lblIntrBkSttlmCcy.Text = pacs.IntrBkSttlmCcy;
//            lblIntrBkSttlmAmt.Text = pacs.IntrBkSttlmAmt.ToString("0.00");
//            lblIntrBkSttlmDt.Text = pacs.IntrBkSttlmDt;
//            lblDbtrBICFI.Text = pacs.DbtrBICFI;
//            lblDbtrNm.Text = pacs.DbtrNm;
//            lblDbtrBranchId.Text = pacs.DbtrBranchId;
//            lblDbtrAcctId.Text = pacs.DbtrAcctId;
//            lblDbtrAcctTp.Text = pacs.DbtrAcctTp;
//            lblCdtrAgtBICFI.Text = pacs.CdtrAgtBICFI;
//            lblCdtrAgtBranchId.Text = pacs.CdtrAgtBranchId;
//            lblCdtrAgtAcctId.Text = pacs.CdtrAgtAcctId;
//            lblCdtrAgtAcctTp.Text = pacs.CdtrAgtAcctTp;
//            lblCdtrBICFI.Text = pacs.CdtrBICFI;
//            lblCdtrNm.Text = pacs.CdtrNm;
//            lblCdtrBranchId.Text = pacs.CdtrBranchId;
//            lblCdtrAcctId.Text = pacs.CdtrAcctId;
//            lblCdtrAcctTp.Text = pacs.CdtrAcctTp;
//            lblInstrInf.Text = pacs.InstrInf;
//            //lblPmntRsn.Text = pacs.PmntRsn;
//            ChkNoCBS.Checked = pacs.NoCBS;
//            lblCBSResponse.Text = pacs.CBSResponse;

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
//            if (TransLimit < pacs.IntrBkSttlmAmt)
//            {
//                ButtonPanel.Visible = false;
//            }
//        }

//        protected void btnSend_Click(object sender, EventArgs e)
//        {
//            string OutwardID = Request.Params["OutwardID"];
//            string RoleCD    = Request.Cookies["RoleCD"].Value;

//            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();

//            if (RoleCD == "RTCK")
//            {
//                db.ApproveOutward09(OutwardID, Request.Cookies["LoginID"].Value, HttpContext.Current.Request.UserHostAddress);
//            }
//            if (RoleCD == "RTAU")
//            {
//                db.AuthOutward09(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            }

//            Response.Redirect("../OutwardListChecker.aspx");
//        }

//        protected void btnReturn_Click(object sender, EventArgs e)
//        {
//            if (txtReturnReason.Text != "")
//            {
//                string OutwardID = Request.Params["OutwardID"];
//                RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();

//                if (lblMsg.Text == "")
//                {
//                    db.ReturnOutward09(OutwardID, txtReturnReason.Text, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//                }
//                else
//                {
//                    db.RejectOutward09(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//                }
//                Response.Redirect("../OutwardListChecker.aspx");
//            }
//        }

//        protected void btnCancelTrans_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("../OutwardListChecker.aspx");
//        }

//    }
//}