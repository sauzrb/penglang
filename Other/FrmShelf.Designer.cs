namespace PengLang 
{
    partial class FrmShelf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShelf));
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.panClient = new DevExpress.XtraEditors.PanelControl();
            this.shelfGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.shelfView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblShelfNo = new DevExpress.XtraEditors.LabelControl();
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtKeyWords = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panClient)).BeginInit();
            this.panClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shelfGrid)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shelfView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(521, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 27);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "检索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panClient
            // 
            this.panClient.Controls.Add(this.shelfGrid);
            this.panClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panClient.Location = new System.Drawing.Point(0, 43);
            this.panClient.Name = "panClient";
            this.panClient.Size = new System.Drawing.Size(595, 324);
            this.panClient.TabIndex = 1;
            // 
            // shelfGrid
            // 
            this.shelfGrid.ContextMenuStrip = this.ctxMenu;
            this.shelfGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shelfGrid.Location = new System.Drawing.Point(2, 2);
            this.shelfGrid.MainView = this.shelfView;
            this.shelfGrid.Name = "shelfGrid";
            this.shelfGrid.Size = new System.Drawing.Size(591, 320);
            this.shelfGrid.TabIndex = 0;
            this.shelfGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.shelfView});
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsertRow,
            this.mnuDeleteRow});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(153, 70);
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
            // shelfView
            // 
            this.shelfView.GridControl = this.shelfGrid;
            this.shelfView.Name = "shelfView";
            this.shelfView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.shelfView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.shelfView.OptionsCustomization.AllowColumnMoving = false;
            this.shelfView.OptionsMenu.EnableColumnMenu = false;
            this.shelfView.OptionsMenu.EnableFooterMenu = false;
            this.shelfView.OptionsNavigation.AutoFocusNewRow = true;
            this.shelfView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.shelfView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.shelfView.OptionsView.ShowGroupPanel = false;
            this.shelfView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.GridView_ValidateRow);
            this.shelfView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridView_KeyUp);
            this.shelfView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.GridView_ValidatingEditor);
            // 
            // lblShelfNo
            // 
            this.lblShelfNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShelfNo.Location = new System.Drawing.Point(367, 15);
            this.lblShelfNo.Name = "lblShelfNo";
            this.lblShelfNo.Size = new System.Drawing.Size(48, 14);
            this.lblShelfNo.TabIndex = 0;
            this.lblShelfNo.Text = "货架号：";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.lblTitle);
            this.gbSearch.Controls.Add(this.lblShelfNo);
            this.gbSearch.Controls.Add(this.txtKeyWords);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.ShowCaption = false;
            this.gbSearch.Size = new System.Drawing.Size(595, 43);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.Text = "检索";
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 14);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "【货架管理】";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyWords.Location = new System.Drawing.Point(420, 13);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(94, 20);
            this.txtKeyWords.TabIndex = 0;
            this.txtKeyWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyWords_KeyPress);
            // 
            // FrmShelf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 367);
            this.Controls.Add(this.panClient);
            this.Controls.Add(this.gbSearch);
            this.Name = "FrmShelf";
            this.Text = "FrmShelf";
            this.Load += new System.EventHandler(this.FrmShelf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panClient)).EndInit();
            this.panClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shelfGrid)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shelfView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.PanelControl panClient;
        private DevExpress.XtraEditors.LabelControl lblShelfNo;
        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.TextEdit txtKeyWords;
        private DevExpress.XtraGrid.GridControl shelfGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView shelfView;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertRow;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteRow;
        private DevExpress.XtraEditors.LabelControl lblTitle;

    }
}