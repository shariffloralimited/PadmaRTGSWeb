//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using RTGSImporter;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Inward08Long : System.Web.UI.Page
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
            string inwardID = base.Request.Params["InwardID"];
            TeamRedDB teamRedDB = new TeamRedDB();
            Pacs008 singleInward = teamRedDB.GetSingleInward08(inwardID);
            this.lblFrBICFI.Text = singleInward.FrBICFI;
            this.lblToBICFI.Text = singleInward.ToBICFI;
            this.lblBizMsgIdr.Text = singleInward.BizMsgIdr;
            this.lblMsgDefIdr.Text = singleInward.MsgDefIdr;
            this.lblBizSvc.Text = singleInward.BizSvc;
            this.lblCreDt.Text = singleInward.CreDt;
            this.lblMsgId.Text = singleInward.MsgId;
            this.lblCreDtTm.Text = singleInward.CreDtTm;
            this.lblBtchBookg.Text = singleInward.BtchBookg;
            this.lblNbOfTxs.Text = singleInward.NbOfTxs.ToString();
            this.lblInstrId.Text = singleInward.InstrId;
            this.lblEndToEndId.Text = singleInward.EndToEndId;
            this.lblTxId.Text = singleInward.TxId;
            this.lblClrChanl.Text = singleInward.ClrChanl;
            this.lblSvcLvlPrtry.Text = singleInward.SvcLvlPrtry.ToString();
            this.lblLclInstrmPrtry.Text = singleInward.LclInstrmPrtry.ToString();
            this.lblCtgyPurpPrtry.Text = singleInward.CtgyPurpPrtry;
            this.lblCcy.Text = singleInward.Ccy;
            this.lblIntrBkSttlmAmt.Text = singleInward.IntrBkSttlmAmt.ToString();
            this.lblIntrBkSttlmDt.Text = singleInward.IntrBkSttlmDt;
            this.lblChrgBr.Text = singleInward.ChrgBr;
            this.lblInstgAgtBICFI.Text = singleInward.InstgAgtBICFI;
            this.lblInstgAgtNm.Text = singleInward.InstgAgtNm;
            this.lblInstgAgtBranchId.Text = singleInward.InstgAgtBranchId;
            this.lblInstdAgtBICFI.Text = singleInward.InstdAgtBICFI;
            this.lblInstdAgtNm.Text = singleInward.InstdAgtNm;
            this.lblInstdAgtBranchId.Text = singleInward.InstdAgtBranchId;
            this.lblDbtrNm.Text = singleInward.DbtrNm;
            this.lblDbtrPstlAdr.Text = singleInward.DbtrPstlAdr;
            this.lblDbtrStrtNm.Text = singleInward.DbtrStrtNm;
            this.lblDbtrTwnNm.Text = singleInward.DbtrTwnNm;
            this.lblDbtrAdrLine.Text = singleInward.DbtrAdrLine;
            this.lblDbtrCtry.Text = singleInward.DbtrCtry;
            this.lblDbtrAcctOthrId.Text = singleInward.DbtrAcctOthrId;
            this.lblDbtrAgtBICFI.Text = singleInward.DbtrAgtBICFI;
            this.lblDbtrAgtNm.Text = singleInward.DbtrAgtNm;
            this.lblDbtrAgtBranchId.Text = singleInward.DbtrAgtBranchId;
            this.lblDbtrAgtAcctOthrId.Text = singleInward.DbtrAgtAcctOthrId;
            this.lblDbtrAgtAcctPrtry.Text = singleInward.DbtrAgtAcctPrtry;
            this.lblCdtrAgtBICFI.Text = singleInward.CdtrAgtBICFI;
            this.lblCdtrAgtNm.Text = singleInward.CdtrAgtNm;
            this.lblCdtrAgtBranchId.Text = singleInward.CdtrAgtBranchId;
            this.lblCdtrAgtAcctOthrId.Text = singleInward.CdtrAgtAcctOthrId;
            this.lblCdtrAgtAcctPrtry.Text = singleInward.CdtrAgtAcctPrtry;
            this.lblCdtrNm.Text = singleInward.CdtrNm;
            this.lblCdtrPstlAdr.Text = singleInward.CdtrPstlAdr;
            this.lblCdtrStrtNm.Text = singleInward.CdtrStrtNm;
            this.lblCdtrTwnNm.Text = singleInward.CdtrTwnNm;
            this.lblCdtrAdrLine.Text = singleInward.CdtrAdrLine;
            this.lblCdtrCtry.Text = singleInward.CdtrCtry;
            this.lblCdtrAcctOthrId.Text = singleInward.CdtrAcctOthrId;
            this.lblCdtrAcctPrtry.Text = singleInward.CdtrAcctPrtry;
            this.lblInstrInf.Text = singleInward.InstrInf;
            this.lblUstrd.Text = singleInward.Ustrd;
            this.lblPmntRsn.Text = singleInward.PmntRsn;
            this.lblCBSResponse.Text = singleInward.CBSResponse;
            string value = base.Request.Cookies["RoleCD"].Value;
            if (value == "RTMK" && singleInward.StatusID == 3)
            {
                this.ButtonPanel.Visible = true;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("PaymentReturn.aspx?FormName=Pacs.008&InwardID=" + base.Request.Params["InwardID"]);
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("../InwardList.aspx");
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            TeamRedDB teamRedDB = new TeamRedDB();
            string inwardID = base.Request.Params["InwardID"];
            teamRedDB.RetryInwardCBS(inwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            base.Response.Redirect("../InwardList.aspx");
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            TeamRedDB teamRedDB = new TeamRedDB();
            string inwardID = base.Request.Params["InwardID"];
            teamRedDB.ApproveInward08(inwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            base.Response.Redirect("../InwardList.aspx");
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
//            string InwardID = Request.Params["InwardID"];

//            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
//            RTGSImporter.Pacs008 pacs = db.GetSingleInward08(InwardID);

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
//            lblIntrBkSttlmAmt.Text = pacs.IntrBkSttlmAmt.ToString();
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
//            lblPmntRsn.Text = pacs.PmntRsn;
//            lblCBSResponse.Text = pacs.CBSResponse;

//            string RoleCD = Request.Cookies["RoleCD"].Value;
//            if((RoleCD == "RTMK")&&(pacs.StatusID == 3))
//            {
//                ButtonPanel.Visible = true;
//            }
//        }

//        protected void btnSend_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("PaymentReturn.aspx?FormName=Pacs.008&InwardID=" + Request.Params["InwardID"]);
//        }

//        protected void btnCancelTrans_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("../InwardList.aspx");
//        }

//        protected void btnTransfer_Click(object sender, EventArgs e)
//        {
//            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
//            string InwardID = Request.Params["InwardID"];
//            //string NewAccountNo = txtNewAccountNo.Text;

//            //if (NewAccountNo != "")
//            //{
//            //    db.TransferInward08(InwardID, NewAccountNo, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            //    Response.Redirect("../InwardList.aspx");
//            //}
//            db.RetryInwardCBS(InwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            Response.Redirect("../InwardList.aspx");
//        }

//        protected void btnApprove_Click(object sender, EventArgs e)
//        {
//            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
//            string InwardID = Request.Params["InwardID"];

//            db.ApproveInward08(InwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            Response.Redirect("../InwardList.aspx");
//        }

//    }
//}