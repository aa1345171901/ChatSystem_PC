using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQ_piracy
{
    public class DBHelper
    {
        private static string CONNECTIONSTRING = "database=sjksx_qq;data source=127.0.0.1;port=3306;user=root;password=root;";
        public static MySqlConnection Connect()
        {
            MySqlConnection conn = new MySqlConnection(CONNECTIONSTRING);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine("链接数据库时出现异常：\n" + e);
                return null;
            }
        }

        public static void CloseConnection(MySqlConnection conn)
        {
            if (conn != null)
                conn.Close();
            else
            {
                Console.WriteLine("MySqlConnection不能为空");
            }
        }
    }
}
