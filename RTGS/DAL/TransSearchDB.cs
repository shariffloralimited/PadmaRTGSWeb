using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class TransSearchDB
    {
        public DataTable GetInvalidList(string Form, string Tick)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("HUB_GetInvalidList", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterForm = new SqlParameter("@Form", SqlDbType.VarChar, 10);
            parameterForm.Value = Form;
            myCommand.SelectCommand.Parameters.Add(parameterForm);

            SqlParameter parameterTick = new SqlParameter("@Tick", SqlDbType.VarChar, 50);
            parameterTick.Value = Tick;
            myCommand.SelectCommand.Parameters.Add(parameterTick); 
            
            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }

        public SqlDataReader GetValidList(string Tick)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetValidList", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterTick = new SqlParameter("@Tick", SqlDbType.VarChar, 50);
            parameterTick.Value = Tick;
            myCommand.Parameters.Add(parameterTick);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }

        public void UpdateRow(string Tick, bool Invalid, string RefNo, string Msg)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_UpdateRow", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterTick = new SqlParameter("@Tick", SqlDbType.VarChar, 50);
            parameterTick.Value = Tick;
            myCommand.Parameters.Add(parameterTick);

            SqlParameter parameterInvalid = new SqlParameter("@Invalid", SqlDbType.Bit);
            parameterInvalid.Value = Invalid;
            myCommand.Parameters.Add(parameterInvalid);

            SqlParameter parameterRefNo = new SqlParameter("@RefNo", SqlDbType.VarChar, 50);
            parameterRefNo.Value = RefNo;
            myCommand.Parameters.Add(parameterRefNo);

            SqlParameter parameterMsg = new SqlParameter("@Msg", SqlDbType.VarChar, 8000);
            parameterMsg.Value = Msg;
            myCommand.Parameters.Add(parameterMsg);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

    }
}
