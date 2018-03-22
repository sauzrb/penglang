using System;
using System.Collections;
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
    public partial class FrmEditInventroy : Form
    {
        bool bEdit = false;

        private EditInventoryView editInventoryView;
        
        public FrmEditInventroy()
        {
            InitializeComponent();

            this.detailView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridView_KeyUp);
            editInventoryView = new EditInventoryView(this.detailView);
        }

        #region 接口函数

        public void Save() 
        {
            string tip = "";
            bool berror = editInventoryView.CheckShelfQuantity(out tip);
            if (berror == true)
            {
                if (false == MsgBox.Confirm(tip))
                    return;
               
            }
            editInventoryView.Save(); 
            bEdit = false;

        }
        public bool IsEdit() { return bEdit; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        #endregion

        private void FrmEditInventroy_Load(object sender, EventArgs e)
        { 
            editInventoryView.Initialize();
            ResetUI();
            
        }

        public void ResetUI()
        {
            
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            btnSearch.Enabled = true;
            cboShelfNo.Enabled = true;

            cboShelfNo.Properties.Items.Clear();
            cboShelfNo.Properties.Items.AddRange(MemoryTable.Instance.ListShelfNo);
            detailView.OptionsBehavior.Editable = false;

            editInventoryView.Cancel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        { 
            Save();
            
            MsgBox.Infometion("保存数据成功！");
            
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnSearch.Enabled = true;
            cboShelfNo.Enabled = true;
            detailView.OptionsBehavior.Editable = false; 
        }
        
        private void RemoveRows()
        {
            int[] rows = detailView.GetSelectedRows();

            if (MsgBox.Confirm("您确定要删除所有选中的数据吗？ ") == false)
                return;
            editInventoryView.RemoveRows(rows);
            bEdit = true;
        }

        private void InsertRow()
        {
            int pos = detailView.FocusedRowHandle;
            if (pos < -1)
                pos = 0;
            DataTable dt = detailGrid.DataSource as DataTable;
            DataRow dataRow = dt.NewRow();
            dt.Rows.InsertAt(dataRow, pos);
            //dt.Rows[pos]["ShelfNo"] = cboShelfNo.Text.Trim();
        }

        private void mnuInsertRow_Click(object sender, EventArgs e)
        {
            InsertRow();
            bEdit = true;
        }

        private void mnuDeleteRow_Click(object sender, EventArgs e)
        {
            RemoveRows();
        }

        private void ctxMenu_Opening(object sender, CancelEventArgs e)
        {
            int[] rows = detailView.GetSelectedRows();
            if (rows == null || rows.Length == 0)
                mnuDeleteRow.Enabled = false;
            else
                mnuDeleteRow.Enabled = true;
        }
       
        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveRows();
            else if (e.KeyCode == Keys.Insert)
                InsertRow();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if( FindShelfNo(cboShelfNo.Text) == false )
            {
                MsgBox.Error("您输入的货架号不存在！");
                return;
            }

            detailView.OptionsBehavior.Editable = true; 
            editInventoryView.SetShelfNo( cboShelfNo.Text.Trim()) ;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            cboShelfNo.Enabled = false;
            btnSearch.Enabled = false;

            editInventoryView.LoadInventory();

        }

        private bool FindShelfNo(string shelfNo)
        {
            List<String> list = MemoryTable.Instance.ListShelfNo;
            int cnt = list.Count;
            for (int i = 0; i < cnt; i++)
                if (list[i] == shelfNo)
                    return true;

            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MsgBox.Confirm("您确定要放弃本次操作？") == false )
                return;

            btnCancel.Enabled = false;
            cboShelfNo.Enabled = true;
            btnSearch.Enabled = true;
            btnSave.Enabled = false;

            editInventoryView.Cancel();
            detailView.OptionsBehavior.Editable = false;

        }
         
 
    }
}
