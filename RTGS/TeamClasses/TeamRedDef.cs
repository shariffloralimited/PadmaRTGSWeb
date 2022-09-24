using System;
using System.Text.RegularExpressions;

namespace RTGSImporter
{
        public class Pacs008
        {
            //public string FileName = "";
            //public string PacsID = "";
            //public string DetectTime = "";
            //public string FrBICFI = "";
            //public string ToBICFI = "";
            //public string BizMsgIdr = "";
            //public string MsgDefIdr = "";
            //public string BizSvc = "";
            //public string CreDt = "";
            //public string MsgId = "";
            //public string CreDtTm = "";
            //public string BatchBookingID = "";
            //public string BtchBookg = "";
            //public int    NbOfTxs = 0;
            //public string InstrId = "";
            //public string EndToEndId = "";
            //public string TxId = "";
            //public string ClrChanl = "";
            //public int SvcLvlPrtry = 0;
            //public string LclInstrmPrtry = "";
            //public string CtgyPurpPrtry = "";
            //public string Ccy = "";
            //public decimal TtlIntrBkSttlmAmt = 0;
            //public decimal IntrBkSttlmAmt = 0;
            //public string IntrBkSttlmDt = "";
            //public string ChrgBr = "";
            //public string InstgAgtBICFI = "";
            //public string InstgAgtNm = "";
            //public string InstgAgtBranchId = "";
            //public string InstdAgtBICFI = "";
            //public string InstdAgtNm = "";
            //public string InstdAgtBranchId = "";
            //public string DbtrNm = "";
            //public string DbtrPstlAdr = "";
            //public string DbtrStrtNm = "";
            //public string DbtrTwnNm = "";
            //public string DbtrAdrLine = "";
            //public string DbtrCtry = "";
            //public string DbtrAcctOthrId = "";
            //public string DbtrAgtBICFI = "";
            //public string DbtrAgtNm = "";
            //public string DbtrAgtBranchId = "";
            //public string DbtrAgtAcctOthrId = "";
            //public string DbtrAgtAcctPrtry = "";
            //public string CdtrAgtBICFI = "";
            //public string CdtrAgtNm = "";
            //public string CdtrAgtBranchId = "";
            //public string CdtrAgtAcctOthrId = "";
            //public string CdtrAgtAcctPrtry = "";
            //public string CdtrNm = "";
            //public string CdtrPstlAdr = "";
            //public string CdtrStrtNm = "";
            //public string CdtrTwnNm = "";
            //public string CdtrAdrLine = "";
            //public string CdtrCtry = "";
            //public string CdtrAcctOthrId = "";
            //public string CdtrAcctPrtry = "";
            //public string InstrInf = "";
            //public string Ustrd = "";
            //public string PmntRsn = "";
            //public string ReturnReason = "";
            //public int DeptId = 0;
            //public string Maker = "";
            //public string MakeTime = "";
            //public string MakerIP = "";
            //public string Checker = "";
            //public string CheckTime = "";
            //public string CheckerIP = "";
            //public string Admin = "";
            //public string AdminTime = "";
            //public string AdminIP = "";
            //public string DeletedBy = "";
            //public string DeleteTime = "";
            //public string CBSResponse = "";
            //public string CBSTime = "";
            //public int StatusID = 0;
            //public string FrBankBIC = "";
            //public string FrBank = ""; 
            //public string FrBranch = "";
            //public string ToBranch = "";
            //public string BrnchCD = "";
            //public bool ChargeWaived = false;

            public string FileName = "";
            public string PacsID = "";
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            private string _MsgId = "";
            public string CreDtTm = "";
            public string BatchBookingID = "";
            public string BtchBookg = "";
            public int NbOfTxs = 0;
            private string _InstrId = "";
            private string _EndToEndId = "";
            private string _TxId = "";
            public string ClrChanl = "";
            public int SvcLvlPrtry = 0;
            public string LclInstrmPrtry = "";
            public string CtgyPurpPrtry = "";
            public string Ccy = "";
            public decimal TtlIntrBkSttlmAmt = 0;
            public decimal IntrBkSttlmAmt = 0;
            public string IntrBkSttlmDt = "";
            public string ChrgBr = "";
            public string InstgAgtBICFI = "";
            public string InstgAgtNm = "";
            public string InstgAgtBranchId = "";
            public string InstdAgtBICFI = "";
            public string InstdAgtNm = "";
            public string InstdAgtBranchId = "";
            private string _DbtrNm = "";
            private string _DbtrPstlAdr = "";
            private string _DbtrStrtNm = "";
            private string _DbtrTwnNm = "";
            private string _DbtrAdrLine = "";
            private string _DbtrCtry = "";
            public string DbtrAcctOthrId = "";
            public string DbtrAgtBICFI = "";
            public string DbtrAgtNm = "";
            public string DbtrAgtBranchId = "";
            public string DbtrAgtAcctOthrId = "";
            public string DbtrAgtAcctPrtry = "";
            public string CdtrAgtBICFI = "";
            public string CdtrAgtNm = "";
            public string CdtrAgtBranchId = "";
            public string CdtrAgtAcctOthrId = "";
            public string CdtrAgtAcctPrtry = "";
            private string _CdtrNm = "";
            private string _CdtrPstlAdr = "";
            private string _CdtrStrtNm = "";
            private string _CdtrTwnNm = "";
            private string _CdtrAdrLine = "";
            private string _CdtrCtry = "";
            public string CdtrAcctOthrId = "";
            public string CdtrAcctPrtry = "";
            private string _InstrInf = "";
            private string _Ustrd = "";
            public string PmntRsn = "";
            public string ReturnReason = "";
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
            public string CBSResponse = "";
            public string CBSTime = "";
            public int StatusID = 0;
            public string FrBankBIC = "";
            public string FrBank = "";
            public string FrBranch = "";
            public string ToBranch = "";
            public string BrnchCD = "";
            public bool ChargeWaived = false;
        private string _OrginatorACType = "";
        private string _ReceiverACType = "";
        private string _PurposeOfTransaction = "";
        private string _OtherInfo = "";

        public string MsgId
            {
                get { return RTGS.StringExt.Truncate(_MsgId, 16); }
                set { _MsgId = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string InstrId
            {
                get { return RTGS.StringExt.Truncate(_InstrId, 16); }
                set { _InstrId = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string EndToEndId
            {
                get { return RTGS.StringExt.Truncate(_EndToEndId, 16); }
                set { _EndToEndId = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string TxId
            {
                get { return RTGS.StringExt.Truncate(_TxId, 16); }
                set { _TxId = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }

            public string DbtrNm
            {
                get { return RTGS.StringExt.Truncate(_DbtrNm, 35); }
                set { _DbtrNm = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string DbtrPstlAdr
            {
                get { return _DbtrPstlAdr; }
                set { _DbtrPstlAdr = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string DbtrStrtNm
            {
                get { return _DbtrStrtNm; }
                set { _DbtrStrtNm = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string DbtrTwnNm
            {
                get { return _DbtrTwnNm; }
                set { _DbtrTwnNm = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string DbtrAdrLine
            {
                get { return _DbtrAdrLine; }
                set { _DbtrAdrLine = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string DbtrCtry
            {
                get { return _DbtrCtry; }
                set { _DbtrCtry = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string CdtrNm
            {
                get { return RTGS.StringExt.Truncate(_CdtrNm, 35); }
                set { _CdtrNm = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string CdtrPstlAdr
            {
                get { return _CdtrPstlAdr; }
                set { _CdtrPstlAdr = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string CdtrStrtNm
            {
                get { return _CdtrStrtNm; }
                set { _CdtrStrtNm = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string CdtrTwnNm
            {
                get { return _CdtrTwnNm; }
                set { _CdtrTwnNm = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string CdtrAdrLine
            {
                get { return _CdtrAdrLine; }
                set { _CdtrAdrLine = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string CdtrCtry
            {
                get { return _CdtrCtry; }
                set { _CdtrCtry = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }

            public string InstrInf
            {
                get { return _InstrInf; }
                set { _InstrInf = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
            public string Ustrd
            {
                get { return RTGS.StringExt.Truncate(_Ustrd, 140); }
                set { _Ustrd = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
            }
        public string OrginatorACType
        {
            get { return RTGS.StringExt.Truncate(_OrginatorACType, 30); }
            set { _OrginatorACType = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
        }

        public string ReceiverACType
        {
            get { return RTGS.StringExt.Truncate(_ReceiverACType, 30); }
            set { _ReceiverACType = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
        }

        public string PurposeOfTransaction
        {
            get { return RTGS.StringExt.Truncate(_PurposeOfTransaction, 30); }
            set { _PurposeOfTransaction = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
        }

        public string OtherInfo
        {
            get { return RTGS.StringExt.Truncate(_OtherInfo, 30); }
            set { _OtherInfo = Regex.Replace(value, RTGS.Global.AppVariable.StringPattern, ""); }
        }

    }

    public class Pacs002
        {
            public string FileName = "";
            public string Pacs02ID = "";
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
            public string OrgnlMsgNmId = "";
            public string OrgnlCreDtTm = "";
            public string GrpSts = "";
            public string RsnPrtry = "";
            public string AddtlInf = "";
            public string OrgnlInstrId = "";
            public string OrgnlEndToEndId = "";
            public string OrgnlTxId = "";
            public string TxSts = "";
            public string TxInfAndStsPrtry = "";
            public string TxInfAndStsAddtlInf = "";
        }

        public class Camt04
        {
            public string FileName = "";
            public string Camt04ID = "";
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string MsgHdrMsgId = "";
            public string CreDtTm = "";
            public string OrgnlBizQryMsgId = "";
            public string AcctIdOthrId = "";
            public string Cd = "";
            public string Ccy = "";
            public string AmtWthtCcy = "";
            public string CdtDbtInd = "";
            public string AnyBIC = "";
            public string XmlData = "";
        }

        public class Camt05
        {
            public string FileName = "";
            public string Camt05ID = "";
            public string DetectTime = "";
            public string MsgId = "";
            public string CreDtTm = "";
            public string ReqTpId = "";
            public string BICFI = "";
            public string TxId = "";
            public string IntrBkSttlmDt = "";
        }
}
