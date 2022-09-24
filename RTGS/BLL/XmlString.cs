using System;
using System.Data;
using System.Data.SqlClient;


namespace RTGSImporter
{
    public class XmlString
    {


        public string GetPacs8(Pacs008 pacs, string Priority)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<DataPDU xmlns=\"urn:swift:saa:xsd:saa.2.0\">");
            sb.Append("<Revision>2.0.5</Revision>");
            sb.Append("<Body>");

            #region AppHdr
            sb.Append("<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">");
            sb.Append("<Fr>");
            sb.Append("<FIId>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>" + pacs.FrBICFI + "</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</FIId>");
            sb.Append("</Fr>");
            sb.Append("<To>");
            sb.Append("<FIId>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>" + pacs.ToBICFI + "</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</FIId>");
            sb.Append("</To>");
            sb.Append("<BizMsgIdr>" + pacs.BizMsgIdr + "</BizMsgIdr>");
            sb.Append("<MsgDefIdr>" + pacs.MsgDefIdr + "</MsgDefIdr>");
            sb.Append("<BizSvc>RTGS</BizSvc>");
            sb.Append("<CreDt>" + pacs.CreDt + "</CreDt>");
            sb.Append("</AppHdr>");
            #endregion

            sb.Append("<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.008.001.04\">");
            sb.Append("<FIToFICstmrCdtTrf>");

            #region GrpHdr
            sb.Append("<GrpHdr>");
            sb.Append("<MsgId>" + pacs.MsgId + "</MsgId>");
            sb.Append("<CreDtTm>" + pacs.CreDtTm + "</CreDtTm>");
            if (pacs.NbOfTxs > 1)
            {
                sb.Append("<BtchBookg>" + pacs.BtchBookg.ToLower() + "</BtchBookg>");
            }

            sb.Append("<NbOfTxs>" + pacs.NbOfTxs + "</NbOfTxs>");
            
            if (pacs.NbOfTxs > 1)
            {
                sb.Append("<TtlIntrBkSttlmAmt Ccy=\"" + pacs.Ccy + "\">" + pacs.TtlIntrBkSttlmAmt.ToString("F2") + "</TtlIntrBkSttlmAmt>");
                sb.Append("<IntrBkSttlmDt>" + pacs.IntrBkSttlmDt + "</IntrBkSttlmDt>");
            }
            sb.Append("<SttlmInf>");
            sb.Append("<SttlmMtd>CLRG</SttlmMtd>");
            sb.Append("</SttlmInf>");
            sb.Append("</GrpHdr>");
            #endregion

            for (int i = 0; i < pacs.NbOfTxs; i++)
            {
                Pacs008 pacs1 = GetSingleOutward08ByBatchBookingID(pacs.BatchBookingID, i);
                string CdtInfo = GenPacs008CdtTrfInf(pacs1, Priority);
                sb.Append(CdtInfo);
            }

            sb.Append("</FIToFICstmrCdtTrf>");
            sb.Append("</Document>");

            sb.Append("</Body>");
            sb.Append("</DataPDU>");

            return sb.ToString();
        }
        protected string GenPacs008CdtTrfInf(Pacs008 pacs, string Priority)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<CdtTrfTxInf>");

            #region PmtId
            sb.Append("<PmtId>");
            sb.Append("<InstrId>" + pacs.InstrId + "</InstrId>");
            sb.Append("<EndToEndId>" + pacs.EndToEndId + "</EndToEndId>");
            sb.Append("<TxId>" + pacs.TxId + "</TxId>");
            sb.Append("</PmtId>");
            #endregion

            #region PmtTpInf
            sb.Append("<PmtTpInf>");
            sb.Append("<ClrChanl>" + pacs.ClrChanl + "</ClrChanl>");
            sb.Append("<SvcLvl>");
            sb.Append("<Prtry>" + Priority.PadLeft(4, '0') + "</Prtry>");
            sb.Append("</SvcLvl>");
            sb.Append("<LclInstrm>");
            sb.Append("<Prtry>" + pacs.LclInstrmPrtry + "</Prtry>");
            sb.Append("</LclInstrm>");
            sb.Append("<CtgyPurp>");

            if (pacs.CtgyPurpPrtry == "000")
            {
                pacs.CtgyPurpPrtry = "001";
            }
            sb.Append("<Prtry>" + pacs.CtgyPurpPrtry + "</Prtry>");
            sb.Append("</CtgyPurp>");
            sb.Append("</PmtTpInf>");
            #endregion

            sb.Append("<IntrBkSttlmAmt Ccy=\"" + pacs.Ccy + "\">" + pacs.IntrBkSttlmAmt.ToString("F2") + "</IntrBkSttlmAmt>");
            if (pacs.BtchBookg.ToLower() == "false")
            {
                sb.Append("<IntrBkSttlmDt>" + pacs.IntrBkSttlmDt + "</IntrBkSttlmDt>");
            }
            sb.Append("<ChrgBr>" + pacs.ChrgBr + "</ChrgBr>");

            #region Instg Instd Agt
            if ((pacs.InstgAgtBICFI != "") || (pacs.InstgAgtNm != ""))
            {
                sb.Append("<InstgAgt>");
                sb.Append("<FinInstnId>");
                if (pacs.InstgAgtBICFI != "")
                {
                    sb.Append("<BICFI>" + pacs.InstgAgtBICFI + "</BICFI>");
                }
                else
                {
                    sb.Append("<Nm>" + pacs.InstgAgtNm + "</Nm>");
                }
                sb.Append("</FinInstnId>");
                sb.Append("</InstgAgt>");
            }
            if ((pacs.InstdAgtBICFI != "") || (pacs.InstdAgtNm != ""))
            {
                sb.Append("<InstdAgt>");
                sb.Append("<FinInstnId>");
                if (pacs.InstdAgtBICFI != "")
                {
                    sb.Append("<BICFI>" + pacs.InstdAgtBICFI + "</BICFI>");
                }
                else
                {
                    sb.Append("<Nm>" + pacs.InstdAgtNm + "</Nm>");
                }
                sb.Append("</FinInstnId>");
                sb.Append("</InstdAgt>");
            }
            #endregion

            #region Dbtr Info
            sb.Append("<Dbtr>");
            sb.Append("<Nm>" + pacs.DbtrNm + "</Nm>");
            if (pacs.DbtrPstlAdr != "")
            {
                sb.Append("<PstlAdr>");

                if (pacs.DbtrPstlAdr.Length > 32)
                {

                        int x = pacs.DbtrPstlAdr.LastIndexOf(" ");
                        int l = pacs.DbtrPstlAdr.Length;

                        sb.Append("<AdrLine>" + pacs.DbtrPstlAdr.Substring(0, 32) + "</AdrLine>");
                        sb.Append("<AdrLine>" + pacs.DbtrPstlAdr.Substring(32) + "</AdrLine>");
                }
                else
                {
                    sb.Append("<AdrLine>" + pacs.DbtrPstlAdr + "</AdrLine>");
                }

                sb.Append("</PstlAdr>");
            }


            sb.Append("</Dbtr>");

            sb.Append("<DbtrAcct>");
            sb.Append("<Id>");
            sb.Append("<Othr>");
            sb.Append("<Id>" + pacs.DbtrAcctOthrId + "</Id>");
            sb.Append("</Othr>");
            sb.Append("</Id>");
            sb.Append("</DbtrAcct>");

            if ((pacs.DbtrAgtBICFI != "") || (pacs.DbtrAgtNm != ""))
            {
                sb.Append("<DbtrAgt>");
                sb.Append("<FinInstnId>");
                if (pacs.DbtrAgtBICFI != "")
                {
                    sb.Append("<BICFI>" + pacs.DbtrAgtBICFI + "</BICFI>");
                }
                else
                {
                    sb.Append("<Nm>" + pacs.DbtrAgtNm + "</Nm>");
                }
                sb.Append("</FinInstnId>");
                if (pacs.DbtrAgtBranchId != "")
                {
                    sb.Append("<BrnchId>");
                    sb.Append("<Id>" + pacs.DbtrAgtBranchId + "</Id>");
                    sb.Append("</BrnchId>");
                }
                sb.Append("</DbtrAgt>");
            }

            if (pacs.DbtrAgtAcctOthrId != "")
            {
                sb.Append("<DbtrAgtAcct>");
                sb.Append("<Id>");
                sb.Append("<Othr>");
                sb.Append("<Id>" + pacs.DbtrAgtAcctOthrId + "</Id>");
                sb.Append("</Othr>");
                sb.Append("</Id>");
                if (pacs.DbtrAgtAcctPrtry != "")
                {
                    sb.Append("<Tp>");
                    sb.Append("<Prtry>" + pacs.DbtrAgtAcctPrtry + "</Prtry>");
                    sb.Append("</Tp>");
                }
                sb.Append("</DbtrAgtAcct>");
            }
            #endregion

            #region Cdtr Info
            if ((pacs.CdtrAgtBICFI != "") || (pacs.CdtrAgtNm != ""))
            {
                sb.Append("<CdtrAgt>");
                sb.Append("<FinInstnId>");
                if (pacs.CdtrAgtBICFI != "")
                {
                    sb.Append("<BICFI>" + pacs.CdtrAgtBICFI + "</BICFI>");
                }
                else
                {
                    sb.Append("<Nm>>" + pacs.CdtrAgtNm + "</Nm>");
                }
                sb.Append("</FinInstnId>");
                if (pacs.CdtrAgtBranchId != "")
                {
                    sb.Append("<BrnchId>");
                    sb.Append("<Id>" + pacs.CdtrAgtBranchId + "</Id>");
                    sb.Append("</BrnchId>");
                }
                sb.Append("</CdtrAgt>");
            }

            if (pacs.CdtrAgtAcctOthrId != "")
            {
                sb.Append("<CdtrAgtAcct>");
                sb.Append("<Id>");
                sb.Append("<Othr>");
                sb.Append("<Id>" + pacs.CdtrAgtAcctOthrId + "</Id>");
                sb.Append("</Othr>");
                sb.Append("</Id>");
                if (pacs.CdtrAgtAcctPrtry != "")
                {
                    sb.Append("<Tp>");
                    sb.Append("<Prtry>" + pacs.CdtrAgtAcctPrtry + "</Prtry>");
                    sb.Append("</Tp>");
                }
                sb.Append("</CdtrAgtAcct>");
            }

            sb.Append("<Cdtr>");
            sb.Append("<Nm>" + pacs.CdtrNm + "</Nm>");
            //if (pacs.CdtrPstlAdr != "")
            //{
            //    sb.Append("<PstlAdr>" + pacs.CdtrPstlAdr + "</PstlAdr>");
            //}
            //if (pacs.CdtrStrtNm != "")
            //{
            //    sb.Append("<StrtNm>" + pacs.CdtrStrtNm + "</StrtNm>");
            //}
            //if (pacs.CdtrTwnNm != "")
            //{
            //    sb.Append("<TwnNm>" + pacs.CdtrTwnNm + "</TwnNm>");
            //}
            //if (pacs.CdtrCtry != "")
            //{
            //    sb.Append("<Ctry>" + pacs.CdtrCtry + "</Ctry>");
            //}
            //if (pacs.CdtrAdrLine != "")
            //{
            //    sb.Append("<AdrLine>" + pacs.CdtrAdrLine + "</AdrLine>");
            //}

            //if (pacs.CdtrPstlAdr != "")
            //{
            //    sb.Append("<PstlAdr>");
            //    {
            //        int x = pacs.CdtrPstlAdr.LastIndexOf(" ");
            //        int l = pacs.CdtrPstlAdr.Length;

            //        sb.Append("<AdrLine>" + pacs.CdtrPstlAdr.Substring(0, 32) + "</AdrLine>");
            //        sb.Append("<AdrLine>" + pacs.CdtrPstlAdr.Substring(32) + "</AdrLine>");
            //    }

            //    sb.Append("</PstlAdr>");
            //}

            if (pacs.CdtrPstlAdr != "")
            {
                sb.Append("<PstlAdr>");

                if (pacs.CdtrPstlAdr.Length > 32)
                {

                    int x = pacs.CdtrPstlAdr.LastIndexOf(" ");
                    int l = pacs.CdtrPstlAdr.Length;

                    sb.Append("<AdrLine>" + pacs.CdtrPstlAdr.Substring(0, 32) + "</AdrLine>");
                    sb.Append("<AdrLine>" + pacs.CdtrPstlAdr.Substring(32) + "</AdrLine>");
                }
                else
                {
                    sb.Append("<AdrLine>" + pacs.CdtrPstlAdr + "</AdrLine>");
                }

                sb.Append("</PstlAdr>");
            }

           
            //if (pacs.CdtrPstlAdr != "")
            //{
            //    sb.Append("<PstlAdr>");
            //    {

            //        sb.Append("<AdrLine>" + pacs.CdtrPstlAdr + "</AdrLine>");
            //        sb.Append("<AdrLine>" + pacs.CdtrPstlAdr + "</AdrLine>");
            //    }
           
            //    sb.Append("</PstlAdr>");
            //}

            sb.Append("</Cdtr>");

            sb.Append("<CdtrAcct>");
            sb.Append("<Id>");
            sb.Append("<Othr>");
            sb.Append("<Id>" + pacs.CdtrAcctOthrId + "</Id>");
            sb.Append("</Othr>");
            sb.Append("</Id>");
            if (pacs.CdtrAcctPrtry != "")
            {
                sb.Append("<Tp>");
                sb.Append("<Prtry>" + pacs.CdtrAcctPrtry + "</Prtry>");
                sb.Append("</Tp>");
            }
            sb.Append("</CdtrAcct>");
            #endregion

            #region Narration
            if (pacs.InstrInf != "")
            {
                sb.Append("<InstrForNxtAgt>");
                sb.Append("<InstrInf>" + pacs.InstrInf + "</InstrInf>");
                sb.Append("</InstrForNxtAgt>");
            }
            //update for FCY
            if (pacs.Ccy != "BDT")
            {
                if (pacs.OrginatorACType != "")
                {
                    sb.Append("<InstrForNxtAgt>");
                    sb.Append("<InstrInf>" + "Org: " + pacs.OrginatorACType + "</InstrInf>");
                    sb.Append("</InstrForNxtAgt>");
                }

                if (pacs.ReceiverACType != "")
                {
                    sb.Append("<InstrForNxtAgt>");
                    sb.Append("<InstrInf>" + "Rec: " + pacs.ReceiverACType + "</InstrInf>");
                    sb.Append("</InstrForNxtAgt>");
                }

                if (pacs.PurposeOfTransaction != "")
                {
                    sb.Append("<InstrForNxtAgt>");
                    sb.Append("<InstrInf>" + "Pur: " + pacs.PurposeOfTransaction + "</InstrInf>");
                    sb.Append("</InstrForNxtAgt>");
                }

                if (pacs.OtherInfo != "")
                {
                    sb.Append("<InstrForNxtAgt>");
                    sb.Append("<InstrInf>" + "Otr: " + pacs.OtherInfo + "</InstrInf>");
                    sb.Append("</InstrForNxtAgt>");
                }
            }

            if (pacs.Ustrd != "")
            {
                sb.Append("<RmtInf>");
                if (pacs.CtgyPurpPrtry == "041")
                {
                    string data = pacs.Ustrd.Replace("  ", " ");
                    data = pacs.Ustrd.Replace("  ", " ");

                    string[] a = pacs.Ustrd.Split(' ');

                    if (a.Length == 5)
                    {
                        sb.Append("<Ustrd>" + a[0] + " " + a[1] + " " + a[2] + "</Ustrd>");
                        sb.Append("<Ustrd>" + a[3] + " " + a[4] + "</Ustrd>");
                    }
                }
                else
                {
                    sb.Append("<Ustrd>" + pacs.Ustrd + "</Ustrd>");
                }


                sb.Append("</RmtInf>");
            }
            #endregion

             sb.Append("</CdtTrfTxInf>");
             return sb.ToString();
        }
        public string GetPacs9(Pacs009 pacs,string Priority)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<DataPDU xmlns=\"urn:swift:saa:xsd:saa.2.0\">");
            sb.Append("<Revision>2.0.5</Revision>");
            sb.Append("<Body>");

            #region AppHdr
            sb.Append("<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">");
            sb.Append("<Fr>");
            sb.Append("<FIId>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>" + pacs.FrBICFI + "</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</FIId>");
            sb.Append("</Fr>");
            sb.Append("<To>");
            sb.Append("<FIId>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>" + pacs.ToBICFI + "</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</FIId>");
            sb.Append("</To>");
            sb.Append("<BizMsgIdr>" + pacs.BizMsgIdr + "</BizMsgIdr>");
            sb.Append("<MsgDefIdr>" + pacs.MsgDefIdr + "</MsgDefIdr>");
            sb.Append("<BizSvc>" + pacs.BizSvc + "</BizSvc>");
            sb.Append("<CreDt>" + pacs.CreDt + "</CreDt>");
            sb.Append("</AppHdr>");
            #endregion

            sb.Append("<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.009.001.04\">");
            sb.Append("<FICdtTrf>");

            #region GrpHdr
            sb.Append("<GrpHdr>");
            sb.Append("<MsgId>" + pacs.MsgId + "</MsgId>");
            sb.Append("<CreDtTm>" + pacs.CreDtTm + "</CreDtTm>");
            sb.Append("<NbOfTxs>" + pacs.NbOfTxs + "</NbOfTxs>");
            sb.Append("<SttlmInf>");
            sb.Append("<SttlmMtd>CLRG</SttlmMtd>");
            sb.Append("</SttlmInf>");
            sb.Append("</GrpHdr>");
            #endregion

            sb.Append("<CdtTrfTxInf>");

            #region PmtId
            sb.Append("<PmtId>");
            sb.Append("<InstrId>" + pacs.InstrId + "</InstrId>");
            sb.Append("<EndToEndId>" + pacs.EndToEndId + "</EndToEndId>");
            sb.Append("<TxId>" + pacs.TxId + "</TxId>");
            sb.Append("</PmtId>");
            #endregion

            #region PmtTpInf
            sb.Append("<PmtTpInf>");
            sb.Append("<ClrChanl>RTGS</ClrChanl>");

            sb.Append("<SvcLvl>");
            sb.Append("<Prtry>" + Priority.PadLeft(4, '0') + "</Prtry>");
            sb.Append("</SvcLvl>");

            sb.Append("<LclInstrm>");
            sb.Append("<Prtry>" + pacs.LclInstrmPrtry + "</Prtry>");
            sb.Append("</LclInstrm>");

            sb.Append("<CtgyPurp>");
            sb.Append("<Prtry>" + pacs.CtgyPurpPrtry + "</Prtry>");
            sb.Append("</CtgyPurp>");
            sb.Append("</PmtTpInf>");
            #endregion

            sb.Append("<IntrBkSttlmAmt Ccy=\"" + pacs.IntrBkSttlmCcy + "\">" + pacs.IntrBkSttlmAmt.ToString("F2") + "</IntrBkSttlmAmt>");
            sb.Append("<IntrBkSttlmDt>" + pacs.IntrBkSttlmDt + "</IntrBkSttlmDt>");

            #region Instg - Instd Agt
            if ((pacs.InstgAgtBICFI != "") || (pacs.InstgAgtNm != ""))
            {
                sb.Append("<InstgAgt>");
                sb.Append("<FinInstnId>");
                if (pacs.InstgAgtBICFI != "")
                {
                    sb.Append("<BICFI>" + pacs.InstgAgtBICFI + "</BICFI>");
                }
                else
                {
                    sb.Append("<Nm>" + pacs.InstgAgtNm + "</Nm>");
                }
                sb.Append("</FinInstnId>");
                sb.Append("</InstgAgt>");
            }

            if ((pacs.InstdAgtBICFI != "") || (pacs.InstdAgtNm != ""))
            {
                sb.Append("<InstdAgt>");
                sb.Append("<FinInstnId>");
                if (pacs.InstdAgtBICFI != "")
                {
                    sb.Append("<BICFI>" + pacs.InstdAgtBICFI + "</BICFI>");
                }
                else
                {
                    sb.Append("<Nm>" + pacs.InstdAgtNm + "</Nm>");
                }
                sb.Append("</FinInstnId>");
                sb.Append("</InstdAgt>");
            }
            #endregion

            #region IntrmyAgt1
            if ((pacs.IntrmyAgt1BICFI != "") || (pacs.IntrmyAgt1Nm != ""))
            {
                sb.Append("<IntrmyAgt1>");
                sb.Append("<FinInstnId>");
                if (pacs.IntrmyAgt1BICFI != "")
                {
                    sb.Append("<BICFI>" + pacs.IntrmyAgt1BICFI + "</BICFI>");
                }
                else
                {
                    sb.Append("<Nm>" + pacs.IntrmyAgt1Nm + "</Nm>");
                }
                sb.Append("</FinInstnId>");
                sb.Append("</IntrmyAgt1>");
            }

            if (pacs.IntrmyAgt1AcctId != "")
            {
                sb.Append("<IntrmyAgt1Acct>");
                sb.Append("<Id>");
                sb.Append("<Othr>");
                sb.Append("<Id>" + pacs.IntrmyAgt1AcctId + "</Id>");
                sb.Append("</Othr>");
                sb.Append("</Id>");
                sb.Append("</IntrmyAgt1Acct>");
            }
            #endregion

            #region Dbtr Info
            if ((pacs.DbtrBICFI != "") || (pacs.DbtrNm != ""))
            {
                sb.Append("<Dbtr>");
                sb.Append("<FinInstnId>");
                if (pacs.DbtrBICFI != "")
                {
                    sb.Append("<BICFI>" + pacs.DbtrBICFI + "</BICFI>");
                }
                else
                {
                    sb.Append("<Nm>" + pacs.DbtrNm + "</Nm>");
                }
                sb.Append("</FinInstnId>");
                if (pacs.DbtrBranchId != "")
                {
                    sb.Append("<BrnchId>");
                    sb.Append("<Id>" + pacs.DbtrBranchId + "</Id>");
                    sb.Append("</BrnchId>");
                }
                sb.Append("</Dbtr>");
            }

            sb.Append("<DbtrAcct>");
            sb.Append("<Id>");
            sb.Append("<Othr>");
            sb.Append("<Id>" + pacs.DbtrAcctId + "</Id>");
            sb.Append("</Othr>");
            sb.Append("</Id>");
            sb.Append("</DbtrAcct>");
            #endregion

            #region Cdtr Info
            if ((pacs.CdtrBICFI != "") || (pacs.CdtrNm != ""))
            {
                sb.Append("<Cdtr>");
                sb.Append("<FinInstnId>");
                if (pacs.CdtrBICFI != "")
                {
                    sb.Append("<BICFI>" + pacs.CdtrBICFI + "</BICFI>");
                }
                else
                {
                    sb.Append("<Nm>" + pacs.CdtrNm + "</Nm>");
                }
                sb.Append("</FinInstnId>");
                if (pacs.CdtrBranchId != "")
                {
                    sb.Append("<BrnchId>");
                    sb.Append("<Id>" + pacs.CdtrBranchId + "</Id>");
                    sb.Append("</BrnchId>");
                }
                sb.Append("</Cdtr>");
            }

            sb.Append("<CdtrAcct>");
            sb.Append("<Id>");
            sb.Append("<Othr>");
            sb.Append("<Id>" + pacs.CdtrAcctId + "</Id>");
            sb.Append("</Othr>");
            sb.Append("</Id>");
            sb.Append("</CdtrAcct>");
            #endregion

            #region Narration
            if (pacs.InstrInf != "")
            {
                sb.Append("<InstrForNxtAgt>");
                sb.Append("<InstrInf>" + pacs.InstrInf + "</InstrInf>");
                sb.Append("</InstrForNxtAgt>");
            }
            #endregion

            sb.Append("</CdtTrfTxInf>");

            sb.Append("</FICdtTrf>");

            sb.Append("</Document>");

            sb.Append("</Body>");
            sb.Append("</DataPDU>");

            return sb.ToString();
        }
        public string GetPacs4(Pacs004 pacs, string Priority)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<DataPDU xmlns=\"urn:swift:saa:xsd:saa.2.0\">");
            sb.Append("<Body>");

            #region AppHdr
            sb.Append("<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">");
            sb.Append("<Fr>");
            sb.Append("<FIId>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>" + pacs.FrBICFI + "</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</FIId>");
            sb.Append("</Fr>");
            sb.Append("<To>");
            sb.Append("<FIId>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>BBHOBDDHRTG</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</FIId>");
            sb.Append("</To>");
            sb.Append("<BizMsgIdr>" + pacs.BizMsgIdr + "</BizMsgIdr>");
            sb.Append("<MsgDefIdr>" + pacs.MsgDefIdr + "</MsgDefIdr>");
            sb.Append("<BizSvc>" + pacs.BizSvc + "</BizSvc>");
            sb.Append("<CreDt>" + pacs.CreDt + "</CreDt>");
            sb.Append("</AppHdr>");
            #endregion

            sb.Append("<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.004.001.04\">");
            sb.Append("<PmtRtr>");

            #region GrpHdr
            sb.Append("<GrpHdr>");
            sb.Append("<MsgId>" + pacs.MsgId + "</MsgId>");
            sb.Append("<CreDtTm>" + pacs.CreDtTm + "</CreDtTm>");
            sb.Append("<NbOfTxs>" + pacs.NbOfTxs + "</NbOfTxs>");
            sb.Append("<SttlmInf>");
            sb.Append("<SttlmMtd>CLRG</SttlmMtd>");
            sb.Append("</SttlmInf>");
            sb.Append("</GrpHdr>");
            #endregion

            #region OrgnlGrpInf
            sb.Append("<OrgnlGrpInf>");
            sb.Append("<OrgnlMsgId>" + pacs.OrgnlMsgId + "</OrgnlMsgId>");
            sb.Append("<OrgnlMsgNmId>" + pacs.OrgnlMsgNmId + "</OrgnlMsgNmId>");
            sb.Append("<OrgnlCreDtTm>" + pacs.OrgnlCreDtTm + "</OrgnlCreDtTm>");
            sb.Append("<RtrRsnInf>");
            sb.Append("<Rsn>");
            sb.Append("<Prtry>" + pacs.RtrRsnCd + "</Prtry>");
            sb.Append("</Rsn>");
            sb.Append("<AddtlInf>" + pacs.RtrRsnPrtry + "</AddtlInf>");
            sb.Append("</RtrRsnInf>");
            sb.Append("</OrgnlGrpInf>");
            #endregion

            sb.Append("<TxInf>");
            sb.Append("<RtrId>" + pacs.RtrId + "</RtrId>");
            sb.Append("<OrgnlInstrId>" + pacs.OrgnlInstrId + "</OrgnlInstrId>");
            sb.Append("<OrgnlEndToEndId>" + pacs.OrgnlEndToEndId + "</OrgnlEndToEndId>");
            sb.Append("<OrgnlTxId>" + pacs.OrgnlTxId + "</OrgnlTxId>");
            sb.Append("<RtrdIntrBkSttlmAmt Ccy=\"" + pacs.RtrdIntrBkSttlmCcy + "\">" + pacs.RtrdIntrBkSttlmAmt.ToString("F2") + "</RtrdIntrBkSttlmAmt>");
            sb.Append("<IntrBkSttlmDt>" + pacs.TxInfIntrBkSttlmDt + "</IntrBkSttlmDt>");
            sb.Append("<ChrgBr>" + pacs.ChrgBr + "</ChrgBr>");

            #region Instg-Instd Agt
            if (pacs.InstgAgtBICFI != "")
            {
                sb.Append("<InstgAgt>");
                sb.Append("<FinInstnId>");
                sb.Append("<BICFI>" + pacs.InstgAgtBICFI + "</BICFI>");
                sb.Append("</FinInstnId>");
                sb.Append("</InstgAgt>");
            }
            if (pacs.InstdAgtBICFI != "")
            {
                sb.Append("<InstdAgt>");
                sb.Append("<FinInstnId>");
                sb.Append("<BICFI>" + pacs.InstdAgtBICFI + "</BICFI>");
                sb.Append("</FinInstnId>");
                sb.Append("</InstdAgt>");
            }
            #endregion

            sb.Append("<OrgnlTxRef>");
            sb.Append("<IntrBkSttlmAmt Ccy=\"" + pacs.RtrdIntrBkSttlmCcy + "\">" + pacs.TxRefIntrBkSttlmAmt.ToString("F2") + "</IntrBkSttlmAmt>");
            sb.Append("<IntrBkSttlmDt>" + pacs.TxInfIntrBkSttlmDt + "</IntrBkSttlmDt>");
            sb.Append("<PmtTpInf>");
            sb.Append("<ClrChanl>RTGS</ClrChanl>");
            sb.Append("<SvcLvl>");
            sb.Append("<Prtry>" + pacs.SvcLvlPrtry.ToString().PadLeft(4, '0') + "</Prtry>");
            sb.Append("</SvcLvl>");
            sb.Append("<LclInstrm>");
            sb.Append("<Prtry>" + pacs.LclInstrmPrtry + "</Prtry>");
            sb.Append("</LclInstrm>");
            sb.Append("<CtgyPurp>");
            sb.Append("<Prtry>" + pacs.CtgyPurpPrtry.PadLeft(3, '0') + "</Prtry>");
            sb.Append("</CtgyPurp>");
            sb.Append("</PmtTpInf>");
            sb.Append("<PmtMtd>" + pacs.PmtMtd + "</PmtMtd>");

            #region Dbtr Info
            sb.Append("<Dbtr>");
            sb.Append("<Nm>" + pacs.DbtrNm + "</Nm>");
            sb.Append("</Dbtr>");

            if (pacs.DbtrAgtBICFI != "")
            {
                sb.Append("<DbtrAgt>");
                sb.Append("<FinInstnId>");
                sb.Append("<BICFI>" + pacs.DbtrAgtBICFI + "</BICFI>");
                sb.Append("</FinInstnId>");
                if (pacs.DbtrAgtBranchId != "")
                {
                    sb.Append("<BrnchId>");
                    sb.Append("<Id>" + pacs.DbtrAgtBranchId + "</Id>");
                    sb.Append("</BrnchId>");
                }
                sb.Append("</DbtrAgt>");

                if (pacs.DbtrAgtAcctId != "")
                {
                    sb.Append("<DbtrAgtAcct>");
                    sb.Append("<Id>");
                    sb.Append("<Othr>");
                    sb.Append("<Id>" + pacs.DbtrAgtAcctId + "</Id>");
                    sb.Append("</Othr>");
                    sb.Append("</Id>");
                    if (pacs.DbtrAgtAcctPrtry != "")
                    {
                        sb.Append("<Tp>");
                        sb.Append("<Prtry>" + pacs.DbtrAgtAcctPrtry + "</Prtry>");
                        sb.Append("</Tp>");
                    }
                    sb.Append("</DbtrAgtAcct>");
                }
            }
            #endregion

            #region Cdtr Info
            if (pacs.CdtrAgtBICFI != "")
            {
                sb.Append("<CdtrAgt>");
                sb.Append("<FinInstnId>");
                sb.Append("<BICFI>" + pacs.CdtrAgtBICFI + "</BICFI>");
                sb.Append("</FinInstnId>");
                if (pacs.CdtrAgtBranchId != "")
                {
                    sb.Append("<BrnchId>");
                    sb.Append("<Id>" + pacs.CdtrAgtBranchId + "</Id>");
                    sb.Append("</BrnchId>");
                }
                sb.Append("</CdtrAgt>");
            }

            if (pacs.CdtrAgtAcctId != "")
            {
                sb.Append("<CdtrAgtAcct>");
                sb.Append("<Id>");
                sb.Append("<Othr>");
                sb.Append("<Id>" + pacs.CdtrAgtAcctId + "</Id>");
                sb.Append("</Othr>");
                sb.Append("</Id>");
                if (pacs.CdtrAgtAcctTpPrtry != "")
                {
                    sb.Append("<Tp>");
                    sb.Append("<Prtry>" + pacs.CdtrAgtAcctTpPrtry + "</Prtry>");
                    sb.Append("</Tp>");
                }
                sb.Append("</CdtrAgtAcct>");
            }

            sb.Append("<Cdtr>");
            sb.Append("<Nm>" + pacs.CdtrNm + "</Nm>");
            sb.Append("</Cdtr>");
            sb.Append("<CdtrAcct>");
            sb.Append("<Id>");
            sb.Append("<Othr>");
            sb.Append("<Id>" + pacs.CdtrAcctId + "</Id>");
            sb.Append("</Othr>");
            sb.Append("</Id>");
            sb.Append("</CdtrAcct>");
            #endregion

            sb.Append("</OrgnlTxRef>");

            sb.Append("</TxInf>");

            sb.Append("</PmtRtr>");
            sb.Append("</Document>");

            sb.Append("</Body>");
            sb.Append("</DataPDU>");

            return sb.ToString();
        }
        private Pacs008 GetSingleOutward08ByBatchBookingID(string BatchBookingID, int Counter)
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


    }
   
}