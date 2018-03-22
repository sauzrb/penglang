using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sau.Util;

namespace PengLang
{
    public partial class FrmCustomerEdit : Form
    {
        public Customer customer;
        public bool bNew = false;

        public FrmCustomerEdit()
        {
            InitializeComponent();
            customer = new Customer();

        }

        private void FrmCustomerEdit_Load(object sender, EventArgs e)
        {
            SetUI();
        }

        private void SetUI()
        {
            txtCustomerNo.Text = customer.CustomerNo;
            txtSales.Text = customer.Sales;
            txtCompany.Text = customer.Company;
            txtAddress.Text = customer.Address;
            txtTel.Text = customer.Tel;
            txtFax.Text = customer.Fax;
            txtEmail.Text = customer.Email;
            txtShipTo.Text = customer.ShipTo;
            cboShipway.Text = customer.ShippingWay;
            txtFreight.Text = customer.Freight;
            nudTerm.Value = Convert.ToInt32(customer.Term);
        }

        private void GetUI()
        {
            customer.Sales = txtSales.Text.Trim();
            customer.CustomerNo = txtCustomerNo.Text.Trim(); 
            customer.Company = txtCompany.Text;
            customer.Address = txtAddress.Text;
            customer.Tel = txtTel.Text;
            customer.Fax = txtFax.Text;
            customer.Email = txtEmail.Text;
            customer.ShipTo = txtShipTo.Text;
            customer.ShippingWay = cboShipway.Text.Trim();
            customer.Term = nudTerm.Value.ToString();
            customer.Freight = txtFreight.Text.Trim();
            if (String.IsNullOrEmpty(customer.Term))
                customer.Term = "0";
            if (String.IsNullOrEmpty(customer.Freight))
                customer.Freight = "0";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string tmp = txtCustomerNo.Text.Trim();

            if (string.IsNullOrEmpty(tmp))
            {
                MsgBox.Error("Customer# can not be empty！");
                return;
            }

            tmp = txtCompany.Text.Trim();

            if (string.IsNullOrEmpty(tmp))
            {
                MsgBox.Error("SellTo can not be empty！");
                return;
            }
             
            GetUI();
            
            bool bsuccess = SaveCustomer();
            if (bsuccess == false)
                return;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtFreight_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            if ((int)e.KeyChar != 46)                           //小数点
                return;
            //小数点的处理。
            if (textbox.Text.Length <= 0)
                e.Handled = true;   //小数点不能在第一位
            else                                             //处理不规则的小数点
            {
                float f;
                float oldf;
                bool b1 = false, b2 = false;
                b1 = float.TryParse(textbox.Text, out oldf);
                b2 = float.TryParse(textbox.Text + e.KeyChar.ToString(), out f);
                if (b2 == false)
                {
                    if (b1 == true)
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }

        }

        private bool SaveCustomer()
        {
            
            customer.Sales = txtSales.Text.Trim();
            customer.CustomerNo = txtCustomerNo.Text.Trim();
            customer.Company = txtCompany.Text;
            customer.Address = txtAddress.Text;
            customer.Tel = txtTel.Text;
            customer.Fax = txtFax.Text;
            customer.Email = txtEmail.Text;
            customer.ShipTo = txtShipTo.Text;
            customer.ShippingWay = cboShipway.Text;
            customer.Freight = txtFreight.Text.Trim();
            CustomerHelper ch = new CustomerHelper();

            if (true == IsExistCustomerID(customer.ID))
            {
                ch.UpdateCustomer(customer);
                bNew = false;
            }
            else
            {
                ch.InsertCustomer(customer);
                bNew = true;
            }
            return true;
        }

        public bool IsExistCustomerID(string id)
        {
            string sql = String.Format("select * from t_customer where ID = '{0}' ", id.Replace("'", "''"));
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }

        public bool IsExist(string no, string id)
        {
            string sql = String.Format("select * from t_customer where customerno = '{0}' and id <> '{1}'", no.Replace("'", "''"), id);
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }
     
        public bool IsExist(string no )
        {
            string sql = String.Format("select * from t_customer where customerno = '{0}' ", no.Replace("'", "''") );
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
          
            string cusCode = txtCustomerNo.Text.Trim();

            bool bres = IsExist(cusCode);

             if ( bres == false )
             {
                 MsgBox.Infometion("Customer# does not exist! ");
             }
             else
             {
                 MsgBox.Error("Customer# already exists!");
             }
        }

    }
}
