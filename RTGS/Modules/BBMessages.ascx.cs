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

namespace RTGS.modules
{
    public partial class BBMessages : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            BBFormsDB db = new BBFormsDB();

            DataTable dt = db.DASH_GetBBForms();

            MyDataGrid.DataSource = dt;
            MyDataGrid.DataBind();
            dt.Dispose();
            MyDataGrid.Dispose();
        }
    }
}