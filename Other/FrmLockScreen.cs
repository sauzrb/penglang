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
    public partial class FrmLockScreen : Form
    {
        public FrmLockScreen()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == AppConfig.LoginUser.UserPsw)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnOK_Click(btnOK, new EventArgs());
        }
    }
}
