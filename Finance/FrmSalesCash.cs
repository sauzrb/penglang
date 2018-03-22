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
    public partial class FrmSalesCash : Form
    {
        #region 类成员及属性

        SalesCashView saleCashView;

        public string TotalAmount 
        { 
            set { 
                txtAmount.Text = value;
                saleCashView.TotalAmount = Convert.ToDouble(value);
            }
        }

        public string RcvdDate {
            set { txtDate.Text = value; }
        }

        public string RcvdID
        {
            set { saleCashView.RcvdRecdID = value; }
        }

        public string RcvdKind
        {
            set { saleCashView.RcvdKind = value; }
        }
        #endregion

        #region 窗体构造及初始化

        public FrmSalesCash()
        {
            InitializeComponent();
            saleCashView = new SalesCashView(this.rcvdView);
            this.rcvdView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridView_KeyUp);
        }

        private void FrmSalesCash_Load(object sender, EventArgs e)
        {
            saleCashView.Initialize();
        }

        private void FrmSalesCash_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #endregion

        #region 增加、删除

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveRows();
            else if (e.KeyCode == Keys.Insert)
                InsertRow();
        }

        private void RemoveRows()
        {
            int[] rows = rcvdView.GetSelectedRows();

            if (MsgBox.Confirm("您确定要删除所有选中的记录吗？ ") == false)
                return;
            saleCashView.RemoveRows(rows);
            
        }

        private void InsertRow()
        {
            int pos = rcvdView.FocusedRowHandle;
            if (pos < -1)
                pos = 0;
            DataTable dt = rcvdGrid.DataSource as DataTable;
            DataRow dataRow = dt.NewRow();
            dt.Rows.InsertAt(dataRow, pos);

        }

        #endregion

        #region 支付确认

        private void btnPay_Click(object sender, EventArgs e)
        {

            if( false == ValidAmount())
                return;

            if (false == saleCashView.Save())
            {
                MsgBox.Error("删除数据出错！");
                return;

            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private bool ValidAmount()
        {
            string temp = string.Empty;
            double amout = 0.0;
            Object obj = null;
            for (int i = 0; i < rcvdView.RowCount; i++)
            {
                obj = rcvdView.GetRowCellValue(i, "RcvdAmount"); 
                if (obj == null)
                    continue;

                temp = obj.ToString();
                if (temp == "")
                    temp = "0.0";
                amout += Convert.ToDouble(temp);
            }
            double total = 0;
            double.TryParse(txtAmount.Text, out total);

            //if( amout > total )
            //{
            //    MsgBox.Error("分配金额总和超出了收款金额！");

            //    return false;
            //}
            return true;
        }
        
        #endregion
         

    }
}
