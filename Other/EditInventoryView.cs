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
    public class EditInventoryView : InventoryView
    {
        
        #region 视图初始化

        protected List<String> delList = new List<String>();

        protected string shelfNo = "";

        public bool bEdit = false;

        public EditInventoryView() 
        { 
        }

        public EditInventoryView(BandedGridView view)
        {
            base.SetGridView(view); 
        }
         
        protected override void InitGridView()
        {
            base.InitGridView();
            
            gridView.OptionsBehavior.Editable = true;    
            gridView.OptionsCustomization.AllowColumnMoving = false;
            
            gridView.IndicatorWidth = 30;

            gridView.OptionsSelection.InvertSelection = true;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;
             
            gridView.OptionsNavigation.AutoFocusNewRow = true; 

            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.ReadOnly = false;
           

            this.gridView.CellValueChanged += new CellValueChangedEventHandler(OnCellValueChanged);
            this.gridView.ValidateRow += new ValidateRowEventHandler(OnValidateRow);
            this.gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(OnValidatingEditor);
            this.gridView.InitNewRow += new InitNewRowEventHandler(this.OnInitNewRow);
            
        }

        protected override void CreateGridBand()
        {
            base.CreateGridBand();
             
        }
        
        protected override void CreateGridColumns()
        {
            base.CreateGridColumns();
             
            CreateLotNoCombo(); 
            
            colColor.OptionsColumn.AllowEdit = false; 
            colStyleNo.OptionsColumn.AllowEdit = false;
            colShelfNo.OptionsColumn.AllowEdit = false;

            colStyleNo.Width = 40;
            colColor.Width = 40;

            for (int i = gridView.Columns.Count - 1; i >= BeginSizeNoIndex; i--)
            {
                gridView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            }

        }

        #region Grid Repository
         
        private RepositoryItemComboBox comboLotNo;

        protected void CreateLotNoCombo()
        {
            comboLotNo = new RepositoryItemComboBox();
            comboLotNo.Name = "comboLotNo";
            comboLotNo.AutoHeight = true;

            List<Clothes> list = MemoryTable.Instance.ListClothes;
            for (int i = 0; i < list.Count; i++)
                comboLotNo.Items.Add(list[i].LotNo);

            colLotNo.ColumnEdit = comboLotNo;
        }
         
        #endregion

        #endregion
          
        #region 明细编辑

        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }

        public void OnInitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView.SetRowCellValue(e.RowHandle, "ShelfNo", shelfNo);
        }

        public void OnCellValueChanged(object sender, CellValueChangedEventArgs e)
        { 
            if (e.Column == colLotNo)
            {
                if (e.Value == null)
                    return;
                string lotno = e.Value.ToString();

                if (IsLotNoExist(lotno, e.RowHandle) == true)
                {
                    MsgBox.Error( "Art# 已存在!");
                    gridView.SetFocusedValue("");
                    return;
                }

                AutoCompleteClothes(lotno);

            }
             
            else if (e.Column.AbsoluteIndex >= BeginSizeNoIndex && e.Column.AbsoluteIndex <= EndSizeNoIndex)
            {
                int sum = GetSubTotal(e.RowHandle);
                gridView.SetFocusedRowCellValue(colSubTotal, sum);
            }

            bEdit = true;
        }

        public void OnValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
           
            ColumnTag tag = gridView.FocusedColumn.Tag as ColumnTag;
            if (tag == null || tag.DataType != ColumnTag.DataType_Integer)
                return;
            int num = 0, sum = 0;
            try
            {
                num = Convert.ToInt32(e.Value);
                string temp = gridView.GetFocusedRowCellValue(colSubTotal).ToString();
                if (string.IsNullOrEmpty(temp) == false)
                    sum = Convert.ToInt32(temp);
                sum += num;
                gridView.SetFocusedRowCellValue(colSubTotal, sum);
            }
            catch
            {
                e.ErrorText = "只能输入一个整数";
                e.Valid = false;
            }
        }

        public void OnValidateRow(object sender, ValidateRowEventArgs e)
        {
            string lotno = gridView.GetRowCellValue(e.RowHandle, colLotNo).ToString();

            if (String.IsNullOrEmpty(lotno))
            {
                e.ErrorText = "Art# 不能为空. ";
                e.Valid = false;
                return;
            }

            if (FindLotNo(lotno) == false)
            {
                e.ErrorText = "Art# 不存在. ";
                e.Valid = false;
                return;
            }

            if (IsLotNoExist(lotno, e.RowHandle) == true)
            {
                e.ErrorText = "Art# 已存在. ";
                e.Valid = false;
                return;
            }
            bEdit = true;
        }
 
        private Clothes GetClothes(string lotNo)
        {
           List<Clothes> list =  MemoryTable.Instance.ListClothes;

           for (int i = 0; i < list.Count; i++)
           {
               if( list[i].LotNo == lotNo )
                return list[i];
           }

           return null;
        }

        private void AutoCompleteClothes(string lotno)
        {
            Clothes clothes = GetClothes(lotno);
            if (clothes == null)
                return; 
            gridView.SetFocusedRowCellValue(colStyleNo, clothes.StyleNo);
            gridView.SetFocusedRowCellValue(colColor, clothes.Color); 
        }

        private bool FindLotNo(string lotno)
        { 
            List<Clothes> list = MemoryTable.Instance.ListClothes;

            for (int i = 0; i < list.Count; i++)
                if (lotno == list[i].LotNo)
                    return true;

            return false;
        }
         
        private bool IsLotNoExist(string lotno, int exceptRowHandle)
        { 
            for (int i = gridView.RowCount - 1; i >= 0; i--)
            {
                object obj = gridView.GetRowCellValue(i, colLotNo);
                if( obj ==null )
                    continue; 
                if (obj.ToString() == lotno && i != exceptRowHandle)
                    return true;
            }
            return false;
        }
 
        public void RemoveRows(int[] rowHandles)
        {
            if (rowHandles == null)
                return;
            string lotNo = "";
            for (int i = rowHandles.Length - 1; i >= 0; i--)
            {
                lotNo = gridView.GetRowCellValue(rowHandles[i], colLotNo).ToString();
               
                if (IsExistDB(shelfNo, lotNo) == true)
                    AddDeleteLotNo(lotNo);
                gridView.DeleteRow(rowHandles[i]);
            }

            bEdit = true;
        }

        public bool HasEdit()
        {
            return bEdit;
        }

        private bool IsExistDB(string shelfNo, string lotNo)
        {
            string sql = String.Format("Select SizeNo From T_Inventory where shelfNo = '{0}' and lotNo = '{1}' ",  shelfNo, lotNo);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return false;
            dt.Clear();
            return true;
        }

        public void SetShelfNo(string no)
        {
            shelfNo = no;
            if (dataTable == null || dataTable.Rows.Count == 0)
                return;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i]["ShelfNo"] = no;
            }

        }

        public void Cancel()
        {
            delList.Clear();
            ClearRows();
        }

        public void Save()
        {
            for (int i = 0; i < delList.Count; i++)
                DeleteInventory(shelfNo, delList[i]);

            delList.Clear();

            SaveInventoryDetail();
            ClearRows();
        }

        public void AddDeleteLotNo(string no)
        {
            for (int i = 0; i < delList.Count; i++)
            {
                if (delList[i] == no)
                    return;
            }

            delList.Add(no);

        }

        public void RemoveDeleteLotNo(string no)
        {
            for (int i = delList.Count - 1; i >= 0; i--)
            {
                if (delList[i] == no)
                {
                    delList.RemoveAt(i);
                    return;
                }
            }
        }

        #endregion

        #region 保存修改库存明细
 
        public void SaveInventoryDetail()
        { 
            int cnt = dataTable.Rows.Count; 
            for (int i = 0; i < cnt; i++)
            {
                SaveInventoryRow(i);
            }

            bEdit = false;
        }

        private void SaveInventoryRow(int idx )
        {
            DataRow dr = dataTable.Rows[idx];
            string shelfno = dr["ShelfNo"].ToString();
            string lotno = dr["LotNo"].ToString();
            string sizeNo = "";
            int cnt = dataTable.Columns.Count-1;
            
            int quantity = 0; 
            for (int i = BeginSizeNoIndex; i < cnt; i++)
            {
                sizeNo = dataTable.Columns[i].ColumnName;
                
                if (dr[i] == null || String.IsNullOrEmpty(dr[i].ToString()))
                    continue;
                quantity = Convert.ToInt32( dr[i] );
                
                if (quantity > 0)
                    UpdateInventory(shelfno, lotno, sizeNo, quantity);
                else
                    DeleteInventory(shelfno, lotno, sizeNo);
            }
        }
 
        private bool UpdateInventory(string shelfNo, string lotNo, string sizeNo, int quantity)
        {
            bool bres = true;
            string id = FindInventory(shelfNo, lotNo, sizeNo);
            if (String.IsNullOrEmpty(id))
            {
                bres = InsertInventory(shelfNo, lotNo, sizeNo, quantity);
            }
            else
            {
                bres = UpdateInventory(id, quantity);
            }

            return bres;
        }

        private bool InsertInventory(string shelfNo, string lotNo, string sizeNo, int quantity)
        {
            string id = Database.GetGlobalKey();

            string sql = String.Format("Insert into T_Inventory (InventoryID, ShelfNo, LotNo, SizeNo, Quantity ) "
                + "Values('{0}', '{1}', '{2}', '{3}', {4})",
                id,
                shelfNo,
                lotNo,
                sizeNo,
                quantity);

            int nres = Database.ExecuteSQL(sql, "EditInventoryView-InsertInventory");
            return nres == 1 ? true : false;
        }

        private bool UpdateInventory(string id, int Quantity)
        {
            string sql = String.Format("update T_Inventory Set Quantity = {0} where inventoryID = '{1}'", Quantity, id);

            int nres = Database.ExecuteSQL(sql, "EditInventoryView-UpdateInventory");

            return nres == 1 ? true : false;
        }

        private string FindInventory(string shelfNo, string lotNo, string sizeNo)
        {
            string sql = String.Format("Select InventoryID From T_Inventory where shelfNo = '{0}' and LotNo = '{1}' and sizeNo = '{2}'",
                shelfNo,
                lotNo,
                sizeNo);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return String.Empty;

            string id = dt.Rows[0][0].ToString();
            dt.Clear();
            return id;
        }

        private int GetShelfNoQuantity(string shelfNo)
        {
            string sql = String.Format("Select sum(Quantity) as cnt From T_Inventory where shelfNo = '{0}'", shelfNo);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return 0;

            string temp = dt.Rows[0][0].ToString();
            if (string.IsNullOrEmpty(temp))
                return 0;

            return Convert.ToInt32(temp);

        }
         
        public bool CheckShelfQuantity(out string tip)
        {
            Dictionary<string, int> dic = GetShelfDictionary();
            int  nnew=0 ,ndic = 0;
            tip = "";

            bool berror = false;

            foreach (string shelfno in dic.Keys )
            {
               // nold = GetShelfNoQuantity(shelfno);

                //网购库存不处理
                if (shelfno == MemoryTable.Shelf_99T99)
                    continue;

                nnew = dic[shelfno]   ;

                if (nnew > MemoryTable.Instance.ShelfCapacity)
                {
                    ndic = nnew - MemoryTable.Instance.ShelfCapacity;
                    tip += String.Format("{0}货架超出容量{1}件，",shelfno,ndic);
                    berror = true;
                }

                if (berror == true)
                    tip += "是否继续保存？";
            } 

            return berror ;
        }

        private Dictionary<string, int> GetShelfDictionary()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            Object obj = null;
            string shelfNo = "";
            int num = 0;

            for (int i = gridView.RowCount - 1; i >= 0; i--)
            {
                obj = gridView.GetRowCellValue(i, colShelfNo);
                if (obj == null || String.IsNullOrEmpty(obj.ToString() ) )
                    continue;
                shelfNo = gridView.GetRowCellValue(i, colShelfNo).ToString();
                num = Convert.ToInt32(  gridView.GetRowCellValue(i,colSubTotal)  );

                if (dic.ContainsKey(shelfNo) == false)
                {
                    dic.Add(shelfNo, num);
                    continue;
                }

                dic[shelfNo] += num;

            }
                
            return dic;
        }

        private bool DeleteInventory(string shelfNo, string lotNo)
        {
            string sql = String.Format("delete from T_Inventory where shelfNo = '{0}' and LotNo = '{1}'", shelfNo, lotNo);

            int nres = Database.ExecuteSQL(sql, "EditInventoryView-DeleteInventory");

            return nres >= 0 ? true : false; 
        }

        private int DeleteInventory(string shelfNo, string lotNo, string sizeNo)
        {
            string sql = String.Format("delete from T_Inventory where shelfNo = '{0}' and lotNo = '{1}' and sizeNo = '{2}'", shelfNo, lotNo, sizeNo);

            return Database.ExecuteSQL(sql, "EditInventoryView-DeleteInventory");
        }

        #endregion

        #region  加载数据

        public void LoadInventory()
        {
            dataTable.Rows.Clear();

            if (String.IsNullOrEmpty(shelfNo))
                return;
             
            string sql = String.Format("Select distinct LotNo  From T_Inventory where shelfNo = '{0}' and Quantity > 0  ",shelfNo );  
  
            sql += " order by LotNo ";

            DataTable dt = Database.Select(sql);
            if( dt == null || dt.Rows.Count ==0 )
                return;
            DataRow dr = null;
            string lotNo = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lotNo = dt.Rows[i][0].ToString();

                dr = dataTable.NewRow();
                dr["ShelfNo"] = shelfNo;
                dr["LotNo"] = lotNo;

                dataTable.Rows.Add(dr);
                AutoCompleteClothes(lotNo);
                LoadDetail(i, shelfNo, lotNo);
            }
        }

        private void LoadDetail(int rowHandle, string shelfNo, string lotNo)
        {
            for (int i = BeginSizeNoIndex; i <= EndSizeNoIndex; i++)
                gridView.SetRowCellValue(rowHandle, gridView.Columns[i], "");

            DataTable dt = null;

            string sql = String.Format("Select SizeNo,  Quantity  From T_Inventory where shelfNo = '{0}' and lotNo = '{1}' and Quantity > 0 ",
                shelfNo, lotNo) ;  
            sql += " order by SizeNo ";

            dt = Database.Select(sql);
            if( dt == null )
                return ; 
            string field = null;
            GridColumn column  = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                field = ToFieldName(dt.Rows[i]["SizeNo"].ToString()); 
                column = gridView.Columns.ColumnByFieldName(field);
                gridView.SetRowCellValue(rowHandle, column , Convert.ToUInt32(dt.Rows[i]["Quantity"]));
            }
        }
         
        private string ToFieldName (string sizeNo)
        {
            sizeNo = sizeNo.ToUpper();
            int idx = -1;
            string flag = "";
            if (sizeNo.IndexOf("L") > -1)
            {
                idx = sizeNo.IndexOf("L");
                flag = "L";
            }
            else if (sizeNo.IndexOf("R") > -1)
            {
                idx = sizeNo.IndexOf("R");
                flag = "R";
            }
            else
            {
                idx = sizeNo.IndexOf("S");
                flag = "S";
            }

            sizeNo = sizeNo.Remove(idx, 1);

            return flag + sizeNo;

        }
        
        #endregion
         
       
    }
}
