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
    public class InboundDetailView : BoundDetailView 
    {
        public string InboundID = String.Empty ;//入库单编号

        #region 视图初始化

        public InboundDetailView() 
        {
            this.LoadData = LoadInboundDetail;
        }
      
        public InboundDetailView(BandedGridView view)
        {
            base.SetGridView(view);
            this.LoadData = LoadInboundDetail;
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
            }
            else
            {
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                gridView.OptionsBehavior.ReadOnly = true;
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

        #region  加载数据

        private DataTable LoadDetail(string inboundID)
        {
            DataTable dt = null;

            string sql = String.Format("Select DetailID as RowID,  LotNo, SizeNo, NumofPlan  From T_InboundDetail where InboundID = '{0}'", inboundID);

            sql += " order by DetailID, LotNo, SizeNo ";

            dt = Database.Select(sql);

            return dt;
        }

        private void LoadInboundDetail()
        { 

            List<InventoryItem> list = InventoryList;
            list.Clear();
            DataTable dt = LoadDetail(InboundID);

            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }

            //将DataTable转换为ListItem
            string  lotNo = "", sizeNo = "", curID = "", lastID="";
            int quantity = 0,sum=0;

            InventoryItem item = null;
            DataRow dr = null;

            for (int i = 0, cnt = dt.Rows.Count; i < cnt; i++)
            {
                dr = dt.Rows[i];
                curID = dr["RowID"].ToString();
                lotNo = dr["LotNo"].ToString();
                sizeNo = dr["SizeNo"].ToString();

                if (lastID != curID)
                {
                    sum = 0;
                    item = new InventoryItem();
                    item.ID = curID;
                    item.LotNo = lotNo;
                    GetClothesData(item, lotNo);

                    list.Add(item);

                    lastID = curID;
                }

                quantity = Convert.ToInt32(dr["NumofPlan"]);
                sum += quantity;
                item.SubTotal = sum;
                item.Set(sizeNo, quantity);
                
            }
             
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
                if (e.Value == null)
                    return;
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
            int num = 0, sum = 0;
            try
            {
                num = Convert.ToInt32(e.Value);
                string temp = gridView.GetFocusedRowCellValue(colSubTotal).ToString();
                if (string.IsNullOrEmpty(temp) == false)
                    sum = Convert.ToInt32(temp);
                sum += num;
                gridView.SetFocusedRowCellValue(colSubTotal, sum);
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
 
        }
 
        private Clothes GetClothes(string lotNo)
        {
           List<Clothes> list =  MemoryTable.Instance.ListClothes;

           for (int i = 0; i < list.Count; i++)
           {
               if( list[i].LotNo == lotNo )
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
                if( obj ==null )
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
            string detialID = "";
            for (int i = rowHandles.Length - 1; i >= 0; i--)
            {
                detialID = gridView.GetRowCellValue(rowHandles[i], colRowID).ToString();

                if (String.IsNullOrEmpty(detialID) == false)
                   RemoveInboundDetail(detialID);
                gridView.DeleteRow(rowHandles[i]);
            }
        }

        public bool RemoveInboundDetail(string detialID)
        {
            string sql = String.Format("delete from T_InboundDetail where detailID = '{0}'", detialID);
            return Database.ExecuteSQL(sql, "InboundDetailView-RemoveInboundDetail") == 0 ? false : true;
        }
       
        #endregion

        #region 保存明细
       
        private int DetailIndex = 0;
       
        public void SaveInboundDetail()
        {
            string sqlIns = " Insert into T_InboundDetail (DetailID, InboundID, LotNo, SizeNo, NumOfPlan, NumOfReal , Status ) ";
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

        private void GetRowValuesSql(int idx , List<string>list )
        {
            DataRow dr = dataTable.Rows[idx];
            string lotno = dr["LotNo"].ToString();
            int cnt = dataTable.Columns.Count - 1;

            string field = "", sql;
            int quantity = 0;
            string detailID = Database.GetDataTimekey(1, DetailIndex++);
            gridView.SetRowCellValue(idx, colRowID, detailID);
            for (int i = BeginSizeNoIndex; i < cnt; i++)
            {
                field = dataTable.Columns[i].ColumnName;
                if (dr[i] == null || String.IsNullOrEmpty(dr[i].ToString()))
                    continue;
                quantity = Convert.ToInt32(dr[i]);
                if (quantity <= 0)
                    continue;
                sql = String.Format("('{0}','{1}','{2}','{3}',{4},{5},'{6}')",
                   detailID,
                   InboundID,
                   lotno,
                   field,
                   quantity,
                   quantity,
                   DealStatus.None);
                list.Add(sql);
            }
        }
        
        #endregion
    }
}
