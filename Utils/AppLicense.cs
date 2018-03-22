using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sau.Util;

namespace PengLang
{
    public class AppLicense
    {
        public static string VersFlag = "-1";
        public static string VersDate = "";

        public static bool License
        {
            get {
                if (VersFlag == "-1")
                    GetAppLicense();

                return VersFlag == "9999";
            }

        }

        private static bool GetAppLicense()
        {
            string sql = "select codetype, codevalue, userdefine1, userdefine2, userdefine3 from t_systemcode where codeid = '0' ";
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            DataRow dr = dt.Rows[0];

            VersFlag = dr["codevalue"].ToString();
            VersDate = dr["userdefine1"].ToString();

            dt.Clear();
            if (VersFlag == "9999")
               return true;
            return false;
        }

    }
}
