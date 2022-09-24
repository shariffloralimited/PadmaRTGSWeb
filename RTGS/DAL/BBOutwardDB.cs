using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class BBOutwardDB
    {
        public void InsertBBOutwardDB(string MsgType, string BizMsgIdr, string MsgID, string RefMsgID, string RefTxId, string RefEndToEndId, string OutwardID, string FormName)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ADM_InsertBBOutward", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ParametersMsgType = new SqlParameter("@MsgType", SqlDbType.VarChar, 12);
            ParametersMsgType.Value = MsgType;
            myCommand.Parameters.Add(ParametersMsgType);

            SqlParameter ParametersBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 35);
            ParametersBizMsgIdr.Value = BizMsgIdr;
            myCommand.Parameters.Add(ParametersBizMsgIdr);

            SqlParameter ParametersMsgID = new SqlParameter("@MsgID", SqlDbType.VarChar, 35);
            ParametersMsgID.Value = MsgID;
            myCommand.Parameters.Add(ParametersMsgID);

            SqlParameter ParametersRefMsgID = new SqlParameter("@RefMsgID", SqlDbType.VarChar, 35);
            ParametersRefMsgID.Value = RefMsgID;
            myCommand.Parameters.Add(ParametersRefMsgID);

            SqlParameter ParametersRefTxId = new SqlParameter("@RefTxId", SqlDbType.VarChar, 35);
            ParametersRefTxId.Value = RefTxId;
            myCommand.Parameters.Add(ParametersRefTxId);

            SqlParameter ParametersRefEndToEndId = new SqlParameter("@RefEndToEndId", SqlDbType.VarChar, 35);
            ParametersRefEndToEndId.Value = RefEndToEndId;
            myCommand.Parameters.Add(ParametersRefEndToEndId);

            SqlParameter ParametersOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            ParametersOutwardID.Value = new Guid(OutwardID);
            myCommand.Parameters.Add(ParametersOutwardID);

            SqlParameter ParametersFormName = new SqlParameter("@FormName", SqlDbType.VarChar, 12);
            ParametersFormName.Value = FormName;
            myCommand.Parameters.Add(ParametersFormName);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
    }
}

