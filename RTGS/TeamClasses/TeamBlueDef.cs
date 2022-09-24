using System;

namespace RTGSImporter
{
        public class Pacs009
        {
            public string PacsID = "";
            public int SLNo = 0;
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string MsgId = "";
            public string CreDtTm = "";
            public string BtchBookg = "";

            public decimal TtlIntrBkSttlmAmt = 0;
            public int    NbOfTxs = 0;

            public string LclInstrmPrtry = "";
            public string SvcLvlPrtry = "";
            public string CtgyPurpPrtry = "";
            public string InstrId = "";
            public string TxId = "";
            public string EndToEndId = "";
            public string IntrBkSttlmCcy = "";
            public decimal IntrBkSttlmAmt = 0;
            public string IntrBkSttlmDt = "";

            public string InstgAgtBICFI = "";
            public string InstgAgtNm = "";
            public string InstgAgtBranchId = "";

            public string InstdAgtBICFI = "";
            public string InstdAgtNm = "";
            public string InstdAgtBranchId = "";

            public string IntrmyAgt1BICFI = "";
            public string IntrmyAgt1Nm = "";
            public string IntrmyAgt1BranchId = "";
            public string IntrmyAgt1AcctId = "";
            public string IntrmyAgt1AcctTp = "";

            public string DbtrBICFI = "";
            public string DbtrNm = "";
            public string DbtrBranchId = "";
            public string DbtrAcctId = "";
            public string DbtrAcctTp = "";

            public string CdtrAgtBICFI = "";
            public string CdtrAgtBranchId = "";
            public string CdtrAgtAcctId = "";
            public string CdtrAgtAcctTp = "";

            public string CdtrBICFI = "";
            public string CdtrNm = "";
            public string CdtrBranchId = "";
            public string CdtrAcctId = "";
            public string CdtrAcctTp = "";

            public string InstrInf = "";
            public string PmntRsn = "";
            public string ReturnReason = "";

            public string FrBankBIC = "";
            public string FrBranchID = "";
            public string ToBranchID = "";
            public int DeptId = 0;

            public string Maker = "";
            public string MakeTime = "";
            public string MakerIP = "";
            public string Checker = "";
            public string CheckTime = "";
            public string CheckerIP = "";
            public string Admin = "";
            public string AdminTime = "";
            public string AdminIP = "";
            public string DeletedBy = "";
            public string DeleteTime = "";
            public string DeleteIP = "";
            public string ReturnedBy = "";
            public string RetunTime = "";
            public string CBSResponse = "";
            public string CBSTime = "";

            public string StatusName = "";
            public string FrBranch = "";
            public string ToBranch = "";

            public string BrnchCD = "";
            public bool   NoCBS = false;

            public int    StatusID = 0;
        }

        public class Camt06
        {
            public string FileName = "";
            public string Camt06ID = "";
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string MsgId = "";
            public string CreDtTm = "";
            public string OrgnlBizQry1 = "";
            public string PrtryId = "";
            public string TxId = "";
            public string ShrtBizIdIntrBkSttlmDt = "";
            public string ShrtBizIdBICFI = "";
            public string PmtMsgId = "";
            public string CdPrtry = "";
            public string Ccy = "";
            public decimal AmtWthCcy = 0;
            public string IntrBkSttlmDt = "";
            public string EndToEndId = "";
            public string DbtrBICFI = "";
            public string CdtrBICFI = "";
            public string AcctId = "";
        }

        public class Camt19
        {
            public string FileName = "";
            public string Camt19ID = "";
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string MsgHdrMsgId = "";
            public string MsgHdrCreDtTm = "";
            public string OrgnlBizQryMsgId = "";
            public string OrgnlBizQryCreDtTm = "";
            public string SysIdPrtry = "";
            public string SysDt = "";
            public string SysInfPerCcyId = "";
            public string SysInfPerCcySchdldTm = "";
            public string SysInfPerCcySchdldStartTm = "";
            public string SysInfPerCcySchdldEndTm = "";
            public string SysInfPerCcyId1 = "";
            public string SysInfPerCcySchdldTm1 = "";
            public string SysInfPerCcySchdldStartTm1 = "";
            public string SysInfPerCcySchdldEndTm1 = "";
            public string SysInfPerCcyId2 = "";
            public string SysInfPerCcySchdldTm2 = "";
            public string SysInfPerCcySchdldStartTm2 = "";
            public string SysInfPerCcySchdldEndTm2 = "";
            public string SysInfPerCcyId3 = "";
            public string SysInfPerCcySchdldTm3 = "";
            public string SysInfPerCcySchdldStartTm3 = "";
            public string SysInfPerCcySchdldEndTm3 = "";
            public string SysInfPerCcyId4 = "";
            public string SysInfPerCcySchdldTm4 = "";
            public string SysInfPerCcySchdldStartTm4 = "";
            public string SysInfPerCcySchdldEndTm4 = "";
            public string SysInfPerCcyId5 = "";
            public string SysInfPerCcySchdldTm5 = "";
            public string SysInfPerCcySchdldStartTm5 = "";
            public string SysInfPerCcySchdldEndTm5 = "";
            public string SysInfPerCcyId6 = "";
            public string SysInfPerCcySchdldTm6 = "";
            public string SysInfPerCcySchdldStartTm6 = "";
            public string SysInfPerCcyId7 = "";
            public string SysInfPerCcySchdldTm7 = "";
            public string SysInfPerCcyId8 = "";
            public string SysInfPerCcySchdldTm8 = "";
            public string SysInfPerCcyId9 = "";
            public string SysInfPerCcySchdldTm9 = "";
            public string SysInfPerCcyId10 = "";
            public string SysInfPerCcySchdldTm10 = "";
            public string SysInfPerCcyId11 = "";
            public string SysInfPerCcySchdldTm11 = "";
            public string SysDt1 = "";
            public string SysDt2 = "";
            public string SysDt3 = "";
            public string SysDt4 = "";
            public string SysDt5 = "";
            public string SysDt6 = "";
            public string SysDt7 = "";
            public string SysDt8 = "";
            public string SysDt9 = "";
            public string SysDt10 = "";
            public string SysDt11 = "";
        }

        public class camt25
        {
            public string FileName = "";
            public string Camt25ID = "";
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string MsgId = "";
            public string CreDtTm = "";
            public string OrgnlMsgId = "";
            public string StsCd = "";
            public string Desc = "";
        }

        public class camt07
        {
            public string Camt07ID = "";
            public string DetectTime = "";
            public string FrBICIF = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string MsgId = "";
            public string CreDtTm = "";
            public string TxId = "";
            public string IntrBkSttlmDt = "";
            public string InstgAgtBICFI = "";
            public string NewPmtValSetPrtryCd = "";

        }
}
