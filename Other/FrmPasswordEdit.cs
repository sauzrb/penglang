using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Sau.Util;

namespace PengLang
{
    public class FrmPasswordEdit //修改密码
    {
        private String userId;
        private String password;

        public String UserID {

            set { userId = value; }
        }

        public String Password {

            set { password = value; }
            get { return password; }
        }

        public DialogResult ShowDialog() {

            FrmPassword dlg = new FrmPassword();
            dlg.OldPassword = password;

            DialogResult ds = dlg.ShowDialog();
            if (ds == DialogResult.Cancel)
                return ds;

            password = dlg.Password;
            IEncrypt encrypt = new DESEncrypt();

            if (false == UserAdo.UpdatePsw(userId, encrypt.EncryptString( password) ) )
            {
                MsgBox.Error("修改密码失败");
                return DialogResult.Cancel;
            }
            AppConfig.LoginUser.UserPsw = password;
            return DialogResult.OK;
        }
        
    }
}
