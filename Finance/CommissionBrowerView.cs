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
    class CommissionBrowerView : BaseGridView
    {
        public string Sales  = String.Empty;
        public string BeginDate = string.Empty;
        public string EndDate = string.Empty;

        public CommissionBrowerView() { }
        public CommissionBrowerView(GridView view)
        {
            base.SetGridView(view);
        }

        #region Grid Column

        protected DevExpress.XtraGrid.Columns.GridColumn colBoundID; 
        protected DevExpress.XtraGrid.Columns.GridColumn colPoNo;        //订单号
        protected DevExpress.XtraGrid.Columns.GridColumn colSales;          //销售
        protected DevExpress.XtraGrid.Columns.GridColumn colCustomer;       //顾客
        protected DevExpress.XtraGrid.Columns.GridColumn colShipDate;       //发货日期    
        protected DevExpress.XtraGrid.Columns.GridColumn colDueDate;        //收款日期 
        protected DevExpress.XtraGrid.Columns.GridColumn colTrackingNo;     //发货单号 
        protected DevExpress.XtraGrid.Columns.GridColumn colQuantity;       //数量
        protected DevExpress.XtraGrid.Columns.GridColumn colPriceAmount;    //服装金额
        protected DevExpress.XtraGrid.Columns.GridColumn colInvAmount;      //发票金额（含运费）
        protected DevExpress.XtraGrid.Columns.GridColumn colCommStatus;     //支付状态
        protected DevExpress.XtraGrid.Columns.GridColumn colCommAmount;     //佣金
        protected DevExpress.XtraGrid.Columns.GridColumn colCommPercent;    //佣金比例  
        protected DevExpress.XtraGrid.Columns.GridColumn colCheck;
        protected DevExpress.XtraGrid.Columns.GridColumn colFreight;
       
        protected override void CreateGridColumns()
        {
            this.colBoundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShipDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPoNo = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommPercent = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colTrackingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreight = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {  this.colBoundID, 
                        this.colCheck,
                        this.colSales,
                        this.colCustomer, 
                        this.colPoNo,
                        this.colShipDate,
                        this.colDueDate,
                        this.colTrackingNo,
                        this.colQuantity, 
                        this.colInvAmount, 
                        this.colFreight, 
                        this.colPriceAmount,
                        this.colCommPercent,
                        this.colCommAmount,
                        this.colCommStatus};
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
            this.colBoundID.FieldName = "OutboundID";
            this.colBoundID.Name = "colBoundID";
            this.colBoundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBoundID.Visible = false;
            this.colBoundID.Width = 100; 
            // 
            // colPoNo
            // 
            this.colPoNo.Caption = "P.O#";
            this.colPoNo.FieldName = "OrderNo";
            this.colPoNo.Name = "colPoNo";
            this.colPoNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPoNo.Visible = true;
            this.colPoNo.Width = 120;
            // 
            // colSales
            // 
            this.colSales.Caption = "Sales";
            this.colSales.FieldName = "Sales";
            this.colSales.Name = "colSales";
            this.colSales.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSales.Visible = true;
            this.colSales.Width = 120;
            // 
            //colCustomer
            //
            this.colCustomer.Caption = "Receiver";
            this.colCustomer.FieldName = "SellTo";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colCustomer.OptionsColumn.AllowEdit = false;
            this.colCustomer.OptionsColumn.AllowSort = DefaultBoolean.False; 
            this.colCustomer.Visible = true;
            this.colCustomer.Width = 150;

            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Qty";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colQuantity.Visible = true;
            this.colQuantity.Width = 50;
           
            // 
            // colInvAmount
            // 
            this.colInvAmount.Caption = "Inv Amt";
            this.colInvAmount.FieldName = "InvoiceAmount";
            this.colInvAmount.Name = "colInvAmount";
            this.colInvAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colInvAmount.Visible = true;
            this.colInvAmount.Width = 110;
            this.colInvAmount.DisplayFormat.FormatString = "0.0";
            this.colInvAmount.DisplayFormat.FormatType = FormatType.Custom;
            // 
            // colFreight
            // 
            this.colFreight.Caption = "Freight";
            this.colFreight.FieldName = "Freight";
            this.colFreight.Name = "colFreight";
            this.colFreight.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colFreight.Visible = true;
            this.colFreight.Width = 100;
            this.colFreight.DisplayFormat.FormatString = "0.0";
            this.colFreight.DisplayFormat.FormatType = FormatType.Custom;
            // 
            // colPriceAmount
            // 
            this.colPriceAmount.Caption = "Comm Amt";
            this.colPriceAmount.FieldName = "PriceAmount";
            this.colPriceAmount.Name = "colPriceAmount";
            this.colPriceAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colPriceAmount.Visible = true;
            this.colPriceAmount.Width = 110;
            this.colPriceAmount.DisplayFormat.FormatString = "0.0";
            this.colPriceAmount.DisplayFormat.FormatType = FormatType.Custom;
            // 
            // colCommPercent
            // 
            this.colCommPercent.Caption = " % ";
            this.colCommPercent.FieldName = "CommPercent";
            this.colCommPercent.Name = "colCommPercent";
            this.colCommPercent.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCommPercent.Visible = true;
            this.colCommPercent.Width = 80;
            this.colCommPercent.DisplayFormat.FormatString = "0.0";
            this.colCommPercent.DisplayFormat.FormatType = FormatType.Custom;
            // 
            // colShipDate
            // 
            this.colShipDate.Caption = "Ship Date";
            this.colShipDate.FieldName = "ShipDate";
            this.colShipDate.Name = "colShipDate";
            this.colShipDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShipDate.Visible = true;
            this.colShipDate.Width = 100;

            // 
            // colDueDate
            // 
            this.colDueDate.Caption = "Due Date";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Name = "colDueDate";
            this.colDueDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDueDate.Visible = true;
            this.colDueDate.Width = 100;
            // 
            // colTrackingNo
            // 
            this.colTrackingNo.Caption = "Tracking#";
            this.colTrackingNo.FieldName = "TrackingNo";
            this.colTrackingNo.Name = "colTrackingNo";
            this.colTrackingNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTrackingNo.Visible = true;
            this.colTrackingNo.Width = 100;
            // 
            // Commission \nAmount
            // 
            this.colCommAmount.Caption = "Commission";
            this.colCommAmount.FieldName = "CommissionAmount";
            this.colCommAmount.Name = "colCommAmount";
            this.colCommAmount.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCommAmount.Visible = true;
            this.colCommAmount.Width = 100;
            this.colCommAmount.DisplayFormat.FormatString = "0.0";
            this.colCommAmount.DisplayFormat.FormatType = FormatType.Custom;
            // 
            // colCommStatus
            // 
            this.colCommStatus.Caption = "Comm Paid";
            this.colCommStatus.FieldName = "CommPaid";
            this.colCommStatus.Name = "colCommStatus";
            this.colCommStatus.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colCommStatus.Visible = true;
            this.colCommStatus.Width = 80;

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

            gridView.RowCellStyle += new RowCellStyleEventHandler(OnRowCellStyle);
            gridView.RowCellClick += new RowCellClickEventHandler(OnRowCellClick);
        }

        protected override DataTable GetDataSource()
        {
            dataTable= base.GetDataSource(); 
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

            dataTable = LoadingCommission();
              
            gridView.GridControl.DataSource = dataTable;

            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;
             
            gridView.EndUpdate();

            WaitingService.EndLoading();
        }

        private DataTable LoadingCommission()
        {
            string sql = "select OutboundID , OrderNo, Sales, SellTo, ShipDate, DueDate,Quantity, InvoiceAmount, PriceAmount, WoAmount,TrackingNo, Freight,"
                       + " 100*( (PriceAmount- WoAmount )/(PriceAmount) ) as CommPercent,  (PriceAmount- WoAmount) as CommissionAmount ,CommPaid "
                       + " from  V_OutboundComs where Sales <> 'NO' and OutboundStatus = '3' ";

            if (string.IsNullOrEmpty(BeginDate) == false)
                sql += string.Format(" AND ShipDate >= '{0}'", BeginDate);
            if (string.IsNullOrEmpty(EndDate) == false)
                sql += string.Format("AND ShipDate <= '{0}'", EndDate);

            if (string.IsNullOrEmpty(Sales) == false)
                sql += string.Format(" and Sales like '{0}%'", Sales);

            sql += " order by Sales asc, ShipDate  asc, OrderNo asc ";
             
            DataTable dt = Database.Select(sql);
            
            
            dt.Columns.Add("CheckStatus", System.Type.GetType("System.Boolean"));

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                dt.Rows[i]["CheckStatus"] = false;
            }

            return dt;
        }
         
        #endregion

        #region 字体颜色

        public void OnRowCellStyle(object sender, RowCellStyleEventArgs e)
        { 
        }

        #endregion
        
        #region Check


        public void OnRowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "CheckStatus")
            {
                bool bcheck = Convert.ToBoolean(gridView.GetFocusedValue());
                gridView.SetFocusedValue(!bcheck);
            }
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


        #endregion
    }
     
}
