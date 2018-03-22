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
    public class BackBound
    {
        public string BackboundID="";
        public string PONo="";
        public string OrderDate="";
        public string CreateTime="";
        public string Sales="";
        public string Customer="";
        public string Status="";
        public string Memo="";

    }

    public  class ReturnMasterView : BaseGridView
    {
        public string KeyWords = String.Empty;

        public ReturnMasterView()
        {
            this.LoadData = this.LoadBackbound;
        }

        public ReturnMasterView(GridView view)
        {
            base.SetGridView(view);
            this.LoadData = this.LoadBackbound;
        }

        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colBackboundID;
        protected DevExpress.XtraGrid.Columns.GridColumn colPONo;  
        protected DevExpress.XtraGrid.Columns.GridColumn colBackDate;
        protected DevExpress.XtraGrid.Columns.GridColumn colSales;
        protected DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        protected DevExpress.XtraGrid.Columns.GridColumn colStatus;
        protected DevExpress.XtraGrid.Columns.GridColumn colRemark; 
        #endregion

        #region 视图初始化

        protected override void CreateGridColumns()
        {
            this.colBackboundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBackDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colBackboundID,
                        this.colPONo,
                        this.colBackDate,
                        this.colSales,
                        this.colCustomer,
                        this.colStatus ,
                        this.colRemark
            };

            // 
            // colBackboundID
            // 
            this.colBackboundID.Caption = "入库单号";
            this.colBackboundID.FieldName = "BackboundID";
            this.colBackboundID.Name = "colBackboundID";
            this.colBackboundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBackboundID.Visible = false;
            this.colBackboundID.Width = 100;
            // 
            // colPONo
            // 
            this.colPONo.Caption = "P.O#";//"发货单号";
            this.colPONo.FieldName = "PONo";
            this.colPONo.Name = "colPONo";
            this.colPONo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPONo.Visible = true;
            this.colPONo.Width = 120;
             
            // 
            // colBackDate
            // 
            this.colBackDate.Caption = "Date";//"退货日期";
            this.colBackDate.FieldName = "BackDate";
            this.colBackDate.Name = "colBackDate";
            this.colBackDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBackDate.Visible = true;
            this.colBackDate.Width = 80;
            // 
            // colSales
            // 
            this.colSales.Caption = "Sales";// "销售";
            this.colSales.FieldName = "Sales";
            this.colSales.Name = "colSales";
            this.colSales.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSales.Visible = true;
            this.colSales.Width = 100;
            // 
            // colCustomer
            // 
            this.colCustomer.Caption = "Customer";// "顾客";
            this.colCustomer.FieldName = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCustomer.Visible = true;
            this.colCustomer.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";//"完成状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStatus.Visible = true;
            this.colStatus.Width = 60;

            // 
            // colRemark
            // 
            this.colRemark.Caption = "Memo";//备注
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colRemark.Visible = true;
            this.colRemark.Width = 200;
             
        }

        protected override void InitGridView()
        {
            base.InitGridView();
            gridView.OptionsBehavior.Editable = false;  
        }

        #endregion

        public void LoadBackbound()
        {

            string sql = "Select BackboundID, PONo,BackDate, Sales,Customer, Status ,Remark From T_Backbound ";

            if (String.IsNullOrEmpty(KeyWords) == false )
            {
               sql += KeyWords ;
            }
            sql += " Order by BackDate desc ";

            dataTable = Database.Select(sql);

        }

        public override void Loading()
        {
          
            if (gridView == null)
                return;

            WaitingService.BeginLoading();
            dataTable.Rows.Clear();

            if (LoadData != null)
                LoadData();

            //gridView.BeginUpdate();

            //gridView.BeginDataUpdate();

            gridView.GridControl.DataSource = dataTable;

           // gridView.EndDataUpdate();

            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;

            //gridView.EndUpdate();

            WaitingService.EndLoading();
        }
         
        public void InsertBackbound(int pos, BackBound bound)
        {
            DataRow dr = dataTable.NewRow();
            dr["BackboundID"] = bound.BackboundID;
            dr["PONo"] = bound.PONo;
            dr["BackDate"] = bound.OrderDate;
            dr["Sales"] = bound.Sales;
            dr["Customer"] = bound.Customer;
            dr["Status"] = bound.Status ;
            dr["Remark"] = bound.Memo;
            dataTable.Rows.InsertAt(dr, pos);
        }
    }
}
