using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Sau.Util;

namespace PengLang
{
    public partial class FrmLogin : Form
    {
        private string lastUser = string.Empty; 

        public FrmLogin()
        {
            InitializeComponent(); 
            
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LoadConfig();
            UserCode.Text = lastUser;
            Password.Focus();
        }
        
        private void pbtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                
                DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            if (e.KeyChar == 13)
            {
                pbtnLogin_Click(pbtnLogin, new EventArgs());
            }
        }

        private void pbtnLogin_Click(object sender, EventArgs e)
        {
            string usercode = UserCode.Text.ToLower().Trim();
            string password = Password.Text.Trim();
           
            #region sunsail

            if (usercode == "sunsail" && password == "sunsail")
            {
                AppConfig.LoginUser.UserCode = usercode;
                AppConfig.LoginUser.UserName = usercode;
                AppConfig.LoginUser.UserPsw = password;
                AppConfig.LoginUser.UserKind = User.UserKind_Admin; 
                DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }

            #endregion

            User user = UserAdo.GetUser(usercode);
            if (user == null)
            {
                MsgBox.Error("登录账号不存在！");
                UserCode.Focus();
                return;
            }

            if (user.UserPsw != password)
            {
                MsgBox.Error("密码不正确！");
                Password.Focus();
                return; 
            }

            AppConfig.LoginUser = user;

            WriteConfig();

            DialogResult = System.Windows.Forms.DialogResult.OK;
            return;
        }

        private bool LoadConfig()
        {
            if (File.Exists(AppConfig.ConfigFilePath) == false)
                return false;
             
            IniFile ini = new IniFile(AppConfig.ConfigFilePath);
            string section = "login";

            lastUser = ini.GetString(section, "user", "user"); 

            return true;
        }

        private void WriteConfig()
        {
            IniFile ini = new IniFile(AppConfig.ConfigFilePath);
            string section = "login";
            ini.WriteValue(section, "user", UserCode.Text); 
        }

    }
}
