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
    class TranboundDetailView : BaseGridView
    {
        public string TranboundID = String.Empty;

        public TranboundDetailView()
        {

        }
        public TranboundDetailView(GridView view)
        {
            base.SetGridView(view);
        }

        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colDetailID;
        protected DevExpress.XtraGrid.Columns.GridColumn colShelfNoFrom;
        protected DevExpress.XtraGrid.Columns.GridColumn colShelfNoTo;
        protected DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colSizeNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colNumOfPlan;//计划倒库数
        //protected DevExpress.XtraGrid.Columns.GridColumn colNumOfReal;//实际倒库数
        protected DevExpress.XtraGrid.Columns.GridColumn colDealTime;
        protected DevExpress.XtraGrid.Columns.GridColumn colDealUser;
        protected DevExpress.XtraGrid.Columns.GridColumn colDealStatus; 

        #endregion

        protected override void InitGridView()
        {
            base.InitGridView(); 
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;
             
            this.gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(OnValidatingEditor);
        }

        protected override void CreateGridColumns()
        {
            this.colDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfNoFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfNoTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSizeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumOfPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            //this.colNumOfReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealStatus = new DevExpress.XtraGrid.Columns.GridColumn(); 
            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] { 
                        this.colDetailID,
                        this.colShelfNoFrom,
                        this.colShelfNoTo, 
                        this.colLotNo,
                        this.colSizeNo,
                        this.colNumOfPlan,
                        //this.colNumOfReal, 
                        this.colDealUser,
                        this.colDealTime, 
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
            this.colDetailID.OptionsColumn.AllowEdit = false;
            this.colDetailID.Width = 100;
            // 
            // colShelfNoFrom
            // 
            this.colShelfNoFrom.Caption = "Shelf# From";//"原货架号";
            this.colShelfNoFrom.FieldName = "ShelfNoFrom";
            this.colShelfNoFrom.Name = "colShelfNoFrom";
            this.colShelfNoFrom.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShelfNoFrom.Visible = true;
            this.colShelfNoFrom.OptionsColumn.AllowEdit = false;
            this.colShelfNoFrom.Width = 80;
            // 
            // colShelfNoTo
            // 
            this.colShelfNoTo.Caption = "Shelf# To";//"新货架号";
            this.colShelfNoTo.FieldName = "ShelfNoTo";
            this.colShelfNoTo.Name = "colShelfNoTo";
            this.colShelfNoTo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShelfNoTo.Visible = true;
            this.colShelfNoTo.OptionsColumn.AllowEdit = false;
            this.colShelfNoTo.Width = 80;
            // 
            // colLotNo
            // 
            this.colLotNo.Caption = "Art#";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLotNo.Visible = true;
            this.colLotNo.OptionsColumn.AllowEdit = false;
            this.colLotNo.Width = 80;
            // 
            // colSizeNo
            // 
            this.colSizeNo.Caption = "Size#";//"尺寸";
            this.colSizeNo.FieldName = "SizeNo";
            this.colSizeNo.Name = "colSizeNo";
            this.colSizeNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSizeNo.Visible = true;
            this.colSizeNo.OptionsColumn.AllowEdit = false;
            this.colSizeNo.Width = 80;

            // 
            // colNumOfPlan
            // 
            this.colNumOfPlan.Caption = "Quantity";//"数量";
            this.colNumOfPlan.FieldName = "NumOfPlan";
            this.colNumOfPlan.Name = "colNumOfPlan";
            this.colNumOfPlan.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colNumOfPlan.Visible = true;
            this.colNumOfPlan.OptionsColumn.AllowEdit = true;
            this.colNumOfPlan.Width = 50;

            // 
            // colNumOfReal
            // 
            //this.colNumOfReal.Caption = "实倒库数量";
            //this.colNumOfReal.FieldName = "NumOfReal";
            //this.colNumOfReal.Name = "colNumOfReal";
            //this.colNumOfReal.UnboundType = DevExpress.Data.UnboundColumnType.String;
            //this.colNumOfReal.Visible = true;
            //this.colNumOfReal.Width = 100;
            // 
            // colDealTime
            // 
            this.colDealTime.Caption = "Date";//"完成时间";
            this.colDealTime.FieldName = "DealDatetime";
            this.colDealTime.Name = "colDealTime";
            this.colDealTime.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDealTime.OptionsColumn.AllowEdit = false;
            this.colDealTime.Visible = true;
            this.colDealTime.Width = 200;
            // 
            // colDealUser
            // 
            this.colDealUser.Caption = "Operator";//"操作人";
            this.colDealUser.FieldName = "DealUser";
            this.colDealUser.Name = "colDealUser";
            this.colDealUser.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDealUser.Visible = false;
            this.colDealUser.OptionsColumn.AllowEdit = false;
            this.colDealUser.Width = 100;

            // 
            // colDealStatus
            // 
            this.colDealStatus.Caption = "Status";//"状态";
            this.colDealStatus.FieldName = "DealStatus";
            this.colDealStatus.Name = "colDealStatus";
            this.colDealStatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDealStatus.OptionsColumn.AllowEdit = false;
            this.colDealStatus.Visible = true ;
            this.colDealStatus.Width = 80;
             
        }
        
        public void LoadTranboundDetail(string tranboundID)
        {
            string sql = String.Format("Select  DetailID, ShelfNoFrom,ShelfNoTo ,LotNo, SizeNo, NumOfPlan,DealUser,DealDatetime,DealStatus "
                                + " From T_TranboundDetail  where TranboundID = '{0}' order by LotNo, SizeNo, ShelfNoFrom,ShelfNoTo ", tranboundID);
            dataTable = Database.Select(sql);
            if (dataTable == null)
                return;
             
            gridView.GridControl.DataSource = dataTable;
 
            if (gridView.RowCount > 0)
                gridView.IndicatorWidth = 25 + (gridView.RowCount.ToString().Length) * 6;
        }

        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }
         
        public void OnValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            int cnt = 0;
            int rowHandle = gridView.FocusedRowHandle;
            try
            {
                cnt = Convert.ToInt32(e.Value);
            }
            catch 
            {
                e.ErrorText = "只能输入一个整数";
                e.Valid = false;
            }
             ;
            if (cnt <= 0)
            {
                e.ErrorText = "倒库数量不能小于0. ";
                e.Valid = false; 
                return;
            }
            string detialId = gridView.GetRowCellValue(rowHandle, colDetailID).ToString();
            string lotno = gridView.GetRowCellValue(rowHandle, colLotNo).ToString();
            string sizeno = gridView.GetRowCellValue(rowHandle, colSizeNo).ToString();
            string shelfno = gridView.GetRowCellValue(rowHandle, colShelfNoFrom).ToString();
            if (cnt > GetInventoryQuantity(lotno, sizeno, shelfno))
            {
                e.ErrorText = "倒库数量不能大于库存量. ";
                e.Valid = false;
                return;
            }

            SaveTranCnt(cnt, detialId);

        }
        
        private int GetInventoryQuantity(string lotNo, string sizeNo, string shelfNo)
        {
            string sql = string.Format("select Quantity from T_Inventory where lotno = '{0}' and sizeNo = '{1}' and shelfNo = '{2}'",
                lotNo,
                sizeNo,
                shelfNo);
            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return 0;

            string temp = dt.Rows[0][0].ToString();
            if (String.IsNullOrEmpty(temp))
                return 0;
            return Convert.ToInt32(temp);
        }

        public void SaveTranCnt(int cnt , string detialId)
        {
           
            string sql = string.Format("update T_TranboundDetail Set NumOfPlan = {0} where  detailID = '{1}'",
                cnt,
                detialId);

            Database.ExecuteSQL(sql, "TranboundDetailView-SaveTranCnt");
        }

    }
}
