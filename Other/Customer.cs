using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sau.Util;

namespace PengLang
{
    public class Customer
    {
        public string ID="";
        public string CustomerNo="";   //客户号 
        public string Sales = "";      //销售代理
        public string Company="";      //客户公司名称
        public string Address="";      //客户快递地址 
        public string Level="";        //客户信誉度级别
        public string Tel="";          //电话
        public string Fax="";          //传真
        public string Email="";        //电子邮箱
        public string Contactor="";    //联系人
        public string ShipTo="";       //发货地址 
        public string ShippingWay="";  //包装方式
        public string Freight="0";      //运费
        public string Term="0";         //收款周期

        public override string ToString()
        {
            return CustomerNo;
        }
    }
     
    public class CustomerHelper
    {
        public  List<Customer> GetCustomerList()
        {
            List<Customer> list = new List<Customer>();
            string sql = "select customerNo ,Sales,company, address, tel, fax, email ,shipto, shippingway, term, freight, CustomerLevel from t_customer order by customerNo ";

            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return list;
            
            Customer obj = null;
            for (int i = 0, col = 0; i < dt.Rows.Count; i++)
            {
                col = 0;
                obj = new Customer();
                obj.CustomerNo = dt.Rows[i][col++].ToString();
                obj.Sales = dt.Rows[i][col++].ToString(); 
                obj.Company = dt.Rows[i][col++].ToString();
                obj.Address = dt.Rows[i][col++].ToString();
                obj.Tel = dt.Rows[i][col++].ToString();
                obj.Fax = dt.Rows[i][col++].ToString();
                obj.Email = dt.Rows[i][col++].ToString();
                obj.ShipTo = dt.Rows[i][col++].ToString();
                obj.ShippingWay = dt.Rows[i][col++].ToString();
                obj.Term = dt.Rows[i][col].ToString() == null ? "0" : dt.Rows[i][col++].ToString();
                obj.Freight = dt.Rows[i][col].ToString() == null ? "0" : dt.Rows[i][col++].ToString();
                obj.Level = dt.Rows[i][col++].ToString();
                list.Add(obj);
            }

            return list;
        }

        public bool FindCustomer(string no)
        {
            string sql = String.Format( "select * from t_customer where customerNo = '{0}'", no.Replace("'","''")) ;
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }

        public bool FindCustomer(Customer obj)
        {
            if (obj == null)
                return false;
            string sql = String.Format("select * from t_customer where customerNo = '{0}'", obj.CustomerNo.Replace("'", "''"));
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }

        public bool UpdateCustomer(Customer obj)
        {
            if (obj == null  )
                return false;
            if (string.IsNullOrEmpty(obj.ID) || string.IsNullOrEmpty(obj.CustomerNo))
                return false;
            int nres = 0;
            string sql = "";
            Customer cus =  Replace(obj);

            if (string.IsNullOrEmpty(obj.ID) == false)
            {
                sql = String.Format("Update T_Customer Set  company='{0}' ,address = '{1}',tel = '{2}', fax = '{3}', email = '{4}', "
                           + " shipto='{5}',shippingway = '{6}', term = '{7}', freight = '{8}' , Sales='{9}' where ID = '{10}'",
                    cus.Company,
                    cus.Address,
                    cus.Tel,
                    cus.Fax,
                    cus.Email,
                    cus.ShipTo,
                    cus.ShippingWay,
                    cus.Term,
                    cus.Freight,
                    cus.Sales,
                    cus.ID);

                nres = Database.ExecuteSQL(sql, "Customer-UpdateCustomer");

            }
            else if (string.IsNullOrEmpty(obj.CustomerNo) == false)
            {
                sql = String.Format("Update T_Customer Set  company='{0}' ,address = '{1}',tel = '{2}', fax = '{3}', email = '{4}', "
                             + " shipto='{5}',shippingway = '{6}', term = '{7}', freight = '{8}' , Sales='{9}' where  customerNo = '{10}'",
                      cus.Company,
                      cus.Address,
                      cus.Tel,
                      cus.Fax,
                      cus.Email,
                      cus.ShipTo,
                      cus.ShippingWay,
                      cus.Term,
                      cus.Freight, 
                      cus.Sales,
                      cus.CustomerNo );
                nres = Database.ExecuteSQL(sql, "Customer-UpdateCustomer");

            }
         
            return nres > 0 ? true : false;
        }

        public bool InsertCustomer(Customer obj)
        {  
            if (string.IsNullOrEmpty(obj.ID))  
                obj.ID = Database.GetGlobalKey();

           Customer cus = Replace(obj); 
           cus.ID = obj.ID;
            string sql = String.Format(" Insert into T_Customer (id, sales,customerno, company, address, tel, fax, email, shipto, shippingway, term, freight )"
              + " values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}') ",
                cus.ID,
                cus.Sales,
                cus.CustomerNo,
                cus.Company,
                cus.Address,
                cus.Tel,
                cus.Fax,
                cus.Fax,
                cus.ShipTo,
                cus.ShippingWay,
                cus.Term,
                cus.Freight);

            int nres = Database.ExecuteSQL(sql, "Customer-InsertCustomer");

            return nres > 0 ? true : false ;
        }

        public Customer GetCustomer(string no)
        {
            Customer obj = null;


            string sql = string.Format("select sales, customerno , company, address, tel, fax, email, shipto, shippingway, term, freight "
                       + " from t_customer where customerno = '{0}' order by customerno  ", no );

            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return obj;
             
            int i=0, col = 0;
            obj = new Customer();
            obj.Sales = dt.Rows[i][col++].ToString();
            obj.CustomerNo = dt.Rows[i][col++].ToString();
            obj.Company = dt.Rows[i][col++].ToString();
            obj.Address = dt.Rows[i][col++].ToString();
            obj.Tel = dt.Rows[i][col++].ToString();
            obj.Fax = dt.Rows[i][col++].ToString();
            obj.Email = dt.Rows[i][col++].ToString();
            obj.ShipTo = dt.Rows[i][col++].ToString();
            obj.ShippingWay = dt.Rows[i][col++].ToString();
            obj.Term = dt.Rows[i][col++].ToString();
            obj.Freight = dt.Rows[i][col++].ToString();
              
            return obj;
        }

        public Customer GetCustomerByID(string id)
        {
            Customer obj = null;


            string sql = string.Format("select sales, customerno , company, address, tel, fax ,email, shipto, shippingway, term, freight, customerlevel from t_customer where id = '{0}' order by customerno ", id);

            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return obj;

            int i = 0, col = 0;
            obj = new Customer();
            obj.ID = id;
            obj.Sales = dt.Rows[i][col++].ToString();
            obj.CustomerNo = dt.Rows[i][col++].ToString();
            obj.Company = dt.Rows[i][col++].ToString();
            obj.Address = dt.Rows[i][col++].ToString();
            obj.Tel = dt.Rows[i][col++].ToString();
            obj.Fax = dt.Rows[i][col++].ToString();
            obj.Email = dt.Rows[i][col++].ToString();
            obj.ShipTo = dt.Rows[i][col++].ToString();
            obj.ShippingWay = dt.Rows[i][col++].ToString();
            obj.Term = dt.Rows[i][col++].ToString();
            obj.Freight = dt.Rows[i][col++].ToString();
            obj.Level =  dt.Rows[i][col++].ToString();

            return obj;
        }

        public List<Customer> GetCustomerBySellTo(string val)
        {

            List<Customer> list = new List<Customer>();

            Customer obj = null;


            string sql = string.Format("select sales, customerNo , company, address,tel,fax,email,shipto ,shippingway, term, freight, customerlevel "
                       + " from t_customer where company like '{0}%' order by company ", val.Replace("'", "''") );

            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return list;
             
            for (int i = 0, col = 0; i < dt.Rows.Count; i++)
            {
                col = 0;
                obj = new Customer();
                obj.Sales = dt.Rows[i][col++].ToString();
                obj.CustomerNo = dt.Rows[i][col++].ToString();
                obj.Company = dt.Rows[i][col++].ToString();
                obj.Address = dt.Rows[i][col++].ToString();
                obj.Tel = dt.Rows[i][col++].ToString();
                obj.Fax = dt.Rows[i][col++].ToString();
                obj.Email = dt.Rows[i][col++].ToString();
                obj.ShipTo = dt.Rows[i][col++].ToString();
                obj.ShippingWay = dt.Rows[i][col++].ToString();
                obj.Term = dt.Rows[i][col++].ToString();
                obj.Freight = dt.Rows[i][col++].ToString();
                obj.Level = dt.Rows[i][col++].ToString();

                list.Add(obj);
            }
            return list;
        }

        public Customer Replace(Customer obj)
        {
            Customer res = new Customer();
            res.ID = obj.ID;
            res.Sales = obj.Sales.Replace("'", "''");
            res.CustomerNo = obj.CustomerNo.Replace("'", "''");
            res.Company = obj.Company.Replace("'", "''");
            res.Address = obj.Address.Replace("'", "''");
            res.Tel = obj.Tel.Replace("'", "''");
            res.Fax = obj.Fax.Replace("'", "''");
            res.Email = obj.Email.Replace("'", "''");
            res.ShipTo = obj.ShipTo.Replace("'", "''");
            res.ShippingWay = obj.ShippingWay.Replace("'", "''"); 
            res.Freight = obj.Freight;
            res.Term = obj.Term;
            res.Level = obj.Level;
            res.Contactor = obj.Contactor.Replace("'", "''");

            return res;
        }

        public bool DeleteCustomer(string id)
        {
            string sql = String.Format("delete from T_Customer where id = '{0}'", id);
            int nres = Database.ExecuteSQL(sql, "Customer-DeleteCustomer");

            return nres > 0 ? true : false;
        }
                 
        private bool GetNewCustomerNo(ref string  name)
        {  
            bool respond = InputBox.ShowInputBox("请输入顾客编号 !", ref name);
            bool isExist = false;
            if (respond == false)
                return false;

            isExist = FindCustomer(name.Trim());

            if (isExist == true)
            {
                DialogResult dr = MessageBox.Show("您输入的编号已经存在，是否重新输入？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    return false;
                while (dr == DialogResult.Yes && isExist == true)
                {
                    bool bol = InputBox.ShowInputBox("请输入顾客编号", ref name);
                    if (bol == false)
                        return false;

                    isExist = FindCustomer(name);
                    if (isExist == false)
                    {
                        break;
                    }
                    dr = MessageBox.Show("您输入的编号已经存在，是否重新输入？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                        return false;
                }
            } 
            return true;

        }
    }

}
