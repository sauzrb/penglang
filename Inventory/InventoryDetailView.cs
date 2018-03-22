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
using Sau.Util;

namespace PengLang 
{
    public class InventoryDetialView : BaseGridView
    {
        public InventoryDetialView() { }
        public InventoryDetialView(GridView view)
        {
                 base.SetGridView(view);
        }

        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colShelfNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colStyleNo; 
        protected DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colColor; 
        protected DevExpress.XtraGrid.Columns.GridColumn colSizeNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colQuantity;

        #endregion

        protected override void InitGridView()
        {
            base.InitGridView();
            gridView.OptionsBehavior.Editable = false;  //是否允许用户编辑单元格 
            gridView.OptionsView.ColumnAutoWidth = false;

            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
        }
       
        protected override void CreateGridColumns()
        {
            this.colShelfNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStyleNo = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColor = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colSizeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShelfNo, 
            this.colLotNo,
            this.colStyleNo,
            this.colColor, 
            this.colSizeNo,
            this.colQuantity  };

            // 
            // colShelfNo
            // 
            this.colShelfNo.Caption = "Shelf#";
            this.colShelfNo.FieldName = "ShelfNo";
            this.colShelfNo.Name = "colShelfNo";
            this.colShelfNo.Visible = true;
            this.colShelfNo.Width = 80;
            // 
            // colStyleNo
            // 
            this.colStyleNo.Caption = "Style#";
            this.colStyleNo.FieldName = "StyleNo";
            this.colStyleNo.Name = "colStyleNo";
            this.colStyleNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStyleNo.Visible = true;
            this.colStyleNo.Width = 100;
           
            // 
            // colLotNo
            // 
            this.colLotNo.Caption = "Art#";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLotNo.Visible = true;
            this.colLotNo.Width = 100;
            // 
            // colColor
            // 
            this.colColor.Caption = "Color";
            this.colColor.FieldName = "Color";
            this.colColor.Name = "colColor";
            this.colColor.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colColor.Visible = true;
            this.colColor.Width = 70; 

            this.colSizeNo.Caption = "Size#";
            this.colSizeNo.FieldName = "SizeNo";
            this.colSizeNo.Name = "colShell";
            this.colSizeNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSizeNo.Visible = true;
            this.colSizeNo.Width = 50;

            //数量
            this.colQuantity.Caption = "Quantity";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 30;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colQuantity.Visible = true;
            this.colQuantity.Width = 60;


        }

        public void LoadInventory(string lotNo )
        {
            string sql = String.Format("Select ShelfNo, StyleNo, LotNo, SizeNo, Color, Quantity From V_Inventory "
                                       + " where LotNo = '{0}' and( Quantity > 0 or Quantity < 0) and ShelfNo <> '{1}' ", lotNo, MemoryTable.Shelf_99T99);
            sql += " order by SizeNo, ShelfNo ";

            DataTable dt = Database.Select(sql);
            if (dt == null)
                return;
            gridView.GridControl.DataSource = dt;
            if (dt.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dt.Rows.Count.ToString().Length + 1) * 5;
        }

        public void LoadInventory(string lotNo, string sizeNo)
        {
            string sql = String.Format("Select ShelfNo, StyleNo, LotNo, SizeNo, Color, Quantity From V_Inventory  "
                                        + "where LotNo = '{0}' and sizeNo = '{1}'and ( Quantity > 0 or Quantity < 0) and ShelfNo <> '{2}'", lotNo, sizeNo, MemoryTable.Shelf_99T99);
            sql += " order by sizeNo, shelfNo ";
            DataTable dt = Database.Select(sql);
            if (dt == null)
                return;
            gridView.GridControl.DataSource = dt;
            if (dt.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dt.Rows.Count.ToString().Length + 1) * 5;
        }

        public void LoadShelfInventory(string shelfNo )
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
               
            string sql =  "Select ShelfNo, StyleNo, LotNo, SizeNo, Color, Quantity From V_Inventory ";

            sql += " where Quantity > 0 " ;
            if (shelfNo.Length > 0)
                sql += String.Format(" and ShelfNo like '%{0}%'", shelfNo);

            sql += " order by shelfNo,StyleNo,LotNo,sizeNo  ";

            DataTable dt = Database.Select(sql);
            if (dt == null)
                return;
            gridView.GridControl.DataSource = dt;
            if (dt.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dt.Rows.Count.ToString().Length + 1) * 5;
        }

        public void LoadShelfInventory()
        {
            string shelfNo = "";
            LoadShelfInventory(shelfNo);
        }

        public void ClearRows()
        {
            if (dataTable == null)
                return;
            dataTable.Rows.Clear(); 
        }

        public void RemoveRows(int[] rowHandles)
        {
            if (rowHandles == null)
                return;
            string shelfNo = "";
            string lotNo = "";
            string sizeNo = "";
            for (int i = rowHandles.Length - 1; i >= 0; i--)
            {
                shelfNo = gridView.GetRowCellValue(rowHandles[i], colShelfNo).ToString();
                lotNo = gridView.GetRowCellValue(rowHandles[i], colLotNo).ToString();
                sizeNo = gridView.GetRowCellValue(rowHandles[i], colSizeNo).ToString();
                if( DeleteInventory(shelfNo, lotNo, sizeNo) > 0 )
                    gridView.DeleteRow(rowHandles[i]);
            }
             
        }

        private int DeleteInventory(string shelfNo, string lotNo, string sizeNo)
        {
            string sql = String.Format("delete from T_Inventory where shelfNo = '{0}' and lotNo = '{1}' and sizeNo = '{2}'", shelfNo, lotNo, sizeNo);

            return Database.ExecuteSQL(sql, "InventoryDetailView-DeleteInventory");
        }
    }

}
