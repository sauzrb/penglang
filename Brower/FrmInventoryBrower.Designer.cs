namespace PengLang
{
    partial class FrmInventoryBrower
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventoryBrower));
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.cboFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch4 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labFilter = new DevExpress.XtraEditors.LabelControl();
            this.lblLotNo = new DevExpress.XtraEditors.LabelControl();
            this.txtKeyWords = new DevExpress.XtraEditors.TextEdit();
            this.invtGrid = new DevExpress.XtraGrid.GridControl();
            this.invtView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invtGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invtView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.cboFilter);
            this.gbSearch.Controls.Add(this.btnExport);
            this.gbSearch.Controls.Add(this.btnSearch4);
            this.gbSearch.Controls.Add(this.btnSearch3);
            this.gbSearch.Controls.Add(this.btnSearch2);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.labFilter);
            this.gbSearch.Controls.Add(this.lblLotNo);
            this.gbSearch.Controls.Add(this.txtKeyWords);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.ShowCaption = false;
            this.gbSearch.Size = new System.Drawing.Size(941, 50);
            this.gbSearch.TabIndex = 6;
            this.gbSearch.Text = "检索";
            // 
            // cboFilter
            // 
            this.cboFilter.Location = new System.Drawing.Point(53, 15);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFilter.Size = new System.Drawing.Size(100, 20);
            this.cboFilter.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(734, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 27);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch4
            // 
            this.btnSearch4.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch4.Image")));
            this.btnSearch4.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch4.Location = new System.Drawing.Point(642, 12);
            this.btnSearch4.Name = "btnSearch4";
            this.btnSearch4.Size = new System.Drawing.Size(80, 27);
            this.btnSearch4.TabIndex = 5;
            this.btnSearch4.Text = "统计4";
            this.btnSearch4.ToolTip = "合并统计结果，但只统计虚拟入库";
            this.btnSearch4.Click += new System.EventHandler(this.btnSearch4_Click);
            // 
            // btnSearch3
            // 
            this.btnSearch3.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch3.Image")));
            this.btnSearch3.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch3.Location = new System.Drawing.Point(550, 12);
            this.btnSearch3.Name = "btnSearch3";
            this.btnSearch3.Size = new System.Drawing.Size(80, 27);
            this.btnSearch3.TabIndex = 4;
            this.btnSearch3.Text = "统计3";
            this.btnSearch3.ToolTip = "合并统计结果，但不包括虚拟入库";
            this.btnSearch3.Click += new System.EventHandler(this.btnSearch3_Click);
            // 
            // btnSearch2
            // 
            this.btnSearch2.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch2.Image")));
            this.btnSearch2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch2.Location = new System.Drawing.Point(455, 12);
            this.btnSearch2.Name = "btnSearch2";
            this.btnSearch2.Size = new System.Drawing.Size(80, 27);
            this.btnSearch2.TabIndex = 3;
            this.btnSearch2.Text = "统计2";
            this.btnSearch2.ToolTip = "合并统计结果";
            this.btnSearch2.Click += new System.EventHandler(this.btnSearch2_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(362, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 27);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "统计1";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labFilter
            // 
            this.labFilter.Location = new System.Drawing.Point(9, 18);
            this.labFilter.Name = "labFilter";
            this.labFilter.Size = new System.Drawing.Size(38, 14);
            this.labFilter.TabIndex = 1;
            this.labFilter.Text = "Filter：";
            // 
            // lblLotNo
            // 
            this.lblLotNo.Location = new System.Drawing.Point(166, 18);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(67, 14);
            this.lblLotNo.TabIndex = 1;
            this.lblLotNo.Text = "KeyWords：";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Location = new System.Drawing.Point(234, 15);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(115, 20);
            this.txtKeyWords.TabIndex = 1;
            this.txtKeyWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyWords_KeyPress);
            // 
            // invtGrid
            // 
            this.invtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invtGrid.Location = new System.Drawing.Point(0, 50);
            this.invtGrid.MainView = this.invtView;
            this.invtGrid.Name = "invtGrid";
            this.invtGrid.Size = new System.Drawing.Size(941, 444);
            this.invtGrid.TabIndex = 8;
            this.invtGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.invtView});
            // 
            // invtView
            // 
            this.invtView.CustomizationFormBounds = new System.Drawing.Rectangle(708, 368, 222, 224);
            this.invtView.GridControl = this.invtGrid;
            this.invtView.Name = "invtView";
            this.invtView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.invtView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.invtView.OptionsBehavior.ReadOnly = true;
            this.invtView.OptionsCustomization.AllowBandMoving = false;
            this.invtView.OptionsCustomization.AllowSort = false;
            this.invtView.OptionsHint.ShowBandHeaderHints = false;
            this.invtView.OptionsHint.ShowCellHints = false;
            this.invtView.OptionsHint.ShowColumnHeaderHints = false;
            this.invtView.OptionsHint.ShowFooterHints = false;
            this.invtView.OptionsMenu.EnableColumnMenu = false;
            this.invtView.OptionsMenu.EnableFooterMenu = false;
            this.invtView.OptionsSelection.MultiSelect = true;
            this.invtView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.invtView.OptionsView.ColumnAutoWidth = false;
            this.invtView.OptionsView.ShowColumnHeaders = false;
            this.invtView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmInventoryBrower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 494);
            this.Controls.Add(this.invtGrid);
            this.Controls.Add(this.gbSearch);
            this.Name = "FrmInventoryBrower";
            this.Text = "FrmInventoryBrower";
            this.Load += new System.EventHandler(this.FrmInventoryBrower_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invtGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invtView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cboFilter;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labFilter;
        private DevExpress.XtraEditors.LabelControl lblLotNo;
        private DevExpress.XtraEditors.TextEdit txtKeyWords;
        private DevExpress.XtraGrid.GridControl invtGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView invtView;
        private DevExpress.XtraEditors.SimpleButton btnSearch2;
        private DevExpress.XtraEditors.SimpleButton btnSearch3;
        private DevExpress.XtraEditors.SimpleButton btnSearch4;
        private DevExpress.Utils.ToolTipController toolTipController;
    }
}