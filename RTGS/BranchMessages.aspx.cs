using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace RTGS
{
    public partial class BranchMessages : System.Web.UI.Page
    {
//        protected void Page_Init(object sender, EventArgs e)
//        {
//            string RoleCD = Request.Cookies["RoleCD"].Value;
//            if ((RoleCD == "RTAD") || (RoleCD == "RTFM"))
//            {
//                Response.Redirect("Messages.aspx");
//            }

//        }
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!Page.IsPostBack)
//            {
//                BindData();
//            }
//            if (MyDataList.Items.Count == 0)
//            {
//                Response.Redirect("BranchMenu.aspx");
//            }
//        }
//        private void BindData()
//        {
//            MessageDB db = new MessageDB();
//            MyDataList.DataSource = db.GetBranchMessages(Request.Cookies["RoutingNo"].Value);
//            MyDataList.DataBind();
//        }
//    }

//}

        protected void Page_Init(object sender, EventArgs e)
        {
            string value = base.Request.Cookies["RoleCD"].Value;
            if (value == "RTAD" || value == "RTFM")
            {
                base.Response.Redirect("Messages.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.BindData();
            }
            if (this.MyDataList.Items.Count == 0)
            {
                base.Response.Redirect("BranchMenu.aspx");
            }
        }

        private void BindData()
        {
            MessageDB messageDB = new MessageDB();
            this.MyDataList.DataSource = messageDB.GetBranchMessages(base.Request.Cookies["RoutingNo"].Value);
            this.MyDataList.DataBind();
        }
    }
}
