using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.Utils;
using Sau.Util;

namespace PengLang 
{
    public partial class FrmBrower : Form, InnerForm
    {
        private FrmOutboundBrowser outboundForm; 
        private FrmInventoryBrower invtForm;
        private FrmSaleBrower saleForm; 
        private FrmCashBrower cashForm;
        private FrmUnpaidStatistics unpaidForm;
        private Form[] childForms;

        public FrmBrower()
        {
            InitializeComponent();
            childForms = new Form[5];

            childForms[0] = outboundForm;
            childForms[1] = invtForm;
            childForms[2] = saleForm;
            childForms[3] = cashForm;
            childForms[4] = unpaidForm;

        }

        public void Save() { }
        public bool IsEdit() { return false; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }


        //加载子窗体
        private Form LoadChildForm(XtraTabPage tabPage, string frmName)
        {
            Form childForm;
            tabPage.Controls.Clear();
            Type t = Type.GetType(frmName);
            childForm = (Form)Activator.CreateInstance(t);
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            tabPage.Controls.Add(childForm);

            childForm.Show();

            return childForm;
        }

        private void LoadChildForms()
        {
           
            if (outboundForm == null)
            {
                outboundForm = LoadChildForm(tpOutbound, "PengLang.FrmOutboundBrowser") as FrmOutboundBrowser;
            }

            if (invtForm == null)
            {
                invtForm = LoadChildForm(tpInventory, "PengLang.FrmInventoryBrower") as FrmInventoryBrower;
            }

            if (saleForm == null)
            {
                saleForm = LoadChildForm(tpSale, "PengLang.FrmSaleBrower") as FrmSaleBrower;
            }

            if (cashForm == null)
            { 
                cashForm = LoadChildForm(tpCash, "PengLang.FrmCashBrower") as FrmCashBrower;
            }

            if (unpaidForm == null)
            {
                unpaidForm = LoadChildForm(tpUnPaid, "PengLang.FrmUnpaidStatistics") as FrmUnpaidStatistics;
            }

        }

        private void FrmBrower_Load(object sender, EventArgs e)
        {
            //tpCommission.PageVisible = true;
            //tpOutbound.PageVisible = true;
            xtraTab.SelectedTabPage = tpOutbound;

            LoadChildForms();
        }

        private void xtraTab_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            
        }
  
    }
}
