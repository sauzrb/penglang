namespace PengLang
{
    partial class FrmClothes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClothes));
            this.panClient = new DevExpress.XtraEditors.PanelControl();
            this.clothesGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.clothesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblKeywords = new DevExpress.XtraEditors.LabelControl();
            this.txtKeyWords = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panClient)).BeginInit();
            this.panClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clothesGrid)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clothesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panClient
            // 
            this.panClient.Controls.Add(this.clothesGrid);
            this.panClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panClient.Location = new System.Drawing.Point(0, 43);
            this.panClient.Name = "panClient";
            this.panClient.Size = new System.Drawing.Size(646, 352);
            this.panClient.TabIndex = 8;
            // 
            // clothesGrid
            // 
            this.clothesGrid.ContextMenuStrip = this.ctxMenu;
            this.clothesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clothesGrid.Location = new System.Drawing.Point(2, 2);
            this.clothesGrid.MainView = this.clothesView;
            this.clothesGrid.Name = "clothesGrid";
            this.clothesGrid.Size = new System.Drawing.Size(642, 348);
            this.clothesGrid.TabIndex = 0;
            this.clothesGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.clothesView});
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
            // clothesView
            // 
            this.clothesView.GridControl = this.clothesGrid;
            this.clothesView.Name = "clothesView";
            this.clothesView.OptionsView.ShowGroupPanel = false;
            this.clothesView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.GridView_ValidateRow);
            this.clothesView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridView_KeyUp);
            this.clothesView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.clothesView_ValidatingEditor);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.lblTitle);
            this.gbSearch.Controls.Add(this.lblKeywords);
            this.gbSearch.Controls.Add(this.txtKeyWords);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.ShowCaption = false;
            this.gbSearch.Size = new System.Drawing.Size(646, 43);
            this.gbSearch.TabIndex = 7;
            this.gbSearch.Text = "检索";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(577, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 27);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 14);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "【服装管理】";
            // 
            // lblKeywords
            // 
            this.lblKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeywords.Location = new System.Drawing.Point(368, 17);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(67, 14);
            this.lblKeywords.TabIndex = 1;
            this.lblKeywords.Text = "KeyWords：";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyWords.Location = new System.Drawing.Point(439, 14);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(132, 20);
            this.txtKeyWords.TabIndex = 0;
            this.txtKeyWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyWords_KeyPress);
            // 
            // FrmClothes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 395);
            this.Controls.Add(this.panClient);
            this.Controls.Add(this.gbSearch);
            this.Name = "FrmClothes";
            this.Text = "FrmClothes";
            this.Load += new System.EventHandler(this.FrmClothes_Load);
            this.Leave += new System.EventHandler(this.FrmClothes_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.panClient)).EndInit();
            this.panClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clothesGrid)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clothesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panClient;
        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl lblKeywords;
        private DevExpress.XtraEditors.TextEdit txtKeyWords;
        private DevExpress.XtraGrid.GridControl clothesGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView clothesView;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertRow;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteRow;
        private DevExpress.XtraEditors.LabelControl lblTitle;
    }
}