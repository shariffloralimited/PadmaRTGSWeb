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
using RTGS.DAC;

namespace RTGS
{
    public partial class GenerateOutwardXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetButtons();
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindData();
            for (int i = 0; i < MyDataGrid.Rows.Count; i++)
            {
                ((CheckBox)MyDataGrid.Rows[i].FindControl("chkTransID")).Checked = CheckSelectAll.Checked;
            }

        }
        private void SetButtons()
        {
            string RoleCD = Request.Cookies["RoleCD"].Value;
            FloraSoft.BankSettingsDB db = new FloraSoft.BankSettingsDB();
            FloraSoft.BankSettings st = db.GetBankSettings();
            if (st.SecsPaused > 0)
            {
                if (RoleCD != "RTFM")
                {
                    btnGenerate.Visible = false;
                    btnMT.Visible = false;
                    ddlPauseMins.Visible = false;
                    btnPause.Visible = false;
                }
                else
                {
                    btnGenerate.CssClass = "btn btn-info";
                    btnMT.CssClass = "btn btn-info";
                    ddlPauseMins.Visible = true;
                    btnPause.Visible = true;
                }
                Msg.Text = st.SecsPaused.ToString() + " seconds remaining.";
            }
            else
            {
                btnGenerate.CssClass = "btn btn-success";
                btnMT.CssClass = "btn btn-success";

                btnGenerate.Visible = true;
                btnMT.Visible = true;
                if (RoleCD != "RTFM")
                {
                    ddlPauseMins.Visible = false;
                    btnPause.Visible = false;
                }
                else
                {
                    ddlPauseMins.Visible = true;
                    btnPause.Visible = true;
                }

                Msg.Text = "";
            }
        }
        private void BindData()
        {
            OutwardDB db = new OutwardDB();
            DataTable dt = db.GetOutwardList("0", 5);

            MyDataGrid.DataSource = dt;
            MyDataGrid.DataBind();
            try
            {
                MyDataGrid.FooterRow.Cells[2].Text  = dt.Compute("SUM(TotalChecks)", "").ToString();
                MyDataGrid.FooterRow.Cells[3].Text  = dt.Compute("SUM(BatchTotal)", "").ToString();
                MyDataGrid.FooterRow.Cells[11].Text = dt.Compute("SUM(Presented)", "").ToString();
                MyDataGrid.FooterRow.Cells[12].Text = dt.Compute("SUM(Accepted)", "").ToString();
                MyDataGrid.FooterRow.Cells[13].Text = dt.Compute("SUM(Rejected)", "").ToString();
            }
            catch
            {
            }
            dt.Dispose();
            MyDataGrid.Dispose();
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            Guid cartid = Guid.NewGuid();
            string CartID = cartid.ToString();

            OutwardDB outdb = new OutwardDB();
            for (int i = 0; i < MyDataGrid.Rows.Count; i++)
            {
                if (((CheckBox)(MyDataGrid.Rows[i].FindControl("chkTransID"))).Checked)
                {
                    string OutwardID = ((Label)MyDataGrid.Rows[i].FindControl("lblTransID")).Text;
                    string FormType = ((Label)MyDataGrid.Rows[i].FindControl("lblFormType")).Text;
                    outdb.AddToCart(OutwardID, FormType, CartID, priority.SelectedItem.Text);
                    ///outdb.AddToCart(OutwardID, FormType, CartID);
                }
            }

            outdb.UpdateBatchBooking(CartID);

            FloraSoft.MXGenerator mx = new FloraSoft.MXGenerator();
            for (int i = 0; i < MyDataGrid.Rows.Count; i++)
            {
                if (((CheckBox)(MyDataGrid.Rows[i].FindControl("chkTransID"))).Checked)
                {
                    string OutwardID= ((Label)MyDataGrid.Rows[i].FindControl("lblTransID")).Text;
                    string FormType = ((Label)MyDataGrid.Rows[i].FindControl("lblFormType")).Text;
                    string UserName = Request.Cookies["UserName"].Value;
                    string UserIP   = HttpContext.Current.Request.UserHostAddress;
                    string Priority = priority.SelectedItem.Text;

                    if (FormType == "Pacs.008")
                    {
                        mx.GenPacs008(OutwardID, CartID, Priority, UserName, UserIP);
                    }
                    if (FormType == "Pacs.009")
                    {
                        mx.GenPacs009(OutwardID, CartID, Priority, UserName, UserIP);
                    }
                    if (FormType == "Pacs.004")
                    {
                        mx.GenPacs004(OutwardID, CartID, Priority, UserName, UserIP);
                    }
                }
            }
            //Response.Redirect("OutwardFileList.aspx");
        }
        protected void btnMT_Click(object sender, EventArgs e)
        {
            FloraSoft.MTGenerator mt = new FloraSoft.MTGenerator();
            for (int i = 0; i < MyDataGrid.Rows.Count; i++)
            {
                if (((CheckBox)(MyDataGrid.Rows[i].FindControl("chkTransID"))).Checked)
                {
                    string OutwardID = ((Label)MyDataGrid.Rows[i].FindControl("lblTransID")).Text;
                    string FormType = ((Label)MyDataGrid.Rows[i].FindControl("lblFormType")).Text;


                    if (FormType == "Pacs.008")
                    {
                        mt.GenMT103(OutwardID);
                    }
                    if (FormType == "Pacs.009")
                    {
                        mt.GenMT202(OutwardID);
                    }

                }
            }
            //Response.Redirect("MTGenerator.aspx?OutwardID=" + TransID + "&Type=" + FormType);
        }
        protected void btnPause_Click(object sender, EventArgs e)
        {
            FloraSoft.BankSettingsDB db = new FloraSoft.BankSettingsDB(); 

            if (ddlPauseMins.SelectedIndex != 0)
            {
                db.PauseOutward(Int32.Parse(ddlPauseMins.SelectedValue));
            }
            SetButtons();
       }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            OutwardDB db = new OutwardDB();
            for (int i = 0; i < MyDataGrid.Rows.Count; i++)
            {
                if (((CheckBox)(MyDataGrid.Rows[i].FindControl("chkTransID"))).Checked)
                {
                    string OutwardID = ((Label)MyDataGrid.Rows[i].FindControl("lblTransID")).Text;
                    string FormType = ((Label)MyDataGrid.Rows[i].FindControl("lblFormType")).Text;
                    db.ReturnToMaker(OutwardID, FormType);
                }
            }
        }
        protected void BtnEmptyCart_Click(object sender, EventArgs e)
        {
            OutwardDB outdb = new OutwardDB();
            outdb.EmptyCart();
        }
    }

}