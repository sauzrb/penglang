using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sau.Util;

namespace PengLang
{
    public partial class FrmCommission : Form
    {
        CommissionBrowerView comBrowerView = null;

        #region 窗体构造及初始化

        public FrmCommission()
        {
            InitializeComponent();

            comBrowerView = new CommissionBrowerView(this.commView);
        }

        private void FrmCommission_Load(object sender, EventArgs e)
        {
            comBrowerView.Initialize();

            SetMonthDate(DateTime.Now.Year, DateTime.Now.Month);

            cboSales.Properties.Items.Clear(); 
            MemoryTable.Instance.LoadSales();

            for (int i = 0; i < MemoryTable.Instance.SalesList.Count; i++)
            {
                if (MemoryTable.Instance.SalesList[i].ToUpper() == "NO" || string.IsNullOrEmpty( MemoryTable.Instance.SalesList[i].Trim()) )
                    continue;
                cboSales.Properties.Items.Add(MemoryTable.Instance.SalesList[i]);
            }

        }

        private void SetMonthDate(int year, int month)
        {
            int day = 31;

            if (month == 2)
            {
                day = 28;
                if (IsLeap(year))
                    day += 1;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
                day = 30;

            string begin = string.Format("{0}-{1}-{2}", year, month, "01");
            string end = string.Format("{0}-{1}-{2}", year, month, day);

            dateBegin.Text = begin;
            dateEnd.Text = end;

        }

        public bool IsLeap(int yN)
        {

            if ((yN % 400 == 0 && yN % 3200 != 0)
                || (yN % 4 == 0 && yN % 100 != 0)
                || (yN % 3200 == 0 && yN % 172800 == 0))
                return true;
            else
                return false;

        }

        #endregion

        #region 查询

        private void btnSearch_Click(object sender, EventArgs e)
        {
            comBrowerView.Sales = cboSales.Text.Trim();
            comBrowerView.BeginDate = dateBegin.DateTime.ToString("yyyy-MM-dd");
            comBrowerView.EndDate = dateEnd.DateTime.ToString("yyyy-MM-dd");
            comBrowerView.Loading();
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

                ExportCommissionBrower exp = new ExportCommissionBrower();
                exp.BeginDate = dateBegin.Text;
                exp.EndDate = dateEnd.Text;
                exp.Export(commView, fileDialog.FileName);

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        #endregion

        #region 支付

        private void btnPay_Click(object sender, EventArgs e)
        {
            //将操作单状态设置为完成

            int cnt = comBrowerView.GetCheckedRowCount();
            if (cnt == 0)
            {
                MsgBox.Infometion("请先选择需要支付的记录！");
                return;
            }

            string outboundId = string.Empty;
            string time = string.Empty;
            object obj = null;
            commView.BeginUpdate();

            for (int i = 0; i < commView.RowCount; i++)
            {
                if (GetChecked(i) == false)
                    continue;
                obj = commView.GetRowCellValue(i, "OutboundID");
                if (obj == null)
                    continue;
                outboundId = obj.ToString();
                time = Database.GetDateTimeString();
                UpdateCommissionStatus(outboundId, time ,"yes");
                commView.SetRowCellValue(i, "CommPaid", "yes"); 
            }

            commView.EndUpdate();
        }

        private bool GetChecked(int rowHandle)
        {
            string value = commView.GetRowCellValue(rowHandle, "CheckStatus").ToString();
            if (value == "True")
                return true;
            return false;
        }

        private void UpdateCommissionStatus(string outboundID, string time, string status )
        { 
            string sql = string.Format("Update T_Outbound  set Commission = '{0}'  where OutboundID='{1}'",
                status, 
                outboundID);
            Database.ExecuteSQL(sql, "FrmCommission-UpdateCommissionStatus");
        }

        #endregion

        #region 右键菜单

        private void ctxMenuRecord_Opening(object sender, CancelEventArgs e)
        {
            if (commView.RowCount == 0)
                e.Cancel = true;


        }
        private void mnuCheckAll_Click(object sender, EventArgs e)
        {
            comBrowerView.CheckAll();
        }

        private void mnuNoCheck_Click(object sender, EventArgs e)
        {
            comBrowerView.UnCheck();
        }

        private void mniUnPay_Click(object sender, EventArgs e)
        {
            int cnt = comBrowerView.GetCheckedRowCount();
            if (cnt == 0)
            {
                MsgBox.Infometion("请先选择需要取消支付的记录！");
                return;
            }

            string outboundId = string.Empty;
            string time = string.Empty;


            commView.BeginUpdate();

            for (int i = 0; i < commView.RowCount; i++)
            {
                if (GetChecked(i) == false)
                    continue;

                outboundId = commView.GetRowCellValue(i,"OutboundID").ToString();
                time = Database.GetDateTimeString();
                UpdateCommissionStatus(outboundId, time, "");
                commView.SetRowCellValue(i, "Commission", "");
            }

            commView.EndUpdate();
        }

        #endregion

    }
}
