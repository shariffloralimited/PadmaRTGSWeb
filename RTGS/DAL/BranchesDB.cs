using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace RTGS
{
	public class BranchesDB
	{
        //public DataTable GetBranchesByBankCode(int BankCode)
        //{
        //    SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

        //    SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetBranchesByBankCode", myConnection);
        //    myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
        //    parameterBankCode.Value = BankCode;
        //    myCommand.SelectCommand.Parameters.Add(parameterBankCode);

        //    myConnection.Open();
        //    DataTable dt = new DataTable();
        //    myCommand.Fill(dt);

        //    myConnection.Close();
        //    myCommand.Dispose();
        //    myConnection.Dispose();

        //    return dt;
        //}
        public DataTable GetZoneBranchesOfAUser(int UserID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetZoneBranchesOfAUser", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.SelectCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }

        //public DataTable GetBranchesByZoneID(int zoneID)
        //{
        //    SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

        //    SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetBranchesByZoneID", myConnection);
        //    myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterZoneID = new SqlParameter("@ZoneID", SqlDbType.Int, 4);
        //    parameterZoneID.Value = zoneID;
        //    myCommand.SelectCommand.Parameters.Add(parameterZoneID);

        //    myConnection.Open();
        //    DataTable dt = new DataTable();
        //    myCommand.Fill(dt);

        //    myConnection.Close();
        //    myCommand.Dispose();
        //    myConnection.Dispose();

        //    return dt;
        //}
        public DataTable GetBranchesByBankID(int BankID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetBranchesByBankID", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBankID = new SqlParameter("@BankID", SqlDbType.Int, 4);
            parameterBankID.Value = BankID;
            myCommand.SelectCommand.Parameters.Add(parameterBankID);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchesByBIC(string BIC)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetBranchesByBIC", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterBIC = new SqlParameter("@BIC", SqlDbType.VarChar, 8);
            parameterBIC.Value = BIC;
            myCommand.SelectCommand.Parameters.Add(parameterBIC);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }

        public DataTable GetBranchesByBankCD(string BankCD)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetBranchesByBankCD", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterBankCD = new SqlParameter("@BankCD", SqlDbType.VarChar, 8);
            parameterBankCD.Value = BankCD;
            myCommand.SelectCommand.Parameters.Add(parameterBankCD);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchesPacs9ByBIC(string BIC)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetBranchesPacs9ByBIC", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterBIC = new SqlParameter("@BIC", SqlDbType.VarChar, 8);
            parameterBIC.Value = BIC;
            myCommand.SelectCommand.Parameters.Add(parameterBIC);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }


        public DataTable GetSendBranches()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetSendBranches", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }


        public string UpdateBranch(int BranchID, string RoutingNo, string BranchName)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_UpdateBranch", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBranchID = new SqlParameter("@BranchID", SqlDbType.Int,4);
            parameterBranchID.Value = BranchID;
            myCommand.Parameters.Add(parameterBranchID);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterBranchName = new SqlParameter("@BranchName", SqlDbType.VarChar, 50);
            parameterBranchName.Value = BranchName;
            myCommand.Parameters.Add(parameterBranchName);

            SqlParameter parameterMsg = new SqlParameter("@Msg", SqlDbType.VarChar, 50);
            parameterMsg.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterMsg);


            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string Msg = (string) parameterMsg.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return Msg;
        }

        public string InsertBranch(string RoutingNo, string BranchName)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_InsertBranch", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterBranchName = new SqlParameter("@BranchName", SqlDbType.VarChar, 50);
            parameterBranchName.Value = BranchName;
            myCommand.Parameters.Add(parameterBranchName);
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
         

