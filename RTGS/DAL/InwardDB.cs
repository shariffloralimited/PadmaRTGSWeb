using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RTGS.DAC
{
    public class InwardDB
    {
        public DataTable GetInwardList(string RoutingNo, int StatusID, string Form, decimal Amount)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("GetListInward", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBranchId = new SqlParameter("@BranchId", SqlDbType.VarChar, 9);
            parameterBranchId.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterBranchId);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            parameterStatusID.Value = StatusID;
            myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterForm = new SqlParameter("@Form", SqlDbType.VarChar, 10);
            parameterForm.Value = Form;
            myCommand.SelectCommand.Parameters.Add(parameterForm);
            myConnection.Open();

            SqlParameter parameterAmount = new SqlParameter("@Amount", SqlDbType.Money);
            parameterAmount.Value = Amount;
            myCommand.SelectCommand.Parameters.Add(parameterAmount);

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }

        public DataTable GetInwardDeptList(int DeptID, int StatusID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("GetListDeptInward", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterDeptID = new SqlParameter("@DeptID", SqlDbType.Int, 4);
            parameterDeptID.Value = DeptID;
            myCommand.SelectCommand.Parameters.Add(parameterDeptID);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            parameterStatusID.Value = StatusID;
            myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            myConnection.Open();

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }
        public DataTable GetInwardSettlement(int BranchId, string CCy, int StatusID, string SttlmDt)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetInwardSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBranchId = new SqlParameter("@BranchId", SqlDbType.Int, 4);
            parameterBranchId.Value = BranchId;
            myCommand.SelectCommand.Parameters.Add(parameterBranchId);

            SqlParameter parameterCCy = new SqlParameter("@CCy", SqlDbType.VarChar, 3);
            parameterCCy.Value = CCy;
            myCommand.SelectCommand.Parameters.Add(parameterCCy);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            parameterStatusID.Value = StatusID;
            myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterSttlmDt = new SqlParameter("@SttlmDt", SqlDbType.VarChar, 10);
            parameterSttlmDt.Value = SttlmDt;
            myCommand.SelectCommand.Parameters.Add(parameterSttlmDt);
            myConnection.Open();

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }

        public DataTable GetInwardDeptSettlement(int DeptID, string CCy, int StatusID, string SttlmDt)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetInwardDeptSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterDeptID = new SqlParameter("@DeptID", SqlDbType.Int, 4);
            parameterDeptID.Value = DeptID;
            myCommand.SelectCommand.Parameters.Add(parameterDeptID);

            SqlParameter parameterCCy = new SqlParameter("@CCy", SqlDbType.VarChar, 3);
            parameterCCy.Value = CCy;
            myCommand.SelectCommand.Parameters.Add(parameterCCy);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            parameterStatusID.Value = StatusID;
            myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterSttlmDt = new SqlParameter("@SttlmDt", SqlDbType.VarChar, 10);
            parameterSttlmDt.Value = SttlmDt;
            myCommand.SelectCommand.Parameters.Add(parameterSttlmDt);
            myConnection.Open();

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }
        public DataTable GetInwardMonthlySettlement(int BranchID, string CCy, int StatusID, string FrSettlementDate, string ToSettlementDate)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetInwardMonthlySettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBranchID = new SqlParameter("@BranchID", SqlDbType.Int, 4);
            parameterBranchID.Value = BranchID;
            myCommand.SelectCommand.Parameters.Add(parameterBranchID);

            SqlParameter parameterCCy = new SqlParameter("@CCy", SqlDbType.VarChar, 3);
            parameterCCy.Value = CCy;
            myCommand.SelectCommand.Parameters.Add(parameterCCy);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            parameterStatusID.Value = StatusID;
            myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterFrSettlementDate = new SqlParameter("@FrSettlementDate", SqlDbType.VarChar, 10);
            parameterFrSettlementDate.Value = FrSettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterFrSettlementDate);

            SqlParameter parameterToSettlementDate = new SqlParameter("@ToSettlementDate", SqlDbType.VarChar, 10);
            parameterToSettlementDate.Value = ToSettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterToSettlementDate);
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