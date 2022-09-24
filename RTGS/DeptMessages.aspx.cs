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
    public partial class DeptMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
            if (MyDataList.Items.Count == 0) 
            {
                Response.Redirect("DeptMenu.aspx");
            }
        }
        private void BindData()
        {
            MessageDB db = new MessageDB();
            MyDataList.DataSource = db.GetBranchMessages(Request.Cookies["RoutingNo"].Value);
            MyDataList.DataBind();
        }
    }

}