using System;
using System.Data;
using System.Data.SqlClient;

namespace RTGSImporter
{
    class TeamBlueDB
    {
        public string InsertOutward009(Pacs009 pacs)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("MKR_InsertOutward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 20);
            parameterFrBICFI.Value = pacs.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 25);
            parameterToBICFI.Value = pacs.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 35);
            parameterMsgDefIdr.Value = pacs.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 20);
            parameterBizSvc.Value = pacs.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 30);
            parameterCreDt.Value = pacs.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterCreDtTm = new SqlParameter("@CreDtTm", SqlDbType.VarChar, 30);
            parameterCreDtTm.Value = pacs.CreDtTm;
            myCommand.Parameters.Add(parameterCreDtTm);

            SqlParameter parameterNbOfTxs = new SqlParameter("@NbOfTxs", SqlDbType.Int);
            parameterNbOfTxs.Value = pacs.NbOfTxs;
            myCommand.Parameters.Add(parameterNbOfTxs);

            SqlParameter parameterInstgAgtBICFI = new SqlParameter("@InstgAgtBICFI", SqlDbType.VarChar, 35);
            parameterInstgAgtBICFI.Value = pacs.InstgAgtBICFI;
            myCommand.Parameters.Add(parameterInstgAgtBICFI);

            SqlParameter parameterInstgAgtNm = new SqlParameter("@InstgAgtNm", SqlDbType.VarChar, 70);
            parameterInstgAgtNm.Value = pacs.InstgAgtNm;
            myCommand.Parameters.Add(parameterInstgAgtNm);

            SqlParameter parameterInstgAgtBranchId = new SqlParameter("@InstgAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstgAgtBranchId.Value = pacs.InstgAgtBranchId;
            myCommand.Parameters.Add(parameterInstgAgtBranchId);

            SqlParameter parameterInstdAgtBICFI = new SqlParameter("@InstdAgtBICFI", SqlDbType.VarChar, 35);
            parameterInstdAgtBICFI.Value = pacs.InstdAgtBICFI;
            myCommand.Parameters.Add(parameterInstdAgtBICFI);

            SqlParameter parameterInstdAgtNm = new SqlParameter("@InstdAgtNm", SqlDbType.VarChar, 70);
            parameterInstdAgtNm.Value = pacs.InstdAgtNm;
            myCommand.Parameters.Add(parameterInstdAgtNm);

            SqlParameter parameterInstdAgtBranchId = new SqlParameter("@InstdAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstdAgtBranchId.Value = pacs.InstdAgtBranchId;
            myCommand.Parameters.Add(parameterInstdAgtBranchId);

            SqlParameter parameterIntrmyAgt1BICFI = new SqlParameter("@IntrmyAgt1BICFI", SqlDbType.VarChar, 50);
            parameterIntrmyAgt1BICFI.Value = pacs.IntrmyAgt1BICFI;
            myCommand.Parameters.Add(parameterIntrmyAgt1BICFI);

            SqlParameter parameterIntrmyAgt1Nm = new SqlParameter("@IntrmyAgt1Nm", SqlDbType.VarChar, 70);
            parameterIntrmyAgt1Nm.Value = pacs.IntrmyAgt1Nm;
            myCommand.Parameters.Add(parameterIntrmyAgt1Nm);

            SqlParameter parameterIntrmyAgt1BranchId = new SqlParameter("@IntrmyAgt1BranchId", SqlDbType.VarChar, 50);
            parameterIntrmyAgt1BranchId.Value = pacs.IntrmyAgt1BranchId;
            myCommand.Parameters.Add(parameterIntrmyAgt1BranchId);

            SqlParameter parameterIntrmyAgt1AcctId = new SqlParameter("@IntrmyAgt1AcctId", SqlDbType.VarChar, 34);
            parameterIntrmyAgt1AcctId.Value = pacs.IntrmyAgt1AcctId;
            myCommand.Parameters.Add(parameterIntrmyAgt1AcctId);

            SqlParameter parameterIntrmyAgt1AcctTp = new SqlParameter("@IntrmyAgt1AcctTp", SqlDbType.VarChar, 50);
            parameterIntrmyAgt1AcctTp.Value = pacs.IntrmyAgt1AcctTp;
            myCommand.Parameters.Add(parameterIntrmyAgt1AcctTp);

            SqlParameter parameterLclInstrmPrtry = new SqlParameter("@LclInstrmPrtry", SqlDbType.VarChar, 35);
            parameterLclInstrmPrtry.Value = pacs.LclInstrmPrtry;
            myCommand.Parameters.Add(parameterLclInstrmPrtry);

            SqlParameter parameterSvcLvlPrtry = new SqlParameter("@SvcLvlPrtry", SqlDbType.VarChar, 35);
            parameterSvcLvlPrtry.Value = pacs.SvcLvlPrtry;
            myCommand.Parameters.Add(parameterSvcLvlPrtry);

            SqlParameter parameterCtgyPurpPrtry = new SqlParameter("@CtgyPurpPrtry", SqlDbType.VarChar, 35);
            parameterCtgyPurpPrtry.Value = pacs.CtgyPurpPrtry;
            myCommand.Parameters.Add(parameterCtgyPurpPrtry);

            SqlParameter parameterInstrId = new SqlParameter("@InstrId", SqlDbType.VarChar, 34);
            parameterInstrId.Value = pacs.InstrId;
            myCommand.Parameters.Add(parameterInstrId);

            SqlParameter parameterTxId = new SqlParameter("@TxId", SqlDbType.VarChar, 35);
            parameterTxId.Value = pacs.TxId;
            myCommand.Parameters.Add(parameterTxId);

            SqlParameter parameterEndToEndId = new SqlParameter("@EndToEndId", SqlDbType.VarChar, 35);
            parameterEndToEndId.Value = pacs.EndToEndId;
            myCommand.Parameters.Add(parameterEndToEndId);

            SqlParameter parameterIntrBkSttlmCcy = new SqlParameter("@IntrBkSttlmCcy", SqlDbType.VarChar, 3);
            parameterIntrBkSttlmCcy.Value = pacs.IntrBkSttlmCcy;
            myCommand.Parameters.Add(parameterIntrBkSttlmCcy);

            SqlParameter parameterIntrBkSttlmAmt = new SqlParameter("@IntrBkSttlmAmt", SqlDbType.Money);
            parameterIntrBkSttlmAmt.Value = pacs.IntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterIntrBkSttlmAmt);

            SqlParameter parameterIntrBkSttlmDt = new SqlParameter("@IntrBkSttlmDt", SqlDbType.VarChar, 10);
            parameterIntrBkSttlmDt.Value = pacs.IntrBkSttlmDt;
            myCommand.Parameters.Add(parameterIntrBkSttlmDt);

            SqlParameter parameterDbtrBICFI = new SqlParameter("@DbtrBICFI", SqlDbType.VarChar, 25);
            parameterDbtrBICFI.Value = pacs.DbtrBICFI;
            myCommand.Parameters.Add(parameterDbtrBICFI);

            SqlParameter parameterDbtrNm = new SqlParameter("@DbtrNm", SqlDbType.VarChar, 70);
            parameterDbtrNm.Value = pacs.DbtrNm;
            myCommand.Parameters.Add(parameterDbtrNm);

            SqlParameter parameterDbtrBranchId = new SqlParameter("@DbtrBranchId", SqlDbType.VarChar, 35);
            parameterDbtrBranchId.Value = pacs.DbtrBranchId;
            myCommand.Parameters.Add(parameterDbtrBranchId);

            SqlParameter parameterDbtrAcctId = new SqlParameter("@DbtrAcctId", SqlDbType.VarChar, 35);
            parameterDbtrAcctId.Value = pacs.DbtrAcctId;
            myCommand.Parameters.Add(parameterDbtrAcctId);

            SqlParameter parameterDbtrAcctTp = new SqlParameter("@DbtrAcctTp", SqlDbType.VarChar, 50);
            parameterDbtrAcctTp.Value = pacs.DbtrAcctTp;
            myCommand.Parameters.Add(parameterDbtrAcctTp);

            SqlParameter parameterCdtrAgtBICFI = new SqlParameter("@CdtrAgtBICFI", SqlDbType.VarChar, 35);
            parameterCdtrAgtBICFI.Value = pacs.CdtrAgtBICFI;
            myCommand.Parameters.Add(parameterCdtrAgtBICFI);

            SqlParameter parameterCdtrAgtBranchId = new SqlParameter("@CdtrAgtBranchId", SqlDbType.VarChar, 35);
            parameterCdtrAgtBranchId.Value = pacs.CdtrAgtBranchId;
            myCommand.Parameters.Add(parameterCdtrAgtBranchId);

            SqlParameter parameterCdtrAgtAcctId = new SqlParameter("@CdtrAgtAcctId", SqlDbType.VarChar, 34);
            parameterCdtrAgtAcctId.Value = pacs.CdtrAgtAcctId;
            myCommand.Parameters.Add(parameterCdtrAgtAcctId);

            SqlParameter parameterCdtrAgtAcctTp = new SqlParameter("@CdtrAgtAcctTp", SqlDbType.VarChar, 50);
            parameterCdtrAgtAcctTp.Value = pacs.CdtrAgtAcctTp;
            myCommand.Parameters.Add(parameterCdtrAgtAcctTp);

            SqlParameter parameterCdtrBICFI = new SqlParameter("@CdtrBICFI", SqlDbType.VarChar, 35);
            parameterCdtrBICFI.Value = pacs.CdtrBICFI;
            myCommand.Parameters.Add(parameterCdtrBICFI);

            SqlParameter parameterCdtrNm = new SqlParameter("@CdtrNm", SqlDbType.VarChar, 70);
            parameterCdtrNm.Value = pacs.CdtrNm;
            myCommand.Parameters.Add(parameterCdtrNm);

            SqlParameter parameterCdtrBranchId = new SqlParameter("@CdtrBranchId", SqlDbType.VarChar, 35);
            parameterCdtrBranchId.Value = pacs.CdtrBranchId;
            myCommand.Parameters.Add(parameterCdtrBranchId);

            SqlParameter parameterCdtrAcctId = new SqlParameter("@CdtrAcctId", SqlDbType.VarChar, 34);
            parameterCdtrAcctId.Value = pacs.CdtrAcctId;
            myCommand.Parameters.Add(parameterCdtrAcctId);

            SqlParameter parameterCdtrAcctTp = new SqlParameter("@CdtrAcctTp", SqlDbType.VarChar, 50);
            parameterCdtrAcctTp.Value = pacs.CdtrAcctTp;
            myCommand.Parameters.Add(parameterCdtrAcctTp);

            SqlParameter parameterInstrInf = new SqlParameter("@InstrInf", SqlDbType.VarChar, 140);
            parameterInstrInf.Value = pacs.InstrInf;
            myCommand.Parameters.Add(parameterInstrInf);

            SqlParameter parameterPmntRsn = new SqlParameter("@PmntRsn", SqlDbType.VarChar, 140);
            parameterPmntRsn.Value = pacs.PmntRsn;
            myCommand.Parameters.Add(parameterPmntRsn);

            SqlParameter parameterDeptId = new SqlParameter("@DeptId", SqlDbType.Int, 4);
            parameterDeptId.Value = pacs.DeptId;
            myCommand.Parameters.Add(parameterDeptId);

            SqlParameter parameterMaker = new SqlParameter("@Maker", SqlDbType.VarChar, 50);
            parameterMaker.Value = pacs.Maker;
            myCommand.Parameters.Add(parameterMaker);

            SqlParameter parameterMakerIP = new SqlParameter("@MakerIP", SqlDbType.VarChar, 50);
            parameterMakerIP.Value = pacs.MakerIP;
            myCommand.Parameters.Add(parameterMakerIP);

            SqlParameter parameterBrnchCD = new SqlParameter("@BrnchCD", SqlDbType.VarChar, 4);
            parameterBrnchCD.Value = pacs.BrnchCD;
            myCommand.Parameters.Add(parameterBrnchCD);

            SqlParameter parameterNoCBS = new SqlParameter("@NoCBS", SqlDbType.Bit);
            parameterNoCBS.Value = pacs.NoCBS;
            myCommand.Parameters.Add(parameterNoCBS);

            SqlParameter parameterOutwarID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwarID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterOutwarID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string OutwardID = parameterOutwarID.Value.ToString();

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return OutwardID;
        }
        public void UpdateOutward009(Pacs009 pacs)
        {
            Guid outid = new Guid(pacs.PacsID);

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("MKR_UpdateOutward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwarID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwarID.Value = outid;
            myCommand.Parameters.Add(parameterOutwarID);

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 20);
            parameterFrBICFI.Value = pacs.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 25);
            parameterToBICFI.Value = pacs.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 35);
            parameterMsgDefIdr.Value = pacs.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 20);
            parameterBizSvc.Value = pacs.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 30);
            parameterCreDt.Value = pacs.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterCreDtTm = new SqlParameter("@CreDtTm", SqlDbType.VarChar, 30);
            parameterCreDtTm.Value = pacs.CreDtTm;
            myCommand.Parameters.Add(parameterCreDtTm);

            SqlParameter parameterNbOfTxs = new SqlParameter("@NbOfTxs", SqlDbType.Int);
            parameterNbOfTxs.Value = pacs.NbOfTxs;
            myCommand.Parameters.Add(parameterNbOfTxs);

            SqlParameter parameterInstgAgtBICFI = new SqlParameter("@InstgAgtBICFI", SqlDbType.VarChar, 35);
            parameterInstgAgtBICFI.Value = pacs.InstgAgtBICFI;
            myCommand.Parameters.Add(parameterInstgAgtBICFI);

            SqlParameter parameterInstgAgtNm = new SqlParameter("@InstgAgtNm", SqlDbType.VarChar, 70);
            parameterInstgAgtNm.Value = pacs.InstgAgtNm;
            myCommand.Parameters.Add(parameterInstgAgtNm);

            SqlParameter parameterInstgAgtBranchId = new SqlParameter("@InstgAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstgAgtBranchId.Value = pacs.InstgAgtBranchId;
            myCommand.Parameters.Add(parameterInstgAgtBranchId);

            SqlParameter parameterInstdAgtBICFI = new SqlParameter("@InstdAgtBICFI", SqlDbType.VarChar, 35);
            parameterInstdAgtBICFI.Value = pacs.InstdAgtBICFI;
            myCommand.Parameters.Add(parameterInstdAgtBICFI);

            SqlParameter parameterInstdAgtNm = new SqlParameter("@InstdAgtNm", SqlDbType.VarChar, 70);
            parameterInstdAgtNm.Value = pacs.InstdAgtNm;
            myCommand.Parameters.Add(parameterInstdAgtNm);

            SqlParameter parameterInstdAgtBranchId = new SqlParameter("@InstdAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstdAgtBranchId.Value = pacs.InstdAgtBranchId;
            myCommand.Parameters.Add(parameterInstdAgtBranchId);

            SqlParameter parameterIntrmyAgt1BICFI = new SqlParameter("@IntrmyAgt1BICFI", SqlDbType.VarChar, 50);
            parameterIntrmyAgt1BICFI.Value = pacs.IntrmyAgt1BICFI;
            myCommand.Parameters.Add(parameterIntrmyAgt1BICFI);

            SqlParameter parameterIntrmyAgt1Nm = new SqlParameter("@IntrmyAgt1Nm", SqlDbType.VarChar, 70);
            parameterIntrmyAgt1Nm.Value = pacs.IntrmyAgt1Nm;
            myCommand.Parameters.Add(parameterIntrmyAgt1Nm);

            SqlParameter parameterIntrmyAgt1BranchId = new SqlParameter("@IntrmyAgt1BranchId", SqlDbType.VarChar, 50);
            parameterIntrmyAgt1BranchId.Value = pacs.IntrmyAgt1BranchId;
            myCommand.Parameters.Add(parameterIntrmyAgt1BranchId);

            SqlParameter parameterIntrmyAgt1AcctId = new SqlParameter("@IntrmyAgt1AcctId", SqlDbType.VarChar, 34);
            parameterIntrmyAgt1AcctId.Value = pacs.IntrmyAgt1AcctId;
            myCommand.Parameters.Add(parameterIntrmyAgt1AcctId);

            SqlParameter parameterIntrmyAgt1AcctTp = new SqlParameter("@IntrmyAgt1AcctTp", SqlDbType.VarChar, 50);
            parameterIntrmyAgt1AcctTp.Value = pacs.IntrmyAgt1AcctTp;
            myCommand.Parameters.Add(parameterIntrmyAgt1AcctTp);

            SqlParameter parameterLclInstrmPrtry = new SqlParameter("@LclInstrmPrtry", SqlDbType.VarChar, 35);
            parameterLclInstrmPrtry.Value = pacs.LclInstrmPrtry;
            myCommand.Parameters.Add(parameterLclInstrmPrtry);

            SqlParameter parameterSvcLvlPrtry = new SqlParameter("@SvcLvlPrtry", SqlDbType.VarChar, 35);
            parameterSvcLvlPrtry.Value = pacs.SvcLvlPrtry;
            myCommand.Parameters.Add(parameterSvcLvlPrtry);

            SqlParameter parameterCtgyPurpPrtry = new SqlParameter("@CtgyPurpPrtry", SqlDbType.VarChar, 35);
            parameterCtgyPurpPrtry.Value = pacs.CtgyPurpPrtry;
            myCommand.Parameters.Add(parameterCtgyPurpPrtry);

            SqlParameter parameterInstrId = new SqlParameter("@InstrId", SqlDbType.VarChar, 34);
            parameterInstrId.Value = pacs.InstrId;
            myCommand.Parameters.Add(parameterInstrId);

            SqlParameter parameterTxId = new SqlParameter("@TxId", SqlDbType.VarChar, 35);
            parameterTxId.Value = pacs.TxId;
            myCommand.Parameters.Add(parameterTxId);

            SqlParameter parameterEndToEndId = new SqlParameter("@EndToEndId", SqlDbType.VarChar, 35);
            parameterEndToEndId.Value = pacs.EndToEndId;
            myCommand.Parameters.Add(parameterEndToEndId);

            SqlParameter parameterIntrBkSttlmCcy = new SqlParameter("@IntrBkSttlmCcy", SqlDbType.VarChar, 3);
            parameterIntrBkSttlmCcy.Value = pacs.IntrBkSttlmCcy;
            myCommand.Parameters.Add(parameterIntrBkSttlmCcy);

            SqlParameter parameterIntrBkSttlmAmt = new SqlParameter("@IntrBkSttlmAmt", SqlDbType.Money);
            parameterIntrBkSttlmAmt.Value = pacs.IntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterIntrBkSttlmAmt);

            SqlParameter parameterIntrBkSttlmDt = new SqlParameter("@IntrBkSttlmDt", SqlDbType.VarChar, 10);
            parameterIntrBkSttlmDt.Value = pacs.IntrBkSttlmDt;
            myCommand.Parameters.Add(parameterIntrBkSttlmDt);

            SqlParameter parameterDbtrBICFI = new SqlParameter("@DbtrBICFI", SqlDbType.VarChar, 25);
            parameterDbtrBICFI.Value = pacs.DbtrBICFI;
            myCommand.Parameters.Add(parameterDbtrBICFI);

            SqlParameter parameterDbtrNm = new SqlParameter("@DbtrNm", SqlDbType.VarChar, 70);
            parameterDbtrNm.Value = pacs.DbtrNm;
            myCommand.Parameters.Add(parameterDbtrNm);

            SqlParameter parameterDbtrBranchId = new SqlParameter("@DbtrBranchId", SqlDbType.VarChar, 35);
            parameterDbtrBranchId.Value = pacs.DbtrBranchId;
            myCommand.Parameters.Add(parameterDbtrBranchId);

            SqlParameter parameterDbtrAcctId = new SqlParameter("@DbtrAcctId", SqlDbType.VarChar, 35);
            parameterDbtrAcctId.Value = pacs.DbtrAcctId;
            myCommand.Parameters.Add(parameterDbtrAcctId);

            SqlParameter parameterDbtrAcctTp = new SqlParameter("@DbtrAcctTp", SqlDbType.VarChar, 50);
            parameterDbtrAcctTp.Value = pacs.DbtrAcctTp;
            myCommand.Parameters.Add(parameterDbtrAcctTp);

            SqlParameter parameterCdtrAgtBICFI = new SqlParameter("@CdtrAgtBICFI", SqlDbType.VarChar, 35);
            parameterCdtrAgtBICFI.Value = pacs.CdtrAgtBICFI;
            myCommand.Parameters.Add(parameterCdtrAgtBICFI);

            SqlParameter parameterCdtrNm = new SqlParameter("@CdtrNm", SqlDbType.VarChar, 70);
            parameterCdtrNm.Value = pacs.CdtrNm;
            myCommand.Parameters.Add(parameterCdtrNm);

            SqlParameter parameterCdtrAgtBranchId = new SqlParameter("@CdtrAgtBranchId", SqlDbType.VarChar, 35);
            parameterCdtrAgtBranchId.Value = pacs.CdtrAgtBranchId;
            myCommand.Parameters.Add(parameterCdtrAgtBranchId);

            SqlParameter parameterCdtrAgtAcctId = new SqlParameter("@CdtrAgtAcctId", SqlDbType.VarChar, 34);
            parameterCdtrAgtAcctId.Value = pacs.CdtrAgtAcctId;
            myCommand.Parameters.Add(parameterCdtrAgtAcctId);

            SqlParameter parameterCdtrAgtAcctTp = new SqlParameter("@CdtrAgtAcctTp", SqlDbType.VarChar, 50);
            parameterCdtrAgtAcctTp.Value = pacs.CdtrAgtAcctTp;
            myCommand.Parameters.Add(parameterCdtrAgtAcctTp);

            SqlParameter parameterCdtrBICFI = new SqlParameter("@CdtrBICFI", SqlDbType.VarChar, 35);
            parameterCdtrBICFI.Value = pacs.CdtrBICFI;
            myCommand.Parameters.Add(parameterCdtrBICFI);

            SqlParameter parameterCdtrBranchId = new SqlParameter("@CdtrBranchId", SqlDbType.VarChar, 35);
            parameterCdtrBranchId.Value = pacs.CdtrBranchId;
            myCommand.Parameters.Add(parameterCdtrBranchId);

            SqlParameter parameterCdtrAcctId = new SqlParameter("@CdtrAcctId", SqlDbType.VarChar, 34);
            parameterCdtrAcctId.Value = pacs.CdtrAcctId;
            myCommand.Parameters.Add(parameterCdtrAcctId);

            SqlParameter parameterCdtrAcctTp = new SqlParameter("@CdtrAcctTp", SqlDbType.VarChar, 50);
            parameterCdtrAcctTp.Value = pacs.CdtrAcctTp;
            myCommand.Parameters.Add(parameterCdtrAcctTp);


            SqlParameter parameterInstrInf = new SqlParameter("@InstrInf", SqlDbType.VarChar, 140);
            parameterInstrInf.Value = pacs.InstrInf;
            myCommand.Parameters.Add(parameterInstrInf);

            SqlParameter parameterPmntRsn = new SqlParameter("@PmntRsn", SqlDbType.VarChar, 140);
            parameterPmntRsn.Value = pacs.PmntRsn;
            myCommand.Parameters.Add(parameterPmntRsn);

            SqlParameter parameterMaker = new SqlParameter("@Maker", SqlDbType.VarChar, 50);
            parameterMaker.Value = pacs.Maker;
            myCommand.Parameters.Add(parameterMaker);

            SqlParameter parameterMakerIP = new SqlParameter("@MakerIP", SqlDbType.VarChar, 50);
            parameterMakerIP.Value = pacs.MakerIP;
            myCommand.Parameters.Add(parameterMakerIP);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public Pacs009 GetSingleOutward09(string OutwardID)
        {
            Guid outid = new Guid(OutwardID);
            Pacs009 pacs = new Pacs009();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("GetSingleOutward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = outid;
            myCommand.Parameters.Add(parameterOutwardID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                pacs.PacsID     = dr["OutwardID"].ToString();
                pacs.DetectTime = dr["DetectTime"].ToString();
                pacs.FrBICFI    = (string)dr["FrBICFI"];
                pacs.ToBICFI    = (string)dr["ToBICFI"];
                pacs.BizMsgIdr  = (string)dr["BizMsgIdr"];
                pacs.MsgDefIdr  = (string)dr["MsgDefIdr"];
                pacs.BizSvc     = (string)dr["BizSvc"];
                pacs.CreDt      = (string)dr["CreDt"];
                pacs.MsgId      = (string)dr["MsgId"];
                pacs.CreDtTm    = (string)dr["CreDtTm"];
                pacs.NbOfTxs    = (int)dr["NbOfTxs"];

                pacs.LclInstrmPrtry     = (string)dr["LclInstrmPrtry"];
                pacs.SvcLvlPrtry        = (string)dr["SvcLvlPrtry"];
                pacs.CtgyPurpPrtry      = (string)dr["CtgyPurpPrtry"];
                pacs.InstrId            = (string)dr["InstrId"];
                pacs.TxId               = (string)dr["TxId"];
                pacs.EndToEndId         = (string)dr["EndToEndId"];
                pacs.IntrBkSttlmCcy     = (string)dr["IntrBkSttlmCcy"];
                pacs.IntrBkSttlmAmt     = (decimal)dr["IntrBkSttlmAmt"];
                pacs.IntrBkSttlmDt      = (string)dr["IntrBkSttlmDt"];

                pacs.InstgAgtBICFI      = (string)dr["InstgAgtBICFI"];
                pacs.InstgAgtNm         = (string)dr["InstgAgtNm"];
                pacs.InstgAgtBranchId   = (string)dr["InstgAgtBranchId"];

                pacs.InstdAgtBICFI      = (string)dr["InstdAgtBICFI"];
                pacs.InstdAgtNm         = (string)dr["InstdAgtNm"];
                pacs.InstdAgtBranchId   = (string)dr["InstdAgtBranchId"];

                pacs.IntrmyAgt1BICFI    = (string)dr["IntrmyAgt1BICFI"];
                pacs.IntrmyAgt1Nm       = (string)dr["IntrmyAgt1Nm"];
                pacs.IntrmyAgt1BranchId = (string)dr["IntrmyAgt1BranchId"];
                pacs.IntrmyAgt1AcctId   = (string)dr["IntrmyAgt1AcctId"];
                pacs.IntrmyAgt1AcctTp   = (string)dr["IntrmyAgt1AcctTp"];

                pacs.DbtrBICFI      = (string)dr["DbtrBICFI"];
                pacs.DbtrNm         = (string)dr["DbtrNm"];
                pacs.DbtrBranchId   = (string)dr["DbtrBranchId"];
                pacs.DbtrAcctId     = (string)dr["DbtrAcctId"];
                pacs.DbtrAcctTp     = (string)dr["DbtrAcctTp"];

                pacs.CdtrAgtBICFI   = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtBranchId= (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctId  = (string)dr["CdtrAgtAcctId"];
                pacs.CdtrAgtAcctTp  = (string)dr["CdtrAgtAcctTp"];

                pacs.CdtrBICFI      = (string)dr["CdtrBICFI"];
                pacs.CdtrNm         = (string)dr["CdtrNm"];
                pacs.CdtrBranchId   = (string)dr["CdtrBranchId"];
                pacs.CdtrAcctId     = (string)dr["CdtrAcctId"];
                pacs.CdtrAcctTp     = (string)dr["CdtrAcctTp"];

                pacs.InstrInf       = (string)dr["InstrInf"];
                pacs.PmntRsn        = (string)dr["PmntRsn"];
                pacs.ReturnReason = (string)dr["ReturnReason"];

                pacs.Maker          = (string)dr["Maker"];
                pacs.MakeTime       = dr["MakeTime"].ToString();
                pacs.MakerIP        = (string)dr["MakerIP"];
                pacs.Checker        = (string)dr["Checker"];
                pacs.CheckTime      = dr["CheckTime"].ToString();
                pacs.CheckerIP      = (string)dr["CheckerIP"];
                pacs.Admin          = (string)dr["Admin"];
                pacs.AdminTime      = dr["AdminTime"].ToString();
                pacs.AdminIP        = (string)dr["AdminIP"];
                pacs.DeletedBy      = (string)dr["DeletedBy"];
                pacs.DeleteTime     = dr["DeleteTime"].ToString();
                pacs.CBSResponse    = (string)dr["CBSResponse"];
                pacs.CBSTime        = dr["CBSTime"].ToString();
                pacs.StatusID       = (int)dr["StatusID"];
                pacs.NoCBS          = (bool)dr["NoCBS"];
            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return pacs;

        }
        public Pacs009 GetSingleCartOutward09(string OutwardID, string CartID)
        {
            Guid outid = new Guid(OutwardID);
            Pacs009 pacs = new Pacs009();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("GetSingleCartOutward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = outid;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = new Guid(CartID); ;
            myCommand.Parameters.Add(parameterCartID); 

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                pacs.PacsID = dr["OutwardID"].ToString();
                pacs.DetectTime = dr["DetectTime"].ToString();
                pacs.FrBICFI = (string)dr["FrBICFI"];
                pacs.ToBICFI = (string)dr["ToBICFI"];
                pacs.BizMsgIdr = (string)dr["BizMsgIdr"];
                pacs.MsgDefIdr = (string)dr["MsgDefIdr"];
                pacs.BizSvc = (string)dr["BizSvc"];
                pacs.CreDt = (string)dr["CreDt"];
                pacs.MsgId = (string)dr["MsgId"];
                pacs.CreDtTm = (string)dr["CreDtTm"];
                pacs.NbOfTxs = (int)dr["NbOfTxs"];

                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.SvcLvlPrtry = (string)dr["SvcLvlPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.InstrId = (string)dr["InstrId"];
                pacs.TxId = (string)dr["TxId"];
                pacs.EndToEndId = (string)dr["EndToEndId"];
                pacs.IntrBkSttlmCcy = (string)dr["IntrBkSttlmCcy"];
                pacs.IntrBkSttlmAmt = (decimal)dr["IntrBkSttlmAmt"];
                pacs.IntrBkSttlmDt = (string)dr["IntrBkSttlmDt"];

                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstgAgtNm = (string)dr["InstgAgtNm"];
                pacs.InstgAgtBranchId = (string)dr["InstgAgtBranchId"];

                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.InstdAgtNm = (string)dr["InstdAgtNm"];
                pacs.InstdAgtBranchId = (string)dr["InstdAgtBranchId"];

                pacs.IntrmyAgt1BICFI = (string)dr["IntrmyAgt1BICFI"];
                pacs.IntrmyAgt1Nm = (string)dr["IntrmyAgt1Nm"];
                pacs.IntrmyAgt1BranchId = (string)dr["IntrmyAgt1BranchId"];
                pacs.IntrmyAgt1AcctId = (string)dr["IntrmyAgt1AcctId"];
                pacs.IntrmyAgt1AcctTp = (string)dr["IntrmyAgt1AcctTp"];

                pacs.DbtrBICFI = (string)dr["DbtrBICFI"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrBranchId = (string)dr["DbtrBranchId"];
                pacs.DbtrAcctId = (string)dr["DbtrAcctId"];
                pacs.DbtrAcctTp = (string)dr["DbtrAcctTp"];

                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctId = (string)dr["CdtrAgtAcctId"];
                pacs.CdtrAgtAcctTp = (string)dr["CdtrAgtAcctTp"];

                pacs.CdtrBICFI = (string)dr["CdtrBICFI"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrBranchId = (string)dr["CdtrBranchId"];
                pacs.CdtrAcctId = (string)dr["CdtrAcctId"];
                pacs.CdtrAcctTp = (string)dr["CdtrAcctTp"];

                pacs.InstrInf = (string)dr["InstrInf"];
                pacs.PmntRsn = (string)dr["PmntRsn"];

                pacs.Maker = (string)dr["Maker"];
                pacs.MakeTime = dr["MakeTime"].ToString();
                pacs.MakerIP = (string)dr["MakerIP"];
                pacs.Checker = (string)dr["Checker"];
                pacs.CheckTime = dr["CheckTime"].ToString();
                pacs.CheckerIP = (string)dr["CheckerIP"];
                pacs.Admin = (string)dr["Admin"];
                pacs.AdminTime = dr["AdminTime"].ToString();
                pacs.AdminIP = (string)dr["AdminIP"];
                pacs.DeletedBy = (string)dr["DeletedBy"];
                pacs.DeleteTime = dr["DeleteTime"].ToString();
                pacs.CBSResponse = (string)dr["CBSResponse"];
                pacs.CBSTime = dr["CBSTime"].ToString();
                pacs.StatusID = (int)dr["StatusID"];
            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return pacs;

        }
        public Pacs009 GetSingleInward09(string InwardID)
        {
            Guid intid = new Guid(InwardID);
            Pacs009 pacs = new Pacs009();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("GetSingleInward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterInwardID = new SqlParameter("@InwardID", SqlDbType.UniqueIdentifier, 50);
            parameterInwardID.Value = intid;
            myCommand.Parameters.Add(parameterInwardID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                pacs.PacsID = dr["InwardID"].ToString();
                pacs.DetectTime = dr["DetectTime"].ToString();
                pacs.FrBICFI = (string)dr["FrBICFI"];
                pacs.ToBICFI = (string)dr["ToBICFI"];
                pacs.BizMsgIdr = (string)dr["BizMsgIdr"];
                pacs.MsgDefIdr = (string)dr["MsgDefIdr"];
                pacs.BizSvc = (string)dr["BizSvc"];
                pacs.CreDt = (string)dr["CreDt"];
                pacs.MsgId = (string)dr["MsgId"];
                pacs.CreDtTm = (string)dr["CreDtTm"];
                pacs.BtchBookg = (string)dr["BtchBookg"];
                pacs.TtlIntrBkSttlmAmt = (decimal)dr["TtlIntrBkSttlmAmt"];
                pacs.NbOfTxs = (int)dr["NbOfTxs"];
                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstgAgtNm = (string)dr["InstgAgtNm"];
                pacs.InstgAgtBranchId = (string)dr["InstgAgtBranchId"];
                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.InstdAgtNm = (string)dr["InstdAgtNm"];
                pacs.InstdAgtBranchId = (string)dr["InstdAgtBranchId"];
                pacs.IntrmyAgt1BICFI = (string)dr["IntrmyAgt1BICFI"];
                pacs.IntrmyAgt1Nm = (string)dr["IntrmyAgt1Nm"];
                pacs.IntrmyAgt1BranchId = (string)dr["IntrmyAgt1BranchId"];
                pacs.IntrmyAgt1AcctId = (string)dr["IntrmyAgt1AcctId"];
                pacs.IntrmyAgt1AcctTp = (string)dr["IntrmyAgt1AcctTp"];
                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.SvcLvlPrtry = (string)dr["SvcLvlPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.InstrId = (string)dr["InstrId"];
                pacs.TxId = (string)dr["TxId"];
                pacs.EndToEndId = (string)dr["EndToEndId"];
                pacs.IntrBkSttlmCcy = (string)dr["IntrBkSttlmCcy"];
                pacs.IntrBkSttlmAmt = (decimal)dr["IntrBkSttlmAmt"];
                pacs.IntrBkSttlmDt = (string)dr["IntrBkSttlmDt"];
                pacs.DbtrBICFI = (string)dr["DbtrBICFI"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrBranchId = (string)dr["DbtrBranchId"];
                pacs.DbtrAcctId = (string)dr["DbtrAcctId"];
                pacs.DbtrAcctTp = (string)dr["DbtrAcctTp"];
                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctId = (string)dr["CdtrAgtAcctId"];
                pacs.CdtrAgtAcctTp = (string)dr["CdtrAgtAcctTp"];
                pacs.CdtrBICFI = (string)dr["CdtrBICFI"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrBranchId = (string)dr["CdtrBranchId"];
                pacs.CdtrAcctId = (string)dr["CdtrAcctId"];
                pacs.CdtrAcctTp = (string)dr["CdtrAcctTp"];
                pacs.InstrInf = (string)dr["InstrInf"];
                pacs.PmntRsn = (string)dr["PmntRsn"];
                pacs.FrBankBIC = (string)dr["FrBankBIC"];
                pacs.FrBranchID = (string)dr["FrBranchID"];
                pacs.ToBranchID = (string)dr["ToBranchID"];
                pacs.Maker = (string)dr["Maker"];
                pacs.MakeTime = (string)dr["MakeTime"];
                pacs.MakerIP = (string)dr["MakerIP"];
                pacs.Checker = (string)dr["Checker"];
                pacs.CheckTime = (string)dr["CheckTime"];
                pacs.CheckerIP = (string)dr["CheckerIP"];
                pacs.Admin = (string)dr["Admin"];
                pacs.AdminTime = (string)dr["AdminTime"];
                pacs.AdminIP = (string)dr["AdminIP"];
                pacs.DeletedBy = (string)dr["DeletedBy"];
                pacs.DeleteTime = (string)dr["DeleteTime"];
                pacs.DeleteIP = (string)dr["DeleteIP"];
                pacs.ReturnedBy = (string)dr["ReturnedBy"];
                pacs.RetunTime = (string)dr["RetunTime"];
                pacs.ReturnReason = (string)dr["ReturnReason"];
                pacs.CBSResponse = (string)dr["CBSResponse"];
                pacs.CBSTime = (string)dr["CBSTime"];
                pacs.StatusID = (int)dr["StatusID"];
                pacs.StatusName = (string)dr["StatusName"];
                pacs.FrBranch = (string)dr["FrBranch"];
                pacs.ToBranch = (string)dr["ToBranch"];
            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return pacs;

        }
        public void ApproveOutward09(string OutwardID, string Checker, string CheckerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("CKR_ApproveOutward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = newGuid;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterChecker = new SqlParameter("@Checker", SqlDbType.VarChar, 50);
            parameterChecker.Value = Checker;
            myCommand.Parameters.Add(parameterChecker);

            SqlParameter parameterCheckerIP = new SqlParameter("@CheckerIP", SqlDbType.VarChar, 50);
            parameterCheckerIP.Value = CheckerIP;
            myCommand.Parameters.Add(parameterCheckerIP);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void AuthOutward09(string OutwardID, string Authorizer, string AuthorizerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("ATH_AuthOutward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = newGuid;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterAuthorizer = new SqlParameter("@Authorizer", SqlDbType.VarChar, 50);
            parameterAuthorizer.Value = Authorizer;
            myCommand.Parameters.Add(parameterAuthorizer);

            SqlParameter parameterAuthorizerIP = new SqlParameter("@AuthorizerIP", SqlDbType.VarChar, 50);
            parameterAuthorizerIP.Value = AuthorizerIP;
            myCommand.Parameters.Add(parameterAuthorizerIP);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void ReturnOutward09(string OutwardID, string ReturnReason, string Checker, string CheckerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("CKR_ReturnOutward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = newGuid;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterReturnReason = new SqlParameter("@ReturnReason", SqlDbType.VarChar, 50);
            parameterReturnReason.Value = ReturnReason;
            myCommand.Parameters.Add(parameterReturnReason);

            SqlParameter parameterChecker = new SqlParameter("@Checker", SqlDbType.VarChar, 50);
            parameterChecker.Value = Checker;
            myCommand.Parameters.Add(parameterChecker);

            SqlParameter parameterCheckerIP = new SqlParameter("@CheckerIP", SqlDbType.VarChar, 50);
            parameterCheckerIP.Value = CheckerIP;
            myCommand.Parameters.Add(parameterCheckerIP);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public void RejectOutward09(string OutwardID, string Checker, string CheckerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("CKR_RejectOutward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = newGuid;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterChecker = new SqlParameter("@Checker", SqlDbType.VarChar, 50);
            parameterChecker.Value = Checker;
            myCommand.Parameters.Add(parameterChecker);

            SqlParameter parameterCheckerIP = new SqlParameter("@CheckerIP", SqlDbType.VarChar, 50);
            parameterCheckerIP.Value = CheckerIP;
            myCommand.Parameters.Add(parameterCheckerIP);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void ReturnInward09(string InwardID, int DeptID, string Maker, string MakerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(InwardID);

            SqlCommand myCommand = new SqlCommand("CKR_ReturnInward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterInwardID = new SqlParameter("@InwardID", SqlDbType.UniqueIdentifier, 50);
            parameterInwardID.Value = newGuid;
            myCommand.Parameters.Add(parameterInwardID);

            SqlParameter parameterDeptID = new SqlParameter("@DeptID", SqlDbType.Int, 4);
            parameterDeptID.Value = DeptID;
            myCommand.Parameters.Add(parameterDeptID);

            SqlParameter parameterMaker = new SqlParameter("@Maker", SqlDbType.VarChar, 50);
            parameterMaker.Value = Maker;
            myCommand.Parameters.Add(parameterMaker);

            SqlParameter parameterMakerIP = new SqlParameter("@MakerIP", SqlDbType.VarChar, 50);
            parameterMakerIP.Value = MakerIP;
            myCommand.Parameters.Add(parameterMakerIP);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void SendOutward09(string OutwardID, string Admin, string AdminIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("ADM_SendOutward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = newGuid;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterAdmin = new SqlParameter("@Admin", SqlDbType.VarChar, 50);
            parameterAdmin.Value = Admin;
            myCommand.Parameters.Add(parameterAdmin);

            SqlParameter parameterAdminIP = new SqlParameter("@AdminIP", SqlDbType.VarChar, 50);
            parameterAdminIP.Value = AdminIP;
            myCommand.Parameters.Add(parameterAdminIP);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void DeleteOutward09(string OutwardID, string Maker, string MakerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("MKR_DeleteOutward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = newGuid;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterMaker = new SqlParameter("@Maker", SqlDbType.VarChar, 50);
            parameterMaker.Value = Maker;
            myCommand.Parameters.Add(parameterMaker);

            SqlParameter parameterMakerIP = new SqlParameter("@MakerIP", SqlDbType.VarChar, 50);
            parameterMakerIP.Value = MakerIP;
            myCommand.Parameters.Add(parameterMakerIP);


            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void TransferInward09(string InwardID, string NewAcctId, string Maker, string MakerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(InwardID);

            SqlCommand myCommand = new SqlCommand("MKR_TransferInward09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterInwardID = new SqlParameter("@InwardID", SqlDbType.UniqueIdentifier, 50);
            parameterInwardID.Value = newGuid;
            myCommand.Parameters.Add(parameterInwardID);

            SqlParameter parameteNewAcctId = new SqlParameter("@NewAcctId", SqlDbType.VarChar, 20);
            parameteNewAcctId.Value = NewAcctId;
            myCommand.Parameters.Add(parameteNewAcctId);

            SqlParameter parameterMaker = new SqlParameter("@Maker", SqlDbType.VarChar, 50);
            parameterMaker.Value = Maker;
            myCommand.Parameters.Add(parameterMaker);

            SqlParameter parameterMakerIP = new SqlParameter("@MakerIP", SqlDbType.VarChar, 50);
            parameterMakerIP.Value = MakerIP;
            myCommand.Parameters.Add(parameterMakerIP);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
    }
}
