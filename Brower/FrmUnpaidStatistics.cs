using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PengLang
{
    public partial class FrmUnpaidStatistics : Form
    {
        UnpaidOutboundView unpaidView = null;

        public FrmUnpaidStatistics()
        {
            InitializeComponent();
            unpaidView = new UnpaidOutboundView(this.resView);
        }

        private void FrmUnpaidStatistics_Load(object sender, EventArgs e)
        {
            //dateBegin.Text = DateTime.Today.ToShortDateString();
            //dateEnd.Text = DateTime.Today.ToShortDateString();
            
            unpaidView.Initialize();
            
            MemoryTable.Instance.LoadSales();

            InitFilterComboBox();
        }

        private void InitFilterComboBox()
        {
            cboFilter.Properties.Items.Clear();

            cboFilter.Properties.Items.Add(new ItemTag("Sales", "SALES"));
            cboFilter.Properties.Items.Add(new ItemTag("PaymentMode", "PAYMENT MODE"));
            cboFilter.Properties.Items.Add(new ItemTag("Receiver", "SELL TO"));
            cboFilter.SelectedText = "SALES";
            cboFilter.SelectedIndex = 0;

        }
     
        #region 查询

        private void btnSearch_Click(object sender, EventArgs e)
        {
            unpaidView.OutboundFilterSql = GetOutboundSqlFilter();
            if (string.IsNullOrEmpty(dateBegin.Text) == false)
                unpaidView.BeginDate = dateBegin.DateTime.ToString("yyyy-MM-dd");
            else
                unpaidView.BeginDate = string.Empty;
            if (string.IsNullOrEmpty(dateEnd.Text) == false)
                unpaidView.EndDate = dateEnd.DateTime.ToString("yyyy-MM-dd");
            else
                unpaidView.EndDate = string.Empty;

            unpaidView.Loading();
        }


        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboKeyWords.Properties.Items.Clear();
            ItemTag tag = cboFilter.SelectedItem as ItemTag;
            if (tag.Key == "PaymentMode")
            {
                cboKeyWords.Properties.Items.AddRange(MemoryTable.Instance.PaymentArray);
            }
            else if (tag.Key == "Sales")
            {
                cboKeyWords.Properties.Items.AddRange(MemoryTable.Instance.SalesList);
            }
        }

        private string GetOutboundSqlFilter()
        {
            string sql = string.Empty;
            if (cboFilter.Text.Trim().Length > 0 && cboKeyWords.Text.Trim().Length > 0)
            {
                ItemTag tag = cboFilter.SelectedItem as ItemTag;
                if (tag == null)
                    return sql;

                sql += String.Format(" ({0} like '{1}%') ", tag.Key, cboKeyWords.Text.Trim().Replace("'", "''"));
            }

            return sql;
        }

        private void cboKeyWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                unpaidView.OutboundFilterSql = GetOutboundSqlFilter();

                if (string.IsNullOrEmpty(dateBegin.Text) == false)
                    unpaidView.BeginDate = dateBegin.DateTime.ToString("yyyy-MM-dd");
                else
                    unpaidView.BeginDate = string.Empty;
                if (string.IsNullOrEmpty(dateEnd.Text) == false)
                    unpaidView.EndDate = dateEnd.DateTime.ToString("yyyy-MM-dd");
                else
                    unpaidView.EndDate = string.Empty;

                unpaidView.Loading();
            }
        }
        
        #endregion


        #region 导出

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                //DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                //cashGrid.ExportToXls(fileDialog.FileName);

                ExportOutboundUnpaid exp = new ExportOutboundUnpaid();
                exp.gridView = resView;
                exp.Export( fileDialog.FileName);

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        #endregion
    }
}
