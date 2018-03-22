using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using DevExpress.UserSkins;
//using DevExpress.Skins;
//using DevExpress.LookAndFeel;

using Sau.Util;

namespace PengLang
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //AppUpdater.AutoUpdate();
               
            
            if (false == AppConfig.ConnectDatabase())
            {
                MsgBox.Error("连接数据库失败");
                return;
            }

            if (AppLicense.License == false)
                return;

            FrmLogin dlgLogin = new FrmLogin();
            if (dlgLogin.ShowDialog() == DialogResult.Cancel)
                return;

            //BonusSkins.Register();
            //SkinManager.EnableFormSkins();
            //UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");//Office 2010 Blue
            Application.Run(new FrmMain());
        }


    }
}
