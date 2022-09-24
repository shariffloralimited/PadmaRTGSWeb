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
    public partial class Inward04Long : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.LoadData();
                BankSettings bankSettings = new BankSettings();
                BankSettingsDB bankSettingsDB = new BankSettingsDB();
                bankSettings = bankSettingsDB.GetBankSettings();
                if (bankSettings.SkipCBS)
                {
                    this.btnRetry.Visible = false;
                }
                else
                {
                    this.btnRetry.Visible = true;
                }
            }
        }

        private void LoadData()
        {
            string inwardID = base.Request.Params["InwardID"];
            TeamGreenDB teamGreenDB = new TeamGreenDB();
            Pacs004 singleInward = teamGreenDB.GetSingleInward04(inwardID);
            NumberToWordConverter numberToWordConverter = new NumberToWordConverter();
            this.lblFrBICFI.Text = singleInward.FrBICFI;
            this.lblToBICFI.Text = singleInward.ToBICFI;
            this.lblBizMsgIdr.Text = singleInward.BizMsgIdr;
            this.lblMsgDefIdr.Text = singleInward.MsgDefIdr;
            this.lblBizSvc.Text = singleInward.BizSvc;
            this.lblCreDt.Text = singleInward.CreDt;
            this.lblMsgId.Text = singleInward.MsgId;
            this.lblCreDtTm.Text = singleInward.CreDtTm;
            this.lblOrgnlMsgId.Text = singleInward.OrgnlMsgId;
            this.lblInstrId.Text = singleInward.OrgnlInstrId;
            this.lblOrgnlMsgNmId.Text = singleInward.OrgnlMsgNmId;
            this.lblOrgnlCreDtTm.Text = singleInward.OrgnlCreDtTm;
            this.lblEndToEndId.Text = singleInward.OrgnlEndToEndId;
            this.lblTxId.Text = singleInward.OrgnlTxId;
            this.lblSvcLvlPrtry.Text = singleInward.SvcLvlPrtry.ToString();
            this.lblLclInstrmPrtry.Text = singleInward.LclInstrmPrtry.ToString();
            this.lblCtgyPurpPrtry.Text = singleInward.CtgyPurpPrtry;
            this.lblCcy.Text = singleInward.TxRefIntrBkSttlmCcy;
            this.lblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(singleInward.TxRefIntrBkSttlmAmt, 2).ToString());
            this.lblIntrBkSttlmAmt.ToolTip = numberToWordConverter.GetAmountInWords(Math.Round(singleInward.TxRefIntrBkSttlmAmt, 2).ToString());
            this.lblIntrBkSttlmDt.Text = singleInward.TxRefIntrBkSttlmDt;
            this.lblChrgBr.Text = singleInward.ChrgBr;
            this.lblInstgAgtBICFI.Text = singleInward.InstgAgtBICFI;
            this.lblInstdAgtBICFI.Text = singleInward.InstdAgtBICFI;
            this.lblDbtrNm.Text = singleInward.DbtrNm;
            this.lblDbtrPstlAdr.Text = singleInward.DbtrNmPstlAdr;
            this.lblDbtrStrtNm.Text = singleInward.DbtrNmStrtNm;
            this.lblDbtrTwnNm.Text = singleInward.DbtrNmTwnNm;
            this.lblDbtrAdrLine.Text = singleInward.DbtrNmAdrLine;
            this.lblDbtrCtry.Text = singleInward.DbtrNmCtry;
            this.lblDbtrAcctOthrId.Text = singleInward.DbtrAcctId;
            this.lblDbtrAgtBICFI.Text = singleInward.DbtrAgtBICFI;
            this.lblDbtrAgtBranchId.Text = singleInward.DbtrAgtBranchId;
            this.lblDbtrAgtAcctOthrId.Text = singleInward.DbtrAgtAcctId;
            this.lblDbtrAgtAcctPrtry.Text = singleInward.DbtrAgtAcctPrtry;
            this.lblCdtrAgtBICFI.Text = singleInward.CdtrAgtBICFI;
            this.lblCdtrAgtNm.Text = singleInward.CdtrAgtNm;
            this.lblCdtrAgtBranchId.Text = singleInward.CdtrAgtBranchId;
            this.lblCdtrAgtAcctOthrId.Text = singleInward.CdtrAgtAcctId;
            this.lblCdtrAgtAcctPrtry.Text = singleInward.CdtrAgtAcctTpPrtry;
            this.lblCdtrNm.Text = singleInward.CdtrNm;
            this.lblCdtrAdrLine.Text = singleInward.CdtrAdrLine;
            this.lblCdtrAcctOthrId.Text = singleInward.CdtrAcctId;
            this.lblCdtrAcctPrtry.Text = singleInward.CdtrAcctTpPrtry;
            this.lblRtrRsnPrtry.Text = singleInward.RtrRsnPrtry;
            this.lblRtrRsnAddtInf.Text = singleInward.RtrRsnAddtlInf;
            string value = base.Request.Cookies["RoleCD"].Value;
            if (value == "RTMK" && singleInward.StatusID == 3)
            {
                this.ButtonPanel.Visible = true;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            TeamGreenDB teamGreenDB = new TeamGreenDB();
            teamGreenDB.ApproveInward04(base.Request.Params["InwardID"], base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            base.Response.Redirect("../InwardList.aspx");
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("../InwardList.aspx");
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
        }
    }
}
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if(!IsPostBack)
//            {
//                LoadData();

//                FloraSoft.BankSettings bs = new FloraSoft.BankSettings();
//                FloraSoft.BankSettingsDB db = new FloraSoft.BankSettingsDB();
//                bs = db.GetBankSettings();

//                if (bs.SkipCBS)
//                {
//                    btnRetry.Visible = false;
//                }
//                else
//                {
//                    btnRetry.Visible = true;
//                }  
//            }
           
//        }
//        private void LoadData()
//        { 
//            string InwardID = Request.Params["InwardID"];

//            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
//            RTGSImporter.Pacs004 pacs = db.GetSingleInward04(InwardID);
//            FMPS.BLL.NumberToWordConverter conv = new FMPS.BLL.NumberToWordConverter();

//            lblFrBICFI.Text = pacs.FrBICFI;
//            lblToBICFI.Text = pacs.ToBICFI;
//            lblBizMsgIdr.Text = pacs.BizMsgIdr;
//            lblMsgDefIdr.Text = pacs.MsgDefIdr;
//            lblBizSvc.Text = pacs.BizSvc;
//            lblCreDt.Text = pacs.CreDt;
//            lblMsgId.Text = pacs.MsgId;
//            lblCreDtTm.Text = pacs.CreDtTm;
//            //lblNbOfTxs.Text = pacs.NbOfTxs.ToString();
//            lblOrgnlMsgId.Text = pacs.OrgnlMsgId;
//            lblInstrId.Text = pacs.OrgnlInstrId;
//            lblOrgnlMsgNmId.Text = pacs.OrgnlMsgNmId;
//            lblOrgnlCreDtTm.Text = pacs.OrgnlCreDtTm;

//            lblEndToEndId.Text = pacs.OrgnlEndToEndId;
//            lblTxId.Text = pacs.OrgnlTxId;

//            //lblClrChanl.Text = pacs.;
//            lblSvcLvlPrtry.Text = pacs.SvcLvlPrtry.ToString();
//            lblLclInstrmPrtry.Text = pacs.LclInstrmPrtry.ToString();
//            lblCtgyPurpPrtry.Text = pacs.CtgyPurpPrtry;

//            lblCcy.Text = pacs.TxRefIntrBkSttlmCcy;
//            lblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(pacs.TxRefIntrBkSttlmAmt, 2).ToString());
//            lblIntrBkSttlmAmt.ToolTip = conv.GetAmountInWords(Math.Round(pacs.TxRefIntrBkSttlmAmt, 2).ToString());
//            lblIntrBkSttlmDt.Text = pacs.TxRefIntrBkSttlmDt;
//            lblChrgBr.Text = pacs.ChrgBr;
//            lblInstgAgtBICFI.Text = pacs.InstgAgtBICFI;
//            //lblInstgAgtNm.Text = pacs.Instg;
//            //lblInstgAgtBranchId.Text = pacs.Instg;
//            lblInstdAgtBICFI.Text = pacs.InstdAgtBICFI;
//            //lblInstdAgtNm.Text = pacs.InstdAgtNm;
//            //lblInstdAgtBranchId.Text = pacs.InstdAgtBranchId;
//            lblDbtrNm.Text = pacs.DbtrNm;
//            lblDbtrPstlAdr.Text = pacs.DbtrNmPstlAdr;
//            lblDbtrStrtNm.Text = pacs.DbtrNmStrtNm;
//            lblDbtrTwnNm.Text = pacs.DbtrNmTwnNm;
//            lblDbtrAdrLine.Text = pacs.DbtrNmAdrLine;
//            lblDbtrCtry.Text = pacs.DbtrNmCtry;
//            lblDbtrAcctOthrId.Text = pacs.DbtrAcctId ;
//            lblDbtrAgtBICFI.Text = pacs.DbtrAgtBICFI;
//            //lblDbtrAgtNm.Text = pacs.DbtrAgtNm;
//            lblDbtrAgtBranchId.Text = pacs.DbtrAgtBranchId;
//            lblDbtrAgtAcctOthrId.Text = pacs.DbtrAgtAcctId;
//            lblDbtrAgtAcctPrtry.Text = pacs.DbtrAgtAcctPrtry;
//            lblCdtrAgtBICFI.Text = pacs.CdtrAgtBICFI;
//            lblCdtrAgtNm.Text = pacs.CdtrAgtNm;
//            lblCdtrAgtBranchId.Text = pacs.CdtrAgtBranchId;
//            lblCdtrAgtAcctOthrId.Text = pacs.CdtrAgtAcctId;
//            lblCdtrAgtAcctPrtry.Text = pacs.CdtrAgtAcctTpPrtry;
//            lblCdtrNm.Text = pacs.CdtrNm;
//            //lblCdtrPstlAdr.Text = pacs.CdtrCdtrPstlAdr;
//            //lblCdtrStrtNm.Text = pacs.CdtrStrtNm;
//            //lblCdtrTwnNm.Text = pacs.CdtrTwnNm;
//            lblCdtrAdrLine.Text = pacs.CdtrAdrLine;
//            //lblCdtrCtry.Text = pacs.CdtrCtry;
//            lblCdtrAcctOthrId.Text = pacs.CdtrAcctId;
//            lblCdtrAcctPrtry.Text = pacs.CdtrAcctTpPrtry;

//            lblRtrRsnPrtry.Text = pacs.RtrRsnPrtry;
//            lblRtrRsnAddtInf.Text = pacs.RtrRsnAddtlInf;

//            //lblInstrInf.Text = pacs.;
//            //lblUstrd.Text = pacs.Ustrd;
//            //lblPmntRsn.Text = pacs.PmntRsn;
//            //lblCBSResponse.Text = pacs.CBSResponse;

//            string RoleCD = Request.Cookies["RoleCD"].Value;
//            if((RoleCD == "RTMK")&&(pacs.StatusID == 3))
//            {
//                ButtonPanel.Visible = true;
//            }
//        }

//        protected void btnSend_Click(object sender, EventArgs e)
//        {
//            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
//            db.ApproveInward04(Request.Params["InwardID"],Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            Response.Redirect("../InwardList.aspx");
//        }

//        protected void btnCancelTrans_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("../InwardList.aspx");
//        }

//        protected void btnTransfer_Click(object sender, EventArgs e)
//        {
//            //RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
//            //string InwardID = Request.Params["InwardID"];
//            //db.RetryInwardCBS(InwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            //Response.Redirect("../InwardList.aspx");
//        }

//    }
//}