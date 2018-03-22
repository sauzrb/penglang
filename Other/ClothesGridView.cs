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
    public class ClothesGridView : BaseGridView
    {
        public string KeyWords = String.Empty;

        public ClothesGridView() { }
       
        public ClothesGridView(GridView view)
        {
            base.SetGridView(view);
        }

        #region GridColumn
      
        protected DevExpress.XtraGrid.Columns.GridColumn colClothesID;
        protected DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colStyleNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colModel;
        protected DevExpress.XtraGrid.Columns.GridColumn colShell; 
        protected DevExpress.XtraGrid.Columns.GridColumn colColor;
        protected DevExpress.XtraGrid.Columns.GridColumn colShellNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colPrice;
        protected DevExpress.XtraGrid.Columns.GridColumn colStyleRemark;
        protected DevExpress.XtraGrid.Columns.GridColumn colShowIndex; 

        #endregion

        protected override void InitGridView()
        {
            base.InitGridView();

            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsCustomization.AllowColumnMoving = true;
            gridView.OptionsNavigation.AutoFocusNewRow = true;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;

            //this.gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(OnValidatingEditor);

        }

        protected override void CreateGridColumns()
        {
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClothesID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStyleNo = new DevExpress.XtraGrid.Columns.GridColumn(); 
            this.colShell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShellNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStyleRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShowIndex = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] { 
            this.colClothesID, 
            this.colShowIndex,
            this.colStyleNo, 
            this.colShellNo,
            this.colShell,
            this.colLotNo,
            this.colColor, 
            this.colPrice,
            this.colStyleRemark  };
             
            // 
            // colClothesID
            // 
            this.colClothesID.Caption = "编号";
            this.colClothesID.FieldName = "ClothesID";
            this.colClothesID.Name = "colClothesID";
            this.colClothesID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colClothesID.Visible = false;
            this.colClothesID.Width = 1;
            // 
            // colShowIndex
            // 
            this.colShowIndex.Caption = "No.";
            this.colShowIndex.FieldName = "PONo";
            this.colShowIndex.Name = "colShowIndex";
            this.colShowIndex.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShowIndex.Visible = true;
            this.colShowIndex.Width = 60;
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
            // colStyleNo
            // 
            this.colStyleNo.Caption = "Style#";
            this.colStyleNo.FieldName = "StyleNo";
            this.colStyleNo.Name = "colStyleNo";
            this.colStyleNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStyleNo.Visible = true;
            this.colStyleNo.Width = 100;
            // 
            // colColor
            // 
            this.colColor.Caption = "Color";// "颜色";
            this.colColor.FieldName = "Color";
            this.colColor.Name = "colColor";
            this.colColor.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colColor.Visible = true;
            this.colColor.Width = 150;
            // 
            // colShell
            // 
            this.colShell.Caption = "Shell";// "成分";
            this.colShell.FieldName = "Shell";
            this.colShell.Name = "colShell";
            this.colShell.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShell.Visible = false;
            this.colShell.Width = 300;
            // 
            // colShellNo
            // 
            this.colShellNo.Caption = "Lot#";// 面料号;
            this.colShellNo.FieldName = "ShellNo";
            this.colShellNo.Name = "colShellNo";
            this.colShellNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShellNo.Visible = true;
            this.colShellNo.Width = 120;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Price";// 单价;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colPrice.Visible = true;
            this.colPrice.Width = 100;
            // 
            // colStyleRemark
            // 
            this.colStyleRemark.Caption = "Style Remark";// 单价;
            this.colStyleRemark.FieldName = "StyleRemark";
            this.colStyleRemark.Name = "colStyleRemark";
            this.colStyleRemark.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStyleRemark.Visible = false;
            this.colStyleRemark.Width = 150;
        }

        public override void Loading()
        {
            if (dataTable == null)
                return;
            if (gridView == null)
                return;

            WaitingService.BeginLoading();
            dataTable.Rows.Clear();

            if (LoadData != null)
                LoadData();

            string sql = String.Format("Select PONo, ClothesID, StyleNo, ShellNo, LotNo, Model, Color, Shell, Price, StyleRemark From T_Clothes  ");

            if (String.IsNullOrEmpty(KeyWords) == false)
            {
                sql += GetSqlWhere(KeyWords);
            }
            sql += " order by PONo,StyleNo, ShellNo, LotNo ";

            gridView.BeginUpdate();
            gridView.BeginDataUpdate();

            DataTable dt = Database.Select(sql);
            gridView.GridControl.DataSource = dt;

            gridView.EndDataUpdate();

            if (dt.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dt.Rows.Count.ToString().Length + 1) * 5;

            gridView.EndUpdate();

            WaitingService.EndLoading();
        }
        
        private string GetSqlWhere(string keywords)
        {
            String sql = " where " ;
            if (keywords.Length > 0)
            {
                sql = String.Format(" where LotNo like '{0}%' or StyleNo like  '{0}%' or ShellNo like '{0}%'   ",
                    keywords.Trim().Replace("'","''") );
                   
            }
            return sql;
        }

        public void RemoveRows(int[] rowHandles)
        {
            if (rowHandles == null)
                return;
            string artNo = "";
            for (int i = rowHandles.Length - 1; i >= 0; i--)
            {
                artNo = gridView.GetRowCellValue(rowHandles[i], colLotNo).ToString();
                if (RemoveClothes(artNo) == true)
                    gridView.DeleteRow(rowHandles[i]);
            }

        }

        private bool RemoveClothes(string artNo)
        { 
           string sql = String.Format("delete from T_Clothes where LotNo = '{0}'", artNo);
           return Database.ExecuteSQL(sql, "ClothesGridView-RemoveClothes") == 0 ? false : true;
        }

        public void InsertRow(int pos)
        {

            DataTable dt = gridView.GridControl.DataSource as DataTable;
            DataRow dataRow = dt.NewRow();
            dt.Rows.InsertAt(dataRow, pos);

        }

        public bool UpdateClothes(int rowHandle)
        {
            string sql = "";
            string lotNo = gridView.GetRowCellValue(rowHandle, colLotNo).ToString();
            string styleNo = gridView.GetRowCellValue(rowHandle, colStyleNo).ToString();
            string color = gridView.GetRowCellValue(rowHandle, colColor).ToString();
            string shell = gridView.GetRowCellValue(rowHandle, colShell).ToString();
            string shellno = gridView.GetRowCellValue(rowHandle, colShellNo).ToString();
            string price = gridView.GetRowCellValue(rowHandle, colPrice).ToString();
            string showno = gridView.GetRowCellValue(rowHandle, colShowIndex).ToString();

            if (string.IsNullOrEmpty(price))
                price = "0.0";
            sql = String.Format("Update T_Clothes Set StyleNo = '{0}', Color='{1}', Shell='{2}',ShellNo='{3}', Price = {4} , PONo = '{5}' where LotNo = '{6}'",
                styleNo,
                color,
                shell,
                shellno,
                price,
                showno,
                lotNo);
            return Database.ExecuteSQL(sql, "ClothesGridView-UpdateClothes") == 1 ? true : false;
        }

        public string AddClothes(int rowHandle)
        {
            string sql = "", keystr;
            string lotNo = gridView.GetRowCellValue(rowHandle, colLotNo).ToString(); 
            string styleNo = gridView.GetRowCellValue(rowHandle, colStyleNo).ToString();
            string color = gridView.GetRowCellValue(rowHandle, colColor).ToString();
            string shell = gridView.GetRowCellValue(rowHandle, colShell).ToString();
            string shellno = gridView.GetRowCellValue(rowHandle, colShellNo).ToString();
            string price = gridView.GetRowCellValue(rowHandle, colPrice).ToString();
            string showno = gridView.GetRowCellValue(rowHandle, colShowIndex).ToString();

            if (string.IsNullOrEmpty(price))
                price = "0.0";
            keystr = Database.GetGlobalKey();
            sql = String.Format("Insert into T_Clothes (ClothesID, LotNo, styleNo, color, shell,ShellNo,Price,PONo ) "
                + "Values('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}')", 
                keystr,
                lotNo,
                styleNo,
                color,
                shell,
                shellno,
                price,
                showno);

            if (Database.ExecuteSQL(sql, "ClothesGridView-AddClothes") <= 0)
                return string.Empty;

            string styleRemark = GetClothStyle(styleNo);
            styleRemark = styleRemark.Trim();
            if (string.IsNullOrEmpty(styleRemark) == false)
                UpdateStyleRemark(styleNo, styleRemark);

            return keystr ;
        }
      
        public bool FindLotNo(string lotNo)
        {
            string sql = String.Format("select LotNo from t_clothes where LotNo = '{0}'", lotNo);
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            else
                return true;
        }

        public bool FindClothesExcept(string lotNo, string exceptClothesID)
        {
            string sql = String.Format("select LotNo from t_clothes where LotNo = '{0}' and ClothesID <> '{1}'", lotNo,exceptClothesID );
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            else
                return true;
        }

        private string GetClothStyle(string styleNo)
        {
            string sql = string.Format("Select StyleRemark from t_clothes where styleNo='{0}' and StyleRemark <> '' ", styleNo);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count ==0 )
                return "";

            string res = dt.Rows[0][0].ToString();
            dt.Clear();

            return res;
        }

        private bool UpdateStyleRemark(string styleNo, string styleRemark )
        {
            string sql = string.Format("update t_clothes  set styleremark = '{0}' where styleno = '{1}'", styleRemark, styleNo);
            int nres = Database.ExecuteSQL(sql, "ClothesGridView-UpdateStyleRemark");
            return nres >= 0 ? true : false;
        }

        //public void OnValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        //{
        //    if (gridView.FocusedColumn != colShowIndex)
        //        return;
        //    int rowHandle = gridView.FocusedRowHandle;
        //    try
        //    {
        //        int num = Convert.ToInt32(e.Value);
        //    }
        //    catch
        //    {
        //        e.ErrorText = "只能输入一个整数";
        //        e.Valid = false;
        //    }
        //}

    }
}
