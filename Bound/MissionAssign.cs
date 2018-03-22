using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sau.Util;

namespace PengLang
{ 
    public class MissionAssign
    { 
        protected class ShelfQntIn
        {
            public string ShelfNo;
            public int Quantity;
            public ShelfQntIn() { }
            public ShelfQntIn(string no, int cnt) { ShelfNo = no; Quantity = cnt; }
        }

        protected class ShelfQntOut
        {
            public string ShelfNo ;
            public string LotNo;
            public string SizeNo;
            public int Quantity ;

            public ShelfQntOut() 
            {
                ShelfNo = string.Empty; 
                LotNo = string.Empty;
                SizeNo = string.Empty;
                Quantity = 0;
            }

            public ShelfQntOut(string shelf, string lot, string size, int cnt)
            {
                ShelfNo = shelf;
                LotNo = lot;
                SizeNo = size;
                Quantity = cnt;
            }
        }


        //货架最大装载数量
        private int iQty_Full = MemoryTable.Instance.ShelfCapacity ;
        private List<ShelfQntIn> shelfQntInList = new List<ShelfQntIn>();
        private List<string> emptyShelfList = new List<string>();
       
        #region 入库

        protected void GetEmptyShelfNo()
        {

            /*调整入库的规则为每次入库单的提交都找空货架进行分配，安装排层列的次序摆放，每个货架摆满为止。
             * 首先找到所有空的货架，然后利用userdefine2字段值设置为1，1表示为本次的空货架。0，表示非空货架
             * 确定空货架的方法，V_BlankShelf里的所有货架然后去掉99T99，然后再减到入库在途的货架
            */
            string no = string.Empty;
            emptyShelfList.Clear();
            string sql = string.Format("select shelfNo from V_BlankShelf where shelfNo <> '{0}'  ORDER BY RowNo,ColNo ,LevelNo ", MemoryTable.Shelf_99T99);
            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return;
            int cnt = dt.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                emptyShelfList.Add(dt.Rows[i][0].ToString().Trim());
            }
            dt.Clear();

            //去除入库在途的货架
            sql = "SELECT distinct ShelfNo FROM T_InboundRecord  WHERE  DealStatus <>'complete' ORDER BY ShelfNo desc";
            dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return;
            cnt = dt.Rows.Count;
            for (int i = 0,j =0; i < cnt; i++)
            {
                no = dt.Rows[i][0].ToString().Trim();

                for (j = emptyShelfList.Count - 1; j >= 0; j--)
                {
                    if (emptyShelfList[j] == no)
                    {
                        emptyShelfList[j].Remove(j);
                        break;
                    }
                }
            }

            dt.Clear();
        }


        //获取没有完成的入库操作单中的数量总和,根据ShelfNo 分类，
        protected List<ShelfQntIn> GetInboundAssignQuantity()
        {
            List<ShelfQntIn> list = new List<ShelfQntIn>();
            string sql = "select shelfNo, sum(NumOfPlan) as qnt From T_InboundRecord where DealStatus <>'complete' Group By shelfNo ";

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return list;
            ShelfQntIn sq = null;
            string no, temp;
            int cnt = 0;
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                no = dt.Rows[i][0].ToString();
                temp = dt.Rows[i][1].ToString();
                cnt = 0;
                int.TryParse(temp, out cnt);
                sq = new ShelfQntIn(no, cnt);

                list.Add(sq);
            }
            dt.Clear();
            return list;
        }

        protected int GetInboundAssignQuantity(string shelfNo, List<ShelfQntIn> list)
        {
            shelfNo = shelfNo.ToUpper();
            if (list == null || list.Count == 0) return 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ShelfNo.ToUpper() == shelfNo)
                    return list[i].Quantity;

            }
            return 0;
        }
       
        //根据ShelfNo 这个参数，获取没有完成的入库操作单中的数量总和
        protected int GetInboundAssignQuantity(string shelfNo)
        {
            string sql = String.Format("select sum(NumOfPlan) as qnt From T_InboundRecord where shelfNo = '{0}' and DealStatus <>'complete' ",
                shelfNo);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return 0;

            string res = dt.Rows[0][0].ToString();
            if (string.IsNullOrEmpty(res))
                return 0;

            return Convert.ToInt32(res);
        }
        
        //完成入库，修改库存,
        //该函数不能改成批量执行，因为Insert的结果会影响Update的条件 2017-12-27
        public bool InboundComplete(string strInboundID)
        {
            DataTable dtDetail,dtQuery;
            string sqlDetail,strQuery;
            string strShelfNo, strLotNo, strSizeNo,strQtyPlan;
            string strUpdateOperate;
            sqlDetail = "SELECT DetailID,ShelfNo,LotNo,SizeNo,NumofPlan FROM  T_InboundRecord WHERE InboundID='" + strInboundID + "' ORDER BY DetailID";
            dtDetail = Database.Select(sqlDetail);
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                strShelfNo = dtDetail.Rows[i]["ShelfNo"].ToString().Trim();
                strLotNo = dtDetail.Rows[i]["LotNo"].ToString().Trim();
                strSizeNo = dtDetail.Rows[i]["SizeNo"].ToString().Trim();
                strQtyPlan = dtDetail.Rows[i]["NumOfPlan"].ToString().Trim();

                strQuery = "SELECT ShelfNo FROM T_Inventory "
                           + " WHERE ShelfNo ='" + strShelfNo + "' AND LotNo ='" + strLotNo + "' AND SizeNo = '" + strSizeNo + "'";
                dtQuery = Database.Select(strQuery);

                if (dtQuery==null || dtQuery.Rows.Count == 0)
                    strUpdateOperate = "INSERT INTO T_Inventory (InventoryID,shelfNo,LotNo,SizeNo,Quantity) "
                                    + " VALUES('" + Database.GetGlobalKey() + "','" + strShelfNo + "','" + strLotNo + "','" + strSizeNo + "'," + strQtyPlan + ")";
                else
                    strUpdateOperate = "UPDATE T_Inventory SET Quantity=Quantity + " + strQtyPlan
                                    + " WHERE ShelfNo ='" + strShelfNo + "' AND LotNo ='" + strLotNo + "' AND SizeNo = '" + strSizeNo + "'";


                Database.ExecuteSQL(strUpdateOperate,  "MissionAssign-InboundComplete");

                //20170328增加
                //实际货物入库时，需要从88T88这个虚拟货位中减掉入库数量
                //将来订单确定完成后，利用用户界面清理已经完成的入库单据，也就是清理88T88的所有该单据的虚拟库存
                //当订单完成后88T88中的无库存表示正常，如果库存是正数，表示生产比实际到货多，反之生产比实际到货少
                //这里使用了T_Inventory表中的UserDefine1自定义字段
                strShelfNo = MemoryTable.Shelf_88T88;
                strUpdateOperate = string.Format("delete from T_Inventory where ShelfNo = '{0}' and UserDefine1 = '{1}'", strShelfNo, strInboundID);
                Database.ExecuteSQL(strUpdateOperate, "MissionAssign-InboundComplete-Actual");
                 
            }

            return true; 
        }

        ////20170328增加
        //生产入库单任务分解，直接放入到88T88虚拟货架中，没有中间的执行状态，直接为完成
        //使用了T_Inbound这个表中的UserDefine1字段，用来表示是虚拟入库还是实际入库
        //修改入库表中的UserDefine1字段为VirtualInbound，表示这个单据是虚拟入库
        //这个就不产生入库单了，直接修改虚拟库存。
        //如果出现操作上错误（数据录入错误），那让用户直接修改虚拟库存
        public bool VirtualInboundAssign(string strInboundID)
        {
         
            string sqlDetail;
            DataTable dtDetail;
            string strLotNo, strSizeNo, strQtyPlan;

            string sql="", sqlIns = "INSERT INTO T_Inventory (InventoryID,shelfNo,LotNo,SizeNo,UserDefine1,Quantity) ";
            List<string> sqlList = new List<string>();

            //设置该入库为虚拟入库单据
            sql = string.Format( "Update T_Inbound Set Status = '{0}' WHERE InboundID='{1}'",
                DealStatus.PreInput,
                strInboundID );

            Database.ExecuteSQL(sql);

            //修改88T88虚拟库存
       
            sqlDetail = "SELECT DetailID,LotNo,SizeNo,NumOfPlan FROM  T_InboundDetail WHERE InboundID='" + strInboundID + "'";
            dtDetail = Database.Select(sqlDetail);
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                strLotNo = dtDetail.Rows[i]["LotNo"].ToString().Trim();
                strSizeNo = dtDetail.Rows[i]["SizeNo"].ToString().Trim();
                strQtyPlan = dtDetail.Rows[i]["NumOfPlan"].ToString().Trim();
                
                sql = String.Format("('{0}','{1}','{2}','{3}',{4},{5})",
                  Database.GetGlobalKey(),
                  MemoryTable.Shelf_88T88,
                  strLotNo,
                  strSizeNo,
                  strInboundID,
                  strQtyPlan );
                sqlList.Add(sql);
            }

            if (sqlList.Count > 0)
                Database.BatchInsertSql(sqlIns, sqlList);

            return true;
        }

        ////20170328增加
        //删除分解结束的生产入库单据
        //删除单据，同是删除该单据下的虚拟库存
        public bool DeleteVirtualInbound(string strInboundID)
        {
            bool bResult = true;
            string sqlDelete;

            //删除入库单据
            sqlDelete = "Delete from T_Inbound  WHERE  InboundID='" + strInboundID + "'";
            Database.ExecuteSQL(sqlDelete);

            //删除入库单据明细
            sqlDelete = "Delete from T_InboundDetail  WHERE InboundID='" + strInboundID + "'";
            Database.ExecuteSQL(sqlDelete);

            //删除虚拟库存
            sqlDelete = "Delete from T_Inventory  WHERE UserDefine1='" + strInboundID + "'";
            Database.ExecuteSQL(sqlDelete);

            return bResult;
        }
        
        //入库单任务分解，不能修改库存
        public bool InboundAssign(string strInboundID)
        {
            DataTable dtTotal, dtLotNo;
            string sql, strLotNo;
            bool bResult = true;

            shelfQntInList.Clear();
            shelfQntInList = GetInboundAssignQuantity();

            //20170328增加
            //设置该入库为实际入库单据
            sql = string.Format("Update T_Inbound Set Status ='{0}' WHERE InboundID='{1}' and status = '{2}' ",
                DealStatus.Inbound,
                strInboundID,
                DealStatus.PreInput ); 
            Database.ExecuteSQL(sql);

            /*调整入库的规则为每次入库单的提交都找空货架进行分配，安装排层列的次序摆放，每个货架摆满为止。
             * 首先找到所有空的货架，然后利用userdefine2字段值设置为1，1表示为本次的空货架。0，表示非空货架
             * 确定空货架的方法，V_BlankShelf里的所有货架然后去掉99T99，然后再减到入库在途的货架
            */ 
            GetEmptyShelfNo();

            //首先提取所有的数据
            sql = string.Format( "SELECT DetailID,LotNo,SizeNo,NumOfPlan FROM  T_InboundDetail WHERE InboundID='{0}' Order By LotNo, SizeNo ",strInboundID);
            dtTotal = Database.Select( sql );
            if (dtTotal == null || dtTotal.Rows.Count == 0)
                return false;

            //按照LotNo分组
            DataView dv = dtTotal.DefaultView;
            dtLotNo = dv.ToTable(true, "LotNo");

            //每组按照R升序，L升序和S升序进行排序分配货架
            for (int iLotIndex = 0; iLotIndex < dtLotNo.Rows.Count; iLotIndex++)
            {
                strLotNo = dtLotNo.Rows[iLotIndex]["LotNo"].ToString().Trim();

               bResult &= InboundAssignGroup(dtTotal, strInboundID, strLotNo, "R");
               bResult &= InboundAssignGroup(dtTotal, strInboundID, strLotNo, "L");
               bResult &= InboundAssignGroup(dtTotal, strInboundID, strLotNo, "S");
            }
                
            return bResult;

        }
      
        //每按照R，L和S 升序分组分配
        public bool InboundAssignGroup(DataTable dt,string inboudId,  string lotno , string cond)
        {
            bool bResult =  true ;
            DataRow[] rows = null;
            string detailId = "" , sizeNo, temp;
            int cnt  = 0;

            rows = dt.Select(string.Format("LotNo = '{0}' AND SizeNo Like '%{1}%'", lotno, cond), "SizeNo");

            if (rows == null || rows.Length == 0)
                return true;

            for (int iSizeNoIndex = 0; iSizeNoIndex < rows.Length; iSizeNoIndex++)
            {
                cnt = 0;
                detailId = rows[iSizeNoIndex]["DetailID"].ToString().Trim();
                sizeNo = rows[iSizeNoIndex]["SizeNo"].ToString().Trim();
                temp = rows[iSizeNoIndex]["NumOfPlan"].ToString().Trim();
                int.TryParse( temp, out cnt);
                bResult &= InboundAssignSingle(inboudId, detailId, lotno, sizeNo, cnt );
            }

            return bResult;
        }

        //处理单个入库任务的分解，只生成入库操作单，不能修改库存
        public bool InboundAssignSingle(string strInboundID, string strDetailId, string strLotNo, string strSizeNo, int iQtyPlan)
        {
            int iQtyShelfRemain=0, iQtyShelfLoad=0, iQtyMissionRunning=0,iQtyMissionRemain = iQtyPlan;
            string strShelfNo; 
            string valSql = "",insSql = "INSERT INTO T_InboundRecord (RecordId,InboundID,DetailID,shelfNo,NumofPlan,NumofReal,LotNo,SizeNo,PlanDateTime, DealStatus ) ";
            List<string> insList = new List<string>();
           
            //现在修改成在空货架中进行分配
            if (emptyShelfList == null || emptyShelfList.Count == 0)
                return false;

            for (int i = 0; i < emptyShelfList.Count; i++)
            { 
                strShelfNo = emptyShelfList[i];
                iQtyMissionRunning = GetInboundAssignQuantity(strShelfNo, shelfQntInList); 
                iQtyShelfRemain = iQty_Full - iQtyMissionRunning;

                if (iQtyShelfRemain <= 0)
                    continue;

                iQtyShelfLoad = (iQtyMissionRemain < iQtyShelfRemain) ? iQtyMissionRemain : iQtyShelfRemain;
              

                valSql = string.Format("('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','正在进行')",
                    Database.GetGlobalKey(),
                    strInboundID,
                    strDetailId,
                    strShelfNo,
                    iQtyShelfLoad,
                    iQtyShelfLoad,
                    strLotNo,
                    strSizeNo,
                     DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") );

                insList.Add(valSql);

                iQtyMissionRemain = iQtyMissionRemain - iQtyShelfLoad;
                if (iQtyMissionRemain <= 0)
                    break;
            }

            int nres = 0;
            if (insList.Count > 0)
                nres = Database.BatchInsertSql(insSql, insList);

            if (iQtyMissionRemain <= 0)
                return true;
            else
            { 
                strShelfNo = "未分配货架";
                insSql = string.Format("INSERT INTO T_InboundRecord (RecordId,InboundID,DetailID,shelfNo,NumofPlan,NumofReal,LotNo,SizeNo,PlanDateTime,DealStatus ) "
                                  + "VALUES('{0}','{1}','{2}','{3}',{4},{5},{6},{7},'{8}','正在进行')",
                                    Database.GetGlobalKey(),
                                    strInboundID,
                                    strDetailId,
                                    strShelfNo,
                                    iQtyShelfLoad,
                                    iQtyShelfLoad,
                                    strLotNo,
                                    strSizeNo,
                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Database.ExecuteSQL(insSql, "MissionAssign-InboundAssignSingle");
                return false;
            }
        }
        
        #endregion

        #region 出库

        //20170331
        //虚拟出库
        //预售分解，从77S77虚拟货架中减去对应的出库明细，没有中间的执行状态，直接为完成
        public bool VirtualOutboundAssign(string strOutboundID)
        {
            int nres = 0;
            DataTable dtDetail = null;
            string sql,  sqlVal=""; 
            string sqlInsert = "INSERT INTO T_Inventory ( InventoryID,shelfNo,LotNo,SizeNo,Quantity,UserDefine1,UserDefine2,UserDefine3 )";
            List<string> insertList = new List<string>();

            //首先删除以前的预出库信息
            sql = string.Format("delete from T_Inventory where ShelfNo = '{0}' and UserDefine1 = '{1}' ", MemoryTable.Shelf_77S77, strOutboundID);
            Database.ExecuteSQL(sql, "MissionAssign-VirtualOutboundAssign");

            sql = string.Format("SELECT DetailID,LotNo,SizeNo, NumOfPlan, Funds, WoPrice FROM  T_OutboundDetail WHERE OutboundID='{0}' ORDER BY DetailID",
                strOutboundID);
            dtDetail = Database.Select(sql);
            if (dtDetail == null || dtDetail.Rows.Count == 0)
                return false;

            //从77S77中减去数量
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                
                sqlVal = string.Format("( '{0}', '{1}', '{2}', '{3}', '-{4}', '{5}', '{6}','{7}' ) ",
                             Database.GetGlobalKey(),
                             MemoryTable.Shelf_77S77,
                             dtDetail.Rows[i]["LotNo"],
                             dtDetail.Rows[i]["SizeNo"],
                             dtDetail.Rows[i]["NumOfPlan"],
                             strOutboundID,
                             dtDetail.Rows[i]["Funds"],
                             dtDetail.Rows[i]["WoPrice"]);
                insertList.Add(sqlVal);
            }

            if (insertList.Count > 0)
               nres = Database.BatchInsertSql(sqlInsert, insertList);
            return nres > 0 ;
        }

        public bool DeleteVirtualOutbound(string strOutboundID)
        {
            string sqlDelete;
            List<string> list = new List<string>();
            //删除出库单据
            sqlDelete = string.Format("Delete from T_Outbound  WHERE  OutboundID='{0}'",strOutboundID);
            list.Add(sqlDelete);

            //删除出库单据明细
            sqlDelete = string.Format("Delete from T_OutboundDetail  WHERE  OutboundID='{0}'", strOutboundID);
            list.Add(sqlDelete);

            //删除虚拟库存
            sqlDelete = string.Format("Delete from T_Inventory  WHERE UserDefine1='{0}'", strOutboundID);
            list.Add(sqlDelete);

            int nres = Database.BatchExecuteSQL(list);

            return nres >0 ;

        }
        
        //完成出库,修改库存数量
        public bool OutboundComplete(string strOutboundID )
        {
            int nres = 0;
            List<string> list = new List<string>();
            string sql = string.Format("SELECT DetailID,ShelfNo,LotNo,SizeNo,NumofPlan FROM  T_OutboundRecord WHERE OutboundID='{0}' ORDER BY DetailID",
                strOutboundID);

            DataTable dtDetail = Database.Select(sql);
            if (dtDetail == null || dtDetail.Rows.Count == 0)
                return true;

            for (int i = 0; i < dtDetail.Rows.Count; i++)
            { 
                sql = string.Format("UPDATE T_Inventory SET Quantity=Quantity - {0}  WHERE ShelfNo ='{1}' AND LotNo ='{2}' AND SizeNo = '{3}'",
                                dtDetail.Rows[i]["NumofPlan"],
                                dtDetail.Rows[i]["ShelfNo"],
                                dtDetail.Rows[i]["LotNo"],
                                dtDetail.Rows[i]["SizeNo"] );
                list.Add(sql);
               
            }

            if (list.Count > 0)
               nres = Database.BatchExecuteSQL(list);

            //20170331增加
            //实际货物出库库时，将77S77中的虚拟出库删除
            //这里使用了T_Inventory表中的UserDefine1自定义字段 
            sql = string.Format("delete from T_Inventory where ShelfNo = '{0}' and UserDefine1 = '{1}'", MemoryTable.Shelf_77S77, strOutboundID);
            Database.ExecuteSQL(sql, "MissionAssign-OutboundComplete-Actual");

            return nres > 0 ;
        }

        //真实出库分配货架
        public bool OutboundAssign(string strOutboundID )
        {
            List<string> insList = new List<string>();
            string insSql = "INSERT INTO T_OutboundRecord (RecordId,OutboundID,DetailID,shelfNo,NumofPlan,NumofReal,LotNo,SizeNo,PlanDateTime, DealStatus) ";

            string sql = string.Format( "Update T_Outbound Set Status ='{0}' WHERE OutboundID='{1}' and Status = '{2}' ",
                DealStatus.Outbound, strOutboundID, DealStatus.PreSell ); 
            Database.ExecuteSQL(sql);

            sql = "SELECT DetailID,LotNo,SizeNo,NumOfPlan FROM  T_OutboundDetail WHERE OutboundID='" + strOutboundID + "' ORDER BY DetailID";
            DataTable dtDetail = Database.Select(sql);

            for (int i = 0; i < dtDetail.Rows.Count; i++)
            { 
                OutboundAssignSingle( strOutboundID, 
                                      dtDetail.Rows[i]["DetailID"].ToString().Trim(), 
                                      dtDetail.Rows[i]["LotNo"].ToString().Trim(), 
                                      dtDetail.Rows[i]["SizeNo"].ToString().Trim(), 
                                      dtDetail.Rows[i]["NumOfPlan"].ToString().Trim(),
                                      insList );
                
            }

            int nres = 0;
            if (insList.Count > 0)
               nres = Database.BatchInsertSql(insSql, insList);
            return nres > 0 ;

        }

        public bool OutboundAssignSingle(string strOutboundID, string strDetailId, string strLotNo, string strSizeNo, string strQtyPlan, List<string> list )
        { 
            string val="";
            int iQtyShelfRemain=0 , iQtyShelfUnload =0, iQtyMissionRemain =0;
                                 
            int.TryParse(strQtyPlan, out iQtyMissionRemain);

            //获取货架的库存
            List<ShelfQntOut> shefQntOutList = new List<ShelfQntOut>();
            shefQntOutList = GetShelfQuantity(strLotNo, strSizeNo, strOutboundID);
             
            if (shefQntOutList == null || shefQntOutList.Count == 0)
                return false;

            //"INSERT INTO T_OutboundRecord (RecordId,OutboundID,DetailID,shelfNo,NumofPlan,NumofReal,LotNo,SizeNo,PlanDateTime) ";

            for (int i = 0; i < shefQntOutList.Count; i++)
            {
                iQtyShelfRemain = shefQntOutList[i].Quantity;
                iQtyShelfUnload = (iQtyMissionRemain < iQtyShelfRemain) ? iQtyMissionRemain : iQtyShelfRemain;

                val = string.Format("('{0}', '{1}','{2}','{3}','{4}', '{5}','{6}','{7}','{8}','正在进行')",
                    Database.GetGlobalKey(),
                    strOutboundID,
                    strDetailId,
                    shefQntOutList[i].ShelfNo,
                    iQtyShelfUnload,
                    iQtyShelfUnload,
                    strLotNo,
                    strSizeNo,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") );
                 
                list.Add(val);

                iQtyMissionRemain = iQtyMissionRemain - iQtyShelfUnload;
                if (iQtyMissionRemain <= 0 )
                    break; 
            }

            if (iQtyMissionRemain > 0)
            {
                val = string.Format("('{0}', '{1}','{2}','{3}','{4}', '{5}','{6}','{7}','{8}','正在进行')",
                         Database.GetGlobalKey(),
                         strOutboundID,
                         strDetailId,
                         "未分配货架",
                         iQtyShelfUnload,
                         iQtyShelfUnload,
                         strLotNo,
                         strSizeNo,
                         DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                list.Add(val);
                return false;
            }

            return true;
        }

        protected List<ShelfQntOut> GetShelfQuantity(string lotNo, string sizeNo, string exceptOutboundId )
        {
            List<ShelfQntOut> list = new List<ShelfQntOut>();

            string  sql = string.Format(" SELECT A.ShelfNo,A.Quantity FROM T_Inventory A LEFT JOIN T_Shelf B ON A.ShelfNo = B.ShelfNo "
                                 + " WHERE  A.Quantity >0  AND A.ShelfNo <> '{0}' AND A.ShelfNo <> '{1}' AND  A.LotNo ='{2}' AND A.SizeNo = '{3}' "
                                 + " ORDER BY B.RowNo,B.ColNo ,B.LevelNo",
                                 MemoryTable.Shelf_99T99,
                                 MemoryTable.Shelf_88T88,
                                 lotNo,
                                 sizeNo);
          
            DataTable dt = Database.Select(sql);
            if( dt == null || dt.Rows.Count == 0)
                return list;

            int qnt  = 0;
            string shelfNo, temp = "";
            ShelfQntOut obj = null;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                obj = new ShelfQntOut();
                qnt = 0;
                shelfNo = dt.Rows[i][0].ToString();
               
                temp = dt.Rows[i][1].ToString();
                int.TryParse(temp, out qnt);
                 
                obj.ShelfNo = shelfNo;
                obj.LotNo = lotNo;
                obj.SizeNo = sizeNo;
                obj.Quantity = qnt;

                list.Add(obj);
            }
            dt.Clear();
            /*
            sql = string.Format( "select shelfNo, sum(NumOfPlan) as qnt From T_OutboundRecord where OutboundId <> '{0}'"
                      + " and (DealStatus <>'complete' and DealStatus <>'complete') and LotNo = '{1}' and SizeNo = '{2}' "
                      + " Group By shelfNo  ", exceptOutboundId ,lotNo, sizeNo );

            dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return list;

            for (int i = 0,j=0; i < dt.Rows.Count; i++)
            {
                qnt = 0;
                shelfNo = dt.Rows[i][0].ToString(); 
                temp = dt.Rows[i][1].ToString();
                int.TryParse(temp, out qnt);

                for (j = 0; j < list.Count; j++)
                {
                    if (list[j].ShelfNo == shelfNo)
                    {
                        list[j].Quantity -= qnt;
                        break;
                    }
                }
            }

            dt.Clear();
             
           */ 
          
            return list;
        }
    
        #endregion

        #region 倒库

        //倒库单任务分解
        public bool TranboundAssign(string strTranboundID)
        { 
            string sql = "SELECT DetailID,ShelfNoFrom,ShelfNoTo,LotNo,SizeNo,NumOfPlan FROM  T_TranboundDetail WHERE TranboundID='" + strTranboundID + "' ORDER BY DetailID";
            DataTable dt = Database.Select(sql);

            string detailId, shelfNoFrom, shelfNoTo, lotNo, sizeNo;
            int num = 0;

            for (int i = 0, col=0; i < dt.Rows.Count; i++)
            {
                col = 0;
                detailId = dt.Rows[i][col++].ToString();
                shelfNoFrom = dt.Rows[i][col++].ToString();
                shelfNoTo = dt.Rows[i][col++].ToString();
                lotNo = dt.Rows[i][col++].ToString();
                sizeNo = dt.Rows[i][col++].ToString(); 
                num = Convert.ToInt32(dt.Rows[i][col++]);
 
                TranboundAssignSingle(shelfNoFrom, shelfNoTo, lotNo, sizeNo, num);

            }

            return true;
        }
 
        public bool TranboundAssignSingle(string shelfNoFrom, string shelfNoTo, string lotNo, string sizeNo, int iQtyPlan)
        {
            string sql = String.Format(" Update T_Inventory Set quantity = quantity - {0} where shelfNo = '{1}' and lotNo = '{2}' and sizeNo = '{3}'",
                iQtyPlan,
                shelfNoFrom,
                lotNo,
                sizeNo);

            int nres1 = 0, nres2=0;

            nres1 = Database.ExecuteSQL(sql, "MissionAssign-TranboundAssignSingle");
            string id = FindInventory(shelfNoTo, lotNo, sizeNo);

            if (String.IsNullOrEmpty(id) == false) 
            {  
                sql = String.Format("Update T_Inventory Set quantity = quantity + {0} where shelfNo = '{1}' and lotNo = '{2}' and sizeNo = '{3}'",
                iQtyPlan,
                shelfNoTo,
                lotNo,
                sizeNo);
                nres2 = Database.ExecuteSQL(sql, "MissionAssign-TranboundAssignSingle");
            }
            else
            {  //目标货架号没有存入该服装
                if (InsertInventory(shelfNoTo, lotNo, sizeNo, iQtyPlan) == true)
                    nres2 = 1;
                else
                    nres2 = 0;
            }
             
            if (nres1 == 1 && nres2 == 1)
                return true;
            return false;
        }
      
        private string FindInventory(string shelfNo, string lotNo, string sizeNo)
        {
            string sql = String.Format("Select InventoryID From T_Inventory where shelfNo = '{0}' and LotNo = '{1}' and sizeNo = '{2}'",
                shelfNo,
                lotNo,
                sizeNo);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return String.Empty;

            string id = dt.Rows[0][0].ToString();
            dt.Clear();
            return id;
        }

        private bool InsertInventory(string shelfNo, string lotNo, string sizeNo, int quantity)
        {
            string id = Database.GetGlobalKey();

            string sql = String.Format("Insert into T_Inventory (InventoryID, ShelfNo, LotNo, SizeNo, Quantity ) "
                + "Values('{0}', '{1}', '{2}', '{3}', {4})",
                id,
                shelfNo,
                lotNo,
                sizeNo,
                quantity);

            int nres = Database.ExecuteSQL(sql, "MissionAssign-InsertInventory");
            return nres == 1 ? true : false;
        }

        #endregion

        #region 退货

        //分解退货单
        public bool BackboundAssign(string strBoundID)
        {
            DataTable dtDetail;
            string sqlDetail;
            string strDetailId;
            bool bResult = true;
            bool bSingleResult;
            sqlDetail = "SELECT DetailID,LotNo,SizeNo,Quantity FROM  T_BackboundDetail WHERE BackboundID='" + strBoundID + "' ORDER BY DetailID";
            dtDetail = Database.Select(sqlDetail);
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                strDetailId = dtDetail.Rows[i]["DetailID"].ToString().Trim();
                bSingleResult = BackboundAssignSingle(strBoundID, strDetailId
                                                    , dtDetail.Rows[i]["LotNo"].ToString().Trim()
                                                    , dtDetail.Rows[i]["SizeNo"].ToString().Trim()
                                                    , int.Parse(dtDetail.Rows[i]["Quantity"].ToString().Trim()));
                if (bSingleResult == false)
                    bResult = false;
            }
            return bResult;
        }

        //处理单个退货任务的分解，只生成入库操作单，不能修改库存
        public bool BackboundAssignSingle(string strBoundID, string strDetailId, string strLotNo, string strSizeNo, int iQtyPlan)
        {
            string sql = string.Format("select shelfNo, Quantity from T_Inventory where lotNo = '{0}' and sizeNo = '{1}' and shelfNo <> '{2}' order by Quantity desc ",
                strLotNo,
                strSizeNo,
                MemoryTable.Shelf_99T99 );
            DataTable dtShelfNo = Database.Select(sql);
            string shelfNo = string.Empty;
           
            if (dtShelfNo == null || dtShelfNo.Rows.Count == 0)
            {
                shelfNo = GetBlankShelfNo();
            }
            else
            {
                shelfNo = dtShelfNo.Rows[0][0].ToString();
            }
            dtShelfNo.Clear();

            string strRecordId = Database.GetGlobalKey();
            sql = "INSERT INTO T_BackboundRecord (RecordId, BackboundID, DetailID, shelfNo, Quantity, LotNo, SizeNo, DealDateTime) "
                                + " VALUES('" + strRecordId + "','" + strBoundID + "','" + strDetailId + "','" + shelfNo + "'," + iQtyPlan.ToString()
                                + ",'" + strLotNo + "','" + strSizeNo + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            int nres = Database.ExecuteSQL(sql, "MissionAssign-BackboundAssignSingle");

            return nres > 0 ? true : false;
        }
         
        private string GetBlankShelfNo()
        {
            string sql = string.Format("select shelfNo from V_BlankShelf where shelfNo <> '{0}'order by shelfNo ", 
               MemoryTable.Shelf_99T99);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return string.Empty;
            return dt.Rows[0][0].ToString();
        }
        
        //完成退货
        public bool BackboundComplete(string strBoundID)
        {
            DataTable dtDetail, dtQuery;
            string sqlDetail, strQuery;
            string strShelfNo, strLotNo, strSizeNo, strQtyPlan;
            string strUpdateOperate;
            sqlDetail = "SELECT DetailID,ShelfNo,LotNo,SizeNo,Quantity FROM  T_BackboundRecord WHERE BackboundID='" + strBoundID + "' ORDER BY DetailID";
            dtDetail = Database.Select(sqlDetail);
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                strShelfNo = dtDetail.Rows[i]["ShelfNo"].ToString().Trim();
                strLotNo = dtDetail.Rows[i]["LotNo"].ToString().Trim();
                strSizeNo = dtDetail.Rows[i]["SizeNo"].ToString().Trim();
                strQtyPlan = dtDetail.Rows[i]["Quantity"].ToString().Trim();

                strQuery = "SELECT ShelfNo FROM T_Inventory "
                           + " WHERE ShelfNo ='" + strShelfNo + "' AND LotNo ='" + strLotNo + "' AND SizeNo = '" + strSizeNo + "'";
                dtQuery = Database.Select(strQuery);

                if (dtQuery == null || dtQuery.Rows.Count == 0)
                    strUpdateOperate = "INSERT INTO T_Inventory (InventoryID,shelfNo,LotNo,SizeNo,Quantity) "
                                    + " VALUES('" + Database.GetGlobalKey() + "','" + strShelfNo + "','" + strLotNo + "','" + strSizeNo + "'," + strQtyPlan + ")";
                else
                    strUpdateOperate = "UPDATE T_Inventory SET Quantity=Quantity + " + strQtyPlan
                                    + " WHERE ShelfNo ='" + strShelfNo + "' AND LotNo ='" + strLotNo + "' AND SizeNo = '" + strSizeNo + "'";


                Database.ExecuteSQL(strUpdateOperate, "MissionAssign-BackboundComplete");

            }
            return true; 
        }

        #endregion
    }

}
