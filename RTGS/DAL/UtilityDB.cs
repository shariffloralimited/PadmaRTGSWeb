using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace RTGS
{
    public class UtilityDB
    {
        public void ExecuteSQL(string command,string database)
        {
            string conStr = "server=. ;uid=sa;pwd=bangladesh; database= "+database+"; ";
            using (SqlConnection myConnection = new SqlConnection(conStr))
            {
                using (SqlCommand myCommand = new SqlCommand(command, myConnection))
                {
                    myCommand.CommandType = CommandType.Text;

                    try
                    {
                        myConnection.Open();

                        myCommand.ExecuteNonQuery();

                        myConnection.Close();
                    }
                    catch
                    {
                    }
                }
            }

        }

        public void TruncateTable(string table, string database)
        {
            string command = "TRUNCATE TABLE [" + table + "]";
            ExecuteSQL(command, database);
        }
    }
    public static class EncryptorDecryptor
    {
        public static int key = 129;

        public static string EncryptDecrypt(string textToEncrypt)
        {
            StringBuilder inSb = new StringBuilder(textToEncrypt);
            StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
            char c;
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                c = inSb[i];
                c = (char)(c ^ key);
                outSb.Append(c);
            }
            return outSb.ToString();
        }
    }
}
