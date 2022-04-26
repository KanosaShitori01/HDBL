using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace CLSB
{
    public class onewaycls
    {
        public static DataTable selectData(string tableName)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(String.Format("SELECT * FROM {0}", tableName), ketnoicls.conn);
            adap.Fill(dt);
            return dt;
        }
        public static DataTable queryAdapFree(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(query, ketnoicls.conn);
            adap.Fill(dt);
            return dt;
        }
        public static string insertData(string tableName, Dictionary<string, object> dataInsert)
        {
            string queryKey = "";
            string queryVal = "";
            string res = "";
            foreach(var i in dataInsert){
                queryKey += i.Key + ",";
                queryVal += i.Value + ",";
            }
            string queryK = queryKey.Substring(0, queryKey.Length - 1);
            string queryV = queryVal.Substring(0, queryVal.Length - 1);
            //return String.Format("INSERT INTO {0}({1}) VALUES({2})", tableName, queryK, queryV);
            SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO {0}({1}) VALUES({2})", tableName, queryK, queryV),
                ketnoicls.conn);
            cmd.Connection.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                res = "Đã Thêm Thành Công";
            }
            else res = "Có Lỗi Thành Công";
            cmd.Connection.Close();
            return res;
        }
    }
}
