using RTGS.Entity;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class BBBusinessDay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string RoleCD = Request.Cookies["RoleCD"].Value;
                LoadData();
                if ((RoleCD != "RTAD") && (RoleCD != "RTFM"))
                {
                    bntGen.Visible = false;
                }
            }
            
        }
        private void LoadData()
        {
            string SysDt = System.DateTime.Today.ToString("yyyy-MM-dd");
            BBFormsDB db = new BBFormsDB();

            DataTable dt = db.GetCamt19Evt(SysDt);

            PanelList.DataSource = dt;
            PanelList.DataBind();

            dt.Dispose();
            PanelList.Dispose();
        }

        protected void bntGen_Click(object sender, EventArgs e)
        {
            FloraSoft.CamtGenerator gen = new FloraSoft.CamtGenerator();
            gen.GenCamt18();
        }

    }
}