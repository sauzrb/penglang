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
    public partial class FrmCashBrower : Form
    {
        CashBrowerView cashBrowerView ;
        CashRecordView cashRecordView ;

        #region 窗体构造及初始化

        public FrmCashBrower()
        {
            InitializeComponent(); 
            cashBrowerView = new CashBrowerView(this.cashView);
            cashRecordView = new CashRecordView(this.rcvdView);
        }

        private void FrmCashBrower_Load(object sender, EventArgs e)
        {
            cashBrowerView.Initialize();
            cashRecordView.Initialize();

            InitFilterComboBox();
             
        }
        
        private void InitFilterComboBox()
        {
            cboFilter.Properties.Items.Clear();

            cboFilter.Properties.Items.Add(new ItemTag("OrderNo", "P.O#"));
            cboFilter.Properties.Items.Add(new ItemTag("Sales", "SALES"));
            cboFilter.Properties.Items.Add(new ItemTag("PaymentMode", "PAYMENT MODE"));
            cboFilter.Properties.Items.Add(new ItemTag("SellTo", "SELL TO"));
            cboFilter.SelectedText = "Sales";
            cboFilter.SelectedIndex = 1;

        }
        
        #endregion

        #region 查询

        private void btnSearch_Click(object sender, EventArgs e)
        {
           

            cashBrowerView.OutboundFilterSql = GetOutboundSqlFilter();

            if (dateBegin.Text.Length > 0)
                cashBrowerView.BeginDate = dateBegin.DateTime.ToString("yyyy-MM-dd");
            if (dateEnd.Text.Length > 0)
                cashBrowerView.EndDate = dateEnd.DateTime.ToString("yyyy-MM-dd");

            cashBrowerView.Loading();
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

                sql += String.Format(" ({0} like '{1}%') ", tag.Key, cboKeyWords.Text.Trim().Replace("'","''"));
            }

            return sql;
        }

        private void cboKeyWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cashBrowerView.OutboundFilterSql = GetOutboundSqlFilter();

                if (dateBegin.Text.Length > 0)
                    cashBrowerView.BeginDate = dateBegin.DateTime.ToString("yyyy-MM-dd");
                if (dateEnd.Text.Length > 0)
                    cashBrowerView.EndDate = dateEnd.DateTime.ToString("yyyy-MM-dd");

                cashBrowerView.Loading();
            }
        }
        
        #endregion

        #region 主表格视图事件

        private void cashView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Object obj =  cashView.GetRowCellValue(e.FocusedRowHandle, "OutboundID");
            if (obj == null)
            {
                cashRecordView.ClearRows();
                return;
            }
            string outboundId = obj.ToString();
            cashRecordView.OutboundID = outboundId;
            cashRecordView.LoadOutboundRcvdRecord();
        }
     
        private void cashView_DoubleClick(object sender, EventArgs e)
        {

           // ReciveAmount();

        }
     
        #endregion

        #region 收款

        //收款
        private void btnCash_Click(object sender, EventArgs e)
        {
            
        } 
        #endregion

        #region 收款明细右键菜单

        private void ctxMenu_Opening(object sender, CancelEventArgs e)
        {
            if (rcvdView.FocusedRowHandle < 0)
            {
                e.Cancel = true;
                return;
            }
        }
  
        private void ctxmDelete_Click(object sender, EventArgs e)
        {
            DeleteRcvdRecord();
        }

        private void DeleteRcvdRecord()
        { 
            string recId = rcvdView.GetRowCellValue(rcvdView.FocusedRowHandle, "RecordID").ToString();
            string amount = rcvdView.GetRowCellValue(rcvdView.FocusedRowHandle, "RcvdAmount").ToString();

            string sql = string.Format("delete from T_RcvdRecord where recordID = '{0}'", recId);

            if (false == MsgBox.Confirm("您确定要删除选中的收款记录吗？"))
                return;

            if (Database.ExecuteSQL(sql, "FrmCashBrower, DeleteRcvdRecord") <= 0)
            {
                MsgBox.Error("删除数据失败！");
                return;
            }

            rcvdView.DeleteRow(rcvdView.FocusedRowHandle);

            string srcvd = "0", sbalance = "0";
            Object obj = cashView.GetFocusedRowCellValue("RcvdAmount");
            if(obj != null && string.IsNullOrEmpty(obj.ToString() ) == false )
                srcvd = obj.ToString();

            obj = cashView.GetFocusedRowCellValue("Balance");
            if (obj != null && string.IsNullOrEmpty(obj.ToString()) == false)
                sbalance = obj.ToString();

            double ftemp = Convert.ToDouble(amount);
            double frcvd = Convert.ToDouble(srcvd);
            double fbalance = Convert.ToDouble(sbalance);
            cashView.SetFocusedRowCellValue("RcvdAmount", ( frcvd - ftemp ).ToString("f2"));
            cashView.SetFocusedRowCellValue("Balance", (fbalance + ftemp).ToString("f2"));

            FrmTip.ShowTip("删除数据成功！");
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

                ExportOutboundCash exp = new ExportOutboundCash();
                exp.gridView = cashView;
                exp.Export(fileDialog.FileName);

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        #endregion

    }
}
