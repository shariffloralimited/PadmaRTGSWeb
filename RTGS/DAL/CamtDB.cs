using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FloraSoft
{
    public class CamtDB
    {
        public String GetCamtXML(string BBID)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ADM_GetCamtXML", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBBID = new SqlParameter("@BBID", SqlDbType.UniqueIdentifier, 50);
            parameterBBID.Value = new Guid(BBID);
            myCommand.Parameters.Add(parameterBBID);

            SqlParameter parameterXmlData = new SqlParameter("@XmlData", SqlDbType.VarChar, 64000);
            parameterXmlData.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterXmlData);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string XmlData = (string) parameterXmlData.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();          

            return XmlData;
        }
    }
}