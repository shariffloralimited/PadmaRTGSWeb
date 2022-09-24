using System;
using System.Data;
using System.Data.SqlClient;

namespace RTGSImporter
{
    class TeamGreenDB
    {
        public void InsertOutward004(Pacs004 pacs)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("MKR_InsertOutward04", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 20);
            parameterFrBICFI.Value = pacs.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 25);
            parameterToBICFI.Value = pacs.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 20);
            parameterMsgDefIdr.Value = pacs.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 17);
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

            SqlParameter parameterOrgnlMsgId = new SqlParameter("@OrgnlMsgId", SqlDbType.VarChar, 35);
            parameterOrgnlMsgId.Value = pacs.OrgnlMsgId;
            myCommand.Parameters.Add(parameterOrgnlMsgId);

            SqlParameter parameterOrgnlMsgNmId = new SqlParameter("@OrgnlMsgNmId", SqlDbType.VarChar, 35);
            parameterOrgnlMsgNmId.Value = pacs.OrgnlMsgNmId;
            myCommand.Parameters.Add(parameterOrgnlMsgNmId);

            SqlParameter parameterOrgnlCreDtTm = new SqlParameter("@OrgnlCreDtTm", SqlDbType.VarChar, 30);
            parameterOrgnlCreDtTm.Value = pacs.OrgnlCreDtTm;
            myCommand.Parameters.Add(parameterOrgnlCreDtTm);

            SqlParameter parameterRtrRsnOrgtrNm = new SqlParameter("@RtrRsnOrgtrNm", SqlDbType.VarChar, 140);
            parameterRtrRsnOrgtrNm.Value = pacs.RtrRsnOrgtrNm;
            myCommand.Parameters.Add(parameterRtrRsnOrgtrNm);

            SqlParameter parameterRtrRsnCd = new SqlParameter("@RtrRsnCd", SqlDbType.VarChar, 10);
            parameterRtrRsnCd.Value = pacs.RtrRsnCd;
            myCommand.Parameters.Add(parameterRtrRsnCd);

            SqlParameter parameterRtrRsnPrtry = new SqlParameter("@RtrRsnPrtry", SqlDbType.VarChar, 35);
            parameterRtrRsnPrtry.Value = pacs.RtrRsnPrtry;
            myCommand.Parameters.Add(parameterRtrRsnPrtry);

            SqlParameter parameterRtrRsnAddtlInf = new SqlParameter("@RtrRsnAddtlInf", SqlDbType.VarChar, 105);
            parameterRtrRsnAddtlInf.Value = pacs.RtrRsnAddtlInf;
            myCommand.Parameters.Add(parameterRtrRsnAddtlInf);

            SqlParameter parameterRtrId = new SqlParameter("@RtrId", SqlDbType.VarChar, 35);
            parameterRtrId.Value = pacs.RtrId;
            myCommand.Parameters.Add(parameterRtrId);

            SqlParameter parameterOrgnlInstrId = new SqlParameter("@OrgnlInstrId", SqlDbType.VarChar, 35);
            parameterOrgnlInstrId.Value = pacs.OrgnlInstrId;
            myCommand.Parameters.Add(parameterOrgnlInstrId);

            SqlParameter parameterOrgnlEndToEndId = new SqlParameter("@OrgnlEndToEndId", SqlDbType.VarChar, 35);
            parameterOrgnlEndToEndId.Value = pacs.OrgnlEndToEndId;
            myCommand.Parameters.Add(parameterOrgnlEndToEndId);

            SqlParameter parameterOrgnlTxId = new SqlParameter("@OrgnlTxId", SqlDbType.VarChar, 35);
            parameterOrgnlTxId.Value = pacs.OrgnlTxId;
            myCommand.Parameters.Add(parameterOrgnlTxId);

            SqlParameter parameterRtrdIntrBkSttlmCcy = new SqlParameter("@RtrdIntrBkSttlmCcy", SqlDbType.VarChar, 3);
            parameterRtrdIntrBkSttlmCcy.Value = pacs.RtrdIntrBkSttlmCcy;
            myCommand.Parameters.Add(parameterRtrdIntrBkSttlmCcy);

            SqlParameter parameterRtrdIntrBkSttlmAmt = new SqlParameter("@RtrdIntrBkSttlmAmt", SqlDbType.Money);
            parameterRtrdIntrBkSttlmAmt.Value = pacs.RtrdIntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterRtrdIntrBkSttlmAmt);

            SqlParameter parameterTxInfIntrBkSttlmDt = new SqlParameter("@TxInfIntrBkSttlmDt", SqlDbType.VarChar, 30);
            parameterTxInfIntrBkSttlmDt.Value = pacs.TxInfIntrBkSttlmDt;
            myCommand.Parameters.Add(parameterTxInfIntrBkSttlmDt);

            SqlParameter parameterChrgBr = new SqlParameter("@ChrgBr", SqlDbType.VarChar, 4);
            parameterChrgBr.Value = pacs.ChrgBr;
            myCommand.Parameters.Add(parameterChrgBr);

            SqlParameter parameterChrgsInfBICFI = new SqlParameter("@ChrgsInfBICFI", SqlDbType.VarChar, 8);
            parameterChrgsInfBICFI.Value = pacs.ChrgsInfBICFI;
            myCommand.Parameters.Add(parameterChrgsInfBICFI);

            SqlParameter parameterChrgsInfNm = new SqlParameter("@ChrgsInfNm", SqlDbType.VarChar, 15);
            parameterChrgsInfNm.Value = pacs.ChrgsInfNm;
            myCommand.Parameters.Add(parameterChrgsInfNm);

            SqlParameter parameterChrgsInfBranchId = new SqlParameter("@ChrgsInfBranchId", SqlDbType.VarChar, 25);
            parameterChrgsInfBranchId.Value = pacs.ChrgsInfBranchId;
            myCommand.Parameters.Add(parameterChrgsInfBranchId);

            SqlParameter parameterInstgAgtBICFI = new SqlParameter("@InstgAgtBICFI", SqlDbType.VarChar, 8);
            parameterInstgAgtBICFI.Value = pacs.InstgAgtBICFI;
            myCommand.Parameters.Add(parameterInstgAgtBICFI);

            SqlParameter parameterInstdAgtBICFI = new SqlParameter("@InstdAgtBICFI", SqlDbType.VarChar, 8);
            parameterInstdAgtBICFI.Value = pacs.InstdAgtBICFI;
            myCommand.Parameters.Add(parameterInstdAgtBICFI);

            SqlParameter parameterTxRefIntrBkSttlmCcy = new SqlParameter("@TxRefIntrBkSttlmCcy", SqlDbType.VarChar, 7);
            parameterTxRefIntrBkSttlmCcy.Value = pacs.TxRefIntrBkSttlmCcy;
            myCommand.Parameters.Add(parameterTxRefIntrBkSttlmCcy);

            SqlParameter parameterTxRefIntrBkSttlmAmt = new SqlParameter("@TxRefIntrBkSttlmAmt", SqlDbType.Money);
            parameterTxRefIntrBkSttlmAmt.Value = pacs.TxRefIntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterTxRefIntrBkSttlmAmt);

            SqlParameter parameterTxRefIntrBkSttlmDt = new SqlParameter("@TxRefIntrBkSttlmDt", SqlDbType.VarChar, 10);
            parameterTxRefIntrBkSttlmDt.Value = pacs.TxRefIntrBkSttlmDt;
            myCommand.Parameters.Add(parameterTxRefIntrBkSttlmDt);

            SqlParameter parameterSvcLvlPrtry = new SqlParameter("@SvcLvlPrtry", SqlDbType.Int);
            parameterSvcLvlPrtry.Value = pacs.SvcLvlPrtry;
            myCommand.Parameters.Add(parameterSvcLvlPrtry);

            SqlParameter parameterLclInstrmPrtry = new SqlParameter("@LclInstrmPrtry", SqlDbType.VarChar, 35);
            parameterLclInstrmPrtry.Value = pacs.LclInstrmPrtry;
            myCommand.Parameters.Add(parameterLclInstrmPrtry);

            SqlParameter parameterCtgyPurpPrtry = new SqlParameter("@CtgyPurpPrtry", SqlDbType.VarChar, 35);
            parameterCtgyPurpPrtry.Value = pacs.CtgyPurpPrtry;
            myCommand.Parameters.Add(parameterCtgyPurpPrtry);

            SqlParameter parameterPmtMtd = new SqlParameter("@PmtMtd", SqlDbType.VarChar, 4);
            parameterPmtMtd.Value = pacs.PmtMtd;
            myCommand.Parameters.Add(parameterPmtMtd);

            SqlParameter parameterRmtInfUstrd = new SqlParameter("@RmtInfUstrd", SqlDbType.VarChar, 140);
            parameterRmtInfUstrd.Value = pacs.RmtInfUstrd;
            myCommand.Parameters.Add(parameterRmtInfUstrd);

            SqlParameter parameterDbtrNm = new SqlParameter("@DbtrNm", SqlDbType.VarChar, 50);
            parameterDbtrNm.Value = pacs.DbtrNm;
            myCommand.Parameters.Add(parameterDbtrNm);

            SqlParameter parameterDbtrNmPstlAdr = new SqlParameter("@DbtrNmPstlAdr", SqlDbType.VarChar, 30);
            parameterDbtrNmPstlAdr.Value = pacs.DbtrNmPstlAdr;
            myCommand.Parameters.Add(parameterDbtrNmPstlAdr);

            SqlParameter parameterDbtrNmStrtNm = new SqlParameter("@DbtrNmStrtNm", SqlDbType.VarChar, 15);
            parameterDbtrNmStrtNm.Value = pacs.DbtrNmStrtNm;
            myCommand.Parameters.Add(parameterDbtrNmStrtNm);

            SqlParameter parameterDbtrNmTwnNm = new SqlParameter("@DbtrNmTwnNm", SqlDbType.VarChar, 15);
            parameterDbtrNmTwnNm.Value = pacs.DbtrNmTwnNm;
            myCommand.Parameters.Add(parameterDbtrNmTwnNm);

            SqlParameter parameterDbtrNmCtry = new SqlParameter("@DbtrNmCtry", SqlDbType.VarChar, 15);
            parameterDbtrNmCtry.Value = pacs.DbtrNmCtry;
            myCommand.Parameters.Add(parameterDbtrNmCtry);

            SqlParameter parameterDbtrNmAdrLine = new SqlParameter("@DbtrNmAdrLine", SqlDbType.VarChar, 70);
            parameterDbtrNmAdrLine.Value = pacs.DbtrNmAdrLine;
            myCommand.Parameters.Add(parameterDbtrNmAdrLine);

            SqlParameter parameterDbtrAcctId = new SqlParameter("@DbtrAcctId", SqlDbType.VarChar, 24);
            parameterDbtrAcctId.Value = pacs.DbtrAcctId;
            myCommand.Parameters.Add(parameterDbtrAcctId);

            SqlParameter parameterDbtrAcctTpPrtry = new SqlParameter("@DbtrAcctTpPrtry", SqlDbType.VarChar, 35);
            parameterDbtrAcctTpPrtry.Value = pacs.DbtrAcctTpPrtry;
            myCommand.Parameters.Add(parameterDbtrAcctTpPrtry);

            SqlParameter parameterDbtrAgtBICFINm = new SqlParameter("@DbtrAgtBICFINm", SqlDbType.VarChar, 140);
            parameterDbtrAgtBICFINm.Value = pacs.DbtrAgtBICFINm;
            myCommand.Parameters.Add(parameterDbtrAgtBICFINm);

            SqlParameter parameterDbtrAgtBICFI = new SqlParameter("@DbtrAgtBICFI", SqlDbType.VarChar, 8);
            parameterDbtrAgtBICFI.Value = pacs.DbtrAgtBICFI;
            myCommand.Parameters.Add(parameterDbtrAgtBICFI);

            SqlParameter parameterDbtrAgtBranchId = new SqlParameter("@DbtrAgtBranchId", SqlDbType.VarChar, 35);
            parameterDbtrAgtBranchId.Value = pacs.DbtrAgtBranchId;
            myCommand.Parameters.Add(parameterDbtrAgtBranchId);

            SqlParameter parameterDbtrAgtAcctId = new SqlParameter("@DbtrAgtAcctId", SqlDbType.VarChar, 24);
            parameterDbtrAgtAcctId.Value = pacs.DbtrAgtAcctId;
            myCommand.Parameters.Add(parameterDbtrAgtAcctId);

            SqlParameter parameterDbtrAgtAcctPrtry = new SqlParameter("@DbtrAgtAcctPrtry", SqlDbType.VarChar, 35);
            parameterDbtrAgtAcctPrtry.Value = pacs.DbtrAgtAcctPrtry;
            myCommand.Parameters.Add(parameterDbtrAgtAcctPrtry);

            SqlParameter parameterCdtrAgtBICFI = new SqlParameter("@CdtrAgtBICFI", SqlDbType.VarChar, 8);
            parameterCdtrAgtBICFI.Value = pacs.CdtrAgtBICFI;
            myCommand.Parameters.Add(parameterCdtrAgtBICFI);

            SqlParameter parameterCdtrAgtNm = new SqlParameter("@CdtrAgtNm", SqlDbType.VarChar, 140);
            parameterCdtrAgtNm.Value = pacs.CdtrAgtNm;
            myCommand.Parameters.Add(parameterCdtrAgtNm);

            SqlParameter parameterCdtrAgtBranchId = new SqlParameter("@CdtrAgtBranchId", SqlDbType.VarChar, 35);
            parameterCdtrAgtBranchId.Value = pacs.CdtrAgtBranchId;
            myCommand.Parameters.Add(parameterCdtrAgtBranchId);

            SqlParameter parameterCdtrAgtAcctId = new SqlParameter("@CdtrAgtAcctId", SqlDbType.VarChar, 24);
            parameterCdtrAgtAcctId.Value = pacs.CdtrAgtAcctId;
            myCommand.Parameters.Add(parameterCdtrAgtAcctId);

            SqlParameter parameterCdtrAgtAcctTpPrtry = new SqlParameter("@CdtrAgtAcctTpPrtry", SqlDbType.VarChar, 35);
            parameterCdtrAgtAcctTpPrtry.Value = pacs.CdtrAgtAcctTpPrtry;
            myCommand.Parameters.Add(parameterCdtrAgtAcctTpPrtry);

            SqlParameter parameterCdtrNm = new SqlParameter("@CdtrNm", SqlDbType.VarChar, 140);
            parameterCdtrNm.Value = pacs.CdtrNm;
            myCommand.Parameters.Add(parameterCdtrNm);

            SqlParameter parameterCdtrAdrLine = new SqlParameter("@CdtrAdrLine", SqlDbType.VarChar, 25);
            parameterCdtrAdrLine.Value = pacs.CdtrAdrLine;
            myCommand.Parameters.Add(parameterCdtrAdrLine);

            SqlParameter parameterCdtrAcctId = new SqlParameter("@CdtrAcctId", SqlDbType.VarChar, 24);
            parameterCdtrAcctId.Value = pacs.CdtrAcctId;
            myCommand.Parameters.Add(parameterCdtrAcctId);

            SqlParameter parameterCdtrAcctTpPrtry = new SqlParameter("@CdtrAcctTpPrtry", SqlDbType.VarChar, 35);
            parameterCdtrAcctTpPrtry.Value = pacs.CdtrAcctTpPrtry;
            myCommand.Parameters.Add(parameterCdtrAcctTpPrtry);

            SqlParameter parameterInwardID = new SqlParameter("@InwardID", SqlDbType.VarChar, 50);
            parameterInwardID.Value = pacs.InwardID;
            myCommand.Parameters.Add(parameterInwardID);

            SqlParameter parameterDeptId = new SqlParameter("@DeptId", SqlDbType.Int, 4);
            parameterDeptId.Value = pacs.DeptId;
            myCommand.Parameters.Add(parameterDeptId);

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
        public Pacs004 GetSingleOutward04(string OutwardID)
        {
            Guid outid = new Guid(OutwardID);
            Pacs004 pacs = new Pacs004();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("GetSingleOutward04", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = outid;
            myCommand.Parameters.Add(parameterOutwardID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                pacs.Pacs004ID = dr["OutwardID"].ToString();
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
                pacs.OrgnlMsgId = (string)dr["OrgnlMsgId"];
                pacs.OrgnlMsgNmId = (string)dr["OrgnlMsgNmId"];
                pacs.OrgnlCreDtTm = (string)dr["OrgnlCreDtTm"];
                pacs.RtrRsnOrgtrNm = (string)dr["RtrRsnOrgtrNm"];
                pacs.RtrRsnCd = (string)dr["RtrRsnCd"];
                pacs.RtrRsnPrtry = (string)dr["RtrRsnPrtry"];
                pacs.RtrRsnAddtlInf = (string)dr["RtrRsnAddtlInf"];
                pacs.RtrId = (string)dr["RtrId"];
                pacs.OrgnlInstrId = (string)dr["OrgnlInstrId"];
                pacs.OrgnlEndToEndId = (string)dr["OrgnlEndToEndId"];
                pacs.OrgnlTxId = (string)dr["OrgnlTxId"];
                pacs.RtrdIntrBkSttlmCcy = (string)dr["RtrdIntrBkSttlmCcy"];
                pacs.RtrdIntrBkSttlmAmt = (decimal)dr["RtrdIntrBkSttlmAmt"];
                pacs.TxInfIntrBkSttlmDt = (string)dr["TxInfIntrBkSttlmDt"];
                pacs.ChrgBr = (string)dr["ChrgBr"];
                pacs.ChrgsInfBICFI = (string)dr["ChrgsInfBICFI"];
                pacs.ChrgsInfNm = (string)dr["ChrgsInfNm"];
                pacs.ChrgsInfBranchId = (string)dr["ChrgsInfBranchId"];
                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.TxRefIntrBkSttlmCcy = (string)dr["TxRefIntrBkSttlmCcy"];
                pacs.TxRefIntrBkSttlmAmt = (decimal)dr["TxRefIntrBkSttlmAmt"];
                pacs.TxRefIntrBkSttlmDt = (string)dr["TxRefIntrBkSttlmDt"];
                pacs.SvcLvlPrtry = (int)dr["SvcLvlPrtry"];
                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.PmtMtd = (string)dr["PmtMtd"];
                pacs.RmtInfUstrd = (string)dr["RmtInfUstrd"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrNmPstlAdr = (string)dr["DbtrNmPstlAdr"];
                pacs.DbtrNmStrtNm = (string)dr["DbtrNmStrtNm"];
                pacs.DbtrNmTwnNm = (string)dr["DbtrNmTwnNm"];
                pacs.DbtrNmCtry = (string)dr["DbtrNmCtry"];
                pacs.DbtrNmAdrLine = (string)dr["DbtrNmAdrLine"];
                pacs.DbtrAcctId = (string)dr["DbtrAcctId"];
                pacs.DbtrAcctTpPrtry = (string)dr["DbtrAcctTpPrtry"];
                pacs.DbtrAgtBICFINm = (string)dr["DbtrAgtBICFINm"];
                pacs.DbtrAgtBICFI = (string)dr["DbtrAgtBICFI"];
                pacs.DbtrAgtBranchId = (string)dr["DbtrAgtBranchId"];
                pacs.DbtrAgtAcctId = (string)dr["DbtrAgtAcctId"];
                pacs.DbtrAgtAcctPrtry = (string)dr["DbtrAgtAcctPrtry"];
                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtNm = (string)dr["CdtrAgtNm"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctId = (string)dr["CdtrAgtAcctId"];
                pacs.CdtrAgtAcctTpPrtry = (string)dr["CdtrAgtAcctTpPrtry"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrAdrLine = (string)dr["CdtrAdrLine"];
                pacs.CdtrAcctId = (string)dr["CdtrAcctId"];
                pacs.CdtrAgtAcctTpPrtry = (string)dr["CdtrAgtAcctTpPrtry"];
                pacs.InwardID = (string)dr["InwardID"];
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
                pacs.ToBank = (string)dr["ToBank"];
                pacs.FrBranch = (string)dr["FrBranch"];
                pacs.ToBranch = (string)dr["ToBranch"];

            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return pacs;

        }
        public Pacs004 GetSingleCartOutward04(string OutwardID, string CartID)
        {
            Guid outid = new Guid(OutwardID);
            Pacs004 pacs = new Pacs004();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("GetSingleCartOutward04", myConnection);
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
                pacs.Pacs004ID = dr["OutwardID"].ToString();
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
                pacs.OrgnlMsgId = (string)dr["OrgnlMsgId"];
                pacs.OrgnlMsgNmId = (string)dr["OrgnlMsgNmId"];
                pacs.OrgnlCreDtTm = (string)dr["OrgnlCreDtTm"];
                pacs.RtrRsnOrgtrNm = (string)dr["RtrRsnOrgtrNm"];
                pacs.RtrRsnCd = (string)dr["RtrRsnCd"];
                pacs.RtrRsnPrtry = (string)dr["RtrRsnPrtry"];
                pacs.RtrRsnAddtlInf = (string)dr["RtrRsnAddtlInf"];
                pacs.RtrId = (string)dr["RtrId"];
                pacs.OrgnlInstrId = (string)dr["OrgnlInstrId"];
                pacs.OrgnlEndToEndId = (string)dr["OrgnlEndToEndId"];
                pacs.OrgnlTxId = (string)dr["OrgnlTxId"];
                pacs.RtrdIntrBkSttlmCcy = (string)dr["RtrdIntrBkSttlmCcy"];
                pacs.RtrdIntrBkSttlmAmt = (decimal)dr["RtrdIntrBkSttlmAmt"];
                pacs.TxInfIntrBkSttlmDt = (string)dr["TxInfIntrBkSttlmDt"];
                pacs.ChrgBr = (string)dr["ChrgBr"];
                pacs.ChrgsInfBICFI = (string)dr["ChrgsInfBICFI"];
                pacs.ChrgsInfNm = (string)dr["ChrgsInfNm"];
                pacs.ChrgsInfBranchId = (string)dr["ChrgsInfBranchId"];
                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.TxRefIntrBkSttlmCcy = (string)dr["TxRefIntrBkSttlmCcy"];
                pacs.TxRefIntrBkSttlmAmt = (decimal)dr["TxRefIntrBkSttlmAmt"];
                pacs.TxRefIntrBkSttlmDt = (string)dr["TxRefIntrBkSttlmDt"];
                pacs.SvcLvlPrtry = (int)dr["SvcLvlPrtry"];
                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.PmtMtd = (string)dr["PmtMtd"];
                pacs.RmtInfUstrd = (string)dr["RmtInfUstrd"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrNmPstlAdr = (string)dr["DbtrNmPstlAdr"];
                pacs.DbtrNmStrtNm = (string)dr["DbtrNmStrtNm"];
                pacs.DbtrNmTwnNm = (string)dr["DbtrNmTwnNm"];
                pacs.DbtrNmCtry = (string)dr["DbtrNmCtry"];
                pacs.DbtrNmAdrLine = (string)dr["DbtrNmAdrLine"];
                pacs.DbtrAcctId = (string)dr["DbtrAcctId"];
                pacs.DbtrAcctTpPrtry = (string)dr["DbtrAcctTpPrtry"];
                pacs.DbtrAgtBICFINm = (string)dr["DbtrAgtBICFINm"];
                pacs.DbtrAgtBICFI = (string)dr["DbtrAgtBICFI"];
                pacs.DbtrAgtBranchId = (string)dr["DbtrAgtBranchId"];
                pacs.DbtrAgtAcctId = (string)dr["DbtrAgtAcctId"];
                pacs.DbtrAgtAcctPrtry = (string)dr["DbtrAgtAcctPrtry"];
                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtNm = (string)dr["CdtrAgtNm"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctId = (string)dr["CdtrAgtAcctId"];
                pacs.CdtrAgtAcctTpPrtry = (string)dr["CdtrAgtAcctTpPrtry"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrAdrLine = (string)dr["CdtrAdrLine"];
                pacs.CdtrAcctId = (string)dr["CdtrAcctId"];
                pacs.CdtrAgtAcctTpPrtry = (string)dr["CdtrAgtAcctTpPrtry"];
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
                pacs.ToBank = (string)dr["ToBank"];
                pacs.FrBranch = (string)dr["FrBranch"];
                pacs.ToBranch = (string)dr["ToBranch"];

            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return pacs;

        }
        public Pacs004 GetSingleInward04(string InwardID)
        {
            Guid intid = new Guid(InwardID);
            Pacs004 pacs = new Pacs004();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("GetSingleInward04", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterInwardID = new SqlParameter("@InwardID", SqlDbType.UniqueIdentifier, 50);
            parameterInwardID.Value = intid;
            myCommand.Parameters.Add(parameterInwardID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                pacs.Pacs004ID      = dr["InwardID"].ToString();
                pacs.DetectTime     = dr["DetectTime"].ToString();
                pacs.FrBICFI        = (string)dr["FrBICFI"];
                pacs.ToBICFI        = (string)dr["ToBICFI"];
                pacs.BizMsgIdr      = (string)dr["BizMsgIdr"];
                pacs.MsgDefIdr      = (string)dr["MsgDefIdr"];
                pacs.BizSvc         = (string)dr["BizSvc"];
                pacs.CreDt          = (string)dr["CreDt"];
                pacs.MsgId          = (string)dr["MsgId"];
                pacs.CreDtTm        = (string)dr["CreDtTm"];
                pacs.NbOfTxs        = (int)dr["NbOfTxs"];
                pacs.OrgnlMsgId     = (string)dr["OrgnlMsgId"];
                pacs.OrgnlMsgNmId   = (string)dr["OrgnlMsgNmId"];
                pacs.OrgnlCreDtTm   = (string)dr["OrgnlCreDtTm"];
                pacs.RtrRsnOrgtrNm  = (string)dr["RtrRsnOrgtrNm"];
                pacs.RtrRsnCd       = (string)dr["RtrRsnCd"];
                pacs.RtrRsnPrtry    = (string)dr["RtrRsnPrtry"];
                pacs.RtrRsnAddtlInf = (string)dr["RtrRsnAddtlInf"];
                pacs.RtrId          = (string)dr["RtrId"];
                pacs.OrgnlInstrId   = (string)dr["OrgnlInstrId"];
                pacs.OrgnlEndToEndId = (string)dr["OrgnlEndToEndId"];
                pacs.OrgnlTxId      = (string)dr["OrgnlTxId"];
                pacs.RtrdIntrBkSttlmCcy = (string)dr["RtrdIntrBkSttlmCcy"];
                pacs.RtrdIntrBkSttlmAmt = (decimal)dr["RtrdIntrBkSttlmAmt"];
                pacs.TxInfIntrBkSttlmDt = (string)dr["TxInfIntrBkSttlmDt"];
                pacs.ChrgBr         = (string)dr["ChrgBr"];
                pacs.ChrgsInfBICFI  = (string)dr["ChrgsInfBICFI"];
                pacs.ChrgsInfNm     = (string)dr["ChrgsInfNm"];
                pacs.ChrgsInfBranchId = (string)dr["ChrgsInfBranchId"];
                pacs.InstgAgtBICFI  = (string)dr["InstgAgtBICFI"];
                pacs.InstdAgtBICFI  = (string)dr["InstdAgtBICFI"];
                pacs.TxRefIntrBkSttlmCcy = (string)dr["TxRefIntrBkSttlmCcy"];
                pacs.TxRefIntrBkSttlmAmt = (decimal)dr["TxRefIntrBkSttlmAmt"];
                pacs.TxRefIntrBkSttlmDt = (string)dr["TxRefIntrBkSttlmDt"];
                pacs.SvcLvlPrtry    = (int)dr["SvcLvlPrtry"];
                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.CtgyPurpPrtry  = (string)dr["CtgyPurpPrtry"];
                pacs.PmtMtd         = (string)dr["PmtMtd"];
                pacs.RmtInfUstrd    = (string)dr["RmtInfUstrd"];
                pacs.DbtrNm         = (string)dr["DbtrNm"];
                pacs.DbtrNmPstlAdr  = (string)dr["DbtrNmPstlAdr"];
                pacs.DbtrNmStrtNm   = (string)dr["DbtrNmStrtNm"];
                pacs.DbtrNmTwnNm    = (string)dr["DbtrNmTwnNm"];
                pacs.DbtrNmCtry     = (string)dr["DbtrNmCtry"];
                pacs.DbtrNmAdrLine  = (string)dr["DbtrNmAdrLine"];
                pacs.DbtrAcctId     = (string)dr["DbtrAcctId"];
                pacs.DbtrAcctTpPrtry = (string)dr["DbtrAcctTpPrtry"];
                pacs.DbtrAgtBICFINm = (string)dr["DbtrAgtBICFINm"];
                pacs.DbtrAgtBICFI   = (string)dr["DbtrAgtBICFI"];
                pacs.DbtrAgtBranchId= (string)dr["DbtrAgtBranchId"];
                pacs.DbtrAgtAcctId  = (string)dr["DbtrAgtAcctId"];
                pacs.DbtrAgtAcctPrtry = (string)dr["DbtrAgtAcctPrtry"];
                pacs.CdtrAgtBICFI   = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtNm      = (string)dr["CdtrAgtNm"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctId  = (string)dr["CdtrAgtAcctId"];
                pacs.CdtrAgtAcctTpPrtry = (string)dr["CdtrAgtAcctTpPrtry"];
                pacs.CdtrNm         = (string)dr["CdtrNm"];
                pacs.CdtrAdrLine    = (string)dr["CdtrAdrLine"];
                pacs.CdtrAcctId     = (string)dr["CdtrAcctId"];
                pacs.CdtrAgtAcctTpPrtry = (string)dr["CdtrAgtAcctTpPrtry"];
                pacs.Maker          = (string)dr["Maker"];
                pacs.MakeTime       = dr["MakeTime"].ToString();
                pacs.MakerIP        = (string)dr["MakerIP"];
                pacs.Checker        = (string)dr["Checker"];
                pacs.CheckTime      = dr["CheckTime"].ToString();
                pacs.CheckerIP      = (string)dr["CheckerIP"];
                pacs.DeletedBy      = (string)dr["DeletedBy"];
                pacs.DeleteTime     = dr["DeleteTime"].ToString();
                pacs.CBSResponse    = (string)dr["CBSResponse"];
                pacs.CBSTime        = dr["CBSTime"].ToString();
                pacs.StatusID       = (int)dr["StatusID"];
            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return pacs;

        }
        public void ApproveOutward04(string OutwardID, string Checker, string CheckerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("CKR_ApproveOutward04", myConnection);
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
        public void AuthOutward04(string OutwardID, string Authorizer, string AuthorizerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("ATH_AuthOutward04", myConnection);
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
        public void SendOutward04(string OutwardID, string Admin, string AdminIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("ADM_SendOutward04", myConnection);
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
        public void RejectOutward04(string OutwardID, string Checker, string CheckerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("CKR_RejectOutward04", myConnection);
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
        public void ApproveInward04(string InwardID, string Checker, string CheckerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);

            Guid newGuid = new Guid(InwardID);

            SqlCommand myCommand = new SqlCommand("CKR_ApproveInward04", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterInwardID = new SqlParameter("@InwardID", SqlDbType.UniqueIdentifier, 50);
            parameterInwardID.Value = newGuid;
            myCommand.Parameters.Add(parameterInwardID);

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

    }
}
