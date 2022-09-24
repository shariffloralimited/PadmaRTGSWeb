using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RTGS
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.Cookies["ChangePwdNow"].Value.ToUpper() == "TRUE")
            {
                Response.Redirect("ChangePassword.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserName = Request.Cookies["UserName"].Value; 
            if (Request.Cookies["RoleName"] != null)
            {
                UserName = UserName + " (" + Request.Cookies["RoleName"].Value + ")";
            }
            if (Request.Cookies["ExpMsg"].Value != "")
            {
                UserName = UserName + "<br/>" + Request.Cookies["ExpMsg"].Value;
            }
            LblUserName.Text = UserName;

            try
            {
                string RoutingNo = Request.Cookies["RoutingNo"].Value;
                BindData(RoutingNo);
            }
            catch
            { }
        }
        private void BindData(string RoutingNo)
        {
            MessageDB db = new MessageDB();
            DataTable dt = db.GetBranchMessages(RoutingNo);
            NotificationList.DataSource = dt;
            NotificationList.DataBind();

            MsgCount.Text = dt.Rows.Count.ToString();
            dt.Dispose();
            NotificationList.Dispose();
        }
    }
}