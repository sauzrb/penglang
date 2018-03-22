using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
 
using System.Windows.Forms;
using System.IO;
using Sau.Util;

//mySQL数据库访问及SQL操作类
namespace Sau.Util
{
    public class Database
    {
        #region class members

        public static string Encrypt = "0"; //1加密，0原码
        public static string Host = "localhost";
        public static string Inst = "";
        public static string Port = "3306";
        public static string User = "root";
        public static string Psw = "ssaa";
        public static string DbName = "penglan3";
        public static string CharSet = "gb2312";
        private static  int ConnTimes = 10;

       // private static OleDbConnection dbConn = null;
        private static MySqlConnection dbConn = null;

        public static MySqlConnection DatabaseConnection
        {
            get { return dbConn; }
        }

        #endregion

        #region 数据库连接状态

        public static bool Connect()
        { 
         
            if (dbConn == null)
                dbConn = new MySqlConnection();

            string strCon = String.Format("Database='{0}';Data Source='{1}'; Port = '{2}';User Id='{3}';Password='{4}';charset='{5}';pooling=true ",//;Persist Security Info=True
              DbName,
              Host,
              Port,
              User,
              Psw,
              CharSet);

            MySqlConnection conn = dbConn ;

            try
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
                conn.ConnectionString = strCon;
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    return true;
                else
                    return false;
            }
            catch (MySqlException e)
            {
                string LogCont = "错误信息：" + e.Message.Trim() + "，错误时间：" + System.DateTime.Now.ToString().Trim() + "\r\n";
                DatabaseLog.WriteLog(LogCont);
                return false;
            }
             
        }

        public static string ConnectionString
        {
            get
            {
                string strCon = String.Format("Database='{0}';Data Source='{1}'; Port = '{2}';User Id='{3}';Password='{4}';charset='{5}';pooling=true ",//;Persist Security Info=True
                     DbName,
                     Host,
                     Port,
                     User,
                     Psw,
                     CharSet);

                return strCon;
            }
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

        #endregion

        #region 数据查询

        /// <summary>
        /// 数据库查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>结果集</returns>
        public static DataTable Select(string sql)
        {
            MySqlConnection Conn = dbConn;

            DataTable dtResult = null;
            MySqlCommand Cmd = null;
            MySqlDataAdapter Adapt = null;
            DataSet Ds = null;
            for (int i = 0; i <= ConnTimes; i++)
            {
                try
                {
                    Cmd = new MySqlCommand(sql, Conn);
                    Cmd.CommandType = CommandType.Text;
                    Adapt = new MySqlDataAdapter(Cmd);
                    Ds = new DataSet();
                    Adapt.Fill(Ds);
                    dtResult = Ds.Tables[0];
                    break;
                }
                catch (MySqlException e)
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
                        else Connect();
                    }
                }
                finally
                {
                    if (Cmd != null) Cmd.Dispose();
                    if (Adapt != null) Adapt.Dispose();
                    if (Ds != null) Ds.Dispose();
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
        public static DataTable Select(string table, string fields, string filter, string order, int page, int limit)
        {
            int beg = (page - 1) * limit;//mysql 从0开始
            //int end = beg + limit  ;

            String sql = "";


            //有过滤条件，和排序条件
            if (filter.Length > 0 && order.Length > 0)
            {
                sql = String.Format("select {0} from {1} where {2} order by {3} limit {4} ,{5}",
                    fields,
                    table,
                    filter,
                    order,
                    beg,
                    limit);
                return Select(sql);
            }

            //有过滤条件，没有排序条件
            if (filter.Length > 0 && order.Length == 0)
            {

                sql = String.Format("select {0} from {1} where {2}   limit {3} ,{4}",
                    fields,
                    table,
                    filter,
                    beg,
                    limit);
                return Select(sql);
            }

            //没有过滤条件，有排序条件
            if (filter.Length == 0 && order.Length > 0)
            {

                sql = String.Format("select {0} from {1} order by {2} limit {3} ,{4}",
                    fields,
                    table,
                    order,
                    beg,
                    limit);
                return Select(sql);

            }

            //没有过滤条件，没有排序条件
            if (filter.Length == 0 && filter.Length == 0)
            {

                sql = String.Format("select {0} from {1} limit {2} ,{3} ",
                        fields,
                        table,
                        beg,
                        limit);

                return Select(sql);
            }
            return null;
        }

        #endregion

        #region 数据更新

        /// <summary>
       /// 更新数据库操作，包括删除、修改与添加
       /// </summary>
        public static int ExecuteSQL(string sql, string modelForm = "")
        {
            MySqlConnection Conn = dbConn;
            int iResult = -1;
            MySqlCommand Cmd = null;
            for (int i = 0; i <= ConnTimes; i++)
            {
                try
                {
                    Cmd = new MySqlCommand(sql, Conn);
                    Cmd.CommandType = CommandType.Text;
                    
                    iResult = Cmd.ExecuteNonQuery();

                    string LogCont = "【正常】：" + "模块名称：" + modelForm + "，执行语句：" + sql + "，执行时间：" + System.DateTime.Now.ToString().Trim() + "\r\n";
                    DatabaseLog.WriteLog(LogCont);

                    break;
                }
                catch (MySqlException e)
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
                        else  Connect();
                    }
                }
                finally
                {
                    if (Cmd != null) Cmd.Dispose();
                }
            }
            return iResult;
        }
           
        /// <summary>
        /// 批量执行SQL语句，无返回结果。
        /// </summary>
        /// <param name="varSqlList"></param>
        public static int BatchExecuteSQL(List<string> sqlList, int batchSize = 500)
        {
            int iResult = 0;

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                if (conn.State != ConnectionState.Open)
                    return -1;
                string sql = "";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = null;

                //计算批量提交次数
                int commitCount = 1;
                if (sqlList.Count % batchSize > 0)
                    commitCount = sqlList.Count / batchSize + 1;
                else
                    commitCount = sqlList.Count / batchSize;

                try
                {

                    for (int i = 0; i < commitCount; i++)
                    {
                        tx = conn.BeginTransaction();
                        cmd.Transaction = tx;

                        sql = GetBatchExecuteSql(sqlList, i * batchSize, batchSize);

                        cmd.CommandText = sql;
                        iResult+=cmd.ExecuteNonQuery();
                        tx.Commit();
                    }

                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    tx.Rollback();
                    string LogCont = "错误信息：" + e.Message.Trim() + "，错误语句：" + cmd.CommandText + "，错误时间：" + System.DateTime.Now.ToString().Trim() + "\r\n";
                    DatabaseLog.WriteLog(LogCont);
                }
            }

            return iResult;
        }

        //批量插入语句
        //MySQL
        public static int BatchInsertSql(string insertSql, List<string> values, int batchSize = 500)
        {
            int iResult = 0;
             using (MySqlConnection conn = new MySqlConnection(ConnectionString) )
             {
                 conn.Open();
                 if (conn.State != ConnectionState.Open )
                     return -1;
                 string sql = "";
                 MySqlCommand cmd = new MySqlCommand();
                 cmd.Connection = conn;
                 MySqlTransaction tx = null;
                 
                 //计算批量提交次数
                 int commitCount = 1;
                 if (values.Count % batchSize > 0)
                     commitCount = values.Count / batchSize + 1;
                 else
                     commitCount = values.Count / batchSize;

                 try 
                 {
                     
                     for (int i = 0; i < commitCount; i++)
                     {
                         tx = conn.BeginTransaction();
                         cmd.Transaction = tx;

                         sql = GetBatchInsertSql( insertSql, values, i * batchSize, batchSize );
                          
                         cmd.CommandText = sql;
                         iResult += cmd.ExecuteNonQuery();
                         tx.Commit();          
                     }

                 }
                 catch (System.Data.SqlClient.SqlException e)
                 {
                     tx.Rollback();
                     string LogCont = "错误信息：" + e.Message.Trim() + "，错误语句：" + cmd.CommandText + "，错误时间：" + System.DateTime.Now.ToString().Trim() + "\r\n";
                     DatabaseLog.WriteLog(LogCont);
                 }
             }

             return iResult;
        }

         //提取批量插入SQL语句
         //INSERT INTO TABLES (LABLE1,LABLE2,LABLE3,...) 
         //VALUES(NUM11,NUM12,NUM13,...), 
         //(NUM21,NUM22,NUM23,...),
         //....
         //(NUMn1,NUMn2,NUMn3,..);
        private static string GetBatchInsertSql(string sqlIns, List<string> values, int begin, int size)
        {
            string sql = sqlIns + " VALUES ";

            if (begin == values.Count || size == 0 || begin < 0)
                return string.Empty;

            sql += values[begin];
            int i = 1, sum = 0;
            for ( i = 1; i < size && begin + i < values.Count; i++)
            {
                sql += string.Format(",{0}", values[begin + i]);
                sum++;
            }

            sql += ";";
            return sql;
        }

        private static string GetBatchExecuteSql( List<string> values, int begin, int size)
        {
            string sql = "";

            if (begin == values.Count || size == 0 || begin < 0)
                return string.Empty;

            int i = 1, sum = 0;
            for (i = 0; i < size && begin + i < values.Count; i++)
            {
                sql += string.Format("{0};", values[begin + i]);
                sum++;
            }

            return sql;
        
        }

        #endregion

        #region 存储过程

        public static void ExecuteProc(string procName)
        {
            ExecuteProc(procName, null);
        }

        public static void ExecuteProc(string sql, params MySqlParameter[] cmdParms )
        {
            MySqlConnection Conn = dbConn;
            int iResult = -1;
            MySqlCommand Cmd = null;
            for (int i = 0; i <= ConnTimes; i++)
            {
                try
                {
                    Cmd = new MySqlCommand(sql, Conn);
                    if (cmdParms != null && cmdParms.Length > 0)
                    {

                        Cmd.Parameters.AddRange(cmdParms);
                    }

                    Cmd.CommandType = CommandType.StoredProcedure;

                    iResult = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear(); 
                    break;
                }
                catch (MySqlException e)
                {
                    string LogCont = "【错误】：" + "存储过程：" + sql + ",错误信息:" + e.Message.Trim() + "，错误语句：" + sql + "，错误时间：" + System.DateTime.Now.ToString().Trim() + "\r\n";
                    DatabaseLog.WriteLog(LogCont);
                    if (MessageBox.Show("当前数据库连接失败，您是否尝试重新连接？\r\n    点击“是”继续连接；点击“否”退出系统。", "", MessageBoxButtons.YesNo) == DialogResult.No) Environment.Exit(0);
                    else
                    {
                        if (i >= ConnTimes)
                        {
                            MessageBox.Show("已经超过最大连接次数，点击确定后退出！");
                            Environment.Exit(0);
                        }
                        else Connect();
                    }
                }
                finally
                {
                    if (Cmd != null) Cmd.Dispose();
                }
            } 
             
        }

        #endregion

        #region 从sql文件中提取sql命令
        /// <summary>
        /// 从sql文件中提取sql命令
        /// </summary>
        /// <param name="varFileName">sql文件名</param>
        /// <returns></returns>
        public virtual List<string> GetSqlFile(string varFileName)
        {
            List<string> alSql = new List<string>();
            if (!File.Exists(varFileName))
            {
                return alSql;
            }

            StreamReader rs = new StreamReader(varFileName, System.Text.Encoding.Default);//注意编码

            string varLine = "";
            while (rs.Peek() > -1)
            {
                varLine = rs.ReadLine();
                if (varLine == "")
                    continue;

                alSql.Add(varLine);
            }

            rs.Close();
            return alSql;
        }

        #endregion

        #region 关键字

        public static String GetGlobalKey()
        { 
            return System.Guid.NewGuid().ToString("N");
        }

        public static string GetDataTimekey(int typeNo)
        {
            string dt = DateTime.Now.ToString("yyyyMMddHHmmssms");
            return dt + typeNo.ToString().PadLeft(2, '0');

        }

        public static string GetDataTimekey(int typeNo, int id)
        {
            string dt = DateTime.Now.ToString("yyyyMMddHHmmssms");
            return dt + typeNo.ToString().PadLeft(2, '0') + id.ToString().PadLeft(4, '0');

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
            return dt;
        }


        #endregion
    }
}
