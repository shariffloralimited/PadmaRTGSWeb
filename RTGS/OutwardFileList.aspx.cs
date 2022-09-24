using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Xml;

using System;
using System.Collections.Generic;
using System.Linq;

namespace RTGS
{
    public partial class OutwardFileList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg.Text = "";
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            FileList.DataSource = CreateDataSource();
            FileList.DataBind();

            //int m = FileList.Items.Count;
            //for (int i = 0; i < m; i++)
            //{
            //    CheckBox cb = (CheckBox)FileList.Items[i].FindControl("FileCheck");
            //    if (FileList.DataKeys[i].ToString().ToUpper().Contains(".TXT"))
            //    {
            //        cb.Enabled = false;
            //    }
            //}
            if (FileList.Items.Count == 0)
            {
                CheckAll.Visible = false;
                SendBtn.Visible = false;
                DeleteBtn.Visible = false;
                Msg.Text = "No files found";
            }

            //if (!AppVariable.IsConnected)
            //{
            //    FTPConnectMsg.Text  = "Cannot Connect to PBM";
            //    PBMList.Visible     = false;
            //    return;
            //}
            //WSClient ws = new WSClient();

            //PBMList.DataSource = ws.GetFileList(ConfigurationManager.AppSettings["RemotePBMPath"] + "\\PBMImport\\PBMOut", "OCE*");
            //PBMList.DataBind();

            //if (PBMList.Items.Count == 0)
            //{
            //    PBMList.Visible = false;
            //}
        }
        ICollection CreateDataSource()
        {
            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("FilePath", typeof(String)));
            dt.Columns.Add(new DataColumn("FileName", typeof(String)));

            string SourcePath = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX";
            string DestPath = ConfigurationManager.AppSettings["RemoteSTPPath"];


            DirectoryInfo dir = new DirectoryInfo(SourcePath);
            FileInfo[] files = dir.GetFiles("*.XML");

            foreach (FileInfo file in files)
            {
                string filename = file.FullName.Substring(file.FullName.LastIndexOf("\\") + 1);
                dr = dt.NewRow();
                dr[0] = file.Name;
                dr[1] = filename;
                dt.Rows.Add(dr);
            }
            DataView dv = new DataView(dt);
            return dv;
        }
        //protected void SendBtn_Click(object sender, EventArgs e)
        //{
        //    WSClient ws = new WSClient();
        //    if (!Directory.Exists(ConfigurationManager.AppSettings["LocalCLPath"] + "\\Outward" + "\\bak"))
        //    {
        //        Directory.CreateDirectory(ConfigurationManager.AppSettings["LocalCLPath"] + "\\Outward" + "\\bak");
        //    }
        //    int m = FileList.Items.Count;
        //    for (int i = m - 1; i > -1; i--)
        //    {
        //        CheckBox cb = (CheckBox)FileList.Items[i].FindControl("FileCheck");
        //        if (cb.Checked)
        //        {
        //            string sourcefile = ConfigurationManager.AppSettings["LocalCLPath"]   + "\\Outward\\"           + FileList.DataKeys[i].ToString().ToUpper();
        //            string destfile   = ConfigurationManager.AppSettings["RemotePBMPath"] + "\\PBMImport\\PBMOut\\" + FileList.DataKeys[i].ToString().ToUpper();
        //            ws.SendSingleFile(sourcefile.Replace(".XML", ".IMG"), destfile.Replace(".XML", ".IMG"));
        //            ws.SendSingleFile(sourcefile, destfile );
        //            BackupFile(sourcefile);
        //        }
        //    }
        //    Response.Redirect("OCEFiles.aspx");
        //}
        private void BackupFile(string FileName)
        {
            string DestFileName = FileName.Replace("FSIB", "bak\\FSIB");
            if (!File.Exists(DestFileName))
            {
                File.Move(FileName, DestFileName);
            }
        }

        protected void RefreshBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("OCEFiles.aspx");
        }
        protected void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            bool CheckAllChecked = CheckAll.Checked;
            int m = FileList.Items.Count;
            for (int i = 0; i < m; i++)
            {
                CheckBox cb = (CheckBox)FileList.Items[i].FindControl("FileCheck");
                cb.Checked = CheckAllChecked;
            }
        }

        protected void SendBtn_Click(object sender, System.EventArgs e)
        {

        }



        protected void DeleteBtn_Click(object sender, System.EventArgs e)
        {
            int m = FileList.Items.Count;
            for (int i = m - 1; i > -1; i--)
            {
                CheckBox cb = (CheckBox)FileList.Items[i].FindControl("FileCheck");
                if (cb.Checked)
                {
                    string FullName = ConfigurationManager.AppSettings["LocalSTPPath"] + "\\Export\\MX" + "\\" + FileList.DataKeys[i].ToString().ToUpper();
                    File.Delete(FullName);
                }
            }
            BindData();
            
        }
    }
}