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
    public partial class FrmWoPrice : Form
    {
        public double WoPrice
        {
            get { return GetWoPrice(); }
        }

        public FrmWoPrice()
        {
            InitializeComponent();
        }

        private void FrmWoPrice_Load(object sender, EventArgs e)
        {
            //DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        public double GetWoPrice()
        {
            string temp = textBox.Text.Trim();

            double res = 0.0;

            res = Convert.ToDouble(temp);

            return res;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
