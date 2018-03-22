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
    public class ReturnRecordView : BaseGridView
    { 

        #region 表格初始化

        public GridView invtView;
        public string BackboundID = String.Empty;
        public ReturnRecordView() { }
        public ReturnRecordView(GridView view)
        {
            base.SetGridView(view);
        }

        #region Grid Column

        protected DevExpress.XtraGrid.Columns.GridColumn colRecordID;
        protected DevExpress.XtraGrid.Columns.GridColumn colBackboundID;
        protected DevExpress.XtraGrid.Columns.GridColumn colDetailID; 
        protected DevExpress.XtraGrid.Columns.GridColumn colShelfNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colSizeNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        protected DevExpress.XtraGrid.Columns.GridColumn colDealDatetime;
        protected DevExpress.XtraGrid.Columns.GridColumn colDealStatus;
        protected DevExpress.XtraGrid.Columns.GridColumn colCheck;

        #endregion
         
        protected override void CreateGridColumns()
        {
            this.colRecordID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBackboundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSizeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colDealDatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colCheck,
                        this.colRecordID,
                        this.colBackboundID,
                        this.colDetailID, 
                        this.colShelfNo,
                        this.colLotNo,
                        this.colSizeNo,
                        this.colQuantity, 
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
            // colBackboundID
            // 
            this.colBackboundID.Caption = "退货单单编号";
            this.colBackboundID.FieldName = "BackboundID";
            this.colBackboundID.Name = "colBackboundID";
            this.colBackboundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBackboundID.Visible = false;
            this.colBackboundID.Width = 0;
            // 
            // colDetailID
            // 
            this.colDetailID.Caption = "明细编号";
            this.colDetailID.FieldName = "DetailID";
            this.colDetailID.Name = "colDetailID";
            this.colDetailID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDetailID.Visible = false;
            this.colDetailID.Width = 0;
            // 
            // colShelfNo
            // 
            this.colShelfNo.Caption = "Shelf#";
            this.colShelfNo.FieldName = "ShelfNo";
            this.colShelfNo.Name = "colShelfNo";
            this.colShelfNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShelfNo.Visible = true;
            this.colShelfNo.Width = 80;
            // 
            // colSizeNo
            // 
            this.colSizeNo.Caption = "Size#";
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
            this.colLotNo.Width = 100;
            // 
            // colNumofPlan
            // 
            this.colQuantity.Caption = "Quantity";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colQuantity.Visible = true;
            this.colQuantity.Width = 80;
            this.colQuantity.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
          
            // 
            // colDealDateTime
            // 
            this.colDealDatetime.Caption = "Date";
            this.colDealDatetime.FieldName = "DealDateTime";
            this.colDealDatetime.Name = "colDealDatetime";
            this.colDealDatetime.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDealDatetime.Visible = true;
            this.colDealDatetime.Width = 100;
            // 
            // colDealStatus
            // 
            this.colDealStatus.Caption = "Status";
            this.colDealStatus.FieldName = "DealStatus";
            this.colDealStatus.Name = "colDealStatus";
            this.colDealStatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDealStatus.Visible = true;
            this.colDealStatus.Width = 70;
            // 
            //colCheck
            //
            this.colCheck.Caption = " ";
            this.colCheck.FieldName = "CheckStatus";
            this.colCheck.Name = "colCheck";
            this.colCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colCheck.OptionsColumn.AllowEdit = false;
            this.colCheck.OptionsColumn.AllowSort = DefaultBoolean.False;

            this.colCheck.Visible = true;
            this.colCheck.Width = 40;
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
            gridView.CustomDrawCell += new RowCellCustomDrawEventHandler(OnCustomDrawCell);
            //gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.recordView_CellValueChanged);
            gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(OnValidatingEditor);
            gridView.IndicatorWidth = 30;
        }

        public void SetGridEditStatus(bool bEdit)
        {
            if (invtView != null)
                invtView.GridControl.Visible =  bEdit  ;

            for (int i = 0; i < gridView.Columns.Count; i++)
                gridView.Columns[i].OptionsColumn.AllowEdit = false;

            if(colShelfNo != null)
                colShelfNo.OptionsColumn.AllowEdit = bEdit;
            if (colCheck != null)
            {
                if (bEdit == true)
                {
                    colCheck.Visible = false;
                    colCheck.VisibleIndex = -1;
                    colCheck.Width = 0;
                }
                else
                {
                    colCheck.Visible = true;
                    colCheck.VisibleIndex = 0;
                    colCheck.Width = 40;
                }
            }
             

        }

        #endregion

        #region 数据加载

        public void LoadRecord(string boundID)
        {
            BackboundID = boundID;
            string sql = String.Format("Select RecordID, BackboundID, DetailID,ShelfNo,LotNo, SizeNo, Quantity,"
                                + " DealDateTime,DealStatus From T_BackboundRecord  where BackboundID = '{0}' order by  ShelfNo,LotNo, SizeNo ", boundID);
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

        private void GridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column != colShelfNo)
                return;

            
        }

        public void OnValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (gridView.FocusedColumn == colShelfNo)
            { 
                if (FindShelfNo( e.Value.ToString() ) == false)
                {
                    e.ErrorText = "Shelf# does not exist. ";
                    e.Valid = false;
                    return;
                }
                UpdateShelfNo(gridView.FocusedRowHandle, e.Value.ToString());
            }
        }

        private bool FindShelfNo(string shelfNo)
        {
            List<String> list = MemoryTable.Instance.ListShelfNo;

            for (int i = 0; i < list.Count; i++)
                if (shelfNo.ToUpper() == list[i].ToUpper() )
                    return true;

            return false;
        }

        private bool UpdateShelfNo(int rowHandle, string val)
        {
            string recID = gridView.GetRowCellValue(rowHandle,colRecordID).ToString() ;
            if (string.IsNullOrEmpty(recID) == true)
                return false;

            string sql = string.Format("Update T_BackboundRecord Set ShelfNo = '{0}' where RecordID = '{1}'", val.ToUpper() , recID);
            return Database.ExecuteSQL(sql) > 0 ? true : false;
        }

        #endregion
    }
}
