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
    class InvoiceSelectionView : BaseGridView
    {
        public string FilterSql_Outbound = String.Empty;
        public string FilterSql_Backbound = String.Empty;
        public InvoiceSelectionView() { }
        public InvoiceSelectionView(GridView view)
        {
            base.SetGridView(view);
        }

        #region Grid Column

        protected DevExpress.XtraGrid.Columns.GridColumn colBoundID; 
        protected DevExpress.XtraGrid.Columns.GridColumn colOrderNo;        //订单号
        protected DevExpress.XtraGrid.Columns.GridColumn colSales; 
        protected DevExpress.XtraGrid.Columns.GridColumn colKind;           //销售还是退货
        protected DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        protected DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        protected DevExpress.XtraGrid.Columns.GridColumn colInvoiceAmount;
        protected DevExpress.XtraGrid.Columns.GridColumn colAmountDue;      //到期金额
        protected DevExpress.XtraGrid.Columns.GridColumn colPaymentDate;    //日期
        protected DevExpress.XtraGrid.Columns.GridColumn colCheck;

        protected override void CreateGridColumns()
        {
            this.colBoundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colSales = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmountDue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKind = new DevExpress.XtraGrid.Columns.GridColumn();
            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colCheck,
                        this.colBoundID,
                        this.colOrderDate, 
                        this.colOrderNo,
                        this.colSales,
                        this.colQuantity,
                        this.colInvoiceAmount,
                        this.colAmountDue,
                        this.colPaymentDate,
                        this.colKind };
            // 
            //colCheck
            //
            this.colCheck.Caption = "选择";
            this.colCheck.FieldName = "CheckStatus";
            this.colCheck.Name = "colCheck";
            this.colCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colCheck.OptionsColumn.AllowEdit = false;
            this.colCheck.OptionsColumn.AllowSort = DefaultBoolean.False;

            this.colCheck.Visible = true;
            this.colCheck.Width = 50;
            // 
            // colBoundID
            // 
            this.colBoundID.Caption = "单据号";
            this.colBoundID.FieldName = "BoundID";
            this.colBoundID.Name = "colBoundID";
            this.colBoundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBoundID.Visible = false;
            this.colBoundID.Width = 100;
            // 
            // colOrderDate
            // 
            this.colOrderDate.Caption = "Date";
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOrderDate.Visible = true;
            this.colOrderDate.Width = 100;
            
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
            // colSales
            // 
            this.colSales.Caption = "Customer#";
            this.colSales.FieldName = "CustomerNo";
            this.colSales.Name = "colSales";
            this.colSales.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSales.Visible = true;
            this.colSales.Width = 100;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Quantity";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colQuantity.Visible = true;
            this.colQuantity.Width = 50;
            // 
            // colInvoiceAmount
            // 
            this.colInvoiceAmount.Caption = "Rcvd Amount";
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
            // 
            // colPaymentDate
            // 
            this.colPaymentDate.Caption = "Payment Date";
            this.colPaymentDate.FieldName = "PaymentDate";
            this.colPaymentDate.Name = "colPaymentDate";
            this.colPaymentDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPaymentDate.Visible = true;
            this.colPaymentDate.Width = 100;
             
            // 
            // colKind
            // 
            this.colKind.Caption = "Catogery";
            this.colKind.FieldName = "BoundKind";
            this.colKind.Name = "colKind";
            this.colKind.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colKind.Visible = true;
            this.colKind.Width = 80;
        }
       
        #endregion

        #region 视图初始化

        protected override void InitGridView()
        {
            gridView.BeginInit();

            base.InitGridView();

            gridView.OptionsBehavior.Editable = false;           //是否允许用户编辑单元格
            gridView.OptionsCustomization.AllowColumnMoving = false;
            gridView.IndicatorWidth = 30;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;
            
            gridView.EndInit();

            //gridView.RowClick += new RowClickEventHandler(OnRowClick);
            gridView.CustomDrawCell += new RowCellCustomDrawEventHandler(OnCustomDrawCell);
            //gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(OnValidatingEditor);

        }

        protected override DataTable GetDataSource()
        {
            dataTable= base.GetDataSource();

            if (dataTable != null && dataTable.Columns["CheckStatus"] != null)
            {
                dataTable.Columns["CheckStatus"].DataType = System.Type.GetType("System.Boolean");

            }
            return dataTable;
        }

        #endregion

        #region 加载数据
 
        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }
    
        public override void Loading()
        {
            ClearRows();

            if (gridView == null)
                return;

            WaitingService.BeginLoading();

            gridView.BeginUpdate();
             

            dataTable = LoadingOutbound();
             
            AddInvoiceItems(LoadingBackbound());

            gridView.GridControl.DataSource = dataTable;

            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;
             
            gridView.EndUpdate();

            WaitingService.EndLoading();
        }

        private void AddInvoiceItems(DataTable dt)
        {
            int colCnt = dt.Columns.Count;
            DataRow dr = null;
            DataRow rowIns = null;
            for (int i = 0 ;i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                rowIns = dataTable.NewRow();

                rowIns["CheckStatus"] = dr["CheckStatus"];
                rowIns["BoundID"] = dr["BoundID"];
                rowIns["OrderNo"] = dr["OrderNo"];
                rowIns["CustomerNo"] = dr["CustomerNo"]; 
                rowIns["OrderDate"] = dr["OrderDate"];
                rowIns["Quantity"] = dr["Quantity"];
                rowIns["InvoiceAmount"] = dr["InvoiceAmount"];
                rowIns["DueAmount"] = dr["DueAmount"];
                rowIns["PaymentDate"] = dr["PaymentDate"]; 
                rowIns["BoundKind"] = dr["BoundKind"]; 
                dataTable.Rows.Add(rowIns);

            }
        }

        private DataTable LoadingOutbound()
        {

            string sql = "select OutboundID as BoundID, OrderNo, CustomerNo, SellTo, ShipDate as OrderDate, Quantity, RcvdAmount as InvoiceAmount, (PriceAmount + Freight) as DueAmount, Term,  PaymentDate , '' as BoundKind "
                       + " from V_OutboundCash ";
            if (string.IsNullOrEmpty(FilterSql_Outbound) == false)
                sql += FilterSql_Outbound;

            sql += String.Format(" and ShipDate <> '' ");

            sql += " order by CustomerNo asc, ShipDate desc , OrderNo asc ";
             
            DataTable dt = Database.Select(sql);

            dt.Columns.Add("CheckStatus", System.Type.GetType("System.Boolean"));
            Object obj = null;

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            { 
                dt.Rows[i]["CheckStatus"] = false;

                obj = dt.Rows[i]["InvoiceAmount"];
                if (obj != null && String.IsNullOrEmpty(obj.ToString()) == false)
                    dt.Rows[i]["InvoiceAmount"] = Convert.ToDouble(obj).ToString("f2");

                obj = dt.Rows[i]["DueAmount"];
                if (obj != null && String.IsNullOrEmpty(obj.ToString()) == false)
                    dt.Rows[i]["DueAmount"] = Convert.ToDouble(obj).ToString("f2");

            }

            return dt;
        }

        private DataTable LoadingBackbound()
        {
            string sql = "select BackboundID as BoundID,  OrderNo, Customer as CustomerNo,  OrderDate, Quantity, '0.0' as InvoiceAmount,  DueAmount, '0' as Term,  '' as PaymentDate ,'Return' as BoundKind  "
                       + " from V_BackboundInvoice ";

            if (string.IsNullOrEmpty(FilterSql_Backbound) == false)
                sql += FilterSql_Backbound;

            sql += " order by Customer asc, OrderDate desc , OrderNo asc ";

            DataTable dt = Database.Select(sql);
            Object obj = null;

            dt.Columns.Add("CheckStatus", System.Type.GetType("System.Boolean"));
              
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            { 
                dt.Rows[i]["CheckStatus"] = false;
                obj = dt.Rows[i]["InvoiceAmount"];
                if (obj != null && String.IsNullOrEmpty(obj.ToString()) == false)
                    dt.Rows[i]["InvoiceAmount"] = Convert.ToDouble(obj).ToString("f2");

                obj = dt.Rows[i]["DueAmount"];
                if (obj != null && String.IsNullOrEmpty(obj.ToString()) == false)
                    dt.Rows[i]["DueAmount"] = Convert.ToDouble(obj).ToString("f2");

            }

            return dt;
        }
        
        public void OnCustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "InvoiceStatus")
            {
                string status = e.CellValue.ToString();
                
                if (status == DealStatus.Yes)
                    e.DisplayText = "已打印";
                else
                    e.DisplayText = "";
            }
        }

        #endregion

        #region 选择

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

        private void OnRowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "CheckStatus")
            {
                bool bcheck = Convert.ToBoolean(gridView.GetFocusedValue());
                gridView.SetFocusedValue(!bcheck);
            }
        }

        public bool GetChecked(int rowHandle)
        {
            string value = gridView.GetRowCellValue(rowHandle, "CheckStatus").ToString();
            if (value == "True")
                return true;
            return false;
        }


        #endregion

       
    }
}
