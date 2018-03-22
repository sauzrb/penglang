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

using Sau.Util;

namespace PengLang
{
    public class ShelfGridView : BaseGridView
    {
        public string KeyWords = String.Empty;
        public bool CanEdit = false;

        public ShelfGridView()
        { 
        }
       
        public ShelfGridView(GridView view)
        {
            base.SetGridView(view); 
        }

        #region GridColumn
         
        protected DevExpress.XtraGrid.Columns.GridColumn colShelfNo; 
        protected DevExpress.XtraGrid.Columns.GridColumn colRowNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colColNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colLevelNo; 

        #endregion
         
        protected override void InitGridView()
        { 
            base.InitGridView();

            gridView.OptionsView.ColumnAutoWidth = false;

            if (CanEdit == true)
            {

                gridView.OptionsBehavior.Editable = true;   //是否允许用户编辑单元格
                gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
                gridView.OptionsCustomization.AllowColumnMoving = true;
                gridView.OptionsNavigation.AutoFocusNewRow = true;
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            }
            else
            {
                //关闭表格编辑功能
                gridView.OptionsBehavior.Editable = false;   //是否允许用户编辑单元格
                //gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                //gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
                //gridView.OptionsCustomization.AllowColumnMoving = true;
                //gridView.OptionsNavigation.AutoFocusNewRow = true;
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;// NewItemRowPosition.Bottom;

            }
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;
             

            gridView.CellValueChanged += new CellValueChangedEventHandler(this.OnCellValueChanged);
            gridView.IndicatorWidth = 30; 
        }
     
        protected override void CreateGridColumns()
        { 
            this.colShelfNo = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colRowNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelNo = new DevExpress.XtraGrid.Columns.GridColumn();  

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] { 
            this.colShelfNo,
            this.colRowNo,
            this.colLevelNo,
            this.colColNo };
            
            // 
            // colShelfNo
            // 
            this.colShelfNo.Caption = "Shelf#";// "货架号";
            this.colShelfNo.FieldName = "ShelfNo";
            this.colShelfNo.Name = "colShelfNo";
            this.colShelfNo.Visible = true;
            this.colShelfNo.Width = 100;
            this.colShelfNo.OptionsColumn.AllowEdit = false;
             
            // 
            // colRowNo
            // 
            this.colRowNo.Caption = "Row#";//"行号";
            this.colRowNo.FieldName = "RowNo";
            this.colRowNo.Name = "colRowNo";
            this.colRowNo.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colRowNo.Visible = true;
            this.colRowNo.Width = 60;
            this.colRowNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRowNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            // 
            // colLevelNo
            // 
            this.colLevelNo.Caption = "Level#";//"层号";
            this.colLevelNo.FieldName = "LevelNo";
            this.colLevelNo.Name = "colLevelNo";
            this.colLevelNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLevelNo.Visible = true;
            this.colLevelNo.Width = 60; 
            this.colLevelNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevelNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            // 
            // colColNo
            // 
            this.colColNo.Caption = "Column#";// "列号";
            this.colColNo.FieldName = "ColNo";
            this.colColNo.Name = "colColNo";
            this.colColNo.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colColNo.Visible = true;
            this.colColNo.Width = 60; 
            this.colColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            
        }

        private void OnCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
            if (e.Column.FieldName != "ShelfNo")
            {
                string levelNo = gridView.GetFocusedRowCellValue("LevelNo").ToString().ToUpper();
                string colNo = gridView.GetFocusedRowCellValue("ColNo").ToString();
                string rowNo = gridView.GetFocusedRowCellValue("RowNo").ToString();

                string shelfNo = rowNo.PadLeft(2, '0') + levelNo + colNo.PadLeft(2, '0'); 
                gridView.SetRowCellValue(e.RowHandle, "ShelfNo", shelfNo);
            }
                       
        }
 
        public override void Loading()
        {
             
            if (gridView == null)
                return;

            WaitingService.BeginLoading();
            
            gridView.BeginUpdate();
            gridView.BeginDataUpdate();

            string sql = String.Format("Select ShelfNo, RowNo, LevelNo, ColNo  From T_Shelf ");
            if (String.IsNullOrEmpty(KeyWords) == false)
            {
                sql += String.Format("where shelfNo like '%{0}%' ", KeyWords);
            }
            sql += " order by ShelfNo ";
            DataTable dt = Database.Select(sql);
            //dt.Columns.Add("Check", System.Type.GetType("System.Boolean"));   
            gridView.GridControl.DataSource = dt;

            gridView.EndDataUpdate();
            if( dt.Rows.Count > 0 )
                gridView.IndicatorWidth = 25 + ( dt.Rows.Count.ToString().Length + 1) * 5;

            gridView.EndUpdate();

            WaitingService.EndLoading();
        }
          
        public void RemoveRows(int []rowHandles)
        {
            if (rowHandles == null)
                return;
            string shelfNo = "";
            for (int i = rowHandles.Length - 1; i >= 0; i--)
            {
                shelfNo = gridView.GetRowCellValue(rowHandles[i],colShelfNo).ToString();
                if( RemoveShelf(shelfNo) == true )
                    gridView.DeleteRow(rowHandles[i]);
            }
        }

        private bool RemoveShelf(string shelfNo)
        {
            string sql = String.Format("delete from t_shelf where shelfNo = '{0}'", shelfNo);
            return Database.ExecuteSQL(sql, "ShelfGridView-RemoveShelf") == 0 ? false : true;
        }

        public void InsertRow(int pos)
        {

            DataTable dt = gridView.GridControl.DataSource as DataTable;
            DataRow dataRow = dt.NewRow();
            dt.Rows.InsertAt(dataRow, pos);

        }

        public bool UpdateShelf(int rowHandle)
        {
            string sql = "";
            string shelfNo = gridView.GetRowCellValue(rowHandle, colShelfNo).ToString();
            if (FindShelfNo(shelfNo) == true)
            { 
                return false;
            }
            string rowNo   = gridView.GetRowCellValue(rowHandle, colRowNo).ToString();
            string levelNo = gridView.GetRowCellValue(rowHandle, colLevelNo).ToString();
            string colNo  = gridView.GetRowCellValue(rowHandle, colColNo).ToString();
            sql = String.Format("Insert into T_Shelf (ShelfNo,ClothesType, RowNo, LevelNo, ColNo,Capacity,Status ) "
                +"Values('{0}','{1}',{2},'{3}',{4},{5},'{6}')",
                shelfNo,
                "",
                rowNo,
                levelNo,
                colNo,
                30,
                "" );

            return Database.ExecuteSQL(sql, "ShelfGridView-UpdateShelf") == 1 ? true : false;
        }
        
        private bool FindShelfNo(string shelfNo)
        {
            string sql = String.Format("select ShelfNo from t_shelf where ShelfNo = '{0}'", shelfNo);
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            else
                return true;
        }
    }
}
