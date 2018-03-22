namespace PengLang
{
    partial class FrmCashBrower
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCashBrower));
            this.gbTop = new DevExpress.XtraEditors.GroupControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.cboKeyWords = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblFilter = new DevExpress.XtraEditors.LabelControl();
            this.lblKeyWords = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.lblBeginDate = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.cashGrid = new DevExpress.XtraGrid.GridControl();
            this.cashView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rcvdGrid = new DevExpress.XtraGrid.GridControl();
            this.rcvdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxmDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gbTop)).BeginInit();
            this.gbTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKeyWords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdView)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTop
            // 
            this.gbTop.Controls.Add(this.btnExport);
            this.gbTop.Controls.Add(this.cboKeyWords);
            this.gbTop.Controls.Add(this.cboFilter);
            this.gbTop.Controls.Add(this.lblFilter);
            this.gbTop.Controls.Add(this.lblKeyWords);
            this.gbTop.Controls.Add(this.dateEnd);
            this.gbTop.Controls.Add(this.dateBegin);
            this.gbTop.Controls.Add(this.lblEndDate);
            this.gbTop.Controls.Add(this.lblBeginDate);
            this.gbTop.Controls.Add(this.btnSearch);
            this.gbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTop.Location = new System.Drawing.Point(0, 0);
            this.gbTop.Name = "gbTop";
            this.gbTop.ShowCaption = false;
            this.gbTop.Size = new System.Drawing.Size(979, 50);
            this.gbTop.TabIndex = 8;
            this.gbTop.Text = "检索";
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(844, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 31);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cboKeyWords
            // 
            this.cboKeyWords.Location = new System.Drawing.Point(569, 15);
            this.cboKeyWords.Name = "cboKeyWords";
            this.cboKeyWords.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKeyWords.Size = new System.Drawing.Size(172, 20);
            this.cboKeyWords.TabIndex = 4;
            this.cboKeyWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboKeyWords_KeyPress);
            // 
            // cboFilter
            // 
            this.cboFilter.Location = new System.Drawing.Point(354, 16);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFilter.Size = new System.Drawing.Size(137, 20);
            this.cboFilter.TabIndex = 3;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(311, 18);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(38, 14);
            this.lblFilter.TabIndex = 13;
            this.lblFilter.Text = "Filter：";
            // 
            // lblKeyWords
            // 
            this.lblKeyWords.Location = new System.Drawing.Point(498, 18);
            this.lblKeyWords.Name = "lblKeyWords";
            this.lblKeyWords.Size = new System.Drawing.Size(67, 14);
            this.lblKeyWords.TabIndex = 12;
            this.lblKeyWords.Text = "KeyWords：";
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(202, 16);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 2;
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(78, 16);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateBegin.TabIndex = 1;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(181, 18);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(15, 14);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "To";
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.Location = new System.Drawing.Point(7, 18);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(68, 14);
            this.lblBeginDate.TabIndex = 7;
            this.lblBeginDate.Text = "Rcvd Date：";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(762, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 31);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainer.Horizontal = false;
            this.splitContainer.Location = new System.Drawing.Point(0, 50);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.cashGrid);
            this.splitContainer.Panel1.Text = "Panel1";
            this.splitContainer.Panel2.Controls.Add(this.rcvdGrid);
            this.splitContainer.Panel2.Text = "Panel2";
            this.splitContainer.Size = new System.Drawing.Size(979, 314);
            this.splitContainer.SplitterPosition = 149;
            this.splitContainer.TabIndex = 10;
            this.splitContainer.Text = "splitContainer";
            // 
            // cashGrid
            // 
            this.cashGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cashGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.cashGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.cashGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.cashGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.cashGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.cashGrid.Location = new System.Drawing.Point(0, 0);
            this.cashGrid.MainView = this.cashView;
            this.cashGrid.Name = "cashGrid";
            this.cashGrid.Size = new System.Drawing.Size(979, 160);
            this.cashGrid.TabIndex = 11;
            this.cashGrid.UseEmbeddedNavigator = true;
            this.cashGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cashView});
            // 
            // cashView
            // 
            this.cashView.GridControl = this.cashGrid;
            this.cashView.Name = "cashView";
            this.cashView.OptionsView.ShowGroupPanel = false;
            this.cashView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.cashView_FocusedRowChanged);
            this.cashView.DoubleClick += new System.EventHandler(this.cashView_DoubleClick);
            // 
            // rcvdGrid
            // 
            this.rcvdGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rcvdGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.rcvdGrid.Location = new System.Drawing.Point(0, 0);
            this.rcvdGrid.MainView = this.rcvdView;
            this.rcvdGrid.Name = "rcvdGrid";
            this.rcvdGrid.Size = new System.Drawing.Size(979, 149);
            this.rcvdGrid.TabIndex = 12;
            this.rcvdGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.rcvdView});
            // 
            // rcvdView
            // 
            this.rcvdView.GridControl = this.rcvdGrid;
            this.rcvdView.Name = "rcvdView";
            this.rcvdView.OptionsView.ShowGroupPanel = false;
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxmDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(101, 26);
            this.ctxMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenu_Opening);
            // 
            // ctxmDelete
            // 
            this.ctxmDelete.Image = ((System.Drawing.Image)(resources.GetObject("ctxmDelete.Image")));
            this.ctxmDelete.Name = "ctxmDelete";
            this.ctxmDelete.Size = new System.Drawing.Size(100, 22);
            this.ctxmDelete.Text = "删除";
            this.ctxmDelete.Click += new System.EventHandler(this.ctxmDelete_Click);
            // 
            // FrmCashBrower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 364);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.gbTop);
            this.Name = "FrmCashBrower";
            this.Text = "收款";
            this.Load += new System.EventHandler(this.FrmCashBrower_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbTop)).EndInit();
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKeyWords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cashGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdView)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbTop;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.LabelControl lblBeginDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cboFilter;
        private DevExpress.XtraEditors.LabelControl lblFilter;
        private DevExpress.XtraEditors.LabelControl lblKeyWords;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        private DevExpress.XtraGrid.GridControl cashGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView cashView;
        private DevExpress.XtraGrid.GridControl rcvdGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView rcvdView;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxmDelete;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.ComboBoxEdit cboKeyWords;
    }
}