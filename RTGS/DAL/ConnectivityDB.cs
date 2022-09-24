using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class Connectivity
    {
        public string CBS;
        public string STP;
        public string BB;
        public decimal LIQ;
        public string LQTM;
        public string BBTM;
    }
    public class ConnectivityDB
    {
        public Connectivity GetConnectivityInfo(string CCY)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("DASH_GetConnectivityInfo", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.SelectCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterCBS = new SqlParameter("@CBS", SqlDbType.VarChar, 3);
            parameterCBS.Direction = ParameterDirection.Output;
            myCommand.SelectCommand.Parameters.Add(parameterCBS);

            SqlParameter parameterSTP = new SqlParameter("@STP", SqlDbType.VarChar, 3);
            parameterSTP.Direction = ParameterDirection.Output;
            myCommand.SelectCommand.Parameters.Add(parameterSTP);

            SqlParameter parameterBB = new SqlParameter("@BB", SqlDbType.VarChar, 3);
            parameterBB.Direction = ParameterDirection.Output;
            myCommand.SelectCommand.Parameters.Add(parameterBB);

            SqlParameter parameterLIQ = new SqlParameter("@LIQ", SqlDbType.Money);
            parameterLIQ.Direction = ParameterDirection.Output;
            myCommand.SelectCommand.Parameters.Add(parameterLIQ);

            SqlParameter parameterLQTM = new SqlParameter("@LQTM", SqlDbType.Int, 4);
            parameterLQTM.Direction = ParameterDirection.Output;
            myCommand.SelectCommand.Parameters.Add(parameterLQTM);

            SqlParameter parameterBBTM = new SqlParameter("@BBTM", SqlDbType.Int, 4);
            parameterBBTM.Direction = ParameterDirection.Output;
            myCommand.SelectCommand.Parameters.Add(parameterBBTM);

            myConnection.Open();
            myCommand.SelectCommand.ExecuteNonQuery();

            Connectivity con = new Connectivity();
            con.CBS = (string) parameterCBS.Value;
            con.STP = (string)parameterSTP.Value;
            con.BB = (string)parameterBB.Value;
            con.LIQ = (decimal)parameterLIQ.Value;
            con.LQTM = parameterLQTM.Value.ToString();
            con.BBTM = parameterBBTM.Value.ToString();

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return con;
        }
    }
}

