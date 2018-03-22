namespace PengLang
{
    partial class FrmCommission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCommission));
            this.gbTop = new DevExpress.XtraEditors.GroupControl();
            this.btnPay = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.cboSales = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSales = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.lblBeginDate = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.commGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenuRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNoCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUnPay = new System.Windows.Forms.ToolStripMenuItem();
            this.commView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gbTop)).BeginInit();
            this.gbTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commGrid)).BeginInit();
            this.ctxMenuRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTop
            // 
            this.gbTop.Controls.Add(this.btnPay);
            this.gbTop.Controls.Add(this.btnExport);
            this.gbTop.Controls.Add(this.cboSales);
            this.gbTop.Controls.Add(this.lblSales);
            this.gbTop.Controls.Add(this.dateEnd);
            this.gbTop.Controls.Add(this.dateBegin);
            this.gbTop.Controls.Add(this.lblEndDate);
            this.gbTop.Controls.Add(this.lblBeginDate);
            this.gbTop.Controls.Add(this.btnSearch);
            this.gbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTop.Location = new System.Drawing.Point(0, 0);
            this.gbTop.Name = "gbTop";
            this.gbTop.ShowCaption = false;
            this.gbTop.Size = new System.Drawing.Size(760, 51);
            this.gbTop.TabIndex = 9;
            this.gbTop.Text = "检索";
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.Image = ((System.Drawing.Image)(resources.GetObject("btnPay.Image")));
            this.btnPay.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPay.Location = new System.Drawing.Point(585, 12);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(72, 31);
            this.btnPay.TabIndex = 14;
            this.btnPay.Text = "支付";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(668, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 31);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cboSales
            // 
            this.cboSales.Location = new System.Drawing.Point(320, 15);
            this.cboSales.Name = "cboSales";
            this.cboSales.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSales.Size = new System.Drawing.Size(151, 20);
            this.cboSales.TabIndex = 3;
            // 
            // lblSales
            // 
            this.lblSales.Location = new System.Drawing.Point(281, 18);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(39, 14);
            this.lblSales.TabIndex = 13;
            this.lblSales.Text = "Sales：";
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
            this.dateEnd.TabIndex = 2;
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
            this.dateBegin.TabIndex = 1;
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
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(479, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 31);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // commGrid
            // 
            this.commGrid.ContextMenuStrip = this.ctxMenuRecord;
            this.commGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.commGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.commGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.commGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.commGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.commGrid.Location = new System.Drawing.Point(0, 51);
            this.commGrid.MainView = this.commView;
            this.commGrid.Name = "commGrid";
            this.commGrid.Size = new System.Drawing.Size(760, 317);
            this.commGrid.TabIndex = 12;
            this.commGrid.UseEmbeddedNavigator = true;
            this.commGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.commView});
            // 
            // ctxMenuRecord
            // 
            this.ctxMenuRecord.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenuRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCheckAll,
            this.mnuNoCheck,
            this.mniUnPay});
            this.ctxMenuRecord.Name = "ctxMenuDetail";
            this.ctxMenuRecord.Size = new System.Drawing.Size(125, 70);
            this.ctxMenuRecord.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuRecord_Opening);
            // 
            // mnuCheckAll
            // 
            this.mnuCheckAll.Name = "mnuCheckAll";
            this.mnuCheckAll.Size = new System.Drawing.Size(124, 22);
            this.mnuCheckAll.Text = "全选";
            this.mnuCheckAll.Click += new System.EventHandler(this.mnuCheckAll_Click);
            // 
            // mnuNoCheck
            // 
            this.mnuNoCheck.Name = "mnuNoCheck";
            this.mnuNoCheck.Size = new System.Drawing.Size(124, 22);
            this.mnuNoCheck.Text = "不选";
            this.mnuNoCheck.Click += new System.EventHandler(this.mnuNoCheck_Click);
            // 
            // mniUnPay
            // 
            this.mniUnPay.Name = "mniUnPay";
            this.mniUnPay.Size = new System.Drawing.Size(124, 22);
            this.mniUnPay.Text = "取消支付";
            this.mniUnPay.Click += new System.EventHandler(this.mniUnPay_Click);
            // 
            // commView
            // 
            this.commView.GridControl = this.commGrid;
            this.commView.Name = "commView";
            this.commView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmCommission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 368);
            this.Controls.Add(this.commGrid);
            this.Controls.Add(this.gbTop);
            this.Name = "FrmCommission";
            this.Text = "佣金统计";
            this.Load += new System.EventHandler(this.FrmCommission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbTop)).EndInit();
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commGrid)).EndInit();
            this.ctxMenuRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbTop;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.ComboBoxEdit cboSales;
        private DevExpress.XtraEditors.LabelControl lblSales;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.LabelControl lblBeginDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.GridControl commGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView commView;
        private DevExpress.XtraEditors.SimpleButton btnPay;
        private System.Windows.Forms.ContextMenuStrip ctxMenuRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckAll;
        private System.Windows.Forms.ToolStripMenuItem mnuNoCheck;
        private System.Windows.Forms.ToolStripMenuItem mniUnPay;
    }
}