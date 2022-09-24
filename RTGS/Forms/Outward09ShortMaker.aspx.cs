using FloraSoft;
using FMPS.BLL;
using RTGSImporter;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward09ShortMaker : System.Web.UI.Page
    {
        DropDownList drpdwnlst;
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (!Global.cancontinue)
                {
                    HttpContext.Current.Response.End();
                }
            }
            catch
            {
                HttpContext.Current.Response.End();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Cookies["RoleCD"].Value != "RTMK")
            {
                base.Response.Redirect("../AccessDenied.aspx");
            }
            if (!base.IsPostBack)
            {
                this.Banks();
                this.BindBranches(this.ddListReceivingBank.SelectedValue);
            }
            this.lblMsg.Text = "";
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.BindAcctNos();
            string text = base.Request.Params["InwardID"];
            if (text != null && text != "")
            {
                this.LoadData(text);
            }
            if (this.drpdwnlst != null)
            {
                this.drpdwnlst.Focus();
            }
        }

        private void LoadData(string InwardID)
        {
            TeamBlueDB teamBlueDB = new TeamBlueDB();
            Pacs009 singleInward = teamBlueDB.GetSingleInward09(InwardID);
            this.ddlCurrency.SelectedValue = singleInward.IntrBkSttlmCcy;
            this.txtAccountNo.Text = singleInward.CdtrAcctId;
            this.txtSettlmentAmount.Text = singleInward.IntrBkSttlmAmt.ToString();
            this.ddListReceivingBank.Text = singleInward.FrBankBIC;
            this.txtReceiverAccountNo.Text = singleInward.DbtrAcctId;
            this.txtReasonForPayment.Text = singleInward.InstrInf;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string text = "";
            if (base.Request.Params["InwardID"] != null && base.Request.Params["InwardID"] != "")
            {
                text = base.Request.Params["InwardID"];
            }
            if (this.ValidateForm())
            {
                BankSettingsDB bankSettingsDB = new BankSettingsDB();
                BankSettings bankSettings = bankSettingsDB.GetBankSettings();
                Pacs009 pacs = new Pacs009();
                string text2 = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                decimal num = decimal.Parse(this.txtSettlmentAmount.Text);
                CCYDB cCYDB = new CCYDB();
                decimal minLimit = cCYDB.GetMinLimit(this.ddlCurrency.SelectedValue, "pacs.009");
                if (num < minLimit)
                {
                    this.lblMsg.Text = "Sending amount is less then Minimum Limit";
                }
                else
                {
                    pacs.FrBICFI = bankSettings.BIC;
                    pacs.ToBICFI = "BBHOBDDHRTG";
                    pacs.MsgDefIdr = "pacs.009.001.04";
                    if (text != "")
                    {
                        pacs.BizSvc = "RTGS_RETN";
                    }
                    else
                    {
                        pacs.BizSvc = "RTGS_FICT";
                    }
                    pacs.CreDt = text2 + "Z";
                    pacs.CreDtTm = text2;
                    pacs.BtchBookg = "false";
                    pacs.NbOfTxs = 1;
                    pacs.TtlIntrBkSttlmAmt = num;
                    pacs.InstgAgtBICFI = bankSettings.BIC;
                    pacs.InstgAgtNm = bankSettings.BankName;
                    pacs.InstgAgtBranchId = base.Request.Cookies["RoutingNo"].Value;
                    pacs.InstdAgtBICFI = this.ddListReceivingBank.SelectedValue;
                    pacs.InstdAgtNm = this.ddListReceivingBank.SelectedValue;
                    pacs.LclInstrmPrtry = "RTGS_FICT";
                    pacs.SvcLvlPrtry = "98";
                    pacs.CtgyPurpPrtry = "1";
                    pacs.IntrBkSttlmCcy = this.ddlCurrency.SelectedValue;
                    pacs.IntrBkSttlmAmt = num;
                    pacs.IntrBkSttlmDt = DateTime.Today.ToString("yyyy-MM-dd");
                    pacs.DbtrBICFI = bankSettings.BIC;
                    pacs.DbtrNm = bankSettings.BIC;
                    pacs.DbtrBranchId = base.Request.Cookies["RoutingNo"].Value;
                    pacs.DbtrAcctId = this.txtAccountNo.Text;
                    pacs.DbtrAcctTp = "1";
                    pacs.CdtrBICFI = this.ddListReceivingBank.SelectedValue;
                    pacs.CdtrNm = this.ddListReceivingBank.SelectedValue;
                    pacs.CdtrBranchId = this.ddListBranch.SelectedValue;
                    pacs.CdtrAcctId = this.txtReceiverAccountNo.Text;
                    pacs.CdtrAcctTp = "1";
                    pacs.InstrInf = this.txtReasonForPayment.Text;
                    pacs.PmntRsn = text;
                    pacs.DeptId = int.Parse(base.Request.Cookies["DeptID"].Value);
                    pacs.Maker = base.Request.Cookies["UserName"].Value;
                    pacs.MakerIP = HttpContext.Current.Request.UserHostAddress;
                    pacs.BrnchCD = base.Request.Cookies["BranchCD"].Value;
                    pacs.NoCBS = this.ChkNoCBS.Checked;
                    TeamBlueDB teamBlueDB = new TeamBlueDB();
                    string str = teamBlueDB.InsertOutward009(pacs);
                    if (text != null && text != "")
                    {
                        teamBlueDB.ReturnInward09(text, int.Parse(base.Request.Cookies["DeptID"].Value), pacs.Maker, pacs.MakerIP);
                    }
                    base.Response.Redirect("Outward09LongMaker.aspx?OutwardID=" + str);
                }
            }
        }

        private bool ValidateForm()
        {
            CCYDB cCYDB = new CCYDB();
            decimal minLimit = cCYDB.GetMinLimit(this.ddlCurrency.SelectedValue, "pacs.009");
            decimal d = 0m;
            bool result = true;
            if (this.txtAccountNo.Text == "")
            {
                result = false;
            }
            if (this.txtSettlmentAmount.Text == "")
            {
                result = false;
            }
            try
            {
                d = decimal.Parse(this.txtSettlmentAmount.Text);
            }
            catch
            {
                result = false;
            }
            if (d < minLimit)
            {
                this.lblMsg.Text = "Sending amount is less then Minimum Limit";
                result = false;
            }
            if (d > new decimal(10000000000L))
            {
                this.lblMsg.Text = "Max 10000 crore";
                result = false;
            }
            if (this.txtReceiverAccountNo.Text == "")
            {
                result = false;
            }
            if (this.txtReasonForPayment.Text == "")
            {
                result = false;
            }
            return result;
        }

        private void Banks()
        {
            BanksDB banksDB = new BanksDB();
            this.ddListReceivingBank.DataSource = banksDB.GetSendBanks();
            this.ddListReceivingBank.DataBind();
        }

        private void BindBranches(string BIC)
        {
            BranchesDB branchesDB = new BranchesDB();
            this.ddListBranch.DataSource = branchesDB.GetBranchesByBIC(BIC);
            this.ddListBranch.DataBind();
            this.txtRoutingNo.Text = this.ddListBranch.SelectedValue;
        }

        private void BindAcctNos()
        {
            BankAccountsDB bankAccountsDB = new BankAccountsDB();
            string singleBankAccount = bankAccountsDB.GetSingleBankAccount(this.ddlCurrency.SelectedValue);
            string otherBankAccount = bankAccountsDB.GetOtherBankAccount(this.ddlCurrency.SelectedValue, this.ddListReceivingBank.SelectedValue);
            this.txtAccountNo.Text = singleBankAccount;
            this.txtReceiverAccountNo.Text = otherBankAccount;
        }

        protected void txtSettlmentAmount_txtChanged(object sender, EventArgs e)
        {
            NumberToWordConverter numberToWordConverter = new NumberToWordConverter();
            try
            {
                this.lblAmount.Text = numberToWordConverter.GetAmountInWords(this.txtSettlmentAmount.Text.Replace(",", ""));
            }
            catch
            {
            }
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("../OutwardListMaker.aspx");
        }

        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.drpdwnlst = (DropDownList)sender;
        }

        protected void ddListReceivingBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.drpdwnlst = (DropDownList)sender;
            this.BindBranches(this.ddListReceivingBank.SelectedValue);
        }

        protected void ddListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtRoutingNo.Text = this.ddListBranch.SelectedValue;
        }
    }
}

//        protected void Page_Init(object sender, EventArgs e)
//        {
//            try
//            {
//                if (!Global.cancontinue)
//                {
//                    HttpContext.Current.Response.End();
//                }
//            }
//            catch
//            {
//                HttpContext.Current.Response.End();
//            }
//        }
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Request.Cookies["RoleCD"].Value != "RTMK") 
//            {
//                Response.Redirect("../AccessDenied.aspx");
//            }
//            if (!IsPostBack)
//            {
//                Banks();
//                BindBranches(ddListReceivingBank.SelectedValue);
//            }
//            lblMsg.Text = "";
//        }
//        protected void Page_PreRender(object sender, EventArgs e)
//        {
//            BindAcctNos();
//            string InwardID = Request.Params["InwardID"];
//            if ((InwardID != null) && (InwardID != ""))
//            {
//                LoadData(InwardID);
//            }
//            if (drpdwnlst != null)
//            {
//                drpdwnlst.Focus();
//            }
//        }
//        private void LoadData(string InwardID)
//        {
//            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
//            RTGSImporter.Pacs009 pacs = db.GetSingleInward09(InwardID);

//            ddlCurrency.SelectedValue = pacs.IntrBkSttlmCcy;
//            txtAccountNo.Text = pacs.CdtrAcctId;

//            txtSettlmentAmount.Text = pacs.IntrBkSttlmAmt.ToString();
//            ddListReceivingBank.Text = pacs.FrBankBIC;
//            txtReceiverAccountNo.Text = pacs.DbtrAcctId;
//            txtReasonForPayment.Text = pacs.InstrInf;
//        }
//        protected void btnSave_Click(object sender, EventArgs e)
//        {
//            string InwardID ="";
//            if ((Request.Params["InwardID"] != null) && (Request.Params["InwardID"] != ""))
//            {
//                InwardID = Request.Params["InwardID"];
//            }
//            if (!ValidateForm())
//                return;
//            FloraSoft.BankSettingsDB db0 = new FloraSoft.BankSettingsDB();
//            FloraSoft.BankSettings bs = db0.GetBankSettings();

//            RTGSImporter.Pacs009 pacs = new RTGSImporter.Pacs009();

//            string Credt = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
//            decimal sttlmmtAmt = Decimal.Parse(txtSettlmentAmount.Text); 
            
//            CCYDB dbccy = new CCYDB();
//            decimal minlimit = dbccy.GetMinLimit(ddlCurrency.SelectedValue, "pacs.009");

//            if (sttlmmtAmt < minlimit)
//            {
//                lblMsg.Text = "Sending amount is less then Minimum Limit";
//                return;
//            }

//            //pacs.PacsID = ;
//            //pacs.SLNo = ;
//            //pacs.DetectTime = ;
//            pacs.FrBICFI = bs.BIC;
//            pacs.ToBICFI = "BBHOBDDHRTG";

//            //pacs.BizMsgIdr = ;
//            pacs.MsgDefIdr = "pacs.009.001.04";
//            if (InwardID != "")
//            {
//                pacs.BizSvc = "RTGS_RETN";
//            }
//            else
//            {
//                pacs.BizSvc = "RTGS_FICT";
//            }
//            pacs.CreDt = Credt + "Z";
//            //pacs.MsgId = ;
//            pacs.CreDtTm = Credt;
//            pacs.BtchBookg = "false";
//            pacs.NbOfTxs = 1;
//            pacs.TtlIntrBkSttlmAmt = sttlmmtAmt;

//            pacs.InstgAgtBICFI = bs.BIC;
//            pacs.InstgAgtNm = bs.BankName;
//            pacs.InstgAgtBranchId = Request.Cookies["RoutingNo"].Value;

//            pacs.InstdAgtBICFI = ddListReceivingBank.SelectedValue;
//            pacs.InstdAgtNm = ddListReceivingBank.SelectedValue;
//            //pacs.InstdAgtBranchId = ;

//            //pacs.IntrmyAgt1BICFI = ;
//            //pacs.IntrmyAgt1Nm = ;
//            //pacs.IntrmyAgt1BranchId = ;
//            //pacs.IntrmyAgt1AcctId = ;
//            //pacs.IntrmyAgt1AcctTp = ;

//            pacs.LclInstrmPrtry = "RTGS_FICT";
//            pacs.SvcLvlPrtry = "98";
//            pacs.CtgyPurpPrtry = "1";
//            //pacs.InstrId = "MT103/006";
//            //pacs.TxId = "202-002-SHS";
//            //pacs.EndToEndId = "MT103/001";
//            pacs.IntrBkSttlmCcy = ddlCurrency.SelectedValue;
//            pacs.IntrBkSttlmAmt = sttlmmtAmt;
//            pacs.IntrBkSttlmDt = System.DateTime.Today.ToString("yyyy-MM-dd");

//            pacs.DbtrBICFI = bs.BIC;
//            pacs.DbtrNm = bs.BIC;
//            pacs.DbtrBranchId = Request.Cookies["RoutingNo"].Value;
//            pacs.DbtrAcctId = txtAccountNo.Text;
//            pacs.DbtrAcctTp = "1";

//            //pacs.CdtrAgtBICFI = ;
//            //pacs.CdtrAgtBranchId = ;
//            //pacs.CdtrAgtAcctId = ;
//            //pacs.CdtrAgtAcctTp = ;

//            pacs.CdtrBICFI = ddListReceivingBank.SelectedValue;
//            pacs.CdtrNm = ddListReceivingBank.SelectedValue;
//            pacs.CdtrBranchId = ddListBranch.SelectedValue;
//            pacs.CdtrAcctId = txtReceiverAccountNo.Text;
//            pacs.CdtrAcctTp = "1";

//            pacs.InstrInf = txtReasonForPayment.Text;
//            pacs.PmntRsn = InwardID;
//            pacs.DeptId = Int32.Parse(Request.Cookies["DeptID"].Value);
//            pacs.Maker = Request.Cookies["UserName"].Value;
//            //pacs.MakeTime = ;
//            pacs.MakerIP = HttpContext.Current.Request.UserHostAddress;

//            pacs.BrnchCD = Request.Cookies["BranchCD"].Value;
//            pacs.NoCBS = ChkNoCBS.Checked;
//            //pacs.Checker = ;
//            //pacs.CheckTime = ;
//            //pacs.CheckerIP = ;
//            //pacs.Admin = ;
//            //pacs.AdminTime = ;
//            //pacs.AdminIP = ;
//            //pacs.DeletedBy = ;
//            //pacs.DeleteTime = ;
//            //pacs.CBSResponse = ;
//            //pacs.CBSTime = ;
//            //pacs.StatusID = ;

//            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
//            string OutwardID = db.InsertOutward009(pacs);

//            if ((InwardID != null) && (InwardID != ""))
//            {
//                db.ReturnInward09(InwardID, Int32.Parse(Request.Cookies["DeptID"].Value), pacs.Maker, pacs.MakerIP);
//            }

//            Response.Redirect("Outward09LongMaker.aspx?OutwardID=" + OutwardID);
//        }
//        private bool ValidateForm()
//        {
//            CCYDB dbccy = new CCYDB();
//            decimal minlimit = dbccy.GetMinLimit(ddlCurrency.SelectedValue, "pacs.009");

//            Decimal amt = 0;
//            bool ret = true;
//            if (txtAccountNo.Text == "")
//                ret = false;
//            if (txtSettlmentAmount.Text == "")
//                ret = false;
//            try
//            {
//                amt = Decimal.Parse(txtSettlmentAmount.Text);
//            }
//            catch
//            {
//                ret = false;
//            }
//            if (amt < minlimit)
//            {
//                lblMsg.Text = "Sending amount is less then Minimum Limit";
//                ret = false;
//            }
//            if (amt > 10000000000)
//            {
//                lblMsg.Text = "Max 10000 crore";
//                ret = false;
//            }

//            if (txtReceiverAccountNo.Text == "")
//                ret = false;
//            if (txtReasonForPayment.Text == "")
//                ret = false;

//            return ret;
//        }
//        private void Banks()
//        {
//            BanksDB bankDB = new BanksDB();
//            ddListReceivingBank.DataSource = bankDB.GetSendBanks();
//            ddListReceivingBank.DataBind();
//        }
//        private void BindBranches(string BIC)
//        {
//            BranchesDB db = new BranchesDB();
//            ddListBranch.DataSource = db.GetBranchesByBIC(BIC);
//            ddListBranch.DataBind();
//            txtRoutingNo.Text = ddListBranch.SelectedValue;
//        }
//        private void BindAcctNos()
//        {
//            BankAccountsDB db = new BankAccountsDB();
//            string SendingActNo = db.GetSingleBankAccount(ddlCurrency.SelectedValue);
//            string RecievingActNo = db.GetOtherBankAccount(ddlCurrency.SelectedValue, ddListReceivingBank.SelectedValue);

//            txtAccountNo.Text = SendingActNo;
//            txtReceiverAccountNo.Text = RecievingActNo; 
//        }

//        protected void txtSettlmentAmount_txtChanged(object sender, EventArgs e)
//        {
//            FMPS.BLL.NumberToWordConverter conv = new FMPS.BLL.NumberToWordConverter();
//            try
//            {
//                lblAmount.Text = conv.GetAmountInWords(txtSettlmentAmount.Text.Replace(",", ""));
//            }
//            catch { }
//        }
//        protected void btnCancelTrans_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("../OutwardListMaker.aspx");
//        }

//        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            drpdwnlst = ((DropDownList)sender);
//        }

//        protected void ddListReceivingBank_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            drpdwnlst = ((DropDownList)sender);
//            BindBranches(ddListReceivingBank.SelectedValue);
//        }

//        protected void ddListBranch_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            txtRoutingNo.Text = ddListBranch.SelectedValue;
//        }
//    }
//}