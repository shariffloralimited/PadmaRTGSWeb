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
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            MessageDB db = new MessageDB();
            MyDataGrid.DataSource = db.GetAllMessages();
            MyDataGrid.DataBind();
        }
    }

}