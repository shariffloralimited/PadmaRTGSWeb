using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RTGS
{
    public partial class _Default : Page
    {
        public string CCYBank;
        public string CCYBranch;
        public DataTable CCYList;
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
//            if (Request.Cookies["ChangePwdNow"].Value.ToUpper() == "TRUE")
//            {
//                Response.Redirect("ChangePassword.aspx");
//            }
//        }
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            CCYDB db = new CCYDB();
//            CCYList = db.GetCCYList();
//            if (!Page.IsPostBack)
//            {
//                string RoleCD = Request.Cookies["RoleCD"].Value;
//                if ((RoleCD == "RTMK") || (RoleCD == "RTCK") || (RoleCD == "RTAU"))
//                {
//                    Response.Redirect("BranchMenu.aspx");
//                }
//                //if (RoleCD == "RTRV")
//                //{
//                //    Response.Redirect("ReportViewerMenu.aspx");
//                //}

//                if ((RoleCD == "RTRV") && (RoleCD != "RTSA"))
//                {
//                    Response.Redirect("ReportViewerMenu.aspx");
//                }

//                if ((RoleCD != "RTAD") && (RoleCD != "RTFM"))
//                {
//                    Response.Redirect("AccessDenied.aspx");
//                }
//                BindCCYLists();

//            }
//            CCYBank = BankCCY.SelectedItem.Text;
//            CCYBranch = BranchCcy.SelectedItem.Text;
//        }
//        private void BindCCYLists()
//        {
//            BankCCY.DataSource = CCYList;
//            BankCCY.DataBind();
//            BranchCcy.DataSource = CCYList;
//            BranchCcy.DataBind();
//        }
//    }
//}

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
            if (base.Request.Cookies["ChangePwdNow"].Value.ToUpper() == "TRUE")
            {
                base.Response.Redirect("ChangePassword.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CCYDB cCYDB = new CCYDB();
            this.CCYList = cCYDB.GetCCYList();
            if (!this.Page.IsPostBack)
            {
                string value = base.Request.Cookies["RoleCD"].Value;
                if (value == "RTMK" || value == "RTCK" || value == "RTAU")
                {
                    base.Response.Redirect("BranchMenu.aspx");
                }
                if (value == "RTRV" && value != "RTSA")
                {
                    base.Response.Redirect("ReportViewerMenu.aspx");
                }
                if (value != "RTAD" && value != "RTFM")
                {
                    base.Response.Redirect("AccessDenied.aspx");
                }
                this.BindCCYLists();
            }
            this.CCYBank = this.BankCCY.SelectedItem.Text;
            this.CCYBranch = this.BranchCcy.SelectedItem.Text;
        }

        private void BindCCYLists()
        {
            this.BankCCY.DataSource = this.CCYList;
            this.BankCCY.DataBind();
            this.BranchCcy.DataSource = this.CCYList;
            this.BranchCcy.DataBind();
        }
    }
}
