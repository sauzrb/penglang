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
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using Sau.Util;

namespace PengLang
{
    public partial class FrmRcvdEdit : Form
    {
        public GridView RcvdGridView = null;
        private string boundId = string.Empty;
        private string recId = string.Empty;
        private string amount = string.Empty;
        private OutboundRcvd item = new OutboundRcvd();

        public FrmRcvdEdit()
        {
            InitializeComponent();
        }

        private void FrmRcvdEdit_Load(object sender, EventArgs e)
        {
            if (RcvdGridView == null) return;
            GridView rcvdView = RcvdGridView;
            int sel = rcvdView.FocusedRowHandle;
            boundId = rcvdView.GetRowCellValue(sel, "OutboundID").ToString();
            recId = rcvdView.GetRowCellValue(sel, "RecordID").ToString();
            amount = rcvdView.GetRowCellValue(sel, "RcvdAmount").ToString();
            txtPoNo.Text = rcvdView.GetRowCellValue(sel, "OutboundNo").ToString();
            txtSales.Text = rcvdView.GetRowCellValue(sel, "Sales").ToString();
            cboPayOff.Text = rcvdView.GetRowCellValue(sel, "PayOff").ToString();
            txtRcvdAmt.Text = rcvdView.GetRowCellValue(sel, "RcvdAmount").ToString();
            txtRemark.Text = rcvdView.GetRowCellValue(sel, "Remark").ToString();
            item = LoadOutbounds(boundId);
            txtInvAmt.Text = item.InvoiceAmount.ToString("f2");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string tmp = txtRcvdAmt.Text.Trim();

            if (txtRcvdAmt.Text.Trim() == "")
                return;
            double val = 0.0;
            if (double.TryParse(tmp, out val) == false)
            {
                MsgBox.Error("数据格式不正确！");
                return;
            }
            
            if (val < 0)
            {
                MsgBox.Error("不能输入负数！");
                return;
            }

            bool bres = Save();
            if (bres == false)
            {
                MsgBox.Error("保存数据出错！");
                return;
            }
           
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        
        private OutboundRcvd LoadOutbounds(string outboundId )
        {
           OutboundRcvd item = new OutboundRcvd();
            string sql = string.Format("select OutboundID,Sales , OrderNo, (PriceAmount + Freight) as InvAmt, RcvdAmount from V_OutboundCash "
                       + " where PriceAmount > 0  and ShipDate <>'' and OutboundID = '{0}'", outboundId );
            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return item;
            
            string temp = "";
            int i = 0, col = 0;
           
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

            return item;     
        }

        private void txtRcvdAmt_TextChanged(object sender, EventArgs e)
        {
        }

        private bool Save()
        { 
            string amount = txtRcvdAmt.Text.Trim();
            if (amount == "")
                amount = "0.0";
            string remark = txtRemark.Text.Trim();
            string payoff = "";

            if (cboPayOff.Text.ToString() == "YES")
                payoff = "YES";
            else
                payoff = "";

            string sql = string.Format("update T_RcvdRecord set RcvdAmount='{0}',DecmDate = '{1}' ,Remark = '{2}'"
                + " where RecordID = '{3}' ",
                amount,
                DateTime.Now.ToString("yyyy-MM-dd"),
                remark.Replace("'", "''"),
                recId);

            int nres = 0;
            nres = Database.ExecuteSQL(sql, "FrmRcvdEdit-Save");
            if (nres > 0)
            {
                UpdateOutboundPayOff(boundId,payoff );
                RcvdGridView.BeginUpdate();
                int sel = RcvdGridView.FocusedRowHandle;
                RcvdGridView.SetRowCellValue(sel, "RcvdAmount", amount);
                RcvdGridView.SetRowCellValue(sel, "PayOff", payoff);
                RcvdGridView.SetRowCellValue(sel, "Remark", remark);
                RcvdGridView.EndUpdate();
            }
            return true;
        }

        private bool UpdateOutboundPayOff(string outboundId, string payoff)
        {
            string sql = string.Format("update t_outbound  set payoff = '{0}' where outboundid = '{1}'",
                payoff,
                outboundId);

            return Database.ExecuteSQL(sql, "FrmRcvdEdit--UpdateOutboundPayOff") > 0 ? true : false;
        }
    }
}
