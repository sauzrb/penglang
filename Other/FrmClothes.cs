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
    public partial class FrmClothes : Form,InnerForm
    {
        #region 类成员

        ClothesGridView clothesGridView;

        #endregion 

        public FrmClothes()
        {
            InitializeComponent();
            clothesGridView = new ClothesGridView(clothesView);

            clothesGridView.Initialize();
        }

        #region  接口函数

        public void Save() { }
        public bool IsEdit() { return hasEdited; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        private bool hasEdited = false;

        #endregion

        public void Loading()
        {
            if (Database.IsConnected())
                clothesGridView.Loading();
        }
      
        private void FrmClothes_Load(object sender, EventArgs e)
        {
            if (Database.IsConnected())
                clothesGridView.Loading();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clothesGridView.KeyWords = txtKeyWords.Text.Trim();
            clothesGridView.Loading();
        }

        private void txtKeyWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                clothesGridView.KeyWords = txtKeyWords.Text.Trim();
                clothesGridView.Loading();
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
            int[] rows = clothesView.GetSelectedRows();
           
            if (MsgBox.Confirm("您确定要删除所有选中的服装吗？ ") == false)
                return;
            clothesGridView.RemoveRows(rows);
            hasEdited = true;
        }

        private void InsertRow()
        {
            int pos = clothesView.FocusedRowHandle;
            if (pos < -1)
                pos = 0;
            DataTable dt = clothesGrid.DataSource as DataTable;
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
            int[] rows = clothesView.GetSelectedRows();
            if (rows == null || rows.Length == 0)
                mnuDeleteRow.Enabled = false;
            else
                mnuDeleteRow.Enabled = true;
        }

        private void clothesView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = clothesView.FocusedColumn;
            if (column.FieldName != "Price")
                return;

            if (e.Value == null)
                return;

            double val = 0.0;
            
            double.TryParse(e.Value.ToString(),out val);
            if (val < 0.0)
            {
                e.ErrorText = "Price must be greater than zero.";
                e.Valid = false;
                return;
            }
        }
  
        private void GridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string lotNo = clothesView.GetRowCellValue(e.RowHandle, "LotNo").ToString();
            if (string.IsNullOrEmpty(lotNo) == true)
            {
                e.ErrorText = "Art# can not be empty.";
                e.Valid = false;
                return;
            } 
             
            if (clothesGridView.FindLotNo(lotNo) == false)
            {
                string id = clothesGridView.AddClothes(e.RowHandle);
                hasEdited = true;
                if(  String.IsNullOrEmpty(id) == false  )
                    clothesView.SetRowCellValue(e.RowHandle,"ClothesID",id);
                e.Valid = true;
                return;
            }
            string clothesID = clothesView.GetRowCellValue(e.RowHandle, "ClothesID").ToString();
            if (clothesGridView.FindClothesExcept(lotNo, clothesID) == false)
            {
                clothesGridView.UpdateClothes(e.RowHandle);
                hasEdited = true;
            }
            else
            {
                e.ErrorText = "The Art# already exists.";
                e.Valid = false;
            }
        }

        private void FrmClothes_Leave(object sender, EventArgs e)
        {
            //焦点离开窗体事，重新加载服装内存表。
            if (IsEdit() == true)
            {
                MemoryTable.Instance.LoadClothes();
                hasEdited = false;
            }
        }


    }
}
