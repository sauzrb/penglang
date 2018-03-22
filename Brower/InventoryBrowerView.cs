using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using Sau.Util;

namespace PengLang 
{
	public class InventoryBrowerView : BaseBandView
	{
        public string FilterSql = string.Empty;
        public string KeyWords = string.Empty;
        public int StatStyle = 1;

        protected  int BeginSizeNoIndex = 5;
        protected int EndSizeNoIndex = 38; 

        #region 构造函数

        public InventoryBrowerView()
        {
            listClothes = MemoryTable.Instance.ListClothes;
        }

        public InventoryBrowerView(BandedGridView view)
        {
            base.SetGridView(view);
            listClothes = MemoryTable.Instance.ListClothes;
        }
        
        #endregion

        #region 类成员

        protected List<InventoryItem> listInventory = new List<InventoryItem>();

        public List<InventoryItem> InventoryList
        {
            get { return listInventory; }
            set { listInventory = value; }
        }

        protected List<Clothes> listClothes;

        #endregion
        
        #region GridBand

        protected GridBand bandRowID;    
        protected GridBand bandStyleNo;   //Style#
        protected GridBand bandShellNo;   //Lot# or Cut#
        protected GridBand bandLotNo;     //Art#
        protected GridBand bandColor;     //颜色  
        protected GridBand bandRegular;   //Regular
        protected GridBand bandLong;      //Long
        protected GridBand bandShort;     //Short	

        protected GridBand bandRegular36; //36 
        protected GridBand bandRegular38; //38 
        protected GridBand bandRegular40; //40 
        protected GridBand bandRegular42; //42 
        protected GridBand bandRegular44; //44 
        protected GridBand bandRegular46; //46 
        protected GridBand bandRegular48; //48 
        protected GridBand bandRegular50; //50 
        protected GridBand bandRegular52; //52 
        protected GridBand bandRegular54; //54 
        protected GridBand bandRegular56; //56 
        protected GridBand bandRegular58; //58 
        protected GridBand bandRegular60; //60 
        protected GridBand bandRegular62; //62 

        protected GridBand bandLong38; //38 
        protected GridBand bandLong40; //40 
        protected GridBand bandLong42; //42 
        protected GridBand bandLong44; //44 
        protected GridBand bandLong46; //46 
        protected GridBand bandLong48; //48 
        protected GridBand bandLong50; //50 
        protected GridBand bandLong52; //52 
        protected GridBand bandLong54; //54 
        protected GridBand bandLong56; //56 
        protected GridBand bandLong58; //58 
        protected GridBand bandLong60; //60 
        protected GridBand bandLong62; //62 

        protected GridBand bandShort34; //36
        protected GridBand bandShort36; //36 
        protected GridBand bandShort38; //38 
        protected GridBand bandShort40; //40 
        protected GridBand bandShort42; //42 
        protected GridBand bandShort44; //44 
        protected GridBand bandShort46; //46 	

        protected GridBand bandSubTotal;
        protected GridBand bandUnitPrice;

        #endregion

        #region  GridColumn

        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRowID;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colShellNo;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colStyleNo; 
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLotNo;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colColor; 
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR36;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR38;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR40;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR42;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR44;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR46;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR48;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR50;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR52;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR54;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR56;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR58;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR60;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colR62;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL38;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL40;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL42;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL44;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL46;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL48;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL50;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL52;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL54;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL56;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL58;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL60;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colL62;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS34;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS36;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS38;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS40;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS42;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS44;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colS46;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSubTotal;
        protected DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUnitPrice;

        #endregion

        #region 初始化

        //初始化视图
        protected override void InitGridView()
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
            view.OptionsBehavior.Editable = false;                               //是否允许用户编辑单元格  
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
            view.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.GridView_CellMerge);
        }

        //初始化列表
        protected override void CreateGridBand()
        {
            if (gridView == null)
                return;
            BandedGridView view = gridView;
            view.Bands.Clear();

            bandRowID = view.Bands.AddBand("RowID");
            bandRowID.Width = 10;
            bandRowID.Visible = false;

           
            bandStyleNo = view.Bands.AddBand("Style#");
            bandStyleNo.Width = 65;
            bandStyleNo.MinWidth = 65;

            bandShellNo = view.Bands.AddBand("Lot#");
            bandShellNo.Width = 70;
            bandShellNo.MinWidth = 70;

            bandLotNo = view.Bands.AddBand("Art#");
            bandLotNo.Width = 70;
            bandLotNo.MinWidth = 70;

            bandColor = view.Bands.AddBand("Color");
            bandColor.Width = 60;
            bandColor.MinWidth = 60;

            bandRegular = view.Bands.AddBand("Regular");
            bandLong = view.Bands.AddBand("Long");
            bandShort = view.Bands.AddBand("Short");

            //列标题对齐方式 
            bandShellNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandStyleNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandLotNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandRegular.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandLong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandShort.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            bandRegular36 = bandRegular.Children.AddBand("36");
            bandRegular38 = bandRegular.Children.AddBand("38");
            bandRegular40 = bandRegular.Children.AddBand("40");
            bandRegular42 = bandRegular.Children.AddBand("42");
            bandRegular44 = bandRegular.Children.AddBand("44");
            bandRegular46 = bandRegular.Children.AddBand("46");
            bandRegular48 = bandRegular.Children.AddBand("48");
            bandRegular50 = bandRegular.Children.AddBand("50");
            bandRegular52 = bandRegular.Children.AddBand("52");
            bandRegular54 = bandRegular.Children.AddBand("54");
            bandRegular56 = bandRegular.Children.AddBand("56");
            bandRegular58 = bandRegular.Children.AddBand("58");
            bandRegular60 = bandRegular.Children.AddBand("60");
            bandRegular62 = bandRegular.Children.AddBand("62");

            bandLong38 = bandLong.Children.AddBand("38");
            bandLong40 = bandLong.Children.AddBand("40");
            bandLong42 = bandLong.Children.AddBand("42");
            bandLong44 = bandLong.Children.AddBand("44");
            bandLong46 = bandLong.Children.AddBand("46");
            bandLong48 = bandLong.Children.AddBand("48");
            bandLong50 = bandLong.Children.AddBand("50");
            bandLong52 = bandLong.Children.AddBand("52");
            bandLong54 = bandLong.Children.AddBand("54");
            bandLong56 = bandLong.Children.AddBand("56");
            bandLong58 = bandLong.Children.AddBand("58");
            bandLong60 = bandLong.Children.AddBand("60");
            bandLong62 = bandLong.Children.AddBand("62");

            bandShort34 = bandShort.Children.AddBand("34");
            bandShort36 = bandShort.Children.AddBand("36");
            bandShort38 = bandShort.Children.AddBand("38");
            bandShort40 = bandShort.Children.AddBand("40");
            bandShort42 = bandShort.Children.AddBand("42");
            bandShort44 = bandShort.Children.AddBand("44");
            bandShort46 = bandShort.Children.AddBand("46");

            bandSubTotal = view.Bands.AddBand("Sub Total");
            bandSubTotal.Width = 45;
            bandSubTotal.MinWidth = 40;
            bandSubTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            bandUnitPrice = view.Bands.AddBand("W/O Price");
            bandUnitPrice.Width = 50;
            bandUnitPrice.MinWidth = 40;
            bandUnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;


            GridBand bandSize = bandRegular;
            int cnt = bandSize.Children.Count;
            for (int i = 0; i < cnt; i++)
            {
                bandSize.Children[i].MinWidth = 30;
                bandSize.Children[i].Width = 35;
                bandSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            bandSize = bandLong;
            cnt = bandSize.Children.Count;
            for (int i = 0; i < cnt; i++)
            {
                bandSize.Children[i].MinWidth = 30;
                bandSize.Children[i].Width = 35;
                bandSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            bandSize = bandShort;
            cnt = bandSize.Children.Count;
            for (int i = 0; i < cnt; i++)
            {
                bandSize.Children[i].MinWidth = 30;
                bandSize.Children[i].Width = 35;
                bandSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        protected override void CreateGridColumns()
        {
            this.colRowID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colShellNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colStyleNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn(); 
            this.colLotNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colColor = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn(); 
            this.colR36 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR38 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR40 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR46 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR48 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR50 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR52 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR54 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR56 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR58 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR60 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colR62 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL38 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL40 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL46 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL48 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL50 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL52 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL54 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL56 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL58 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL60 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colL62 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS34 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS36 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS38 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS40 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colS46 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSubTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();

            Columns = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { 
            this.colRowID,
            this.colStyleNo, 
            this.colShellNo,
            this.colLotNo, 
            this.colColor, 
            this.colR36,
            this.colR38,
            this.colR40,
            this.colR42,
            this.colR44,
            this.colR46,
            this.colR48,
            this.colR50,
            this.colR52,
            this.colR54,
            this.colR56,
            this.colR58,
            this.colR60,
            this.colR62,
            this.colL38,
            this.colL40,
            this.colL42,
            this.colL44,
            this.colL46,
            this.colL48,
            this.colL50,
            this.colL52,
            this.colL54,
            this.colL56,
            this.colL58,
            this.colL60,
            this.colL62,
            this.colS34,
            this.colS36,
            this.colS38,
            this.colS40,
            this.colS42,
            this.colS44,
            this.colS46,
            this.colSubTotal,
            this.colUnitPrice };
            // 
            // colRowID
            // 
            this.colRowID.Caption = "RowID";
            this.colRowID.FieldName = "RowID";
            this.colRowID.Name = "colRowID";
            this.colRowID.Visible = false;
            this.colRowID.Width = 50;
            this.colRowID.UnboundType = DevExpress.Data.UnboundColumnType.String;
           
            // 
            // colStyleNo
            // 
            this.colStyleNo.Caption = "Style#";
            this.colStyleNo.FieldName = "StyleNo";
            this.colStyleNo.Name = "colStyleNo";
            this.colStyleNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStyleNo.Visible = true;
            this.colStyleNo.Width = 80;
            //this.colStyleNo.MinWidth = 80;
            // 
            // colShellNo
            // 
            this.colShellNo.Caption = "Lot#";
            this.colShellNo.FieldName = "ShellNo";
            this.colShellNo.Name = "colShellNo";
            this.colShellNo.Visible = true;
            this.colShellNo.Width = 70;
            //this.colShellNo.MinWidth = 70;
            this.colShellNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // colLotNo
            // 
            this.colLotNo.Caption = "Art#";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLotNo.Visible = true;
            //this.colLotNo.MinWidth = 80;
            this.colLotNo.Width = 100;
            // 
            // colColor
            // 
            this.colColor.Caption = "颜色";
            this.colColor.FieldName = "Color";
            this.colColor.Name = "colColor";
            this.colColor.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colColor.Visible = true;
            this.colColor.Width = 80;
            //this.colColor.MinWidth = 80;
            // 
            // colR36
            // 
            this.colR36.Caption = "36";
            this.colR36.FieldName = "R36";
            this.colR36.MinWidth = 15;
            this.colR36.Name = "colR36";
            this.colR36.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR36.Visible = true;
            this.colR36.Width = 20;
            // 
            // colR38
            // 
            this.colR38.Caption = "38";
            this.colR38.FieldName = "R38";
            this.colR38.MinWidth = 15;
            this.colR38.Name = "colR38";
            this.colR38.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR38.Visible = true;
            this.colR38.Width = 20;
            // 
            // colR40
            // 
            this.colR40.Caption = "40";
            this.colR40.FieldName = "R40";
            this.colR40.MinWidth = 15;
            this.colR40.Name = "colR40";
            this.colR40.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR40.Visible = true;
            this.colR40.Width = 15;
            // 
            // colR42
            // 
            this.colR42.Caption = "42";
            this.colR42.FieldName = "R42";
            this.colR42.MinWidth = 15;
            this.colR42.Name = "colR42";
            this.colR42.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR42.Visible = true;
            this.colR42.Width = 15;
            // 
            // colR44
            // 
            this.colR44.Caption = "44";
            this.colR44.FieldName = "R44";
            this.colR44.MinWidth = 15;
            this.colR44.Name = "colR44";
            this.colR44.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR44.Visible = true;
            this.colR44.Width = 15;
            // 
            // colR46
            // 
            this.colR46.Caption = "46";
            this.colR46.FieldName = "R46";
            this.colR46.MinWidth = 15;
            this.colR46.Name = "colR46";
            this.colR46.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR46.Visible = true;
            this.colR46.Width = 15;
            // 
            // colR48
            // 
            this.colR48.Caption = "48";
            this.colR48.FieldName = "R48";
            this.colR48.MinWidth = 15;
            this.colR48.Name = "colR48";
            this.colR48.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR48.Visible = true;
            this.colR48.Width = 15;
            // 
            // colR50
            // 
            this.colR50.Caption = "50";
            this.colR50.FieldName = "R50";
            this.colR50.MinWidth = 15;
            this.colR50.Name = "colR50";
            this.colR50.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR50.Visible = true;
            this.colR50.Width = 15;
            // 
            // colR52
            // 
            this.colR52.Caption = "52";
            this.colR52.FieldName = "R52";
            this.colR52.MinWidth = 15;
            this.colR52.Name = "colR52";
            this.colR52.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR52.Visible = true;
            this.colR52.Width = 15;
            // 
            // colR54
            // 
            this.colR54.Caption = "54";
            this.colR54.FieldName = "R54";
            this.colR54.MinWidth = 15;
            this.colR54.Name = "colR54";
            this.colR54.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR54.Visible = true;
            this.colR54.Width = 15;
            // 
            // colR56
            // 
            this.colR56.Caption = "56";
            this.colR56.FieldName = "R56";
            this.colR56.MinWidth = 15;
            this.colR56.Name = "colR56";
            this.colR56.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR56.Visible = true;
            this.colR56.Width = 15;
            // 
            // colR58
            // 
            this.colR58.Caption = "58";
            this.colR58.FieldName = "R58";
            this.colR58.MinWidth = 15;
            this.colR58.Name = "colR58";
            this.colR58.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR58.Visible = true;
            this.colR58.Width = 15;
            // 
            // colR60
            // 
            this.colR60.Caption = "60";
            this.colR60.FieldName = "R60";
            this.colR60.MinWidth = 15;
            this.colR60.Name = "colR60";
            this.colR60.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR60.Visible = true;
            this.colR60.Width = 15;
            // 
            // colR62
            // 
            this.colR62.Caption = "62";
            this.colR62.FieldName = "R62";
            this.colR62.MinWidth = 15;
            this.colR62.Name = "colR62";
            this.colR62.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colR62.Visible = true;
            this.colR62.Width = 68;
            // 
            // colL38
            // 
            this.colL38.Caption = "38";
            this.colL38.FieldName = "L38";
            this.colL38.MinWidth = 15;
            this.colL38.Name = "colL38";
            this.colL38.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL38.Visible = true;
            this.colL38.Width = 20;
            // 
            // colL40
            // 
            this.colL40.Caption = "40";
            this.colL40.FieldName = "L40";
            this.colL40.MinWidth = 15;
            this.colL40.Name = "colL40";
            this.colL40.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL40.Visible = true;
            // 
            // colL42
            // 
            this.colL42.Caption = "42";
            this.colL42.FieldName = "L42";
            this.colL42.MinWidth = 15;
            this.colL42.Name = "colL42";
            this.colL42.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL42.Visible = true;
            // 
            // colL44
            // 
            this.colL44.Caption = "44";
            this.colL44.FieldName = "L44";
            this.colL44.MinWidth = 15;
            this.colL44.Name = "colL44";
            this.colL44.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL44.Visible = true;
            // 
            // colL46
            // 
            this.colL46.Caption = "46";
            this.colL46.FieldName = "L46";
            this.colL46.MinWidth = 15;
            this.colL46.Name = "colL46";
            this.colL46.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL46.Visible = true;
            this.colL46.Width = 20;
            // 
            // colL48
            // 
            this.colL48.Caption = "48";
            this.colL48.FieldName = "L48";
            this.colL48.MinWidth = 15;
            this.colL48.Name = "colL48";
            this.colL48.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL48.Visible = true;
            this.colL48.Width = 20;
            // 
            // colL50
            // 
            this.colL50.Caption = "50";
            this.colL50.FieldName = "L50";
            this.colL50.MinWidth = 15;
            this.colL50.Name = "colL50";
            this.colL50.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL50.Visible = true;
            this.colL50.Width = 20;
            // 
            // colL52
            // 
            this.colL52.Caption = "52";
            this.colL52.FieldName = "L52";
            this.colL52.MinWidth = 15;
            this.colL52.Name = "colL52";
            this.colL52.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL52.Visible = true;
            this.colL52.Width = 20;
            // 
            // colL54
            // 
            this.colL54.Caption = "54";
            this.colL54.FieldName = "L54";
            this.colL54.MinWidth = 15;
            this.colL54.Name = "colL54";
            this.colL54.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL54.Visible = true;
            this.colL54.Width = 20;
            // 
            // colL56
            // 
            this.colL56.Caption = "56";
            this.colL56.FieldName = "L56";
            this.colL56.MinWidth = 15;
            this.colL56.Name = "colL56";
            this.colL56.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL56.Visible = true;
            this.colL56.Width = 20;
            // 
            // colL58
            // 
            this.colL58.Caption = "58";
            this.colL58.FieldName = "L58";
            this.colL58.MinWidth = 15;
            this.colL58.Name = "colL58";
            this.colL58.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL58.Visible = true;
            this.colL58.Width = 20;
            // 
            // colL60
            // 
            this.colL60.Caption = "60";
            this.colL60.FieldName = "L60";
            this.colL60.MinWidth = 15;
            this.colL60.Name = "colL60";
            this.colL60.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL60.Visible = true;
            this.colL60.Width = 20;
            // 
            // colL62
            // 
            this.colL62.Caption = "62";
            this.colL62.FieldName = "L62";
            this.colL62.MinWidth = 15;
            this.colL62.Name = "colL62";
            this.colL62.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colL62.Visible = true;
            this.colL62.Width = 20;
            // 
            // colS34
            // 
            this.colS34.Caption = "34";
            this.colS34.FieldName = "S34";
            this.colS34.MinWidth = 15;
            this.colS34.Name = "colS34";
            this.colS34.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colS34.Visible = true;
            this.colS34.Width = 20;
            // 
            // colS36
            // 
            this.colS36.Caption = "36";
            this.colS36.FieldName = "S36";
            this.colS36.MinWidth = 15;
            this.colS36.Name = "colS36";
            this.colS36.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colS36.Visible = true;
            this.colS36.Width = 20;
            // 
            // colS38
            // 
            this.colS38.Caption = "38";
            this.colS38.FieldName = "S38";
            this.colS38.MinWidth = 15;
            this.colS38.Name = "colS38";
            this.colS38.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colS38.Visible = true;
            this.colS38.Width = 20;
            // 
            // colS40
            // 
            this.colS40.Caption = "40";
            this.colS40.FieldName = "S40";
            this.colS40.MinWidth = 15;
            this.colS40.Name = "colS40";
            this.colS40.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colS40.Visible = true;
            this.colS40.Width = 20;
            // 
            // colS42
            // 
            this.colS42.Caption = "42";
            this.colS42.FieldName = "S42";
            this.colS42.MinWidth = 15;
            this.colS42.Name = "colS42";
            this.colS42.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colS42.Visible = true;
            this.colS42.Width = 20;
            // 
            // colS44
            // 
            this.colS44.Caption = "44";
            this.colS44.FieldName = "S44";
            this.colS44.MinWidth = 15;
            this.colS44.Name = "colS44";
            this.colS44.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colS44.Visible = true;
            this.colS44.Width = 20;
            // 
            // colS46
            // 
            this.colS46.Caption = "46";
            this.colS46.FieldName = "S46";
            this.colS46.MinWidth = 15;
            this.colS46.Name = "colS46";
            this.colS46.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colS46.Visible = true;
            this.colS46.Width = 20;
            // 
            // colSubTotal
            // 
            this.colSubTotal.Caption = "Total";
            this.colSubTotal.FieldName = "SubTotal";
            this.colSubTotal.MinWidth = 30;
            this.colSubTotal.Name = "colSubTotal";
            this.colSubTotal.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSubTotal.Visible = true;
            this.colSubTotal.Width = 60;
            this.colSubTotal.OptionsColumn.AllowEdit = false;

            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "W/OPrice";
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.MinWidth = 30;
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.Width = 70;
            this.colUnitPrice.MinWidth = 60;
            this.colUnitPrice.OptionsColumn.AllowEdit = false;

        }

        protected override void BindingBandColumn()
        {
            if (gridView == null)
                return;
            BandedGridView view = gridView;

            view.Columns["RowID"].OwnerBand = bandRowID; 
            view.Columns["StyleNo"].OwnerBand = bandStyleNo;
            view.Columns["ShellNo"].OwnerBand = bandShellNo;
            view.Columns["LotNo"].OwnerBand = bandLotNo;
            view.Columns["Color"].OwnerBand = bandColor;
            view.Columns["SubTotal"].OwnerBand = bandSubTotal;
            view.Columns["UnitPrice"].OwnerBand = bandUnitPrice;

            view.Columns["R36"].OwnerBand = bandRegular36;
            view.Columns["R38"].OwnerBand = bandRegular38;
            view.Columns["R40"].OwnerBand = bandRegular40;
            view.Columns["R42"].OwnerBand = bandRegular42;
            view.Columns["R44"].OwnerBand = bandRegular44;
            view.Columns["R46"].OwnerBand = bandRegular46;
            view.Columns["R48"].OwnerBand = bandRegular48;
            view.Columns["R50"].OwnerBand = bandRegular50;
            view.Columns["R52"].OwnerBand = bandRegular52;
            view.Columns["R54"].OwnerBand = bandRegular54;
            view.Columns["R56"].OwnerBand = bandRegular56;
            view.Columns["R58"].OwnerBand = bandRegular58;
            view.Columns["R60"].OwnerBand = bandRegular60;
            view.Columns["R62"].OwnerBand = bandRegular62;

            view.Columns["L38"].OwnerBand = bandLong38;
            view.Columns["L40"].OwnerBand = bandLong40;
            view.Columns["L42"].OwnerBand = bandLong42;
            view.Columns["L44"].OwnerBand = bandLong44;
            view.Columns["L46"].OwnerBand = bandLong46;
            view.Columns["L48"].OwnerBand = bandLong48;
            view.Columns["L50"].OwnerBand = bandLong50;
            view.Columns["L52"].OwnerBand = bandLong52;
            view.Columns["L54"].OwnerBand = bandLong54;
            view.Columns["L56"].OwnerBand = bandLong56;
            view.Columns["L58"].OwnerBand = bandLong58;
            view.Columns["L60"].OwnerBand = bandLong60;
            view.Columns["L62"].OwnerBand = bandLong62;
           
            view.Columns["S34"].OwnerBand = bandShort34;
            view.Columns["S36"].OwnerBand = bandShort36;
            view.Columns["S38"].OwnerBand = bandShort38;
            view.Columns["S40"].OwnerBand = bandShort40;
            view.Columns["S42"].OwnerBand = bandShort42;
            view.Columns["S44"].OwnerBand = bandShort44;
            view.Columns["S46"].OwnerBand = bandShort46;

            ColumnTag tag = null;
            for (int i = BeginSizeNoIndex; i <= EndSizeNoIndex; i++)
            {
                tag = new ColumnTag();
                tag.DataType = ColumnTag.DataType_Integer;
                gridView.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                gridView.Columns[i].Tag = tag;
                gridView.Columns[i].Width = 35;
            }

        }

        #endregion

        #region 添加数据行

        protected virtual void AddDataRows(DataTable dt)
        {

            InventoryItem item = null;
            System.Data.DataRow dataRow = null;
           
            for (int i = 0, cnt = listInventory.Count; i < cnt; i++)
            {
                dataRow = dt.NewRow();
                item = listInventory[i];
                dataRow["RowID"] = item.ID;
                dataRow["StyleNo"] = item.StyleNo ;
                dataRow["ShellNo"] = item.ShellNo;
                dataRow["LotNo"] = item.LotNo;
                dataRow["Color"] = item.Color; 

                dataRow["R36"] = item.R36 == 0 ? "" : item.R36.ToString();
                dataRow["R38"] = item.R38 == 0 ? "" : item.R38.ToString();
                dataRow["R40"] = item.R40 == 0 ? "" : item.R40.ToString();
                dataRow["R42"] = item.R42 == 0 ? "" : item.R42.ToString();
                dataRow["R44"] = item.R44 == 0 ? "" : item.R44.ToString();
                dataRow["R46"] = item.R46 == 0 ? "" : item.R46.ToString();
                dataRow["R48"] = item.R48 == 0 ? "" : item.R48.ToString();
                dataRow["R50"] = item.R50 == 0 ? "" : item.R50.ToString();
                dataRow["R52"] = item.R52 == 0 ? "" : item.R52.ToString();
                dataRow["R54"] = item.R54 == 0 ? "" : item.R54.ToString();
                dataRow["R56"] = item.R56 == 0 ? "" : item.R56.ToString();
                dataRow["R58"] = item.R58 == 0 ? "" : item.R58.ToString();
                dataRow["R60"] = item.R60 == 0 ? "" : item.R60.ToString();
                dataRow["R62"] = item.R62 == 0 ? "" : item.R62.ToString();

                dataRow["L38"] = item.L38 == 0 ? "" : item.L38.ToString();
                dataRow["L40"] = item.L40 == 0 ? "" : item.L40.ToString();
                dataRow["L42"] = item.L42 == 0 ? "" : item.L42.ToString();
                dataRow["L44"] = item.L44 == 0 ? "" : item.L44.ToString();
                dataRow["L46"] = item.L46 == 0 ? "" : item.L46.ToString();
                dataRow["L48"] = item.L48 == 0 ? "" : item.L48.ToString();
                dataRow["L50"] = item.L50 == 0 ? "" : item.L50.ToString();
                dataRow["L52"] = item.L52 == 0 ? "" : item.L52.ToString();
                dataRow["L54"] = item.L54 == 0 ? "" : item.L54.ToString();
                dataRow["L56"] = item.L56 == 0 ? "" : item.L56.ToString();
                dataRow["L58"] = item.L58 == 0 ? "" : item.L58.ToString();
                dataRow["L60"] = item.L60 == 0 ? "" : item.L60.ToString();
                dataRow["L62"] = item.L62 == 0 ? "" : item.L62.ToString();
               
                dataRow["S34"] = item.S34 == 0 ? "" : item.S34.ToString();
                dataRow["S36"] = item.S36 == 0 ? "" : item.S36.ToString();
                dataRow["S38"] = item.S38 == 0 ? "" : item.S38.ToString();
                dataRow["S40"] = item.S40 == 0 ? "" : item.S40.ToString();
                dataRow["S42"] = item.S42 == 0 ? "" : item.S42.ToString();
                dataRow["S44"] = item.S44 == 0 ? "" : item.S44.ToString();
                dataRow["S46"] = item.S46 == 0 ? "" : item.S46.ToString();

                dataRow["SubTotal"] = item.SubTotal == 0 ? "" : item.SubTotal.ToString();
                dataRow["UnitPrice"] = item.Price == null ? "" : item.Price;

                dt.Rows.Add(dataRow);
            }

           
        }

        #endregion 

        #region 加载库存数据

        //加载库存数据
        public override void Loading()
        {
            if( dataTable != null)
                dataTable.Clear();
            
            if (gridView == null)
                return;

            if (StatStyle == 1)
                LoadInventory();
            else if (StatStyle == 2)
                LoadInventory2();
            else if (StatStyle == 3)
                LoadInventory3();
            else if (StatStyle == 4)
                LoadInventory4();

            AddDataRows(dataTable);

            gridView.BeginUpdate();//开始视图的编辑，防止触发其他事件
            gridView.BeginDataUpdate(); //开始数据的编辑

            gridView.GridControl.DataSource = dataTable;

            gridView.EndDataUpdate();
            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;
            gridView.MoveFirst();
            gridView.EndUpdate();

        }
        
        private void LoadInventory()
        {
            DataTable dt = null;

            string sql = "Select StyleNo, ShellNo,LotNo, SizeNo, Sum(Quantity) as Cnt From V_Inventory";

            sql += GetSqlWhere();

            sql += " Group by StyleNo,ShellNo, LotNo, SizeNo ";
            sql += " Order by StyleNo,ShellNo, LotNo, SizeNo ";

            dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return;

            List<InventoryItem> list = InventoryList;
            list.Clear();

            //将DataTable转换为ListItem
            string lotNo = "", sizeNo = "", curLotNo = "";
            int quantity = 0, sum = 0;

            InventoryItem item = null;
            DataRow dr = null;

            for (int i = 0, cnt = dt.Rows.Count; i < cnt; i++)
            {
                dr = dt.Rows[i];
                curLotNo = dr["LotNo"].ToString();
                sizeNo = dr["SizeNo"].ToString();

                if (lotNo != curLotNo)
                {
                    item = new InventoryItem();
                    lotNo = curLotNo;
                    sum = 0;
                    item.LotNo = lotNo;
                    GetClothesData(item, lotNo);

                    list.Add(item);
                }

                quantity = Convert.ToInt32(dr["Cnt"]);
                sum += quantity;
                item.SubTotal = sum;
                item.Set(sizeNo, quantity);


            }

            for (int i = list.Count - 1; i >= 0; i--)
                list[i].GetTotal();

            dt.Clear();
             
        }

        private void LoadInventory2()
        {
            DataTable dt = null;

            string sql = "Select StyleNo, ShellNo, SizeNo, Sum(Quantity) as Cnt From V_Inventory";

            sql += GetSqlWhere();

            sql += " Group by StyleNo,ShellNo, SizeNo ";
            sql += " Order by StyleNo,ShellNo, SizeNo ";

            dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return;

            List<InventoryItem> list = InventoryList;
            list.Clear();

            //将DataTable转换为ListItem
            string shellNo = "", sizeNo = "", curShellNo = "", styleNo = "", curStyleNo = "";
            int quantity = 0, sum = 0;

            InventoryItem item = null;
            DataRow dr = null;

            for (int i = 0, cnt = dt.Rows.Count; i < cnt; i++)
            {
                dr = dt.Rows[i];
                curShellNo = dr["ShellNo"].ToString();
                curStyleNo = dr["StyleNo"].ToString();
                sizeNo = dr["SizeNo"].ToString();

                if (shellNo != curShellNo || styleNo != curStyleNo )
                {
                    item = new InventoryItem();
                    shellNo = curShellNo;
                    styleNo = curStyleNo;
                    sum = 0;
                    item.ShellNo = shellNo;
                    GetClothesData2(item, shellNo, styleNo);

                    list.Add(item);
                }

                quantity = Convert.ToInt32(dr["Cnt"]);
                sum += quantity;
                item.SubTotal = sum;
                item.Set(sizeNo, quantity);


            }

            for (int i = list.Count - 1; i >= 0; i--)
                list[i].GetTotal();

            dt.Clear();

        }

        //在统计2d基础上，不统计虚拟入库和出库的。
        private void LoadInventory3()
        {
            List<string> artList = GetArtNoList("88T88", string.Empty);
            
            DataTable dt = null;

            string sql = "Select StyleNo, ShellNo, SizeNo, Sum(Quantity) as Cnt From V_Inventory";

            sql += GetSqlWhere3();

            sql += " Group by  StyleNo,ShellNo, SizeNo ";
            sql += " Order by  StyleNo,ShellNo, SizeNo ";

            dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return;

            List<InventoryItem> list = InventoryList;
            list.Clear();

            //将DataTable转换为ListItem
            string shellNo = "", sizeNo = "", curShellNo = "", styleNo = "", curStyleNo = "";
            int quantity = 0, sum = 0;

            InventoryItem item = null;
            DataRow dr = null;

            for (int i = 0, cnt = dt.Rows.Count; i < cnt; i++)
            {
                dr = dt.Rows[i];
                curShellNo = dr["ShellNo"].ToString();
                curStyleNo = dr["StyleNo"].ToString();
                sizeNo = dr["SizeNo"].ToString();

                if (shellNo != curShellNo || styleNo != curStyleNo)
                {
                    item = new InventoryItem();
                    shellNo = curShellNo;
                    styleNo = curStyleNo;
                    sum = 0;
                    item.ShellNo = shellNo;
                    GetClothesData3(item, shellNo, styleNo, artList);

                    list.Add(item);
                }

                quantity = Convert.ToInt32(dr["Cnt"]);
                sum += quantity;
                item.SubTotal = sum;
                item.Set(sizeNo, quantity);


            }

            for (int i = list.Count - 1; i >= 0; i--)
                list[i].GetTotal();

            dt.Clear();

        }


        //在统计2d基础上，只统计虚拟入库的。
        private void LoadInventory4()
        {
            List<string> artList = GetArtNoList("88T88", GetSqlWhere4());
            
            DataTable dt = null;

            string sql = "Select StyleNo, ShellNo, SizeNo, Sum(Quantity) as Cnt From V_Inventory";

            sql += GetSqlWhere4();

            sql += " Group by StyleNo,ShellNo, SizeNo ";
            sql += " Order by StyleNo,ShellNo, SizeNo ";

            dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return;

            List<InventoryItem> list = InventoryList;
            list.Clear();

            //将DataTable转换为ListItem
            string shellNo = "", sizeNo = "", curShellNo = "", styleNo = "", curStyleNo = "";
            int quantity = 0, sum = 0;

            InventoryItem item = null;
            DataRow dr = null;

            for (int i = 0, cnt = dt.Rows.Count; i < cnt; i++)
            {
                dr = dt.Rows[i];
                curShellNo = dr["ShellNo"].ToString();
                curStyleNo = dr["StyleNo"].ToString();
                sizeNo = dr["SizeNo"].ToString();

                if (shellNo != curShellNo || styleNo != curStyleNo)
                {
                    item = new InventoryItem();
                    shellNo = curShellNo;
                    styleNo = curStyleNo;
                    sum = 0;
                    item.ShellNo = shellNo;
                    GetClothesData4(item, shellNo, styleNo, artList);

                    list.Add(item);
                }

                quantity = Convert.ToInt32(dr["Cnt"]);
                sum += quantity;
                item.SubTotal = sum;
                item.Set(sizeNo, quantity);


            }

            for (int i = list.Count - 1; i >= 0; i--)
                list[i].GetTotal();

            dt.Clear();

        }

        private string GetSqlWhere()
        {

            string sql = string.Format(" WHERE ShelfNo <> '{0}' ", MemoryTable.Shelf_99T99);
            if (String.IsNullOrEmpty(FilterSql) || string.IsNullOrEmpty(KeyWords))
            {
                return sql;
            }

            sql += String.Format(" and {0} like '{1}%' ", FilterSql, KeyWords);

            return sql;
        }

        //不统计虚拟入库
        private string GetSqlWhere3()
        {

            string sql = string.Format(" WHERE ( ShelfNo <> '{0}' and ShelfNo <> '{1}') ",
                MemoryTable.Shelf_99T99,
                MemoryTable.Shelf_88T88);

            if (String.IsNullOrEmpty(FilterSql) || string.IsNullOrEmpty(KeyWords))
            {
                return sql;
            }

            sql += String.Format(" and {0} like '{1}%' ", FilterSql, KeyWords);

            return sql;
        }

        //只统计虚拟入库
        private string GetSqlWhere4()
        {

            string sql = string.Format(" WHERE ( ShelfNo = '{0}') ", 
                MemoryTable.Shelf_88T88);

            if (String.IsNullOrEmpty(FilterSql) || string.IsNullOrEmpty(KeyWords))
            {
                return sql;
            }

            sql += String.Format(" and {0} like '{1}%' ", FilterSql, KeyWords);

            return sql;
        }
     
        private void GetClothesData(InventoryItem item, string lotNo)
        {
            int cnt = listClothes.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (listClothes[i].LotNo != lotNo)
                    continue;

                item.StyleNo = listClothes[i].StyleNo ;
                item.ShellNo = listClothes[i].ShellNo;
                item.Shell = listClothes[i].Shell;
                item.Model = listClothes[i].Model;
                item.Color = listClothes[i].Color;
                item.Price = listClothes[i].Price;
                return;
            }
        }
       
        private void GetClothesData2(InventoryItem item, string shellNo, string styleNo)
        {
            int cnt = listClothes.Count;
            bool bFind = false;
            for (int i = 0; i < cnt; i++)
            {
                if (listClothes[i].ShellNo != shellNo || styleNo != listClothes[i].StyleNo )
                    continue;

                if (bFind == false)
                {
                    item.StyleNo = listClothes[i].StyleNo;
                    item.LotNo = listClothes[i].LotNo;
                    item.Shell = listClothes[i].Shell;
                    item.Model = listClothes[i].Model;
                    item.Color = listClothes[i].Color;
                    item.Price = listClothes[i].Price;
                    bFind = true;
                }
                else
                {
                    item.LotNo += "/" + listClothes[i].LotNo;
                }
                
            }
        }

        private void GetClothesData3(InventoryItem item, string shellNo, string styleNo, List<string> artList)
        {
            int cnt = listClothes.Count;
            bool bFind = false;
            for (int i = 0; i < cnt; i++)
            {
                if (listClothes[i].ShellNo != shellNo || styleNo != listClothes[i].StyleNo || FindArtNo(listClothes[i].LotNo, artList) == true)
                    continue;

                if (bFind == false)
                {
                    item.StyleNo = listClothes[i].StyleNo;
                    item.LotNo = listClothes[i].LotNo;
                    item.Shell = listClothes[i].Shell;
                    item.Model = listClothes[i].Model;
                    item.Color = listClothes[i].Color;
                    item.Price = listClothes[i].Price;
                    bFind = true;
                }
                else
                {
                    item.LotNo += "/" + listClothes[i].LotNo;
                }

            }
        }
     
        private void GetClothesData4(InventoryItem item, string shellNo, string styleNo, List<string> artList)
        {
            int cnt = listClothes.Count;
            bool bFind = false;
            for (int i = 0; i < cnt; i++)
            {
                if (listClothes[i].ShellNo != shellNo || styleNo != listClothes[i].StyleNo || FindArtNo(listClothes[i].LotNo, artList) == false )
                    continue;

                if (bFind == false)
                {
                    item.StyleNo = listClothes[i].StyleNo;
                    item.LotNo = listClothes[i].LotNo;
                    item.Shell = listClothes[i].Shell;
                    item.Model = listClothes[i].Model;
                    item.Color = listClothes[i].Color;
                    item.Price = listClothes[i].Price;
                    bFind = true;
                }
                else
                { 
                    item.LotNo += "/" + listClothes[i].LotNo;
                }

            }
        }
     
        private List<string> GetArtNoList(string shelfNo,string sqlWhere )
        {
            List<string> list = new List<string>();

            DataTable dt = null;

            string sql = "Select distinct LotNo From T_Inventory";
            if (string.IsNullOrEmpty(sqlWhere) != true)
            {
                sql += sqlWhere;
                sql += string.Format(" and shelfno = '{0}'", shelfNo);
            }
            else
                sql += string.Format(" where shelfNo = '{0}'", shelfNo);

            dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return list;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][0].ToString());
            }
            return list;
        }

        private bool FindArtNo(string artNo, List<string> list)
        { 
            if (list == null)
                return false;
            for (int i = 0; i < list.Count; i++)
            {
                if (artNo == list[i])
                    return true; 
            }
                
            return false;
        }
      
        #endregion

        #region 求小计

        protected int GetSubTotal(int rowHandle)
        {
            int sum = 0;
            //string temp = "";
            Object obj = null;
            for (int i = BeginSizeNoIndex; i <= EndSizeNoIndex; i++)
            {
                //temp = gridView.Columns[i].FieldName;
                obj = gridView.GetRowCellValue(rowHandle, gridView.Columns[i]);
                if (obj == null) continue;
                if (string.IsNullOrEmpty(obj.ToString()))
                    continue;
                sum += Convert.ToInt32(obj);
            }

            return sum;
        }

        #endregion

        #region 单元格合并
        
        private void GridView_CellMerge(object sender, CellMergeEventArgs e)
        {
            if (e.Column.FieldName == "StyleNo")
            {
                GridView view = sender as GridView;
                string val1 = view.GetRowCellValue(e.RowHandle1, e.Column).ToString();
                string val2 = view.GetRowCellValue(e.RowHandle2, e.Column).ToString();

                e.Merge = (val1 == val2);
                e.Handled = true;
            }

            if (e.Column.FieldName == "UnitPrice")
            {
                GridView view = sender as GridView;
                string val1 = view.GetRowCellValue(e.RowHandle1, "SyleNo").ToString();
                string val2 = view.GetRowCellValue(e.RowHandle2, "SyleNo").ToString();

                e.Merge = (val1 == val2);
                e.Handled = true;
            }
        }

        #endregion

    }
}
