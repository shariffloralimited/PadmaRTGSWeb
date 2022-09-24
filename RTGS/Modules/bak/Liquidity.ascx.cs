using System;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.ServiceProcess;
using System.IO;
using System.Linq;

namespace RTGS.modules
{
    public partial class Liquidity : System.Web.UI.UserControl
    {
        ConnectivityDB db = new ConnectivityDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable CCyList;

                RTGS._Default homepage = (RTGS._Default)Parent.Page;
                CCyList = homepage.CCYList;

                CCYList.DataSource = CCyList;
                CCYList.DataBind();
            }
            SetButtons();
        }
        protected void LiquidityBtn_Click(object sender, EventArgs e)
        {
            FloraSoft.CamtGenerator camt = new FloraSoft.CamtGenerator();
            camt.GenCamt60(CCYList.SelectedItem.Text);
        }

        private void SetErrorFile()
        {
            DirectoryInfo dir = new DirectoryInfo(ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Error");
            int n = dir.GetFiles().Count();
            LblErrFileCnt.Text = n.ToString() + " files";
            if (n > 0)
            {
                FileInfo myFile = dir.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
                LblErrFile.Text = myFile.Name + " (" + myFile.LastWriteTime + ")";
                myFile = null;
            }
            else
            {
                LblErrFile.Text = "";
            }

            dir = null;
        }
        private void SetButtons()
        {
            string ccy = CCYList.SelectedItem.Text;
            Connectivity con = db.GetConnectivityInfo(ccy);
            lblCBS.Text = con.CBS;
            lblSTP.Text = con.STP;
            lblBB.Text = con.BB;
            lblBBTM.Text = con.BBTM;
            lblLIQ.Text = ccy + " " +con.LIQ.ToString("N2") + " (" + con.LQTM + " mins)";
            if (con.BB != "OFF")
            {
                lblBB.CssClass = "label label-success";
            }
            else
            {
                lblBB.CssClass = "label label-danger";
            }






            if (con.CBS != "OFF")
            {
                lblCBS.CssClass = "label label-success";
            }
            else
            {
                lblCBS.CssClass = "label label-danger";
            }







            if (con.STP != "OFF")
            {
                lblSTP.CssClass = "label label-success";
            }
            else
            {
                lblSTP.CssClass = "label label-danger";
            }

            ServiceController sc = new ServiceController("Flora RTGS Export Import Service");
            if (sc.Status.ToString() != "Running")
            {
                LblImporter.CssClass = "label label-danger";
                LblImporter.Text = "OFF";

                lblSTP.CssClass = "label label-danger";
                lblSTP.Text = "OFF";
            }
            else
            {
                LblImporter.CssClass = "label label-success";
                LblImporter.Text = "ON";
            }
            sc.Dispose();
            sc.Close();





            ServiceController cb = new ServiceController("Flora RTGS Export Import Service");
            if (cb.Status.ToString() != "Running")
            {
                lblCBSService.CssClass = "label label-danger";
                lblCBSService.Text = "OFF";

                lblSTP.CssClass = "label label-danger";
                lblSTP.Text = "OFF";
            }
            else
            {
                lblCBSService.CssClass = "label label-success";
                lblCBSService.Text = "ON";
            }
            cb.Dispose();
            cb.Close();





            SetErrorFile();
        }

        protected void Camt03Btn_Click(object sender, EventArgs e)
        {
            FloraSoft.CamtGenerator camt = new FloraSoft.CamtGenerator();
            camt.GenCam03(CCYList.SelectedItem.Text);
        }

    }

// The following example demonstrates how to create 
// a resource class that implements the IDisposable interface 
// and the IDisposable.Dispose method. 

    public class MyResource: IDisposable
    {
        // Pointer to an external unmanaged resource. 
        private IntPtr handle;
        // Other managed resource this class uses. 
        private Component component = new Component();
        // Track whether Dispose has been called. 
        private bool disposed = false;

        // The class constructor. 
        public MyResource(IntPtr handle)
        {
            this.handle = handle;
        }

        // Implement IDisposable. 
        // Do not make this method virtual. 
        // A derived class should not be able to override this method. 
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method. 
            // Therefore, you should call GC.SupressFinalize to 
            // take this object off the finalization queue 
            // and prevent finalization code for this object 
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios. 
        // If disposing equals true, the method has been called directly 
        // or indirectly by a user's code. Managed and unmanaged resources 
        // can be disposed. 
        // If disposing equals false, the method has been called by the 
        // runtime from inside the finalizer and you should not reference 
        // other objects. Only unmanaged resources can be disposed. 
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if(!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources. 
                if(disposing)
                {
                    // Dispose managed resources.
                    component.Dispose();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here. 
                // If disposing is false, 
                // only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;

                // Note disposing has been done.
                disposed = true;

            }
        }

        // Use interop to call the method necessary 
        // to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        // Use C# destructor syntax for finalization code. 
        // This destructor will run only if the Dispose method 
        // does not get called. 
        // It gives your base class the opportunity to finalize. 
        // Do not provide destructors in types derived from this class.
        ~MyResource()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of 
            // readability and maintainability.
            Dispose(false);
        }
    }
}