using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using NPOI.HPSF;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util; 

using Sau.Util;

namespace PengLang
{
    public partial class FrmInventoryBrower : Form
    {
        InventoryBrowerView invtBrowerView;

        #region 窗体构造及初始化

        public FrmInventoryBrower()
        {
            InitializeComponent();
            invtBrowerView = new InventoryBrowerView(this.invtView);

        }
       
        private void InitFilterComboBox()
        {
            cboFilter.Properties.Items.Clear();

            cboFilter.Properties.Items.Add(new ItemTag("StyleNo", "Style#"));
            cboFilter.Properties.Items.Add(new ItemTag("ShellNo", "Lot#"));
            cboFilter.Properties.Items.Add(new ItemTag("LotNo", "Art#"));
            cboFilter.SelectedText = "Style#";
            cboFilter.SelectedIndex = 0;
        }
     
        private void FrmInventoryBrower_Load(object sender, EventArgs e)
        {
            InitFilterComboBox();

            invtBrowerView.Initialize();

            //单元格合并
            invtView.OptionsView.AllowCellMerge = true;

            for (int i = 0; i < invtView.Columns.Count; i++)
            {
                if(invtView.Columns[i].FieldName == "StyleNo" )
                    invtView.Columns[i].OptionsColumn.AllowMerge = DefaultBoolean.True;
                else
                    invtView.Columns[i].OptionsColumn.AllowMerge = DefaultBoolean.False;
            }
             

        }

        #endregion

        #region 统计1

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchInventory(1); 
        }

        private void txtKeyWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    SearchInventory(1);
            //}
        }
         
        private void SearchInventory(int statStyle )
        {
            if (cboFilter.Text.Trim().Length > 0)
            {
                ItemTag tag = cboFilter.SelectedItem as ItemTag;
                if (tag != null)
                {
                    invtBrowerView.FilterSql = tag.Key;
                }
            }

            invtBrowerView.KeyWords = txtKeyWords.Text.Trim();
            invtBrowerView.StatStyle = statStyle;
            invtBrowerView.Loading();
        }

        #endregion

        #region 统计2
        
        private void btnSearch2_Click(object sender, EventArgs e)
        {
            SearchInventory(2); 
        }
        
        #endregion


        #region 统计3

        private void btnSearch3_Click(object sender, EventArgs e)
        {
            SearchInventory(3); 
        }
        #endregion

        #region 统计4
        private void btnSearch4_Click(object sender, EventArgs e)
        {
            SearchInventory(4); 
        }
        #endregion

        #region 导出

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return;
            ExportInventoryBrowerView.Export(invtView, fileDialog.FileName) ;
             
            if (System.IO.File.Exists(fileDialog.FileName))
                System.Diagnostics.Process.Start(fileDialog.FileName); 
            
        }

        #endregion

         
    }

}