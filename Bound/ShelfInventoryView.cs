using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
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
    public class ShelfInventoryView : BaseGridView
    {
        public string ShelfNo = string.Empty;
        public string LotNo = string.Empty;
        public string SizeNo = string.Empty;

        public ShelfInventoryView() { }
        public ShelfInventoryView(GridView view) 
        {
            base.SetGridView(view);
        }

        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colCheck;   
        protected DevExpress.XtraGrid.Columns.GridColumn colShelfNo; 
        protected DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colSizeNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        protected DevExpress.XtraGrid.Columns.GridColumn colTranCnt;
    
        protected override void CreateGridColumns()
        {
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSizeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTranCnt = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] { 
                        this.colCheck,
                        this.colShelfNo, 
                        this.colLotNo,
                        this.colSizeNo,
                        this.colQuantity,
                        this.colTranCnt
            };
            // 
            //colCheck
            //
            this.colCheck.Caption = "Selection";
            this.colCheck.FieldName = "CheckStatus";
            this.colCheck.Name = "colCheck";
            this.colCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colCheck.OptionsColumn.AllowEdit = false;
            this.colCheck.OptionsColumn.AllowSort = DefaultBoolean.False;

            this.colCheck.Visible = true;
            this.colCheck.Width = 60;
            // 
            // colShelfNo
            // 
            this.colShelfNo.Caption = "Shelf# From";//"货架号";
            this.colShelfNo.FieldName = "ShelfNo";
            this.colShelfNo.Name = "colShelfNo";
            this.colShelfNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShelfNo.Visible = true;
            this.colShelfNo.Width = 80;
             
            // 
            // colLotNo
            // 
            this.colLotNo.Caption = "Art#";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLotNo.Visible = true;
            this.colLotNo.Width = 80;
            // 
            // colSizeNo
            // 
            this.colSizeNo.Caption = "Size#";//"尺寸";
            this.colSizeNo.FieldName = "SizeNo";
            this.colSizeNo.Name = "colSizeNo";
            this.colSizeNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSizeNo.Visible = true;
            this.colSizeNo.Width = 80;

            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Quantity";//"数量";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colQuantity.Visible = true;
            this.colQuantity.Width = 80;
            // 
            // colTranCnt
            // 
            this.colTranCnt.Caption = "Tran QNT";//"数量";
            this.colTranCnt.FieldName = "TranQnt";
            this.colTranCnt.Name = "colTranCnt";
            this.colTranCnt.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colTranCnt.Visible = true;
            this.colTranCnt.Width = 80;

        }

        #endregion

        #region 表格初始化

        protected override void InitGridView()
        {
            base.InitGridView();
            gridView.OptionsBehavior.Editable = true;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;
            gridView.IndicatorWidth = 30;

            gridView.RowCellClick += new RowCellClickEventHandler(OnRowCellClick);
            gridView.RowClick += new RowClickEventHandler(OnRowClick);
            //this.gridView.ValidateRow += new ValidateRowEventHandler(OnValidateRow);
            this.gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(OnValidatingEditor);
        }

        #endregion

        #region 加载数据

        public override void Loading()
        {
            if( dataTable != null)
                 dataTable.Rows.Clear();
            if (string.IsNullOrEmpty(ShelfNo)  &&  string.IsNullOrEmpty(LotNo) )
                return;

            string sql = "";

            if (string.IsNullOrEmpty(ShelfNo) == false)
            {
                sql = String.Format("Select ShelfNo, LotNo, SizeNo, Quantity, Quantity as TranQnt From T_Inventory "
                   + " where Quantity > 0 and ShelfNo = '{0}' ",
                    ShelfNo);
            }
            else
            {
                sql = String.Format("Select ShelfNo, LotNo, SizeNo, Quantity, Quantity as TranQnt From T_Inventory "
                   + " where Quantity > 0 and ShelfNo <> '{0}'", 
                    MemoryTable.Shelf_99T99);
            }

            if (string.IsNullOrEmpty(LotNo) == false)
            { 
                sql += string.Format("and LotNo = '{0}'", LotNo); 
            }
            
            if ( string.IsNullOrEmpty(SizeNo) == false )
            {
                sql += string.Format("and SizeNo = '{0}'", SizeNo); 
            }

            sql += " order by ShelfNo , LotNo, SizeNo ";

            dataTable = Database.Select(sql);
            dataTable.Columns.Add("CheckStatus", System.Type.GetType("System.Boolean"));

            if (dataTable == null)
                return;
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                dataTable.Rows[i]["CheckStatus"] = false;
            }

            gridView.GridControl.DataSource = dataTable;
            if (gridView.RowCount > 0)
                gridView.IndicatorWidth = 25 + (gridView.RowCount.ToString().Length ) * 6;
        }
        
        public void CheckAll()
        {
            int cnt = gridView.RowCount;

            for (int i = 0; i < cnt; i++)
            {
                gridView.SetRowCellValue(i, colCheck, true);
            }
        }

        public void UnCheck()
        {
            int cnt = gridView.RowCount;

            for (int i = 0; i < cnt; i++)
            {
                gridView.SetRowCellValue(i, colCheck, false);
            }
        }

        public int GetCheckedRowCount()
        {
            int res = 0;
            int cnt = gridView.RowCount;
            string value;
            for (int i = 0; i < cnt; i++)
            {
                value = gridView.GetRowCellValue(i, colCheck).ToString();
                if (value == "True")
                    res++;
            }

            return res;
        }

        public bool IsRowChecked(int idx)
        {
            if ("True" == gridView.GetRowCellValue(idx, colCheck).ToString() )
                return true;
            return false;
        }

        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }

        public void SetRowCheckedState(int rowHandle, bool status)
        {
            gridView.SetRowCellValue(rowHandle, colCheck, status);
        }

        #endregion

        #region 视图编辑

        public void OnRowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "CheckStatus")
            {
                bool bcheck = Convert.ToBoolean(gridView.GetFocusedValue());
                gridView.SetFocusedValue(!bcheck);
            }
        }

        public void OnRowClick(object sender, RowClickEventArgs e)
        {
            for (int i = 0; i < gridView.Columns.Count; i++)
                gridView.Columns[i].OptionsColumn.AllowEdit = false; 
            colTranCnt.OptionsColumn.AllowEdit = true;
        }
         
        public void OnValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            int cnt = 0;
            int rowHandle = gridView.FocusedRowHandle;
            try
            {
                cnt = Convert.ToInt32(e.Value);
            }
            catch
            {
                e.ErrorText = "只能输入一个整数";
                e.Valid = false;
            }
            int qnt = Convert.ToInt32(gridView.GetRowCellValue(rowHandle, colQuantity));
            if (cnt <= 0)
            {
                e.ErrorText = "倒库数量不能小于0. ";
                e.Valid = false;
                gridView.SetRowCellValue(rowHandle, colTranCnt, qnt);
                return;
            }
            if (cnt > qnt)
            {
                e.ErrorText = "倒库数量大于库存量. ";
                e.Valid = false;
                gridView.SetRowCellValue(rowHandle, colTranCnt, qnt);
                return;
            }
        }

        #endregion

        public void GetTranBoundItem(int rowHandle, TranboundItem item )
        {
            if(item == null)
              item = new TranboundItem();

            item.lotNo = gridView.GetRowCellValue(rowHandle, colLotNo).ToString();
            item.sizeNo = gridView.GetRowCellValue(rowHandle, colSizeNo).ToString();
            item.fromShelfNo = gridView.GetRowCellValue(rowHandle, colShelfNo).ToString();
            item.quantity = Convert.ToInt32(gridView.GetRowCellValue(rowHandle, colTranCnt));
             
        }
    }

    public class TranboundItem
    {
        public string detailId;
        public string lotNo;
        public string sizeNo;
        public string fromShelfNo;
        public string toShelfNo;
        public int quantity;
    }
}
