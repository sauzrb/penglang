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
using DevExpress.XtraGrid.Views.Grid; 
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraReports;
using Sau.Util;

namespace PengLang
{
    public partial class FrmInvoice : DevExpress.XtraEditors.XtraForm, InnerForm
    {
        InvoiceSelectionView invoiceSelectionView;
        InvoiceEditView invoiceEditView;

        #region 窗体构造与初始化

        public FrmInvoice()
        {
            InitializeComponent();

            InitFilterComboBox();

            invoiceSelectionView = new InvoiceSelectionView(this.outboundView);
            invoiceEditView = new InvoiceEditView(this.editView);
 
            outboundView.RowCellClick += new RowCellClickEventHandler(outBoundView_CellClick);
        }

        private void FrmInvoice_Load(object sender, EventArgs e)
        {
            splitContainer.IsSplitterFixed = true;
            xtraTab.ShowTabHeader = DefaultBoolean.False;

            btnPrev.Enabled = false;
            btnPrint.Enabled = false;
            btnNext.Enabled = false;
            btnExport.Enabled = true;

            invoiceSelectionView.Initialize();
            invoiceEditView.Initialize();

            dateBegin.Focus();
        }

        private void InitFilterComboBox()
        {
            cboFilter.Properties.Items.Clear();

            cboFilter.Properties.Items.Add(new ItemTag("Sales", "SELL TO"));
            cboFilter.Properties.Items.Add(new ItemTag("Sales", "SALES"));
            cboFilter.SelectedText = "SALES";
            cboFilter.SelectedIndex = 1;
        }

        #endregion

        #region 接口函数

        public void Save() { }
        public bool IsEdit() { return false; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        #endregion

        #region 界面状态

        private int CurrentStatus = 0;
        const int Status_Outbound = 0; //出库单查询 
        const int Status_Preview = 1; //打印预览  
        
        private void InitUI_Search(bool bFlag)
        {
            btnSearch.Visible = bFlag;
            btnExport.Enabled = true;

            lblBeginDate.Visible = bFlag;
            lblEndDate.Visible = bFlag;
            dateBegin.Visible = bFlag;
            dateEnd.Visible = bFlag;
             
            lblFilter.Visible = bFlag;
            cboFilter.Visible = bFlag; 

            lblKeyWords.Visible = bFlag;
            cboKeyWords.Visible = bFlag;
        }

        private void InitUI_OutBound()
        { 
            tpOutband.PageVisible = true;
            tpPreview.PageVisible = false;
             
            btnPrint.Enabled = false;
            btnPrev.Enabled = false;
            btnNext.Enabled = true;
            btnExport.Enabled = true;

            InitUI_Search(true);
        }

        private void InitUI_Preview()
        {
            tpOutband.PageVisible = false;
            tpPreview.PageVisible = true;

            btnPrev.Enabled = true;
            btnNext.Enabled = false;
            btnPrint.Enabled = true;
            btnExport.Enabled = true;

            InitUI_Search(false);
        }

        #endregion

        #region 按钮事件

        private void btnPrev_Click(object sender, EventArgs e)
        {
            InitUI_OutBound();
            CurrentStatus = Status_Outbound;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (invoiceSelectionView.GetCheckedRowCount() == 0)
            {
                MsgBox.Infometion("请选择要打印发票的出库单。");
                return;
            }
            invoiceEditView.GetSelectionOutbound(invoiceSelectionView);
            InitUI_Preview();
            CurrentStatus = Status_Preview;
        }

        #endregion

        #region 检索

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Loadding();
        }

        private string GetFilterSql_Sale()
        {
            string sql = " where 1=1 ";

            if (dateBegin.Text.Length > 0)
                sql += String.Format(" and ShipDate >= '{0}' ", dateBegin.DateTime.ToString("yyyy-MM-dd"));
            if (dateEnd.Text.Length > 0)
                sql += String.Format(" and ShipDate <= '{0}'", dateEnd.DateTime.ToString("yyyy-MM-dd"));

            if (cboFilter.Text.Trim().Length > 0 && cboKeyWords.Text.Trim().Length > 0)
            {
                ItemTag tag = cboFilter.SelectedItem as ItemTag;
                if (tag == null)
                    return sql;

                sql += String.Format(" and {0} like '{1}%'",  tag.Key, cboKeyWords.Text.Trim());
            }
              
            return sql;
        }

        private string GetFilterSql_Back()
        {
            string sql = " where 1=1 ";

            if (dateBegin.Text.Length > 0)
                sql += String.Format(" and OrderDate >= '{0}' ", dateBegin.DateTime.ToString("yyyy-MM-dd"));
            if (dateEnd.Text.Length > 0)
                sql += String.Format(" and OrderDate <= '{0}'", dateEnd.DateTime.ToString("yyyy-MM-dd"));

            if (cboFilter.Text.Trim().Length > 0 && cboKeyWords.Text.Trim().Length > 0)
            {
                ItemTag tag = cboFilter.SelectedItem as ItemTag;
                if (tag == null)
                    return sql;
                string key = tag.Key;
                if(tag.Key == "CustomerNo")
                    key = "Customer";
                sql += String.Format(" and {0} like '{1}%'", key, cboKeyWords.Text.Trim());
            }

            return sql; 
        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Loadding();
            }

        }

        public void Loadding()
        {
            invoiceSelectionView.FilterSql_Outbound = GetFilterSql_Sale();
            invoiceSelectionView.FilterSql_Backbound = GetFilterSql_Back();

            invoiceSelectionView.Loading();
        }

        #endregion

        #region 选择

        private void ctxMenuBound_Opening(object sender, CancelEventArgs e)
        {
            if (outboundView.RowCount == 0)
                e.Cancel = true;
        }

        private void mnuCheckAll_Click(object sender, EventArgs e)
        {
            invoiceSelectionView.CheckAll();
            int cnt = invoiceSelectionView.GetCheckedRowCount();
            if (cnt == 0)
                btnNext.Enabled = false;
            else
                btnNext.Enabled = true;
        }

        private void mnuNoCheck_Click(object sender, EventArgs e)
        {
            invoiceSelectionView.UnCheck();
            int cnt = invoiceSelectionView.GetCheckedRowCount();
            if (cnt == 0)
                btnNext.Enabled = false;
            else
                btnNext.Enabled = true;
        }

        private void outBoundView_CellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "CheckStatus")
            {
                bool bcheck = Convert.ToBoolean(outboundView.GetFocusedValue());
                outboundView.SetFocusedValue(!bcheck);
            }

            int cnt = invoiceSelectionView.GetCheckedRowCount();
            if (cnt == 0)
                btnNext.Enabled = false;
            else
                btnNext.Enabled = true;
        }
        
        #endregion

        #region 编辑

        private void mnuInsertRow_Click(object sender, EventArgs e)
        {
           invoiceEditView.InsertRow();
        }

        private void mnuDeleteRow_Click(object sender, EventArgs e)
        {
            invoiceEditView.RemoveRows();
        }

        private void ctxMenuEdit_Opening(object sender, CancelEventArgs e)
        {
            int[] rows = editView.GetSelectedRows();
            if (rows == null || rows.Length == 0)
                mnuDeleteRow.Enabled = false;
            else
                mnuDeleteRow.Enabled = true;
        }

        #endregion

        #region 打印、导出

        private void PrintGrid(GridControl grid)
        {
            string tempFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";
            
            string customer = GetCustomerNo();
            string strDate = GetOrderDate();
            ExportInvoice.ExportInvioceTotal(editView, customer, strDate, tempFile);

            if (System.IO.File.Exists(tempFile))
                System.Diagnostics.Process.Start(tempFile);  
        }

        private void PrintGrid_ExA(GridControl grid )
        { 
            PrintingSystem print = new DevExpress.XtraPrinting.PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(print);
             
            print.Links.Add(link);
            link.Component = grid;//这里可以是可打印的部件

            PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
            phf.Header.Content.Clear();
            phf.Header.Content.AddRange(new string[] { "", "", "" });
            phf.Header.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold);
            phf.Header.LineAlignment = BrickAlignment.Center;

            link.CreateDocument(); //建立文档
            print.PreviewFormEx.Show();//进行预览

        }

        private void ExportGrid()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            { 
                string customer = GetCustomerNo();
                string strDate = GetOrderDate();

                ExportInvoice.ExportInvioceTotal(editView, customer, strDate, fileDialog.FileName);

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName);
            }
        }

        private void ExportPreviewGrid()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                //DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                //outboundGrid.ExportToXls(fileDialog.FileName);
                ExportInvoice.ExportInvoiceSelection(outboundView, fileDialog.FileName );

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
 
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (CurrentStatus == Status_Outbound)
                ExportPreviewGrid();
            else
                ExportGrid(); 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintGrid(editGrid);
        }

        private string GetCustomerNo()
        {
            Object obj;
            String res; 
            for (int i = 0; i < outboundView.RowCount; i++)
            {
                obj = outboundView.GetRowCellValue(i,"Customer");
                if(obj == null)
                    continue;
                res = obj.ToString();
                if( String.IsNullOrEmpty( res ) )
                    continue;

                return obj.ToString();
            }
            return "";
        }

        private string GetOrderDate()
        {
            Object obj;
            String res;
            for (int i = 0; i < outboundView.RowCount; i++)
            {
                obj = outboundView.GetRowCellValue(i, "OrderDate");
                if (obj == null)
                    continue;
                res = obj.ToString();
                if (String.IsNullOrEmpty(res))
                    continue;

                return obj.ToString();
            }
            return "";
        }
        #endregion

    }
}
