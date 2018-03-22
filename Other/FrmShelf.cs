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
    public partial class FrmShelf : Form,InnerForm
    {
        #region 类成员
        private bool bCanEdit = false;
        public bool CanEdit {
            get { return bCanEdit; }
            set { SetEditStatus(value); }
        }
       
        ShelfGridView shelfGridView;

        #endregion 

        public FrmShelf()
        {
            InitializeComponent();
            shelfGridView = new ShelfGridView(shelfView);
            shelfGridView.CanEdit = bCanEdit;
            shelfGridView.Initialize();

            if (CanEdit == false) 
                shelfGrid.ContextMenuStrip = null;
            else
                shelfGrid.ContextMenuStrip = ctxMenu;
        }

        public void Loading()
        {
            if (Database.IsConnected())
                shelfGridView.Loading();
        }

        private void FrmShelf_Load(object sender, EventArgs e)
        {
            shelfGrid.BeginInit();
            shelfView.BeginUpdate();

            if( Database.IsConnected())
                shelfGridView.Loading();
            
            shelfGrid.EndInit();
            shelfView.EndUpdate();
        }

        private void SetEditStatus(bool bEdit)
        {
            bCanEdit = bEdit;
            if (CanEdit == false)
                shelfGrid.ContextMenuStrip = null;
            else
                shelfGrid.ContextMenuStrip = ctxMenu;

            shelfGridView.CanEdit = bEdit;
            shelfGridView.Initialize();
        }

        public void Save() { }
        public bool IsEdit() { return false; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            shelfGridView.KeyWords = txtKeyWords.Text.Trim();
            shelfGridView.Loading();
        }
     
        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if( CanEdit == false )
               return;

            if (e.KeyCode == Keys.Delete)
                RemoveRows();
            else if (e.KeyCode == Keys.Insert)
                InsertRow();
        }
        
        private void RemoveRows()
        {
            int[] rows = shelfView.GetSelectedRows();
            //if (rows == null || rows.Length == 0)
            //{
            //    MsgBox.Error("请先选择要删除的货架！");
            //    return;
            //}
            if (MsgBox.Confirm("您确定要删除所有选中的货架吗？ ") == false)
                return;
            shelfGridView.RemoveRows(rows);

        }

        private void InsertRow()
        {
            int pos = shelfView.FocusedRowHandle;
            if (pos < -1)
                pos = 0;
            DataTable dt = shelfGrid.DataSource as DataTable;
            DataRow dataRow = dt.NewRow();
            dt.Rows.InsertAt(dataRow, pos);

        }

        private void ctxMenu_Opening(object sender, CancelEventArgs e)
        {
            int[] rows = shelfView.GetSelectedRows();
            if (rows == null || rows.Length == 0)
                mnuDeleteRow.Enabled = false;
            else
                mnuDeleteRow.Enabled = true;
        }

        private void mnuInsertRow_Click(object sender, EventArgs e)
        {

            InsertRow();
        }

        private void mnuDeleteRow_Click(object sender, EventArgs e)
        {
            RemoveRows();
        }
        
        private void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            string field = shelfView.FocusedColumn.FieldName;
            

            if (field == "LevelNo")
            {
                string txt = e.Value.ToString();
                if (txt == null)
                {
                    e.Valid = false;
                    e.ErrorText = "层号不能为空";
                    return;
                }

                txt = txt.ToUpper();
                if (string.Compare(txt, "A") < 0 || string.Compare(txt, "C") > 0)
                {
                    e.Valid = false;
                    e.ErrorText = "只能输入'A'、‘B’、‘C’";
                }
                else
                    e.Valid = true;
                return;
            }
            if (field == "ColNo")
            {
                string txt = e.Value.ToString();
                if (txt == null)
                {
                    e.Valid = false;
                    e.ErrorText = "列号不能为空";
                    return;
                }
                int col =0;
                try
                {
                    col = Convert.ToInt32(txt);
                    if (col > 3 || col < 1)
                    {
                        e.Valid = false;
                        e.ErrorText = "只能输入'1'、‘2’、‘3’";
                    }
                    else
                        e.Valid = true;
                }
                catch
                {
                    e.ErrorText = "只能输入一个整数";
                    e.Valid = false;
                }
                 
                return;
            }

        }
         
        private void GridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string rowNo = shelfView.GetRowCellValue(e.RowHandle, "RowNo").ToString();
            if (string.IsNullOrEmpty(rowNo) == true)
            {
                e.ErrorText = "Row number can not be empty.";
                e.Valid = false;
                return;
            }
            string levelNo = shelfView.GetRowCellValue(e.RowHandle, "LevelNo").ToString();
            if (string.IsNullOrEmpty(levelNo) == true)
            {
                //shelfView.SetColumnError(shelfView.Columns["LevelNo"], "必须填写层号");
                e.ErrorText = "Level number can not be empty.";
                e.Valid = false;
                return;
            }
            string colNo = shelfView.GetRowCellValue(e.RowHandle, "ColNo").ToString();
            if (string.IsNullOrEmpty(colNo) == true)
            {
                e.ErrorText = "Column number can not be empty.";
                e.Valid = false;
                return;
            }
            shelfView.SetRowCellValue(e.RowHandle, "LevelNo", levelNo.ToUpper() );

            e.Valid = true;

            if (shelfGridView.UpdateShelf(e.RowHandle) == false)
            {
                MsgBox.Error("您所添加的货架已经存在！");
                shelfView.DeleteRow(e.RowHandle);
            }
        }

        private void txtKeyWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                shelfGridView.KeyWords = txtKeyWords.Text.Trim();
                shelfGridView.Loading();
            }
        }
    
    }
}
