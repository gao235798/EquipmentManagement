using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentManagement.tool
{
    class data
    {
        //private static string ServerIP = "192.168.1.5";               //数据库IP地址
        //private static string Database = "yele_okmes";                //数据库名称
        //private static string ServerName = "root";                     //数据库账号名称
        //private static string ServerPwd = "okai01230!0011";                    //数据库密码  
        private static string ServerIP = "192.168.1.203";               //数据库IP地址
        private static string Database = "yele_okmes";              //数据库名称
        private static string ServerName = "root";                     //数据库账号名称
        private static string ServerPwd = "235798";                    //数据库密码
        private static MySqlConnection conn;

        //打开sql连接
        ///
        public static void join(string fac)
        {
            if (fac.Equals("野乐") || fac.Equals("yl"))
            {
                 ServerIP = "localhost";               //数据库IP地址
                 Database = "yele_okmes";              //数据库名称
                 ServerName = "root";                     //数据库账号名称
                 ServerPwd = "235798";                    //数据库密码
            }
            string connString = "server=" + ServerIP + ";database=" + Database + ";uid=" + ServerName + ";pwd=" + ServerPwd + ";SslMode = none;Charset=utf8";
            conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        //更新数据
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="fac"></param>
        public static bool update(string sql, string fac)
        {
            bool falg = true;
            join(fac);
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);
                mySqlCommand.ExecuteNonQuery();    //关闭数据库连接
                conn.Close();
            }
            catch (Exception ex)
            {
                falg = false;
            }
            return falg;
        }
        //录入数据库数据
        public static void update1(string sql, string fac)
        {

            join(fac);
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);
                mySqlCommand.ExecuteNonQuery();    //关闭数据库连接
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //查询数据返回dataset
        public static DataSet select(string sql, string fac)
        {
            join(fac);
            DataSet data = new DataSet();
            try
            {
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(sql, conn);
                mySqlData.Fill(data, "data");
                conn.Close();        //关闭数据库连接
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }
        //查询数据返回datatable
        public static DataTable selectTable(string sql, string fac)
        {
            join(fac);
            DataSet data = new DataSet();
            try
            {
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(sql, conn);
                mySqlData.Fill(data, "data");
                conn.Close();        //关闭数据库连接
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data.Tables[0];
        }

        //查询数据返回String
        public static String selectone(string sql, string fac)
        {
            String view = "";
            join(fac);
            DataSet data = new DataSet();
            try
            {
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(sql, conn);
                mySqlData.Fill(data, "data");
                conn.Close();        //关闭数据库连接
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (data == null || data.Tables[0].Rows.Count == 0)
            {
                view = "";
            }
            else
            {
                view = data.Tables[0].Rows[0][0].ToString(); //把查询信息写入
            }
            return view;
        }
    }
}
