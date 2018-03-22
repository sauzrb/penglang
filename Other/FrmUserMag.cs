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
    public partial class FrmUserMag :  Form,InnerForm
    {
        #region 类成员

        UserGridView userGridView;

        #endregion 
        
        #region  接口函数

        public void Save() { }
        public bool IsEdit() { return hasEdited; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        private bool hasEdited = false;

        #endregion

        public FrmUserMag()
        {
            InitializeComponent();
            userGridView = new UserGridView(userView);

            userGridView.Initialize();
        }

        private void FrmUserMag_Load(object sender, EventArgs e)
        {
            if (Database.IsConnected())
                userGridView.Loading();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            userGridView.KeyWords = txtKeyWords.Text.Trim();
            userGridView.Loading();
        }

        private void txtKeyWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                userGridView.KeyWords = txtKeyWords.Text.Trim();
                userGridView.Loading();
            }
        }
        
        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveRows();
            else if (e.KeyCode == Keys.Insert)
                InsertRow();
        }

        private void RemoveRows()
        {
            int[] rows = userView.GetSelectedRows();

            if (MsgBox.Confirm("您确定要删除所有选中的服装吗？ ") == false)
                return;
            userGridView.RemoveRows(rows);
            hasEdited = true;
        }

        private void InsertRow()
        {
            int pos = userView.FocusedRowHandle;
            if (pos < -1)
                pos = 0;
            DataTable dt = userGrid.DataSource as DataTable;
            DataRow dataRow = dt.NewRow();
            dt.Rows.InsertAt(dataRow, pos);

        }

        private void mnuInsertRow_Click(object sender, EventArgs e)
        {
            InsertRow();
            hasEdited = true;
        }

        private void mnuDeleteRow_Click(object sender, EventArgs e)
        {
            RemoveRows();
        }

        private void ctxMenu_Opening(object sender, CancelEventArgs e)
        {
            int[] rows = userView.GetSelectedRows();
            if (rows == null || rows.Length == 0)
                mnuDeleteRow.Enabled = false;
            else
                mnuDeleteRow.Enabled = true;
        }

        private void clothesView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            
        }

        private void GridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            string userCode = userView.GetRowCellValue(e.RowHandle, "UserCode").ToString();
            string userName = userView.GetRowCellValue(e.RowHandle, "UserName").ToString();
            if (string.IsNullOrEmpty(userName) == true)
            {
                e.ErrorText = "Name can not be empty.";
                e.Valid = false;
                return;
            }

            //添加用户
            if (string.IsNullOrEmpty(userCode) == true)
            {
                if (userGridView.FindUserName(userName) == true)
                {
                    MsgBox.Error("姓名已经存在！");
                    e.Valid = false;
                    return;
                }
                else
                {
                    string id = userGridView.AddUser(e.RowHandle); 
                    if (String.IsNullOrEmpty(id) == false)
                        userView.SetRowCellValue(e.RowHandle, "UserCode", id);
                    e.Valid = true; 
                }
              
                return;
            }
            
            //修改用户 
            if (userGridView.FindUserNameExcept(userName,userCode) == true)
            {
                MsgBox.Error("姓名已经存在！");
                e.Valid = false;
                return;
            }
            userGridView.UpdateUser(e.RowHandle);
            
            
        }

        private void userView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
   
        }
                
    }
}
