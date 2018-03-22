using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sau.Util;

namespace PengLang
{
    public class TestDebug
    { 
        public static void UpdateTest()
        {
            List<string> sqlList = new List<string>();
            string ins = "INSERT into T_Test (testId, testName, testCode )";
 
            sqlList.Add("(9,'444','444')");
            sqlList.Add("(10,'555','555')");
            sqlList.Add("(6,'666','666')");
            sqlList.Add("(11,'777','777')");
            sqlList.Add("(12,'888','888')");
            int res = 0;
            if (sqlList.Count > 0)
                res = Database.BatchInsertSql(ins, sqlList);

        }

        public static void Debug()
        {
            string temp = "";
            string sql;
            DataTable dtTotal;
            sql = string.Format("SELECT DetailID,LotNo,SizeNo,NumOfPlan FROM  T_InboundDetail WHERE InboundID='{0}' Order By LotNo, SizeNo ", "20170922095349534901");
            dtTotal = Database.Select(sql);
            if (dtTotal == null || dtTotal.Rows.Count == 0)
                return ;
            for (int i = 0; i < dtTotal.Rows.Count; i++)
            {
                temp = dtTotal.Rows[i][0].ToString();
            }
            //按照LotNo分组，每组按照R升序，L升序和S升序进行排序分配货架

            DataView dv = dtTotal.DefaultView;

            DataTable dtLot = dv.ToTable(true, "LotNo");
       

            for (int i = 0; i < dtLot.Rows.Count; i++)
            {
                temp = dtLot.Rows[i][0].ToString();
            }
        }
    }
}
