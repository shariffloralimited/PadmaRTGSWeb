using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace RTGS
{
    public class OCEBatchDB
    {
        public DataTable GetBatchStatus(int RoutingNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_Outward_GetBatchStatus", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            //SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int, 4);
            //parameterClearingType.Value = ClearingType;
            //myCommand.SelectCommand.Parameters.Add(parameterClearingType);

            //SqlParameter parameterToday = new SqlParameter("@Today", SqlDbType.Bit);
            //parameterToday.Value = Today;
            //myCommand.SelectCommand.Parameters.Add(parameterToday);

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

