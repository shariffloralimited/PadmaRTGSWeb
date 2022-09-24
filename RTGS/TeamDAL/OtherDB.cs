using System;
using System.Data;
using System.Data.SqlClient;

namespace RTGSImporter
{
    class OtherDB
    {
        public void InsertOther(string FileName, string MsgDefIdr, string xmlstr)
        {
            SqlConnection myConnection = new SqlConnection("server=.;Trusted_connection=Yes;database=RTGSV3");
            SqlCommand myCommand = new SqlCommand("InsertOther", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = FileName;
            myCommand.Parameters.Add(parameterFileName); 
            
            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 100);
            parameterMsgDefIdr.Value = MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterxmlstr = new SqlParameter("@xmlstr", SqlDbType.VarChar, 64000);
            parameterxmlstr.Value = xmlstr;
            myCommand.Parameters.Add(parameterxmlstr);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
    }
}
