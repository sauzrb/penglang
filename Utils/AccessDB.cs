using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using Sau.Util;
namespace PengLang
{
    public class AccessDatabase
    {
        #region class members

        private static  int ConnTimes = 10;
        private static OleDbConnection dbConn = null;
     
        private static string dbFile = ""; 
        
        public static string DatabaseFile
        {
            get { return dbFile; }
            set { dbFile = value; }
        }

        #endregion

        public static bool Connect()
        {
            //string sql = "Provider=Microsoft.ACE.OLEDB.14.0;Data Source ={0}";
            string sql = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={0}";
            //string sql = "Provider=Microsoft.ACE.OLEDB.12.0;jet oledb:database password=saunsail;Data Source ={0}";

            string constr = String.Format(sql, dbFile); 
            if (dbConn == null)
                dbConn = new OleDbConnection(constr);
            
            dbConn.Open();
            

            return Database.IsConnected();
        } 
      
        public static bool IsConnected()
        {
            if (dbConn == null)
            {
                return false;
            }
            if (dbConn.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CloseDB()
        {
            if (dbConn == null)
                return false;
            if (dbConn != null)
                dbConn.Close(); 
            return true;
        }

        public static DataTable Select(string sql)
        {
            OleDbConnection conn = dbConn;

           DataTable dtResult = null;
           OleDbDataAdapter adapt = null;
           DataSet ds = null;
           for (int i = 0; i <= ConnTimes; i++)
           {
               try
               {
                   adapt = new OleDbDataAdapter(sql, conn); 
                   ds = new DataSet();
                   adapt.Fill(ds );
                   dtResult = ds.Tables[0];
                   break;
               }
               catch (SqlException e)
               {
                   string LogCont = "错误信息：" + e.Message.Trim() + "，错误语句：" + sql + "，错误时间：" + System.DateTime.Now.ToString().Trim() + "\r\n";
                   DatabaseLog.WriteLog(LogCont);
                   if (MessageBox.Show("当前数据库连接失败，您是否尝试重新连接？\r\n    点击“是”继续连接；点击“否”退出系统。", "", MessageBoxButtons.YesNo) == DialogResult.No) Environment.Exit(0);
                   else
                   {
                       if (i >= ConnTimes)
                       {
                           MessageBox.Show("已经超过最大连接次数，点击确定后退出！");
                           Environment.Exit(0);
                       }
                       else
                           Database.Connect();
                   }
               }
               finally
               { 
                   if (adapt != null) adapt.Dispose();
                   if (ds != null) ds.Dispose();
               }
           }
           return dtResult;
       }

        /// <summary>
       /// 分页查询
       /// </summary>
       /// <param name="table">表、视图名称</param>
       /// <param name="fields">查询字段</param>
       /// <param name="filter">过滤条件</param>
       /// <param name="order">排序条件</param>
       /// <param name="page">页号码</param>
       /// <param name="limit">页大小</param>
       /// <returns></returns>
        public DataTable Select(string table, string fields, string filter, string order, int page, int limit)
        {
           return null;
       
        }

        /// <summary>
       /// 更新数据库操作，包括删除、修改与添加
       /// </summary>
        public static int ExecuteSQL(string sql, string modelForm="")
        {
            OleDbConnection conn = dbConn;
            int iResult = -1;
            OleDbCommand cmd = null;
            for (int i = 0; i <= ConnTimes; i++)
            {
                try
                {
                    cmd = new OleDbCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    iResult = cmd.ExecuteNonQuery();

                    string LogCont = "【正常】："+ "模块名称："+modelForm +  "，执行语句：" + sql + "，执行时间：" + System.DateTime.Now.ToString().Trim() + "\r\n";
                    DatabaseLog.WriteLog(LogCont);

                    break;
                }
                catch (SqlException e)
                {
                    string LogCont = "【错误】：" + "模块名称：" + modelForm + ",错误信息:" + e.Message.Trim() + "，错误语句：" + sql + "，错误时间：" + System.DateTime.Now.ToString().Trim() + "\r\n";
                    DatabaseLog.WriteLog(LogCont);
                    if (MessageBox.Show("当前数据库连接失败，您是否尝试重新连接？\r\n    点击“是”继续连接；点击“否”退出系统。", "", MessageBoxButtons.YesNo) == DialogResult.No) Environment.Exit(0);
                    else
                    {
                        if (i >= ConnTimes)
                        {
                            MessageBox.Show("已经超过最大连接次数，点击确定后退出！");
                            Environment.Exit(0);
                        }
                        else Database.Connect();
                    }
                }
                finally
                {
                    if (cmd != null) cmd.Dispose();
                }
            }
            return iResult;
        }
               
        /// <summary>
       /// 批量执行SQL语句，无返回结果。
       /// </summary>
       /// <param name="varSqlList"></param>
        void ExecuteSQL(List<string> sqlList)
        {
           
        }

        public static String GetGlobalKey()
        {

            return System.Guid.NewGuid().ToString("N");
        }

        public static string GetDataTimekey(int typeNo)
        {
            string dt = DateTime.Now.ToString("yyyyMMddHHmmssms");
            return dt + typeNo.ToString().PadLeft(2, '0');
            
        }
       
        public static string GetDataTimekey(int typeNo,int id)
        {
            string dt = DateTime.Now.ToString("yyyyMMddHHmmssms");
            return dt + typeNo.ToString().PadLeft(2, '0')+id.ToString().PadLeft(4,'0');

        }

        public static string GetDateString()
        {
            string dt = DateTime.Now.ToString("yyyy-MM-dd");
            return dt;
        }

        public static string GetTimeString()
        {
            string dt = DateTime.Now.ToString("HH:mm:ss");
            return dt;
        }

        public static string GetDateTimeString()
        {
            string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return dt  ;
        }


    }
}
