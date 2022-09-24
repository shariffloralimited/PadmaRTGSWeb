using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class TransCodeDB
    {
        public DataTable GetTransCode(string Form)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetTransCode", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterForm = new SqlParameter("@Form", SqlDbType.VarChar, 10);
            parameterForm.Value = Form;
            myCommand.SelectCommand.Parameters.Add(parameterForm); 
            
            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
            
            return dt;
        }
    }
}

