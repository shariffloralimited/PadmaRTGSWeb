using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;

namespace RTGS 
{
    public partial class ViewSignature : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string AccountNo = Request.Params["AccountNo"];

            try
            {
                RTGSWS.Service1 svc = new RTGSWS.Service1();
                //string photoId = ConfigurationManager.AppSettings["ImageUrl"] + svc.GetSignature(AccountNo.Trim());
              //string photoId = "\\\\192.168.0.133\\Signatures\\" + svc.GetSignature(AccountNo);

                //byte[] bytes = Convert.FromBase64String(Getbase64Image(photoId));

                //SignImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);
            }
            catch { }
                
        }
        public string Getbase64Image(string Path)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(Path);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }

   
    }
}