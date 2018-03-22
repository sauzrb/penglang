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
    public partial class FrmEditInbound : Form
    {
        public string InboundID = string.Empty;
        private InBound inbound = new InBound();
        public InBound InboundItem
        {
            get { return inbound; }
            set { inbound = value; }
        }
        
        public FrmEditInbound()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (inbound == null)
                inbound = new InBound();

            inbound.ProductNo = txtProductNo.Text.Trim();
            inbound.OrderDate = dateOrder.DateTime.ToString("yyyy-MM-dd");

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
            txtInboundNo.Text = InboundID;
            txtProductNo.Text = inbound.ProductNo;
            dateOrder.Text = inbound.OrderDate;
        }
    }
}
