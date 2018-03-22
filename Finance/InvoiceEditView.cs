using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
    class InvoiceEditView : BaseGridView
    {
        public string FilterSql = String.Empty;

        public InvoiceEditView() { }
        public InvoiceEditView(GridView view)
        {
            base.SetGridView(view);
        }

        #region Grid Column

        protected DevExpress.XtraGrid.Columns.GridColumn colIndex;
        protected DevExpress.XtraGrid.Columns.GridColumn colDate;
        protected DevExpress.XtraGrid.Columns.GridColumn colOrderNo;        //订单号 
        protected DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        protected DevExpress.XtraGrid.Columns.GridColumn colInvoiceAmount;
        protected DevExpress.XtraGrid.Columns.GridColumn colAmountDue;      //到期金额
        
        protected override void CreateGridColumns()
        {
            this.colIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();  
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmountDue = new DevExpress.XtraGrid.Columns.GridColumn(); 

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colIndex,
                        this.colDate, 
                        this.colOrderNo, 
                        this.colQuantity,
                        this.colInvoiceAmount,
                        this.colAmountDue  }; 
            // 
            // colIndex
            // 
            this.colIndex.Caption = "No.";
            this.colIndex.FieldName = "Index";
            this.colIndex.Name = "colIndex";
            this.colIndex.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colIndex.Visible = false;
            this.colIndex.Width = 40;
            // 
            // colDate
            // 
            this.colDate.Caption = "Date";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDate.Visible = true;
            this.colDate.Width = 100;
            
            // 
            // colOrderNo
            // 
            this.colOrderNo.Caption = "P.O#";
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOrderNo.Visible = true;
            this.colOrderNo.Width = 100;
           
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "QNT";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colQuantity.Visible = true;
            this.colQuantity.Width = 50;
            // 
            // colInvoiceAmount
            // 
            this.colInvoiceAmount.Caption = "Invoice Amount";
            this.colInvoiceAmount.FieldName = "InvoiceAmount";
            this.colInvoiceAmount.Name = "colInvoiceAmount";
            this.colInvoiceAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colInvoiceAmount.Visible = true;
            this.colInvoiceAmount.Width = 80;
            // 
            // colAmountDue
            // 
            this.colAmountDue.Caption = "Amount Due";
            this.colAmountDue.FieldName = "DueAmount";
            this.colAmountDue.Name = "colAmountDue";
            this.colAmountDue.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colAmountDue.Visible = true;
            this.colAmountDue.Width = 80;
             
        }
       
        #endregion

        #region 视图初始化

        protected override void InitGridView()
        {
            gridView.BeginInit();

            base.InitGridView();

            gridView.OptionsBehavior.Editable = true;           //是否允许用户编辑单元格
            gridView.OptionsCustomization.AllowColumnMoving = false;
            gridView.IndicatorWidth = 30;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;

            gridView.OptionsNavigation.AutoFocusNewRow = true;
            gridView.OptionsSelection.InvertSelection = true;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView.EndInit();

            gridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
        }
         
        #endregion

        #region 加载数据
         
        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }

        public void GetSelectionOutbound(InvoiceSelectionView selView)
        {
            GridView view = selView.GetGridView();
            this.ClearRows();

            DataRow dr = null;
            Object obj = null;
            for (int i = 0,idx=1; i < view.RowCount; i++)
            {
                if (selView.GetChecked(i) == false)
                    continue;

                dr = dataTable.NewRow();
                dr["Index"] = idx++;

                obj =  view.GetRowCellValue(i, "OrderDate");
                if (obj == null || String.IsNullOrEmpty(obj.ToString()))
                    dr["Date"] = "";
                else
                {
                     DateTime time = Convert.ToDateTime(obj);
                     //dr["Date"] = time.ToString("MM")+"/"+time.ToString("dd")+"/"+time.ToString("yy");
                     dr["Date"] = time.ToString("yyyy-MM-dd");
                }
               
                dr["OrderNo"] = view.GetRowCellValue(i, "OrderNo");
                dr["Quantity"] = view.GetRowCellValue(i, "Quantity");
                dr["InvoiceAmount"] = view.GetRowCellValue(i, "InvoiceAmount");
                dr["DueAmount"] = view.GetRowCellValue(i, "DueAmount");

                dataTable.Rows.Add(dr);
            }

            this.gridView.GridControl.DataSource = dataTable;

        }
       
        #endregion


        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveRows();
            else if (e.KeyCode == Keys.Insert)
                InsertRow();
        }

        public void RemoveRows()
        {
            int[] rows = gridView.GetSelectedRows(); 
            if (MsgBox.Confirm("您确定要删除所有选中的数据吗？ ") == false)
                return;
            RemoveRows(rows);

        }
      
        public void RemoveRows(int[] rowHandles)
        {
            if (rowHandles == null)
                return; 
            for (int i = rowHandles.Length - 1; i >= 0; i--)
            { 
                gridView.DeleteRow(rowHandles[i]);
            }
        }

        public void InsertRow()
        {
            int pos = gridView.FocusedRowHandle;
            if (pos < -1)
                pos = 0; 
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, pos);

        }

    }
}
