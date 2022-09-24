using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace RTGS
{
	public class DeptDB
	{
        public DataTable GetDepts()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetDepts", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

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
         

