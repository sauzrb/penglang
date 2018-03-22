namespace PengLang
{
    partial class FrmCashWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCashWindow));
            this.gbTop = new DevExpress.XtraEditors.GroupControl();
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            this.btnCash = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.lblBeginDate = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.masterGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMaster = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMasterDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.masterView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSerialNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRcvdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRcvdAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDecmAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRcvdKind = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rcvdGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxRcvd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRcvdDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.rcvdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mnuRcvdEdit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gbTop)).BeginInit();
            this.gbTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).BeginInit();
            this.ctxMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdGrid)).BeginInit();
            this.ctxRcvd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTop
            // 
            this.gbTop.Controls.Add(this.btnCheck);
            this.gbTop.Controls.Add(this.btnCash);
            this.gbTop.Controls.Add(this.btnExport);
            this.gbTop.Controls.Add(this.dateEnd);
            this.gbTop.Controls.Add(this.dateBegin);
            this.gbTop.Controls.Add(this.lblEndDate);
            this.gbTop.Controls.Add(this.lblBeginDate);
            this.gbTop.Controls.Add(this.btnSearch);
            this.gbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTop.Location = new System.Drawing.Point(0, 0);
            this.gbTop.Name = "gbTop";
            this.gbTop.ShowCaption = false;
            this.gbTop.Size = new System.Drawing.Size(768, 51);
            this.gbTop.TabIndex = 9;
            this.gbTop.Text = "检索";
            // 
            // btnCheck
            // 
            this.btnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnCheck.Image")));
            this.btnCheck.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(494, 11);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(87, 31);
            this.btnCheck.TabIndex = 16;
            this.btnCheck.Text = "销售认领";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCash
            // 
            this.btnCash.Image = ((System.Drawing.Image)(resources.GetObject("btnCash.Image")));
            this.btnCash.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCash.Location = new System.Drawing.Point(394, 11);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(87, 31);
            this.btnCash.TabIndex = 15;
            this.btnCash.Text = "财务收款";
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(670, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 31);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(193, 16);
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
            this.dateBegin.Location = new System.Drawing.Point(69, 16);
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
            this.lblEndDate.Location = new System.Drawing.Point(173, 18);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(12, 14);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "到";
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.Location = new System.Drawing.Point(7, 18);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(60, 14);
            this.lblBeginDate.TabIndex = 7;
            this.lblBeginDate.Text = "收款日期：";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(309, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 31);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 51);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.masterGrid);
            this.splitContainer.Panel1.Text = "Panel1";
            this.splitContainer.Panel2.Controls.Add(this.rcvdGrid);
            this.splitContainer.Panel2.Text = "Panel2";
            this.splitContainer.Size = new System.Drawing.Size(768, 293);
            this.splitContainer.SplitterPosition = 606;
            this.splitContainer.TabIndex = 15;
            this.splitContainer.Text = "splitContainerControl1";
            // 
            // masterGrid
            // 
            this.masterGrid.ContextMenuStrip = this.ctxMaster;
            this.masterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.masterGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.masterGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.masterGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.masterGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.masterGrid.Location = new System.Drawing.Point(0, 0);
            this.masterGrid.MainView = this.masterView;
            this.masterGrid.Name = "masterGrid";
            this.masterGrid.Size = new System.Drawing.Size(606, 293);
            this.masterGrid.TabIndex = 15;
            this.masterGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.masterView});
            this.masterGrid.Click += new System.EventHandler(this.masterGrid_Click);
            // 
            // ctxMaster
            // 
            this.ctxMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMasterDelete});
            this.ctxMaster.Name = "ctxMaster";
            this.ctxMaster.Size = new System.Drawing.Size(101, 26);
            this.ctxMaster.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMaster_Opening);
            // 
            // mnuMasterDelete
            // 
            this.mnuMasterDelete.Name = "mnuMasterDelete";
            this.mnuMasterDelete.Size = new System.Drawing.Size(100, 22);
            this.mnuMasterDelete.Text = "删除";
            this.mnuMasterDelete.Click += new System.EventHandler(this.mnuMasterDelete_Click);
            // 
            // masterView
            // 
            this.masterView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSerialNo,
            this.colRcvdDate,
            this.colRcvdAmount,
            this.colDecmAmount,
            this.colRcvdKind,
            this.colFactFee,
            this.colRemark});
            this.masterView.GridControl = this.masterGrid;
            this.masterView.Name = "masterView";
            this.masterView.OptionsView.ColumnAutoWidth = false;
            this.masterView.OptionsView.ShowGroupPanel = false;
            // 
            // colSerialNo
            // 
            this.colSerialNo.Caption = "RecordID";
            this.colSerialNo.FieldName = "SerialNo";
            this.colSerialNo.Name = "colSerialNo";
            // 
            // colRcvdDate
            // 
            this.colRcvdDate.Caption = "收款时间";
            this.colRcvdDate.FieldName = "RcvdDate";
            this.colRcvdDate.Name = "colRcvdDate";
            this.colRcvdDate.Visible = true;
            this.colRcvdDate.VisibleIndex = 0;
            this.colRcvdDate.Width = 100;
            // 
            // colRcvdAmount
            // 
            this.colRcvdAmount.Caption = "收到金额";
            this.colRcvdAmount.DisplayFormat.FormatString = "0.00";
            this.colRcvdAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRcvdAmount.FieldName = "RcvdAmount";
            this.colRcvdAmount.Name = "colRcvdAmount";
            this.colRcvdAmount.Visible = true;
            this.colRcvdAmount.VisibleIndex = 1;
            this.colRcvdAmount.Width = 110;
            // 
            // colDecmAmount
            // 
            this.colDecmAmount.Caption = "认领金额";
            this.colDecmAmount.DisplayFormat.FormatString = "0.00";
            this.colDecmAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colDecmAmount.FieldName = "DecmAmount";
            this.colDecmAmount.Name = "colDecmAmount";
            this.colDecmAmount.Visible = true;
            this.colDecmAmount.VisibleIndex = 2;
            this.colDecmAmount.Width = 110;
            // 
            // colRcvdKind
            // 
            this.colRcvdKind.Caption = "收款类型";
            this.colRcvdKind.FieldName = "RcvdKind";
            this.colRcvdKind.Name = "colRcvdKind";
            this.colRcvdKind.Visible = true;
            this.colRcvdKind.VisibleIndex = 3;
            this.colRcvdKind.Width = 80;
            // 
            // colFactFee
            // 
            this.colFactFee.Caption = "费用";
            this.colFactFee.DisplayFormat.FormatString = "0.00";
            this.colFactFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colFactFee.FieldName = "FactFee";
            this.colFactFee.Name = "colFactFee";
            this.colFactFee.Visible = true;
            this.colFactFee.VisibleIndex = 4;
            this.colFactFee.Width = 110;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 5;
            this.colRemark.Width = 100;
            // 
            // rcvdGrid
            // 
            this.rcvdGrid.ContextMenuStrip = this.ctxRcvd;
            this.rcvdGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rcvdGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.rcvdGrid.Location = new System.Drawing.Point(0, 0);
            this.rcvdGrid.MainView = this.rcvdView;
            this.rcvdGrid.Name = "rcvdGrid";
            this.rcvdGrid.Size = new System.Drawing.Size(157, 293);
            this.rcvdGrid.TabIndex = 13;
            this.rcvdGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.rcvdView});
            // 
            // ctxRcvd
            // 
            this.ctxRcvd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRcvdEdit,
            this.mnuRcvdDelete});
            this.ctxRcvd.Name = "ctxMaster";
            this.ctxRcvd.Size = new System.Drawing.Size(153, 70);
            this.ctxRcvd.Opening += new System.ComponentModel.CancelEventHandler(this.ctxRcvd_Opening);
            // 
            // mnuRcvdDelete
            // 
            this.mnuRcvdDelete.Name = "mnuRcvdDelete";
            this.mnuRcvdDelete.Size = new System.Drawing.Size(152, 22);
            this.mnuRcvdDelete.Text = "删除";
            this.mnuRcvdDelete.Click += new System.EventHandler(this.mnuRcvdDelete_Click);
            // 
            // rcvdView
            // 
            this.rcvdView.GridControl = this.rcvdGrid;
            this.rcvdView.Name = "rcvdView";
            this.rcvdView.OptionsView.ShowGroupPanel = false;
            this.rcvdView.DoubleClick += new System.EventHandler(this.rcvdView_DoubleClick);
            // 
            // mnuRcvdEdit
            // 
            this.mnuRcvdEdit.Name = "mnuRcvdEdit";
            this.mnuRcvdEdit.Size = new System.Drawing.Size(152, 22);
            this.mnuRcvdEdit.Text = "修改";
            this.mnuRcvdEdit.Click += new System.EventHandler(this.mnuRcvdEdit_Click);
            // 
            // FrmCashWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 344);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.gbTop);
            this.Name = "FrmCashWindow";
            this.Text = "收款";
            this.Load += new System.EventHandler(this.FrmCashWindow_Load);
            this.Resize += new System.EventHandler(this.FrmCashWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gbTop)).EndInit();
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).EndInit();
            this.ctxMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdGrid)).EndInit();
            this.ctxRcvd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rcvdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbTop;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.LabelControl lblBeginDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnCash;
        private DevExpress.XtraEditors.SimpleButton btnCheck;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        private DevExpress.XtraGrid.GridControl masterGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView masterView;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRcvdDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRcvdAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.GridControl rcvdGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView rcvdView;
        private System.Windows.Forms.ContextMenuStrip ctxMaster;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterDelete;
        private System.Windows.Forms.ContextMenuStrip ctxRcvd;
        private System.Windows.Forms.ToolStripMenuItem mnuRcvdDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDecmAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRcvdKind;
        private DevExpress.XtraGrid.Columns.GridColumn colFactFee;
        private System.Windows.Forms.ToolStripMenuItem mnuRcvdEdit;
    }
}