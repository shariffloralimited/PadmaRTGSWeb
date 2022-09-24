using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace RTGS
{
    public class UserInfo
    {
        public string UserID;
        public string LoginID;
        public string RoleCount;
        public string RoleID;
        public string RoleCD;
        public string DeptID;
        public string RoutingNo;
        public string BranchCD;
        public bool   AllBranch;
        public decimal TransLimit;
        public string BankCode;
        public string DeptName;
        public string UserName;
        public string RoleName;
        public string BranchName;
        public string BankName;
        public int    DaysRemaining;
        public bool   ChangePwdNow;
        public string ExpMsg;
    }
    public class PasswordPolicy
    {
        public  string PasswordPolicyTest(string Pwd, int UserID)
        {
            string result = IsMinSixDigits(Pwd);
            if (result != "OK")
            {
                return result;
            }
            result = IsNotSameAsLoginID(Pwd, UserID);
            if (result != "OK")
            {
                return result;
            }
            result = IsAlphaNumeric(Pwd);
            if (result != "OK")
            {
                return result;
            }
            result = IsRepeatingOldPassword(Pwd, UserID);
            if (result != "OK")
            {
                return result;
            }
            return "OK";
        }
        public string IsNotSameAsLoginID(string Pwd, int UserID)
        {
            UserDB user = new UserDB();
            string LoginID = "";
            //SqlDataReader dr = user.GetSingleUser(UserID);
            //while (dr.Read())
            //{
            //    LoginID = (string)dr["LoginID"];
            //}
            //dr.Close();
            //dr.Dispose();

            if (LoginID != Pwd)
            {
                return "OK";
            }
            else
            {
                return "Your Password can not be the same as your LoginID";
            }
        }
        public string IsExpiring(int DaysPassedSinceLastChange)
        {
            if (DaysPassedSinceLastChange > 44)
            {
                return "Your Password has expired. Please contact Administrator.";
            }
            if (DaysPassedSinceLastChange > 34)
            {
                return "Your Password will expire in " + (45 - DaysPassedSinceLastChange).ToString() + " day(s). Please change your password ASAP.";
            }
            return "OK";
        }
        private string IsMinSixDigits(string Pwd)
        {
            if (Pwd.Length > 5)
            {
                return "OK";
            }
            else
            {
                return "Password must be atleast 8 characters.";
            }
        }
        private string IsAlphaNumeric(string Pwd)
        {
            string alphaLow = "abcdefghijklmnopqrstuvwxyz";
            string alphaUp  = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeric  = "0123456789";
            string special  = "~!@#$%^&*";
            char[] p = Pwd.ToCharArray();

            bool AlphaLowFound = false;
            bool AlphaUpFound  = false;
            bool NumFound      = false;
            bool SpFound       = false;

            foreach (char c in p)
            {
                if (alphaLow.IndexOf(c) != -1)
                {
                    AlphaLowFound = true;
                }
                if (alphaUp.IndexOf(c) != -1)
                {
                    AlphaUpFound = true;
                } 
                if (numeric.IndexOf(c) != -1)
                {
                    NumFound = true;
                }
                if (special.IndexOf(c) != -1)
                {
                    SpFound = true;
                }
            }
            if ((AlphaLowFound) && (AlphaUpFound) && (NumFound) && (SpFound))
            {
                return "OK";
            }
            else
            {
                return "Password must contain at least one Upper case Alphabet, Lower case Alphabet, Number and Special Character.";
            }
        }
        private string IsRepeatingOldPassword(string Pwd, int UserID)
        {
            bool repeating = false;
            UserDB user   = new UserDB();
            string NewPwd = user.Encrypt(Pwd);

            SqlDataReader dr = GetLast3Passwords(UserID);
            while(dr.Read())
            {
                if (NewPwd == (string) dr["Password"])
                {
                    repeating = true;
                }
            }
            dr.Close();
            dr.Dispose();

            if (repeating)
            {
                return "Can not use the same password that you have used during the last 3 changes.";
            }
            else
            {
                return "OK";
            }
        }
        private SqlDataReader GetLast3Passwords(int UserID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("USER_GetLast3Passwords", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
    }
    public class UserDB
    {
        public UserInfo Login(string LoginID, string Password, string IPAddress)
        {
            SqlConnection sqlConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand sqlCommand = new SqlCommand("USER_Login", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
            sqlParameter.Value = LoginID;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlParameter sqlParameter2 = new SqlParameter("@Password", SqlDbType.VarChar, 50);
            sqlParameter2.Value = this.Encrypt(Password);
            sqlCommand.Parameters.Add(sqlParameter2);
            SqlParameter sqlParameter3 = new SqlParameter("@IPAddress", SqlDbType.VarChar, 30);
            sqlParameter3.Value = IPAddress;
            sqlCommand.Parameters.Add(sqlParameter3);
            SqlParameter sqlParameter4 = new SqlParameter("@UserID", SqlDbType.Int, 4);
            sqlParameter4.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter4);
            SqlParameter sqlParameter5 = new SqlParameter("@RoleCount", SqlDbType.Int, 4);
            sqlParameter5.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter5);
            SqlParameter sqlParameter6 = new SqlParameter("@RoleID", SqlDbType.Int, 4);
            sqlParameter6.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter6);
            SqlParameter sqlParameter7 = new SqlParameter("@RoleCD", SqlDbType.VarChar, 4);
            sqlParameter7.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter7);
            SqlParameter sqlParameter8 = new SqlParameter("@DeptID", SqlDbType.Int, 4);
            sqlParameter8.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter8);
            SqlParameter sqlParameter9 = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
            sqlParameter9.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter9);
            SqlParameter sqlParameter10 = new SqlParameter("@BranchCD", SqlDbType.VarChar, 4);
            sqlParameter10.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter10);
            SqlParameter sqlParameter11 = new SqlParameter("@AllBranch", SqlDbType.Bit, 1);
            sqlParameter11.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter11);
            SqlParameter sqlParameter12 = new SqlParameter("@TransLimit", SqlDbType.Money, 8);
            sqlParameter12.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter12);
            SqlParameter sqlParameter13 = new SqlParameter("@DeptName", SqlDbType.VarChar, 50);
            sqlParameter13.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter13);
            SqlParameter sqlParameter14 = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            sqlParameter14.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter14);
            SqlParameter sqlParameter15 = new SqlParameter("@RoleName", SqlDbType.VarChar, 50);
            sqlParameter15.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter15);
            SqlParameter sqlParameter16 = new SqlParameter("@BranchName", SqlDbType.VarChar, 50);
            sqlParameter16.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter16);
            SqlParameter sqlParameter17 = new SqlParameter("@BankName", SqlDbType.VarChar, 50);
            sqlParameter17.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter17);
            SqlParameter sqlParameter18 = new SqlParameter("@DaysPassed", SqlDbType.Int, 4);
            sqlParameter18.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter18);
            SqlParameter sqlParameter19 = new SqlParameter("@ChangePwdNow", SqlDbType.Bit);
            sqlParameter19.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter19);
            SqlParameter sqlParameter20 = new SqlParameter("@ExpMsg", SqlDbType.VarChar, 50);
            sqlParameter20.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter20);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            UserInfo userInfo = new UserInfo();
            userInfo.UserID = sqlParameter4.Value.ToString();
            userInfo.RoleCount = sqlParameter5.Value.ToString();
            userInfo.RoleID = sqlParameter6.Value.ToString();
            userInfo.RoleCD = (string)sqlParameter7.Value;
            userInfo.DeptID = sqlParameter8.Value.ToString();
            userInfo.RoutingNo = (string)sqlParameter9.Value;
            userInfo.BranchCD = (string)sqlParameter10.Value;
            userInfo.AllBranch = (bool)sqlParameter11.Value;
            userInfo.TransLimit = (decimal)sqlParameter12.Value;
            userInfo.DeptName = (string)sqlParameter13.Value;
            userInfo.UserName = (string)sqlParameter14.Value;
            userInfo.RoleName = (string)sqlParameter15.Value;
            userInfo.BranchName = (string)sqlParameter16.Value;
            userInfo.BankName = (string)sqlParameter17.Value;
            userInfo.DaysRemaining = (int)sqlParameter18.Value;
            userInfo.ChangePwdNow = (bool)sqlParameter19.Value;
            userInfo.ExpMsg = (string)sqlParameter20.Value;
            sqlConnection.Close();
            sqlConnection.Dispose();
            sqlCommand.Dispose();
            return userInfo;
        }
        //    SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
        //    SqlCommand myCommand = new SqlCommand("USER_Login", myConnection);
        //    myCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
        //    parameterLoginID.Value = LoginID;
        //    myCommand.Parameters.Add(parameterLoginID);

        //    SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        //    parameterPassword.Value = Encrypt(Password);
        //    myCommand.Parameters.Add(parameterPassword);

        //    SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 30);
        //    parameterIPAddress.Value = IPAddress;
        //    myCommand.Parameters.Add(parameterIPAddress);

        //    SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        //    parameterUserID.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterUserID);

        //    SqlParameter parameterRoleCount = new SqlParameter("@RoleCount", SqlDbType.Int, 4);
        //    parameterRoleCount.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterRoleCount);

        //    SqlParameter parameterRoleID = new SqlParameter("@RoleID", SqlDbType.Int, 4);
        //    parameterRoleID.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterRoleID);

        //    SqlParameter parameterRoleCD = new SqlParameter("@RoleCD", SqlDbType.VarChar, 4);
        //    parameterRoleCD.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterRoleCD);

        //    SqlParameter parameterDeptID = new SqlParameter("@DeptID", SqlDbType.Int, 4);
        //    parameterDeptID.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterDeptID);

        //    SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
        //    parameterRoutingNo.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterRoutingNo);

        //    SqlParameter parameterBranchCD = new SqlParameter("@BranchCD", SqlDbType.VarChar, 10);
        //    parameterBranchCD.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterBranchCD);

        //    SqlParameter parameterAllBranch = new SqlParameter("@AllBranch", SqlDbType.Bit, 1);
        //    parameterAllBranch.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterAllBranch);

        //    SqlParameter parameterTransLimit = new SqlParameter("@TransLimit", SqlDbType.Money, 8);
        //    parameterTransLimit.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterTransLimit);

        //    SqlParameter parameterDeptName = new SqlParameter("@DeptName", SqlDbType.VarChar, 50);
        //    parameterDeptName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterDeptName);

        //    SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        //    parameterUserName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterUserName);

        //    SqlParameter parameterRoleName = new SqlParameter("@RoleName", SqlDbType.VarChar, 50);
        //    parameterRoleName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterRoleName);

        //    SqlParameter parameterBranchName = new SqlParameter("@BranchName", SqlDbType.VarChar, 50);
        //    parameterBranchName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterBranchName);

        //    SqlParameter parameterBankName = new SqlParameter("@BankName", SqlDbType.VarChar, 50);
        //    parameterBankName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterBankName);

        //    SqlParameter parameterDaysPassed = new SqlParameter("@DaysPassed", SqlDbType.Int, 4);
        //    parameterDaysPassed.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterDaysPassed);

        //    SqlParameter parameterChangePwdNow = new SqlParameter("@ChangePwdNow", SqlDbType.Bit);
        //    parameterChangePwdNow.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterChangePwdNow);

        //    SqlParameter parameterExpMsg = new SqlParameter("@ExpMsg", SqlDbType.VarChar, 50);
        //    parameterExpMsg.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterExpMsg);
            
        //    myConnection.Open();
        //    myCommand.ExecuteNonQuery();

        //    UserInfo ui     = new UserInfo();

        //    ui.UserID       = parameterUserID.Value.ToString();
        //    ui.RoleCount    = parameterRoleCount.Value.ToString();
        //    ui.RoleID       = parameterRoleID.Value.ToString();
        //    ui.RoleCD       = (string) parameterRoleCD.Value;
        //    ui.DeptID       = parameterDeptID.Value.ToString();
        //    ui.RoutingNo    = (string) parameterRoutingNo.Value;
        //    ui.BranchCD     = (string) parameterBranchCD.Value;
        //    ui.AllBranch    = (bool)parameterAllBranch.Value;

        //    ui.TransLimit   = (decimal)parameterTransLimit.Value;
        //    ui.DeptName     = (string) parameterDeptName.Value;
        //    ui.UserName     = (string) parameterUserName.Value;
        //    ui.RoleName     = (string) parameterRoleName.Value;
        //    ui.BranchName   = (string) parameterBranchName.Value;
        //    ui.BankName     = (string) parameterBankName.Value;

        //    ui.DaysRemaining= (int) parameterDaysPassed.Value;
        //    ui.ChangePwdNow = (bool)parameterChangePwdNow.Value;

        //    ui.ExpMsg       = (string)parameterExpMsg.Value;

        //    myConnection.Close();
        //    myConnection.Dispose();
        //    myCommand.Dispose();         

        //    return ui;
        //}
        public UserInfo ADLogin(string LoginID, string BranchNumonic, string IPAddress)
        {
            SqlConnection sqlConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand sqlCommand = new SqlCommand("USER_ADLogin", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@LoginID", SqlDbType.NVarChar, 50);
            sqlParameter.Value = LoginID;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlParameter sqlParameter2 = new SqlParameter("@BranchNumonic", SqlDbType.VarChar, 4);
            sqlParameter2.Value = BranchNumonic;
            sqlCommand.Parameters.Add(sqlParameter2);
            SqlParameter sqlParameter3 = new SqlParameter("@IPAddress", SqlDbType.VarChar, 30);
            sqlParameter3.Value = IPAddress;
            sqlCommand.Parameters.Add(sqlParameter3);
            SqlParameter sqlParameter4 = new SqlParameter("@UserID", SqlDbType.Int, 4);
            sqlParameter4.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter4);
            SqlParameter sqlParameter5 = new SqlParameter("@RoleCount", SqlDbType.Int, 4);
            sqlParameter5.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter5);
            SqlParameter sqlParameter6 = new SqlParameter("@RoleID", SqlDbType.Int, 4);
            sqlParameter6.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter6);
            SqlParameter sqlParameter7 = new SqlParameter("@RoleCD", SqlDbType.VarChar, 4);
            sqlParameter7.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter7);
            SqlParameter sqlParameter8 = new SqlParameter("@DeptID", SqlDbType.Int, 4);
            sqlParameter8.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter8);
            SqlParameter sqlParameter9 = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
            sqlParameter9.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter9);
            SqlParameter sqlParameter10 = new SqlParameter("@BranchCD", SqlDbType.VarChar, 4);
            sqlParameter10.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter10);
            SqlParameter sqlParameter11 = new SqlParameter("@AllBranch", SqlDbType.Bit, 1);
            sqlParameter11.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter11);
            SqlParameter sqlParameter12 = new SqlParameter("@TransLimit", SqlDbType.Money, 8);
            sqlParameter12.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter12);
            SqlParameter sqlParameter13 = new SqlParameter("@DeptName", SqlDbType.VarChar, 50);
            sqlParameter13.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter13);
            SqlParameter sqlParameter14 = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            sqlParameter14.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter14);
            SqlParameter sqlParameter15 = new SqlParameter("@RoleName", SqlDbType.NVarChar, 50);
            sqlParameter15.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter15);
            SqlParameter sqlParameter16 = new SqlParameter("@BranchName", SqlDbType.NVarChar, 50);
            sqlParameter16.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter16);
            SqlParameter sqlParameter17 = new SqlParameter("@BankName", SqlDbType.NVarChar, 50);
            sqlParameter17.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter17);
            SqlParameter sqlParameter18 = new SqlParameter("@ChangePwdNow", SqlDbType.Bit);
            sqlParameter18.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter18);
            SqlParameter sqlParameter19 = new SqlParameter("@DaysPassed", SqlDbType.Int, 4);
            sqlParameter19.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter19);
            SqlParameter sqlParameter20 = new SqlParameter("@ExpMsg", SqlDbType.VarChar, 50);
            sqlParameter20.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter20);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            UserInfo userInfo = new UserInfo();
            userInfo.UserID = sqlParameter4.Value.ToString();
            userInfo.RoleCount = sqlParameter5.Value.ToString();
            userInfo.RoleID = sqlParameter6.Value.ToString();
            userInfo.RoleCD = (string)sqlParameter7.Value;
            userInfo.DeptID = sqlParameter8.Value.ToString();
            userInfo.RoutingNo = sqlParameter9.Value.ToString();
            userInfo.BranchCD = (string)sqlParameter10.Value;
            userInfo.AllBranch = (bool)sqlParameter11.Value;
            userInfo.TransLimit = (decimal)sqlParameter12.Value;
            userInfo.DeptName = (string)sqlParameter13.Value;
            userInfo.UserName = (string)sqlParameter14.Value;
            userInfo.RoleName = (string)sqlParameter15.Value;
            userInfo.BranchName = (string)sqlParameter16.Value;
            userInfo.BankName = (string)sqlParameter17.Value;
            userInfo.DaysRemaining = (int)sqlParameter19.Value;
            userInfo.ExpMsg = (string)sqlParameter20.Value;
            sqlConnection.Close();
            sqlConnection.Dispose();
            sqlCommand.Dispose();
            return userInfo;
        }

        //    SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
        //    SqlCommand myCommand = new SqlCommand("USER_ADLogin", myConnection);
        //    myCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.NVarChar, 50);
        //    parameterLoginID.Value = LoginID;
        //    myCommand.Parameters.Add(parameterLoginID);

        //    SqlParameter parameterBranchNumonic = new SqlParameter("@BranchNumonic", SqlDbType.VarChar, 4);
        //    parameterBranchNumonic.Value = BranchNumonic;
        //    myCommand.Parameters.Add(parameterBranchNumonic);

        //    SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 30);
        //    parameterIPAddress.Value = IPAddress;
        //    myCommand.Parameters.Add(parameterIPAddress);

        //    SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        //    parameterUserID.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterUserID);

        //    SqlParameter parameterRoleCount = new SqlParameter("@RoleCount", SqlDbType.Int, 4);
        //    parameterRoleCount.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterRoleCount);

        //    SqlParameter parameterRoleID = new SqlParameter("@RoleID", SqlDbType.Int, 4);
        //    parameterRoleID.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterRoleID);

        //    SqlParameter parameterRoleCD = new SqlParameter("@RoleCD", SqlDbType.VarChar, 4);
        //    parameterRoleCD.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterRoleCD);

        //    SqlParameter parameterDeptID = new SqlParameter("@DeptID", SqlDbType.Int, 4);
        //    parameterDeptID.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterDeptID);

        //    SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
        //    parameterRoutingNo.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterRoutingNo);

        //    SqlParameter parameterBranchCD = new SqlParameter("@BranchCD", SqlDbType.VarChar, 4);
        //    parameterBranchCD.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterBranchCD);

        //    SqlParameter parameterAllBranch = new SqlParameter("@AllBranch", SqlDbType.Bit,1);
        //    parameterAllBranch.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterAllBranch);

        //    SqlParameter parameterTransLimit = new SqlParameter("@TransLimit", SqlDbType.Money, 8);
        //    parameterTransLimit.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterTransLimit);

        //    SqlParameter parameterDeptName = new SqlParameter("@DeptName", SqlDbType.VarChar, 50);
        //    parameterDeptName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterDeptName);

        //    SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
        //    parameterUserName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterUserName);

        //    SqlParameter parameterRoleName = new SqlParameter("@RoleName", SqlDbType.NVarChar, 50);
        //    parameterRoleName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterRoleName);

        //    SqlParameter parameterBranchName = new SqlParameter("@BranchName", SqlDbType.NVarChar, 50);
        //    parameterBranchName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterBranchName);

        //    SqlParameter parameterBankName = new SqlParameter("@BankName", SqlDbType.NVarChar, 50);
        //    parameterBankName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterBankName);

        //    SqlParameter parameterChangePwdNow = new SqlParameter("@ChangePwdNow", SqlDbType.Bit);
        //    parameterChangePwdNow.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterChangePwdNow);

        //    SqlParameter parameterDaysPassed = new SqlParameter("@DaysPassed", SqlDbType.Int, 4);
        //    parameterDaysPassed.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterDaysPassed);

        //    SqlParameter parameterExpMsg = new SqlParameter("@ExpMsg", SqlDbType.VarChar, 50);
        //    parameterExpMsg.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterExpMsg);


        //    myConnection.Open();
        //    myCommand.ExecuteNonQuery();

        //    UserInfo ui = new UserInfo();

        //    ui.UserID    = parameterUserID.Value.ToString();
        //    ui.RoleCount = parameterRoleCount.Value.ToString();
        //    ui.RoleID    = parameterRoleID.Value.ToString();
        //    ui.RoleCD    = (string)parameterRoleCD.Value;
        //    ui.DeptID    = parameterDeptID.Value.ToString();
        //    ui.RoutingNo = parameterRoutingNo.Value.ToString();
        //    ui.BranchCD  = (string) parameterBranchCD.Value;
        //    ui.AllBranch = (bool) parameterAllBranch.Value;

        //    ui.TransLimit = (decimal)parameterTransLimit.Value;
        //    ui.DeptName = (string)parameterDeptName.Value;
        //    ui.UserName = (string)parameterUserName.Value;
        //    ui.RoleName = (string)parameterRoleName.Value;
        //    ui.BranchName = (string)parameterBranchName.Value;
        //    ui.BankName = (string)parameterBankName.Value;

        //    ui.DaysRemaining = (int)parameterDaysPassed.Value;
        //    ui.ExpMsg  = (string)parameterExpMsg.Value;

        //    myConnection.Close();
        //    myConnection.Dispose();
        //    myCommand.Dispose();

        //    return ui;
        //}
        public DataTable GetUserByRoutingNo(string RoutingNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("USER_GetUsersByRoutingNo", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public void LockUser(string LoginID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("USER_Lock", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.NVarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void LogOut(int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("USER_LogOut", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);


            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 30);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public int ChangePassword(int UserID, String OldPassword, String NewPassword, String IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("USER_ChangePassword", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int,4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterOldPassword = new SqlParameter("@OldPassword", SqlDbType.NVarChar, 50);
            parameterOldPassword.Value = OldPassword;
            myCommand.Parameters.Add(parameterOldPassword);

            SqlParameter parameterNewPassword = new SqlParameter("@NewPassword", SqlDbType.NVarChar, 50);
            parameterNewPassword.Value = NewPassword;
            myCommand.Parameters.Add(parameterNewPassword);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            SqlParameter parameterStatus = new SqlParameter("@Status", SqlDbType.Int, 4);
            parameterStatus.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterStatus);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            int Status = (int)parameterStatus.Value;
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return Status;
        }
        public string Encrypt(string cleanString)
        {
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}


    

