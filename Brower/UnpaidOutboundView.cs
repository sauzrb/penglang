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
    class UnpaidOutboundView : BaseGridView
    {
        public string OutboundFilterSql = String.Empty;
        public string BeginDate = string.Empty;
        public string EndDate = string.Empty;

        public UnpaidOutboundView() { }
        public UnpaidOutboundView(GridView view)
        {
            base.SetGridView(view);
        }

        #region Grid Column

        protected DevExpress.XtraGrid.Columns.GridColumn colBoundID; 
        protected DevExpress.XtraGrid.Columns.GridColumn colPoNo;           //订单号
        protected DevExpress.XtraGrid.Columns.GridColumn colSales;          //销售
        protected DevExpress.XtraGrid.Columns.GridColumn colCustomer;       //顾客
        protected DevExpress.XtraGrid.Columns.GridColumn colShipDate;       //发货日期    
        protected DevExpress.XtraGrid.Columns.GridColumn colDueDate;        //收款日期  
        protected DevExpress.XtraGrid.Columns.GridColumn colQuantity;       //数量
        protected DevExpress.XtraGrid.Columns.GridColumn colPriceAmount;    //服装金额 Comm Amt
        protected DevExpress.XtraGrid.Columns.GridColumn colInvAmount;      //发票金额（含运费） 
        protected DevExpress.XtraGrid.Columns.GridColumn colCommission;     //应付佣金
        protected DevExpress.XtraGrid.Columns.GridColumn colRcvdAmount;     //已收金额
        protected DevExpress.XtraGrid.Columns.GridColumn colPayoff;         //结清收款状态  
        protected DevExpress.XtraGrid.Columns.GridColumn colCommPaid;       //佣金支付状态
        protected DevExpress.XtraGrid.Columns.GridColumn colPaymentMode;    //付款方式
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
            this.colRcvdAmount = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colInvAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayoff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentMode = new DevExpress.XtraGrid.Columns.GridColumn();  
            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {  this.colBoundID,  
                        this.colSales, 
                        this.colShipDate, 
                        this.colDueDate, 
                        this.colPoNo,
                        this.colCustomer,
                        this.colQuantity,  
                        this.colInvAmount, 
                        this.colPriceAmount, 
                        this.colCommission,
                        this.colRcvdAmount,
                        this.colPayoff,
                        this.colCommPaid,
                        this.colPaymentMode}; 
            // colBoundID
            // 
            this.colBoundID.Caption = "单据号";
            this.colBoundID.FieldName = "OutboundID";
            this.colBoundID.Name = "colBoundID";
            this.colBoundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBoundID.Visible = false;
            this.colBoundID.Width = 100; 
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
            // colPoNo
            // 
            this.colPoNo.Caption = "P.O#";
            this.colPoNo.FieldName = "OrderNo";
            this.colPoNo.Name = "colPoNo";
            this.colPoNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPoNo.Visible = true;
            this.colPoNo.Width = 120;
            // 
            //colCustomer
            //
            this.colCustomer.Caption = "Receiver";
            this.colCustomer.FieldName = "Receiver";
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
            this.colInvAmount.FieldName = "InvAmt";
            this.colInvAmount.Name = "colInvAmount";
            this.colInvAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colInvAmount.Visible = true;
            this.colInvAmount.Width = 100;
            this.colInvAmount.DisplayFormat.FormatString = "0.0";
            this.colInvAmount.DisplayFormat.FormatType = FormatType.Custom;
            // 
            // colPriceAmount
            // 
            this.colPriceAmount.Caption = "Comm Amt";
            this.colPriceAmount.FieldName = "CommAmt";
            this.colPriceAmount.Name = "colPriceAmount";
            this.colPriceAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colPriceAmount.Visible = true;
            this.colPriceAmount.Width = 100;
            this.colPriceAmount.DisplayFormat.FormatString = "0.0";
            this.colPriceAmount.DisplayFormat.FormatType = FormatType.Custom;
           
            // 
            // Commission
            // 
            this.colCommission.Caption = "Comm";
            this.colCommission.FieldName = "Commission";
            this.colCommission.Name = "colCommission";
            this.colCommission.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCommission.Visible = true;
            this.colCommission.Width = 80;
            this.colCommission.DisplayFormat.FormatString = "0.0";
            this.colCommission.DisplayFormat.FormatType = FormatType.Custom;
            // 
            // colRcvdAmount
            // 
            this.colRcvdAmount.Caption = "Rcvd Amt";
            this.colRcvdAmount.FieldName = "RcvdAmount";
            this.colRcvdAmount.Name = "colRcvdAmount";
            this.colRcvdAmount.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colRcvdAmount.Visible = true;
            this.colRcvdAmount.Width = 80;
            this.colRcvdAmount.DisplayFormat.FormatString = "0.0";
            this.colRcvdAmount.DisplayFormat.FormatType = FormatType.Custom;
            // 
            // colPayoff
            // 
            this.colPayoff.Caption = "Pay Off";
            this.colPayoff.FieldName = "PayOff";
            this.colPayoff.Name = "colPayoff";
            this.colPayoff.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colPayoff.Visible = true;
            this.colPayoff.Width = 70;
            // 
            // colCommStatus
            // 
            this.colCommPaid.Caption = "Comm Paid";
            this.colCommPaid.FieldName = "CommPaid";
            this.colCommPaid.Name = "colCommStatus";
            this.colCommPaid.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colCommPaid.Visible = true;
            this.colCommPaid.Width = 70;
            // 
            // colPaymentMode
            // 
            this.colPaymentMode.Caption = "PAYMENT MODE";
            this.colPaymentMode.FieldName = "PaymentMode";
            this.colPaymentMode.Name = "colPaymentMode";
            this.colPaymentMode.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colPaymentMode.Visible = true;
            this.colPaymentMode.Width = 90;

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

            dataTable = LoadingData();
              
            gridView.GridControl.DataSource = dataTable;

            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;
             
            gridView.EndUpdate();

            WaitingService.EndLoading();
        }

        private DataTable LoadingData()
        {
             
            string sql = string.Format("select OutboundID , OrderNo, Sales, Receiver, ShipDate, DueDate ,PayOff ,CommPaid, CommAmt, Freight , InvAmt, WoAmount ,Quantity,"
                       + " ( CommAmt-WoAmount) as Commission, RcvdAmount, PaymentMode "
                       + " from ({0})  where Sales <> 'NO' AND OrderNo like 'P%'", "V_OutboundUnpaid" );

            if (string.IsNullOrEmpty(BeginDate) == false)
                sql += string.Format(" AND ShipDate >= '{0}'", BeginDate);
            if (string.IsNullOrEmpty(EndDate) == false)
                sql += string.Format("AND ShipDate <= '{0}'", EndDate);

            if (string.IsNullOrEmpty(OutboundFilterSql) == false)
                sql += string.Format(" and {0}", OutboundFilterSql);
              

            sql += " order by Sales asc, ShipDate  asc, OrderNo asc ";
              
             
            DataTable dt = Database.Select(sql);
             
            return dt;
        }

        private string GetVirtualTable()
        {

            string table = " SELECT due.*, rcvd.Amount AS RcvdAmount "
                         + " FROM (SELECT t_cash.outboundID, t_outbound.orderNo, t_outbound.Sales, t_outbound.CustomerNo, t_outbound.SellTo AS Receiver, t_outbound.term, t_outbound.freight, t_outbound.TrackingNo, "
                         + " t_cash.Quantity, (freight+CommAmt) AS InvAmt, t_cash.CommAmt, t_cash.WoAmount, t_outbound.ShipDate, Format(DateAdd('d',term,ShipDate),'yyyy-mm-dd') AS DueDate,"
                         + " t_outbound.Status AS OutboundStatus, t_outbound.OutboundKind AS boundKind, t_outbound.Commission AS CommPaid, t_outbound.PayOff, t_outbound.PaymentMode "
                         + " FROM t_outbound, (SELECT outboundID, sum(numofplan) AS Quantity, sum(numofplan*(funds+addFee)) AS CommAmt, sum(numofplan*(woprice+addFee)) AS WoAmount"
                         + " FROM t_outbounddetail WHERE funds>0 GROUP BY outboundID ORDER BY outboundID)  AS t_cash "
                         + " WHERE (t_outbound.ShipDate<> '' and T_Outbound.Status = '3' and ( PayOff <> 'YES' or PayOff is null ) and t_outbound.outboundID=t_cash.outboundId ))  AS due "
                         + " LEFT JOIN V_OutboundRcvd AS rcvd ON due.outboundID=rcvd.OutboundID ";
                
            return table;
        }


        #endregion

          
    }
     
}
