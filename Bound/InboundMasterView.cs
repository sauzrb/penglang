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
    public class InBound
    {
        public string InboundID;
        public string ProductNo;
        public string OrderDate;
        public string CreateTime;
        public string Operator;
        public string Status; 
    }

    public  class InboundMasterView : BaseGridView
    {
        public string KeyWords = String.Empty;

        public InboundMasterView()
        {
            this.LoadData = this.LoadInbound;
        }

        public InboundMasterView(GridView view)
        {
            base.SetGridView(view);
            this.LoadData = this.LoadInbound;
        }

        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colInboundID;
        protected DevExpress.XtraGrid.Columns.GridColumn colProductNo;//进货订单号 
        protected DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        protected DevExpress.XtraGrid.Columns.GridColumn colOperator;
        protected DevExpress.XtraGrid.Columns.GridColumn colStatus; 

        #endregion

        protected override void CreateGridColumns()
        {
            this.colInboundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn(); 

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colInboundID,
                        this.colProductNo,
                        this.colOrderDate,
                        this.colOperator, 
                        this.colStatus  
            };

            // 
            // colInboundID
            // 
            this.colInboundID.Caption = "入库单号";
            this.colInboundID.FieldName = "InboundID";
            this.colInboundID.Name = "colInboundID";
            this.colInboundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colInboundID.Visible = false;
            this.colInboundID.Width = 100;
            // 
            // colProductNo
            // 
            this.colProductNo.Caption = "Order#";//"发货单号";
            this.colProductNo.FieldName = "ProductNo";
            this.colProductNo.Name = "colProductNo";
            this.colProductNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colProductNo.Visible = true;
            this.colProductNo.Width = 120;
             
            // 
            // colOrderDate
            // 
            this.colOrderDate.Caption = "Date";//"产生日期";
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOrderDate.Visible = true;
            this.colOrderDate.Width = 100;
            // 
            // colOperator
            // 
            this.colOperator.Caption = "Operator";// "操作人员";
            this.colOperator.FieldName = "Operator";
            this.colOperator.Name = "colOperator";
            this.colOperator.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOperator.Visible = true;
            this.colOperator.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";//"完成状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStatus.Visible = true;
            this.colStatus.Width = 100;
           
        }

        protected override void InitGridView()
        {
            base.InitGridView();
            gridView.OptionsBehavior.Editable = false;

            this.gridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.inboundView_CustomDrawCell);
            this.gridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.inboundView_RowStyle);
        }
        
        private string GetStatusCaption(string no)
        {
            if (no == DealStatus.PreInput)
                return "准备入库";
            if (no == DealStatus.Inbound)
                return "正在入库";
            if (no == DealStatus.Finish)
                return "完成";
            return "";
        }
         
        private void inboundView_RowStyle(object sender, RowStyleEventArgs e)
        {
            Object obj = null;
            obj = gridView.GetRowCellValue(e.RowHandle, "Status");
            if (obj == null)
            {
                return;
            }

            string status = obj.ToString();

            if ( status  == DealStatus.Finish)
                e.Appearance.ForeColor = Color.Black;
            else if( status == DealStatus.PreInput)
                e.Appearance.ForeColor = Color.Red;
            else if (status == DealStatus.Inbound)
                e.Appearance.ForeColor = Color.Blue;
 
        }

        private void inboundView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                e.DisplayText = GetStatusCaption(e.CellValue.ToString());
            }
            
        }
        
        public void LoadInbound()
        {

            string sql = "Select InboundID, ProductNo,OrderDate, Operator, Status, CreateTime From T_Inbound ";

            if (String.IsNullOrEmpty(KeyWords) == false )
            {
               sql += KeyWords ;
            }
            sql += " Order by Status asc , CreateTime desc ";

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
         
        public void InsertInbound(int pos, InBound inbound)
        {
            DataRow dr = dataTable.NewRow();
            dr["InboundID"] = inbound.InboundID;
            dr["ProductNo"] = inbound.ProductNo;
            dr["OrderDate"] = inbound.OrderDate;
            dr["Operator"] = inbound.Operator;
            dr["Status"] = inbound.Status ; 
            dataTable.Rows.InsertAt(dr, pos);
        }
    }
}
