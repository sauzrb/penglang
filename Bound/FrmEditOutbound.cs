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
    public partial class FrmEditOutbound : Form
    {
        public string OutboundID = string.Empty;
        private OutBound outbound = new OutBound();
        public OutBound OutboundItem
        {
            get { return outbound; }
            set { outbound = value; }
        }

        public FrmEditOutbound()
        {
            outbound = new OutBound();
            InitializeComponent();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
         
        private void FrmEditOutbound_Load(object sender, EventArgs e)
        {
            
            cboCustomerNo.Properties.Items.Clear();
            cboSales.Properties.Items.Clear();
            
            MemoryTable.Instance.LoadSales();
            cboSales.Properties.Items.AddRange(MemoryTable.Instance.SalesList );

            CustomerHelper ch = new CustomerHelper();
            cboCustomerNo.Properties.Items.AddRange(ch.GetCustomerList());

            outbound = GetOutBound(OutboundID);
            SetUI();
        }

        private void GetUI()
        {
            if (outbound == null)
                outbound = new OutBound();

            outbound.OrderNo = txtOrderNo.Text.Trim();
            outbound.ShipDate = dateOutbound.DateTime.ToString("yyyy-MM-dd");
            outbound.Sales = cboSales.Text.Trim();
            outbound.CustomerNo = cboCustomerNo.Text.Trim();
            outbound.Operator = txtDealWorker.Text.Trim();
            outbound.SellTo = txtSellTo.Text;
            outbound.Address = txtAddr.Text;
            outbound.TrackingNo = txtTrackingNo.Text;
            outbound.ShipTo = txtShipTo.Text;
            outbound.ShipBy = txtShipBy.Text.Trim();
            outbound.Shippingway = cboShipway.Text.Trim();
            outbound.Term = nudTerm.Value.ToString();
            outbound.Freight = txtFreight.Text.Trim();
            if (String.IsNullOrEmpty(outbound.Term) )
                outbound.Term = "0";
            if( String.IsNullOrEmpty(outbound.Freight) )
                outbound.Freight = "0";

            outbound.PaymentMode = cboPayment.Text.Trim();
        }

        private void SetUI()
        {
            if (outbound == null)
                return;
            cboCustomerNo.Text = outbound.CustomerNo;
            txtOrderNo.Text = outbound.OrderNo;
            dateOutbound.Text = outbound.ShipDate;
            cboSales.Text = outbound.Sales;
            txtDealWorker.Text = outbound.Operator;
            txtSellTo.Text = outbound.SellTo;
            txtAddr.Text = outbound.Address;
            txtTrackingNo.Text = outbound.TrackingNo;
            txtShipTo.Text = outbound.ShipTo;
            txtShipBy.Text = outbound.ShipBy;
            txtFreight.Text = outbound.Freight;
            cboShipway.Text = outbound.Shippingway;
            nudTerm.Value = Convert.ToInt32(outbound.Term);
            cboPayment.Text = outbound.PaymentMode;
        }

        private OutBound GetOutBound(string id)
        {
            OutBound bound = new OutBound();
            string sql = String.Format("Select OrderNo, ShipDate, Sales, CustomerNo, Commission,  SellTo,Address,TrackingNo,ShipBy,ShipTo, Shippingway, Term, Freight,"
                                      + " Operator, InvoiceStatus, Status ,PaymentMode From T_Outbound "
                                      + " where OutboundID = '{0}' ", id);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return bound;
            DataRow dr = dt.Rows[0];
            int col = 0;
            bound.OutboundID = id;
            bound.OrderNo = dr[col++].ToString();
            bound.ShipDate = dr[col++].ToString();
            bound.Sales = dr[col++].ToString();
            bound.CustomerNo = dr[col++].ToString();
            bound.Commission = dr[col++].ToString();

            bound.SellTo = dr[col++].ToString();
            bound.Address = dr[col++].ToString();
            bound.TrackingNo = dr[col++].ToString();

            bound.ShipBy = dr[col++].ToString();
            bound.ShipTo = dr[col++].ToString();
            bound.Shippingway = dr[col++].ToString();
            bound.Term = dr[col++].ToString();
            bound.Freight = dr[col++].ToString();

            bound.Operator = dr[col++].ToString();
            bound.InvoiceStatus = dr[col++].ToString();
            bound.Status = dr[col++].ToString();
            bound.PaymentMode = dr[col++].ToString();

            return bound;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (false == Valid())
                return;
            GetUI();

            SaveCustomer();

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

        #region  Customer

        private List<Customer> TempCustomerList = null;
        private int nTempCutomerIndex = -1;

        private void ComboBoxCustomer_TextChanged(object sender, EventArgs e)
        {
            CustomerHelper ch = new CustomerHelper();
            string txt = cboCustomerNo.Text.Trim();
            Customer obj = ch.GetCustomer(txt);
            if (obj != null)
            {
                cboSales.Text = obj.Sales;
                txtSellTo.Text = obj.Company;
                txtShipTo.Text = obj.ShipTo;
                txtAddr.Text = obj.Address;
            }
            else
            {
                cboSales.Text = "";
                txtSellTo.Text = "";
                txtShipTo.Text = "";
                txtAddr.Text = "";
            }
        }

        private void SaveCustomer()
        {
            Customer cus = new Customer();
            Customer sel = cboCustomerNo.SelectedItem as Customer;
            
            if (sel != null)
            { 
                cus.ID = sel.ID;
            }

            cus.CustomerNo = cboCustomerNo.Text.Trim();
            cus.Sales = cboSales.Text.Trim();
            cus.Company = txtSellTo.Text.Trim();
            cus.Address = txtAddr.Text;
            cus.ShipTo = txtShipTo.Text;
            cus.ShippingWay = cboShipway.Text;
            cus.Term = nudTerm.Value.ToString();
            cus.Freight = txtFreight.Text.Trim();
            
            CustomerHelper ch = new CustomerHelper();

            if (ch.FindCustomer(cus.CustomerNo) )
                ch.UpdateCustomer(cus);

            else
                ch.InsertCustomer(cus);
        }

        private bool Valid()
        {
            string cusNo = cboCustomerNo.Text.Trim();

            if ( string.IsNullOrEmpty(cusNo)  )
            {
                MsgBox.Error("customer# can not be empty.");
                cboCustomerNo.Focus();
                return false;
            }

            string sellTo = txtSellTo.Text.Trim();
            if (string.IsNullOrEmpty(sellTo))
            {
                MsgBox.Error("Sell To can not be empty.");
                txtSellTo.Focus();
                return false;
            }

            if (cboPayment.Text.Trim().Length == 0)
            {
                MsgBox.Error(" 'Payment Mode' can not be empty！");
                return false;
            }

            if (ValidPayment() == false)
            {
                MsgBox.Error(" 'Payment Mode' must be  one of 'FAC,CHECK,CREDET,CASH.'！");
                return false;
            }
            return true;
        }


        //验证付款方式是否合法
        bool ValidPayment()
        {
            //"FAC CHECK CREDET CASH ";
            string mode = cboPayment.Text.Trim().ToUpper();

            if (mode == "FAC") return true;
            if (mode == "CHECK") return true;
            if (mode == "CREDET") return true;
            if (mode == "CASH") return true;
            return false;
        }
     

        private void btnRereshCustomer_Click(object sender, EventArgs e)
        {
            CustomerHelper ch = new CustomerHelper();
            string txt = txtSellTo.Text.Trim();

            TempCustomerList = ch.GetCustomerBySellTo(txt);
            if (TempCustomerList == null || TempCustomerList.Count == 0)
                return;
            Customer obj = TempCustomerList[0];
             
            txtSellTo.Text = obj.Company;
            txtShipTo.Text = obj.ShipTo;
            txtAddr.Text = obj.Address;
            cboShipway.Text = obj.ShippingWay;
            nudTerm.Value = Convert.ToDecimal(obj.Term);
            txtFreight.Text = obj.Freight;

            nTempCutomerIndex = 0;
            SwitchCustomer(nTempCutomerIndex);
        }

        private void btnPrevCustomer_Click(object sender, EventArgs e)
        {
            nTempCutomerIndex--;
            SwitchCustomer(nTempCutomerIndex);
        }

        private void btnNextCustomer_Click(object sender, EventArgs e)
        {
            nTempCutomerIndex++;
            SwitchCustomer(nTempCutomerIndex);
        }
        
        private void SwitchCustomer(int idx)
        {
            if (idx < 0 || TempCustomerList == null || TempCustomerList.Count <= 1)
            {
                btnPrevCustomer.Enabled = false;
                btnNextCustomer.Enabled = false;

                return;
            }
            if (idx <= TempCustomerList.Count - 1)
            {
                Customer obj = TempCustomerList[idx];
                cboCustomerNo.Text = obj.CustomerNo;
                cboSales.Text = obj.Sales;
                txtSellTo.Text = obj.Company;
                txtShipTo.Text = obj.ShipTo;
                txtAddr.Text = obj.Address;
                cboShipway.Text = obj.ShippingWay;
                nudTerm.Value = Convert.ToDecimal(obj.Term);
                txtFreight.Text = obj.Freight;
            }
            if (idx == 0 && TempCustomerList.Count <= 1)
            {
                btnPrevCustomer.Enabled = false;
                btnNextCustomer.Enabled = false;

                return;
            }
            if (idx == 0)
            {
                btnPrevCustomer.Enabled = false;
                btnNextCustomer.Enabled = true;
                return;
            }

            if (idx >= TempCustomerList.Count - 1)
            {
                btnNextCustomer.Enabled = false;
                btnPrevCustomer.Enabled = true;
                return;
            }

            btnNextCustomer.Enabled = true;
            btnPrevCustomer.Enabled = true;

        }
        
        #endregion

        #region 填写订单时，显示最后一个订单的编号

        private void btnTip_Click(object sender, EventArgs e)
        {
            string text = txtOrderNo.Text.Trim();

            txtOrderNo.Text = GetLastPoNo(text);
        }

        private string GetLastPoNo(string text)
        {
            string sql = string.Format("Select TOP 1 OrderNo ,CreateTime from T_Outbound where OrderNo like '{0}%' Order By CreateTime Desc ", text);

            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return text;
            string temp = dt.Rows[0][0].ToString();
            return temp;
        }


        #endregion
    }
}
