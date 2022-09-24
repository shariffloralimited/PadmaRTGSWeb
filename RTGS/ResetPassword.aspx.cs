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
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = Int32.Parse(Request.Params["UserID"]);
            string password = "1";

            UserDB db = new UserDB();
            db.ResetPassword(userID, password);
            Response.Redirect("Users.aspx");

        }
    }
}
