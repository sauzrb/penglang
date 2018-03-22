namespace PengLang
{
    partial class FrmOutboundBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOutboundBrowser));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gbOutbound = new DevExpress.XtraEditors.GroupControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.cboFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labFilter = new DevExpress.XtraEditors.LabelControl();
            this.lblLotNo = new DevExpress.XtraEditors.LabelControl();
            this.txtKeyWords = new DevExpress.XtraEditors.TextEdit();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.lblBeginDate = new DevExpress.XtraEditors.LabelControl();
            this.btnFilterOutbound = new DevExpress.XtraEditors.SimpleButton();
            this.splitCtrl = new DevExpress.XtraEditors.SplitContainerControl();
            this.masterGrid = new DevExpress.XtraGrid.GridControl();
            this.masterView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.detailGrid = new DevExpress.XtraGrid.GridControl();
            this.detailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gbOutbound)).BeginInit();
            this.gbOutbound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitCtrl)).BeginInit();
            this.splitCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOutbound
            // 
            this.gbOutbound.Controls.Add(this.btnExport);
            this.gbOutbound.Controls.Add(this.cboFilter);
            this.gbOutbound.Controls.Add(this.labFilter);
            this.gbOutbound.Controls.Add(this.lblLotNo);
            this.gbOutbound.Controls.Add(this.txtKeyWords);
            this.gbOutbound.Controls.Add(this.dateEnd);
            this.gbOutbound.Controls.Add(this.dateBegin);
            this.gbOutbound.Controls.Add(this.lblEndDate);
            this.gbOutbound.Controls.Add(this.lblBeginDate);
            this.gbOutbound.Controls.Add(this.btnFilterOutbound);
            this.gbOutbound.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOutbound.Location = new System.Drawing.Point(0, 0);
            this.gbOutbound.Name = "gbOutbound";
            this.gbOutbound.ShowCaption = false;
            this.gbOutbound.Size = new System.Drawing.Size(837, 51);
            this.gbOutbound.TabIndex = 7;
            this.gbOutbound.Text = "检索";
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(718, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 31);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cboFilter
            // 
            this.cboFilter.Location = new System.Drawing.Point(329, 15);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFilter.Size = new System.Drawing.Size(100, 20);
            this.cboFilter.TabIndex = 12;
            // 
            // labFilter
            // 
            this.labFilter.Location = new System.Drawing.Point(288, 18);
            this.labFilter.Name = "labFilter";
            this.labFilter.Size = new System.Drawing.Size(38, 14);
            this.labFilter.TabIndex = 15;
            this.labFilter.Text = "Filter：";
            // 
            // lblLotNo
            // 
            this.lblLotNo.Location = new System.Drawing.Point(442, 18);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(67, 14);
            this.lblLotNo.TabIndex = 14;
            this.lblLotNo.Text = "KeyWords：";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Location = new System.Drawing.Point(510, 15);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(115, 20);
            this.txtKeyWords.TabIndex = 13;
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(172, 16);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 11;
            this.dateEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(48, 16);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateBegin.TabIndex = 6;
            this.dateBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(151, 18);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(15, 14);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "To";
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.Location = new System.Drawing.Point(10, 18);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(38, 14);
            this.lblBeginDate.TabIndex = 7;
            this.lblBeginDate.Text = "Date：";
            // 
            // btnFilterOutbound
            // 
            this.btnFilterOutbound.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterOutbound.Image")));
            this.btnFilterOutbound.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnFilterOutbound.Location = new System.Drawing.Point(635, 10);
            this.btnFilterOutbound.Name = "btnFilterOutbound";
            this.btnFilterOutbound.Size = new System.Drawing.Size(72, 31);
            this.btnFilterOutbound.TabIndex = 5;
            this.btnFilterOutbound.Text = "检索";
            this.btnFilterOutbound.Click += new System.EventHandler(this.btnFilterOutbound_Click);
            // 
            // splitCtrl
            // 
            this.splitCtrl.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.splitCtrl.Appearance.Options.UseBackColor = true;
            this.splitCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCtrl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitCtrl.Horizontal = false;
            this.splitCtrl.Location = new System.Drawing.Point(0, 51);
            this.splitCtrl.Name = "splitCtrl";
            this.splitCtrl.Panel1.Controls.Add(this.masterGrid);
            this.splitCtrl.Panel1.Text = "Panel1";
            this.splitCtrl.Panel2.Controls.Add(this.detailGrid);
            this.splitCtrl.Panel2.Text = "Panel2";
            this.splitCtrl.Size = new System.Drawing.Size(837, 400);
            this.splitCtrl.SplitterPosition = 207;
            this.splitCtrl.TabIndex = 8;
            this.splitCtrl.Text = "splitContainerControl1";
            // 
            // masterGrid
            // 
            this.masterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterGrid.Location = new System.Drawing.Point(0, 0);
            this.masterGrid.MainView = this.masterView;
            this.masterGrid.Name = "masterGrid";
            this.masterGrid.Size = new System.Drawing.Size(837, 188);
            this.masterGrid.TabIndex = 7;
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
            this.detailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.detailGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.detailGrid.Location = new System.Drawing.Point(0, 0);
            this.detailGrid.MainView = this.detailView;
            this.detailGrid.Name = "detailGrid";
            this.detailGrid.Size = new System.Drawing.Size(837, 207);
            this.detailGrid.TabIndex = 4;
            this.detailGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.detailView});
            // 
            // detailView
            // 
            this.detailView.GridControl = this.detailGrid;
            this.detailView.Name = "detailView";
            this.detailView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmOutboundBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 451);
            this.Controls.Add(this.splitCtrl);
            this.Controls.Add(this.gbOutbound);
            this.Name = "FrmOutboundBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmOutboundBrowser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbOutbound)).EndInit();
            this.gbOutbound.ResumeLayout(false);
            this.gbOutbound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitCtrl)).EndInit();
            this.splitCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbOutbound;
        private DevExpress.XtraEditors.SimpleButton btnFilterOutbound;
        private DevExpress.XtraEditors.SplitContainerControl splitCtrl;
        private DevExpress.XtraGrid.GridControl masterGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView masterView;
        private DevExpress.XtraGrid.GridControl detailGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView detailView;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.LabelControl lblBeginDate;
        private DevExpress.XtraEditors.ComboBoxEdit cboFilter;
        private DevExpress.XtraEditors.LabelControl labFilter;
        private DevExpress.XtraEditors.LabelControl lblLotNo;
        private DevExpress.XtraEditors.TextEdit txtKeyWords;
        private DevExpress.XtraEditors.SimpleButton btnExport;

    }
}