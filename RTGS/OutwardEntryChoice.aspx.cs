using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS
{
    public partial class OutwardEntryChoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            

        }

        protected void SingleCustomerCredit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forms/Outward08ShortMaker.aspx");
        }

        protected void FICredit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forms/Outward09ShortMaker.aspx");
        }

        protected void FIDebit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forms/FinInstitutionDirectDebit.aspx");
        }

        protected void SingleCustomerCreditBulk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forms/CustomerCreditBulk.aspx");
        }

        protected void FICreditBulk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forms/FinInstitutionCreditTransferBulk.aspx");
        }

        protected void FIDebitBulk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forms/FinInstitutionDirectDebitBulk.aspx");
        }
    }
}