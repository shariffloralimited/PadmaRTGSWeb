using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RTGS
{
    public static class Utilities
    {
        public static string ToMoney(string amount)
        {
            Decimal d = Decimal.Parse(amount);
            string  s = d.ToString("0.00");
            char[]  c = s.ToCharArray();

            int n       = c.Length;
            string ms   = "";

            for (int i = n - 1; i > -1; i--)
            {
                if ((i == n-7)||(i == n-9)||(i == n-11))
                {
                    ms = "," + ms;
                }
                ms = c[i] + ms;
            }
            return ms;
        }

        public static Dictionary<string, string> SplitNameValuePair(string str)
        {
            Dictionary<string, string> names = new Dictionary<string, string>();
            string[] arr = str.Split('~');
            foreach (string ar1 in arr)
            {
                string[] itemArr = ar1.Split('=');
                if (itemArr.Length > 1)
                {
                    names.Add(itemArr[0], itemArr[1]);
                }
            }

            return names;
        }
    }

    public class CustomerInfo
    {
        public DataTable GetCustomerTable(string str)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("Title", typeof(String)));
            dt.Columns.Add(new DataColumn("Value", typeof(String)));

            string[] arr = str.Split('~');
            foreach (string ar1 in arr)
            {
                string[] itemArr = ar1.Split('=');
                if (itemArr.Length > 0)
                {
                    dr    = dt.NewRow();
                    dr[0] = itemArr[0];
                    //dr[1] = itemArr[1];
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            value = value.Trim();
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
