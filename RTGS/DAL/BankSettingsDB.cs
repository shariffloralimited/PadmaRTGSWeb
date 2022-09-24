using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FloraSoft
{
    public class BankSettings
    {
        public string   BankName            = "";
        public string   BankCD              = "";
        public string   BIC                 = "";
        public string   BBBIC               = "";
        public string   HOBranchID          = "";
        public string   ContactName         = "";
        public string   ContactNumber       = "";
        public bool     AuthorizerEnabled   = false;
        public bool     DeptBanking         = false;
        public bool     SkipCBS             = false;
        public bool     CBSQuery            = false;
        public decimal  Chrg = 0;
        public decimal  AutoMXAmnt          = 0;
        public int      CamtInterval        = 0;
        public decimal  VAT                 = 0;
        public string   DBSize              = "";
        public int      SecsPaused          = 0;
        public string   OutParkingGL        = "";
        public int      MorCutOffHr         = 0;
        public int      MorCutOffMin        = 0;
        public int      AftrCutOffHr        = 0;
        public int      AftrCutOffMin       = 0;

    }
    public class BankSettingsDB
    {
        public BankSettings GetBankSettings()
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_GetBankSetting", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
     
            SqlParameter parameterBankName = new SqlParameter("@BankName", SqlDbType.VarChar, 40);
            parameterBankName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBankName);

            SqlParameter parameterBankCD = new SqlParameter("@BankCD", SqlDbType.VarChar, 3);
            parameterBankCD.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBankCD);

            SqlParameter parameterBIC = new SqlParameter("@BIC", SqlDbType.VarChar, 10);
            parameterBIC.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBIC);

            SqlParameter parameterBBBIC = new SqlParameter("@BBBIC", SqlDbType.VarChar, 12);
            parameterBBBIC.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBBBIC);

            SqlParameter parameterHOBranchID = new SqlParameter("@HOBranchID", SqlDbType.VarChar, 9);
            parameterHOBranchID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterHOBranchID);

            SqlParameter parameterContactName = new SqlParameter("@ContactName", SqlDbType.VarChar, 14);
            parameterContactName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterContactName);

            SqlParameter parameterContactNumber = new SqlParameter("@ContactNumber", SqlDbType.VarChar, 15);
            parameterContactNumber.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterContactNumber);

            SqlParameter parameterAuthorizerEnabled = new SqlParameter("@AuthorizerEnabled", SqlDbType.Bit);
            parameterAuthorizerEnabled.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAuthorizerEnabled);

            SqlParameter parameterDeptBanking = new SqlParameter("@DeptBanking", SqlDbType.Bit);
            parameterDeptBanking.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterDeptBanking);

            SqlParameter parameterSkipCBS = new SqlParameter("@SkipCBS", SqlDbType.Bit);
            parameterSkipCBS.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterSkipCBS);

            //SqlParameter parameterCBSQuery = new SqlParameter("@CBSQuery", SqlDbType.Bit);
            //parameterCBSQuery.Direction = ParameterDirection.Output;
            //myCommand.Parameters.Add(parameterCBSQuery);

            SqlParameter parameterAutoMXAmnt = new SqlParameter("@AutoMXAmnt", SqlDbType.Money);
            parameterAutoMXAmnt.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAutoMXAmnt);

            SqlParameter parameterCamtInterval = new SqlParameter("@CamtInterval", SqlDbType.Int, 4);
            parameterCamtInterval.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterCamtInterval);

            SqlParameter parameterChrg = new SqlParameter("@Chrg", SqlDbType.Money);
            parameterChrg.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterChrg);

            SqlParameter parameterVAT = new SqlParameter("@VAT", SqlDbType.Money);
            parameterVAT.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterVAT);

            SqlParameter parameterDBSize = new SqlParameter("@DBSize", SqlDbType.VarChar, 6);
            parameterDBSize.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterDBSize);

            SqlParameter parameterSecsPaused = new SqlParameter("@SecsPaused", SqlDbType.Int);
            parameterSecsPaused.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterSecsPaused);

            SqlParameter parameterOutParkingGL = new SqlParameter("@OutParkingGL", SqlDbType.VarChar, 35);
            parameterOutParkingGL.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterOutParkingGL);

            SqlParameter parameterMorCutOffHr = new SqlParameter("@MorCutOffHr", SqlDbType.Int);
            parameterMorCutOffHr.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterMorCutOffHr);

            SqlParameter parameterMorCutOffMin = new SqlParameter("@MorCutOffMin", SqlDbType.Int);
            parameterMorCutOffMin.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterMorCutOffMin);

            SqlParameter parameterAftrCutOffHr = new SqlParameter("@AftrCutOffHr", SqlDbType.Int);
            parameterAftrCutOffHr.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAftrCutOffHr);

            SqlParameter parameterAftrCutOffMin = new SqlParameter("@AftrCutOffMin", SqlDbType.Int);
            parameterAftrCutOffMin.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAftrCutOffMin);
            
            myConnection.Open();
            myCommand.ExecuteNonQuery();

            BankSettings bs = new BankSettings();

            bs.BankName         = (string) parameterBankName.Value;
            bs.BankCD           = (string) parameterBankCD.Value;
            bs.BIC              = (string) parameterBIC.Value;
            bs.BBBIC            = (string) parameterBBBIC.Value;
            bs.HOBranchID       = (string)parameterHOBranchID.Value;
            bs.ContactName      = (string) parameterContactName.Value;
            bs.ContactNumber    = (string) parameterContactNumber.Value;
            bs.AuthorizerEnabled= (bool)parameterAuthorizerEnabled.Value;
            bs.DeptBanking      = (bool)parameterDeptBanking.Value;
            bs.SkipCBS          = (bool)parameterSkipCBS.Value;
            //bs.CBSQuery         = (bool)parameterCBSQuery.Value;
            bs.AutoMXAmnt       = (decimal)parameterAutoMXAmnt.Value;
            bs.CamtInterval     = (int)parameterCamtInterval.Value;
            bs.Chrg             = (decimal)parameterChrg.Value;
            bs.VAT              = (decimal) parameterVAT.Value;
            bs.DBSize           = (string)parameterDBSize.Value;
            bs.SecsPaused       = (int)parameterSecsPaused.Value;

            bs.OutParkingGL     = (string)parameterOutParkingGL.Value;
            bs.MorCutOffHr      = (int)parameterMorCutOffHr.Value;
            bs.MorCutOffMin     = (int)parameterMorCutOffMin.Value;
            bs.AftrCutOffHr     = (int)parameterAftrCutOffHr.Value;
            bs.AftrCutOffMin    = (int)parameterAftrCutOffMin.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();          

            return bs;
        }

        public void PauseOutward(int Mins)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_PauseOutward", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterMins = new SqlParameter("@Mins", SqlDbType.Int, 4);
            parameterMins.Value = Mins;
            myCommand.Parameters.Add(parameterMins);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            myConnection.Dispose();
            myCommand.Dispose();   

        }

        public void UpdateBankSettings(decimal AutoMXAmnt, int CamtInterval, bool SkipCBS, string OutParkingGL, int MorCutOffHr, int MorCutOffMin, int AftrCutOffHr, int AftrCutOffMin)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ADM_UpdateBankSettings", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterAutoMXAmnt = new SqlParameter("@AutoMXAmnt", SqlDbType.Money);
            parameterAutoMXAmnt.Value = AutoMXAmnt;
            myCommand.Parameters.Add(parameterAutoMXAmnt);

            SqlParameter parameterCamtInterval = new SqlParameter("@CamtInterval", SqlDbType.Int);
            parameterCamtInterval.Value = CamtInterval;
            myCommand.Parameters.Add(parameterCamtInterval);

            SqlParameter parameterSkipCBS = new SqlParameter("@SkipCBS", SqlDbType.Bit);
            parameterSkipCBS.Value = SkipCBS;
            myCommand.Parameters.Add(parameterSkipCBS);

            SqlParameter parameterOutParkingGL = new SqlParameter("@OutParkingGL", SqlDbType.VarChar,35);
            parameterOutParkingGL.Value = OutParkingGL;
            myCommand.Parameters.Add(parameterOutParkingGL);

            SqlParameter parameterMorCutOffHr = new SqlParameter("@MorCutOffHr", SqlDbType.Int);
            parameterMorCutOffHr.Value = MorCutOffHr;
            myCommand.Parameters.Add(parameterMorCutOffHr);

            SqlParameter parameterMorCutOffMin = new SqlParameter("@MorCutOffMin", SqlDbType.Int);
            parameterMorCutOffMin.Value = MorCutOffMin;
            myCommand.Parameters.Add(parameterMorCutOffMin);

            SqlParameter parameterAftrCutOffHr = new SqlParameter("@AftrCutOffHr", SqlDbType.Int);
            parameterAftrCutOffHr.Value = AftrCutOffHr;
            myCommand.Parameters.Add(parameterAftrCutOffHr);

            SqlParameter parameterAftrCutOffMin = new SqlParameter("@AftrCutOffMin", SqlDbType.Int);
            parameterAftrCutOffMin.Value = AftrCutOffMin;
            myCommand.Parameters.Add(parameterAftrCutOffMin); 

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            myConnection.Dispose();
            myCommand.Dispose();

        }
    }
}