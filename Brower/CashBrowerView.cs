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
    class CashBrowerView : BaseGridView
    {
        public string OutboundFilterSql  = String.Empty;
        public string BeginDate = string.Empty;
        public string EndDate = string.Empty;

        public CashBrowerView() { }
        public CashBrowerView(GridView view)
        {
            base.SetGridView(view);
        }

        #region Grid Column

        protected DevExpress.XtraGrid.Columns.GridColumn colBoundID; 
        protected DevExpress.XtraGrid.Columns.GridColumn colOrderNo;        //订单号
        protected DevExpress.XtraGrid.Columns.GridColumn colSales;          //销售
        protected DevExpress.XtraGrid.Columns.GridColumn colShipDate;      //发货日期
        protected DevExpress.XtraGrid.Columns.GridColumn colDueDate;        //日期  
        protected DevExpress.XtraGrid.Columns.GridColumn colReceiver;       //顾客
        
        protected DevExpress.XtraGrid.Columns.GridColumn colQuantity;       //数量
        protected DevExpress.XtraGrid.Columns.GridColumn colIvtAmount;      //应收(发票)金额
        protected DevExpress.XtraGrid.Columns.GridColumn colPriceAmt;       //服装金额
        protected DevExpress.XtraGrid.Columns.GridColumn colCommisioin;     //佣金金额
        
        protected DevExpress.XtraGrid.Columns.GridColumn colRcvdAmount;     //实收金额
        protected DevExpress.XtraGrid.Columns.GridColumn colBalance;        //尚欠金额

        protected DevExpress.XtraGrid.Columns.GridColumn colCommPaid;       //佣金已付
        protected DevExpress.XtraGrid.Columns.GridColumn colPayOff;         //付清款项
        
        protected DevExpress.XtraGrid.Columns.GridColumn colPaymentMode;    //付款方式
        protected DevExpress.XtraGrid.Columns.GridColumn colRcvdDate;       //收款时间
        
        protected override void CreateGridColumns()
        {
            this.colBoundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShipDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiver = new DevExpress.XtraGrid.Columns.GridColumn();
            
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIvtAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommisioin = new DevExpress.XtraGrid.Columns.GridColumn();
           
            this.colRcvdAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
           
            this.colPayOff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRcvdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentMode = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] { 
                        this.colBoundID, 
                        this.colSales,
                        this.colShipDate, 
                        this.colDueDate,
                        this.colReceiver, 
                        this.colOrderNo,
                        this.colQuantity,
                        this.colIvtAmount,
                        this.colPriceAmt,
                        this.colCommisioin,
                        this.colRcvdAmount, 
                        this.colRcvdDate,
                        this.colBalance,
                        this.colCommPaid,
                        this.colPayOff,
                        this.colPaymentMode };
            
            // 
            // colBoundID
            // 
            this.colBoundID.Caption = "单据号";
            this.colBoundID.FieldName = "OutboundID";
            this.colBoundID.Name = "colBoundID";
            this.colBoundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBoundID.Visible = false;
            this.colBoundID.Width = 100;
            this.colBoundID.OptionsColumn.AllowMerge = DefaultBoolean.False;
            // 
            // colSales
            // 
            this.colSales.Caption = "Sales";
            this.colSales.FieldName = "Sales";
            this.colSales.Name = "colSales";
            this.colSales.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSales.OptionsColumn.AllowMerge = DefaultBoolean.True;
            this.colSales.Visible = true;
            this.colSales.Width = 120;
            // 
            // colShipDate
            // 
            this.colShipDate.Caption = "Ship Day";
            this.colShipDate.FieldName = "ShipDate";
            this.colShipDate.Name = "colShipDate";
            this.colShipDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShipDate.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colShipDate.Visible = true;
            this.colShipDate.Width = 100;
            // 
            // colDueDate
            // 
            this.colDueDate.Caption = "Due Date";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Name = "colDueDate";
            this.colDueDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDueDate.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colDueDate.Visible = true;
            this.colDueDate.Width = 100; 
            // 
            // colOrderNo
            // 
            this.colOrderNo.Caption = "P.O#";
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOrderNo.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colOrderNo.Visible = true;
            this.colOrderNo.Width = 120; 
            // 
            //colReceiver
            //
            this.colReceiver.Caption = "Receiver";
            this.colReceiver.FieldName = "Receiver";
            this.colReceiver.Name = "colReceiver";
            this.colReceiver.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colReceiver.OptionsColumn.AllowEdit = false;
            this.colReceiver.OptionsColumn.AllowSort = DefaultBoolean.False;
            this.colReceiver.OptionsColumn.AllowMerge = DefaultBoolean.True;
            this.colReceiver.Visible = true;
            this.colReceiver.Width = 150;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Qty";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colQuantity.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colQuantity.Visible = true;
            this.colQuantity.Width = 50;
            // 
            // colIvtAmount
            // 
            this.colIvtAmount.Caption = "Inv Amt";
            this.colIvtAmount.FieldName = "InvoiceAmount";
            this.colIvtAmount.Name = "colIvtAmount";
            this.colIvtAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colIvtAmount.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colIvtAmount.DisplayFormat.FormatString = "0.00";
            this.colIvtAmount.DisplayFormat.FormatType = FormatType.Custom;
            this.colIvtAmount.Visible = true;
            this.colIvtAmount.Width = 80;
            // 
            // colPriceAmt
            // 
            this.colPriceAmt.Caption = "Comm Amt";
            this.colPriceAmt.FieldName = "PriceAmount";
            this.colPriceAmt.Name = "colPriceAmt";
            this.colPriceAmt.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colPriceAmt.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colPriceAmt.DisplayFormat.FormatString = "0.00";
            this.colPriceAmt.DisplayFormat.FormatType = FormatType.Custom;
            this.colPriceAmt.Visible = true;
            this.colIvtAmount.Width = 80;

            // 
            // colCommisioin
            // 
            this.colCommisioin.Caption = "Comm";
            this.colCommisioin.FieldName = "Comm";
            this.colCommisioin.Name = "colCommisioin";
            this.colCommisioin.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colCommisioin.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colCommisioin.DisplayFormat.FormatString = "0.00";
            this.colCommisioin.DisplayFormat.FormatType = FormatType.Custom;
            this.colCommisioin.Visible = true;
            this.colCommisioin.Width = 80;

            // 
            // colRcvdAmount
            // 
            this.colRcvdAmount.Caption = "Rcvd Amt";
            this.colRcvdAmount.FieldName = "RcvdAmount";
            this.colRcvdAmount.Name = "colRcvdAmount";
            this.colRcvdAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colRcvdAmount.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colRcvdAmount.DisplayFormat.FormatString = "0.00";
            this.colRcvdAmount.DisplayFormat.FormatType = FormatType.Custom;
            this.colRcvdAmount.Visible = true;
            this.colRcvdAmount.Width = 80;
            // 
            // colRcvdDate
            // 
            this.colRcvdDate.Caption = "Rcvd Date";
            this.colRcvdDate.FieldName = "RcvdDate";
            this.colRcvdDate.Name = "colRcvdDate";
            this.colRcvdDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colRcvdDate.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colRcvdDate.Visible = true;
            this.colRcvdDate.Width = 100; 
            // 
            // colBalance
            // 
            this.colBalance.Caption = "Balance";
            this.colBalance.FieldName = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colBalance.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colBalance.DisplayFormat.FormatString = "0.00";
            this.colBalance.DisplayFormat.FormatType = FormatType.Custom;
            this.colBalance.Visible = true;
            this.colBalance.Width = 80;

            // 
            //colCommPaid
            //
            this.colCommPaid.Caption = "Comm Paid";
            this.colCommPaid.FieldName = "CommPaid";
            this.colCommPaid.Name = "colCommPaid";
            this.colCommPaid.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colCommPaid.OptionsColumn.AllowEdit = false;
            this.colCommPaid.OptionsColumn.AllowSort = DefaultBoolean.False;
            this.colCommPaid.OptionsColumn.AllowMerge = DefaultBoolean.True;
            this.colCommPaid.Visible = true;
            this.colCommPaid.Width = 70;
            // 
            // colPayOff
            // 
            this.colPayOff.Caption = "Pay Off";
            this.colPayOff.FieldName = "PayOff";
            this.colPayOff.Name = "colPayOff";
            this.colPayOff.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPayOff.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colPayOff.Visible = true;
            this.colPayOff.Width = 70;
            // 
            // colPaymentMode
            // 
            this.colPaymentMode.Caption = "PAYMENT MODE";
            this.colPaymentMode.FieldName = "PaymentMode";
            this.colPaymentMode.Name = "colPaymentMode";
            this.colPaymentMode.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPaymentMode.OptionsColumn.AllowMerge = DefaultBoolean.False;
            this.colPaymentMode.Visible = true;
            this.colPaymentMode.Width = 90;
        }
       
        #endregion

        #region 视图初始化

        protected override void InitGridView()
        {
            gridView.BeginInit();

            base.InitGridView();

            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsBehavior.Editable = false;           //是否允许用户编辑单元格
            gridView.OptionsCustomization.AllowColumnMoving = false;
            gridView.IndicatorWidth = 30;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;

            //单元格合并
            //gridView.OptionsView.AllowCellMerge = true;

            gridView.EndInit();

            gridView.RowCellStyle += new RowCellStyleEventHandler(OnRowCellStyle);
            //gridView.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.GridView_CellMerge);
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
             
            dataTable = LoadingOutboundCash();
              
            gridView.GridControl.DataSource = dataTable;

            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;
             
            gridView.EndUpdate();

            WaitingService.EndLoading();
        }

        private DataTable LoadingOutboundCash()
        {
            string sql = string.Format("select OutboundID, Sales,ShipDate, DueDate, OrderNo, Receiver, Quantity, InvoiceAmount, PriceAmount, Comm, "
              + " RcvdAmount, (InvoiceAmount-RcvdAmount) AS Balance ,PayOff,CommPaid, PaymentMode,RcvdDate  "
              + " from ( {0} ) as TempTable ", GetTableSql());

            sql += " order by Sales asc, CustomerNo asc , OrderNo asc ";


            DataTable dt = Database.Select(sql);
            int cnt = dt.Rows.Count;
            Dictionary<string, string> map = GetRcvdDateMap();
            string id = null;
            for (int i = 0; i < cnt; i++)
            {
                id = dt.Rows[i][0].ToString();

                if (map.ContainsKey(id) == true)
                    dt.Rows[i]["RcvdDate"] = map[id];
            }

            map.Clear();

            return dt;
        }

        private string GetTableSql()
        {
            string sql = string.Format(" SELECT due.* , rcvd.RcvdAmt AS RcvdAmount, ' ' as RcvdDate "
                +" FROM ({0}) AS due, ({1}) AS rcvd  WHERE due.outboundID=rcvd.OutboundID ",
                GetDueTableSql(), GetRecivedAmountTableSql());

            return sql;
        }

        private string GetDueTableSql()
        {
            string sql = string.Format(" SELECT outbound.*, cash.Quantity, PriceAmount, WoAmount , (PriceAmount + Freight) As InvoiceAmount , (PriceAmount - WoAmount) as Comm "
                       + " From ({0}) AS outbound , ({1}) AS cash  WHERE outbound.OutboundID = cash.OutboundID and PriceAmount >0.0 and WoAmount > 0.0 ",
                       GetOutboundTableSql() ,
                       GetCashTableSql() );
            return sql;

        }

        private string GetOutboundTableSql()
        {
            string sql = "SELECT OutboundID, OrderNo, Sales, CustomerNo, SellTo AS Receiver, Term, Freight, TrackingNo,ShipDate, "
                       + " Format(DateAdd('d',Term,ShipDate),'yyyy-mm-dd') AS DueDate,Status AS OutboundStatus, OutboundKind, "
                       + " Commission AS CommPaid, t_outbound.PayOff, PaymentMode FROM t_outbound "
                       + " WHERE  (Sales <> 'NO' and Sales<>'' ) and ShipDate > '' "
                       + " AND (CustomerNo = '001' OR CustomerNo = '004' OR CustomerNo like'JF%')" ;
            if (string.IsNullOrEmpty(OutboundFilterSql) == false)
                sql += string.Format(" and {0}", OutboundFilterSql);
            return sql;

        }

        private string GetRecivedAmountTableSql()
        {
            string sql = "SELECT OutboundID, sum(RcvdAmount) AS RcvdAmt FROM T_RcvdRecord WHERE 1=1 ";

            if (string.IsNullOrEmpty(BeginDate) == false)
                sql += string.Format("AND DecmDate >= '{0}' ", BeginDate);

            if (string.IsNullOrEmpty(EndDate) == false)
                sql += string.Format("AND DecmDate <= '{0}' ", EndDate);
           
            sql += " GROUP BY OutboundID ";

            return sql;
        }

        private string GetCashTableSql()
        {
            string sql = "SELECT outboundID, sum(numofplan) AS Quantity, sum(numofplan*(funds+addfee)) AS PriceAmount, "
             + " sum(numofplan*(woprice+AddFee)) AS WoAmount FROM t_outbounddetail "
             + "WHERE funds>0 And numofplan>0 "
             +" GROUP BY outboundID ORDER BY outboundID  ";
        
             return sql;
        }

        private Dictionary<string, string> GetRcvdDateMap()
        {
            Dictionary<string, string>  map = new Dictionary<string, string>();
            string sql = "SELECT OutboundID, max( RcvdDate) as MaxRcvdDate FROM T_RcvdRecord  , T_RcvdAmount "
                       + "WHERE T_RcvdRecord.RcvdRecdID = T_RcvdAmount.SerialNo GROUP BY OutboundID ";

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return map;
            int cnt = dt.Rows.Count;
            
            for (int i = 0; i < cnt; i++)
            {
                map.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString() );
            }
            dt.Clear();
            return map;
        }
        
        #endregion

        #region 字体颜色

        public void OnRowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            object obj = null;
            int rowHandle = e.RowHandle;

            if (e.Column == colBalance)
            {
                obj = e.CellValue;

                //RcvdAmount
                if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                    return;
                double dif = Convert.ToDouble(e.CellValue);
                Color color = Color.Black;
                if (dif > 0.001)
                    color = Color.Red;
                e.Appearance.ForeColor = color;
                 
            }

            #region  实际收款列

            if (e.Column == colRcvdAmount)
            { 
                obj = e.CellValue;

                //RcvdAmount
                if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                    return;

                obj = dataTable.Rows[rowHandle]["InvoiceAmount"];
                if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                    return;
                double fdue = Convert.ToDouble(obj);
                if (fdue <= 0.001)
                    return;
                double dif = Convert.ToDouble(e.CellValue) - fdue;

                Color color = Color.Black;
                if (dif <= -0.001)
                    color = Color.Red;
                e.Appearance.ForeColor = color;
            }
            #endregion

        }

        #endregion
        
        //单元格合并
        private void GridView_CellMerge(object sender, CellMergeEventArgs e)
        {
            //if (e.Column.FieldName == "Sales")
            //{
                GridView view = sender as GridView;
                string val1 = view.GetRowCellValue(e.RowHandle1, e.Column).ToString();
                string val2 = view.GetRowCellValue(e.RowHandle2, e.Column).ToString();

                e.Merge = (val1 == val2);
                e.Handled = true;
            //}
            //else if (e.Column.FieldName == "CustomerNo")
            //{
            //    GridView view = sender as GridView;
            //    string val1 = view.GetRowCellValue(e.RowHandle1, "CustomerNo").ToString();
            //    string val2 = view.GetRowCellValue(e.RowHandle2, "CustomerNo").ToString();

            //    e.Merge = (val1 == val2);
            //    e.Handled = true;
            //}
            
        }


    }
}
