using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace FloraSoft
{
    public class HUBFile
    {
        public string BulkExcelUpload(string Maker, string MakerIP, string BranchCD, string Tick, string fileName, string DestTableName)
        {
            string result = "";
            string Columns = System.DateTime.Today.Day.ToString() + ",'" + Maker + "','" + MakerIP + "','" + BranchCD + "','" + Tick + "',*";
            try
            {
                SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
                myConnection.Open();
                SqlBulkCopy myBulkCopy = new SqlBulkCopy(myConnection);
                myBulkCopy.BulkCopyTimeout = 300;
                myBulkCopy.DestinationTableName = DestTableName;

                DataTable excelDT = new DataTable();
                string excelConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";
                OleDbConnection myExcelConn = new OleDbConnection(excelConnString);
                myExcelConn.Open();

                DataTable dbSchema = myExcelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dbSchema == null || dbSchema.Rows.Count < 1)
                {
                    throw new Exception("Error: Could not determine the name of the first worksheet.");
                }
                string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();

                
                OleDbCommand myCmdExcel = new OleDbCommand();
                myCmdExcel.CommandText = "SELECT " + Columns + " FROM [" + firstSheetName + "]";
                myCmdExcel.Connection = myExcelConn;

                OleDbDataAdapter oda = new OleDbDataAdapter();
                oda.SelectCommand = myCmdExcel;
                oda.Fill(excelDT);

                myExcelConn.Close();

                myBulkCopy.WriteToServer(excelDT);
                myConnection.Close();
                result = "Uploaded";
            }
            catch (Exception ex)
            {
                result = "Error: " + ex.ToString();
            }
            return result;
        }

        public void ExecuteSQL(string commandText)
        {
            SqlConnection connection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = commandText;

            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch 
            {
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
        public void ValidateData08(string Tick)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_ValidateData08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterTick = new SqlParameter("@Tick", SqlDbType.VarChar, 50);
            parameterTick.Value = Tick;
            myCommand.Parameters.Add(parameterTick);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public int MoveToMain08(string Tick)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_MoveToMain08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            //SqlParameter parameterTick = new SqlParameter("@Tick", SqlDbType.VarChar, 50);
            //parameterTick.Value = Tick;
            //myCommand.Parameters.Add(parameterTick);

            SqlParameter parameterRowsUploaded = new SqlParameter("@RowsUploaded", SqlDbType.Int, 4);
            parameterRowsUploaded.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRowsUploaded);

            SqlParameter parameterTick = new SqlParameter("@Tick", SqlDbType.VarChar, 50);
            parameterTick.Value = Tick;
            myCommand.Parameters.Add(parameterTick);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            int RowsUploaded = (int)parameterRowsUploaded.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return RowsUploaded;
        }
        public int MoveToMain09(string Tick)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_MoveToMain09", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterTick = new SqlParameter("@Tick", SqlDbType.VarChar, 50);
            parameterTick.Value = Tick;
            myCommand.Parameters.Add(parameterTick);

            SqlParameter parameterRowsUploaded = new SqlParameter("@RowsUploaded", SqlDbType.Int, 4);
            parameterRowsUploaded.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRowsUploaded);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            int RowsUploaded = (int)parameterRowsUploaded.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return RowsUploaded;
        }
        public int MoveToMain(int DeptID, string Maker, string MakerIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_MoveToMain", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterDeptID = new SqlParameter("@DeptID", SqlDbType.Int, 4);
            parameterDeptID.Value = DeptID;
            myCommand.Parameters.Add(parameterDeptID);

            SqlParameter parameterMaker = new SqlParameter("@Maker", SqlDbType.VarChar, 50);
            parameterMaker.Value = Maker;
            myCommand.Parameters.Add(parameterMaker);

            SqlParameter parameterMakerIP = new SqlParameter("@MakerIP", SqlDbType.VarChar, 50);
            parameterMakerIP.Value = MakerIP;
            myCommand.Parameters.Add(parameterMakerIP);

            SqlParameter parameterRowsUploaded = new SqlParameter("@RowsUploaded", SqlDbType.Int, 4);
            parameterRowsUploaded.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRowsUploaded);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            int RowsUploaded = (int)parameterRowsUploaded.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return RowsUploaded;
        }
        //public string GetCurDBName()
        //{
        //    SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
        //    SqlCommand myCommand = new SqlCommand("ACH_GetCurrentDB", myConnection);
        //    myCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterCurDBName = new SqlParameter("@CurDBName", SqlDbType.VarChar, 11);
        //    parameterCurDBName.Direction = ParameterDirection.Output;
        //    myCommand.Parameters.Add(parameterCurDBName);

        //    myConnection.Open();
        //    myCommand.ExecuteNonQuery();

        //    string CurDBName = (string)parameterCurDBName.Value;

        //    myConnection.Close();
        //    myConnection.Dispose();
        //    myCommand.Dispose();
        //    return CurDBName;
        //}
    }
}