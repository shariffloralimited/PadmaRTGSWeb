using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace RTGS
{
    public partial class EditMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BranchesDB db2 = new BranchesDB();
                BranchList.DataSource = db2.GetSendBranches();
                BranchList.DataBind();
                BranchList.Items.Add(new ListItem("All", "0"));
                BranchList.SelectedIndex = BranchList.Items.Count - 1;

                DateTime nextdate = System.DateTime.Today.Add(new TimeSpan(1, 0, 0, 0));
                ChkDay.SelectedValue   = nextdate.Day.ToString();
                ChkMonth.SelectedValue = nextdate.Month.ToString();
                ChkYear.SelectedValue  = nextdate.Year.ToString();
            }
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            MessageDB db = new MessageDB();
            DateTimeFormatInfo format = CultureInfo.InvariantCulture.DateTimeFormat;
            try
            {
                
                DateTime.Parse(ChkMonth.SelectedValue.ToString().PadLeft(2,'0')+"/" +  ChkDay.SelectedValue.ToString().PadLeft(2,'0')+"/"+ChkYear.SelectedValue.ToString().PadLeft(2,'0'),format );
                string ExpiryDate = ChkYear.SelectedValue + ChkMonth.SelectedValue.PadLeft(2, '0') + ChkDay.SelectedValue.PadLeft(2, '0');
                db.InsertMessage(Request.Cookies["UserName"].Value, BranchList.SelectedValue, ExpiryDate, MessageText.Text);
                Response.Redirect("Messages.aspx");
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message+" Format:"+format.FullDateTimePattern);
                Msg.Text = "Inavlid Date";
            } 
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Messages.aspx");
        }
    }
}
