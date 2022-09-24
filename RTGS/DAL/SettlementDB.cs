using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace RTGS
{
    public class SettlementDB
    {
        public DataTable GetDASHBankSettlement(string Ccy)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("DASH_GetBankSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCCy = new SqlParameter("@Ccy", SqlDbType.VarChar, 3);
            parameterCCy.Value = Ccy;
            myCommand.SelectCommand.Parameters.Add(parameterCCy);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetDASHBranchSettlement(string Ccy)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("DASH_GetBranchSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCCy = new SqlParameter("@Ccy", SqlDbType.VarChar, 3);
            parameterCCy.Value = Ccy;
            myCommand.SelectCommand.Parameters.Add(parameterCCy);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetDASHDeptSettlement(string Ccy)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("DASH_GetDeptSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCCy = new SqlParameter("@Ccy", SqlDbType.VarChar, 3);
            parameterCCy.Value = Ccy;
            myCommand.SelectCommand.Parameters.Add(parameterCCy);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBankSettlement(string SttlmDt, string Ccy)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetBankSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSttlmDt = new SqlParameter("@SttlmDt", SqlDbType.VarChar, 10);
            parameterSttlmDt.Value = SttlmDt;
            myCommand.SelectCommand.Parameters.Add(parameterSttlmDt);

            SqlParameter parameterCCy = new SqlParameter("@Ccy", SqlDbType.VarChar, 3);
            parameterCCy.Value = Ccy;
            myCommand.SelectCommand.Parameters.Add(parameterCCy);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchSettlement(string SttlmDt, string Ccy)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetBranchSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSttlmDt = new SqlParameter("@SttlmDt", SqlDbType.VarChar, 10);
            parameterSttlmDt.Value = SttlmDt;
            myCommand.SelectCommand.Parameters.Add(parameterSttlmDt);

            SqlParameter parameterCCy = new SqlParameter("@cCy", SqlDbType.VarChar, 3);
            parameterCCy.Value = Ccy;
            myCommand.SelectCommand.Parameters.Add(parameterCCy);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }


        public DataTable BranchSettlement(string SttlmDt, string Ccy)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_BranchSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSttlmDt = new SqlParameter("@SttlmDt", SqlDbType.VarChar, 10);
            parameterSttlmDt.Value = SttlmDt;
            myCommand.SelectCommand.Parameters.Add(parameterSttlmDt);

            SqlParameter parameterCCy = new SqlParameter("@cCy", SqlDbType.VarChar, 3);
            parameterCCy.Value = Ccy;
            myCommand.SelectCommand.Parameters.Add(parameterCCy);

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

