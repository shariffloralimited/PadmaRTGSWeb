using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class BBFormsDB
    {
        public DataTable GetBBForms(string Form)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("BB_GetBBForms", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterForm = new SqlParameter("@Form", SqlDbType.VarChar, 10);
            parameterForm.Value = Form;
            myCommand.SelectCommand.Parameters.Add(parameterForm); 
            
            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();   

            return dt;
        }

        public DataTable DASH_GetBBForms()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("DASH_GetBBForms", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();   

            return dt;
        }
        public DataTable GetCamt19Evt(string SysDt)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ADM_GetCamt19Evt", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSysDt = new SqlParameter("@SysDt", SqlDbType.VarChar, 10);
            parameterSysDt.Value = SysDt;
            myCommand.SelectCommand.Parameters.Add(parameterSysDt);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
            
            return dt;
        }
    }
}

