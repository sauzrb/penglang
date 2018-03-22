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
    public partial class FrmSelectOperator : Form
    {
        public String OperatorName
        {
            get { return edtOperator.Text; }
            set { edtOperator.Text = value; }
        }

        public FrmSelectOperator()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void edtOperator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
           
        }
    }
}
