using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class SettingsDB
    {
        public void UpdateCutoffTime(string HVCT, string RVCT, string OHVCT, string ORVCT)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_UpdateCTSetting", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterHVCT = new SqlParameter("@HVCT", SqlDbType.VarChar, 4);
            parameterHVCT.Value = HVCT;
            myCommand.Parameters.Add(parameterHVCT);

            SqlParameter parameterRVCT = new SqlParameter("@RVCT", SqlDbType.VarChar, 4);
            parameterRVCT.Value = RVCT;
            myCommand.Parameters.Add(parameterRVCT);


            SqlParameter parameterOHVCT = new SqlParameter("@OHVCT", SqlDbType.VarChar, 4);
            parameterOHVCT.Value = OHVCT;
            myCommand.Parameters.Add(parameterOHVCT);

            SqlParameter parameterORVCT = new SqlParameter("@ORVCT", SqlDbType.VarChar, 4);
            parameterORVCT.Value = ORVCT;
            myCommand.Parameters.Add(parameterORVCT);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

        }
        public SqlDataReader GetSettings()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_GetSetting", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public void UpdateValue(string FieldName, int FieldVal)
        {
            string sql = "Update RTGS.dbo.RTGS_BankSetting SET " + FieldName + " = " + FieldVal.ToString();
            ExecuteSQL(sql, "RTGS");
        }
        public void ExecuteSQL(string commandText, string databaseName)
        {
            SqlConnection connection = new SqlConnection(AppVariables.ConStr);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandTimeout = 60;

            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch 
            {
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
    }
}

