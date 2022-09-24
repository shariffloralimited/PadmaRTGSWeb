using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class CCYDB
    {
        public DataTable GetCCYList()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("GetCCYList", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
            
            return dt;
        }

        public decimal GetMinLimit(string CCY, string FileName)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_GetMinLimit", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 10);
            parameterFileName.Value = FileName;
            myCommand.Parameters.Add(parameterFileName);

            SqlParameter parameterMinLimit = new SqlParameter("@MinLimit", SqlDbType.Money);
            parameterMinLimit.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterMinLimit);

            myConnection.Open();
            myCommand.ExecuteNonQuery();


            decimal MinLimit = (decimal)parameterMinLimit.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return MinLimit;
        }

        public decimal GetCCYRate(string CCY)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_GetCCYRate", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterRate = new SqlParameter("@Rate", SqlDbType.Money);
            parameterRate.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRate);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            decimal Rate = (decimal)parameterRate.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return Rate;
        }
        public void UpdateRate(string CCY, decimal Rate, decimal Pacs08MinLimit, decimal Pacs09MinLimit)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_UpdateRate", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
            parameterCCY.Value = CCY;
            myCommand.Parameters.Add(parameterCCY);

            SqlParameter parameterRate = new SqlParameter("@Rate", SqlDbType.Money);
            parameterRate.Value = Rate;
            myCommand.Parameters.Add(parameterRate);

            SqlParameter parameterPacs08MinLimit = new SqlParameter("@Pacs08MinLimit", SqlDbType.Money);
            parameterPacs08MinLimit.Value = Pacs08MinLimit;
            myCommand.Parameters.Add(parameterPacs08MinLimit);

            SqlParameter parameterPacs09MinLimit = new SqlParameter("@Pacs09MinLimit", SqlDbType.Money);
            parameterPacs09MinLimit.Value = Pacs09MinLimit;
            myCommand.Parameters.Add(parameterPacs09MinLimit);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
    }
}

