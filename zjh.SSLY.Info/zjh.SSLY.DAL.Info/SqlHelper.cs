using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.DAL.Info
{
    public static class SqlHelper
    {

        private static string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["BabySSLYInfo"];
        public static DataTable GetData(string sqlcmd)
        {
            using (SqlDataAdapter adapt = new SqlDataAdapter(sqlcmd, new SqlConnection(ConnectionString)))
            {
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                return ds.Tables[0];
            }
            return null;
        }

        public static int ExSql(string sqlcmd)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
            return 0;
        }

    }
}
