using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RTGS.DAC
{
    public class OutwardDB
    {
        public DataTable GetOutwardList(string RoutingNo, int StatusID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("GetListOutward", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            myCommand.SelectCommand.CommandTimeout = 950;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 20);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

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
        public DataTable GetOutwardDeptList(int DeptID, int StatusID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("GetListDeptOutward", myConnection);
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
        public void ReturnToMaker(string OutwardID, string FormType)
        {
            Guid outid = new Guid(OutwardID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ADM_ReturnToMaker", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = outid;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterFormType = new SqlParameter("@FormType", SqlDbType.VarChar, 10);
            parameterFormType.Value = FormType;
            myCommand.Parameters.Add(parameterFormType);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
        }
        public DataTable GetOutwardListForMaker(int BranchId)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetOutwardListForMaker", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBranchId = new SqlParameter("@BranchId", SqlDbType.Int, 4);
            parameterBranchId.Value = BranchId;
            myCommand.SelectCommand.Parameters.Add(parameterBranchId);

            myConnection.Open();

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }
        public DataTable GetOutwardSettlement(int BranchId, string CCy, int StatusID, string SttlmDt)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetOutwardSettlement", myConnection);
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
        public DataTable GetOutwardDeptSettlement(int DeptID, string CCy, int StatusID, string SttlmDt)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetOutwardDeptSettlement", myConnection);
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

        public DataTable GetOutwardMonthlySettlement(int BranchID, string CCy, int StatusID, string FrSettlementDate, string ToSettlementDate)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_GetOutwardMonthlySettlement", myConnection);
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
        public void AddToCart(string OutwardID, string FormName, string CartID, string Priority)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ADM_AddToCart", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = new Guid(OutwardID);
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterFormName = new SqlParameter("@FormName", SqlDbType.VarChar, 10);
            parameterFormName.Value = FormName;
            myCommand.Parameters.Add(parameterFormName); 
            
            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = new Guid(CartID);
            myCommand.Parameters.Add(parameterCartID);

            SqlParameter parameterPriority = new SqlParameter("@Priority", SqlDbType.VarChar, 3);
            parameterPriority.Value = Priority.PadLeft(3,'0');
            myCommand.Parameters.Add(parameterPriority);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        }
        public void EmptyCart()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ADM_EmptyCart", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        }

        public void ChangeStatus(string MsgId, int StatusId, string Admin, string AdminIP)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ADM_ChangeStatus", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterMsgId = new SqlParameter("@MsgId", SqlDbType.VarChar, 35);
            parameterMsgId.Value = MsgId;
            myCommand.Parameters.Add(parameterMsgId);

            SqlParameter parameterStatusId = new SqlParameter("@StatusId", SqlDbType.Int, 4);
            parameterStatusId.Value = StatusId;
            myCommand.Parameters.Add(parameterStatusId);

            SqlParameter parameterAdmin = new SqlParameter("@Admin", SqlDbType.VarChar, 50);
            parameterAdmin.Value = Admin;
            myCommand.Parameters.Add(parameterAdmin);

            SqlParameter parameterAdminIP = new SqlParameter("@AdminIP", SqlDbType.VarChar, 50);
            parameterAdminIP.Value = AdminIP;
            myCommand.Parameters.Add(parameterAdminIP); 
            
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        }


        public void DeleteAdnReverseCBS(string MsgId, string Admin, string AdminIP)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ADM_DeleteAdnReverseCBS", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterMsgId = new SqlParameter("@MsgId", SqlDbType.VarChar, 35);
            parameterMsgId.Value = MsgId;
            myCommand.Parameters.Add(parameterMsgId);

            SqlParameter parameterAdmin = new SqlParameter("@Admin", SqlDbType.VarChar, 50);
            parameterAdmin.Value = Admin;
            myCommand.Parameters.Add(parameterAdmin);

            SqlParameter parameterAdminIP = new SqlParameter("@AdminIP", SqlDbType.VarChar, 50);
            parameterAdminIP.Value = AdminIP;
            myCommand.Parameters.Add(parameterAdminIP);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        }

        public void UpdateBatchBooking(string CartID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ADM_UpdateBatchBooking", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = new Guid(CartID);
            myCommand.Parameters.Add(parameterCartID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        }

        public decimal GetWaitingAmount(string AccountNo)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_GetWaitingAmount", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterAccountNo = new SqlParameter("@AccountNo", SqlDbType.VarChar, 17);
            parameterAccountNo.Value = AccountNo;
            myCommand.Parameters.Add(parameterAccountNo);

            SqlParameter parameterAmount = new SqlParameter("@Amount", SqlDbType.Money);
            parameterAmount.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAmount);


            myConnection.Open();
            myCommand.ExecuteNonQuery();

            decimal Amount = (decimal)parameterAmount.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return Amount;
        }
    }
}