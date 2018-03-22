using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
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
    public class TranboundEditView : BaseGridView
    {
        
        public string TranboundID = String.Empty;

        public TranboundEditView()
        {

        }
        public TranboundEditView(GridView view)
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
         
        protected override void CreateGridColumns()
        {
            this.colDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfNoFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfNoTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSizeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumOfPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            
            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colDetailID,
                        this.colShelfNoFrom,
                        this.colShelfNoTo, 
                        this.colLotNo,
                        this.colSizeNo,
                        this.colNumOfPlan 
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
            // colShelfNoFrom
            // 
            this.colShelfNoFrom.Caption = "Shelf# From";//"原货架号";
            this.colShelfNoFrom.FieldName = "ShelfNoFrom";
            this.colShelfNoFrom.Name = "colShelfNoFrom";
            this.colShelfNoFrom.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShelfNoFrom.Visible = true;
            this.colShelfNoFrom.Width = 80;
            // 
            // colShelfNoTo
            // 
            this.colShelfNoTo.Caption = "Shelf# To";//"新货架号";
            this.colShelfNoTo.FieldName = "ShelfNoTo";
            this.colShelfNoTo.Name = "colShelfNoTo";
            this.colShelfNoTo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShelfNoTo.Visible = true;
            this.colShelfNoTo.Width = 80;
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
            this.colSizeNo.Caption = "Size#";//"尺寸";
            this.colSizeNo.FieldName = "SizeNo";
            this.colSizeNo.Name = "colSizeNo";
            this.colSizeNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSizeNo.Visible = true;
            this.colSizeNo.Width = 80;

            // 
            // colNumOfPlan
            // 
            this.colNumOfPlan.Caption = "Quantity";//"数量";
            this.colNumOfPlan.FieldName = "NumOfPlan";
            this.colNumOfPlan.Name = "colNumOfPlan";
            this.colNumOfPlan.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colNumOfPlan.Visible = true;
            this.colNumOfPlan.Width = 80;
             
        }

        #endregion
         
        #region 视图初始化

        public override void Initialize(GridView view)
        {
            base.Initialize(view); 
        }

        protected override void InitGridView()
        {
            base.InitGridView();
            gridView.OptionsBehavior.Editable = false;  
            gridView.OptionsCustomization.AllowColumnMoving = false; 
            //gridView.OptionsNavigation.AutoFocusNewRow = true;
            //gridView.OptionsSelection.InvertSelection = true;
            //gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;
            gridView.IndicatorWidth = 30;
        }

        
        #endregion

        #region 倒库明细编辑
         
        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }

        public void RemoveRows(int[] rowHandles)
        {
            if (rowHandles == null)
                return;
            string detialID = "";
            for (int i = rowHandles.Length - 1; i >= 0; i--)
            {
                detialID = gridView.GetRowCellValue(rowHandles[i], colDetailID).ToString();

                if (String.IsNullOrEmpty(detialID) == false )
                    RemoveTranboundDetail(detialID);
                gridView.DeleteRow(rowHandles[i]);
            }
        }

        public bool RemoveTranboundDetail(string detialID)
        {
            string sql = String.Format("delete from T_TranboundDetail where detailID = '{0}'", detialID);
            return Database.ExecuteSQL(sql, "TranboundEditView-RemoveTranboundDetail") == 0 ? false : true;
        }
        
        public void SaveDetail()
        {
            Cursor.Current = Cursors.WaitCursor;
        
            string sql = ""; 
            string detailID = "";
            int cnt = gridView.RowCount;
            for (int i = 0; i < cnt; i++)
            {
                detailID = "";
                if (gridView.GetRowCellValue(i, colDetailID) == null)
                    continue;
                detailID = gridView.GetRowCellValue(i, colDetailID).ToString();
                if (  String.IsNullOrEmpty(detailID ))
                {
                    detailID = Database.GetDataTimekey(3,i);
                    sql = String.Format("insert into t_tranbounddetail (detailID, TranboundID, ShelfNoFrom, ShelfNoTo,LotNo,SizeNo,NumOfPlan,NumOfReal,DealStatus )"
                        +"Values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}')",
                        detailID,
                        TranboundID,
                        gridView.GetRowCellValue(i, colShelfNoFrom).ToString(),
                        gridView.GetRowCellValue(i, colShelfNoTo).ToString(),
                        gridView.GetRowCellValue(i, colLotNo).ToString(),
                        gridView.GetRowCellValue(i, colSizeNo).ToString(),
                        gridView.GetRowCellValue(i, colNumOfPlan).ToString(),
                        0 ,
                        DealStatus.None );
                    if (Database.ExecuteSQL(sql, "TranboundEditView-SaveDetail") > 0)
                    {
                        gridView.SetRowCellValue(i, colDetailID, detailID);
                         
                    }

                }else{
                     
                    sql = String.Format("update T_TranboundDetail set ShelfNoFrom='{0}', ShelfNoTo='{1}' , LotNo = '{2}', SizeNo='{3}',NumofPlan={4} where DetailID='{5}' ",
                                gridView.GetRowCellValue(i, colShelfNoFrom).ToString(),
                                gridView.GetRowCellValue(i, colShelfNoTo).ToString(),
                                gridView.GetRowCellValue(i, colLotNo).ToString(),
                                gridView.GetRowCellValue(i, colSizeNo).ToString(),
                                gridView.GetRowCellValue(i, colNumOfPlan).ToString(),
                                detailID );

                    Database.ExecuteSQL(sql, "TranboundEditView-SaveDetail");
                }
            }

            Cursor.Current = Cursors.Default;
        }

        public bool FindTranbound(string id)
        {
            string sql = String.Format("select tranboundID from t_tranbound where tranboundID = '{0}'", id);
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }

        public bool FindTranDetail(string lotNo, string sizeNo, string shelfNo)
        {
            bool bFind = false;
            
            int cnt = gridView.RowCount;
            string value;
            for (int i = 0; i < cnt; i++)
            {
                bFind = false;
                //lotNo
                value = gridView.GetRowCellValue(i, colLotNo).ToString();
                if (value != lotNo)
                    continue;

                //sizeNo
                value = gridView.GetRowCellValue(i, colSizeNo).ToString();
                if (value != sizeNo)
                    continue ;

                value = gridView.GetRowCellValue(i, colShelfNoFrom ).ToString();
                if (value != shelfNo)
                    continue ;

                return true;
            }


            return bFind;
        }

        public bool FindTranDetail(TranboundItem item)
        {
            return FindTranDetail(item.lotNo, item.sizeNo, item.fromShelfNo);
        }

        #endregion

        public void AddTranBoundDetail(TranboundItem item)
        {
            DataRow dr = dataTable.NewRow();

            dr["DetailID"] = "";
            dr["ShelfNoFrom"] = item.fromShelfNo;
            dr["ShelfNoTo"] = item.toShelfNo;
            dr["LotNo"] = item.lotNo;
            dr["SizeNo"] = item.sizeNo;
            dr["NumOfPlan"] = item.quantity.ToString();

            dataTable.Rows.Add(dr);
        }
    }
}
