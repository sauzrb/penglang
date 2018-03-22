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
    public partial class FrmFinance : Form, InnerForm
    {
        private FrmInvoice invoiceForm;
        private FrmCashWindow cashForm;
        private FrmCommission commissionForm;

        private Form[] childForms;

        #region 窗体构造及初始化

        public FrmFinance()
        {
            InitializeComponent();

            childForms = new Form[3];

            childForms[0] = cashForm;
            childForms[1] = invoiceForm; 
            childForms[2] = commissionForm;
        }

        private void FrmFinance_Load(object sender, EventArgs e)
        {
            xtraTab.SelectedTabPage = tpAccountCash;
           
            if( cashForm == null )
                cashForm = LoadChildForm(tpAccountCash, "PengLang.FrmCashWindow") as FrmCashWindow;

            if (invoiceForm == null) 
                invoiceForm = LoadChildForm(tpInvoice, "PengLang.FrmInvoice") as FrmInvoice;

            if (commissionForm == null)
            {
                commissionForm = LoadChildForm(tpCommission, "PengLang.FrmCommission") as FrmCommission; 
            }

            
        }

        #endregion

        #region 接口函数

        public void Save() { }
        public bool IsEdit() { return false; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        #endregion

        #region 加载子窗体
       
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
        
        #endregion

    }
}
