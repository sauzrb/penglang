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
using DevExpress.XtraEditors;

namespace PengLang
{
    public class BackBoundDetailView : BaseGridView
    {
        class SizeComboItem
        {
            public string sizeNo = string.Empty;
            public string detailNo = string.Empty;
            public string lotNo = string.Empty;
            public string shelfNo = string.Empty;
            public int quantity=0;

            public override string ToString()
            {
                return sizeNo;
            }
        }

        #region 表格初始化

        public string OutboundID = String.Empty;
        public int OutboundKind = MemoryTable.Outbound_Kind_Gel;

        public BackBoundDetailView() { }
        public BackBoundDetailView(GridView view)
        {
            base.SetGridView(view);
        }

        #region Grid Column

        protected DevExpress.XtraGrid.Columns.GridColumn colRecordID;
        protected DevExpress.XtraGrid.Columns.GridColumn colDetailID; 
        protected DevExpress.XtraGrid.Columns.GridColumn colShelfNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colSizeNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        protected DevExpress.XtraGrid.Columns.GridColumn colDateTime;
        protected DevExpress.XtraGrid.Columns.GridColumn colToShelfNo;
        
        protected override void CreateGridColumns()
        {
            this.colRecordID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSizeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToShelfNo = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] { 
                        this.colRecordID,  
                        this.colDetailID,
                        this.colLotNo,
                        this.colSizeNo,
                        this.colShelfNo,
                        this.colQuantity,
                        this.colDateTime,
                        this.colToShelfNo
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
            // colDetailID
            // 
            this.colDetailID.Caption = "明细编号";
            this.colDetailID.FieldName = "DetailID";
            this.colDetailID.Name = "colDetailID";
            this.colDetailID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDetailID.Visible = false;
            this.colDetailID.Width = 0;
           
            // 
            // colLotNo
            //
            this.colLotNo.Caption = "Art#";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLotNo.Visible = true;
            this.colLotNo.Width = 150;
             
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
            this.colShelfNo.Caption = "Shelf#";
            this.colShelfNo.FieldName = "ShelfNo";
            this.colShelfNo.Name = "colShelfNo";
            this.colShelfNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShelfNo.Visible = true;
            this.colShelfNo.Width = 80;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Quantity";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colQuantity.Visible = true;
            this.colQuantity.Width = 80;
            this.colQuantity.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
             
            // 
            // colDateTime
            // 
            this.colDateTime.Caption = "DateTime";
            this.colDateTime.FieldName = "PlanDateTime";
            this.colDateTime.Name = "colPlanDateTime";
            this.colDateTime.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colDateTime.Visible = false;
            this.colDateTime.Width = 100;

            // 
            this.colToShelfNo.Caption = "Transfer To Shelf#";
            this.colToShelfNo.FieldName = "ToShelfNo";
            this.colToShelfNo.Name = "colToShelfNo";
            this.colToShelfNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colToShelfNo.Visible = true;
            this.colToShelfNo.Width = 120;

            CreateCombo();
        }

        #endregion

        #region Grid Repository

        private RepositoryItemComboBox comboLotNo;
        private RepositoryItemComboBox comboShelfNo;
        private RepositoryItemComboBox comboSizeNo;
        private RepositoryItemDateEdit comboDateTime;
        private RepositoryItemComboBox comboToShelfNo;

        protected void CreateCombo()
        {
            comboLotNo = new RepositoryItemComboBox();
            comboLotNo.Name = "comboLotNo";
            comboLotNo.AutoHeight = true;
            comboLotNo.TextEditStyle = TextEditStyles.DisableTextEditor;
            comboLotNo.SelectedValueChanged += new System.EventHandler(this.ComLotNo_SelectedValueChanged);
            colLotNo.ColumnEdit = comboLotNo;

            comboShelfNo = new RepositoryItemComboBox();
            comboShelfNo.Name = "comboShelfNo";
            comboShelfNo.AutoHeight = true;
            comboShelfNo.SelectedValueChanged += new System.EventHandler(this.ComShelfNo_SelectedValueChanged);
            colShelfNo.ColumnEdit = comboShelfNo;
             
            comboSizeNo = new RepositoryItemComboBox();
            comboSizeNo.Name = "comboSizeNo";
            comboSizeNo.AutoHeight = true;
            comboSizeNo.TextEditStyle = TextEditStyles.DisableTextEditor;
            comboSizeNo.SelectedValueChanged += new System.EventHandler(this.ComSizeNo_SelectedValueChanged);
            colSizeNo.ColumnEdit = comboSizeNo;

            comboDateTime = new RepositoryItemDateEdit();
            comboDateTime.DisplayFormat.FormatString = "yyyy-MM-dd";
            colDateTime.ColumnEdit = comboDateTime;

            comboToShelfNo = new RepositoryItemComboBox();
            comboToShelfNo.Name = "comboToShelfNo";
            comboToShelfNo.AutoHeight = true;
            colToShelfNo.ColumnEdit = comboToShelfNo;
            comboToShelfNo.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        #endregion

        protected override void InitGridView()
        {
            base.InitGridView();
            
            gridView.OptionsBehavior.Editable = false;   //是否允许用户编辑单元格
            gridView.OptionsCustomization.AllowColumnMoving = false;
            gridView.IndicatorWidth = 30;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;
            gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.CustomDrawCell += new RowCellCustomDrawEventHandler(OnCustomDrawCell);
            this.gridView.ValidateRow += new ValidateRowEventHandler(OnValidateRow); 
             
        }
        
        public void SetGridEditStatus(bool bEdit)
        {
            gridView.BeginInit();

            gridView.OptionsBehavior.Editable = bEdit;   //是否允许用户编辑单元格

            gridView.OptionsNavigation.AutoFocusNewRow = bEdit;
            gridView.OptionsSelection.InvertSelection = bEdit;

            if (bEdit == true)
            {
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
                gridView.OptionsBehavior.ReadOnly = false;
                
            }
            else
            {
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                gridView.OptionsBehavior.ReadOnly = true;
            }

            gridView.EndInit();
        }
        
        #endregion

        #region 数据加载

        public override void Loading()
        {
            string sql = String.Format("Select RecordID,DetailID,ShelfNo,LotNo, SizeNo, NumofReal as Quantity, PlanDateTime ,'' as ToShelfNo "
                                + "  From T_OutboundRecord  where OutboundID = '{0}' and DealStatus = '{1}' order by  LotNo, SizeNo ,ShelfNo ",
                                OutboundID,
           MemoryTable.BackBound);
            dataTable = Database.Select(sql);
 
            gridView.GridControl.DataSource = dataTable;
             
            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;
        }

        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }
        

        #endregion

        #region 编辑明细
               
        private DataTable dtBackbound = null;
      
        public void LoadBackBoundCombobox()
        {

            if (dtBackbound != null)
                dtBackbound.Clear();

            string sql = String.Format("Select DetailID, LotNo, SizeNo, ShelfNo, NumOfReal as Quantity From T_OutboundRecord  "
                                + " where OutboundID = '{0}' and DealStatus <> '{1}' and NumOfReal > 0 order by LotNo, SizeNo, ShelfNo ",
                                OutboundID,
                                MemoryTable.BackBound);
            dtBackbound = Database.Select(sql);

            if (dtBackbound == null || dtBackbound.Rows.Count == 0)
                return;

            GetLotNoComboItems();
        }

        private void GetLotNoComboItems()
        {
            DataView dataView = dtBackbound.DefaultView;
            DataTable dt = dataView.ToTable(true, "LotNo" );//注：其中ToTable（）的第一个参数为是否DISTINCT

            comboLotNo.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboLotNo.Items.Add(dt.Rows[i]["LotNo"].ToString());
            }
        }

        private void GetSizeNoComboItems(string lotNo)
        {
            comboSizeNo.Items.Clear();
            DataRow []dr = dtBackbound.Select(String.Format("LotNo = '{0}'", lotNo));
            for (int i = 0; i < dr.Length; i++)
                comboSizeNo.Items.Add(dr[i]["SizeNo" ].ToString());
        }

        private void GetShelfNoComboItems(string lotNo, string sizeNo )
        {
            comboShelfNo.Items.Clear();
            DataRow[] dr = dtBackbound.Select(String.Format("LotNo = '{0}' and SizeNo = '{1}' ", lotNo,sizeNo));
            for (int i = 0; i < dr.Length; i++)
                comboShelfNo.Items.Add(dr[i]["ShelfNo"].ToString());
        }

        private void GetShelfNoComboItems_ExA( string lotNo, string sizeNo)
        {
            comboToShelfNo.Items.Clear();
            string sql = string.Format("select distinct shelfNo from T_Inventory where lotNo = '{0}' and sizeNo = '{1}' and Quantity > 0 order by ShelfNo ",
                lotNo, sizeNo);
            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboToShelfNo.Items.Add(dt.Rows[i][0].ToString());
            }
        }
      
        private string GetDetailID(string lotNo, string sizeNo, string shelfNo)
        {
            int cnt = dtBackbound.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (dtBackbound.Rows[i]["LotNo"].ToString() != lotNo)
                    continue;
                if (dtBackbound.Rows[i]["SizeNo"].ToString() != sizeNo)
                    continue;
                if (dtBackbound.Rows[i]["ShelfNo"].ToString() != shelfNo)
                    continue;

                return dtBackbound.Rows[i]["DetailID"].ToString();
            }
            return "";
        }

        private int GetQuantity(string lotNo, string sizeNo, string shelfNo)
        {
            int cnt = dtBackbound.Rows.Count;
            int sum = 0;
            for (int i = 0; i < cnt; i++)
            {
                if (dtBackbound.Rows[i]["LotNo"].ToString() != lotNo)
                    continue;
                if (dtBackbound.Rows[i]["SizeNo"].ToString() != sizeNo)
                    continue;
                if (dtBackbound.Rows[i]["ShelfNo"].ToString() != shelfNo)
                    continue;

                return Convert.ToInt32(dtBackbound.Rows[i]["Quantity"]);
            }
            ;
            return sum;
        }

        private int GetSubTotal(string lotNo, string sizeNo)
        {
            int sum = 0;
            string lotno, sizeno;
            for (int i = 0; i < gridView.RowCount; i++)
            {
                lotno = gridView.GetRowCellValue(i,colLotNo).ToString();
                sizeno = gridView.GetRowCellValue(i, colSizeNo).ToString();
                if (lotno != lotNo)
                    continue;
                if (sizeno != sizeNo)
                    continue;

                sum += Convert.ToInt32(gridView.GetRowCellValue(i, colQuantity) );
            }

            return sum;
        }

        private void ComLotNo_SelectedValueChanged(object sender, EventArgs e)
        {
            string lotNo =  (sender as ComboBoxEdit).Text;

            gridView.SetFocusedRowCellValue("SizeNo", "");
            GetSizeNoComboItems(lotNo);
        }

        private void ComSizeNo_SelectedValueChanged(object sender, EventArgs e)
        {
            string lotNo = gridView.GetFocusedRowCellValue("LotNo").ToString();
            string sizeNo =  (sender as ComboBoxEdit).Text;
            gridView.SetFocusedRowCellValue("ShelfNo", ""); 
            GetShelfNoComboItems(lotNo, sizeNo);
            GetShelfNoComboItems_ExA(lotNo, sizeNo);
        }

        private void ComShelfNo_SelectedValueChanged(object sender, EventArgs e)
        {
            string lotNo = gridView.GetFocusedRowCellValue("LotNo").ToString();
            string sizeNo = gridView.GetFocusedRowCellValue("SizeNo").ToString();
            string shelfNo = (sender as ComboBoxEdit).Text; 
            gridView.SetFocusedRowCellValue(colQuantity, GetQuantity(lotNo,sizeNo,shelfNo));
            gridView.SetFocusedRowCellValue(colDetailID, GetDetailID(lotNo, sizeNo, shelfNo));
        }
         
        public void OnValidateRow(object sender, ValidateRowEventArgs e)
        {
            string lotNo = gridView.GetRowCellValue(e.RowHandle, colLotNo).ToString();
            if (String.IsNullOrEmpty(lotNo))
            {
                e.ErrorText = "Art# Column can not be empty. ";
                e.Valid = false;
                return;
            }
            string sizeNo = gridView.GetRowCellValue(e.RowHandle, colSizeNo).ToString();
            if (String.IsNullOrEmpty(sizeNo))
            {
                e.ErrorText = "Size# Column can not be empty. ";
                e.Valid = false;
                return;
            }

            string shelfNo = gridView.GetRowCellValue(e.RowHandle, colShelfNo).ToString();
            if (FindShelfNo(shelfNo) == false)
            {
                e.ErrorText = "Shelf# Column can not be empty. ";
                e.Valid = false;
                return;
            }

            if (gridView.GetRowCellValue(e.RowHandle, colQuantity) == null)
            {
                e.ErrorText = "Quantity Column error . ";
                e.Valid = false;
                return;
            }

            int qnt = Convert.ToInt32( gridView.GetRowCellValue(e.RowHandle, colQuantity));
            if (qnt > GetQuantity(lotNo, sizeNo,shelfNo ) || qnt < 1)
            {
                e.ErrorText = "Quantity Column error . ";
                e.Valid = false;
                return;
            }

          
        }

        private bool FindShelfNo(string shelfNo)
        {
            List<string> list = MemoryTable.Instance.ListShelfNo;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (shelfNo == list[i])
                    return true;
            }
            return false;
        }

        public void OnCustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "PlanDateTime")
            {
                Object obj = gridView.GetRowCellValue(e.RowHandle, "PlanDateTime");
                if (obj == null)
                    return;
                string strDateTime = gridView.GetRowCellValue(e.RowHandle, "PlanDateTime").ToString();
                e.DisplayText = strDateTime.Substring(0, 10); 
            }
        }

        #endregion

        #region 保存明细

        public void SaveBackbound()
        {
            int cnt = gridView.RowCount;
            for (int i = 0; i < cnt; i++)
            {
                if (gridView.GetRowCellValue(i, colLotNo) == null)
                    continue;
                SaveBackboundDetail(i);
            }
        }

        protected bool SaveBackboundDetail(int idx)
        {
            string recordID = Database.GetGlobalKey();
            string detailID = gridView.GetRowCellValue(idx, colDetailID).ToString();
            string lotNo = gridView.GetRowCellValue(idx,colLotNo).ToString();
            string sizeNo = gridView.GetRowCellValue(idx, colSizeNo).ToString();
            string shelfNo = gridView.GetRowCellValue(idx, colShelfNo).ToString();
            string datetime = gridView.GetRowCellValue(idx, colDateTime).ToString();
            string transferTo = gridView.GetRowCellValue(idx, colToShelfNo).ToString();

            int num = Convert.ToInt32(gridView.GetRowCellValue(idx, colQuantity));

            string sql = String.Format("Insert into T_OutboundRecord (RecordID, OutboundID, DetailID, ShelfNo, LotNo, SizeNo, NumofPlan, NumofReal, PlanDateTime, DealStatus ) "
                + " Values ( '{0}', '{1}','{2}', '{3}','{4}','{5}',{6},{7},'{8}','{9}')",
                recordID,
                OutboundID,
                detailID,
                shelfNo,
                lotNo,
                sizeNo,
                num,
                num,
                datetime,
                MemoryTable.BackBound );

            int nres = Database.ExecuteSQL(sql, "BackBoundDetailView-SaveBackboundDetail");

            sql = String.Format("Update T_OutboundRecord Set NumofPlan = NumofPlan - {0} , NumofReal = NumofReal - {0} "
                + "Where DetailID = '{1}' and LotNo = '{2}' and SizeNo = '{3}' and ShelfNo = '{4}' and DealStatus <> '{5}' ",
                num,
                detailID,
                lotNo,
                sizeNo,
                shelfNo,
                MemoryTable.BackBound);

            nres = Database.ExecuteSQL(sql, "BackBoundDetailView-SaveBackboundDetail");

            sql = String.Format("Update T_OutboundDetail Set NumofPlan = NumofPlan - {0} , NumofReal = NumofReal - {0} "
                + "Where DetailID = '{1}' and LotNo = '{2}' and SizeNo = '{3}' ",
                num,
                detailID,
                lotNo,
                sizeNo);
            nres = Database.ExecuteSQL(sql, "BackBoundDetailView-SaveBackboundDetail");

            string toShelfNo = transferTo;
            if (string.IsNullOrEmpty(toShelfNo))
                toShelfNo = shelfNo;

            bool bFind = FindInventory(lotNo, sizeNo, toShelfNo);
            if (bFind == true)
            {
                sql = String.Format("Update T_Inventory Set Quantity = Quantity + {0} where shelfNo = '{1}' and LotNo = '{2}' and sizeNo = '{3}'",
                    num,
                    toShelfNo,
                    lotNo,
                    sizeNo);
            }
            else
            {
                sql = String.Format("Insert Into T_Inventory (InventoryID,LotNo, SizeNo, ShelfNo, Quantity )"
                    + "VALUES ('{0}','{1}','{2}','{3}','{4}')",
                       Database.GetGlobalKey(), 
                       lotNo,
                       sizeNo, 
                       toShelfNo,
                       num );
            
            }

            nres = Database.ExecuteSQL(sql, "BackBoundDetailView-SaveBackboundDetail");

            if (OutboundKind == MemoryTable.Outbound_Kind_99T)
            {
                bFind = FindInventory(lotNo, sizeNo, MemoryTable.Shelf_99T99 );
                if (bFind == true)
                {
                    sql = String.Format("Update T_Inventory Set Quantity = Quantity - {0} where shelfNo = '{1}' and LotNo = '{2}' and sizeNo = '{3}'",
                    num,
                    MemoryTable.Shelf_99T99,
                    lotNo,
                    sizeNo);
                    nres = Database.ExecuteSQL(sql, "BackBoundDetailView-SaveBackboundDetail");
                }
            }

            return nres > 0 ? true : false;

        }

        private bool FindInventory(string lotno, string sizeno, string shelfno)
        { 
            string sql = string.Format("select * from t_inventory where LotNo = '{0}' and sizeNo = '{1}' and ShelfNo = '{2}'",
                lotno,
                sizeno,
                shelfno);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }
        #endregion

    }
}
