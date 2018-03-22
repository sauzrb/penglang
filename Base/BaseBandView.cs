using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
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
    public class BaseBandView
    {
        #region 构造函数

        public BaseBandView() { }
        public BaseBandView(BandedGridView view) { gridView = view; }
        
        #endregion

        #region 类成员
        
        protected BandedGridView gridView;

        protected DataTable dataTable; 
        public DataTable DataSource
        {
            get { return dataTable; }
            set { dataTable = value; }
        }

        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] columns;
        public BandedGridColumn[] Columns
        {
            get { return columns; }
            set { columns = value; }
        }
      
        #endregion

        #region 初始化

        public BandedGridView GetGridView()
        {
            return this.gridView;
        } 

        public void SetGridView(BandedGridView view )
        {
            gridView = view;
        }

        //初始化
        public virtual void Initialize( )
        {
            Initialize(gridView);
        }
        //初始化
        public virtual void Initialize(BandedGridView view)
        {
            gridView = view;
            if (gridView == null)
                return;
            view.BeginUpdate(); //开始视图的编辑，防止触发其他事件
            view.BeginDataUpdate(); //开始数据的编辑
           
            InitGridView();

            CreateGridBand();
            
            CreateGridColumns();

            view.Columns.AddRange(this.Columns);

            //绑定列
            BindingBandColumn();

            dataTable = GetDataSource();

            view.EndDataUpdate();
            view.EndUpdate();
        }

        //初始化视图
        protected  virtual void InitGridView()
        {
            BandedGridView view = gridView;
            if (view == null)
                return;
            //修改附加选项
            view.OptionsView.ShowColumnHeaders = false;                         //因为有Band列了，所以把ColumnHeader隐藏
            view.OptionsView.ShowGroupPanel = false;                            //如果没必要分组，就把它去掉
            view.OptionsView.EnableAppearanceEvenRow = true;
            view.OptionsView.EnableAppearanceOddRow = true;
            view.OptionsView.ColumnAutoWidth = false;  

            view.Appearance.OddRow.BackColor = Color.White;
            view.Appearance.EvenRow.BackColor = Color.LightCyan;

            view.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;   //是否显示过滤面板
            view.OptionsCustomization.AllowColumnMoving = false;                //是否允许移动列
            view.OptionsCustomization.AllowColumnResizing = true;              //是否允许调整列宽
            view.OptionsCustomization.AllowGroup = false;                       //是否允许分组
            view.OptionsCustomization.AllowFilter = false;                      //是否允许过滤
            view.OptionsCustomization.AllowSort = true;                         //是否允许排序
            view.OptionsCustomization.AllowBandMoving = false;
             

            view.OptionsSelection.EnableAppearanceFocusedCell = true;           //
            view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            view.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            view.OptionsBehavior.ReadOnly = true;
  
            view.OptionsHint.ShowBandHeaderHints = false;
            view.OptionsHint.ShowCellHints = false;
            view.OptionsHint.ShowColumnHeaderHints = false;
            view.OptionsHint.ShowFooterHints = false;
            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
           
            view.OptionsSelection.MultiSelect = true;
            view.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            
            view.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(this.OnCustomDrawRowIndicator);
            
        }

        //初始化列表
        protected virtual void CreateGridBand()
        {
            if (gridView == null)
                return;
            BandedGridView view = gridView;
            view.Bands.Clear();
 
      }

        //创建表字段
        protected virtual void CreateGridColumns()
        {     
        }

        //绑定表字段到Band
        protected virtual void BindingBandColumn()
        {
            if (gridView == null)
                return;
            BandedGridView view = gridView;
         
        }
        
        //获取数据表字段
        protected virtual DataTable GetDataSource()
        {
            dataTable = new DataTable();
            DataColumn dataColumn;
            foreach (BandedGridColumn gridColumn in this.Columns)
            {
                dataColumn = new System.Data.DataColumn();
                dataColumn.Caption = gridColumn.Caption;
                dataColumn.ColumnName = gridColumn.FieldName;
                dataTable.Columns.Add(dataColumn);
            }
            gridView.GridControl.DataSource = dataTable;
            return dataTable;
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
         
        //刷新
        public virtual void Loading()
        {
            if (gridView == null)
                return;

            if (dataTable == null)
                return;
 
        }
         
        #endregion

        #region 加载数据委托

       
        public delegate void LoadDataHandler(); 
        public LoadDataHandler LoadData;
         
        #endregion 
        
     
    }
}
