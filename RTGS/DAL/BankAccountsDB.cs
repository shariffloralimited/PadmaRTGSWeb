using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class BankAccountsDB
    {
        public DataTable GetBankAccounts()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetBankAccounts", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public string GetSingleBankAccount(string CCY)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_GetSingleBankAccount", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar,3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterAcctId = new SqlParameter("@AcctId", SqlDbType.VarChar, 35);
            parameterAcctId.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAcctId);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string AcctId = (string)parameterAcctId.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return AcctId;
        }
        public string GetOtherBankAccount(string CCY, string BICFI)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_GetOtherBankAccount", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterBICFI = new SqlParameter("@BICFI", SqlDbType.VarChar, 8);
            parameterBICFI.Value = BICFI;
            myCommand.Parameters.Add(parameterBICFI);

            SqlParameter parameterAcctId = new SqlParameter("@AcctId", SqlDbType.VarChar, 35);
            parameterAcctId.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAcctId);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string AcctId = (string)parameterAcctId.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return AcctId;
        }
    }
}
