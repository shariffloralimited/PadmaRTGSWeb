using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class CBAccountsDB
    {
        public DataTable GetCBAccountsByBIC(string BIC)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetCBAccountsByBIC", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBIC = new SqlParameter("@BIC", SqlDbType.VarChar, 8);
            parameterBIC.Value = BIC;
            myCommand.SelectCommand.Parameters.Add(parameterBIC);
            
            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
            
            return dt;
        }

        public void UpdateCBAccount(int AcctID, string AcctNo)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_UpdateCBAccount", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterAcctID = new SqlParameter("@AcctID", SqlDbType.Int, 4);
            parameterAcctID.Value = AcctID;
            myCommand.Parameters.Add(parameterAcctID); 
           
            SqlParameter parameterAcctNo = new SqlParameter("@AcctNo", SqlDbType.VarChar, 35);
            parameterAcctNo.Value = AcctNo;
            myCommand.Parameters.Add(parameterAcctNo);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public string InsertCBAccount(string BICFI, string CCY, string AcctType, string AcctNo)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_InsertCBAccount", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBICFI = new SqlParameter("@BICFI", SqlDbType.VarChar, 8);
            parameterBICFI.Value = BICFI;
            myCommand.Parameters.Add(parameterBICFI);

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterAcctType = new SqlParameter("@AcctType", SqlDbType.VarChar, 3);
            parameterAcctType.Value = AcctType;
            myCommand.Parameters.Add(parameterAcctType);

            SqlParameter parameterAcctNo = new SqlParameter("@AcctNo", SqlDbType.VarChar, 35);
            parameterAcctNo.Value = AcctNo;
            myCommand.Parameters.Add(parameterAcctNo);

            SqlParameter parameterMsg = new SqlParameter("@Msg", SqlDbType.VarChar, 50);
            parameterMsg.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterMsg);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string Msg = (string)parameterMsg.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return Msg;
        }
    }
}

