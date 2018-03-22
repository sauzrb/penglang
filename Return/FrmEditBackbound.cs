using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PengLang
{
    public partial class FrmEditBackbound : Form
    {
        public string BackboundID = string.Empty;
        private BackBound bound = new BackBound();
        public BackBound BackboundItem
        {
            get { return bound; }
            set { bound = value; }
        }
        
        public FrmEditBackbound()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (bound == null)
                bound = new BackBound();

            bound.PONo = txtPONo.Text.Trim();
            bound.OrderDate = dateOrder.DateTime.ToString("yyyy-MM-dd");
            bound.Customer = cboCustomer.Text.Trim();
            bound.Sales = cboSales.Text.Trim();
            bound.Memo = txtMemo.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmEditInbound_Load(object sender, EventArgs e)
        {
            txtBackboundNo.Text = BackboundID;
            txtPONo.Text = bound.PONo;
            dateOrder.Text = bound.OrderDate;
            cboCustomer.Text = bound.Customer;
            cboSales.Text = bound.Sales;
            txtMemo.Text = bound.Memo;
        }
 
    }
}
