using System;
using System.Data;
using System.Data.SqlClient;

namespace RTGSImporter
{
    class TeamRedDB
    {
        public string InsertOutward008(Pacs008 pacs)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("MKR_InsertOutward08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 8);
            parameterFrBICFI.Value = pacs.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 12);
            parameterToBICFI.Value = pacs.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 16);
            parameterMsgDefIdr.Value = pacs.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 10);
            parameterBizSvc.Value = pacs.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 50);
            parameterCreDt.Value = pacs.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterCreDtTm = new SqlParameter("@CreDtTm", SqlDbType.VarChar, 50);
            parameterCreDtTm.Value = pacs.CreDtTm;
            myCommand.Parameters.Add(parameterCreDtTm);

            SqlParameter parameterBtchBookg = new SqlParameter("@BtchBookg", SqlDbType.VarChar, 8);
            parameterBtchBookg.Value = pacs.BtchBookg;
            myCommand.Parameters.Add(parameterBtchBookg);

            SqlParameter parameterNbOfTxs = new SqlParameter("@NbOfTxs", SqlDbType.Int);
            parameterNbOfTxs.Value = pacs.NbOfTxs;
            myCommand.Parameters.Add(parameterNbOfTxs);

            SqlParameter parameterInstrId = new SqlParameter("@InstrId", SqlDbType.VarChar, 35);
            parameterInstrId.Value = pacs.InstrId;
            myCommand.Parameters.Add(parameterInstrId);

            SqlParameter parameterEndToEndId = new SqlParameter("@EndToEndId", SqlDbType.VarChar, 35);
            parameterEndToEndId.Value = pacs.EndToEndId;
            myCommand.Parameters.Add(parameterEndToEndId);

            SqlParameter parameterTxId = new SqlParameter("@TxId", SqlDbType.VarChar, 35);
            parameterTxId.Value = pacs.TxId;
            myCommand.Parameters.Add(parameterTxId);

            SqlParameter parameterClrChanl = new SqlParameter("@ClrChanl", SqlDbType.VarChar, 10);
            parameterClrChanl.Value = pacs.ClrChanl;
            myCommand.Parameters.Add(parameterClrChanl);

            SqlParameter parameterSvcLvlPrtry = new SqlParameter("@SvcLvlPrtry", SqlDbType.Int);
            parameterSvcLvlPrtry.Value = pacs.SvcLvlPrtry;
            myCommand.Parameters.Add(parameterSvcLvlPrtry);

            SqlParameter parameterLclInstrmPrtry = new SqlParameter("@LclInstrmPrtry", SqlDbType.VarChar, 35);
            parameterLclInstrmPrtry.Value = pacs.LclInstrmPrtry;
            myCommand.Parameters.Add(parameterLclInstrmPrtry);

            SqlParameter parameterCtgyPurpPrtry = new SqlParameter("@CtgyPurpPrtry", SqlDbType.VarChar, 35);
            parameterCtgyPurpPrtry.Value = pacs.CtgyPurpPrtry;
            myCommand.Parameters.Add(parameterCtgyPurpPrtry);

            SqlParameter parameterCcy = new SqlParameter("@Ccy", SqlDbType.VarChar, 3);
            parameterCcy.Value = pacs.Ccy;
            myCommand.Parameters.Add(parameterCcy);

            SqlParameter parameterIntrBkSttlmAmt = new SqlParameter("@IntrBkSttlmAmt", SqlDbType.Money);
            parameterIntrBkSttlmAmt.Value = pacs.IntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterIntrBkSttlmAmt);

            SqlParameter parameterIntrBkSttlmDt = new SqlParameter("@IntrBkSttlmDt", SqlDbType.VarChar, 10);
            parameterIntrBkSttlmDt.Value = pacs.IntrBkSttlmDt;
            myCommand.Parameters.Add(parameterIntrBkSttlmDt);

            SqlParameter parameterChrgBr = new SqlParameter("@ChrgBr", SqlDbType.VarChar, 4);
            parameterChrgBr.Value = pacs.ChrgBr;
            myCommand.Parameters.Add(parameterChrgBr);

            SqlParameter parameterInstgAgtBICFI = new SqlParameter("@InstgAgtBICFI", SqlDbType.VarChar, 20);
            parameterInstgAgtBICFI.Value = pacs.InstgAgtBICFI;
            myCommand.Parameters.Add(parameterInstgAgtBICFI);

            SqlParameter parameterInstgAgtNm = new SqlParameter("@InstgAgtNm", SqlDbType.VarChar, 140);
            parameterInstgAgtNm.Value = pacs.InstgAgtNm;
            myCommand.Parameters.Add(parameterInstgAgtNm);

            SqlParameter parameterInstgAgtBranchId = new SqlParameter("@InstgAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstgAgtBranchId.Value = pacs.InstgAgtBranchId;
            myCommand.Parameters.Add(parameterInstgAgtBranchId);

            SqlParameter parameterInstdAgtBICFI = new SqlParameter("@InstdAgtBICFI", SqlDbType.VarChar, 8);
            parameterInstdAgtBICFI.Value = pacs.InstdAgtBICFI;
            myCommand.Parameters.Add(parameterInstdAgtBICFI);

            SqlParameter parameterInstdAgtNm = new SqlParameter("@InstdAgtNm", SqlDbType.VarChar, 140);
            parameterInstdAgtNm.Value = pacs.InstdAgtNm;
            myCommand.Parameters.Add(parameterInstdAgtNm);

            SqlParameter parameterInstdAgtBranchId = new SqlParameter("@InstdAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstdAgtBranchId.Value = pacs.InstdAgtBranchId;
            myCommand.Parameters.Add(parameterInstdAgtBranchId);

            SqlParameter parameterDbtrNm = new SqlParameter("@DbtrNm", SqlDbType.VarChar, 140);
            parameterDbtrNm.Value = pacs.DbtrNm;
            myCommand.Parameters.Add(parameterDbtrNm);

            SqlParameter parameterDbtrPstlAdr = new SqlParameter("@DbtrPstlAdr", SqlDbType.VarChar, 140);
            parameterDbtrPstlAdr.Value = pacs.DbtrPstlAdr;
            myCommand.Parameters.Add(parameterDbtrPstlAdr);

            SqlParameter parameterDbtrStrtNm = new SqlParameter("@DbtrStrtNm", SqlDbType.VarChar, 70);
            parameterDbtrStrtNm.Value = pacs.DbtrStrtNm;
            myCommand.Parameters.Add(parameterDbtrStrtNm);

            SqlParameter parameterDbtrTwnNm = new SqlParameter("@DbtrTwnNm", SqlDbType.VarChar, 35);
            parameterDbtrTwnNm.Value = pacs.DbtrTwnNm;
            myCommand.Parameters.Add(parameterDbtrTwnNm);

            SqlParameter parameterDbtrAdrLine = new SqlParameter("@DbtrAdrLine", SqlDbType.VarChar, 70);
            parameterDbtrAdrLine.Value = pacs.DbtrAdrLine;
            myCommand.Parameters.Add(parameterDbtrAdrLine);

            SqlParameter parameterDbtrCtry = new SqlParameter("@DbtrCtry", SqlDbType.VarChar, 20);
            parameterDbtrCtry.Value = pacs.DbtrCtry;
            myCommand.Parameters.Add(parameterDbtrCtry);

            SqlParameter parameterDbtrAcctOthrId = new SqlParameter("@DbtrAcctOthrId", SqlDbType.VarChar, 34);
            parameterDbtrAcctOthrId.Value = pacs.DbtrAcctOthrId;
            myCommand.Parameters.Add(parameterDbtrAcctOthrId);

            SqlParameter parameterDbtrAgtBICFI = new SqlParameter("@DbtrAgtBICFI", SqlDbType.VarChar, 8);
            parameterDbtrAgtBICFI.Value = pacs.DbtrAgtBICFI;
            myCommand.Parameters.Add(parameterDbtrAgtBICFI);

            SqlParameter parameterDbtrAgtNm = new SqlParameter("@DbtrAgtNm", SqlDbType.VarChar, 140);
            parameterDbtrAgtNm.Value = pacs.DbtrAgtNm;
            myCommand.Parameters.Add(parameterDbtrAgtNm);

            SqlParameter parameterDbtrAgtBranchId = new SqlParameter("@DbtrAgtBranchId", SqlDbType.VarChar, 20);
            parameterDbtrAgtBranchId.Value = pacs.DbtrAgtBranchId;
            myCommand.Parameters.Add(parameterDbtrAgtBranchId);

            SqlParameter parameterDbtrAgtAcctOthrId = new SqlParameter("@DbtrAgtAcctOthrId", SqlDbType.VarChar, 35);
            parameterDbtrAgtAcctOthrId.Value = pacs.DbtrAgtAcctOthrId;
            myCommand.Parameters.Add(parameterDbtrAgtAcctOthrId);

            SqlParameter parameterDbtrAgtAcctPrtry = new SqlParameter("@DbtrAgtAcctPrtry", SqlDbType.VarChar, 35);
            parameterDbtrAgtAcctPrtry.Value = pacs.DbtrAgtAcctPrtry;
            myCommand.Parameters.Add(parameterDbtrAgtAcctPrtry);

            SqlParameter parameterCdtrAgtBICFI = new SqlParameter("@CdtrAgtBICFI", SqlDbType.VarChar, 8);
            parameterCdtrAgtBICFI.Value = pacs.CdtrAgtBICFI;
            myCommand.Parameters.Add(parameterCdtrAgtBICFI);

            SqlParameter parameterCdtrAgtNm = new SqlParameter("@CdtrAgtNm", SqlDbType.VarChar, 140);
            parameterCdtrAgtNm.Value = pacs.CdtrAgtNm;
            myCommand.Parameters.Add(parameterCdtrAgtNm);

            SqlParameter parameterCdtrAgtBranchId = new SqlParameter("@CdtrAgtBranchId", SqlDbType.VarChar, 20);
            parameterCdtrAgtBranchId.Value = pacs.CdtrAgtBranchId;
            myCommand.Parameters.Add(parameterCdtrAgtBranchId);

            SqlParameter parameterCdtrAgtAcctOthrId = new SqlParameter("@CdtrAgtAcctOthrId", SqlDbType.VarChar, 35);
            parameterCdtrAgtAcctOthrId.Value = pacs.CdtrAgtAcctOthrId;
            myCommand.Parameters.Add(parameterCdtrAgtAcctOthrId);

            SqlParameter parameterCdtrAgtAcctPrtry = new SqlParameter("@CdtrAgtAcctPrtry", SqlDbType.VarChar, 35);
            parameterCdtrAgtAcctPrtry.Value = pacs.CdtrAgtAcctPrtry;
            myCommand.Parameters.Add(parameterCdtrAgtAcctPrtry);

            SqlParameter parameterCdtrNm = new SqlParameter("@CdtrNm", SqlDbType.VarChar, 140);
            parameterCdtrNm.Value = pacs.CdtrNm;
            myCommand.Parameters.Add(parameterCdtrNm);

            SqlParameter parameterCdtrPstlAdr = new SqlParameter("@CdtrPstlAdr", SqlDbType.VarChar, 140);
            parameterCdtrPstlAdr.Value = pacs.CdtrPstlAdr;
            myCommand.Parameters.Add(parameterCdtrPstlAdr);

            SqlParameter parameterCdtrStrtNm = new SqlParameter("@CdtrStrtNm", SqlDbType.VarChar, 70);
            parameterCdtrStrtNm.Value = pacs.CdtrStrtNm;
            myCommand.Parameters.Add(parameterCdtrStrtNm);

            SqlParameter parameterCdtrTwnNm = new SqlParameter("@CdtrTwnNm", SqlDbType.VarChar, 35);
            parameterCdtrTwnNm.Value = pacs.CdtrTwnNm;
            myCommand.Parameters.Add(parameterCdtrTwnNm);

            SqlParameter parameterCdtrAdrLine = new SqlParameter("@CdtrAdrLine", SqlDbType.VarChar, 70);
            parameterCdtrAdrLine.Value = pacs.CdtrAdrLine;
            myCommand.Parameters.Add(parameterCdtrAdrLine);

            SqlParameter parameterCdtrCtry = new SqlParameter("@CdtrCtry", SqlDbType.VarChar, 20);
            parameterCdtrCtry.Value = pacs.CdtrCtry;
            myCommand.Parameters.Add(parameterCdtrCtry);

            SqlParameter parameterCdtrAcctOthrId = new SqlParameter("@CdtrAcctOthrId", SqlDbType.VarChar, 34);
            parameterCdtrAcctOthrId.Value = pacs.CdtrAcctOthrId;
            myCommand.Parameters.Add(parameterCdtrAcctOthrId);

            SqlParameter parameterCdtrAcctPrtry = new SqlParameter("@CdtrAcctPrtry", SqlDbType.VarChar, 35);
            parameterCdtrAcctPrtry.Value = pacs.CdtrAcctPrtry;
            myCommand.Parameters.Add(parameterCdtrAcctPrtry);

            SqlParameter parameterInstrInf = new SqlParameter("@InstrInf", SqlDbType.VarChar, 140);
            parameterInstrInf.Value = pacs.InstrInf;
            myCommand.Parameters.Add(parameterInstrInf);

            SqlParameter parameterUstrd = new SqlParameter("@Ustrd", SqlDbType.VarChar, 140);
            parameterUstrd.Value = pacs.Ustrd;
            myCommand.Parameters.Add(parameterUstrd);

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

            SqlParameter parameterBrnchCD = new SqlParameter("@BrnchCD", SqlDbType.VarChar, 10);
            parameterBrnchCD.Value = pacs.BrnchCD;
            myCommand.Parameters.Add(parameterBrnchCD);

            SqlParameter parameterChargeWaived = new SqlParameter("@ChargeWaived", SqlDbType.Bit);
            parameterChargeWaived.Value = pacs.ChargeWaived;
            myCommand.Parameters.Add(parameterChargeWaived);

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

        public void UpdateOutward008(Pacs008 pacs)
        {
            Guid outid = new Guid(pacs.PacsID);

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("MKR_UpdateOutward08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwarID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwarID.Value = outid;
            myCommand.Parameters.Add(parameterOutwarID);

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 8);
            parameterFrBICFI.Value = pacs.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 12);
            parameterToBICFI.Value = pacs.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 16);
            parameterMsgDefIdr.Value = pacs.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 10);
            parameterBizSvc.Value = pacs.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 50);
            parameterCreDt.Value = pacs.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterCreDtTm = new SqlParameter("@CreDtTm", SqlDbType.VarChar, 50);
            parameterCreDtTm.Value = pacs.CreDtTm;
            myCommand.Parameters.Add(parameterCreDtTm);

            SqlParameter parameterBtchBookg = new SqlParameter("@BtchBookg", SqlDbType.VarChar, 8);
            parameterBtchBookg.Value = pacs.BtchBookg;
            myCommand.Parameters.Add(parameterBtchBookg);

            SqlParameter parameterNbOfTxs = new SqlParameter("@NbOfTxs", SqlDbType.Int);
            parameterNbOfTxs.Value = pacs.NbOfTxs;
            myCommand.Parameters.Add(parameterNbOfTxs);

            SqlParameter parameterInstrId = new SqlParameter("@InstrId", SqlDbType.VarChar, 35);
            parameterInstrId.Value = pacs.InstrId;
            myCommand.Parameters.Add(parameterInstrId);

            SqlParameter parameterEndToEndId = new SqlParameter("@EndToEndId", SqlDbType.VarChar, 35);
            parameterEndToEndId.Value = pacs.EndToEndId;
            myCommand.Parameters.Add(parameterEndToEndId);

            SqlParameter parameterTxId = new SqlParameter("@TxId", SqlDbType.VarChar, 35);
            parameterTxId.Value = pacs.TxId;
            myCommand.Parameters.Add(parameterTxId);

            SqlParameter parameterClrChanl = new SqlParameter("@ClrChanl", SqlDbType.VarChar, 10);
            parameterClrChanl.Value = pacs.ClrChanl;
            myCommand.Parameters.Add(parameterClrChanl);

            SqlParameter parameterSvcLvlPrtry = new SqlParameter("@SvcLvlPrtry", SqlDbType.Int);
            parameterSvcLvlPrtry.Value = pacs.SvcLvlPrtry;
            myCommand.Parameters.Add(parameterSvcLvlPrtry);

            SqlParameter parameterLclInstrmPrtry = new SqlParameter("@LclInstrmPrtry", SqlDbType.VarChar, 35);
            parameterLclInstrmPrtry.Value = pacs.LclInstrmPrtry;
            myCommand.Parameters.Add(parameterLclInstrmPrtry);

            SqlParameter parameterCtgyPurpPrtry = new SqlParameter("@CtgyPurpPrtry", SqlDbType.VarChar, 35);
            parameterCtgyPurpPrtry.Value = pacs.CtgyPurpPrtry;
            myCommand.Parameters.Add(parameterCtgyPurpPrtry);

            SqlParameter parameterCcy = new SqlParameter("@Ccy", SqlDbType.VarChar, 3);
            parameterCcy.Value = pacs.Ccy;
            myCommand.Parameters.Add(parameterCcy);

            SqlParameter parameterIntrBkSttlmAmt = new SqlParameter("@IntrBkSttlmAmt", SqlDbType.Money);
            parameterIntrBkSttlmAmt.Value = pacs.IntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterIntrBkSttlmAmt);

            SqlParameter parameterIntrBkSttlmDt = new SqlParameter("@IntrBkSttlmDt", SqlDbType.VarChar, 10);
            parameterIntrBkSttlmDt.Value = pacs.IntrBkSttlmDt;
            myCommand.Parameters.Add(parameterIntrBkSttlmDt);

            SqlParameter parameterChrgBr = new SqlParameter("@ChrgBr", SqlDbType.VarChar, 4);
            parameterChrgBr.Value = pacs.ChrgBr;
            myCommand.Parameters.Add(parameterChrgBr);

            SqlParameter parameterInstgAgtBICFI = new SqlParameter("@InstgAgtBICFI", SqlDbType.VarChar, 20);
            parameterInstgAgtBICFI.Value = pacs.InstgAgtBICFI;
            myCommand.Parameters.Add(parameterInstgAgtBICFI);

            SqlParameter parameterInstgAgtNm = new SqlParameter("@InstgAgtNm", SqlDbType.VarChar, 140);
            parameterInstgAgtNm.Value = pacs.InstgAgtNm;
            myCommand.Parameters.Add(parameterInstgAgtNm);

            SqlParameter parameterInstgAgtBranchId = new SqlParameter("@InstgAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstgAgtBranchId.Value = pacs.InstgAgtBranchId;
            myCommand.Parameters.Add(parameterInstgAgtBranchId);

            SqlParameter parameterInstdAgtBICFI = new SqlParameter("@InstdAgtBICFI", SqlDbType.VarChar, 8);
            parameterInstdAgtBICFI.Value = pacs.InstdAgtBICFI;
            myCommand.Parameters.Add(parameterInstdAgtBICFI);

            SqlParameter parameterInstdAgtNm = new SqlParameter("@InstdAgtNm", SqlDbType.VarChar, 140);
            parameterInstdAgtNm.Value = pacs.InstdAgtNm;
            myCommand.Parameters.Add(parameterInstdAgtNm);

            SqlParameter parameterInstdAgtBranchId = new SqlParameter("@InstdAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstdAgtBranchId.Value = pacs.InstdAgtBranchId;
            myCommand.Parameters.Add(parameterInstdAgtBranchId);

            SqlParameter parameterDbtrNm = new SqlParameter("@DbtrNm", SqlDbType.VarChar, 140);
            parameterDbtrNm.Value = pacs.DbtrNm;
            myCommand.Parameters.Add(parameterDbtrNm);

            SqlParameter parameterDbtrPstlAdr = new SqlParameter("@DbtrPstlAdr", SqlDbType.VarChar, 140);
            parameterDbtrPstlAdr.Value = pacs.DbtrPstlAdr;
            myCommand.Parameters.Add(parameterDbtrPstlAdr);

            SqlParameter parameterDbtrStrtNm = new SqlParameter("@DbtrStrtNm", SqlDbType.VarChar, 70);
            parameterDbtrStrtNm.Value = pacs.DbtrStrtNm;
            myCommand.Parameters.Add(parameterDbtrStrtNm);

            SqlParameter parameterDbtrTwnNm = new SqlParameter("@DbtrTwnNm", SqlDbType.VarChar, 35);
            parameterDbtrTwnNm.Value = pacs.DbtrTwnNm;
            myCommand.Parameters.Add(parameterDbtrTwnNm);

            SqlParameter parameterDbtrAdrLine = new SqlParameter("@DbtrAdrLine", SqlDbType.VarChar, 70);
            parameterDbtrAdrLine.Value = pacs.DbtrAdrLine;
            myCommand.Parameters.Add(parameterDbtrAdrLine);

            SqlParameter parameterDbtrCtry = new SqlParameter("@DbtrCtry", SqlDbType.VarChar, 20);
            parameterDbtrCtry.Value = pacs.DbtrCtry;
            myCommand.Parameters.Add(parameterDbtrCtry);

            SqlParameter parameterDbtrAcctOthrId = new SqlParameter("@DbtrAcctOthrId", SqlDbType.VarChar, 34);
            parameterDbtrAcctOthrId.Value = pacs.DbtrAcctOthrId;
            myCommand.Parameters.Add(parameterDbtrAcctOthrId);

            SqlParameter parameterDbtrAgtBICFI = new SqlParameter("@DbtrAgtBICFI", SqlDbType.VarChar, 8);
            parameterDbtrAgtBICFI.Value = pacs.DbtrAgtBICFI;
            myCommand.Parameters.Add(parameterDbtrAgtBICFI);

            SqlParameter parameterDbtrAgtNm = new SqlParameter("@DbtrAgtNm", SqlDbType.VarChar, 140);
            parameterDbtrAgtNm.Value = pacs.DbtrAgtNm;
            myCommand.Parameters.Add(parameterDbtrAgtNm);

            SqlParameter parameterDbtrAgtBranchId = new SqlParameter("@DbtrAgtBranchId", SqlDbType.VarChar, 20);
            parameterDbtrAgtBranchId.Value = pacs.DbtrAgtBranchId;
            myCommand.Parameters.Add(parameterDbtrAgtBranchId);

            SqlParameter parameterDbtrAgtAcctOthrId = new SqlParameter("@DbtrAgtAcctOthrId", SqlDbType.VarChar, 35);
            parameterDbtrAgtAcctOthrId.Value = pacs.DbtrAgtAcctOthrId;
            myCommand.Parameters.Add(parameterDbtrAgtAcctOthrId);

            SqlParameter parameterDbtrAgtAcctPrtry = new SqlParameter("@DbtrAgtAcctPrtry", SqlDbType.VarChar, 35);
            parameterDbtrAgtAcctPrtry.Value = pacs.DbtrAgtAcctPrtry;
            myCommand.Parameters.Add(parameterDbtrAgtAcctPrtry);

            SqlParameter parameterCdtrAgtBICFI = new SqlParameter("@CdtrAgtBICFI", SqlDbType.VarChar, 8);
            parameterCdtrAgtBICFI.Value = pacs.CdtrAgtBICFI;
            myCommand.Parameters.Add(parameterCdtrAgtBICFI);

            SqlParameter parameterCdtrAgtNm = new SqlParameter("@CdtrAgtNm", SqlDbType.VarChar, 140);
            parameterCdtrAgtNm.Value = pacs.CdtrAgtNm;
            myCommand.Parameters.Add(parameterCdtrAgtNm);

            SqlParameter parameterCdtrAgtBranchId = new SqlParameter("@CdtrAgtBranchId", SqlDbType.VarChar, 20);
            parameterCdtrAgtBranchId.Value = pacs.CdtrAgtBranchId;
            myCommand.Parameters.Add(parameterCdtrAgtBranchId);

            SqlParameter parameterCdtrAgtAcctOthrId = new SqlParameter("@CdtrAgtAcctOthrId", SqlDbType.VarChar, 35);
            parameterCdtrAgtAcctOthrId.Value = pacs.CdtrAgtAcctOthrId;
            myCommand.Parameters.Add(parameterCdtrAgtAcctOthrId);

            SqlParameter parameterCdtrAgtAcctPrtry = new SqlParameter("@CdtrAgtAcctPrtry", SqlDbType.VarChar, 35);
            parameterCdtrAgtAcctPrtry.Value = pacs.CdtrAgtAcctPrtry;
            myCommand.Parameters.Add(parameterCdtrAgtAcctPrtry);

            SqlParameter parameterCdtrNm = new SqlParameter("@CdtrNm", SqlDbType.VarChar, 140);
            parameterCdtrNm.Value = pacs.CdtrNm;
            myCommand.Parameters.Add(parameterCdtrNm);

            SqlParameter parameterCdtrPstlAdr = new SqlParameter("@CdtrPstlAdr", SqlDbType.VarChar, 140);
            parameterCdtrPstlAdr.Value = pacs.CdtrPstlAdr;
            myCommand.Parameters.Add(parameterCdtrPstlAdr);

            SqlParameter parameterCdtrStrtNm = new SqlParameter("@CdtrStrtNm", SqlDbType.VarChar, 70);
            parameterCdtrStrtNm.Value = pacs.CdtrStrtNm;
            myCommand.Parameters.Add(parameterCdtrStrtNm);

            SqlParameter parameterCdtrTwnNm = new SqlParameter("@CdtrTwnNm", SqlDbType.VarChar, 35);
            parameterCdtrTwnNm.Value = pacs.CdtrTwnNm;
            myCommand.Parameters.Add(parameterCdtrTwnNm);

            SqlParameter parameterCdtrAdrLine = new SqlParameter("@CdtrAdrLine", SqlDbType.VarChar, 70);
            parameterCdtrAdrLine.Value = pacs.CdtrAdrLine;
            myCommand.Parameters.Add(parameterCdtrAdrLine);

            SqlParameter parameterCdtrCtry = new SqlParameter("@CdtrCtry", SqlDbType.VarChar, 20);
            parameterCdtrCtry.Value = pacs.CdtrCtry;
            myCommand.Parameters.Add(parameterCdtrCtry);

            SqlParameter parameterCdtrAcctOthrId = new SqlParameter("@CdtrAcctOthrId", SqlDbType.VarChar, 34);
            parameterCdtrAcctOthrId.Value = pacs.CdtrAcctOthrId;
            myCommand.Parameters.Add(parameterCdtrAcctOthrId);

            SqlParameter parameterCdtrAcctPrtry = new SqlParameter("@CdtrAcctPrtry", SqlDbType.VarChar, 35);
            parameterCdtrAcctPrtry.Value = pacs.CdtrAcctPrtry;
            myCommand.Parameters.Add(parameterCdtrAcctPrtry);

            SqlParameter parameterInstrInf = new SqlParameter("@InstrInf", SqlDbType.VarChar, 140);
            parameterInstrInf.Value = pacs.InstrInf;
            myCommand.Parameters.Add(parameterInstrInf);

            SqlParameter parameterUstrd = new SqlParameter("@Ustrd", SqlDbType.VarChar, 140);
            parameterUstrd.Value = pacs.Ustrd;
            myCommand.Parameters.Add(parameterUstrd);

            SqlParameter parameterPmntRsn = new SqlParameter("@PmntRsn", SqlDbType.VarChar, 140);
            parameterPmntRsn.Value = pacs.PmntRsn;
            myCommand.Parameters.Add(parameterPmntRsn);

            SqlParameter parameterMaker = new SqlParameter("@Maker", SqlDbType.VarChar, 50);
            parameterMaker.Value = pacs.Maker;
            myCommand.Parameters.Add(parameterMaker);

            SqlParameter parameterMakerIP = new SqlParameter("@MakerIP", SqlDbType.VarChar, 50);
            parameterMakerIP.Value = pacs.MakerIP;
            myCommand.Parameters.Add(parameterMakerIP);
            SqlParameter parameterOrginatorACType = new SqlParameter("@OrginatorACType", SqlDbType.VarChar, 30);
            parameterOrginatorACType.Value = pacs.OrginatorACType;
            myCommand.Parameters.Add(parameterOrginatorACType);
            SqlParameter parameterReceiverACType = new SqlParameter("@ReceiverACType", SqlDbType.VarChar, 30);
            parameterReceiverACType.Value = pacs.ReceiverACType;
            myCommand.Parameters.Add(parameterReceiverACType);
            SqlParameter parameterPurposeOfTransaction = new SqlParameter("@PurposeOfTransaction", SqlDbType.VarChar, 30);
            parameterPurposeOfTransaction.Value = pacs.PurposeOfTransaction;
            myCommand.Parameters.Add(parameterPurposeOfTransaction);
            SqlParameter parameterOtherInfo = new SqlParameter("@OtherInfo", SqlDbType.VarChar, 30);
            parameterOtherInfo.Value = pacs.OtherInfo;
            myCommand.Parameters.Add(parameterOtherInfo);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

        }
        public Pacs008 GetSingleOutward08(string OutwardID)
        {
            Guid outid = new Guid(OutwardID);
            Pacs008 pacs = new Pacs008();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("GetSingleOutward08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = outid;
            myCommand.Parameters.Add(parameterOutwardID);

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
                pacs.BtchBookg = (string)dr["BtchBookg"];
                pacs.NbOfTxs = (int)dr["NbOfTxs"];
                pacs.InstrId = (string)dr["InstrId"];
                pacs.EndToEndId = (string)dr["EndToEndId"];
                pacs.TxId = (string)dr["TxId"];
                pacs.ClrChanl = (string)dr["ClrChanl"];
                pacs.SvcLvlPrtry = (int)dr["SvcLvlPrtry"];
                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.Ccy = (string)dr["Ccy"];
                pacs.IntrBkSttlmAmt = (decimal)dr["IntrBkSttlmAmt"];
                pacs.IntrBkSttlmDt = (string)dr["IntrBkSttlmDt"];
                pacs.ChrgBr = (string)dr["ChrgBr"];
                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstgAgtNm = (string)dr["InstgAgtNm"];
                pacs.InstgAgtBranchId = (string)dr["InstgAgtBranchId"];
                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.InstdAgtNm = (string)dr["InstdAgtNm"];
                pacs.InstdAgtBranchId = (string)dr["InstdAgtBranchId"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrPstlAdr = (string)dr["DbtrPstlAdr"];
                pacs.DbtrStrtNm = (string)dr["DbtrStrtNm"];
                pacs.DbtrTwnNm = (string)dr["DbtrTwnNm"];
                pacs.DbtrAdrLine = (string)dr["DbtrAdrLine"];
                pacs.DbtrCtry = (string)dr["DbtrCtry"];
                pacs.DbtrAcctOthrId = (string)dr["DbtrAcctOthrId"];
                pacs.DbtrAgtBICFI = (string)dr["DbtrAgtBICFI"];
                pacs.DbtrAgtNm = (string)dr["DbtrAgtNm"];
                pacs.DbtrAgtBranchId = (string)dr["DbtrAgtBranchId"];
                pacs.DbtrAgtAcctOthrId = (string)dr["DbtrAgtAcctOthrId"];
                pacs.DbtrAgtAcctPrtry = (string)dr["DbtrAgtAcctPrtry"];
                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtNm = (string)dr["CdtrAgtNm"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctOthrId = (string)dr["CdtrAgtAcctOthrId"];
                pacs.CdtrAgtAcctPrtry = (string)dr["CdtrAgtAcctPrtry"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrPstlAdr = (string)dr["CdtrPstlAdr"];
                pacs.CdtrStrtNm = (string)dr["CdtrStrtNm"];
                pacs.CdtrTwnNm = (string)dr["CdtrTwnNm"];
                pacs.CdtrAdrLine = (string)dr["CdtrAdrLine"];
                pacs.CdtrCtry = (string)dr["CdtrCtry"];
                pacs.CdtrAcctOthrId = (string)dr["CdtrAcctOthrId"];
                pacs.CdtrAcctPrtry = (string)dr["CdtrAcctPrtry"];
                pacs.InstrInf = (string)dr["InstrInf"];
                pacs.Ustrd = (string)dr["Ustrd"];
                pacs.PmntRsn = (string)dr["PmntRsn"];
                pacs.ReturnReason = (string)dr["ReturnReason"];
                pacs.Maker = (string)dr["Maker"];
                pacs.MakeTime = dr["MakeTime"].ToString();
                pacs.MakerIP = (string)dr["MakerIP"];
                pacs.Checker = (string)dr["Checker"];
                pacs.CheckTime = dr["CheckTime"].ToString();
                pacs.CheckerIP = (string)dr["CheckerIP"];
                pacs.DeletedBy = (string)dr["DeletedBy"];
                pacs.DeleteTime = dr["DeleteTime"].ToString();
                pacs.CBSResponse = (string)dr["CBSResponse"];
                pacs.CBSTime = dr["CBSTime"].ToString();
                pacs.StatusID = (int)dr["StatusID"];
                pacs.FrBranch = (string)dr["FrBranch"];
                pacs.ToBranch = (string)dr["ToBranch"];
                pacs.ChargeWaived = (bool)dr["ChargeWaived"];
                pacs.OrginatorACType = (string)dr["OrginatorACType"];
                pacs.ReceiverACType = (string)dr["ReceiverACType"];
                pacs.PurposeOfTransaction = (string)dr["PurposeOfTransaction"];
                pacs.OtherInfo = (string)dr["OtherInfo"];
            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return pacs;

        }
        public Pacs008 GetSingleCartOutward08(string OutwardID, string CartID)
        {
            Pacs008 pacs = new Pacs008();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("GetSingleCartOutward08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = new Guid(OutwardID);;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = new Guid(CartID);;
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
                pacs.BtchBookg = (string)dr["BtchBookg"];
                pacs.BatchBookingID = dr["BatchBookingID"].ToString();
                pacs.NbOfTxs = (int)dr["NbOfTxs"];
                pacs.TtlIntrBkSttlmAmt = (decimal)dr["TtlIntrBkSttlmAmt"];
                pacs.InstrId = (string)dr["InstrId"];
                pacs.EndToEndId = (string)dr["EndToEndId"];
                pacs.TxId = (string)dr["TxId"];
                pacs.ClrChanl = (string)dr["ClrChanl"];
                pacs.SvcLvlPrtry = (int)dr["SvcLvlPrtry"];
                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.Ccy = (string)dr["Ccy"];
                pacs.IntrBkSttlmAmt = (decimal)dr["IntrBkSttlmAmt"];
                pacs.IntrBkSttlmDt = (string)dr["IntrBkSttlmDt"];
                pacs.ChrgBr = (string)dr["ChrgBr"];
                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstgAgtNm = (string)dr["InstgAgtNm"];
                pacs.InstgAgtBranchId = (string)dr["InstgAgtBranchId"];
                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.InstdAgtNm = (string)dr["InstdAgtNm"];
                pacs.InstdAgtBranchId = (string)dr["InstdAgtBranchId"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrPstlAdr = (string)dr["DbtrPstlAdr"];
                pacs.DbtrStrtNm = (string)dr["DbtrStrtNm"];
                pacs.DbtrTwnNm = (string)dr["DbtrTwnNm"];
                pacs.DbtrAdrLine = (string)dr["DbtrAdrLine"];
                pacs.DbtrCtry = (string)dr["DbtrCtry"];
                pacs.DbtrAcctOthrId = (string)dr["DbtrAcctOthrId"];
                pacs.DbtrAgtBICFI = (string)dr["DbtrAgtBICFI"];
                pacs.DbtrAgtNm = (string)dr["DbtrAgtNm"];
                pacs.DbtrAgtBranchId = (string)dr["DbtrAgtBranchId"];
                pacs.DbtrAgtAcctOthrId = (string)dr["DbtrAgtAcctOthrId"];
                pacs.DbtrAgtAcctPrtry = (string)dr["DbtrAgtAcctPrtry"];
                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtNm = (string)dr["CdtrAgtNm"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctOthrId = (string)dr["CdtrAgtAcctOthrId"];
                pacs.CdtrAgtAcctPrtry = (string)dr["CdtrAgtAcctPrtry"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrPstlAdr = (string)dr["CdtrPstlAdr"];
                pacs.CdtrStrtNm = (string)dr["CdtrStrtNm"];
                pacs.CdtrTwnNm = (string)dr["CdtrTwnNm"];
                pacs.CdtrAdrLine = (string)dr["CdtrAdrLine"];
                pacs.CdtrCtry = (string)dr["CdtrCtry"];
                pacs.CdtrAcctOthrId = (string)dr["CdtrAcctOthrId"];
                pacs.CdtrAcctPrtry = (string)dr["CdtrAcctPrtry"];
                pacs.InstrInf = (string)dr["InstrInf"];
                pacs.Ustrd = (string)dr["Ustrd"];
                pacs.PmntRsn = (string)dr["PmntRsn"];
                pacs.Maker = (string)dr["Maker"];
                pacs.MakeTime = dr["MakeTime"].ToString();
                pacs.MakerIP = (string)dr["MakerIP"];
                pacs.Checker = (string)dr["Checker"];
                pacs.CheckTime = dr["CheckTime"].ToString();
                pacs.CheckerIP = (string)dr["CheckerIP"];
                pacs.DeletedBy = (string)dr["DeletedBy"];
                pacs.DeleteTime = dr["DeleteTime"].ToString();
                pacs.CBSResponse = (string)dr["CBSResponse"];
                pacs.CBSTime = dr["CBSTime"].ToString();
                pacs.StatusID = (int)dr["StatusID"];
                pacs.FrBranch = (string)dr["FrBranch"];
                pacs.ToBranch = (string)dr["ToBranch"];
                //update for FCY
                pacs.OrginatorACType = (string)dr["OrginatorACType"];
                pacs.ReceiverACType = (string)dr["ReceiverACType"];
                pacs.PurposeOfTransaction = (string)dr["PurposeOfTransaction"];
                pacs.OtherInfo = (string)dr["OtherInfo"];
                //end

            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return pacs;

        }
        public Pacs008 GetSingleOutward08ByBatchBookingID(string BatchBookingID, int Counter)
        {
            Pacs008 pacs = new Pacs008();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("GetSingleOutward08ByBatchBookingID", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@BatchBookingID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = new Guid(BatchBookingID); ;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterCounter = new SqlParameter("@Counter", SqlDbType.Int, 4);
            parameterCounter.Value = Counter;
            myCommand.Parameters.Add(parameterCounter);

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
                pacs.BtchBookg = (string)dr["BtchBookg"];
                pacs.NbOfTxs = (int)dr["NbOfTxs"];
                pacs.InstrId = (string)dr["InstrId"];
                pacs.EndToEndId = (string)dr["EndToEndId"];
                pacs.TxId = (string)dr["TxId"];
                pacs.ClrChanl = (string)dr["ClrChanl"];
                pacs.SvcLvlPrtry = (int)dr["SvcLvlPrtry"];
                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.Ccy = (string)dr["Ccy"];
                pacs.IntrBkSttlmAmt = (decimal)dr["IntrBkSttlmAmt"];
                pacs.IntrBkSttlmDt = (string)dr["IntrBkSttlmDt"];
                pacs.ChrgBr = (string)dr["ChrgBr"];
                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstgAgtNm = (string)dr["InstgAgtNm"];
                pacs.InstgAgtBranchId = (string)dr["InstgAgtBranchId"];
                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.InstdAgtNm = (string)dr["InstdAgtNm"];
                pacs.InstdAgtBranchId = (string)dr["InstdAgtBranchId"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrPstlAdr = (string)dr["DbtrPstlAdr"];
                pacs.DbtrStrtNm = (string)dr["DbtrStrtNm"];
                pacs.DbtrTwnNm = (string)dr["DbtrTwnNm"];
                pacs.DbtrAdrLine = (string)dr["DbtrAdrLine"];
                pacs.DbtrCtry = (string)dr["DbtrCtry"];
                pacs.DbtrAcctOthrId = (string)dr["DbtrAcctOthrId"];
                pacs.DbtrAgtBICFI = (string)dr["DbtrAgtBICFI"];
                pacs.DbtrAgtNm = (string)dr["DbtrAgtNm"];
                pacs.DbtrAgtBranchId = (string)dr["DbtrAgtBranchId"];
                pacs.DbtrAgtAcctOthrId = (string)dr["DbtrAgtAcctOthrId"];
                pacs.DbtrAgtAcctPrtry = (string)dr["DbtrAgtAcctPrtry"];
                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtNm = (string)dr["CdtrAgtNm"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctOthrId = (string)dr["CdtrAgtAcctOthrId"];
                pacs.CdtrAgtAcctPrtry = (string)dr["CdtrAgtAcctPrtry"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrPstlAdr = (string)dr["CdtrPstlAdr"];
                pacs.CdtrStrtNm = (string)dr["CdtrStrtNm"];
                pacs.CdtrTwnNm = (string)dr["CdtrTwnNm"];
                pacs.CdtrAdrLine = (string)dr["CdtrAdrLine"];
                pacs.CdtrCtry = (string)dr["CdtrCtry"];
                pacs.CdtrAcctOthrId = (string)dr["CdtrAcctOthrId"];
                pacs.CdtrAcctPrtry = (string)dr["CdtrAcctPrtry"];
                pacs.InstrInf = (string)dr["InstrInf"];
                pacs.Ustrd = (string)dr["Ustrd"];
                pacs.Maker = (string)dr["Maker"];
                pacs.MakeTime = dr["MakeTime"].ToString();
                pacs.MakerIP = (string)dr["MakerIP"];
                pacs.Checker = (string)dr["Checker"];
                pacs.CheckTime = dr["CheckTime"].ToString();
                pacs.CheckerIP = (string)dr["CheckerIP"];
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

        public Pacs008 GetSingleInward08(string InwardID)
        {
            Guid inid = new Guid(InwardID);
            Pacs008 pacs = new Pacs008();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("GetSingleInward08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@InwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = inid;
            myCommand.Parameters.Add(parameterOutwardID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                pacs.PacsID = dr["InwardID"].ToString();
                pacs.DetectTime = dr["DetectTime"].ToString();
                pacs.FileName = (string)dr["FileName"];
                pacs.FrBICFI = (string)dr["FrBICFI"];
                pacs.ToBICFI = (string)dr["ToBICFI"];
                pacs.BizMsgIdr = (string)dr["BizMsgIdr"];
                pacs.MsgDefIdr = (string)dr["MsgDefIdr"];
                pacs.BizSvc = (string)dr["BizSvc"];
                pacs.CreDt = (string)dr["CreDt"];
                pacs.MsgId = (string)dr["MsgId"];
                pacs.CreDtTm = (string)dr["CreDtTm"];
                pacs.BtchBookg = (string)dr["BtchBookg"];
                pacs.NbOfTxs = (int)dr["NbOfTxs"];
                pacs.InstrId = (string)dr["InstrId"];
                pacs.EndToEndId = (string)dr["EndToEndId"];
                pacs.TxId = (string)dr["TxId"];
                pacs.ClrChanl = (string)dr["ClrChanl"];
                pacs.SvcLvlPrtry = (int)dr["SvcLvlPrtry"];
                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.Ccy = (string)dr["Ccy"];
                pacs.IntrBkSttlmAmt = (decimal)dr["IntrBkSttlmAmt"];
                pacs.IntrBkSttlmDt = (string)dr["IntrBkSttlmDt"];
                pacs.ChrgBr = (string)dr["ChrgBr"];
                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstgAgtNm = (string)dr["InstgAgtNm"];
                pacs.InstgAgtBranchId = (string)dr["InstgAgtBranchId"];
                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.InstdAgtNm = (string)dr["InstdAgtNm"];
                pacs.InstdAgtBranchId = (string)dr["InstdAgtBranchId"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrPstlAdr = (string)dr["DbtrPstlAdr"];
                pacs.DbtrStrtNm = (string)dr["DbtrStrtNm"];
                pacs.DbtrTwnNm = (string)dr["DbtrTwnNm"];
                pacs.DbtrAdrLine = (string)dr["DbtrAdrLine"];
                pacs.DbtrCtry = (string)dr["DbtrCtry"];
                pacs.DbtrAcctOthrId = (string)dr["DbtrAcctOthrId"];
                pacs.DbtrAgtBICFI = (string)dr["DbtrAgtBICFI"];
                pacs.DbtrAgtNm = (string)dr["DbtrAgtNm"];
                pacs.DbtrAgtBranchId = (string)dr["DbtrAgtBranchId"];
                pacs.DbtrAgtAcctOthrId = (string)dr["DbtrAgtAcctOthrId"];
                pacs.DbtrAgtAcctPrtry = (string)dr["DbtrAgtAcctPrtry"];
                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtNm = (string)dr["CdtrAgtNm"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctOthrId = (string)dr["CdtrAgtAcctOthrId"];
                pacs.CdtrAgtAcctPrtry = (string)dr["CdtrAgtAcctPrtry"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrPstlAdr = (string)dr["CdtrPstlAdr"];
                pacs.CdtrStrtNm = (string)dr["CdtrStrtNm"];
                pacs.CdtrTwnNm = (string)dr["CdtrTwnNm"];
                pacs.CdtrAdrLine = (string)dr["CdtrAdrLine"];
                pacs.CdtrCtry = (string)dr["CdtrCtry"];
                pacs.CdtrAcctOthrId = (string)dr["CdtrAcctOthrId"];
                pacs.CdtrAcctPrtry = (string)dr["CdtrAcctPrtry"];
                pacs.InstrInf = (string)dr["InstrInf"];
                pacs.Ustrd = (string)dr["Ustrd"];
                pacs.Maker = (string)dr["Maker"];
                pacs.MakeTime = dr["MakeTime"].ToString();
                pacs.MakerIP = (string)dr["MakerIP"];
                pacs.Checker = (string)dr["Checker"];
                pacs.CheckTime = dr["CheckTime"].ToString();
                pacs.CheckerIP = (string)dr["CheckerIP"];
                pacs.DeletedBy = (string)dr["DeletedBy"];
                pacs.DeleteTime = dr["DeleteTime"].ToString();
                pacs.CBSResponse = (string)dr["CBSResponse"];
                pacs.CBSTime = dr["CBSTime"].ToString();
                pacs.FrBranch = (string)dr["FrBranch"];
                pacs.ToBranch = (string)dr["ToBranch"];
                pacs.FrBankBIC = (string)dr["FrBankBIC"];
                pacs.FrBank = (string)dr["FrBank"];
                pacs.StatusID = (int)dr["StatusID"];
            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return pacs;

        }
        public void ApproveOutward08(string OutwardID, string Checker, string CheckerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("CKR_ApproveOutward08", myConnection);
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
        public void AuthOutward08(string OutwardID, string Authorizer, string AuthorizerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("ATH_AuthOutward08", myConnection);
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
        public void ReturnOutward08(string OutwardID, string ReturnReason, string Checker, string CheckerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("CKR_ReturnOutward08", myConnection);
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
        public void ReturnInward08(string InwardID, int DeptID, string Maker, string MakerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(InwardID);

            SqlCommand myCommand = new SqlCommand("CKR_ReturnInward08", myConnection);
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
        public void SendOutward08(string OutwardID, string Admin, string AdminIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("ADM_SendOutward08", myConnection);
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
        public void DeleteOutward08(string OutwardID, string Maker, string MakerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("MKR_DeleteOutward08", myConnection);
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

        public void RetryInwardCBS(string InwardID, string Maker, string MakerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            Guid newGuid = new Guid(InwardID);

            SqlCommand myCommand = new SqlCommand("MKR_RetryInwardCBS08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@InwardID", SqlDbType.UniqueIdentifier, 50);
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

        public void TransferInward08(string InwardID, string NewAcctId, string Maker, string MakerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(InwardID);

            SqlCommand myCommand = new SqlCommand("MKR_TransferInward08", myConnection);
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


        public void ApproveInward08(string InwardID, string Maker, string MakerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            Guid newGuid = new Guid(InwardID);

            SqlCommand myCommand = new SqlCommand("MKR_ApproveInward08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@InwardID", SqlDbType.UniqueIdentifier, 50);
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
    }
}
