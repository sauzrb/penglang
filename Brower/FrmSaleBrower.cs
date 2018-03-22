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
    public partial class FrmSaleBrower : Form
    {
        SaleStatisticsView saleBrowerView;

        public FrmSaleBrower()
        {
            InitializeComponent();
            saleBrowerView = new SaleStatisticsView(this.resView);
        }

        private void FrmSaleBrower_Load(object sender, EventArgs e)
        {
            saleBrowerView.Initialize();
            cboArtNo.Properties.Items.Clear();
            for (int i = 0; i < MemoryTable.Instance.ListClothes.Count; i++)
            {
                cboArtNo.Properties.Items.Add(MemoryTable.Instance.ListClothes[i].LotNo);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSelection.Text.Trim() == "")
                return;
            
            saleBrowerView.ArtNo = txtSelection.Text.Trim();
            saleBrowerView.Loading();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string txt = txtInQnt.Text.Trim();

            int cnt = 0;

            bool bres = Int32.TryParse(txt, out cnt);
            if (bres == false)
                return;

            saleBrowerView.AddInboundCount( cnt );
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return;
            ExportSaleStatisticsiew exp = new ExportSaleStatisticsiew();
            exp.ArtNo = resView.GetRowCellValue(0,"LotNo").ToString();
            exp.Export(resView, fileDialog.FileName);

            if (System.IO.File.Exists(fileDialog.FileName))
                System.Diagnostics.Process.Start(fileDialog.FileName); 
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string artNo = cboArtNo.Text.Trim();
            string selNos = txtSelection.Text.Trim();
            if (selNos.IndexOf(artNo) < 0)
                txtSelection.Text += artNo + " ";
        }
    }
}
