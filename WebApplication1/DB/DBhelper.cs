using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DB
{
    public static class DBhelper
    {
        public static string crm_member() { return "crm_wathet_member"; }
        public static SqlConnection Db(this string Initial_Catalog)
        {
            string config = $"Pooling=true;Min Pool Size=4;Max Pool Size=150;Data Source=rm-uf62qu999u55hl4796o.sqlserver.rds.aliyuncs.com;Initial Catalog={Initial_Catalog};Persist Security Info=True;User ID=sy_member;Password=7NuEXRkYh%Y#K;Connect Timeout=30;";
            SqlConnection conn = new SqlConnection(config);
            if (conn.State==System.Data.ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
            else if (conn.State==System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        public static DataTable ExecuteDT(this SqlConnection conn,string sql)
        {
            DataTable table = new DataTable();
            SqlCommand com = new SqlCommand(sql,conn);
            //DataSet set = new DataSet();
            //SqlDataReader dataReader = com.ExecuteReader();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
            dataAdapter.Fill(table);
            //dataAdapter.Fill(set);
            dataAdapter.Dispose();
            return table;
        }
    }
}
