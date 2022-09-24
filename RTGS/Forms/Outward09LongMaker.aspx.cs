using RTGSImporter;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward09LongMaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Cookies["RoleCD"].Value != "RTMK")
            {
                base.Response.Redirect("../AccessDenied.aspx");
            }
            if (!base.IsPostBack)
            {
                TransCodeDB transCodeDB = new TransCodeDB();
                this.ddlCtgyPurpPrtry.DataSource = transCodeDB.GetTransCode("Pacs09");
                this.ddlCtgyPurpPrtry.DataBind();
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
                this.lblMsg.Text = singleOutward.PacsID;
            }
            this.txtFrBICFI.Text = singleOutward.FrBICFI;
            this.txtToBICFI.Text = singleOutward.ToBICFI;
            this.txtBizMsgIdr.Text = singleOutward.BizMsgIdr;
            this.txtMsgDefIdr.Text = singleOutward.MsgDefIdr;
            this.txtBizSvc.Text = singleOutward.BizSvc;
            this.txtCreDt.Text = singleOutward.CreDt;
            this.txtMsgId.Text = singleOutward.MsgId;
            this.txtCreDtTm.Text = singleOutward.CreDtTm;
            this.txtNbOfTxs.Text = singleOutward.NbOfTxs.ToString();
            this.txtInstgAgtBICFI.Text = singleOutward.InstgAgtBICFI;
            this.txtInstgAgtNm.Text = singleOutward.InstgAgtNm;
            this.txtInstgAgtBranchId.Text = singleOutward.InstgAgtBranchId;
            this.txtInstdAgtBICFI.Text = singleOutward.InstdAgtBICFI;
            this.txtInstdAgtNm.Text = singleOutward.InstdAgtNm;
            this.txtInstdAgtBranchId.Text = singleOutward.InstdAgtBranchId;
            this.txtIntrmyAgt1BICFI.Text = singleOutward.IntrmyAgt1BICFI;
            this.txtIntrmyAgt1Nm.Text = singleOutward.IntrmyAgt1Nm;
            this.txtIntrmyAgt1BranchId.Text = singleOutward.IntrmyAgt1BranchId;
            this.txtIntrmyAgt1AcctId.Text = singleOutward.IntrmyAgt1AcctId;
            this.txtIntrmyAgt1AcctTp.Text = singleOutward.IntrmyAgt1AcctTp;
            this.txtLclInstrmPrtry.Text = singleOutward.LclInstrmPrtry;
            this.txtSvcLvlPrtry.Text = singleOutward.SvcLvlPrtry;
            this.ddlCtgyPurpPrtry.SelectedValue = singleOutward.CtgyPurpPrtry;
            this.txtInstrId.Text = singleOutward.InstrId;
            this.txtTxId.Text = singleOutward.TxId;
            this.txtEndToEndId.Text = singleOutward.EndToEndId;
            this.lblSettlementCurrency.Text = singleOutward.IntrBkSttlmCcy;
            this.lblIntrBkSttlmAmt.Text = singleOutward.IntrBkSttlmAmt.ToString("0.00");
            this.txtIntrBkSttlmDt.Text = singleOutward.IntrBkSttlmDt;
            this.txtDbtrBICFI.Text = singleOutward.DbtrBICFI;
            this.txtDbtrNm.Text = singleOutward.DbtrNm;
            this.txtDbtrBranchId.Text = singleOutward.DbtrBranchId;
            this.lblDbtrAcctId.Text = singleOutward.DbtrAcctId;
            this.txtDbtrAcctTp.Text = singleOutward.DbtrAcctTp;
            this.txtCdtrAgtBICFI.Text = singleOutward.CdtrAgtBICFI;
            this.txtCdtrAgtBranchId.Text = singleOutward.CdtrAgtBranchId;
            this.txtCdtrAgtAcctId.Text = singleOutward.CdtrAgtAcctId;
            this.txtCdtrAgtAcctTp.Text = singleOutward.CdtrAgtAcctTp;
            this.txtCdtrBICFI.Text = singleOutward.CdtrBICFI;
            this.txtCdtrNm.Text = singleOutward.CdtrNm;
            this.txtCdtrBranchId.Text = singleOutward.CdtrBranchId;
            this.lblCdtrAcctId.Text = singleOutward.CdtrAcctId;
            this.txtCdtrAcctTp.Text = singleOutward.CdtrAcctTp;
            this.txtInstrInf.Text = singleOutward.InstrInf;
            this.LblReturnReason.Text = singleOutward.ReturnReason;
            this.ChkNoCBS.Checked = singleOutward.NoCBS;
            this.lblCBSResponse.Text = singleOutward.CBSResponse;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            TeamBlueDB teamBlueDB = new TeamBlueDB();
            teamBlueDB.UpdateOutward009(new Pacs009
            {
                PacsID = base.Request.Params["OutwardID"],
                FrBICFI = this.txtFrBICFI.Text,
                ToBICFI = this.txtToBICFI.Text,
                BizMsgIdr = this.txtBizMsgIdr.Text,
                MsgDefIdr = this.txtMsgDefIdr.Text,
                BizSvc = this.txtBizSvc.Text,
                CreDt = this.txtCreDt.Text,
                MsgId = this.txtMsgId.Text,
                CreDtTm = this.txtCreDtTm.Text,
                NbOfTxs = int.Parse(this.txtNbOfTxs.Text),
                InstgAgtBICFI = this.txtInstgAgtBICFI.Text,
                InstgAgtNm = this.txtInstgAgtNm.Text,
                InstgAgtBranchId = this.txtInstgAgtBranchId.Text,
                InstdAgtBICFI = this.txtInstdAgtBICFI.Text,
                InstdAgtNm = this.txtInstdAgtNm.Text,
                InstdAgtBranchId = this.txtInstdAgtBranchId.Text,
                IntrmyAgt1BICFI = this.txtIntrmyAgt1BICFI.Text,
                IntrmyAgt1Nm = this.txtIntrmyAgt1Nm.Text,
                IntrmyAgt1BranchId = this.txtIntrmyAgt1BranchId.Text,
                IntrmyAgt1AcctId = this.txtIntrmyAgt1AcctId.Text,
                IntrmyAgt1AcctTp = this.txtIntrmyAgt1AcctTp.Text,
                LclInstrmPrtry = this.txtLclInstrmPrtry.Text,
                SvcLvlPrtry = this.txtSvcLvlPrtry.Text,
                CtgyPurpPrtry = this.ddlCtgyPurpPrtry.SelectedValue,
                InstrId = this.txtInstrId.Text,
                TxId = this.txtTxId.Text,
                EndToEndId = this.txtEndToEndId.Text,
                IntrBkSttlmCcy = this.lblSettlementCurrency.Text,
                IntrBkSttlmAmt = decimal.Parse(this.lblIntrBkSttlmAmt.Text),
                IntrBkSttlmDt = this.txtIntrBkSttlmDt.Text,
                DbtrBICFI = this.txtDbtrBICFI.Text,
                DbtrNm = this.txtDbtrNm.Text,
                DbtrBranchId = this.txtDbtrBranchId.Text,
                DbtrAcctId = this.lblDbtrAcctId.Text,
                DbtrAcctTp = this.txtDbtrAcctTp.Text,
                CdtrAgtBICFI = this.txtCdtrAgtBICFI.Text,
                CdtrAgtBranchId = this.txtCdtrAgtBranchId.Text,
                CdtrAgtAcctId = this.txtCdtrAgtAcctId.Text,
                CdtrAgtAcctTp = this.txtCdtrAgtAcctTp.Text,
                CdtrBICFI = this.txtCdtrBICFI.Text,
                CdtrNm = this.txtCdtrNm.Text,
                CdtrBranchId = this.txtCdtrBranchId.Text,
                CdtrAcctId = this.lblCdtrAcctId.Text,
                CdtrAcctTp = this.txtCdtrAcctTp.Text,
                InstrInf = this.txtInstrInf.Text,
                PmntRsn = this.lblMsg.Text,
                Maker = base.Request.Cookies["UserName"].Value,
                MakerIP = HttpContext.Current.Request.UserHostAddress
            });
            base.Response.Redirect("../OutwardListMaker.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string outwardID = base.Request.Params["OutwardID"];
            TeamBlueDB teamBlueDB = new TeamBlueDB();
            teamBlueDB.DeleteOutward09(outwardID, base.Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            base.Response.Redirect("../OutwardListMaker.aspx");
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("../OutwardListMaker.aspx");
        }
    }
}

//        protected void Page_Load(object sender, EventArgs e)
//            //{
//            //    if (Request.Cookies["RoleCD"].Value != "RTMK") 
//            //    {
//            //        Response.Redirect("../AccessDenied.aspx");
//            //    }
//            //    if (!IsPostBack)
//            //    {
//            //        TransCodeDB tr = new TransCodeDB();
//            //        ddlCtgyPurpPrtry.DataSource = tr.GetTransCode();
//            //        ddlCtgyPurpPrtry.DataBind();

//            //        LoadData();
//            //    }
//            //}

//        {
//            if (Request.Cookies["RoleCD"].Value != "RTMK")
//            {
//                Response.Redirect("../AccessDenied.aspx");
//            }
//            if (!IsPostBack)
//            {
//                TransCodeDB tr = new TransCodeDB();
//                ddlCtgyPurpPrtry.DataSource = tr.GetTransCode("Pacs09");
//                ddlCtgyPurpPrtry.DataBind();

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
//                lblMsg.Text = pacs.PacsID;
//            }

//            txtFrBICFI.Text = pacs.FrBICFI;
//            txtToBICFI.Text = pacs.ToBICFI;
//            txtBizMsgIdr.Text = pacs.BizMsgIdr;
//            txtMsgDefIdr.Text = pacs.MsgDefIdr;
//            txtBizSvc.Text = pacs.BizSvc;
//            txtCreDt.Text = pacs.CreDt;
//            txtMsgId.Text = pacs.MsgId;
//            txtCreDtTm.Text = pacs.CreDtTm;
//            txtNbOfTxs.Text = pacs.NbOfTxs.ToString();
//            txtInstgAgtBICFI.Text = pacs.InstgAgtBICFI;
//            txtInstgAgtNm.Text = pacs.InstgAgtNm;
//            txtInstgAgtBranchId.Text = pacs.InstgAgtBranchId;
//            txtInstdAgtBICFI.Text = pacs.InstdAgtBICFI;
//            txtInstdAgtNm.Text = pacs.InstdAgtNm;
//            txtInstdAgtBranchId.Text = pacs.InstdAgtBranchId;
//            txtIntrmyAgt1BICFI.Text = pacs.IntrmyAgt1BICFI;
//            txtIntrmyAgt1Nm.Text = pacs.IntrmyAgt1Nm;
//            txtIntrmyAgt1BranchId.Text = pacs.IntrmyAgt1BranchId;
//            txtIntrmyAgt1AcctId.Text = pacs.IntrmyAgt1AcctId;
//            txtIntrmyAgt1AcctTp.Text = pacs.IntrmyAgt1AcctTp;
//            txtLclInstrmPrtry.Text = pacs.LclInstrmPrtry;
//            txtSvcLvlPrtry.Text = pacs.SvcLvlPrtry;
//            ddlCtgyPurpPrtry.SelectedValue = pacs.CtgyPurpPrtry;
//            txtInstrId.Text = pacs.InstrId;
//            txtTxId.Text = pacs.TxId;
//            txtEndToEndId.Text = pacs.EndToEndId;
//            lblSettlementCurrency.Text = pacs.IntrBkSttlmCcy;
//            lblIntrBkSttlmAmt.Text = pacs.IntrBkSttlmAmt.ToString("0.00");
//            txtIntrBkSttlmDt.Text = pacs.IntrBkSttlmDt;
//            txtDbtrBICFI.Text = pacs.DbtrBICFI;
//            txtDbtrNm.Text = pacs.DbtrNm;
//            txtDbtrBranchId.Text = pacs.DbtrBranchId;
//            lblDbtrAcctId.Text = pacs.DbtrAcctId;
//            txtDbtrAcctTp.Text = pacs.DbtrAcctTp;
//            txtCdtrAgtBICFI.Text = pacs.CdtrAgtBICFI;
//            txtCdtrAgtBranchId.Text = pacs.CdtrAgtBranchId;
//            txtCdtrAgtAcctId.Text = pacs.CdtrAgtAcctId;
//            txtCdtrAgtAcctTp.Text = pacs.CdtrAgtAcctTp;
//            txtCdtrBICFI.Text = pacs.CdtrBICFI;
//            txtCdtrNm.Text = pacs.CdtrNm;
//            txtCdtrBranchId.Text = pacs.CdtrBranchId;
//            lblCdtrAcctId.Text = pacs.CdtrAcctId;
//            txtCdtrAcctTp.Text = pacs.CdtrAcctTp;
//            txtInstrInf.Text = pacs.InstrInf;
//            //txtPmntRsn.Text = pacs.PmntRsn;
//            LblReturnReason.Text = pacs.ReturnReason;
//            ChkNoCBS.Checked = pacs.NoCBS;
//            lblCBSResponse.Text = pacs.CBSResponse;
//        }
//        protected void btnSend_Click(object sender, EventArgs e)
//        {
//            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
//            RTGSImporter.Pacs009 pacs = new RTGSImporter.Pacs009();

//            pacs.PacsID =  Request.Params["OutwardID"];

//            pacs.FrBICFI = txtFrBICFI.Text;
//            pacs.ToBICFI = txtToBICFI.Text;
//            pacs.BizMsgIdr = txtBizMsgIdr.Text;
//            pacs.MsgDefIdr = txtMsgDefIdr.Text;
//            pacs.BizSvc = txtBizSvc.Text;
//            pacs.CreDt = txtCreDt.Text;
//            pacs.MsgId = txtMsgId.Text;
//            pacs.CreDtTm = txtCreDtTm.Text;
//            pacs.NbOfTxs = Int32.Parse(txtNbOfTxs.Text);

//            pacs.InstgAgtBICFI = txtInstgAgtBICFI.Text;
//            pacs.InstgAgtNm = txtInstgAgtNm.Text;
//            pacs.InstgAgtBranchId = txtInstgAgtBranchId.Text;

//            pacs.InstdAgtBICFI = txtInstdAgtBICFI.Text;
//            pacs.InstdAgtNm = txtInstdAgtNm.Text;
//            pacs.InstdAgtBranchId = txtInstdAgtBranchId.Text;

//            pacs.IntrmyAgt1BICFI = txtIntrmyAgt1BICFI.Text;
//            pacs.IntrmyAgt1Nm = txtIntrmyAgt1Nm.Text;
//            pacs.IntrmyAgt1BranchId = txtIntrmyAgt1BranchId.Text;
//            pacs.IntrmyAgt1AcctId = txtIntrmyAgt1AcctId.Text;
//            pacs.IntrmyAgt1AcctTp = txtIntrmyAgt1AcctTp.Text;

//            pacs.LclInstrmPrtry = txtLclInstrmPrtry.Text;
//            pacs.SvcLvlPrtry = txtSvcLvlPrtry.Text;
//            pacs.CtgyPurpPrtry = ddlCtgyPurpPrtry.SelectedValue;
//            pacs.InstrId = txtInstrId.Text;
//            pacs.TxId = txtTxId.Text;
//            pacs.EndToEndId = txtEndToEndId.Text;
//            pacs.IntrBkSttlmCcy = lblSettlementCurrency.Text;
//            pacs.IntrBkSttlmAmt = decimal.Parse(lblIntrBkSttlmAmt.Text);
//            pacs.IntrBkSttlmDt = txtIntrBkSttlmDt.Text;

//            pacs.DbtrBICFI = txtDbtrBICFI.Text;
//            pacs.DbtrNm = txtDbtrNm.Text;
//            pacs.DbtrBranchId = txtDbtrBranchId.Text;
//            pacs.DbtrAcctId = lblDbtrAcctId.Text;
//            pacs.DbtrAcctTp = txtDbtrAcctTp.Text;

//            pacs.CdtrAgtBICFI = txtCdtrAgtBICFI.Text;
//            pacs.CdtrAgtBranchId = txtCdtrAgtBranchId.Text;
//            pacs.CdtrAgtAcctId = txtCdtrAgtAcctId.Text;
//            pacs.CdtrAgtAcctTp = txtCdtrAgtAcctTp.Text;

//            pacs.CdtrBICFI = txtCdtrBICFI.Text;
//            pacs.CdtrNm = txtCdtrNm.Text;
//            pacs.CdtrBranchId = txtCdtrBranchId.Text;
//            pacs.CdtrAcctId = lblCdtrAcctId.Text;
//            pacs.CdtrAcctTp = txtCdtrAcctTp.Text;

//            pacs.InstrInf = txtInstrInf.Text;

//            pacs.PmntRsn = lblMsg.Text;

//            //pacs.PmntRsn = txtPmntRsn.Text;

//            pacs.Maker = Request.Cookies["UserName"].Value;
//            pacs.MakerIP = HttpContext.Current.Request.UserHostAddress;


//            db.UpdateOutward009(pacs);
//            Response.Redirect("../OutwardListMaker.aspx");

//        }

//        protected void btnDelete_Click(object sender, EventArgs e)
//        {
//            string OutwardID = Request.Params["OutwardID"];

//            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
//            db.DeleteOutward09(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
//            Response.Redirect("../OutwardListMaker.aspx");
//        }

//        protected void btnCancelTrans_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("../OutwardListMaker.aspx");
//        }
//    }
//}