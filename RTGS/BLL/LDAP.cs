using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
namespace UTILITY
{
    public static class DirectoryHelper
    {

        public static SearchResult serachLogin(string username, string userpassword)
        {
            try
            {
                // create LDAP connection object  

                DirectoryEntry myLdapConnection = createDirectoryEntry(username, userpassword);

                // create search object which operates on LDAP connection object  
                // and set search object to only find the user specified  

                DirectorySearcher search = new DirectorySearcher(myLdapConnection);
                search.Filter = "(samaccountname=" + username + ")";

                // create results objects from search object  

                string[] requiredProperties = new string[] { "cn", "displayname", "mail", "department", "mobile", "physicaldeliveryofficename", "samaccountname" };

                foreach (String property in requiredProperties)
                    search.PropertiesToLoad.Add(property);

                SearchResult result = search.FindOne();


                if (result != null)
                {
                    return result;
                }
                else return null;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null; 
            }
        }
        public static SearchResult serachLogin1(string username)
        {
            try
            {
                // create LDAP connection object  

                DirectoryEntry myLdapConnection = createDirectoryEntry1(username);

                // create search object which operates on LDAP connection object  
                // and set search object to only find the user specified  

                DirectorySearcher search = new DirectorySearcher(myLdapConnection);
                search.Filter = "(samaccountname=" + username + ")";

                // create results objects from search object  

                string[] requiredProperties = new string[] { "cn", "displayname", "mail", "department", "mobile", "physicaldeliveryofficename", "samaccountname" };

                foreach (String property in requiredProperties)
                    search.PropertiesToLoad.Add(property);

                SearchResult result = search.FindOne();


                if (result != null)
                {
                    return result;
                }
                else return null;
            }
            catch { return null; }
        }
       private static DirectoryEntry createDirectoryEntry(string username, string userpassword)
        {
            // create and return new LDAP connection with desired settings  

            DirectoryEntry ldapConnection = new DirectoryEntry("abbl.org", username, userpassword);
            ldapConnection.Path = "LDAP://abbl.org";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

            return ldapConnection;
        }
       static DirectoryEntry createDirectoryEntry1(string username)
       {
           // create and return new LDAP connection with desired settings  

           DirectoryEntry ldapConnection = new DirectoryEntry("abbl.org");
           ldapConnection.Path = "LDAP://abbl.org";
           ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

           return ldapConnection;
       }
        //public static string ConvertNativeDigits(string text)
        //{
        //    if (text == null)
        //        return null;
        //    if (text.Length == 0)
        //        return string.Empty;
        //    StringBuilder sb = new StringBuilder();
        //    foreach (char character in text)
        //    {
        //        if (char.IsDigit(character))
        //        {
        //            sb.Append(char.GetNumericValue(character));
        //        }
        //        else
        //            sb.Append(character);
        //    }
        //    return sb.ToString();
        //}

        //public static string ConvertDigitsToBangla(string text)
        //{
        //    if (text == null)
        //        return null;
        //    if (text.Length == 0)
        //        return string.Empty;
        //    StringBuilder sb = new StringBuilder();
        //    foreach (char character in text)
        //    {
        //        if (char.IsDigit(character))
        //        {
        //            sb.Append(GetBangla(character));
        //        }
        //        else
        //            sb.Append(character);
        //    }
        //    return sb.ToString();
        //}

        

    }
}
