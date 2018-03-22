using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid; 
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
 
using Sau.Util;

namespace PengLang
{
    public partial class FrmInventory : DevExpress.XtraEditors.XtraForm, InnerForm
    {
         
        InventoryMasterView inventoryMasterView ;
        InventoryDetialView inventoryDetialView;
        InventoryDetialView shelfInventoryView;

        public FrmInventory()
        {
            InitializeComponent();

            InitFilterComboBox();
            inventoryMasterView = new InventoryMasterView(this.masterView);
            inventoryDetialView = new InventoryDetialView(this.detailView);
            shelfInventoryView = new InventoryDetialView(this.shelfView);

            splitContainer.Panel2.Height = 250;
            splitContainer.Collapsed = true;

            this.masterView.FocusedRowChanged += new FocusedRowChangedEventHandler(this.MasterView_FocusedRowChanged);
            this.masterView.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.MasterView_FocusedColumnChanged);
            this.masterView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.MasterView_RowCellStyle);
            
        }

        public void Loading()
        {
            if (Database.IsConnected())
            {
                ItemTag tag = cboFilter.SelectedItem as ItemTag;
                if (tag != null)
                {
                    inventoryMasterView.KeyWords = txtKeyWords.Text.Trim();
                    inventoryMasterView.FilterSql = tag.Key;
                }
                inventoryMasterView.Loading();
                shelfInventoryView.LoadShelfInventory(txtShelfNo.Text.Trim());
            }
        }

        private void FrmInventory_Load(object sender, EventArgs e)
        {
            inventoryMasterView.Initialize();
            inventoryDetialView.Initialize();
            shelfInventoryView.Initialize();

            if (Database.IsConnected())
            {
                ItemTag tag = cboFilter.SelectedItem as ItemTag;
                if (tag != null)
                {
                    inventoryMasterView.KeyWords = txtKeyWords.Text.Trim();
                    inventoryMasterView.FilterSql = tag.Key;
                }
                inventoryMasterView.Loading();
                shelfInventoryView.LoadShelfInventory(txtShelfNo.Text.Trim());
            }
        }
         
        
        #region 接口函数

        public void Save() { }
        public bool IsEdit() { return false; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        #endregion

        #region tpClothes

        private void InitFilterComboBox()
        {
            cboFilter.Properties.Items.Clear();

            cboFilter.Properties.Items.Add( new ItemTag( "StyleNo" , "Style#"));
            cboFilter.Properties.Items.Add( new ItemTag("ShellNo", "Lot#") );
            cboFilter.Properties.Items.Add(new ItemTag("LotNo", "Art#"));
            cboFilter.SelectedText = "Art#";
            cboFilter.SelectedIndex = 2;
        }

        private void btnHind_Click(object sender, EventArgs e)
        { 
            splitContainer.Collapsed = true;
        }
          
        private void panDetailMenu_Resize(object sender, EventArgs e)
        {
            lblInventoryDetail.Left = panDetailMenu.Width / 2 - lblInventoryDetail.Width / 2;
        }

        private void FilterInventory()
        {
            inventoryDetialView.ClearRows();
            ItemTag tag = cboFilter.SelectedItem as ItemTag;
            if (tag != null)
            {
                inventoryMasterView.KeyWords = txtKeyWords.Text.Trim();
                inventoryMasterView.FilterSql = tag.Key;
            }
            inventoryMasterView.Loading(); 

        }
       
        private void btnSearchLot_Click(object sender, EventArgs e)
        {
            FilterInventory();
        }

        private void txLotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FilterInventory();
            }
        }

        private void MasterView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            inventoryMasterView.OnRowCellStyle(sender, e);
        }

        private GridColumn FocusedColumn;
        private int FocusedRowHandle = -1;

        private void MasterView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            splitContainer.Collapsed = false;
            int rowHandle = masterView.FocusedRowHandle;
            if (rowHandle < 0 )
                return;
            if (e.FocusedColumn == null)
                return;

            FocusedColumn = e.FocusedColumn;

            string lotNo = masterView.GetFocusedRowCellValue("LotNo").ToString();
            if (inventoryMasterView.IsSizeNoColumn(FocusedColumn) == true)
            {

                string sizeNo =  FocusedColumn.FieldName ;
                inventoryDetialView.LoadInventory(lotNo, sizeNo);
            }
            else
                inventoryDetialView.LoadInventory(lotNo);

        }

        private void MasterView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            splitContainer.Collapsed = false;

            if (e.FocusedRowHandle < 0)
                return;
            FocusedRowHandle = e.FocusedRowHandle;
             
            string lotNo = masterView.GetFocusedRowCellValue("LotNo").ToString();
            if (FocusedColumn == null || inventoryMasterView.IsSizeNoColumn(FocusedColumn) == false)
            { 
                inventoryDetialView.LoadInventory(lotNo);
            }
            else
            { 
                string sizeNo = FocusedColumn.FieldName;
                inventoryDetialView.LoadInventory(lotNo, sizeNo);
            }

        }

        #endregion

        #region tpShelf

        private void btnSearchShelf_Click(object sender, EventArgs e)
        {
            shelfInventoryView.LoadShelfInventory(txtShelfNo.Text.Trim());
        }

        private void txtShelfNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( e.KeyChar == 13 )
                shelfInventoryView.LoadShelfInventory(txtShelfNo.Text.Trim());
        }

        #endregion

        #region 删除库存--按货架显示列表
     
        private void RemoveRows(GridView gridView, InventoryDetialView editView)
        {
            int[] rows = gridView.GetSelectedRows();

            if (MsgBox.Confirm("您确定要删除所有选中的库存数据吗？ ") == false)
                return;
            editView.RemoveRows(rows);
            
        }
        
        private void mnuDeleteShelf_Click(object sender, EventArgs e)
        {
            RemoveRows(shelfView,shelfInventoryView); 
            inventoryMasterView.Loading();
            inventoryDetialView.ClearRows();
        }
       
        private void ShelfView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveRows(shelfView, shelfInventoryView);
                inventoryMasterView.Loading();
                inventoryDetialView.ClearRows();
            }
        }
        
        #endregion

        #region 删除库存--按服装显示列表

        private void mnuDeleteClothes_Click(object sender, EventArgs e)
        {
            RemoveRows(detailView, inventoryDetialView);
            shelfInventoryView.LoadShelfInventory(txtShelfNo.Text.Trim());
            inventoryMasterView.Loading();
            inventoryDetialView.ClearRows();
        }

        private void DetialView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveRows(detailView, inventoryDetialView);
                shelfInventoryView.LoadShelfInventory(txtShelfNo.Text.Trim());
                inventoryMasterView.Loading();
                inventoryDetialView.ClearRows();
            }
        }
       
        private void AfterRemoveSizeNo(string lotNo, string sizeNo, int quantity)
        {
            int masterRowHandle = masterView.FocusedRowHandle;
            if (masterRowHandle < 0)
                return;

            string field = sizeNo.ToUpper();  

            Object objSum = masterView.GetFocusedRowCellValue("SubTotal");
            Object obj = masterView.GetFocusedRowCellValue(field);

            int num = 0, sum = 0;
            try
            {
                num = Convert.ToInt32(obj) - quantity;
                masterView.SetFocusedRowCellValue(field, num);

                sum = Convert.ToInt32(objSum) - quantity;
                masterView.SetFocusedRowCellValue("SubTotal", sum);
            }
            catch
            {
            }

        }

        #endregion

        #region 导出库存

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();       ///储存文件提示框类
            fileDialog.Title = "导出Excel";           ///标题
            fileDialog.Filter = "Excel (*.xls)|*.xls";      ///存储类型
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                ExportGridView.ExportDetail(this.masterView, fileDialog.FileName);

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        private void btnExport2_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                shelfGrid.ExportToXls(fileDialog.FileName);

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        #endregion
    }
}
