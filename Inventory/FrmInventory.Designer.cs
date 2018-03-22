namespace PengLang
{
    partial class FrmInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventory));
            this.xtraTab = new DevExpress.XtraTab.XtraTabControl();
            this.tpClothes = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.masterGrid = new DevExpress.XtraGrid.GridControl();
            this.masterView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.detailGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenuClothes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteClothes = new System.Windows.Forms.ToolStripMenuItem();
            this.detailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panDetailMenu = new System.Windows.Forms.Panel();
            this.lblInventoryDetail = new System.Windows.Forms.Label();
            this.btnHind = new DevExpress.XtraEditors.SimpleButton();
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.cboFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearchArt = new DevExpress.XtraEditors.SimpleButton();
            this.labFilter = new DevExpress.XtraEditors.LabelControl();
            this.lblLotNo = new DevExpress.XtraEditors.LabelControl();
            this.txtKeyWords = new DevExpress.XtraEditors.TextEdit();
            this.tpShelf = new DevExpress.XtraTab.XtraTabPage();
            this.shelfGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenuShelf = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteShelf = new System.Windows.Forms.ToolStripMenuItem();
            this.shelfView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panEditLeftSearch = new DevExpress.XtraEditors.PanelControl();
            this.btnExport2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtShelfNo = new DevExpress.XtraEditors.TextEdit();
            this.btnSearchShelf = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).BeginInit();
            this.xtraTab.SuspendLayout();
            this.tpClothes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
            this.ctxMenuClothes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).BeginInit();
            this.panDetailMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).BeginInit();
            this.tpShelf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shelfGrid)).BeginInit();
            this.ctxMenuShelf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shelfView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panEditLeftSearch)).BeginInit();
            this.panEditLeftSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShelfNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTab
            // 
            this.xtraTab.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.xtraTab.Appearance.Options.UseBackColor = true;
            this.xtraTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTab.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTab.Location = new System.Drawing.Point(0, 0);
            this.xtraTab.Name = "xtraTab";
            this.xtraTab.SelectedTabPage = this.tpClothes;
            this.xtraTab.Size = new System.Drawing.Size(769, 423);
            this.xtraTab.TabIndex = 0;
            this.xtraTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpClothes,
            this.tpShelf});
            // 
            // tpClothes
            // 
            this.tpClothes.Appearance.PageClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tpClothes.Appearance.PageClient.Options.UseBackColor = true;
            this.tpClothes.Controls.Add(this.splitContainer);
            this.tpClothes.Controls.Add(this.gbSearch);
            this.tpClothes.Name = "tpClothes";
            this.tpClothes.Size = new System.Drawing.Size(763, 394);
            this.tpClothes.Text = "按服装显示";
            // 
            // splitContainer
            // 
            this.splitContainer.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Appearance.Options.UseBackColor = true;
            this.splitContainer.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainer.Horizontal = false;
            this.splitContainer.Location = new System.Drawing.Point(0, 43);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.masterGrid);
            this.splitContainer.Panel2.Controls.Add(this.detailGrid);
            this.splitContainer.Panel2.Controls.Add(this.panDetailMenu);
            this.splitContainer.Size = new System.Drawing.Size(763, 351);
            this.splitContainer.SplitterPosition = 210;
            this.splitContainer.TabIndex = 6;
            // 
            // masterGrid
            // 
            this.masterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterGrid.Location = new System.Drawing.Point(0, 0);
            this.masterGrid.MainView = this.masterView;
            this.masterGrid.Name = "masterGrid";
            this.masterGrid.Size = new System.Drawing.Size(763, 210);
            this.masterGrid.TabIndex = 6;
            this.masterGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.masterView});
            // 
            // masterView
            // 
            this.masterView.CustomizationFormBounds = new System.Drawing.Rectangle(708, 368, 222, 224);
            this.masterView.GridControl = this.masterGrid;
            this.masterView.Name = "masterView";
            this.masterView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.masterView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.masterView.OptionsBehavior.ReadOnly = true;
            this.masterView.OptionsCustomization.AllowBandMoving = false;
            this.masterView.OptionsCustomization.AllowSort = false;
            this.masterView.OptionsHint.ShowBandHeaderHints = false;
            this.masterView.OptionsHint.ShowCellHints = false;
            this.masterView.OptionsHint.ShowColumnHeaderHints = false;
            this.masterView.OptionsHint.ShowFooterHints = false;
            this.masterView.OptionsMenu.EnableColumnMenu = false;
            this.masterView.OptionsMenu.EnableFooterMenu = false;
            this.masterView.OptionsSelection.MultiSelect = true;
            this.masterView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.masterView.OptionsView.ColumnAutoWidth = false;
            this.masterView.OptionsView.ShowColumnHeaders = false;
            this.masterView.OptionsView.ShowGroupPanel = false;
            // 
            // detailGrid
            // 
            this.detailGrid.ContextMenuStrip = this.ctxMenuClothes;
            this.detailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailGrid.Location = new System.Drawing.Point(0, 32);
            this.detailGrid.MainView = this.detailView;
            this.detailGrid.Name = "detailGrid";
            this.detailGrid.Size = new System.Drawing.Size(763, 104);
            this.detailGrid.TabIndex = 10;
            this.detailGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.detailView});
            this.detailGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DetialView_KeyUp);
            // 
            // ctxMenuClothes
            // 
            this.ctxMenuClothes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteClothes});
            this.ctxMenuClothes.Name = "ctxMenu";
            this.ctxMenuClothes.Size = new System.Drawing.Size(101, 26);
            // 
            // mnuDeleteClothes
            // 
            this.mnuDeleteClothes.Name = "mnuDeleteClothes";
            this.mnuDeleteClothes.Size = new System.Drawing.Size(100, 22);
            this.mnuDeleteClothes.Text = "删除";
            this.mnuDeleteClothes.Click += new System.EventHandler(this.mnuDeleteClothes_Click);
            // 
            // detailView
            // 
            this.detailView.GridControl = this.detailGrid;
            this.detailView.Name = "detailView";
            this.detailView.OptionsView.ShowGroupPanel = false;
            this.detailView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DetialView_KeyUp);
            // 
            // panDetailMenu
            // 
            this.panDetailMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panDetailMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDetailMenu.Controls.Add(this.lblInventoryDetail);
            this.panDetailMenu.Controls.Add(this.btnHind);
            this.panDetailMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panDetailMenu.Location = new System.Drawing.Point(0, 0);
            this.panDetailMenu.Name = "panDetailMenu";
            this.panDetailMenu.Size = new System.Drawing.Size(763, 32);
            this.panDetailMenu.TabIndex = 0;
            this.panDetailMenu.Resize += new System.EventHandler(this.panDetailMenu_Resize);
            // 
            // lblInventoryDetail
            // 
            this.lblInventoryDetail.AutoSize = true;
            this.lblInventoryDetail.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblInventoryDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInventoryDetail.Location = new System.Drawing.Point(371, 6);
            this.lblInventoryDetail.Name = "lblInventoryDetail";
            this.lblInventoryDetail.Size = new System.Drawing.Size(83, 17);
            this.lblInventoryDetail.TabIndex = 1;
            this.lblInventoryDetail.Text = "库存明细表";
            // 
            // btnHind
            // 
            this.btnHind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHind.Image = ((System.Drawing.Image)(resources.GetObject("btnHind.Image")));
            this.btnHind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnHind.Location = new System.Drawing.Point(725, 3);
            this.btnHind.Name = "btnHind";
            this.btnHind.Size = new System.Drawing.Size(30, 23);
            this.btnHind.TabIndex = 0;
            this.btnHind.Click += new System.EventHandler(this.btnHind_Click);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.cboFilter);
            this.gbSearch.Controls.Add(this.btnExport);
            this.gbSearch.Controls.Add(this.btnSearchArt);
            this.gbSearch.Controls.Add(this.labFilter);
            this.gbSearch.Controls.Add(this.lblLotNo);
            this.gbSearch.Controls.Add(this.txtKeyWords);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.ShowCaption = false;
            this.gbSearch.Size = new System.Drawing.Size(763, 43);
            this.gbSearch.TabIndex = 5;
            this.gbSearch.Text = "检索";
            // 
            // cboFilter
            // 
            this.cboFilter.Location = new System.Drawing.Point(53, 11);
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
            this.btnExport.Location = new System.Drawing.Point(455, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 27);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearchArt
            // 
            this.btnSearchArt.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchArt.Image")));
            this.btnSearchArt.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearchArt.Location = new System.Drawing.Point(362, 8);
            this.btnSearchArt.Name = "btnSearchArt";
            this.btnSearchArt.Size = new System.Drawing.Size(80, 27);
            this.btnSearchArt.TabIndex = 2;
            this.btnSearchArt.Text = "Search";
            this.btnSearchArt.Click += new System.EventHandler(this.btnSearchLot_Click);
            // 
            // labFilter
            // 
            this.labFilter.Location = new System.Drawing.Point(9, 14);
            this.labFilter.Name = "labFilter";
            this.labFilter.Size = new System.Drawing.Size(38, 14);
            this.labFilter.TabIndex = 1;
            this.labFilter.Text = "Filter：";
            // 
            // lblLotNo
            // 
            this.lblLotNo.Location = new System.Drawing.Point(166, 14);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(67, 14);
            this.lblLotNo.TabIndex = 1;
            this.lblLotNo.Text = "KeyWords：";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Location = new System.Drawing.Point(234, 11);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(115, 20);
            this.txtKeyWords.TabIndex = 1;
            this.txtKeyWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txLotNo_KeyPress);
            // 
            // tpShelf
            // 
            this.tpShelf.Controls.Add(this.shelfGrid);
            this.tpShelf.Controls.Add(this.panEditLeftSearch);
            this.tpShelf.Name = "tpShelf";
            this.tpShelf.Size = new System.Drawing.Size(763, 394);
            this.tpShelf.Text = "按货架显示";
            // 
            // shelfGrid
            // 
            this.shelfGrid.ContextMenuStrip = this.ctxMenuShelf;
            this.shelfGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shelfGrid.Location = new System.Drawing.Point(0, 42);
            this.shelfGrid.MainView = this.shelfView;
            this.shelfGrid.Name = "shelfGrid";
            this.shelfGrid.Size = new System.Drawing.Size(763, 352);
            this.shelfGrid.TabIndex = 10;
            this.shelfGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.shelfView});
            this.shelfGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ShelfView_KeyUp);
            // 
            // ctxMenuShelf
            // 
            this.ctxMenuShelf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteShelf});
            this.ctxMenuShelf.Name = "ctxMenu";
            this.ctxMenuShelf.Size = new System.Drawing.Size(101, 26);
            // 
            // mnuDeleteShelf
            // 
            this.mnuDeleteShelf.Name = "mnuDeleteShelf";
            this.mnuDeleteShelf.Size = new System.Drawing.Size(100, 22);
            this.mnuDeleteShelf.Text = "删除";
            this.mnuDeleteShelf.Click += new System.EventHandler(this.mnuDeleteShelf_Click);
            // 
            // shelfView
            // 
            this.shelfView.GridControl = this.shelfGrid;
            this.shelfView.Name = "shelfView";
            this.shelfView.OptionsView.ShowGroupPanel = false;
            // 
            // panEditLeftSearch
            // 
            this.panEditLeftSearch.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panEditLeftSearch.Appearance.Options.UseBackColor = true;
            this.panEditLeftSearch.Controls.Add(this.btnExport2);
            this.panEditLeftSearch.Controls.Add(this.labelControl1);
            this.panEditLeftSearch.Controls.Add(this.txtShelfNo);
            this.panEditLeftSearch.Controls.Add(this.btnSearchShelf);
            this.panEditLeftSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panEditLeftSearch.Location = new System.Drawing.Point(0, 0);
            this.panEditLeftSearch.Name = "panEditLeftSearch";
            this.panEditLeftSearch.Size = new System.Drawing.Size(763, 42);
            this.panEditLeftSearch.TabIndex = 9;
            // 
            // btnExport2
            // 
            this.btnExport2.Image = ((System.Drawing.Image)(resources.GetObject("btnExport2.Image")));
            this.btnExport2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport2.Location = new System.Drawing.Point(228, 9);
            this.btnExport2.Name = "btnExport2";
            this.btnExport2.Size = new System.Drawing.Size(62, 27);
            this.btnExport2.TabIndex = 11;
            this.btnExport2.Text = "导出";
            this.btnExport2.Click += new System.EventHandler(this.btnExport2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "货架：";
            // 
            // txtShelfNo
            // 
            this.txtShelfNo.Location = new System.Drawing.Point(63, 13);
            this.txtShelfNo.Name = "txtShelfNo";
            this.txtShelfNo.Size = new System.Drawing.Size(86, 20);
            this.txtShelfNo.TabIndex = 5;
            this.txtShelfNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShelfNo_KeyPress);
            // 
            // btnSearchShelf
            // 
            this.btnSearchShelf.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchShelf.Image")));
            this.btnSearchShelf.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearchShelf.Location = new System.Drawing.Point(160, 9);
            this.btnSearchShelf.Name = "btnSearchShelf";
            this.btnSearchShelf.Size = new System.Drawing.Size(62, 27);
            this.btnSearchShelf.TabIndex = 3;
            this.btnSearchShelf.Text = "检索";
            this.btnSearchShelf.Click += new System.EventHandler(this.btnSearchShelf_Click);
            // 
            // FrmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 423);
            this.Controls.Add(this.xtraTab);
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.Name = "FrmInventory";
            this.Text = "库存";
            this.Load += new System.EventHandler(this.FrmInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).EndInit();
            this.xtraTab.ResumeLayout(false);
            this.tpClothes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
            this.ctxMenuClothes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).EndInit();
            this.panDetailMenu.ResumeLayout(false);
            this.panDetailMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).EndInit();
            this.tpShelf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shelfGrid)).EndInit();
            this.ctxMenuShelf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shelfView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panEditLeftSearch)).EndInit();
            this.panEditLeftSearch.ResumeLayout(false);
            this.panEditLeftSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShelfNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTab;
        private DevExpress.XtraTab.XtraTabPage tpClothes;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        private DevExpress.XtraGrid.GridControl masterGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView masterView;
        private DevExpress.XtraGrid.GridControl detailGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView detailView;
        private System.Windows.Forms.Panel panDetailMenu;
        private System.Windows.Forms.Label lblInventoryDetail;
        private DevExpress.XtraEditors.SimpleButton btnHind;
        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.SimpleButton btnSearchArt;
        private DevExpress.XtraEditors.LabelControl lblLotNo;
        private DevExpress.XtraEditors.TextEdit txtKeyWords;
        private DevExpress.XtraTab.XtraTabPage tpShelf;
        private DevExpress.XtraGrid.GridControl shelfGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView shelfView;
        private DevExpress.XtraEditors.PanelControl panEditLeftSearch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtShelfNo;
        private DevExpress.XtraEditors.SimpleButton btnSearchShelf;
        private System.Windows.Forms.ContextMenuStrip ctxMenuShelf;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteShelf;
        private System.Windows.Forms.ContextMenuStrip ctxMenuClothes;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteClothes;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnExport2;
        private DevExpress.XtraEditors.ComboBoxEdit cboFilter;
        private DevExpress.XtraEditors.LabelControl labFilter;




    }
}