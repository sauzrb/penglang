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
    class OutboundBrowerMasterView : InventoryView
    {
        public string FilterSql = String.Empty;

        public OutboundBrowerMasterView() 
        {
            this.LoadData = this.LoadInventory;
        }

        public OutboundBrowerMasterView(BandedGridView view)
        {
            base.SetGridView(view);
            this.LoadData = this.LoadInventory;
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
        
        private  DataTable LoadOuboundDetailData()
        {
            DataTable dt = null;

            string sql = "Select ShellNo,LotNo, SizeNo, Sum(NumOfReal) as Cnt From V_OutboundDetail";

            if (String.IsNullOrEmpty(FilterSql) == false)
                sql += FilterSql;
            sql += " Group by ShellNo, LotNo, SizeNo ";
            sql += " order by ShellNo, LotNo, SizeNo ";

            dt = Database.Select(sql);

            return dt;
        }
        
        private void LoadInventory()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();

            List<InventoryItem> list =  InventoryList;
            list.Clear();
            DataTable dt = LoadOuboundDetailData();

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
