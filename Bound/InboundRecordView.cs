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
    public class InboundRecordView : BaseGridView
    { 

        #region 表格初始化

        public string InboundID = String.Empty;
        public InboundRecordView() { }
        public InboundRecordView(GridView view)
        {
            base.SetGridView(view);
        }

        #region Grid Column

        protected DevExpress.XtraGrid.Columns.GridColumn colRecordID;
        protected DevExpress.XtraGrid.Columns.GridColumn colInboundID;
        protected DevExpress.XtraGrid.Columns.GridColumn colDetailID; 
        protected DevExpress.XtraGrid.Columns.GridColumn colShelfNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colSizeNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colNumofPlan;
        protected DevExpress.XtraGrid.Columns.GridColumn colNumofReal;
        protected DevExpress.XtraGrid.Columns.GridColumn colDealUser;
        protected DevExpress.XtraGrid.Columns.GridColumn colPlanDateTime;
        protected DevExpress.XtraGrid.Columns.GridColumn colDealDatetime;
        protected DevExpress.XtraGrid.Columns.GridColumn colDealStatus;
        protected DevExpress.XtraGrid.Columns.GridColumn colCheck;

        #endregion
         
        protected override void CreateGridColumns()
        {
            this.colRecordID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInboundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSizeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumofPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumofReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealDatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colCheck,
                        this.colRecordID,
                        this.colInboundID,
                        this.colDetailID, 
                        this.colShelfNo,
                        this.colLotNo,
                        this.colSizeNo,
                        this.colNumofPlan,
                        this.colNumofReal,
                        this.colDealUser,
                        this.colPlanDateTime,
                        this.colDealDatetime,
                        this.colDealStatus
            };

            // 
            // colRecordID
            // 
            this.colRecordID.Caption = "记录编号";
            this.colRecordID.FieldName = "RecordID";
            this.colRecordID.Name = "colRecordID";
            this.colRecordID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colRecordID.Visible = false;
            this.colRecordID.Width = 0;
            // 
            // colInboundID
            // 
            this.colInboundID.Caption = "入库单编号";
            this.colInboundID.FieldName = "InboundID";
            this.colInboundID.Name = "colInboundID";
            this.colInboundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colInboundID.Visible = false;
            this.colInboundID.Width = 0;
            // 
            // colDetailID
            // 
            this.colDetailID.Caption = "入库明细编号";
            this.colDetailID.FieldName = "DetailID";
            this.colDetailID.Name = "colDetailID";
            this.colDetailID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDetailID.Visible = false;
            this.colDetailID.Width = 0;
            // 
            // colShelfNo
            // 
            this.colShelfNo.Caption = "货架号";
            this.colShelfNo.FieldName = "ShelfNo";
            this.colShelfNo.Name = "colShelfNo";
            this.colShelfNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShelfNo.Visible = true;
            this.colShelfNo.Width = 80;
            // 
            // colSizeNo
            // 
            this.colSizeNo.Caption = "尺寸";
            this.colSizeNo.FieldName = "SizeNo";
            this.colSizeNo.Name = "colSizeNo";
            this.colSizeNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSizeNo.Visible = true;
            this.colSizeNo.Width = 70;
            // 
            // colLotNo
            // 
            this.colLotNo.Caption = "Art#";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLotNo.Visible = true;
            this.colLotNo.Width = 70;
            // 
            // colNumofPlan
            // 
            this.colNumofPlan.Caption = "订单数量";
            this.colNumofPlan.FieldName = "NumOfPlan";
            this.colNumofPlan.Name = "colNumofPlan";
            this.colNumofPlan.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colNumofPlan.Visible = true;
            this.colNumofPlan.Width = 80;
            this.colNumofPlan.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
            // 
            // colNumofReal
            // 
            this.colNumofReal.Caption = "实际数量";
            this.colNumofReal.FieldName = "NumOfReal";
            this.colNumofReal.Name = "colNumofReal";
            this.colNumofReal.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colNumofReal.Visible = true;
            this.colNumofReal.Width = 80;
            // 
            // colDealUser
            // 
            this.colDealUser.Caption = "完成人员";
            this.colDealUser.FieldName = "DealUser";
            this.colDealUser.Name = "colDealUser";
            this.colDealUser.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDealUser.Visible = false;
            this.colDealUser.Width = 80;
            // 
            // colPlanDateTime
            // 
            this.colPlanDateTime.Caption = "分解时间";
            this.colPlanDateTime.FieldName = "PlanDateTime";
            this.colPlanDateTime.Name = "colPlanDateTime";
            this.colPlanDateTime.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPlanDateTime.Visible = true;
            this.colPlanDateTime.Width = 100;
            // 
            // colDealDateTime
            // 
            this.colDealDatetime.Caption = "完成时间";
            this.colDealDatetime.FieldName = "DealDateTime";
            this.colDealDatetime.Name = "colDealDatetime";
            this.colDealDatetime.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDealDatetime.Visible = true;
            this.colDealDatetime.Width = 100;
            // 
            // colDealStatus
            // 
            this.colDealStatus.Caption = "完成状态";
            this.colDealStatus.FieldName = "DealStatus";
            this.colDealStatus.Name = "colDealStatus";
            this.colDealStatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDealStatus.Visible = true;
            this.colDealStatus.Width = 100;
            // 
            //colCheck
            //
            this.colCheck.Caption = "选择";
            this.colCheck.FieldName = "CheckStatus";
            this.colCheck.Name = "colCheck";
            this.colCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colCheck.OptionsColumn.AllowEdit = false;
            this.colCheck.OptionsColumn.AllowSort = DefaultBoolean.False;

            this.colCheck.Visible = false;
            this.colCheck.Width = 50;
        }

        protected override void InitGridView()
        {
            base.InitGridView(); 

            gridView.OptionsBehavior.Editable = true;   //是否允许用户编辑单元格
            gridView.OptionsCustomization.AllowColumnMoving = false;
            gridView.IndicatorWidth = 30;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;
             
            gridView.RowCellClick += new RowCellClickEventHandler(OnRowCellClick);
            gridView.RowClick += new RowClickEventHandler(OnRowClick);
            gridView.CustomDrawCell += new RowCellCustomDrawEventHandler(OnCustomDrawCell);
            gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(OnValidatingEditor);

            gridView.IndicatorWidth = 30;
        }

        public void SetGridEditStatus(bool bEdit)
        {
            for (int i = 0; i < gridView.Columns.Count; i++)
                gridView.Columns[i].OptionsColumn.AllowEdit = false;
            
            colCheck.Visible = bEdit;
            if (bEdit == true)
                colCheck.VisibleIndex = 0;
            else
                colCheck.VisibleIndex = -1;
            colNumofReal.OptionsColumn.AllowEdit = bEdit;
                 
        }

        #endregion

        #region 数据加载

        public void LoadInboundRecord(string inboundID)
        {
            //string sql = String.Format("Select RecordID, InboundID, DetailID,ShelfNo,LotNo, SizeNo, NumOfPlan,NumOfReal,"
            //                    + " DealUser,PlanDateTime,DealDateTime,DealStatus From T_InboundRecord  where InboundID = '{0}' order by  ShelfNo,LotNo, SizeNo ", inboundID);

            string sql = string.Format("SELECT rec.RecordID, rec.InboundID, rec.DetailID, rec.ShelfNo, rec.LotNo, rec.SizeNo, rec.NumOfPlan, rec.NumOfReal, "
                         + " rec.DealUser, rec.PlanDateTime, rec.DealDateTime, rec.DealStatus, sef.RowNo, sef.ColNo, sef.LevelNo "
                         + " FROM T_InboundRecord rec INNER JOIN T_Shelf sef ON rec.ShelfNo = sef.ShelfNo WHERE  rec.InboundID = '{0}' "
                         + " ORDER BY sef.RowNo, sef.ColNo , sef.LevelNo , rec.LotNo, rec.SizeNo ",
                         inboundID);

            dataTable = Database.Select(sql);

            dataTable.Columns.Add("CheckStatus", System.Type.GetType("System.Boolean"));

            gridView.GridControl.DataSource = dataTable;

            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                dataTable.Rows[i]["CheckStatus"] = false;
            }
            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;
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

        #region 视图编辑

        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }
        
        public void OnRowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "CheckStatus")
            {
                bool bcheck = Convert.ToBoolean(gridView.GetFocusedValue());
                gridView.SetFocusedValue(!bcheck);
            }
        }
        
        public void OnRowClick(object sender, RowClickEventArgs e)
        {
             
            string status = gridView.GetFocusedRowCellValue(colDealStatus).ToString() ;

            if (status == DealStatus.Complete)
                colNumofReal.OptionsColumn.AllowEdit = false;
            else
                colNumofReal.OptionsColumn.AllowEdit = true;
        }

        public void OnCustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "DealStatus")
            {
                string status = gridView.GetRowCellValue(e.RowHandle, "DealStatus").ToString();

                if (status == DealStatus.Complete)
                    e.DisplayText = DealStatus.Caption_Complete;
                else
                    e.DisplayText = "";
            }
        }

        public void OnValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {

            if (gridView.FocusedColumn != colNumofReal)
                return;
             
            try
            {
               int  numOfReal = Convert.ToInt32(e.Value); 
               int inventory = GetInventory(gridView.FocusedRowHandle);
               if (numOfReal + inventory > MemoryTable.Instance.ShelfCapacity)
               {
                   MsgBox.Warn("该货架超出了其的最大量");
               }
            }
            catch 
            {
                e.ErrorText = "只能输入一个整数";
                e.Valid = false;
            }
        }
         
        private int GetInventory(int rowHandle)
        {
            string shelfNo = gridView.GetRowCellValue(rowHandle, "ShelfNo").ToString();
            string lotNo = gridView.GetRowCellValue(rowHandle, "LotNo").ToString();
            string sizeNo = gridView.GetRowCellValue(rowHandle, "SizeNo").ToString();

            string sql = String.Format("Select Quantity From T_Inventory Where shelfNo = '{0}' and LotNo = '{1}' and SizeNo = '{2}' ",
                shelfNo,
                lotNo,
                sizeNo);

            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return 0;

            return Convert.ToInt32(dt.Rows[0][0]);

        }

      
        #endregion
    }
}
