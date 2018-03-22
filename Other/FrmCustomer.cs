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
    public partial class FrmCustomer : Form, InnerForm
    {
        private CustomerGridView custGridView;
        
        #region  接口函数

        public void Save() { }
        public bool IsEdit() { return hasEdited; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        private bool hasEdited = false;

        #endregion
        
        public FrmCustomer()
        {
            InitializeComponent();

            custGridView = new CustomerGridView(custView);

            custGridView.Initialize();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (Database.IsConnected())
               custGridView.Loading();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCustomerEdit dlg = new FrmCustomerEdit();
            dlg.bNew = true;
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            if (custView.FocusedRowHandle <0 )
                custGridView.InsertCustomer(0, dlg.customer);
            else
                custGridView.InsertCustomer(custView.FocusedRowHandle+1, dlg.customer);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        { 
            if (custView.FocusedRowHandle < 0)
            {
                MsgBox.Infometion("请选择要修改的客户记录！");
                return;
            }
            OnEdit();
        }

        private void OnEdit()
        {
           
            FrmCustomerEdit dlg = new FrmCustomerEdit();
            dlg.bNew = false;

            string id = custView.GetFocusedRowCellValue("ID").ToString();
            CustomerHelper ch = new CustomerHelper();
            dlg.customer = ch.GetCustomerByID(id);

            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            if (dlg.bNew == false)
            {
                custGridView.UpdateCustomer(custView.FocusedRowHandle, dlg.customer);
                return;
            }

            if (custView.FocusedRowHandle < 0)
                custGridView.InsertCustomer(0, dlg.customer);
            else
                custGridView.InsertCustomer(custView.FocusedRowHandle + 1, dlg.customer);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (custView.FocusedRowHandle < 0)
            {
                MsgBox.Infometion("请选择要删除的客户记录！");
                return;
            }
            OnDelete();
        }

        private void OnDelete()
        {
            string name = custView.GetFocusedRowCellValue("CustomerNo").ToString();

            string tip = string.Format("您确定要删除选中的用户“{0}”", name);
            if (MsgBox.Confirm(tip) == false)
                return;

            string id = custView.GetFocusedRowCellValue("ID").ToString();

            CustomerHelper ch = new CustomerHelper();
            if (true == ch.DeleteCustomer(id))
            {
                FrmTip.ShowTip("删除客户成功！");
                DataTable dt = custGrid.DataSource as DataTable;
                //dt.Rows[custView.FocusedRowHandle].Delete();
                custView.BeginUpdate();
                //custView.DeleteRow(custView.FocusedRowHandle); 
                dt.Rows.RemoveAt(custView.FocusedRowHandle);
                custView.EndUpdate();
            }
            else
            {
                MsgBox.Error("删除客户失败！");
            }
        }
    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            custGridView.KeyWords = txtKeyWords.Text.Trim();
            custGridView.Loading();
        }

        private void txtKeyWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                custGridView.KeyWords = txtKeyWords.Text.Trim();
                custGridView.Loading();
            }
         
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                custGrid.ExportToXls(fileDialog.FileName);

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            } 
        }

        private void custView_DoubleClick(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void mnuSyncOutbound_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string sql = "UPDATE T_Outbound a, T_Customer b  Set a.Sales = b.Sales where a.CustomerNo = b.CustomerNo";

            Database.ExecuteSQL(sql);

            sql = "UPDATE T_Outbound a, T_Customer b  Set a.SellTo = b.Company where a.CustomerNo = b.CustomerNo";
            Database.ExecuteSQL(sql);

            sql = "UPDATE T_Outbound a, T_Customer b  Set a.Address = b.Address where a.CustomerNo = b.CustomerNo";
            Database.ExecuteSQL(sql);

            sql = "UPDATE T_Outbound a, T_Customer b  Set a.ShipTo = b.ShipTo where a.CustomerNo = b.CustomerNo";
            Database.ExecuteSQL(sql);

            Cursor.Current = Cursors.Default;

            FrmTip.ShowTip("同步出库表订单数据成功！");
        }
 
    }
}
