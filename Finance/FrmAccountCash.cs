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
    public partial class FrmAccountCash : Form
    {
       
        public FrmAccountCash()
        {
            InitializeComponent();
            dateRcvt.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void FrmCash_Load(object sender, EventArgs e)
        {

        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            if ((int)e.KeyChar != 46)                           //小数点
                return;
            //小数点的处理。
            if (textbox.Text.Length <= 0)
                e.Handled = true;   //小数点不能在第一位
            else                                             //处理不规则的小数点
            {
                float f;
                float oldf;
                bool b1 = false, b2 = false;
                b1 = float.TryParse(textbox.Text, out oldf);
                b2 = float.TryParse(textbox.Text + e.KeyChar.ToString(), out f);
                if (b2 == false)
                {
                    if (b1 == true)
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (false == Valid())
                return;
            bool bres = SaveRcvdAmount();

            if (bres == false)
            {
                MsgBox.Error("保存数据失败，请与系统管理员联系！");
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private bool Valid()
        {

            if (dateRcvt.Text.Trim().Length < 0)
            {
                MsgBox.Error("请输入收款日期！");
                return false;
            }

            string sAmount = txtAmount.Text.Trim();
            if (string.IsNullOrEmpty(sAmount))
                sAmount = "0.0";
           
            double famout = Convert.ToDouble(sAmount);
                       
            if ( famout <=0.0 )
            {
                MsgBox.Error("您确定输入的金额不正确！"); 
                    return false;
            }

            return true;
        }

        private bool SaveRcvdAmount()
        {
            string fee = "0.0";
            if(string.IsNullOrEmpty( txtFactFee.Text ) == false )
                fee = txtFactFee.Text;

            string sAmount = txtAmount.Text.Trim();
            if (string.IsNullOrEmpty(sAmount))
                sAmount = "0.0";

            string sql = string.Format(" Insert into T_RcvdAmount (SerialNo, RcvdDate, RcvdAmount,RcvdKind,FactFee, Remark ) "
                + " Values ( '{0}','{1}','{2}','{3}' ,'{4}','{5}')",
                Database.GetGlobalKey(),
               dateRcvt.DateTime.ToString("yyyy-MM-dd"),
               sAmount,
               cboRvdKind.Text.Replace("'", "''"),
               fee,
               txtRemark.Text.Replace("'","''"));

            return Database.ExecuteSQL(sql, "FrmCash-SaveRcvdAmount") > 0 ? true : false;
        }

    }
}
