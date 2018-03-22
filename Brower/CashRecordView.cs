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
    public class CashRecordView : BaseGridView
    {
        public string OutboundID = string.Empty;

        public CashRecordView() { }
        public CashRecordView(GridView view)
        {
            base.SetGridView(view);
        }
        
        #region Grid Column
        protected DevExpress.XtraGrid.Columns.GridColumn colRecordID;
        protected DevExpress.XtraGrid.Columns.GridColumn colBoundID;
        protected DevExpress.XtraGrid.Columns.GridColumn colOrderNo;        //订单号  
        protected DevExpress.XtraGrid.Columns.GridColumn colRcvdAmount;     //收款金额 
        protected DevExpress.XtraGrid.Columns.GridColumn colInvtAmount;     //发票金额 
        protected DevExpress.XtraGrid.Columns.GridColumn colRemark;
        protected DevExpress.XtraGrid.Columns.GridColumn colDecmDate;       //落款日期
        protected DevExpress.XtraGrid.Columns.GridColumn colSales;
        protected DevExpress.XtraGrid.Columns.GridColumn colPayOff;

        protected override void CreateGridColumns()
        {
            this.colRecordID = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colBoundID = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRcvdAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvtAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDecmDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayOff = new DevExpress.XtraGrid.Columns.GridColumn(); 
            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] { 
                        this.colRecordID,
                        this.colBoundID,
                        this.colSales,
                        this.colOrderNo,
                        this.colRcvdAmount,
                        this.colInvtAmount,
                        this.colDecmDate,
                        this.colPayOff,
                        this.colRemark  };
            // 
            // colRecordID
            // 
            this.colRecordID.Caption = "记录号";
            this.colRecordID.FieldName = "RecordID";
            this.colRecordID.Name = "colRecordID";
            this.colRecordID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colRecordID.Visible = false;
            this.colRecordID.Width = 100;
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
            // colOrderNo
            // 
            this.colOrderNo.Caption = "P.O#";
            this.colOrderNo.FieldName = "OutboundNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOrderNo.Visible = true;
            this.colOrderNo.Width = 120;
            
            // 
            //colRcvdAmount
            //
            this.colRcvdAmount.Caption = " Rcvd Amt ";
            this.colRcvdAmount.FieldName = "RcvdAmount";
            this.colRcvdAmount.Name = "colRcvdAmount";
            this.colRcvdAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colRcvdAmount.OptionsColumn.AllowEdit = false;
            this.colRcvdAmount.OptionsColumn.AllowSort = DefaultBoolean.False;
            this.colRcvdAmount.DisplayFormat.FormatString = "0.00";
            this.colRcvdAmount.DisplayFormat.FormatType = FormatType.Custom;
            this.colRcvdAmount.Visible = true;
            this.colRcvdAmount.Width = 80;
            // 
            //colInvtAmount
            //
            this.colInvtAmount.Caption = " Inv Amt ";
            this.colInvtAmount.FieldName = "InvoiceAmount";
            this.colInvtAmount.Name = "colInvtAmount";
            this.colInvtAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colInvtAmount.OptionsColumn.AllowEdit = false;
            this.colInvtAmount.OptionsColumn.AllowSort = DefaultBoolean.False;
            this.colInvtAmount.DisplayFormat.FormatString = "0.00";
            this.colInvtAmount.DisplayFormat.FormatType = FormatType.Custom;
            this.colInvtAmount.Visible = true;
            this.colInvtAmount.Width = 80;

            // 
            //colDecmDate
            //
            this.colDecmDate.Caption = "Date";
            this.colDecmDate.FieldName = "DecmDate";
            this.colDecmDate.Name = "colDecmDate";
            this.colDecmDate.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colDecmDate.OptionsColumn.AllowEdit = false;
            this.colDecmDate.OptionsColumn.AllowSort = DefaultBoolean.False;
            this.colDecmDate.Visible = true;
            this.colDecmDate.Width = 80;
            // 
            // colSales
            // 
            this.colSales.Caption = "Sales";
            this.colSales.FieldName = "Sales";
            this.colSales.Name = "colSales";
            this.colSales.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSales.Visible = true;
            
            // 
            // colPayOff
            // 
            this.colPayOff.Caption = "Pay Off";
            this.colPayOff.FieldName = "PayOff";
            this.colPayOff.Name = "colPayOff";
            this.colPayOff.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPayOff.Visible = true;
            this.colPayOff.Width = 120;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "Remark";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colRemark.Visible = true;
            this.colRemark.Width = 120;
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
            dataTable = base.GetDataSource();
            return dataTable;
        }

        #endregion

        #region 加载数据

        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }

        public void LoadOutboundRcvdRecord()
        {
            ClearRows();

            if (gridView == null)
                return;

            WaitingService.BeginLoading();

            gridView.BeginUpdate();

            dataTable = LoadingRcvtRecord();

            gridView.GridControl.DataSource = dataTable;

            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;

            gridView.EndUpdate();

            WaitingService.EndLoading();
        }

        private DataTable LoadingRcvtRecord()
        {
            if (string.IsNullOrEmpty(OutboundID))
            {
                ClearRows();
                return dataTable;
            }

            string sql = "select OutboundID ,Sales, OutboundNo, RecordID, RcvdAmount,InvoiceAmount, DecmDate,Remark, PayOff  from V_RcvdRecord ";

            if (string.IsNullOrEmpty(OutboundID) == false)
                sql += string.Format(" where OutboundID = '{0}'", OutboundID); 
           // sql += " order by RcvdDate asc ";

            DataTable dt = Database.Select(sql);

            return dt;
        }

        public void LoadCashRcvdRecord(string rcvdID)
        {

            ClearRows();

            if (gridView == null)
                return;

            WaitingService.BeginLoading();

            gridView.BeginUpdate();

            dataTable = LoadingRcvtRecordEx(rcvdID);

            gridView.GridControl.DataSource = dataTable;

            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;

            gridView.EndUpdate();

            WaitingService.EndLoading();
        }

        private DataTable LoadingRcvtRecordEx(string rcvdID)
        { 
            if (string.IsNullOrEmpty(rcvdID))
            {
                ClearRows();
                return dataTable;
            }

            string sql = "select OutboundID ,Sales, OutboundNo, RecordID, RcvdAmount,InvoiceAmount, DecmDate,Remark, PayOff  from V_RcvdRecord ";
            sql += string.Format(" where RcvdRecdID = '{0}'", rcvdID );
            sql += " order by DecmDate desc ";

            DataTable dt = Database.Select(sql);

            return dt;
        }


        #endregion
  
    }
}
