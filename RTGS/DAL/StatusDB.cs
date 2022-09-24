using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RTGS
{
    public class StatusDB
	{
        public DataTable GetStatusByClearingType(int ClearingType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetStatusByClearingType", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameteClearingType = new SqlParameter("@ClearingType", SqlDbType.Int, 4);
            parameteClearingType.Value = ClearingType;
            myCommand.SelectCommand.Parameters.Add(parameteClearingType); 
            
            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
    }
}

