namespace PengLang
{
    partial class FrmEditInventroy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditInventroy));
            this.btnSave = new System.Windows.Forms.Button();
            this.panCtrl = new DevExpress.XtraEditors.PanelControl();
            this.cboShelfNo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.detailGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.detailView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.detailBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.panCtrl)).BeginInit();
            this.panCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboShelfNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(509, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panCtrl
            // 
            this.panCtrl.Controls.Add(this.cboShelfNo);
            this.panCtrl.Controls.Add(this.btnSearch);
            this.panCtrl.Controls.Add(this.lblTitle);
            this.panCtrl.Controls.Add(this.btnCancel);
            this.panCtrl.Controls.Add(this.btnSave);
            this.panCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panCtrl.Location = new System.Drawing.Point(0, 0);
            this.panCtrl.Name = "panCtrl";
            this.panCtrl.Size = new System.Drawing.Size(680, 46);
            this.panCtrl.TabIndex = 1;
            // 
            // cboShelfNo
            // 
            this.cboShelfNo.EditValue = "";
            this.cboShelfNo.Location = new System.Drawing.Point(171, 14);
            this.cboShelfNo.Name = "cboShelfNo";
            this.cboShelfNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboShelfNo.Size = new System.Drawing.Size(95, 20);
            this.cboShelfNo.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(271, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 31);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "OK";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(152, 14);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "【修改库存】--请选择货架号";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(593, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // detailGrid
            // 
            this.detailGrid.ContextMenuStrip = this.ctxMenu;
            this.detailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailGrid.Location = new System.Drawing.Point(0, 46);
            this.detailGrid.MainView = this.detailView;
            this.detailGrid.Name = "detailGrid";
            this.detailGrid.Size = new System.Drawing.Size(680, 294);
            this.detailGrid.TabIndex = 2;
            this.detailGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.detailView});
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsertRow,
            this.mnuDeleteRow});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(101, 48);
            this.ctxMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenu_Opening);
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
            // detailView
            // 
            this.detailView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.detailBand});
            this.detailView.GridControl = this.detailGrid;
            this.detailView.Name = "detailView";
            this.detailView.OptionsView.ShowGroupPanel = false;
            // 
            // detailBand
            // 
            this.detailBand.Caption = "detailBand";
            this.detailBand.Name = "detailBand";
            this.detailBand.VisibleIndex = 0;
            // 
            // FrmEditInventroy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 340);
            this.Controls.Add(this.detailGrid);
            this.Controls.Add(this.panCtrl);
            this.Name = "FrmEditInventroy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改库存";
            this.Load += new System.EventHandler(this.FrmEditInventroy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panCtrl)).EndInit();
            this.panCtrl.ResumeLayout(false);
            this.panCtrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboShelfNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraEditors.PanelControl panCtrl;
        private DevExpress.XtraGrid.GridControl detailGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView detailView;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand detailBand;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertRow;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteRow;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cboShelfNo;
        private System.Windows.Forms.Button btnCancel;
    }
}