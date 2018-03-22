using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using Sau.Util;

namespace PengLang
{
    public partial class FrmClothesStyle : Form
    {
        public FrmClothesStyle()
        {
            InitializeComponent();
            colStyleNo.OptionsColumn.AllowEdit = false;
        }


        private void FrmClothesStyle_Load(object sender, EventArgs e)
        {
            InitGridView();
            Loadding();
        }

        #region 表格初始化

        private void InitGridView()
        {
            GridView gridView = styleView;
            gridView.BeginInit();

            //修改附加选项
            gridView.OptionsView.ShowColumnHeaders = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            gridView.OptionsView.ColumnAutoWidth = false;

            gridView.Appearance.OddRow.BackColor = Color.White;
            gridView.Appearance.EvenRow.BackColor = Color.LightCyan;

            gridView.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(this.OnCustomDrawRowIndicator);

            gridView.OptionsBehavior.Editable = true;           //是否允许用户编辑单元格
            gridView.OptionsCustomization.AllowColumnMoving = false;
            gridView.IndicatorWidth = 30;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;

            gridView.EndInit();
        }
    
        //自增行号
        protected void DrawRowIndicator(RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString(System.Globalization.CultureInfo.InvariantCulture);
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = Color.AntiqueWhite;
                    // e.Info.DisplayText = "G" + e.RowHandle;
                    e.Info.DisplayText = e.RowHandle.ToString();
                }
            }
        }

        protected void OnCustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            DrawRowIndicator(e);
        }

        #endregion

        #region 刷新、加载数据

        private void Loadding()
        {
            string sql = "Select distinct StyleNo, StyleRemark from t_clothes Order By StyleNo ";

            DataTable dt = Database.Select(sql);

            styleGrid.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Loadding();
        }

        #endregion

        #region 更新数据


        private void styleView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (styleView.FocusedColumn != colRemark)
                return;

            string styleNo = styleView.GetFocusedRowCellValue(colStyleNo).ToString();

            string sql = string.Format("Update T_Clothes Set StyleRemark = '{0}' Where StyleNo = '{1}'",
                    e.Value.ToString().Replace("'", "''"),
                    styleNo );

            int nres = Database.ExecuteSQL(sql, "FrmClothesStyle-styleView_ValidatingEditor");

            if (nres == 0)
            {
                e.ErrorText = "无法保存数据.";
                e.Valid = false;
            }

            //Loadding();
        }

        #endregion 

    }
}
