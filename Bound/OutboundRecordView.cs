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
    public class OutboundRecordView : BaseGridView
    {
        public string OutboundID = String.Empty;//出库单编号

        public OutboundRecordView() { }
        public OutboundRecordView(GridView view)
        {
                 base.SetGridView(view);
        }

        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colOutboundID;
        protected DevExpress.XtraGrid.Columns.GridColumn colRecordID;
        protected DevExpress.XtraGrid.Columns.GridColumn colDetailID; 
        protected DevExpress.XtraGrid.Columns.GridColumn colShelfNo; 
        protected DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colSizeNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colNumOfPlan;
        protected DevExpress.XtraGrid.Columns.GridColumn colNumOfReal;
        protected DevExpress.XtraGrid.Columns.GridColumn colPlanDatetime;
        protected DevExpress.XtraGrid.Columns.GridColumn colDealDatetime;
        protected DevExpress.XtraGrid.Columns.GridColumn colDealUser;
        protected DevExpress.XtraGrid.Columns.GridColumn colDealStatus;
        protected DevExpress.XtraGrid.Columns.GridColumn colCheck;
       
        #endregion

        #region 视图初始化

        protected override void CreateGridColumns()
        {
            this.colOutboundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSizeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumOfPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumOfReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanDatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealDatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colCheck,
                        this.colRecordID,
                        this.colOutboundID,
                        this.colDetailID, 
                        this.colShelfNo, 
                        this.colLotNo,
                        this.colSizeNo,
                        this.colNumOfPlan,
                        this.colNumOfReal,
                        this.colDealUser,  
                        this.colPlanDatetime,
                        this.colDealDatetime,
                        this.colDealStatus
            };

            // 
            // colDetailID
            // 
            this.colDetailID.Caption = "明细编号";
            this.colDetailID.FieldName = "DetailID";
            this.colDetailID.Name = "colDetailID";
            this.colDetailID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDetailID.Visible = false;
            this.colDetailID.Width = 100;
            // 
            // colRecordID
            // 
            this.colRecordID.Caption = "记录编号";
            this.colRecordID.FieldName = "RecordID";
            this.colRecordID.Name = "colRecordID";
            this.colRecordID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colRecordID.Visible = false;
            this.colRecordID.Width = 80;
            // 
            // colOutboundID
            // 
            this.colOutboundID.Caption = "出库单编号";
            this.colOutboundID.FieldName = "OutboundID";
            this.colOutboundID.Name = "colOutboundID";
            this.colOutboundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOutboundID.Visible = false;
            this.colOutboundID.Width = 80; 
            // 
            // colLotNo
            // 
            this.colLotNo.Caption = "Art#";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLotNo.Visible = true;
            this.colLotNo.Width = 80;
            // 
            // colSizeNo
            // 
            this.colSizeNo.Caption = "尺寸";
            this.colSizeNo.FieldName = "SizeNo";
            this.colSizeNo.Name = "colSizeNo";
            this.colSizeNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSizeNo.Visible = true;
            this.colSizeNo.Width = 80;
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
            // colNumOfPlan
            // 
            this.colNumOfPlan.Caption = "计划数量";
            this.colNumOfPlan.FieldName = "NumOfPlan";
            this.colNumOfPlan.Name = "colNumOfPlan";
            this.colNumOfPlan.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colNumOfPlan.Visible = true;
            this.colNumOfPlan.Width = 80;
            // 
            // colNumOfReal
            // 
            this.colNumOfReal.Caption = "实际数量";
            this.colNumOfReal.FieldName = "NumOfReal";
            this.colNumOfReal.Name = "colNumOfReal";
            this.colNumOfReal.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colNumOfReal.Visible = true;
            this.colNumOfReal.Width = 80;
            // 
            // colPlanDatetime
            // 
            this.colPlanDatetime.Caption = "分解时间";
            this.colPlanDatetime.FieldName = "PlanDateTime";
            this.colPlanDatetime.Name = "colPlanDatetime";
            this.colPlanDatetime.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPlanDatetime.Visible = false;
            this.colPlanDatetime.Width = 100;
            // 
            // colDealDatetime
            // 
            this.colDealDatetime.Caption = "完成时间";
            this.colDealDatetime.FieldName = "DealDateTime";
            this.colDealDatetime.Name = "colDealDatetime";
            this.colDealDatetime.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDealDatetime.Visible = true;
            this.colDealDatetime.Width = 100;
            // 
            // colDealUser
            // 
            this.colDealUser.Caption = "操作人";
            this.colDealUser.FieldName = "DealUser";
            this.colDealUser.Name = "colDealUser";
            this.colDealUser.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDealUser.Visible = false;
            this.colDealUser.Width = 100;

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

            this.colCheck.Visible = true;
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
             

        }

        public void SetGridEditStatus(bool bEdit)
        {
            for (int i = 0; i < gridView.Columns.Count; i++)
                gridView.Columns[i].OptionsColumn.AllowEdit = false;

            colCheck.Visible =  bEdit;  
        }

        #endregion

        #region 加载数据

        public void LoadOutboundRecord(string outboundID)
        {
            //string sql = String.Format("Select RecordID, OutboundID, DetailID, ShelfNo, LotNo, SizeNo, NumOfPlan, NumOfReal,DealUser, "
            //                    + " PlanDatetime,DealDatetime,DealStatus From T_OutboundRecord  where OutboundID = '{0}' and DealStatus <> '{1}' order by LotNo, SizeNo, ShelfNo ",
            //                    outboundID,
            //                    MemoryTable.BackBound );

            string sql = string.Format("SELECT rec.RecordID, rec.OutboundID, rec.DetailID, rec.ShelfNo, rec.LotNo, rec.SizeNo, rec.NumOfPlan, rec.NumOfReal, "
                        + " rec.DealUser, rec.PlanDateTime, rec.DealDateTime, rec.DealStatus, sef.RowNo, sef.ColNo, sef.LevelNo "
                        + " FROM T_OutboundRecord rec INNER JOIN T_Shelf sef ON rec.ShelfNo = sef.ShelfNo WHERE  rec.OutboundID = '{0}' "
                        + "  and (DealStatus <> '{1}' or DealStatus is null)  and rec.NumOfPlan >0 "
                        + " ORDER BY sef.RowNo, sef.ColNo , sef.LevelNo , rec.LotNo, rec.SizeNo ",
                        outboundID,
                        MemoryTable.BackBound);

            dataTable = Database.Select(sql);
             
            dataTable.Columns.Add("CheckStatus", System.Type.GetType("System.Boolean"));

            gridView.GridControl.DataSource = dataTable;

            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                dataTable.Rows[i]["CheckStatus"] = false;
            }

        }

        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
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
            for (int i = 0; i < gridView.Columns.Count; i++)
                gridView.Columns[i].OptionsColumn.AllowEdit = false;

            string status = gridView.GetFocusedRowCellValue(colDealStatus).ToString();

            if (status == DealStatus.Complete)
                colNumOfReal.OptionsColumn.AllowEdit = false;
            else
                colNumOfReal.OptionsColumn.AllowEdit = true;
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

            if (gridView.FocusedColumn != colNumOfReal)
                return; 
            try
            {
                int numOfReal = Convert.ToInt32(e.Value);
                
                int inventory = GetInventory(gridView.FocusedRowHandle);

                if (numOfReal > inventory)
                {
                    e.ErrorText = "实际出库数量大于货架上的库存量";
                    e.Valid = false;
                     
                }
            }
            catch
            {
                e.ErrorText = "只能输入一个整数";
                e.Valid = false;
            }
        }
 
        private void UpdateNumOfReal(int rowHandle)
        {
            string recordID = "", detailID, shelfNo = "";
            recordID = gridView.GetRowCellValue(rowHandle, "RecordID").ToString();
            detailID = gridView.GetRowCellValue(rowHandle, "DetailID").ToString();
            shelfNo = gridView.GetRowCellValue(rowHandle, "ShelfNo").ToString();

            Object obj = null;
            int numOfPlan = 0, numOfReal = 0;

            obj = gridView.GetRowCellValue(rowHandle, "NumOfPlan");
            if (obj != null)
                numOfPlan = Convert.ToInt32(obj);

            obj = gridView.GetRowCellValue(rowHandle, "NumOfReal");
            if (obj != null)
                numOfReal = Convert.ToInt32(obj);

            if (numOfReal == numOfPlan)
                return;

            //更新库存表，操作明细，出库明细等.
            string sql = String.Format("Update T_OutboundRecord Set  NumofReal =  {0}  Where recordID = '{1}' ", numOfReal, recordID);
            Database.ExecuteSQL(sql, "OutboundDetailView-UpdateNumOfReal");

            string lotNo = gridView.GetRowCellValue(rowHandle, "LotNo").ToString();
            string sizeNo = gridView.GetRowCellValue(rowHandle, "SizeNo").ToString();

            //出库明细
            sql = String.Format("Update T_OutboundDetail Set  NumofReal =  {0}  Where detailID = '{1}' and lotNo = '{2}' and SizeNo = '{3}' ",
                numOfReal,
                detailID,
                lotNo,
                sizeNo);

            Database.ExecuteSQL(sql, "OutboundDetailView-UpdateNumOfReal");

            //修改库存表
            sql = String.Format("Update T_Inventory Set Quantity = Quantity + {0} where shelfNo = '{1}' and LotNo = '{2}' and sizeNo = '{3}'",
                numOfPlan - numOfReal,
                shelfNo,
                lotNo,
                sizeNo);

            Database.ExecuteSQL(sql, "OutboundDetailView-UpdateNumOfReal");
        }

        private int GetInventory(int rowHandle)
        {
            string shelfNo = gridView.GetRowCellValue(rowHandle,"ShelfNo").ToString();
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
