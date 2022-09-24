using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RTGS
{
    public partial class DeptDefault : Page
    {
        public string CCYBank;
        public string CCYBranch;
        public DataTable CCYList;
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
            CCYDB db = new CCYDB();
            CCYList = db.GetCCYList();
            if (!Page.IsPostBack)
            {
                string RoleCD = Request.Cookies["RoleCD"].Value;
                if ((RoleCD == "RTMK") || (RoleCD == "RTCK") || (RoleCD == "RTAU"))
                {
                    Response.Redirect("BranchMenu.aspx");
                }
                //if (RoleCD == "RTRV")
                //{
                //    Response.Redirect("ReportViewerMenu.aspx");
                //}

                if ((RoleCD == "RTRV") && (RoleCD != "RTSA"))
                {
                    Response.Redirect("ReportViewerMenu.aspx");
                }

                if ((RoleCD != "RTAD") && (RoleCD != "RTFM"))
                {
                    Response.Redirect("AccessDenied.aspx");
                }
                BindCCYLists();
            }
            CCYBank = BankCCY.SelectedItem.Text;
            CCYBranch = BranchCcy.SelectedItem.Text;
        }
        private void BindCCYLists()
        {
            BankCCY.DataSource = CCYList;
            BankCCY.DataBind();
            BranchCcy.DataSource = CCYList;
            BranchCcy.DataBind();
        }
    }
}