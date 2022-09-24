using FloraSoft;
using FMPS.BLL;
using RTGSImporter;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward08LongChecker : System.Web.UI.Page
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
            TeamRedDB teamRedDB = new TeamRedDB();
            Pacs008 singleOutward = teamRedDB.GetSingleOutward08(outwardID);
            NumberToWordConverter numberToWordConverter = new NumberToWordConverter();
            this.lblFrBICFI.Text = singleOutward.FrBICFI;
            this.lblToBICFI.Text = singleOutward.ToBICFI;
            this.lblBizMsgIdr.Text = singleOutward.BizMsgIdr;
            this.lblMsgDefIdr.Text = singleOutward.MsgDefIdr;
            this.lblBizSvc.Text = singleOutward.BizSvc;
            this.lblCreDt.Text = singleOutward.CreDt;
            this.lblMsgId.Text = singleOutward.MsgId;
            this.lblCreDtTm.Text = singleOutward.CreDtTm;
            this.lblBtchBookg.Text = singleOutward.BtchBookg;
            this.lblNbOfTxs.Text = singleOutward.NbOfTxs.ToString();
            this.lblInstrId.Text = singleOutward.InstrId;
            this.lblEndToEndId.Text = singleOutward.EndToEndId;
            this.lblTxId.Text = singleOutward.TxId;
            this.lblClrChanl.Text = singleOutward.ClrChanl;
            this.lblSvcLvlPrtry.Text = singleOutward.SvcLvlPrtry.ToString();
            this.lblLclInstrmPrtry.Text = singleOutward.LclInstrmPrtry.ToString();
            this.lblCtgyPurpPrtry.Text = singleOutward.CtgyPurpPrtry;
            this.lblCcy.Text = singleOutward.Ccy;
            this.lblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(singleOutward.IntrBkSttlmAmt, 2).ToString());
            this.lblIntrBkSttlmAmt.ToolTip = numberToWordConverter.GetAmountInWords(Math.Round(singleOutward.IntrBkSttlmAmt, 2).ToString());
            this.lblIntrBkSttlmDt.Text = singleOutward.IntrBkSttlmDt;
            this.lblChrgBr.Text = singleOutward.ChrgBr;
            this.lblInstgAgtBICFI.Text = singleOutward.InstgAgtBICFI;
            this.lblInstgAgtNm.Text = singleOutward.InstgAgtNm;
            this.lblInstgAgtBranchId.Text = singleOutward.InstgAgtBranchId;
            this.lblInstdAgtBICFI.Text = singleOutward.InstdAgtBICFI;
            this.lblInstdAgtNm.Text = singleOutward.InstdAgtNm;
            this.lblInstdAgtBranchId.Text = singleOutward.InstdAgtBranchId;
            this.lblDbtrNm.Text = singleOutward.DbtrNm;
            this.lblDbtrPstlAdr.Text = singleOutward.DbtrPstlAdr;
            this.lblDbtrStrtNm.Text = singleOutward.DbtrStrtNm;
            this.lblDbtrTwnNm.Text = singleOutward.DbtrTwnNm;
            this.lblDbtrAdrLine.Text = singleOutward.DbtrAdrLine;
            this.lblDbtrCtry.Text = singleOutward.DbtrCtry;
            this.lblDbtrAcctOthrId.Text = singleOutward.DbtrAcctOthrId;
            this.lblDbtrAgtBICFI.Text = singleOutward.DbtrAgtBICFI;
            this.lblDbtrAgtNm.Text = singleOutward.DbtrAgtNm;
            this.lblDbtrAgtBranchId.Text = singleOutward.DbtrAgtBranchId;
            this.lblDbtrAgtAcctOthrId.Text = singleOutward.DbtrAgtAcctOthrId;
            this.lblDbtrAgtAcctPrtry.Text = singleOutward.DbtrAgtAcctPrtry;
            this.lblCdtrAgtBICFI.Text = singleOutward.CdtrAgtBICFI;
            this.lblCdtrAgtNm.Text = singleOutward.CdtrAgtNm;
            this.lblCdtrAgtBranchId.Text = singleOutward.CdtrAgtBranchId;
            this.lblCdtrAgtAcctOthrId.Text = singleOutward.CdtrAgtAcctOthrId;
            this.lblCdtrAgtAcctPrtry.Text = singleOutward.CdtrAgtAcctPrtry;
            this.lblCdtrNm.Text = singleOutward.CdtrNm;
            this.lblCdtrPstlAdr.Text = singleOutward.CdtrPstlAdr;
            this.lblCdtrStrtNm.Text = singleOutward.CdtrStrtNm;
            this.lblCdtrTwnNm.Text = singleOutward.CdtrTwnNm;
            this.lblCdtrAdrLine.Text = singleOutward.CdtrAdrLine;
            this.lblCdtrCtry.Text = singleOutward.CdtrCtry;
            this.lblCdtrAcctOthrId.Text = singleOutward.CdtrAcctOthrId;
            this.lblCdtrAcctPrtry.Text = singleOutward.CdtrAcctPrtry;
            this.lblInstrInf.Text = singleOutward.InstrInf;
            //update for FCY
            this.txtOrginatorACType.Text = singleOutward.OrginatorACType;
            this.txtRecieverACType.Text = singleOutward.ReceiverACType;
            this.txtTransactionPurpose.Text = singleOutward.PurposeOfTransaction;
            this.txtOtherInf.Text = singleOutward.OtherInfo;


            //end
            this.lblUstrd.Text = singleOutward.Ustrd;
            this.ChkChargerWaived.Checked = singleOutward.ChargeWaived;
            this.lblCBSResponse.Text = singleOutward.CBSResponse;
            string value = base.Request.Cookies["RoleCD"].Value;
            decimal d = decimal.Parse(base.Request.Cookies["TransLimit"].Value);
            BankSettingsDB bankSettingsDB = new BankSettingsDB();
            BankSettings bankSettings = bankSettingsDB.GetBankSettings();
            DateTime t = DateTime.Today.AddHours((double)bankSettings.AftrCutOffHr).AddMinutes((double)bankSettings.AftrCutOffMin);
            CCYDB cCYDB = new CCYDB();
            decimal cCYRate = cCYDB.GetCCYRate(singleOutward.Ccy);
            decimal d2 = d / cCYRate;
            if (value == "RTCK" && singleOutward.StatusID == 2)
            {
                this.ButtonPanel.Visible = true;
            }
            if (value == "RTAU" && singleOutward.StatusID == 3)
            {
                this.ButtonPanel.Visible = true;
            }
            if (d2 < singleOutward.IntrBkSttlmAmt)
            {
                this.ButtonPanel.Visible = false;
            }
            if (t < DateTime.Now)
            {
                this.ButtonPanel.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string outwardID = base.Request.Params["OutwardID"];
            string value = base.Request.Cookies["RoleCD"].Value;
            TeamRedDB teamRedDB = new TeamRedDB();
            if (value == "RTCK")
            {
                teamRedDB.ApproveOutward08(outwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }
            if (value == "RTAU")
            {
                teamRedDB.AuthOutward08(outwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }
            base.Response.Redirect("../OutwardListChecker.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (this.txtReturnReason.Text.Trim() != "")
            {
                string outwardID = base.Request.Params["OutwardID"];
                TeamRedDB teamRedDB = new TeamRedDB();
                teamRedDB.ReturnOutward08(outwardID, this.txtReturnReason.Text, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
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
//            if(!IsPostBack)
//            {
//                LoadData();
//            }
//        }
//        private void LoadData()
//        {
//            string OutwardID = Request.Params["OutwardID"];

//            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
//            RTGSImporter.Pacs008 pacs = db.GetSingleOutward08(OutwardID);
//            FMPS.BLL.NumberToWordConverter conv = new FMPS.BLL.NumberToWordConverter();

//            lblFrBICFI.Text = pacs.FrBICFI ;
//            lblToBICFI.Text = pacs.ToBICFI;
//            lblBizMsgIdr.Text = pacs.BizMsgIdr;
//            lblMsgDefIdr.Text = pacs.MsgDefIdr;
//            lblBizSvc.Text = pacs.BizSvc;
//            lblCreDt.Text = pacs.CreDt;
//            lblMsgId.Text = pacs.MsgId;
//            lblCreDtTm.Text = pacs.CreDtTm;
//            lblBtchBookg.Text = pacs.BtchBookg;
//            lblNbOfTxs.Text = pacs.NbOfTxs.ToString();
//            lblInstrId.Text = pacs.InstrId;
//            lblEndToEndId.Text = pacs.EndToEndId;
//            lblTxId.Text = pacs.TxId;
//            lblClrChanl.Text = pacs.ClrChanl;
//            lblSvcLvlPrtry.Text = pacs.SvcLvlPrtry.ToString();
//            lblLclInstrmPrtry.Text = pacs.LclInstrmPrtry.ToString();
//            lblCtgyPurpPrtry.Text = pacs.CtgyPurpPrtry;
//            lblCcy.Text = pacs.Ccy;
//            lblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
//            lblIntrBkSttlmAmt.ToolTip = conv.GetAmountInWords(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
//            lblIntrBkSttlmDt.Text = pacs.IntrBkSttlmDt;
//            lblChrgBr.Text = pacs.ChrgBr;
//            lblInstgAgtBICFI.Text = pacs.InstgAgtBICFI;
//            lblInstgAgtNm.Text = pacs.InstgAgtNm;
//            lblInstgAgtBranchId.Text = pacs.InstgAgtBranchId;
//            lblInstdAgtBICFI.Text = pacs.InstdAgtBICFI;
//            lblInstdAgtNm.Text = pacs.InstdAgtNm;
//            lblInstdAgtBranchId.Text = pacs.InstdAgtBranchId;
//            lblDbtrNm.Text = pacs.DbtrNm;
//            lblDbtrPstlAdr.Text = pacs.DbtrPstlAdr;
//            lblDbtrStrtNm.Text = pacs.DbtrStrtNm;
//            lblDbtrTwnNm.Text = pacs.DbtrTwnNm;
//            lblDbtrAdrLine.Text = pacs.DbtrAdrLine;
//            lblDbtrCtry.Text = pacs.DbtrCtry;
//            lblDbtrAcctOthrId.Text = pacs.DbtrAcctOthrId ;
//            lblDbtrAgtBICFI.Text = pacs.DbtrAgtBICFI;
//            lblDbtrAgtNm.Text = pacs.DbtrAgtNm;
//            lblDbtrAgtBranchId.Text = pacs.DbtrAgtBranchId;
//            lblDbtrAgtAcctOthrId.Text = pacs.DbtrAgtAcctOthrId;
//            lblDbtrAgtAcctPrtry.Text = pacs.DbtrAgtAcctPrtry;
//            lblCdtrAgtBICFI.Text = pacs.CdtrAgtBICFI;
//            lblCdtrAgtNm.Text = pacs.CdtrAgtNm;
//            lblCdtrAgtBranchId.Text = pacs.CdtrAgtBranchId;
//            lblCdtrAgtAcctOthrId.Text = pacs.CdtrAgtAcctOthrId;
//            lblCdtrAgtAcctPrtry.Text = pacs.CdtrAgtAcctPrtry;
//            lblCdtrNm.Text = pacs.CdtrNm;
//            lblCdtrPstlAdr.Text = pacs.CdtrPstlAdr;
//            lblCdtrStrtNm.Text = pacs.CdtrStrtNm;
//            lblCdtrTwnNm.Text = pacs.CdtrTwnNm;
//            lblCdtrAdrLine.Text = pacs.CdtrAdrLine;
//            lblCdtrCtry.Text = pacs.CdtrCtry;
//            lblCdtrAcctOthrId.Text = pacs.CdtrAcctOthrId;
//            lblCdtrAcctPrtry.Text = pacs.CdtrAcctPrtry;
//            lblInstrInf.Text = pacs.InstrInf;
//            lblUstrd.Text = pacs.Ustrd;
//            ChkChargerWaived.Checked = pacs.ChargeWaived;

//            lblCBSResponse.Text = pacs.CBSResponse;
//            //lblPmntRsn.Text = pacs.PmntRsn;

//            string RoleCD       = Request.Cookies["RoleCD"].Value;
//            Decimal TransLimit  = Decimal.Parse(Request.Cookies["TransLimit"].Value);

//            FloraSoft.BankSettingsDB bsdb = new FloraSoft.BankSettingsDB();
//            FloraSoft.BankSettings bs = bsdb.GetBankSettings();
//            DateTime cuttoffDate = System.DateTime.Today.AddHours((double) bs.AftrCutOffHr).AddMinutes((double) bs.AftrCutOffMin);

//            CCYDB ccdb = new CCYDB();
//            Decimal Rate = ccdb.GetCCYRate(pacs.Ccy);
//            Decimal ApprovalLimit = TransLimit / Rate;

//            if ((RoleCD == "RTCK") && (pacs.StatusID == 2))
//            {
//                ButtonPanel.Visible = true;
//            }
//            if ((RoleCD == "RTAU") && (pacs.StatusID == 3))
//            {
//                ButtonPanel.Visible = true;
//            }
//            if (ApprovalLimit < pacs.IntrBkSttlmAmt)
//            {
//                ButtonPanel.Visible = false;
//            }

//            if (cuttoffDate < System.DateTime.Now)
//            {
//                ButtonPanel.Visible = false;
//            }
//        }

//        protected void btnSend_Click(object sender, EventArgs e)
//        {
//            string OutwardID = Request.Params["OutwardID"];
//            string RoleCD = Request.Cookies["RoleCD"].Value;


//            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
//            if (RoleCD == "RTCK")
//            {
//                db.ApproveOutward08(OutwardID, Request.Cookies["LoginID"].Value, HttpContext.Current.Request.UserHostAddress);
//            }
//            if (RoleCD == "RTAU")
//            {
//                db.AuthOutward08(OutwardID, Request.Cookies["LoginID"].Value, HttpContext.Current.Request.UserHostAddress);
//            }

//            Response.Redirect("../OutwardListChecker.aspx");
//        }

//        protected void btnReturn_Click(object sender, EventArgs e)
//        {
//            if (txtReturnReason.Text.Trim() != "")
//            {
//                string OutwardID = Request.Params["OutwardID"];

//                RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
//                db.ReturnOutward08(OutwardID, txtReturnReason.Text, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);

//                Response.Redirect("../OutwardListChecker.aspx");
//            }
//        }

//        protected void btnCancelTrans_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("../OutwardListChecker.aspx");
//        }
//    }
//}