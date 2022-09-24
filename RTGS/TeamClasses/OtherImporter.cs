using System;
using System.Xml;

namespace RTGSImporter
{
    class OtherImporter
    {
        public void LoadOther(string FileName, string MsgDefIdr, string xmlstr)
        {
            OtherDB db = new OtherDB();
            db.InsertOther(FileName, MsgDefIdr, xmlstr);
        }
    }
}
