using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sau.Util;

namespace PengLang
{
    public class AppConfig
    { 
        public static User LoginUser = new User();
                
        public static Company CompanyInfo = new Company();

        public static bool ConnectDatabase()
        {
            Database.Host = "localhost";//"123.57.232.240";
            Database.Port = "3306";
            Database.Inst = "mysql";
            Database.User = "root";
            Database.Psw = "ssaa";// "sxy20150802";
            Database.DbName = "penglan3";
            Database.CharSet = "gb2312";

            if (false == Database.Connect())
            {
                MsgBox.Error("数据库连接失败！");
                return false;
            }

            return true;
        }

        public static bool GetCompanyInfo()
        {
            CompanyInfo = CompanyAdo.LoadComanyInfo();

            return true;
        }
         
        public static string GetTempDirectory()
        {
            string path = Application.StartupPath + "\\temp";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); 
            }
            return path+"\\";
        }

        public static void DeleteTempDirectory()
        {
            bool IsOpen = false;
             string path = Application.StartupPath + "\\temp";
             if (System.IO.Directory.Exists(path))
             {
                 DirectoryInfo dir = new DirectoryInfo(path);
                 if (dir.Exists)
                 {
                     DirectoryInfo[] childs = dir.GetDirectories();
                     foreach (DirectoryInfo child in childs)
                     {
                         if (FileStatus.FileIsOpen(child.FullName) == 0)
                             child.Delete(true);
                         else
                             IsOpen = true;
                     }
                     if (IsOpen == false && childs.Length >0)
                        dir.Delete(true);
                 }
             }
        }

        public static string ConfigFilePath
        {
            get { return Application.StartupPath + "\\config.ini"; }
        }

    }

    public class AppEditStatus
    {
        public static int InboundCurrentStatus = 0;
        public static int OutboundCurrentStatus = 0;
        public static int TranboundCurrentStatus = 0;

        public const int InboundCompleteStatus = 4;
        public const int OutboundCompleteStatus = 1;
        public const int TranboundCompleteStatus = 1;
    
    }
}
