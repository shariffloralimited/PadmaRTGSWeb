using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace RTGS
{
    public class MessageDB
    {
        public void InsertMessage(string MessageFrom, string RoutingNo, string ExpiryDate, string MessageText)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("Msg_Insert", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterMessageFrom = new SqlParameter("@MessageFrom", SqlDbType.VarChar, 50);
            parameterMessageFrom.Value = MessageFrom;
            myCommand.Parameters.Add(parameterMessageFrom);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterExpiryDate = new SqlParameter("@ExpiryDate", SqlDbType.Int);
            parameterExpiryDate.Value = ExpiryDate;
            myCommand.Parameters.Add(parameterExpiryDate);

            SqlParameter parameterMessageText = new SqlParameter("@MessageText", SqlDbType.NVarChar, 1000);
            parameterMessageText.Value = MessageText;
            myCommand.Parameters.Add(parameterMessageText);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myCommand.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        }
        public DataTable GetBranchMessages(string RoutingNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("Msg_GetBranch", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            myConnection.Open();

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }
        public DataTable GetAllMessages()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("Msg_GetAll", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }
        public void ExpireMessage(int MessageID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("Msg_Expire", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterMessageID = new SqlParameter("@MessageID", SqlDbType.Int,4);
            parameterMessageID.Value = MessageID;
            myCommand.Parameters.Add(parameterMessageID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
        }
    }
}

