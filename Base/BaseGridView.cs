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
	public class BaseGridView
    {
        #region 构造函数

        public BaseGridView() { }
        public BaseGridView(GridView view) { gridView = view; }

        #endregion 

        #region  类成员

        protected GridView gridView;

        protected DataTable dataTable; 
        
        public DataTable DataSource
        {
            get { return dataTable; }
            set { dataTable = value; }
        }

        protected GridColumn[] Columns;

        #endregion

        #region 初始化

        public GridView GetGridView()
        {
            return this.gridView;
        }

        public void SetGridView(GridView view)
        {
            gridView = view;
        }
      
        //初始化
        public virtual void Initialize()
        {
            Initialize(gridView);
        }
        
        //初始化
        public virtual void Initialize(GridView view)
        {
            gridView = view;
            if (gridView == null)
                return;

            view.BeginUpdate(); //开始视图的编辑，防止触发其他事件
            view.BeginDataUpdate(); //开始数据的编辑

            InitGridView(); 

            CreateGridColumns();
            view.Columns.Clear();
            view.Columns.AddRange(this.Columns);
             
            dataTable = GetDataSource();
            view.GridControl.DataSource = dataTable;

            view.EndDataUpdate();
            view.EndUpdate();

            view.GridControl.Refresh();
        }
        
        //初始化视图
        protected virtual void InitGridView()
        {
            GridView view = gridView;
            if (view == null)
                return;

            //修改附加选项
            view.OptionsView.ShowColumnHeaders = true;                          
            view.OptionsView.ShowGroupPanel = false;    
            view.OptionsView.EnableAppearanceEvenRow = true;
            view.OptionsView.EnableAppearanceOddRow = true;
            view.OptionsView.ColumnAutoWidth = true;  

            view.Appearance.OddRow.BackColor = Color.White;
            view.Appearance.EvenRow.BackColor = Color.LightCyan;

            view.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(this.OnCustomDrawRowIndicator);
        }

        protected virtual void CreateGridColumns()
        {
        }
     
        //获取数据表字段
        protected virtual DataTable GetDataSource()
        {
            dataTable = new DataTable();
            DataColumn dataColumn;
            foreach (GridColumn gridColumn in this.Columns)
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
        
        #region 加载数据委托


        public delegate void LoadDataHandler();
        public LoadDataHandler LoadData;

        #endregion 
        
        #region 刷新、加载数据
         
        //刷新
        public virtual void Loading()
        {

            if (gridView == null)
                return;
            WaitingService.BeginLoading();
            if (dataTable != null)
                dataTable.Rows.Clear();
            if (LoadData != null)
                LoadData();

            AddDataRows(dataTable);

            gridView.BeginUpdate();
            gridView.BeginDataUpdate();

            gridView.GridControl.DataSource = dataTable;

            gridView.EndDataUpdate();

            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;

            gridView.EndUpdate();

            WaitingService.EndLoading();
        }
         
        protected virtual void AddDataRows(DataTable dt)
        {
           
        }
        
        #endregion
    }
}
