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
    public class OutBound
    {
        public string OutboundID;
        public string OrderNo;          //P.O#
        public string Sales;             
        public string CustomerNo;        
        public string InvoiceStatus;
        public string CreateTime;
        public string Operator;
        public string Status;
        public string ShipDate;     
        public string ShipTo;
        public string SellTo;        
        public string Term;
        public string Shippingway;
        public string Freight;      //运费
        public string ConfirmTime;
        public int    OutBoundKind;
        public string PaymentMode;  //付款方式
        public string Commission;   //佣金
        public string Address;      //发货地址    
        public string TrackingNo;   //快递单号
        public string ShipBy;       //快递商

        public string ShipAddress
        {
            get {
                return Address;
            }
        }
    }

    public class OutboundMasterView : BaseGridView
    {
        public string FilterSql = String.Empty;

        public OutboundMasterView() 
        {
            this.LoadData = this.LoadOutbound;
        }
        
        public OutboundMasterView(GridView view)
        {
            base.SetGridView(view);
            this.LoadData = this.LoadOutbound;
        }
     
        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colOutboundID;
        protected DevExpress.XtraGrid.Columns.GridColumn colOrderNo;//订单号
        protected DevExpress.XtraGrid.Columns.GridColumn colShipDate;
        protected DevExpress.XtraGrid.Columns.GridColumn colSales;
        protected DevExpress.XtraGrid.Columns.GridColumn colCustomerNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colOperator;
        protected DevExpress.XtraGrid.Columns.GridColumn colShipTo;
        protected DevExpress.XtraGrid.Columns.GridColumn colSellTo;
        protected DevExpress.XtraGrid.Columns.GridColumn colShippingway;
        protected DevExpress.XtraGrid.Columns.GridColumn colTerm;
        protected DevExpress.XtraGrid.Columns.GridColumn colFreight;       //运费
        protected DevExpress.XtraGrid.Columns.GridColumn colInvoiceStatus; //发票状态
        protected DevExpress.XtraGrid.Columns.GridColumn colStatus;
        protected DevExpress.XtraGrid.Columns.GridColumn colOutboundKind;

        protected DevExpress.XtraGrid.Columns.GridColumn colAddress; 
        protected DevExpress.XtraGrid.Columns.GridColumn colCommission; 
        protected DevExpress.XtraGrid.Columns.GridColumn colTrackingNo; 
        protected DevExpress.XtraGrid.Columns.GridColumn colShipBy;
        protected DevExpress.XtraGrid.Columns.GridColumn colPaymentMode;

        #endregion

        public  void Loading(int limit)
        {
            if (gridView == null)
                return;
            WaitingService.BeginLoading();
            if (dataTable != null)
                dataTable.Rows.Clear();
            LoadOutbound(limit);

            AddDataRows(dataTable);

            gridView.BeginUpdate();
            gridView.BeginDataUpdate();

            gridView.GridControl.DataSource = dataTable;

            gridView.EndDataUpdate();

            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;

            gridView.EndUpdate();

            WaitingService.EndLoading();
        }

        protected override void CreateGridColumns()
        {
            this.colOutboundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShipDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperator = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colShipTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShippingway = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTerm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutboundKind = new DevExpress.XtraGrid.Columns.GridColumn();

            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrackingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShipBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentMode = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colOutboundID,
                        this.colOrderNo,
                        this.colShipDate,
                        this.colSales, 
                        this.colCustomerNo, 
                        this.colPaymentMode,
                        this.colSellTo,
                        this.colAddress,
                        this.colTrackingNo,
                        this.colShipBy,
                        this.colShipTo,
                        this.colShippingway,
                        this.colTerm,
                        this.colFreight,
                        this.colOutboundKind,
                        this.colInvoiceStatus, 
                        this.colOperator,
                        this.colStatus,
                        this.colCommission
            };

            // 
            // colOutboundID
            // 
            this.colOutboundID.Caption = "出库单号";
            this.colOutboundID.FieldName = "OutboundID";
            this.colOutboundID.Name = "colOutboundID";
            this.colOutboundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOutboundID.Visible = false;
            this.colOutboundID.Width = 100; 
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
            // colShipDate
            // 
            this.colShipDate.Caption = "Ship Date";
            this.colShipDate.FieldName = "ShipDate";
            this.colShipDate.Name = "colShipDate";
            this.colShipDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShipDate.Visible = true;
            this.colShipDate.Width = 100; 
            // 
            // colSales
            // 
            this.colSales.Caption = "Sales";
            this.colSales.FieldName = "Sales";
            this.colSales.Name = "colSales";
            this.colSales.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSales.Visible = true;
            this.colSales.Width = 80;
            // 
            // colCustomerNo
            // 
            this.colCustomerNo.Caption = "Customer#";
            this.colCustomerNo.FieldName = "CustomerNo";
            this.colCustomerNo.Name = "colCustomerNo";
            this.colCustomerNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCustomerNo.Visible = true;
            this.colCustomerNo.Width = 100;
            // 
            // colCommission
            // 
            this.colCommission.Caption = "Commission";
            this.colCommission.FieldName = "Commission";
            this.colCommission.Name = "colCommission";
            this.colCommission.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCommission.Visible = true;
            this.colCommission.Width = 90; 
            // 
            // colSellTo
            // 
            this.colSellTo.Caption = "Sell To";
            this.colSellTo.FieldName = "SellTo";
            this.colSellTo.Name = "colSellTo";
            this.colSellTo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSellTo.Visible = true;
            this.colSellTo.Width = 100;
            // 
            // colAddress
            // 
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colAddress.Visible = false;
            this.colAddress.Width = 120;
            // 
            // colTrackingNo
            // 
            this.colTrackingNo.Caption = "Tracking#";
            this.colTrackingNo.FieldName = "TrackingNo";
            this.colTrackingNo.Name = "colTrackingNo";
            this.colTrackingNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTrackingNo.Visible = true;
            this.colTrackingNo.Width = 80;
            // 
            // colShipBy
            // 
            this.colShipBy.Caption = "Ship By";
            this.colShipBy.FieldName = "ShipBy";
            this.colShipBy.Name = "colShipBy";
            this.colShipBy.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShipBy.Visible = false;
            this.colShipBy.Width = 80;
            // 
            // colShipTo
            // 
            this.colShipTo.Caption = "Ship To";
            this.colShipTo.FieldName = "ShipTo";
            this.colShipTo.Name = "colShipTo";
            this.colShipTo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShipTo.Visible = true;
            this.colShipTo.Width = 120;
            // 
            // colShippway
            // 
            this.colShippingway.Caption = "Shipping way";
            this.colShippingway.FieldName = "Shippingway";
            this.colShippingway.Name = "colShippingway";
            this.colShippingway.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShippingway.Visible = false; 
            this.colShippingway.Width = 100; 
            // 
            // colTerm
            // 
            this.colTerm.Caption = "Term";
            this.colTerm.FieldName = "Term";
            this.colTerm.Name = "colTerm";
            this.colTerm.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTerm.Visible = false;
            this.colTerm.Width = 70;
            // 
            // colFreight
            // 
            this.colFreight.Caption = "Shipping";
            this.colFreight.FieldName = "Freight";
            this.colFreight.Name = "colFreight";
            this.colFreight.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colFreight.Visible = true;
            this.colFreight.Width = 90;
            // 
            // colOperator
            // 
            this.colOperator.Caption = "Operator";
            this.colOperator.FieldName = "Operator";
            this.colOperator.Name = "colOperator";
            this.colOperator.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOperator.Visible = false;
            this.colOperator.Width = 80;
            // 
            // colInvoiceStatus
            // 
            this.colInvoiceStatus.Caption = "Invoice";//发票状态
            this.colInvoiceStatus.FieldName = "InvoiceStatus";
            this.colInvoiceStatus.Name = "colInvoiceStatus";
            this.colInvoiceStatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colInvoiceStatus.Visible = false;
            this.colInvoiceStatus.Width = 7;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";//完成状态
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStatus.Visible = true;
            this.colStatus.Width = 70;
            // 
            // colOutboundKind
            // 
            this.colOutboundKind.Caption = "Category";//出库类型
            this.colOutboundKind.FieldName = "OutboundKind";
            this.colOutboundKind.Name = "colOutboundKind";
            this.colOutboundKind.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOutboundKind.Visible = true;
            this.colOutboundKind.Width = 100;
            // 
            // colPaymentMode
            // 
            this.colPaymentMode.Caption = "Payment";//付款方式
            this.colPaymentMode.FieldName = "PaymentMode";
            this.colPaymentMode.Name = "colPaymentMode";
            this.colPaymentMode.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPaymentMode.Visible = true;
            this.colPaymentMode.Width = 70;
        }
       
        protected override void InitGridView()
        {
            base.InitGridView();
            gridView.OptionsBehavior.Editable = false; 
            this.gridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.outboundView_CustomDrawCell);
            this.gridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.outboundView_RowStyle);
        }
        
        public void LoadOutbound()
        {

            string sql = "Select OutboundID,OrderNo, ShipDate, Sales,CustomerNo, Commission, Address , TrackingNo, ShipBy, Operator, "
             + " ShipTo, SellTo, Shippingway, Term, Freight, InvoiceStatus, Status, OutboundKind ,CreateTime, PaymentMode  From T_Outbound ";

            if (String.IsNullOrEmpty(FilterSql) == false)
            {
                sql += FilterSql;
            }
            sql += " Order by Status asc, ShipDate desc , CreateTime desc ";

            DataTable dt = Database.Select(sql);

            DataSource = dt;
        }

        public void LoadOutbound(int limit)
        {
            string sql =  "Select OutboundID,OrderNo, ShipDate, Sales,CustomerNo, Commission, Address , TrackingNo, ShipBy, Operator, "
            + " ShipTo, SellTo, Shippingway, Term, Freight, InvoiceStatus, Status, OutboundKind ,CreateTime, PaymentMode  From T_Outbound ";
           
            if (String.IsNullOrEmpty(FilterSql) == false)
            {
                sql += FilterSql;
            }
            
            sql += " Order by Status asc, ShipDate desc , CreateTime desc ";
            sql += string.Format("Limit {0} ", limit);

            DataTable dt = Database.Select(sql);

            DataSource = dt;
        }
       
        public void InsertOutbound(int pos,OutBound bound)
        {
            if (pos < 0 || bound == null)
                return;

            DataRow dr = dataTable.NewRow();
            dr["OutboundID"] = bound.OutboundID ;
            dr["OrderNo"] = bound.OrderNo ;
            dr["ShipDate"] = bound.ShipDate;
            dr["Sales"] = bound.Sales;
            dr["Commission"] = bound.Commission;
            dr["CustomerNo"] = bound.CustomerNo;
            dr["SellTo"] = bound.SellTo;
            dr["Address"] = bound.Address;
            dr["TrackingNo"] = bound.TrackingNo;
            dr["ShipBy"] = bound.ShipBy;

            dr["ShipTo"] = bound.ShipTo;
            dr["Shippingway"] = bound.Shippingway;
            dr["Term"] = bound.Term;
            dr["Freight"] = bound.Freight;

            dr["Operator"] = bound.Operator;
            dr["InvoiceStatus"] = bound.InvoiceStatus ;
            dr["Status"] = bound.Status ;
            dr["OutboundKind"] = bound.OutBoundKind.ToString();

            dr["PaymentMode"] = bound.PaymentMode;

            dataTable.Rows.InsertAt(dr, pos);
            gridView.FocusedRowHandle = pos;

        }

        private string GetStatusCaption(string no)
        {
            if (no == DealStatus.PreSell)
                return "预售";
            if (no == DealStatus.Outbound)
                return "正在出库";
            if( no == DealStatus.Finish)
                return "完成";

            return "";
        }

        private void outboundView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (gridView.GetRowCellValue(e.RowHandle, "Status") == null)
                return;

            string status = gridView.GetRowCellValue(e.RowHandle, "Status").ToString();

            if (status == DealStatus.PreSell)
                e.Appearance.ForeColor = Color.Red;
            else if (status == DealStatus.Outbound)
                e.Appearance.ForeColor = Color.Blue;
            else if (status == DealStatus.Finish)
                e.Appearance.ForeColor = Color.Black;
        }

        private void outboundView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                e.DisplayText = GetStatusCaption(e.CellValue.ToString());
            }
            else if (e.Column.FieldName == "InvoiceStatus")
            {
                if (e.CellValue.ToString() == "1")
                    e.DisplayText = "printed";
                else
                    e.DisplayText = "";
            }
            else if (e.Column.FieldName == "OutboundKind")
            {
                if (e.CellValue.ToString() == MemoryTable.Outbound_Kind_99T.ToString())
                    e.DisplayText = "Ship To FBA";
                else if (e.CellValue.ToString() == MemoryTable.Outbound_Kind_FBA.ToString())
                    e.DisplayText = "FBA Sold";
                else if (e.CellValue.ToString() == MemoryTable.Outbound_Kind_Gel.ToString())
                    e.DisplayText = "SOLD TO BUYER";
                else if (e.CellValue.ToString() == MemoryTable.Outbound_Kind_Amazon.ToString())
                    e.DisplayText = "AMAZON";
                else if (e.CellValue.ToString() == MemoryTable.Outbound_Kind_Amazon.ToString())
                    e.DisplayText = "SAMPLE";
            }
        }

    }
}
