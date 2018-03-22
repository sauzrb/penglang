namespace PengLang
{
    partial class FrmInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvoice));
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.cboFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lblFilter = new DevExpress.XtraEditors.LabelControl();
            this.lblKeyWords = new DevExpress.XtraEditors.LabelControl();
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.lblBeginDate = new DevExpress.XtraEditors.LabelControl();
            this.cboKeyWords = new DevExpress.XtraEditors.TextEdit();
            this.xtraTab = new DevExpress.XtraTab.XtraTabControl();
            this.tpOutband = new DevExpress.XtraTab.XtraTabPage();
            this.outboundGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenuBound = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNoCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.outboundView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpPreview = new DevExpress.XtraTab.XtraTabPage();
            this.editGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenuEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.editView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKeyWords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).BeginInit();
            this.xtraTab.SuspendLayout();
            this.tpOutband.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outboundGrid)).BeginInit();
            this.ctxMenuBound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outboundView)).BeginInit();
            this.tpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editGrid)).BeginInit();
            this.ctxMenuEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Horizontal = false;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.gbSearch);
            this.splitContainer.Panel1.Text = "Panel1";
            this.splitContainer.Panel2.Controls.Add(this.xtraTab);
            this.splitContainer.Panel2.Text = "Panel2";
            this.splitContainer.Size = new System.Drawing.Size(1047, 408);
            this.splitContainer.SplitterPosition = 53;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.Text = "splitContainerControl1";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.cboFilter);
            this.gbSearch.Controls.Add(this.btnPrev);
            this.gbSearch.Controls.Add(this.btnExport);
            this.gbSearch.Controls.Add(this.btnPrint);
            this.gbSearch.Controls.Add(this.btnNext);
            this.gbSearch.Controls.Add(this.dateEnd);
            this.gbSearch.Controls.Add(this.dateBegin);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.lblFilter);
            this.gbSearch.Controls.Add(this.lblKeyWords);
            this.gbSearch.Controls.Add(this.lblEndDate);
            this.gbSearch.Controls.Add(this.lblBeginDate);
            this.gbSearch.Controls.Add(this.cboKeyWords);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.ShowCaption = false;
            this.gbSearch.Size = new System.Drawing.Size(1047, 53);
            this.gbSearch.TabIndex = 7;
            this.gbSearch.Text = "检索";
            // 
            // cboFilter
            // 
            this.cboFilter.Location = new System.Drawing.Point(327, 18);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFilter.Size = new System.Drawing.Size(88, 20);
            this.cboFilter.TabIndex = 2;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(725, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(72, 31);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "上一步";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(883, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 31);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(963, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 31);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(805, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 31);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "下一步";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(179, 18);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 1;
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(47, 18);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateBegin.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(588, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 31);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "检索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(288, 21);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(38, 14);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "Filter：";
            // 
            // lblKeyWords
            // 
            this.lblKeyWords.Location = new System.Drawing.Point(426, 21);
            this.lblKeyWords.Name = "lblKeyWords";
            this.lblKeyWords.Size = new System.Drawing.Size(67, 14);
            this.lblKeyWords.TabIndex = 1;
            this.lblKeyWords.Text = "KeyWords：";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(156, 19);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(15, 14);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "To";
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.Location = new System.Drawing.Point(7, 19);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(38, 14);
            this.lblBeginDate.TabIndex = 1;
            this.lblBeginDate.Text = "Date：";
            // 
            // cboKeyWords
            // 
            this.cboKeyWords.Location = new System.Drawing.Point(499, 18);
            this.cboKeyWords.Name = "cboKeyWords";
            this.cboKeyWords.Size = new System.Drawing.Size(79, 20);
            this.cboKeyWords.TabIndex = 3;
            this.cboKeyWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomer_KeyPress);
            // 
            // xtraTab
            // 
            this.xtraTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTab.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTab.Location = new System.Drawing.Point(0, 0);
            this.xtraTab.Name = "xtraTab";
            this.xtraTab.SelectedTabPage = this.tpOutband;
            this.xtraTab.Size = new System.Drawing.Size(1047, 350);
            this.xtraTab.TabIndex = 0;
            this.xtraTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpOutband,
            this.tpPreview});
            // 
            // tpOutband
            // 
            this.tpOutband.Controls.Add(this.outboundGrid);
            this.tpOutband.Name = "tpOutband";
            this.tpOutband.Size = new System.Drawing.Size(1041, 321);
            this.tpOutband.Text = "选择订单";
            // 
            // outboundGrid
            // 
            this.outboundGrid.ContextMenuStrip = this.ctxMenuBound;
            this.outboundGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outboundGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.outboundGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.outboundGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.outboundGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.outboundGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.outboundGrid.Location = new System.Drawing.Point(0, 0);
            this.outboundGrid.MainView = this.outboundView;
            this.outboundGrid.Name = "outboundGrid";
            this.outboundGrid.Size = new System.Drawing.Size(1041, 321);
            this.outboundGrid.TabIndex = 0;
            this.outboundGrid.UseEmbeddedNavigator = true;
            this.outboundGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.outboundView});
            // 
            // ctxMenuBound
            // 
            this.ctxMenuBound.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenuBound.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCheckAll,
            this.mnuNoCheck});
            this.ctxMenuBound.Name = "ctxMenuDetail";
            this.ctxMenuBound.Size = new System.Drawing.Size(101, 48);
            this.ctxMenuBound.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuBound_Opening);
            // 
            // mnuCheckAll
            // 
            this.mnuCheckAll.Name = "mnuCheckAll";
            this.mnuCheckAll.Size = new System.Drawing.Size(100, 22);
            this.mnuCheckAll.Text = "全选";
            this.mnuCheckAll.Click += new System.EventHandler(this.mnuCheckAll_Click);
            // 
            // mnuNoCheck
            // 
            this.mnuNoCheck.Name = "mnuNoCheck";
            this.mnuNoCheck.Size = new System.Drawing.Size(100, 22);
            this.mnuNoCheck.Text = "不选";
            this.mnuNoCheck.Click += new System.EventHandler(this.mnuNoCheck_Click);
            // 
            // outboundView
            // 
            this.outboundView.GridControl = this.outboundGrid;
            this.outboundView.Name = "outboundView";
            this.outboundView.OptionsView.ShowGroupPanel = false;
            // 
            // tpPreview
            // 
            this.tpPreview.Controls.Add(this.editGrid);
            this.tpPreview.Name = "tpPreview";
            this.tpPreview.Size = new System.Drawing.Size(1041, 321);
            this.tpPreview.Text = "预览";
            // 
            // editGrid
            // 
            this.editGrid.ContextMenuStrip = this.ctxMenuEdit;
            this.editGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editGrid.Location = new System.Drawing.Point(0, 0);
            this.editGrid.MainView = this.editView;
            this.editGrid.Name = "editGrid";
            this.editGrid.Size = new System.Drawing.Size(1041, 321);
            this.editGrid.TabIndex = 0;
            this.editGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.editView});
            // 
            // ctxMenuEdit
            // 
            this.ctxMenuEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsertRow,
            this.mnuDeleteRow});
            this.ctxMenuEdit.Name = "ctxMenu";
            this.ctxMenuEdit.Size = new System.Drawing.Size(101, 48);
            this.ctxMenuEdit.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuEdit_Opening);
            // 
            // mnuInsertRow
            // 
            this.mnuInsertRow.Name = "mnuInsertRow";
            this.mnuInsertRow.Size = new System.Drawing.Size(100, 22);
            this.mnuInsertRow.Text = "插入";
            this.mnuInsertRow.Click += new System.EventHandler(this.mnuInsertRow_Click);
            // 
            // mnuDeleteRow
            // 
            this.mnuDeleteRow.Name = "mnuDeleteRow";
            this.mnuDeleteRow.Size = new System.Drawing.Size(100, 22);
            this.mnuDeleteRow.Text = "删除";
            this.mnuDeleteRow.Click += new System.EventHandler(this.mnuDeleteRow_Click);
            // 
            // editView
            // 
            this.editView.GridControl = this.editGrid;
            this.editView.Name = "editView";
            this.editView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 408);
            this.Controls.Add(this.splitContainer);
            this.Name = "FrmInvoice";
            this.Text = "FrmInvoice";
            this.Load += new System.EventHandler(this.FrmInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKeyWords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).EndInit();
            this.xtraTab.ResumeLayout(false);
            this.tpOutband.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outboundGrid)).EndInit();
            this.ctxMenuBound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outboundView)).EndInit();
            this.tpPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editGrid)).EndInit();
            this.ctxMenuEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl lblFilter;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.LabelControl lblBeginDate;
        private DevExpress.XtraTab.XtraTabControl xtraTab;
        private DevExpress.XtraTab.XtraTabPage tpOutband;
        private DevExpress.XtraTab.XtraTabPage tpPreview;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraGrid.GridControl outboundGrid;
        private DevExpress.XtraEditors.LabelControl lblKeyWords;
        private System.Windows.Forms.ContextMenuStrip ctxMenuBound;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckAll;
        private System.Windows.Forms.ToolStripMenuItem mnuNoCheck;
        private DevExpress.XtraGrid.GridControl editGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView editView;
        private System.Windows.Forms.ContextMenuStrip ctxMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertRow;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteRow;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Views.Grid.GridView outboundView;
        private DevExpress.XtraEditors.TextEdit cboKeyWords;
        private DevExpress.XtraEditors.ComboBoxEdit cboFilter;
    }
}