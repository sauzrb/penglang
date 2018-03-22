using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Sau.Util;

namespace PengLang
{
     public class Company
    {
         public string Address = "218 South 5th Ave., La Puente, CA 91746";
         public string Tell = "626-330-0275";
         public string Fax = "626-369-8489";
         public string Email = "penglangarment@gmail.com";
         public string Name = "P&L Import Corp";

        
    }

     public class CompanyAdo
     {
         public static Company LoadComanyInfo()
         {
             Company CompanyInfo = new Company(); ;
             if (LoadCompanyInfoFromDB(CompanyInfo))
                 return CompanyInfo;
             if (LoadCompanyInfoFromConfigFile(CompanyInfo))
                return CompanyInfo;

             return CompanyInfo;
         }

         public static bool LoadCompanyInfoFromConfigFile(Company CompanyInfo)
         {
             if(CompanyInfo == null)
                CompanyInfo = new Company();

             string ConfigFilePath = Application.StartupPath + "\\config.ini";
             if (File.Exists(ConfigFilePath) == false)
             {
                 return false;
             }

             IniFile ini = new IniFile(ConfigFilePath);
             string section = "company";

             CompanyInfo.Name = ini.GetString(section, "name", "P&L Import Corp");
             CompanyInfo.Tell = ini.GetString(section, "tell", "626-330-0275");
             CompanyInfo.Fax = ini.GetString(section, "fax", "626-369-8489");
             CompanyInfo.Email = ini.GetString(section, "email", "penglangarment@gmail.com");
             CompanyInfo.Address = ini.GetString(section, "address", "218 South 5th Ave., La Puente, CA 91746");

             return true;
         }

         public static bool LoadCompanyInfoFromDB(Company CompanyInfo)
         {
             if( CompanyInfo == null)
                CompanyInfo = new Company();
             string sql = "select codeid, codename, codevalue from t_systemcode where codetype = 'company' order by codeid ";

             DataTable dt = Database.Select(sql);

             if(dt == null || dt.Rows.Count == 0)
                 return false;
             string id, name, val ;
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 id = dt.Rows[i]["codeid"].ToString();
                 name = dt.Rows[i]["codename"].ToString();
                 val = dt.Rows[i]["codevalue"].ToString();
                 name = name.ToLower();

                 if (name == "name")
                     CompanyInfo.Name = val;
                 else if (name == "tell")
                     CompanyInfo.Tell = val;
                 else if (name == "fax")
                     CompanyInfo.Fax = val;
                 else if (name == "email")
                     CompanyInfo.Email = val;
                 else if (name == "address")
                     CompanyInfo.Address = val;
             }

             return true;
         }
         
         public static bool UpdateCompanyInfo(Company CompanyInfo)
         {
             int nres = 0;
             string sql = "";
             sql = string.Format(" update t_systemcode set codevalue = '{0}' where codename = 'name' and codetype = 'company'",
                 CompanyInfo.Name.Replace("'","''") );
             nres = Database.ExecuteSQL(sql);
             if (nres == 0) return false;

             sql = string.Format(" update t_systemcode set codevalue = '{0}' where codename = 'tell' and codetype = 'company'",
                 CompanyInfo.Tell.Replace("'", "''"));
             nres = Database.ExecuteSQL(sql);
             if (nres == 0) return false;

             sql = string.Format(" update t_systemcode set codevalue = '{0}' where codename = 'fax' and codetype = 'company'",
                 CompanyInfo.Fax.Replace("'", "''"));
             nres = Database.ExecuteSQL(sql);
             if (nres == 0) return false;


             sql = string.Format(" update t_systemcode set codevalue = '{0}' where codename = 'email' and codetype = 'company'",
                 CompanyInfo.Email.Replace("'", "''"));
             nres = Database.ExecuteSQL(sql);
             if (nres == 0) return false;

             sql = string.Format(" update t_systemcode set codevalue = '{0}' where codename = 'address' and codetype = 'company'",
                 CompanyInfo.Address.Replace("'", "''"));
             nres = Database.ExecuteSQL(sql);
             if (nres == 0) return false;

             return true;
         }

     }
}
