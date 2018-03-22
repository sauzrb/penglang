using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sau.Util;
namespace PengLang
{
    public class User
    {
        public const int UserKind_Admin = 1;
        public const int UserKind_Sales = 2;
        public const int UserKind_Accnt = 3;
        public const int UserKind_Other = 0;

        public string UserCode="";
        public string UserName="";
        public string UserPsw=""; 
        public int UserKind = UserKind_Other;

        public bool IsSunSail()
        {
            if (UserCode == "sunsail")
                return true;
            return false;
        }

        public static string GetUserKindName(int no)
        {
            switch (no)
            {
                case UserKind_Admin: return "管理员";
                case UserKind_Accnt: return "财务";
                case UserKind_Sales: return "销售";
                default: return "其它";
            }
             
        }

        public static int GetUserKindNo(string name)
        {
            if (name == "管理员")
                return UserKind_Admin;
            if(name == "销售")
                return UserKind_Sales;
            if (name == "财务")
                return UserKind_Accnt;

            return UserKind_Other;
        }
    }


    public class UserAdo
    {
        public static User GetUser(string usercode)
        {
            IEncrypt encrypt = new DESEncrypt();
            User user = new User();

            string sql = string.Format("select username, userpsw, userright from t_user where usercode = '{0}'", usercode);
            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            DataRow dr = dt.Rows[0];
            string temp = "0";
            user.UserCode = usercode;
            user.UserName = dr["username"].ToString();
            temp = dr["userpsw"].ToString();

            if (string.IsNullOrEmpty(temp) == false)
                user.UserPsw = encrypt.DecryptString(temp);
            else
                user.UserPsw = "";

            temp = dr["userright"].ToString();
            if (true == string.IsNullOrEmpty(temp))
                user.UserKind = User.UserKind_Other;
            else
                user.UserKind = Convert.ToInt32(temp);
             
            return user;
        }

        public static bool UpdatePsw(string code, string psw)
        {
            string sql = string.Format("update t_user set userpsw = '{0}' where usercode = '{1}'", psw, code);

            if (Database.ExecuteSQL(sql) == 0)
                return false;
            return true;
        }
    }

}
