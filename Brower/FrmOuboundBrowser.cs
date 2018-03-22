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
    public partial class FrmOutboundBrowser : Form
    {
        OutboundBrowerMasterView outboundBrowerMasterView;
        OutboundBrowerDetailView outboundBrowerDetailView;

        #region 窗体构造、初始化

        public FrmOutboundBrowser()
        {
            InitializeComponent();
            outboundBrowerMasterView = new OutboundBrowerMasterView(this.masterView);
            outboundBrowerDetailView = new OutboundBrowerDetailView(this.detailView);
            splitCtrl.Panel2.Height = 250;
            splitCtrl.Collapsed = true;

            this.masterView.FocusedRowChanged += new FocusedRowChangedEventHandler(this.MasterView_FocusedRowChanged);
            this.masterView.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.MasterView_FocusedColumnChanged);

        }

        private void FrmOutboundBrowser_Load(object sender, EventArgs e)
        {
            InitFilterComboBox();
            outboundBrowerMasterView.Initialize();
            outboundBrowerDetailView.Initialize();
            //if (Database.IsConnected())
            //{
            //    outboundBrowerMasterView.FilterSql = GetFilterSql();
            //    outboundBrowerMasterView.Loading(); 
            //}
        }
        
        private void InitFilterComboBox()
        {
            cboFilter.Properties.Items.Clear();
            cboFilter.Properties.Items.Add(new ItemTag("OrderNo", "P.O#"));
            cboFilter.Properties.Items.Add(new ItemTag("LotNo", "Art#"));
            cboFilter.Properties.Items.Add(new ItemTag("Sales", "Sales"));
            cboFilter.SelectedText = "P.O#";
            cboFilter.SelectedIndex = 0;
        }

        #endregion

        private string GetFilterSql()
        {
            string sql = " where 1=1 ";

            if (dateBegin.Text.Length > 0)
                sql += String.Format(" and ShipDate >= '{0}' ", dateBegin.DateTime.ToString("yyyy-MM-dd"));
            if (dateEnd.Text.Length > 0)
                sql += String.Format(" and ShipDate <= '{0}'", dateEnd.DateTime.ToString("yyyy-MM-dd"));

            string val = txtKeyWords.Text.Trim();
            if (cboFilter.Text.Trim().Length > 0 && val.Length > 0 )
            {
                ItemTag tag = cboFilter.SelectedItem as ItemTag;
                if (tag == null)
                    return sql;
                sql += String.Format(" and {0} like '{1}%'",tag.Key, val);
            } 
            return sql;
        }

        private void btnFilterOutbound_Click(object sender, EventArgs e)
        {
            Loadding();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            Loadding();
        }

        public void Loadding()
        {
            outboundBrowerDetailView.ClearRows();
            FilterSql = GetFilterSql();
            outboundBrowerMasterView.FilterSql = FilterSql;
            outboundBrowerMasterView.Loading();
        }

        private GridColumn FocusedColumn;
        private int FocusedRowHandle = -1;
        private String FilterSql = string.Empty;

        private void MasterView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            splitCtrl.Collapsed = false;
            int rowHandle = masterView.FocusedRowHandle;
            if (rowHandle < 0)
                return;
            if (e.FocusedColumn == null)
                return;

            FocusedColumn = e.FocusedColumn;
            outboundBrowerDetailView.FilterSql = GetFilterSql();
            string lotNo = masterView.GetFocusedRowCellValue("LotNo").ToString();
            if (outboundBrowerMasterView.IsSizeNoColumn(FocusedColumn) == true)
            {

                string sizeNo = FocusedColumn.FieldName;
                outboundBrowerDetailView.LoadOutboundDetail(lotNo, sizeNo);
            }
            else
                outboundBrowerDetailView.LoadOutboundDetail(lotNo);

        }

        private void MasterView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            splitCtrl.Collapsed = false;

            if (e.FocusedRowHandle < 0)
                return;
            FocusedRowHandle = e.FocusedRowHandle;
            outboundBrowerDetailView.FilterSql = GetFilterSql();
            string lotNo = masterView.GetFocusedRowCellValue("LotNo").ToString();
            if (FocusedColumn == null || outboundBrowerMasterView.IsSizeNoColumn(FocusedColumn) == false)
            {
                outboundBrowerDetailView.LoadOutboundDetail(lotNo);
            }
            else
            {
                string sizeNo = FocusedColumn.FieldName;
                outboundBrowerDetailView.LoadOutboundDetail(lotNo, sizeNo);
            }

        }

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
                            
    }
}
