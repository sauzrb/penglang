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
    class InventoryMasterView : InventoryView
    { 
        public string FilterSql = string.Empty;
        public string KeyWords = string.Empty;

        public InventoryMasterView() 
        {
            this.LoadData = this.LoadInventory;
        }

        public InventoryMasterView(BandedGridView view)
        {
            base.SetGridView(view);
            this.LoadData = this.LoadInventory;
        }

        public override void Initialize()
        {
            base.Initialize();
              
        }

        protected override void InitGridView()
        {
            base.InitGridView();
            gridView.OptionsBehavior.Editable = false;   //是否允许用户编辑单元格

            
        }
       
        protected override void CreateGridBand()
        {
            base.CreateGridBand();
            base.bandShelfNo.Visible = false; 
        }
    
        protected override void CreateGridColumns()
        {
            base.CreateGridColumns();
            base.colShelfNo.Visible = false; 
        }
        
        private  DataTable LoadInventorMaster()
        {
            DataTable dt = null;

            string sql = "Select '0' as PoNo,LotNo, SizeNo, Sum(Quantity) as Cnt From V_Inventory";
             
            sql += GetSqlWhere(); 
             
            sql += " Group by LotNo, SizeNo ";
            sql += " order by LotNo, SizeNo ";

            dt = Database.Select(sql);

            return dt;
        }
        
        private string  GetSqlWhere( )
        {

            string sql = string.Format(" WHERE ShelfNo <> '{0}' ",MemoryTable.Shelf_99T99);
            if (String.IsNullOrEmpty(FilterSql)  ||  string.IsNullOrEmpty(KeyWords)  )
            {
                return sql;
            }

            sql += String.Format(" and {0} like '{1}%' ", FilterSql, KeyWords );
             
            return sql;
        }
       
        private void LoadInventory( )
        {
            if (dataTable != null)
                dataTable.Rows.Clear();

            List<InventoryItem> list =  InventoryList;
            list.Clear();
            DataTable dt = LoadInventorMaster();

            if (dt == null || dt.Rows.Count == 0)
                return;

            //将DataTable转换为ListItem
            string lotNo="", sizeNo="", curLotNo ="";
            int quantity = 0, sum = 0;

            InventoryItem item = null;
            DataRow dr = null;
            
            for (int i = 0, cnt = dt.Rows.Count ; i < cnt; i++)
            {
                dr = dt.Rows[i];
                curLotNo = dr["LotNo"].ToString();
                sizeNo = dr["SizeNo"].ToString(); 
                if (lotNo != curLotNo)
                {
                    item = new InventoryItem();
                    lotNo = curLotNo;
                    sum = 0;
                    item.LotNo = lotNo;
                    GetClothesData(item, lotNo);
                     
                    list.Add(item);
                }
                 
                quantity = Convert.ToInt32( dr["Cnt"] );
                sum += quantity;
                item.SubTotal = sum;
                item.Set(sizeNo, quantity);


            }

            for (int i = list.Count - 1; i >= 0; i--)
                list[i].GetTotal();
            
            dt.Clear();

        }

        private void GetClothesData(InventoryItem item, string lotNo)
        {
            int cnt = listClothes.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (listClothes[i].LotNo != lotNo)
                    continue;

                item.StyleNo = listClothes[i].StyleNo;
                item.Shell = listClothes[i].Shell;
                item.Model = listClothes[i].Model;
                item.Color = listClothes[i].Color;

                return;
            }
        }
    
        public void OnRowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == colShelfNo)
                return;
            if (e.Column == colLotNo)
                return; 
            if (e.Column == colStyleNo)
                return;
            if (e.Column == colColor)
                return; 
            if (e.Column == colSubTotal)
                return;
            if (String.IsNullOrEmpty(e.CellValue.ToString()))
                return;
            int cnt = Convert.ToInt32(e.CellValue);
            Color color = Color.Black;
            if (cnt <= MemoryTable.Instance.ClothesWarnCntLow || cnt >= MemoryTable.Instance.ClothesWarnCntUp)
                color = Color.Red;
            else
                color = Color.Black;
            
            e.Appearance.ForeColor = color;
        }

        public bool IsSizeNoColumn(GridColumn column)
        { 
            if (column.AbsoluteIndex >= BeginSizeNoIndex && column.AbsoluteIndex <= EndSizeNoIndex)
                return true;
            return false;
        }
    }
}
