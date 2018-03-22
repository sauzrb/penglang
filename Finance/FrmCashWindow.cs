using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

using Sau.Util;

namespace PengLang
{
    public partial class FrmCashWindow : Form
    {
        #region 窗体构造及初始化

        CashRecordView cashRecordView;

        public FrmCashWindow()
        {
            InitializeComponent();
            cashRecordView = new CashRecordView(this.rcvdView);
        }

        private void FrmCashWindow_Load(object sender, EventArgs e)
        {
            InitGridView();
            cashRecordView.Initialize();

            btnCash.Enabled = false;
            btnCheck.Enabled = false;

            if (AppConfig.LoginUser.UserKind == User.UserKind_Admin || AppConfig.LoginUser.UserKind == User.UserKind_Sales)
            {
                btnCheck.Enabled = true;  
            }

            if (AppConfig.LoginUser.UserKind == User.UserKind_Admin || AppConfig.LoginUser.UserKind == User.UserKind_Accnt)
            {
                btnCash.Enabled = true;
            }
        }

        private void FrmCashWindow_Resize(object sender, EventArgs e)
        {
            splitContainer.Panel1.Width = this.Width / 2;
        }
       
        #endregion

        #region  表格初始化

        private void InitGridView()
        {
            GridView gridView = masterView;
            gridView.BeginInit();
            gridView.OptionsView.ColumnAutoWidth = false;
            //修改附加选项
            gridView.OptionsView.ShowColumnHeaders = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            gridView.OptionsView.ColumnAutoWidth = true;

            gridView.Appearance.OddRow.BackColor = Color.White;
            gridView.Appearance.EvenRow.BackColor = Color.LightCyan;

            gridView.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(this.OnCustomDrawRowIndicator);

            gridView.OptionsBehavior.Editable = false;           //是否允许用户编辑单元格
            gridView.OptionsCustomization.AllowColumnMoving = false;
            gridView.IndicatorWidth = 30;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;

            gridView.EndInit();
        }
        //自增行号
        protected void DrawRowIndicator(RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString(System.Globalization.CultureInfo.InvariantCulture);
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = Color.AntiqueWhite;
                    // e.Info.DisplayText = "G" + e.RowHandle;
                    e.Info.DisplayText = e.RowHandle.ToString();
                }
            }
        }

        protected void OnCustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            DrawRowIndicator(e);
        }

        #endregion

        #region 加载数据

        private void Loading()
        {
            cashRecordView.ClearRows();

            string beginDate = dateBegin.DateTime.ToString("yyyy-MM-dd");
            string endDate = dateEnd.DateTime.ToString("yyyy-MM-dd");

            string sql = "Select SerialNo, RcvdDate, RcvdAmount,RcvdKind ,(DecmAmount-RcvdAmount) as FactFee,  DecmAmount, Remark From V_RcvdAmount Where RcvdAmount >0 ";
            if (string.IsNullOrEmpty(dateBegin.Text) == false)
                sql += string.Format(" AND RcvdDate >= '{0}'", beginDate);
            if (string.IsNullOrEmpty(dateEnd.Text) == false)
                sql += string.Format("AND RcvdDate <= '{0}'", endDate);

            sql += " Order by RcvdDate desc ";

            DataTable dt = Database.Select(sql);

            masterGrid.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Loading();
        }

        #endregion

        #region 财务收款

        private void btnCash_Click(object sender, EventArgs e)
        {
            FrmAccountCash dlg = new FrmAccountCash();
            if (DialogResult.Cancel == dlg.ShowDialog())
                return;

            Loading();
        }

        #endregion

        #region  右键菜单事件 FocusedRowChanged

        private void masterGrid_Click(object sender, EventArgs e)
        {
            int nRow = masterView.FocusedRowHandle;
            if(nRow < 0)
                return;
            Object obj = masterView.GetRowCellValue(nRow, colSerialNo);
            if (obj == null)
            {
                cashRecordView.ClearRows();
                return;
            }
            string serialNo = obj.ToString();
            cashRecordView.LoadCashRcvdRecord(serialNo);
        }
      
        private void ctxMaster_Opening(object sender, CancelEventArgs e)
        {
            if (masterView.FocusedRowHandle < 0)
            {
                e.Cancel = true;
                return;
            }

            if (AppConfig.LoginUser.UserKind == User.UserKind_Admin || AppConfig.LoginUser.UserKind == User.UserKind_Accnt)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void ctxRcvd_Opening(object sender, CancelEventArgs e)
        {
            if (rcvdView.FocusedRowHandle < 0)
            {
                e.Cancel = true;
                return;
            }
            if (AppConfig.LoginUser.UserKind == User.UserKind_Admin || AppConfig.LoginUser.UserKind == User.UserKind_Accnt)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void mnuRcvdDelete_Click(object sender, EventArgs e)
        {
            DeleteRcvdRecord();
        }

        private void mnuRcvdEdit_Click(object sender, EventArgs e)
        {
            DoEditRcvdRecord();
        }

        private void mnuMasterDelete_Click(object sender, EventArgs e)
        {
            DeleteRvcdAmount();
        }

        private bool UpdateOutboundPayOff(string outboundId, string payoff)
        {
            string sql = string.Format("update t_outbound  set payoff = '{0}' where outboundid = '{1}'",
                payoff,
                outboundId);

            return Database.ExecuteSQL(sql, "FrmCashWindow--UpdateOutboundPayOff") > 0 ? true : false;

        }

        private void DeleteRcvdRecord()
        {
            string boundId = rcvdView.GetRowCellValue(rcvdView.FocusedRowHandle, "OutboundID").ToString();
            string recId = rcvdView.GetRowCellValue(rcvdView.FocusedRowHandle, "RecordID").ToString();
            string amount = rcvdView.GetRowCellValue(rcvdView.FocusedRowHandle, "RcvdAmount").ToString();
            double fAmout = 0.0;
            double.TryParse(amount, out fAmout);

            string sql = string.Format("delete from T_RcvdRecord where recordID = '{0}'", recId);

            if (false == MsgBox.Confirm("您确定要删除选中的收款记录吗？"))
                return;

            if (Database.ExecuteSQL(sql, "FrmCashWindow, DeleteRcvdRecord") <= 0)
            {
                MsgBox.Error("删除数据失败！");
                return;
            }

            UpdateOutboundPayOff(boundId, "");

            rcvdView.DeleteRow(rcvdView.FocusedRowHandle);

            string decm = masterView.GetFocusedRowCellValue("DecmAmount").ToString();
            double fDecm = 0.0;
            double.TryParse(decm, out fDecm);

            masterView.BeginUpdate();
      
            masterView.SetRowCellValue(masterView.FocusedRowHandle, "DecmAmount", (fDecm - fAmout).ToString("f2"));

            masterView.EndUpdate();

            FrmTip.ShowTip("删除数据成功！");


        }

        private void DeleteRvcdAmount()
        {
            string recId = masterView.GetRowCellValue(masterView.FocusedRowHandle, colSerialNo).ToString();
            
            string sql = string.Format("delete from T_RcvdRecord where RcvdRecdID = '{0}'", recId);
            int cnt = 0;
            cnt = rcvdView.RowCount;
            if (cnt > 0 && false == MsgBox.Confirm("该收款记录已经分到具体的出库单了，您确定要删除选中的收款记录吗？"))
                return;
            if (cnt ==0 && false == MsgBox.Confirm("您确定要删除选中的收款记录吗？"))
                return;

            Database.ExecuteSQL(sql, "FrmCashWindow, DeleteRvcdAmount");

            sql = string.Format("delete from T_RcvdAmount where serialNo = '{0}'", recId);

            if (Database.ExecuteSQL(sql, "FrmCashWindow, DeleteRvcdAmount")  <= 0 )
            {
                MsgBox.Error("删除数据失败！");
                return;
            }
            cashRecordView.ClearRows();
            masterView.DeleteRow(masterView.FocusedRowHandle);

            FrmTip.ShowTip("删除数据成功！");
        }

        #endregion

        #region 销售认领

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (masterView.FocusedRowHandle < 0)
            {
                MsgBox.Infometion("请选择一条收款记录！");
                return;
            }
            string rcvdId = masterView.GetFocusedRowCellValue("SerialNo").ToString();
            string rcvdDate = masterView.GetFocusedRowCellValue("RcvdDate").ToString();
            string amount = masterView.GetFocusedRowCellValue("RcvdAmount").ToString();
            string decm = masterView.GetFocusedRowCellValue("DecmAmount").ToString();
            string rcvdKind = masterView.GetFocusedRowCellValue("RcvdKind").ToString();

            double fTotal = Convert.ToDouble(amount);
            double fDecm = 0.0;
            double.TryParse(decm, out fDecm);

            //if (fTotal <= fDecm)
            //{
            //    MsgBox.Infometion("该收款记录已认领完成！");
            //    return;
            //}

            FrmSalesCash dlg = new FrmSalesCash();
            dlg.RcvdDate = rcvdDate;
            dlg.RcvdID = rcvdId;
            dlg.RcvdKind = rcvdKind;
            dlg.TotalAmount =  (fTotal - fDecm).ToString("f2");

            if (DialogResult.OK != dlg.ShowDialog())
                return;
            masterView.BeginUpdate();
            decm = GetDecmAmount(rcvdId);
            masterView.SetRowCellValue(masterView.FocusedRowHandle,"DecmAmount", decm);
            masterView.EndUpdate();
        }

        private string GetDecmAmount(string id)
        {
            string sql = string.Format("select sum(RcvdAmount) as DecmAmount From T_RcvdRecord where RcvdRecdID = '{0}'", id);

            DataTable dt = Database.Select(sql);
            if (dt == null)
                return "0.0";

            return dt.Rows[0][0].ToString();
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
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                masterGrid.ExportToXls(fileDialog.FileName);

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }

        }

        #endregion

        #region 编辑修改领款明细

        private List<OutboundRcvd> LoadOutbounds()
        {
            List<OutboundRcvd> list = new List<OutboundRcvd>();
            string sql = "select OutboundID,Sales , OrderNo, (PriceAmount + Freight) as InvAmt, RcvdAmount from V_OutboundCash ";
            sql += " where PriceAmount > 0  and Sales <> 'NO' and ShipDate <>'' Order By OrderNo ";
            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return list;
            OutboundRcvd item = null;
            string temp = "";
            for (int i = 0, col = 0; i < dt.Rows.Count; i++)
            {
                col = 0;
                temp = dt.Rows[i][1].ToString();
                if (string.IsNullOrEmpty(temp.Trim()))
                    continue;

                item = new OutboundRcvd();
                item.OutboundId = dt.Rows[i][col++].ToString();
                item.Sales = dt.Rows[i][col++].ToString();
                item.OutboundNo = dt.Rows[i][col++].ToString();

                temp = dt.Rows[i][col++].ToString();
                if (string.IsNullOrEmpty(temp) == false)
                    item.InvoiceAmount = Convert.ToDouble(temp);

                temp = dt.Rows[i][col++].ToString();
                if (string.IsNullOrEmpty(temp) == false)
                    item.RcvdAmount = Convert.ToDouble(temp);

                item.BalanceAmount = item.InvoiceAmount - item.RcvdAmount;
                //靠PayOff = “yes”
                if (item.BalanceAmount <= 0.0)
                    continue;

                list.Add(item);
            }

            return list;
        }

        private void rcvdView_DoubleClick(object sender, EventArgs e)
        {
            DoEditRcvdRecord();
        }
      
        private void DoEditRcvdRecord()
        {
            string aOld = rcvdView.GetRowCellValue(rcvdView.FocusedRowHandle, "RcvdAmount").ToString();
            double fAmoutOld = 0.0;
            double.TryParse(aOld, out fAmoutOld);


            FrmRcvdEdit dlg = new FrmRcvdEdit();
            dlg.RcvdGridView = rcvdView;
            if(DialogResult.OK != dlg.ShowDialog() )
                return ;

            string aNew = rcvdView.GetRowCellValue(rcvdView.FocusedRowHandle, "RcvdAmount").ToString();
            double fAmoutNew = 0.0;
            double.TryParse(aNew, out fAmoutNew);

            string decm = masterView.GetFocusedRowCellValue("DecmAmount").ToString();
            double fDecm = 0.0;
            double.TryParse(decm, out fDecm);

            masterView.BeginUpdate();

            masterView.SetRowCellValue(masterView.FocusedRowHandle, "DecmAmount", (fDecm - fAmoutOld + fAmoutNew ).ToString("f2"));

            masterView.EndUpdate();

            FrmTip.ShowTip("修改数据成功！");
        }

        #endregion

    }
}
