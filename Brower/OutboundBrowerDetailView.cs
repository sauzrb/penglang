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
    public class OutboundBrowerDetailView : BaseGridView
    {
        public String FilterSql = String.Empty;

        public OutboundBrowerDetailView() { }
        public OutboundBrowerDetailView(GridView view)
        {
                 base.SetGridView(view);
        }

        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colOrderNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        protected DevExpress.XtraGrid.Columns.GridColumn colSales;
        protected DevExpress.XtraGrid.Columns.GridColumn colShelfNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colLotNo;
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

            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSales = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colShelfNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSizeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrderNo, 
            this.colOrderDate,
            this.colSales,
            this.colLotNo, 
            this.colSizeNo,
            this.colQuantity  };
            // 
            // colOrderNo
            // 
            this.colOrderNo.Caption = "Order#";
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOrderNo.Visible = true;
            this.colOrderNo.Width = 150;
            // 
            // colOrderDate
            // 
            this.colOrderDate.Caption = "Ship Date";
            this.colOrderDate.FieldName = "ShipDate";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOrderDate.Visible = true;
            this.colOrderDate.Width = 120;
            // 
            // colSales
            // 
            this.colSales.Caption = "Customer#";
            this.colSales.FieldName = "CustomerNo";
            this.colSales.Name = "colSales";
            this.colSales.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSales.Visible = true;
            this.colSales.Width = 120;

            // 
            // colShelfNo
            // 
            this.colShelfNo.Caption = "Shelf#";
            this.colShelfNo.FieldName = "ShelfNo";
            this.colShelfNo.Name = "colShelfNo";
            this.colShelfNo.Visible = true;
            this.colShelfNo.Width = 100;
           
           
            // 
            // colLotNo
            // 
            this.colLotNo.Caption = "Art#";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLotNo.Visible = true;
            this.colLotNo.Width = 120;
            
            this.colSizeNo.Caption = "Size#";
            this.colSizeNo.FieldName = "SizeNo";
            this.colSizeNo.Name = "colShell";
            this.colSizeNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSizeNo.Visible = true;
            this.colSizeNo.Width = 100;

            //数量
            this.colQuantity.Caption = "Quantity";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 30;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colQuantity.Visible = true;
            this.colQuantity.Width = 100;


        }

        public void LoadOutboundDetail(string lotNo )
        {
            string sql = "Select OrderNo, ShipDate,Sales,CustomerNo, LotNo, SizeNo, NumOfReal as Quantity, CreateTime From V_OutboundDetail   ";


            if (String.IsNullOrEmpty(FilterSql))
                sql += String.Format(" where LotNo = '{0}' and OutboundKind <> '2'  ", lotNo);
            else
            {
                sql += FilterSql;
                sql += String.Format(" and LotNo = '{0}' and OutboundKind <> '2'", lotNo);
            }

            sql += " order by  OrderNo,CreateTime,lotNo, SizeNo ";

            dataTable = Database.Select(sql);
            if (dataTable == null)
                return;
            gridView.GridControl.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;
        }

        public void LoadOutboundDetail(string lotNo, string sizeNo)
        {
            string sql = "Select OrderNo, ShipDate,Sales, CustomerNo, LotNo, SizeNo, NumOfReal as Quantity, CreateTime  From V_OutboundDetail    ";

            if (String.IsNullOrEmpty(FilterSql))
                sql += String.Format("where LotNo = '{0}' and SizeNo = '{1}'", lotNo, sizeNo );
            else
            {
                sql += FilterSql;
                sql += String.Format("and LotNo = '{0}' and sizeNo = '{1}' ", lotNo, sizeNo );
            }

            sql += " order by OrderNo, CreateTime ,lotNo, SizeNo";

            dataTable = Database.Select(sql);
            if (dataTable == null)
                return;
            gridView.GridControl.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;
        }
        
        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }
 

    }

}
