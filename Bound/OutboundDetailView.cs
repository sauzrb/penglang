using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Sau.Util;

namespace PengLang
{
    public class OutboundDetailView : BoundDetailView
    {
        public bool bCommission = true; 
        public string OutboundID = String.Empty;//出库单编号
        public int OutboundKind = MemoryTable.Outbound_Kind_Gel;
        public string CustomerNo = string.Empty;

        #region 视图初始化

         private RowCellStyleEventHandler handlerRowCellStyle = null;

         public OutboundDetailView()
         { 
            this.LoadData = LoadOutboundDetail;
         }

         public OutboundDetailView(BandedGridView view)
         {
            base.SetGridView(view);
            this.LoadData = LoadOutboundDetail;
         }

         public void SetGridEditStatus(bool bEdit)
         {
             gridView.BeginInit();

             gridView.OptionsBehavior.Editable = bEdit;   //是否允许用户编辑单元格

             gridView.OptionsNavigation.AutoFocusNewRow = bEdit;
             gridView.OptionsSelection.InvertSelection = bEdit;

             if (bEdit == true)
             {
                 gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                 gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                 gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
                 gridView.OptionsBehavior.ReadOnly = false;
                 this.gridView.RowCellStyle += handlerRowCellStyle;
             }
             else
             {
                 gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                 gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                 gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                 gridView.OptionsBehavior.ReadOnly = true;
                 this.gridView.RowCellStyle -= handlerRowCellStyle;
             }

             gridView.EndInit();
         }

         protected override void InitGridView()
         {
             base.InitGridView(); 

             gridView.OptionsBehavior.Editable = false;   //是否允许用户编辑单元格
             gridView.OptionsCustomization.AllowColumnMoving = false;
             gridView.IndicatorWidth = 30;
             gridView.OptionsSelection.MultiSelect = true;
             gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
             gridView.OptionsMenu.EnableColumnMenu = false;
             gridView.OptionsMenu.EnableFooterMenu = false;

             this.gridView.CellValueChanged += new CellValueChangedEventHandler(OnCellValueChanged);
             this.gridView.ValidateRow += new ValidateRowEventHandler(OnValidateRow);
             this.gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(OnValidatingEditor);
             handlerRowCellStyle =  new RowCellStyleEventHandler(OnRowCellStyle); ;
            
             for(int i=0;i<arValid.Length;i++)
                 arValid[i] = true;
         }

         protected override void CreateGridBand()
         {
             base.CreateGridBand();

             base.bandShelfNo.Visible = false; 
         }

         protected override void CreateGridColumns()
         {
             base.CreateGridColumns();

             base.colShelfNo.Visible = false;
             CreateLotNoCombo();

             colColor.OptionsColumn.AllowEdit = false; 
             colStyleNo.OptionsColumn.AllowEdit = false;

             for (int i = gridView.Columns.Count - 1; i >= BeginSizeNoIndex; i--)
             {
                 gridView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                 gridView.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Integer;
             }
         }

         #region Grid Repository

         private RepositoryItemComboBox comboLotNo;

         protected void CreateLotNoCombo()
         {
             comboLotNo = new RepositoryItemComboBox();
             comboLotNo.Name = "comboLotNo";
             comboLotNo.AutoHeight = true;

             List<Clothes> list = MemoryTable.Instance.ListClothes;
             for (int i = 0; i < list.Count; i++)
                 comboLotNo.Items.Add(list[i].LotNo);

             colLotNo.ColumnEdit = comboLotNo;
         }

         #endregion

        #endregion

        #region 加载数据

        private DataTable LoadDetail(string outboundID)
         {
             DataTable dt = null;

             string sql = String.Format("Select DetailID as RowID, LotNo, SizeNo, NumOfPlan  From T_OutboundDetail where OutboundID = '{0}' and NumOfPlan > 0  ", outboundID);

             sql += " order by DetailID, LotNo, SizeNo ";

             dt = Database.Select(sql);

             return dt;
         }

        private void LoadOutboundDetail()
         {

             List<InventoryItem> list = InventoryList;
             list.Clear();
             DataTable dt = LoadDetail(OutboundID);

             if (dt == null || dt.Rows.Count == 0)
                 return;

             //将DataTable转换为ListItem
             string lotNo = "", sizeNo = "", curID = "", lastID = "";
             int quantity = 0, sum =0;

             InventoryItem item = null;
             DataRow dr = null;

             for (int i = 0, cnt = dt.Rows.Count; i < cnt; i++)
             {
                 dr = dt.Rows[i];
                 curID = dr["RowID"].ToString();
                 lotNo = dr["LotNo"].ToString();
                 sizeNo = dr["SizeNo"].ToString();

                 if (curID != lastID)
                 {
                     item = new InventoryItem();
                     sum = 0;
                     item.ID = curID;
                     item.LotNo = lotNo;
                     GetClothesData(item, lotNo);

                     list.Add(item);

                     lastID = curID;

                 }

                 quantity = Convert.ToInt32(dr["NumOfPlan"]);
                 sum += quantity;
                
                 item.Set(sizeNo, quantity);
                 item.SubTotal = sum;
             }

             for (int i = list.Count - 1; i >= 0; i--)
                 list[i].GetTotal();

             dt.Clear();

         }

        private void GetClothesData(InventoryItem item, string lotNo)
         {
             int cnt = listClothes.Count;
             for (int i = 0; i < cnt; i++)
             {
                 if (listClothes[i].LotNo != lotNo)
                     continue;

                 item.StyleNo = listClothes[i].StyleNo;
                 item.Shell = listClothes[i].Shell;
                 item.Model = listClothes[i].Model;
                 item.Color = listClothes[i].Color;

                 return;
             }
         }

        #endregion

        #region 明细编辑

        public void ClearRows()
         {
             if (dataTable != null)
                 dataTable.Rows.Clear();
         }

        public void OnCellValueChanged(object sender, CellValueChangedEventArgs e)
         {
             if (e.Column == colLotNo)
             {
                 string lotno = e.Value.ToString();
                 AutoCompleteClothes(lotno);
             }
             else if (e.Column.AbsoluteIndex >= BeginSizeNoIndex && e.Column.AbsoluteIndex <= EndSizeNoIndex)
             {
                 int sum = GetSubTotal(e.RowHandle);
                 gridView.SetFocusedRowCellValue(colSubTotal, sum);
             }
         }

        public void OnValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
         {
             ColumnTag tag = gridView.FocusedColumn.Tag as ColumnTag;
             if (tag == null || tag.DataType != ColumnTag.DataType_Integer)
                 return;
             int rowHandle = gridView.FocusedRowHandle;
             try
             {
                 int num = Convert.ToInt32(e.Value);
             }
             catch
             {
                 e.ErrorText = "只能输入一个整数";
                 e.Valid = false;
             }
         }

        public void OnValidateRow(object sender, ValidateRowEventArgs e)
         {
             string lotno = gridView.GetRowCellValue(e.RowHandle, colLotNo).ToString();
             if (String.IsNullOrEmpty(lotno))
             {
                 e.ErrorText = "Art# Column can not be empty. ";
                 e.Valid = false;
                 return;
             }
             if (FindLotNo(lotno) == false)
             {
                 e.ErrorText = "Art# does not exist. ";
                 e.Valid = false;
                 return;
             }

             if (IsLotNoExist(lotno, e.RowHandle) == true)
             {
                 e.ErrorText = "Art# already exists. ";
                 e.Valid = false;
                 return;
             }

             if (ValidRowQuantity(e.RowHandle) == false)
             {
                 e.ErrorText = "出库数量大于库存量. ";
                 e.Valid = false;
                 return;
             }
         }

        private Clothes GetClothes(string lotNo)
         {
             List<Clothes> list = MemoryTable.Instance.ListClothes;

             for (int i = 0; i < list.Count; i++)
             {
                 if (list[i].LotNo == lotNo)
                     return list[i];
             }

             return null;
         }

        private void AutoCompleteClothes(string lotno)
         {
             Clothes clothes = GetClothes(lotno);
             if (clothes == null)
                 return; 
             gridView.SetFocusedRowCellValue(colStyleNo, clothes.StyleNo);
             gridView.SetFocusedRowCellValue(colColor, clothes.Color); 
         }

        private bool FindLotNo(string lotno)
        {
            List<Clothes> list = MemoryTable.Instance.ListClothes;

            for (int i = 0; i < list.Count; i++)
                if (lotno == list[i].LotNo)
                    return true;

            return false;
        }

        private bool IsLotNoExist(string lotno, int exceptRowHandle)
         {
             for (int i = gridView.RowCount - 1; i >= 0; i--)
             {
                 object obj = gridView.GetRowCellValue(i, colLotNo);
                 if (obj == null)
                     continue;
                 if (obj.ToString() == lotno && i != exceptRowHandle)
                     return true;
             }
             return false;
         }

        public void RemoveRows(int[] rowHandles)
         {
             if (rowHandles == null)
                 return; 
             Object objDetail = null;
             for (int i = rowHandles.Length - 1; i >= 0; i--)
             {
                 objDetail = gridView.GetRowCellValue(rowHandles[i], colRowID);
                 if (objDetail != null)
                 { 
                     RemoveOutboundDetail(objDetail.ToString());
                 }
                 gridView.DeleteRow(rowHandles[i]);
             }
         }

        public bool RemoveOutboundDetail(string detialID)
         {
             string sql = String.Format("delete from T_OutboundDetail where detailID = '{0}'", detialID);
             return Database.ExecuteSQL(sql, "OutboundDetailView-RemoveOutboundDetail") == 0 ? false : true;
         }

        #endregion
                 
        #region 保存明细
        
        private int DetailIndex = 0;
        private List<ItemTag> listSalePrice;


        //2017-12-26
        //批量保存出库明细

        public void SaveOutboundDetail()
        {
            if (listSalePrice != null)
                listSalePrice.Clear();
            listSalePrice = GetSalePriceList(CustomerNo);

            MemoryTable.Instance.LoadClothes();
            listClothes = MemoryTable.Instance.ListClothes;

            string sql = string.Format("delete from T_OutboundDetail where OutboundID = '{0}'", OutboundID);
            Database.ExecuteSQL(sql, "OutboundDetailView-UpdateOutboundDetail");

            string sqlIns = " Insert into T_OutboundDetail (DetailID, OutboundID, LotNo, SizeNo, NumOfPlan, NumOfReal ,funds , WOPrice,Status ) ";
            List<string> sqlList = new List<string>();
            DetailIndex = 0;
            int cnt = dataTable.Rows.Count;

            for (int i = 0; i < cnt; i++)
            {
                GetRowValuesSql(i, sqlList);
            }
            if (sqlList.Count > 0)
                Database.BatchInsertSql(sqlIns, sqlList);
        }

        private void GetRowValuesSql(int idx, List<string> list)
        {
            DataRow dr = dataTable.Rows[idx];
            string lotno = dr["LotNo"].ToString();
            int cnt = dataTable.Columns.Count - 1;

            string sizeNo = "", sql = "", price = "0", woprice = "";
            int quantity = 0;

            string detailID = Database.GetDataTimekey(2, DetailIndex++);
            gridView.SetRowCellValue(idx, colRowID, detailID);
            for (int i = BeginSizeNoIndex; i < cnt; i++)
            {
                sizeNo = dataTable.Columns[i].ColumnName;
                if (dr[i] == null || String.IsNullOrEmpty(dr[i].ToString()))
                    continue;
                quantity = Convert.ToInt32(dr[i]);
                if (quantity <= 0)
                    continue;
                price = GetSalePrice(lotno);
                woprice = GetClothesPrice(lotno);

                sql = String.Format("('{0}','{1}','{2}','{3}',{4},{5},{6},{7},'{8}')",
                detailID,
                OutboundID,
                lotno,
                sizeNo,
                quantity,
                quantity,
                price,
                woprice,
                DealStatus.None);

                list.Add(sql);
            }
        }
        
        private string GetClothesPrice(string lotNo)
        {
            if (bCommission == false)
                return "0";

            if(this.listClothes == null )
            {
                MemoryTable.Instance.LoadClothes();
                listClothes = MemoryTable.Instance.ListClothes;
            }
            for (int i = 0; i < this.listClothes.Count; i++)
            {
                if (listClothes[i].LotNo == lotNo)
                    return listClothes[i].Price;
            }

            return "0";
        }

        private List<ItemTag> GetSalePriceList(string customerNo)
        {
            List<ItemTag> list = new List<ItemTag>();

            string sql = string.Format(" Select distinct LotNo, Funds ,CreateTime From V_OutboundDetail Where CustomerNo = '{0}' Order By LotNo asc , CreateTime desc  ", customerNo);
            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return list;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (GetSalePrice(dt.Rows[i][0].ToString()) == "0.0")
                {
                    list.Add(new ItemTag(
                        dt.Rows[i][0].ToString(),
                        dt.Rows[i][1].ToString()));
                }
            }

            return list;
        }

        private string GetSalePrice(string LotNo)
        {
            if (listSalePrice == null || listSalePrice.Count == 0)
                return "0.0";

            for (int i = 0; i < listSalePrice.Count; i++)
            {
                if (listSalePrice[i].Key == LotNo)
                    return listSalePrice[i].Caption;
            }
            return "0.0";
        }
 
        #endregion

        #region 库存量检查

        private bool[] arValid = new bool[40];
 
        private bool ValidRowQuantity(int rowHandle)
        {
            for(int i= arValid.Length -1;i>=0;i--)
                arValid[i] = true;

            Object obj = gridView.GetRowCellValue(rowHandle, colLotNo);
            if(obj == null)
                return true ;
            bool bres = true;
            string lotNo = obj.ToString(); 
            string sizeNo = "";
            int quantity = 0;
            int inventory = 0;

            for (int i = BeginSizeNoIndex; i <= EndSizeNoIndex; i++)
            {
                sizeNo = gridView.Columns[i].FieldName;
                obj = gridView.GetRowCellValue(rowHandle, sizeNo);
                if (obj == null || String.IsNullOrEmpty(obj.ToString()))
                    continue;

                quantity = Convert.ToInt32(obj);
                if (quantity <= 0)
                    continue;

                inventory = GetSizeInventory(lotNo, sizeNo, OutboundKind);
                if (inventory >= quantity)
                    continue;
                bres = false;
                arValid[i] = false; 
                //重新刷新
                gridView.RefreshRowCell(rowHandle, gridView.Columns[i]);
                
            }

            //gridView.RefreshRow(rowHandle);
            return bres;
        }
         
        // 1 ：普通货架
        // 2 : 99T99货架 
        private int GetSizeInventory(string lotNo, string sizeNo, int flag = 1)
        {
            int sum = 0;

            //默认是普通货架出库
            string sql = string.Format("select sum( Quantity )as cnt  from T_Inventory  where lotNo = '{0}' and sizeNo = '{1}' "
            + "and shelfNo <> '{2}' and ( UserDefine1 <> '{3}' or UserDefine1 is null)",
                    lotNo,
                    sizeNo,
                    MemoryTable.Shelf_99T99,
                    OutboundID );

            //99T99货架出库
            if (flag == MemoryTable.Outbound_Kind_99T)
            {
                sql = string.Format("select sum( Quantity )as cnt  from T_Inventory  where lotNo = '{0}' and sizeNo = '{1}' and shelfNo = '{2}'",
                   lotNo,
                   sizeNo,
                   MemoryTable.Shelf_99T99);
            }

            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return sum;
            
            string temp = dt.Rows[0][0].ToString();
            if (String.IsNullOrEmpty(temp))
                return 0;
            return Convert.ToInt32(temp);
        }

        public void OnRowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //if (gridView.OptionsBehavior.ReadOnly == true)
            //    return;

            if (e.Column.AbsoluteIndex > EndSizeNoIndex )
                return;
            if (e.Column.AbsoluteIndex < BeginSizeNoIndex)
                return;
            if (e.CellValue == null)
                return;

            if ( String.IsNullOrEmpty(e.CellValue.ToString()) )
                return;
              
            if ( arValid[e.Column.AbsoluteIndex] == false )
                e.Appearance.ForeColor = Color.Red;
            else
                e.Appearance.ForeColor = Color.Black;
        }

        private int GetActualInventory(string lotNo, string sizeNo, int flag = 1 )
        {
            int sum = 0;

            string sql = string.Format("select sum( Quantity )as cnt  from T_Inventory  where lotNo = '{0}' and sizeNo = '{1}' and shelfNo <> '{2}' "
                + " and shelfNo <> '{3}' and shelfNo <> '{4}'",
                   lotNo,
                   sizeNo,
                   MemoryTable.Shelf_99T99,
                   MemoryTable.Shelf_88T88,
                   MemoryTable.Shelf_77S77 );

            //99T99货架出库
            if (flag == MemoryTable.Outbound_Kind_99T)
            {
                sql = string.Format("select sum( Quantity )as cnt  from T_Inventory  where lotNo = '{0}' and sizeNo = '{1}' and shelfNo = '{2}'",
                   lotNo,
                   sizeNo,
                   MemoryTable.Shelf_99T99);
            }

            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return sum;

            string temp = dt.Rows[0][0].ToString();
            if (String.IsNullOrEmpty(temp))
                return 0;
            return Convert.ToInt32(temp);
             
        }

        public string ErrorMsg = string.Empty;

        public bool CanActualOutbound()
        {
            int cnt = dataTable.Rows.Count;
            bool bres = true;
            for (int i = 0; i < cnt; i++)
            {
                 bres = CanActualOutboundRow(i);
                 if (bres == false)
                     return false;
            }

            return true;
        }

        private bool CanActualOutboundRow(int idx)
        {
            DataRow dr = dataTable.Rows[idx];
            string lotno = dr["LotNo"].ToString();
            int cnt = dataTable.Columns.Count - 1;

            string sizeNo = "";
            int qntDetial = 0, qntInventory=0 ;

            string detailID = Database.GetDataTimekey(2, DetailIndex++);
            gridView.SetRowCellValue(idx, colRowID, detailID);
            for (int i = BeginSizeNoIndex; i < cnt; i++)
            {
                sizeNo = dataTable.Columns[i].ColumnName;
                if (dr[i] == null || String.IsNullOrEmpty(dr[i].ToString()))
                    continue;
                qntDetial = Convert.ToInt32(dr[i]);
                if (qntDetial <= 0)
                    continue;
                qntInventory = GetActualInventory(lotno, sizeNo, OutboundKind);

                if (qntDetial > qntInventory)
                {
                    ErrorMsg = string.Format( "LotNo:{0},SizeNo:{1},库存不足，不能执行下一步！",lotno, sizeNo );
                    return false;
                }
            }

            return true;
        }
        
        public void ResetView()
        {
            for (int i = arValid.Length - 1; i >= 0; i--)
                arValid[i] = true;
        }
       
        #endregion
    }
}
