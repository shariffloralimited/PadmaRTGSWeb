using FMPS.BLL;
using RTGSImporter;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward08LongMaker : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
		{
			if (base.Request.Cookies["RoleCD"].Value != "RTMK")
			{
				base.Response.Redirect("../AccessDenied.aspx");
			}
			if (!base.IsPostBack)
			{
				this.LoadData();
				if (base.Request.Cookies["AllBranch"].Value == "False")
				{
					this.TxtDbtrAgtBranchId.Enabled = false;
				}
				this.TxtDbtrAgtBICFI.Enabled = false;
			}
		}

		private void LoadData()
		{
			string outwardID = base.Request.Params["OutwardID"];
			TeamRedDB teamRedDB = new TeamRedDB();
			Pacs008 singleOutward = teamRedDB.GetSingleOutward08(outwardID);
			NumberToWordConverter numberToWordConverter = new NumberToWordConverter();
			this.TxtFrBICFI.Text = singleOutward.FrBICFI;
			this.TxtToBICFI.Text = singleOutward.ToBICFI;
			this.TxtBizMsgIdr.Text = singleOutward.BizMsgIdr;
			this.TxtMsgDefIdr.Text = singleOutward.MsgDefIdr;
			this.TxtBizSvc.Text = singleOutward.BizSvc;
			this.TxtCreDt.Text = singleOutward.CreDt;
			this.TxtMsgId.Text = singleOutward.MsgId;
			this.TxtCreDtTm.Text = singleOutward.CreDtTm;
			if (singleOutward.BtchBookg == "")
			{
				singleOutward.BtchBookg = "false";
			}
			this.ChkBtchBookg.Checked = bool.Parse(singleOutward.BtchBookg);
			this.TxtNbOfTxs.Text = singleOutward.NbOfTxs.ToString();
			this.TxtInstrId.Text = singleOutward.InstrId;
			this.TxtEndToEndId.Text = singleOutward.EndToEndId;
			this.TxtTxId.Text = singleOutward.TxId;
			this.TxtClrChanl.Text = singleOutward.ClrChanl;
			this.TxtSvcLvlPrtry.Text = singleOutward.SvcLvlPrtry.ToString();
			this.TxtLclInstrmPrtry.Text = singleOutward.LclInstrmPrtry.ToString();
			this.TxtCtgyPurpPrtry.Text = singleOutward.CtgyPurpPrtry;
			this.LblSettlementCurrency.Text = singleOutward.Ccy;
			this.LblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(singleOutward.IntrBkSttlmAmt, 2).ToString());
			this.LblIntrBkSttlmAmt.ToolTip = numberToWordConverter.GetAmountInWords(Math.Round(singleOutward.IntrBkSttlmAmt, 2).ToString());
			this.TxtIntrBkSttlmDt.Text = singleOutward.IntrBkSttlmDt;
			this.radioChargeBearer.SelectedValue = singleOutward.ChrgBr;
			this.TxtInstgAgtBICFI.Text = singleOutward.InstgAgtBICFI;
			this.TxtInstgAgtNm.Text = singleOutward.InstgAgtNm;
			this.TxtInstgAgtBranchId.Text = singleOutward.InstgAgtBranchId;
			this.TxtInstdAgtBICFI.Text = singleOutward.InstdAgtBICFI;
			this.TxtInstdAgtNm.Text = singleOutward.InstdAgtNm;
			this.TxtInstdAgtBranchId.Text = singleOutward.InstdAgtBranchId;
			this.TxtDbtrNm.Text = singleOutward.DbtrNm;
			this.TxtDbtrPstlAdr.Text = singleOutward.DbtrPstlAdr;
			this.TxtDbtrStrtNm.Text = singleOutward.DbtrStrtNm;
			this.TxtDbtrTwnNm.Text = singleOutward.DbtrTwnNm;
			this.TxtDbtrAdrLine.Text = singleOutward.DbtrAdrLine;
			this.TxtDbtrCtry.Text = singleOutward.DbtrCtry;
			this.lblDbtrAcctOthrId.Text = singleOutward.DbtrAcctOthrId;
			this.TxtDbtrAgtBICFI.Text = singleOutward.DbtrAgtBICFI;
			this.TxtDbtrAgtNm.Text = singleOutward.DbtrAgtNm;
			this.TxtDbtrAgtBranchId.Text = singleOutward.DbtrAgtBranchId;
			this.TxtDbtrAgtAcctOthrId.Text = singleOutward.DbtrAgtAcctOthrId;
			this.TxtDbtrAgtAcctPrtry.Text = singleOutward.DbtrAgtAcctPrtry;
			this.TxtCdtrAgtBICFI.Text = singleOutward.CdtrAgtBICFI;
			this.TxtCdtrAgtNm.Text = singleOutward.CdtrAgtNm;
			this.TxtCdtrAgtBranchId.Text = singleOutward.CdtrAgtBranchId;
			this.TxtCdtrAgtAcctOthrId.Text = singleOutward.CdtrAgtAcctOthrId;
			this.TxtCdtrAgtAcctPrtry.Text = singleOutward.CdtrAgtAcctPrtry;
			this.TxtCdtrNm.Text = singleOutward.CdtrNm;
			this.TxtCdtrPstlAdr.Text = singleOutward.CdtrPstlAdr;
			this.TxtCdtrStrtNm.Text = singleOutward.CdtrStrtNm;
			this.TxtCdtrTwnNm.Text = singleOutward.CdtrTwnNm;
			this.TxtCdtrAdrLine.Text = singleOutward.CdtrAdrLine;
			this.TxtCdtrCtry.Text = singleOutward.CdtrCtry;
			this.TxtCdtrAcctOthrId.Text = singleOutward.CdtrAcctOthrId;
			this.TxtCdtrAcctPrtry.Text = singleOutward.CdtrAcctPrtry;
			this.TxtInstrInf.Text = singleOutward.InstrInf;
			this.TxtUstrd.Text = singleOutward.Ustrd;
			this.LblReturnReason.Text = singleOutward.ReturnReason;
			this.ChkChargerWaived.Checked = singleOutward.ChargeWaived;
			this.lblCBSResponse.Text = singleOutward.CBSResponse;
		}

		protected void btnSend_Click(object sender, EventArgs e)
		{
			string pacsID = base.Request.Params["OutwardID"];
			TeamRedDB teamRedDB = new TeamRedDB();
			teamRedDB.UpdateOutward008(new Pacs008
			{
				PacsID = pacsID,
				FrBICFI = this.TxtFrBICFI.Text,
				ToBICFI = this.TxtToBICFI.Text,
				BizMsgIdr = this.TxtBizMsgIdr.Text,
				MsgDefIdr = this.TxtMsgDefIdr.Text,
				BizSvc = this.TxtBizSvc.Text,
				CreDt = this.TxtCreDt.Text,
				MsgId = this.TxtMsgId.Text,
				CreDtTm = this.TxtCreDtTm.Text,
				BtchBookg = this.ChkBtchBookg.Checked.ToString(),
				NbOfTxs = int.Parse(this.TxtNbOfTxs.Text),
				InstrId = this.TxtInstrId.Text,
				EndToEndId = this.TxtEndToEndId.Text,
				TxId = this.TxtTxId.Text,
				ClrChanl = this.TxtClrChanl.Text,
				SvcLvlPrtry = int.Parse(this.TxtSvcLvlPrtry.Text),
				LclInstrmPrtry = this.TxtLclInstrmPrtry.Text,
				CtgyPurpPrtry = this.TxtCtgyPurpPrtry.Text,
				Ccy = this.LblSettlementCurrency.Text,
				IntrBkSttlmAmt = decimal.Parse(this.LblIntrBkSttlmAmt.Text),
				IntrBkSttlmDt = this.TxtIntrBkSttlmDt.Text,
				ChrgBr = this.radioChargeBearer.SelectedValue,
				InstgAgtBICFI = this.TxtInstgAgtBICFI.Text,
				InstgAgtNm = this.TxtInstgAgtNm.Text,
				InstgAgtBranchId = this.TxtInstgAgtBranchId.Text,
				InstdAgtBICFI = this.TxtInstdAgtBICFI.Text,
				InstdAgtNm = this.TxtInstdAgtNm.Text,
				InstdAgtBranchId = this.TxtInstdAgtBranchId.Text,
				DbtrNm = this.TxtDbtrNm.Text,
				DbtrPstlAdr = this.TxtDbtrPstlAdr.Text,
				DbtrStrtNm = this.TxtDbtrStrtNm.Text,
				DbtrTwnNm = this.TxtDbtrTwnNm.Text,
				DbtrAdrLine = this.TxtDbtrAdrLine.Text,
				DbtrCtry = this.TxtDbtrCtry.Text,
				DbtrAcctOthrId = this.lblDbtrAcctOthrId.Text,
				DbtrAgtBICFI = this.TxtDbtrAgtBICFI.Text,
				DbtrAgtNm = this.TxtDbtrAgtNm.Text,
				DbtrAgtBranchId = this.TxtDbtrAgtBranchId.Text,
				DbtrAgtAcctOthrId = this.TxtDbtrAgtAcctOthrId.Text,
				DbtrAgtAcctPrtry = this.TxtDbtrAgtAcctPrtry.Text,
				CdtrAgtBICFI = this.TxtCdtrAgtBICFI.Text,
				CdtrAgtNm = this.TxtCdtrAgtNm.Text,
				CdtrAgtBranchId = this.TxtCdtrAgtBranchId.Text,
				CdtrAgtAcctOthrId = this.TxtCdtrAgtAcctOthrId.Text,
				CdtrAgtAcctPrtry = this.TxtCdtrAgtAcctPrtry.Text,
				CdtrNm = this.TxtCdtrNm.Text,
				CdtrPstlAdr = this.TxtCdtrPstlAdr.Text,
				CdtrStrtNm = this.TxtCdtrStrtNm.Text,
				CdtrTwnNm = this.TxtCdtrTwnNm.Text,
				CdtrAdrLine = this.TxtCdtrAdrLine.Text,
				CdtrCtry = this.TxtCdtrCtry.Text,
				CdtrAcctOthrId = this.TxtCdtrAcctOthrId.Text,
				CdtrAcctPrtry = this.TxtCdtrAcctPrtry.Text,
				InstrInf = this.TxtInstrInf.Text,
                //change for FCY
                OrginatorACType = txtOrginatorACType.Text,
                ReceiverACType = txtRecieverACType.Text,
                PurposeOfTransaction = txtTransactionPurpose.Text,
                OtherInfo = txtOtherInf.Text,

                //end
                Ustrd = this.TxtUstrd.Text,
				Maker = base.Request.Cookies["UserName"].Value,
				MakerIP = HttpContext.Current.Request.UserHostAddress
			});
			base.Response.Redirect("../OutwardListMaker.aspx");
		}

		protected void btnCancelTrans_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("../OutwardListMaker.aspx");
		}

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			string outwardID = base.Request.Params["OutwardID"];
			TeamRedDB teamRedDB = new TeamRedDB();
			teamRedDB.DeleteOutward08(outwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
			base.Response.Redirect("../OutwardListMaker.aspx");
		}
	}
}

//            if (Request.Cookies["RoleCD"].Value != "RTMK") 
//            {
//                Response.Redirect("../AccessDenied.aspx");
//            }
//            if(!IsPostBack)
//            {
//                LoadData();
//                if (Request.Cookies["AllBranch"].Value == "False")
//                {
//                    TxtDbtrAgtBranchId.Enabled = false;
//                }
//                TxtDbtrAgtBICFI.Enabled = false;
//            }
//        }
//        private void LoadData()
//        {
//            string OutwardID = Request.Params["OutwardID"];

//            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
//            RTGSImporter.Pacs008 pacs = db.GetSingleOutward08(OutwardID);
//            FMPS.BLL.NumberToWordConverter conv = new FMPS.BLL.NumberToWordConverter();

//            TxtFrBICFI.Text = pacs.FrBICFI ;
//            TxtToBICFI.Text = pacs.ToBICFI;
//            TxtBizMsgIdr.Text = pacs.BizMsgIdr;
//            TxtMsgDefIdr.Text = pacs.MsgDefIdr;
//            TxtBizSvc.Text = pacs.BizSvc;
//            TxtCreDt.Text = pacs.CreDt;
//            TxtMsgId.Text = pacs.MsgId;
//            TxtCreDtTm.Text = pacs.CreDtTm;
//            if (pacs.BtchBookg == "")
//                pacs.BtchBookg = "false";
//            ChkBtchBookg.Checked = bool.Parse(pacs.BtchBookg);
//            TxtNbOfTxs.Text = pacs.NbOfTxs.ToString();
//            TxtInstrId.Text = pacs.InstrId;
//            TxtEndToEndId.Text = pacs.EndToEndId;
//            TxtTxId.Text = pacs.TxId;
//            TxtClrChanl.Text = pacs.ClrChanl;
//            TxtSvcLvlPrtry.Text = pacs.SvcLvlPrtry.ToString();
//            TxtLclInstrmPrtry.Text = pacs.LclInstrmPrtry.ToString();
//            TxtCtgyPurpPrtry.Text = pacs.CtgyPurpPrtry;
//            LblSettlementCurrency.Text = pacs.Ccy;
//            //TxtCcy.Text = pacs.Ccy ;
//          ///  LblIntrBkSttlmAmt.Text = pacs.IntrBkSttlmAmt.ToString("0.00");
//           /// decimal sttlmmtAmt = Decimal.Parse(txtSettlmentAmount.Text);
//            LblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
//            LblIntrBkSttlmAmt.ToolTip = conv.GetAmountInWords(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
//            TxtIntrBkSttlmDt.Text = pacs.IntrBkSttlmDt;
//            radioChargeBearer.SelectedValue = pacs.ChrgBr;
//            //TxtChrgBr.Text = pacs.ChrgBr;
//            TxtInstgAgtBICFI.Text = pacs.InstgAgtBICFI;
//            TxtInstgAgtNm.Text = pacs.InstgAgtNm;
//            TxtInstgAgtBranchId.Text = pacs.InstgAgtBranchId;
//            TxtInstdAgtBICFI.Text = pacs.InstdAgtBICFI;
//            TxtInstdAgtNm.Text = pacs.InstdAgtNm;
//            TxtInstdAgtBranchId.Text = pacs.InstdAgtBranchId;
//            TxtDbtrNm.Text = pacs.DbtrNm;
//            TxtDbtrPstlAdr.Text = pacs.DbtrPstlAdr;
//            TxtDbtrStrtNm.Text = pacs.DbtrStrtNm;
//            TxtDbtrTwnNm.Text = pacs.DbtrTwnNm;
//            TxtDbtrAdrLine.Text = pacs.DbtrAdrLine;
//            TxtDbtrCtry.Text = pacs.DbtrCtry;
//            lblDbtrAcctOthrId.Text = pacs.DbtrAcctOthrId ;
//            TxtDbtrAgtBICFI.Text = pacs.DbtrAgtBICFI;
//            TxtDbtrAgtNm.Text = pacs.DbtrAgtNm;
//            TxtDbtrAgtBranchId.Text = pacs.DbtrAgtBranchId;
//            TxtDbtrAgtAcctOthrId.Text = pacs.DbtrAgtAcctOthrId;
//            TxtDbtrAgtAcctPrtry.Text = pacs.DbtrAgtAcctPrtry;
//            TxtCdtrAgtBICFI.Text    = pacs.CdtrAgtBICFI;
//            TxtCdtrAgtNm.Text       = pacs.CdtrAgtNm;
//            TxtCdtrAgtBranchId.Text = pacs.CdtrAgtBranchId;
//            TxtCdtrAgtAcctOthrId.Text= pacs.CdtrAgtAcctOthrId;
//            TxtCdtrAgtAcctPrtry.Text= pacs.CdtrAgtAcctPrtry;
//            TxtCdtrNm.Text          = pacs.CdtrNm;
//            TxtCdtrPstlAdr.Text     = pacs.CdtrPstlAdr;
//            TxtCdtrStrtNm.Text      = pacs.CdtrStrtNm;
//            TxtCdtrTwnNm.Text       = pacs.CdtrTwnNm;
//            TxtCdtrAdrLine.Text     = pacs.CdtrAdrLine;
//            TxtCdtrCtry.Text        = pacs.CdtrCtry;
//            TxtCdtrAcctOthrId.Text  = pacs.CdtrAcctOthrId;
//            TxtCdtrAcctPrtry.Text   = pacs.CdtrAcctPrtry;
//            TxtInstrInf.Text        = pacs.InstrInf;
//            TxtUstrd.Text           = pacs.Ustrd;
//            //TxtPmntRsn.Text       = pacs.PmntRsn;
//            LblReturnReason.Text    = pacs.ReturnReason;
//            ChkChargerWaived.Checked = pacs.ChargeWaived;
//            lblCBSResponse.Text     = pacs.CBSResponse;

//            //TxtMaker.Text = pacs.Maker;
//            //TxtMakeTime.Text = pacs.MakeTime;
//            //TxtMakerIP.Text = pacs.MakerIP;
//            //TxtStatusID.Text = pacs.StatusID;
//        }

//        protected void btnSend_Click(object sender, EventArgs e)
//        {
//            string OutwardID = Request.Params["OutwardID"];

//            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
//            RTGSImporter.Pacs008 pacs = new RTGSImporter.Pacs008();

//            pacs.PacsID = OutwardID;
//            pacs.FrBICFI = TxtFrBICFI.Text;
//            pacs.ToBICFI = TxtToBICFI.Text;
//            pacs.BizMsgIdr = TxtBizMsgIdr.Text;
//            pacs.MsgDefIdr = TxtMsgDefIdr.Text;
//            pacs.BizSvc = TxtBizSvc.Text;
//            pacs.CreDt = TxtCreDt.Text;
//            pacs.MsgId = TxtMsgId.Text;
//            pacs.CreDtTm = TxtCreDtTm.Text;
//            pacs.BtchBookg = ChkBtchBookg.Checked.ToString();
//            pacs.NbOfTxs = Int32.Parse(TxtNbOfTxs.Text);
//            pacs.InstrId = TxtInstrId.Text;
//            pacs.EndToEndId = TxtEndToEndId.Text;
//            pacs.TxId = TxtTxId.Text;
//            pacs.ClrChanl = TxtClrChanl.Text;
//            pacs.SvcLvlPrtry = Int32.Parse(TxtSvcLvlPrtry.Text);
//            pacs.LclInstrmPrtry = TxtLclInstrmPrtry.Text;
//            pacs.CtgyPurpPrtry = TxtCtgyPurpPrtry.Text;
//            pacs.Ccy = LblSettlementCurrency.Text;
//            pacs.IntrBkSttlmAmt = decimal.Parse(LblIntrBkSttlmAmt.Text);
//            pacs.IntrBkSttlmDt = TxtIntrBkSttlmDt.Text;
//            pacs.ChrgBr = radioChargeBearer.SelectedValue;
//            pacs.InstgAgtBICFI = TxtInstgAgtBICFI.Text;
//            pacs.InstgAgtNm = TxtInstgAgtNm.Text;
//            pacs.InstgAgtBranchId = TxtInstgAgtBranchId.Text;
//            pacs.InstdAgtBICFI = TxtInstdAgtBICFI.Text;
//            pacs.InstdAgtNm = TxtInstdAgtNm.Text;
//            pacs.InstdAgtBranchId = TxtInstdAgtBranchId.Text;
//            pacs.DbtrNm = TxtDbtrNm.Text;
//            pacs.DbtrPstlAdr = TxtDbtrPstlAdr.Text;
//            pacs.DbtrStrtNm = TxtDbtrStrtNm.Text;
//            pacs.DbtrTwnNm = TxtDbtrTwnNm.Text;
//            pacs.DbtrAdrLine = TxtDbtrAdrLine.Text;
//            pacs.DbtrCtry = TxtDbtrCtry.Text;
//            pacs.DbtrAcctOthrId = lblDbtrAcctOthrId.Text;
//            pacs.DbtrAgtBICFI = TxtDbtrAgtBICFI.Text;
//            pacs.DbtrAgtNm = TxtDbtrAgtNm.Text;
//            pacs.DbtrAgtBranchId = TxtDbtrAgtBranchId.Text;
//            pacs.DbtrAgtAcctOthrId = TxtDbtrAgtAcctOthrId.Text;
//            pacs.DbtrAgtAcctPrtry = TxtDbtrAgtAcctPrtry.Text;
//            pacs.CdtrAgtBICFI = TxtCdtrAgtBICFI.Text;
//            pacs.CdtrAgtNm = TxtCdtrAgtNm.Text;
//            pacs.CdtrAgtBranchId = TxtCdtrAgtBranchId.Text;
//            pacs.CdtrAgtAcctOthrId = TxtCdtrAgtAcctOthrId.Text;
//            pacs.CdtrAgtAcctPrtry = TxtCdtrAgtAcctPrtry.Text;
//            pacs.CdtrNm = TxtCdtrNm.Text;
//            pacs.CdtrPstlAdr = TxtCdtrPstlAdr.Text;
//            pacs.CdtrStrtNm = TxtCdtrStrtNm.Text;
//            pacs.CdtrTwnNm = TxtCdtrTwnNm.Text;
//            pacs.CdtrAdrLine = TxtCdtrAdrLine.Text;
//            pacs.CdtrCtry = TxtCdtrCtry.Text;
//            pacs.CdtrAcctOthrId = TxtCdtrAcctOthrId.Text;
//            pacs.CdtrAcctPrtry = TxtCdtrAcctPrtry.Text;
//            pacs.InstrInf = TxtInstrInf.Text;
//            pacs.Ustrd = TxtUstrd.Text;
//            //pacs.PmntRsn = TxtPmntRsn.Text;
//            pacs.Maker = Request.Cookies["UserName"].Value;
//            pacs.MakerIP = HttpContext.Current.Request.UserHostAddress;

//            db.UpdateOutward008(pacs);
//            Response.Redirect("../OutwardListMaker.aspx");
//        }

//        protected void btnCancelTrans_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("../OutwardListMaker.aspx");
//        }

//        protected void btnDelete_Click(object sender, EventArgs e)
//        {
//            string OutwardID = Request.Params["OutwardID"];

//            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
//            db.DeleteOutward08(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            Response.Redirect("../OutwardListMaker.aspx");
//        }



//    }
//}