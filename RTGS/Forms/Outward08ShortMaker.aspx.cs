using FloraSoft;
using FMPS.BLL;
using RTGS.DAC;
using RTGS.RTGSWS;
using RTGSImporter;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward08ShortMaker : System.Web.UI.Page
    {
        protected string ImgName = "";
        public string AccountNo = "";
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
            BankSettingsDB bankSettingsDB = new BankSettingsDB();
            BankSettings bankSettings = bankSettingsDB.GetBankSettings();
            if (bankSettings.SkipCBS)
            {
                this.btnGetInfo.Visible = false;
            }
            else
            {
                this.btnGetInfo.Visible = true;
            }
            if (base.Request.Cookies["RoleCD"].Value != "RTMK")
            {
                base.Response.Redirect("../AccessDenied.aspx");
            }
            if (!base.IsPostBack)
            {
                this.CustomDutyPanel.Visible = false;
                this.UnstructDiv.Visible = true;
            }
            if (!base.IsPostBack)
            {
                this.BindTransType();
                this.BindSendBranch();
                this.Banks();
                this.BindBranches(this.ddListReceivingBank.SelectedValue);
            }
            this.lblMsg.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BankSettingsDB bankSettingsDB = new BankSettingsDB();
            BankSettings bankSettings = bankSettingsDB.GetBankSettings();
            if (this.Page.IsValid)
            {
                if (this.ddlCtgyPurpPrtry.SelectedValue != "031" && this.ddlCtgyPurpPrtry.SelectedItem.Value != "041" && this.ddlCtgyPurpPrtry.SelectedItem.Value != "040")
                {
                    CCYDB cCYDB = new CCYDB();
                    decimal minLimit = cCYDB.GetMinLimit(this.ddlCurrency.SelectedValue, "pacs.008");
                    decimal d = decimal.Parse(this.txtSettlmentAmount.Text);
                    if (d < minLimit)
                    {
                        this.lblMsg.Text = "Sending amount is less then Minimum Limit";
                        return;
                    }
                    if (d > new decimal(100000000000L))
                    {
                        this.lblMsg.Text = "Maximum Amount: 1000 Crore.";
                        return;
                    }
                }
                else if (!this.ChkChargeWaived.Checked)
                {
                    this.lblMsg.Text = "Charges must be waived for Govt Payment, Custom Duty Payment, TAX Payment And VAT Payment";
                    return;
                }
                Pacs008 pacs = new Pacs008();
                string text = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                pacs.FrBICFI = bankSettings.BIC;
                pacs.ToBICFI = "BBHOBDDHRTG";
                pacs.MsgDefIdr = "pacs.008.001.04";
                pacs.BizSvc = "RTGS";
                pacs.CreDt = text + "Z";
                pacs.CreDtTm = text;
                pacs.BtchBookg = "false";
                pacs.NbOfTxs = 1;
                pacs.ClrChanl = "RTGS";
                pacs.SvcLvlPrtry = 75;
                pacs.LclInstrmPrtry = "RTGS_SSCT";
                pacs.CtgyPurpPrtry = this.ddlCtgyPurpPrtry.SelectedValue;
                pacs.Ccy = this.ddlCurrency.SelectedValue;
                pacs.IntrBkSttlmAmt = decimal.Parse(this.txtSettlmentAmount.Text);
                pacs.IntrBkSttlmDt = DateTime.Today.ToString("yyyy-MM-dd");
                pacs.ChrgBr = this.radioChargeBearer1.SelectedValue;
                pacs.InstgAgtBICFI = bankSettings.BIC;
                pacs.InstgAgtNm = bankSettings.BIC;
                pacs.InstgAgtBranchId = this.ddlSendBranch.SelectedValue;
                pacs.InstdAgtBICFI = this.ddListReceivingBank.SelectedValue;
                pacs.InstdAgtNm = this.ddListReceivingBank.SelectedValue;
                pacs.InstdAgtBranchId = this.ddListBranch.SelectedValue;
                pacs.DbtrNm = this.txtAccountName.Text;
                pacs.DbtrAcctOthrId = this.txtAccountNo.Text;
                pacs.DbtrAgtBICFI = bankSettings.BIC;
                pacs.DbtrAgtNm = bankSettings.BIC;
                pacs.DbtrAgtBranchId = this.ddlSendBranch.SelectedValue;
                pacs.CdtrAgtBICFI = this.ddListReceivingBank.SelectedValue;
                pacs.CdtrAgtNm = this.ddListReceivingBank.SelectedValue;
                pacs.CdtrAgtBranchId = this.ddListBranch.SelectedValue;
                pacs.CdtrNm = this.txtReceiverName.Text;
                pacs.CdtrAcctOthrId = this.txtReceiverAccountNo.Text;
                if (pacs.CtgyPurpPrtry == "041")
                {
                    pacs.Ustrd = string.Concat(new string[]
					{
						this.txtCustomOfficeCD.Text,
						" ",
						this.txtRegYr.Text,
						" ",
						this.txRegNumber.Text,
						" ",
						this.txtDeclarantCD.Text,
						" ",
						this.txtCustomerMobile.Text
					});
                }
                else
                {
                    pacs.Ustrd = this.txtReasonForPayment.Text;
                }
                pacs.DeptId = int.Parse(base.Request.Cookies["DeptID"].Value);
                pacs.Maker = base.Request.Cookies["UserName"].Value;
                pacs.MakerIP = HttpContext.Current.Request.UserHostAddress;
                pacs.BrnchCD = base.Request.Cookies["BranchCD"].Value;
                pacs.ChargeWaived = this.ChkChargeWaived.Checked;
                TeamRedDB teamRedDB = new TeamRedDB();
                string str = teamRedDB.InsertOutward008(pacs);
                base.Response.Redirect("Outward08LongMaker.aspx?OutwardID=" + str);
            }
        }

        protected void ddListReceivingBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindBranches(this.ddListReceivingBank.SelectedValue);
        }

        protected void ddListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtRoutingNo.Text = this.ddListBranch.SelectedValue;
        }

        private void Banks()
        {
            BanksDB banksDB = new BanksDB();
            this.ddListReceivingBank.DataSource = banksDB.GetSendBanks();
            this.ddListReceivingBank.DataBind();
        }

        private void BindSendBranch()
        {
            BranchesDB branchesDB = new BranchesDB();
            this.ddlSendBranch.DataSource = branchesDB.GetSendBranches();
            this.ddlSendBranch.DataBind();
            if (base.Request.Cookies["AllBranch"].Value != "False")
            {
                this.ddlSendBranch.SelectedValue = "0";
            }
            else
            {
                this.ddlSendBranch.SelectedValue = base.Request.Cookies["RoutingNo"].Value;
                this.ddlSendBranch.Enabled = false;
            }
        }

        private void BindBranches(string BIC)
        {
            BranchesDB branchesDB = new BranchesDB();
            this.ddListBranch.DataSource = branchesDB.GetBranchesByBIC(BIC);
            this.ddListBranch.DataBind();
            this.txtRoutingNo.Text = this.ddListBranch.SelectedValue;
        }

        protected void btnGetInfo_Click(object sender, EventArgs e)
        {
            this.btnSend.Visible = false;
            //this.Sigimages.ImageUrl = "";
            if (this.txtAccountNo.Text == "")
            {
                this.lblMsg.Text = "Please Enter Senders Account Number.";
            }
            else
            {
                this.AccountNo = this.txtAccountNo.Text;
                if (this.txtSettlmentAmount.Text == "")
                {
                    this.lblMsg.Text = "Please Enter Sending Amount";
                }
                else
                {
                    Service1 service = new Service1();
                    string accountInfo = service.GetAccountInfo(this.txtAccountNo.Text);
                    this.lblAccountInfo.Text = accountInfo.Replace("|", "<BR/>");
                    if (!accountInfo.StartsWith("No records were found"))
                    {
                        string[] array = accountInfo.Split(new char[]
						{
							'|'
						});
                        this.txtAccountName.Text = array[0];
                        if (array.Length < 8)
                        {
                            this.lblMsg.Text = "CBS Response was not in correct format";
                        }
                        else if (array[5].Trim() != "ACTIVE")
                        {
                            this.lblMsg.Text = "Account not ACTIVE.";
                        }
                        else if (array[7].Trim() != this.ddlCurrency.SelectedValue)
                        {
                            this.lblMsg.Text = "Account and Transaction Currency mismatch.";
                        }
                        else if (array[6].Trim() == "")
                        {
                            this.lblMsg.Text = "Account Balance not found.";
                        }
                        else
                        {
                            decimal d = 0m;
                            decimal num = 0m;
                            try
                            {
                                d = decimal.Parse(array[6].Trim());
                            }
                            catch
                            {
                                this.lblMsg.Text = "Invalid Account Balance.";
                                return;
                            }
                            try
                            {
                                num = decimal.Parse(this.txtSettlmentAmount.Text);
                            }
                            catch
                            {
                                this.lblMsg.Text = "Invalid Sending Amount.";
                                return;
                            }
                            OutwardDB outwardDB = new OutwardDB();
                            num += outwardDB.GetWaitingAmount(this.txtAccountNo.Text.Trim());
                            if (d < num)
                            {
                                this.lblMsg.Text = "Insufficient Balance";
                            }
                            else
                            {
                                this.btnSend.Visible = true;
                                //this.BindSignatureImage(this.base64string);
                            }
                        }
                    }
                }
            }
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

        private void BindTransType()
        {
            TransCodeDB transCodeDB = new TransCodeDB();
            this.ddlCtgyPurpPrtry.DataSource = transCodeDB.GetTransCode("Pacs08");
            this.ddlCtgyPurpPrtry.DataBind();
        }

        protected void ddlCtgyPurpPrtry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlCtgyPurpPrtry.SelectedValue == "041")
            {
                this.CustomDutyPanel.Visible = true;
                this.UnstructDiv.Visible = false;
                this.ddListReceivingBank.SelectedValue = ConfigurationManager.AppSettings["CustomDutyReceivingBankBIC"];
                this.BindBranches(this.ddListReceivingBank.SelectedValue);
                this.ddListBranch.SelectedValue = ConfigurationManager.AppSettings["CustomDutyReceivingBranch"];
                this.txtReceiverName.Text = ConfigurationManager.AppSettings["CustomDutyReceiverName"];
                this.txtReceiverAccountNo.Text = ConfigurationManager.AppSettings["CustomDutyReceiverAccountNo"];
            }
            else
            {
                this.CustomDutyPanel.Visible = false;
                this.UnstructDiv.Visible = true;
                this.ddListReceivingBank.SelectedIndex = 0;
                this.BindBranches(this.ddListReceivingBank.SelectedValue);
                this.txtReceiverName.Text = "";
                this.txtReceiverAccountNo.Text = "";
            }
        }

        //protected void BindSignatureImage(string base64string)
        //{
        //    this.AccountNo = this.txtAccountNo.Text.Trim();
        //    RTGSWS.Service1 service = new Service1();
        //    try
        //    {
        //        string path = ConfigurationManager.AppSettings["ImageUrl"] + service.GetSignature(this.AccountNo.Trim());
        //        byte[] inArray = Convert.FromBase64String(this.Getbase64Image(path));
        //        this.Sigimages.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(inArray);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.lblMsg.Text = ex.Message;
        //    }
        //}

        public string Getbase64Image(string Path)
        {
            byte[] inArray = File.ReadAllBytes(Path);
            return Convert.ToBase64String(inArray);
        }

        protected string PhotoBase64ImgSrc(string fileNameandPath)
        {
            byte[] inArray = File.ReadAllBytes(fileNameandPath);
            string arg = Convert.ToBase64String(inArray);
            return string.Format("data:image/gif;base64,{0}", arg);
        }
        public string base64string { get; set; }
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
//            FloraSoft.BankSettingsDB db0 = new FloraSoft.BankSettingsDB();
//            FloraSoft.BankSettings bs = db0.GetBankSettings();

//            if (bs.SkipCBS == true)
//            {
//                btnGetInfo.Visible = false;
//            }
//            else
//            {
//                btnGetInfo.Visible = true;
//            }

//            if (Request.Cookies["RoleCD"].Value != "RTMK")
//            {
//                Response.Redirect("../AccessDenied.aspx");
//            }

//            if (!IsPostBack)
//            {
//                CustomDutyPanel.Visible = false;
//                UnstructDiv.Visible = true;
//            }

//            if (!IsPostBack)
//            {
//                BindTransType();
//                BindSendBranch();
//                Banks();
//                BindBranches(ddListReceivingBank.SelectedValue);
//            }

//            lblMsg.Text = "";
//        }

//        protected void btnSave_Click(object sender, EventArgs e)
//        {
//            FloraSoft.BankSettingsDB db0 = new FloraSoft.BankSettingsDB();
//            FloraSoft.BankSettings bs = db0.GetBankSettings();

//            if (!Page.IsValid)
//            {
//                return;
//            }
//            if ((ddlCtgyPurpPrtry.SelectedValue != "031") && (ddlCtgyPurpPrtry.SelectedItem.Value != "041") && (ddlCtgyPurpPrtry.SelectedItem.Value != "040"))
//            {
//                CCYDB dbccy = new CCYDB();
//                decimal minlimit = dbccy.GetMinLimit(ddlCurrency.SelectedValue, "pacs.008");
//                decimal sttlmmtAmt = Decimal.Parse(txtSettlmentAmount.Text);
//                if (sttlmmtAmt < minlimit)
//                {
//                    lblMsg.Text = "Sending amount is less then Minimum Limit";
//                    return;
//                }

//                if (sttlmmtAmt > (decimal)100000000000.00)
//                {
//                    lblMsg.Text = "Maximum Amount: 1000 Crore.";
//                    return;
//                }
//            }
//            else
//            {
//                if (!ChkChargeWaived.Checked)
//                {
//                    lblMsg.Text = "Charges must be waived for Govt Payment, Custom Duty Payment, TAX Payment And VAT Payment";
//                    return;
//                }
//            }


//            RTGSImporter.Pacs008 pacs = new RTGSImporter.Pacs008();
//            string Credt = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

//            pacs.FrBICFI = bs.BIC;
//            pacs.ToBICFI = "BBHOBDDHRTG";
//            pacs.MsgDefIdr = "pacs.008.001.04";
//            pacs.BizSvc = "RTGS";
//            pacs.CreDt = Credt + "Z";
//            pacs.CreDtTm = Credt;
//            pacs.BtchBookg = "false";
//            pacs.NbOfTxs = 1;
//            pacs.ClrChanl = "RTGS";
//            pacs.SvcLvlPrtry = 75;
//            pacs.LclInstrmPrtry = "RTGS_SSCT";
//            pacs.CtgyPurpPrtry = ddlCtgyPurpPrtry.SelectedValue;
//            pacs.Ccy = ddlCurrency.SelectedValue;
//            pacs.IntrBkSttlmAmt = Decimal.Parse(txtSettlmentAmount.Text);
//            pacs.IntrBkSttlmDt = System.DateTime.Today.ToString("yyyy-MM-dd");
//            pacs.ChrgBr = radioChargeBearer1.SelectedValue;
//            pacs.InstgAgtBICFI = bs.BIC;
//            pacs.InstgAgtNm = bs.BIC;
//            pacs.InstgAgtBranchId = ddlSendBranch.SelectedValue;
//            pacs.InstdAgtBICFI = ddListReceivingBank.SelectedValue;
//            pacs.InstdAgtNm = ddListReceivingBank.SelectedValue;
//            pacs.InstdAgtBranchId = ddListBranch.SelectedValue;



//            pacs.DbtrNm = txtAccountName.Text;

//            pacs.DbtrAcctOthrId = txtAccountNo.Text; //.Replace(".","");
//            pacs.DbtrAgtBICFI = bs.BIC;
//            pacs.DbtrAgtNm = bs.BIC;
//            pacs.DbtrAgtBranchId = ddlSendBranch.SelectedValue;
//            pacs.CdtrAgtBICFI = ddListReceivingBank.SelectedValue;
//            pacs.CdtrAgtNm = ddListReceivingBank.SelectedValue;
//            pacs.CdtrAgtBranchId = ddListBranch.SelectedValue;
//            pacs.CdtrNm = txtReceiverName.Text;
//            pacs.CdtrAcctOthrId = txtReceiverAccountNo.Text;
//            if (pacs.CtgyPurpPrtry == "041")
//            {
//                pacs.Ustrd = txtCustomOfficeCD.Text + " " + txtRegYr.Text + " " + txRegNumber.Text + " " + txtDeclarantCD.Text + " " + txtCustomerMobile.Text;
//            }
//            else
//            {
//                pacs.Ustrd = txtReasonForPayment.Text;
//            }
//            pacs.DeptId = Int32.Parse(Request.Cookies["DeptID"].Value);
//            pacs.Maker = Request.Cookies["UserName"].Value;
//            pacs.MakerIP = HttpContext.Current.Request.UserHostAddress;
//            pacs.BrnchCD = Request.Cookies["BranchCD"].Value;
//            pacs.ChargeWaived = ChkChargeWaived.Checked;

//            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
//            string OutwardID = db.InsertOutward008(pacs);

//            Response.Redirect("Outward08LongMaker.aspx?OutwardID=" + OutwardID);
//        }

//        protected void ddListReceivingBank_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            BindBranches(ddListReceivingBank.SelectedValue);

//        }

//        protected void ddListBranch_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            txtRoutingNo.Text = ddListBranch.SelectedValue;
//        }

//        private void Banks()
//        {
//            BanksDB bankDB = new BanksDB();
//            ddListReceivingBank.DataSource = bankDB.GetSendBanks();
//            ddListReceivingBank.DataBind();
//        }

//        private void BindSendBranch()
//        {
//            BranchesDB db = new BranchesDB();
//            ddlSendBranch.DataSource = db.GetSendBranches();
//            ddlSendBranch.DataBind();
//            if (Request.Cookies["AllBranch"].Value != "False")
//            {
//                ddlSendBranch.SelectedValue = "0";
//            }
//            else
//            {
//                ddlSendBranch.SelectedValue = Request.Cookies["RoutingNo"].Value;
//                ddlSendBranch.Enabled = false;
//            }
//        }

//        private void BindBranches(string BIC)
//        {
//            BranchesDB db = new BranchesDB();
//            ddListBranch.DataSource = db.GetBranchesByBIC(BIC);
//            ddListBranch.DataBind();
//            txtRoutingNo.Text = ddListBranch.SelectedValue;
//        }

//        protected void btnGetInfo_Click(object sender, EventArgs e)
//        {
//            btnSend.Visible = false;
//            Sigimages.ImageUrl = "";
//            if (txtAccountNo.Text == "")
//            {
//                lblMsg.Text = "Please Enter Senders Account Number.";
//                return;
//            }
//            AccountNo = txtAccountNo.Text;
//            if (txtSettlmentAmount.Text == "")
//            {
//                lblMsg.Text = "Please Enter Sending Amount";
//                return;
//            }

//            RTGSWS.Service2 srv = new RTGSWS.Service2();

//            string a = srv.GetAccountInfo(txtAccountNo.Text);
//            lblAccountInfo.Text = a.Replace("|", "<BR/>");
//            if (a.StartsWith("No records were found"))
//            {
//                return;
//            }
//            string[] accountinfo = a.Split('|');


//            txtAccountName.Text = accountinfo[0];
//            if (accountinfo.Length < 8)
//            {
//                lblMsg.Text = "CBS Response was not in correct format";
//                return;
//            }

//            if (accountinfo[5].Trim() != "ACTIVE")
//            {
//                lblMsg.Text = "Account not ACTIVE.";
//                return;
//            }

//            if (accountinfo[7].Trim() != ddlCurrency.SelectedValue)
//            {
//                lblMsg.Text = "Account and Transaction Currency mismatch.";
//                return;
//            }

//            if (accountinfo[6].Trim() == "")
//            {
//                lblMsg.Text = "Account Balance not found.";
//                return;
//            }

//            decimal avialablebal = 0;
//            decimal sendingamount = 0;
//            try
//            {
//                avialablebal = decimal.Parse(accountinfo[6].Trim());
//            }
//            catch
//            {
//                lblMsg.Text = "Invalid Account Balance.";
//                return;
//            }


//            try
//            {
//                sendingamount = decimal.Parse(txtSettlmentAmount.Text);
//            }
//            catch
//            {
//                lblMsg.Text = "Invalid Sending Amount.";
//                return;
//            }
//            DAC.OutwardDB db = new DAC.OutwardDB();
//            sendingamount = sendingamount + db.GetWaitingAmount(txtAccountNo.Text.Trim());

//            if (avialablebal < sendingamount)
//            {
//                lblMsg.Text = "Insufficient Balance";
//                return;
//            }

//            btnSend.Visible = true;
//            BindSignatureImage(base64string);
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
//        private void BindTransType()
//        {
//            TransCodeDB db = new TransCodeDB();
//            ddlCtgyPurpPrtry.DataSource = db.GetTransCode("Pacs08");
//            ddlCtgyPurpPrtry.DataBind();
//        }

//        protected void ddlCtgyPurpPrtry_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (ddlCtgyPurpPrtry.SelectedValue == "041")
//            {
//                CustomDutyPanel.Visible = true;
//                UnstructDiv.Visible = false;
//                ddListReceivingBank.SelectedValue = ConfigurationManager.AppSettings["CustomDutyReceivingBankBIC"];
//                BindBranches(ddListReceivingBank.SelectedValue);
//                ddListBranch.SelectedValue = ConfigurationManager.AppSettings["CustomDutyReceivingBranch"];
//                txtReceiverName.Text = ConfigurationManager.AppSettings["CustomDutyReceiverName"];
//                txtReceiverAccountNo.Text = ConfigurationManager.AppSettings["CustomDutyReceiverAccountNo"];
//            }
//            else
//            {
//                CustomDutyPanel.Visible = false;
//                UnstructDiv.Visible = true;
//                ddListReceivingBank.SelectedIndex = 0;
//                BindBranches(ddListReceivingBank.SelectedValue);
//                txtReceiverName.Text = "";
//                txtReceiverAccountNo.Text = "";
//            }

//        }
//        protected void BindSignatureImage(string base64string)
//        {
//            //lbl_images.Text = "";
            
//            AccountNo = txtAccountNo.Text.Trim();

          
//            RTGSWS.Service2 svc = new RTGSWS.Service2();


//            try
//            {
//                //string photoId = "\\\\192.168.200.11\\signatures\\" +svc.GetSignature(AccountNo);
//                //string photoId = "\\\\198.168.200.104\\jboss\\server\\default\\deploy\\BrowserWeb.war\\im.images\\signatures\\" + svc.GetSignature(AccountNo);
//                //string photoId = ConfigurationManager.AppSettings["ImageUrl"] + svc.GetSignature(AccountNo.Trim());
//              // string photoId = "\\\\192.168.0.133\\Signatures\\"+svc.GetSignature(AccountNo);
//                string photoId = "E:\\Signature\\" + svc.GetSignature(AccountNo);

//                byte[] bytes = Convert.FromBase64String(Getbase64Image(photoId));

//                Sigimages.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);


//                // \\198.168.200.104\jboss\server\default\deploy\BrowserWeb.war\im.images\signatures\"
//             //    \\198.168.200.104\jboss\server\default\deploy\BrowserWeb.war\im.images\signatures\201407151127901449.jpg
//                //lbl_images.Text += "<img src='" + Getbase64Image(photoId) + "'height='150px' width='250px' alt='photo' />";
//            }
//            catch (Exception ex)
//            {
//                lblMsg.Text = ex.Message;
               
//            }


//        }

//        public string Getbase64Image(string Path)
//        {
//            byte[] imageArray = System.IO.File.ReadAllBytes(Path);
//            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
//            return base64ImageRepresentation;
//        }
//        protected string PhotoBase64ImgSrc(string fileNameandPath)
//        {
//            byte[] byteArray = File.ReadAllBytes(fileNameandPath);
//            string base64 = Convert.ToBase64String(byteArray);

//            return string.Format("data:image/gif;base64,{0}", base64);
//        }



//        public string base64string { get; set; }
//    }
//}