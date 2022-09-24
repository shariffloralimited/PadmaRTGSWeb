using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class AuditDB
    {
        public DataTable AuditSearch(string ClearingType, string FrDt, string ToDt, string RoutingNo, string EmpName, string TransID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("SearchAudit", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.VarChar, 7);
            parameterClearingType.Value = ClearingType;
            myCommand.SelectCommand.Parameters.Add(parameterClearingType);

            SqlParameter parameterFrDt = new SqlParameter("@FrDt", SqlDbType.VarChar, 10);
            parameterFrDt.Value = FrDt;
            myCommand.SelectCommand.Parameters.Add(parameterFrDt);

            SqlParameter parameterToDt = new SqlParameter("@ToDt", SqlDbType.VarChar, 10);
            parameterToDt.Value = ToDt;
            myCommand.SelectCommand.Parameters.Add(parameterToDt);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterEmpName = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);
            parameterEmpName.Value = EmpName;
            myCommand.SelectCommand.Parameters.Add(parameterEmpName);

            SqlParameter parameterTransID = new SqlParameter("@TransID", SqlDbType.VarChar, 30);
            parameterTransID.Value = TransID;
            myCommand.SelectCommand.Parameters.Add(parameterTransID);


            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return dt;
        }

        //public DataTable AuditData(string TransID)
        //{
        //    SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
        //    SqlDataAdapter myCommand = new SqlDataAdapter("AuditData", myConnection);
        //    myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterTransID = new SqlParameter("@TransID", SqlDbType.VarChar, 35);
        //    parameterTransID.Value = TransID;
        //    myCommand.SelectCommand.Parameters.Add(parameterTransID);

        //    myConnection.Open();
        //    DataTable dt = new DataTable();
        //    myCommand.Fill(dt);

        //    myConnection.Close();
        //    myConnection.Dispose();
        //    myCommand.Dispose();

        //    return dt;
        //}


        public DataTable AuditData(string OutwardID)
        {
            Guid outid = new Guid(OutwardID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("AuditData", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier);
            parameterOutwardID.Value = outid;
            myCommand.SelectCommand.Parameters.Add(parameterOutwardID);

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

