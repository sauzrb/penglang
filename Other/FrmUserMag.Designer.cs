namespace PengLang
{
    partial class FrmUserMag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserMag));
            this.userGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.userView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblCustomerNo = new DevExpress.XtraEditors.LabelControl();
            this.txtKeyWords = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // userGrid
            // 
            this.userGrid.ContextMenuStrip = this.ctxMenu;
            this.userGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userGrid.Location = new System.Drawing.Point(0, 43);
            this.userGrid.MainView = this.userView;
            this.userGrid.Name = "userGrid";
            this.userGrid.Size = new System.Drawing.Size(712, 267);
            this.userGrid.TabIndex = 3;
            this.userGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.userView});
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
            // userView
            // 
            this.userView.GridControl = this.userGrid;
            this.userView.Name = "userView";
            this.userView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.userView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.userView.OptionsCustomization.AllowColumnMoving = false;
            this.userView.OptionsCustomization.AllowRowSizing = true;
            this.userView.OptionsMenu.EnableColumnMenu = false;
            this.userView.OptionsMenu.EnableFooterMenu = false;
            this.userView.OptionsNavigation.AutoFocusNewRow = true;
            this.userView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.userView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.userView.OptionsView.RowAutoHeight = true;
            this.userView.OptionsView.ShowGroupPanel = false;
            this.userView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.userView_CustomDrawCell);
            this.userView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.GridView_ValidateRow);
            this.userView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridView_KeyUp);
            this.userView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.clothesView_ValidatingEditor);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.lblTitle);
            this.gbSearch.Controls.Add(this.lblCustomerNo);
            this.gbSearch.Controls.Add(this.txtKeyWords);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.ShowCaption = false;
            this.gbSearch.Size = new System.Drawing.Size(712, 43);
            this.gbSearch.TabIndex = 4;
            this.gbSearch.Text = "检索";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(621, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 27);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 14);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "【员工管理】";
            // 
            // lblCustomerNo
            // 
            this.lblCustomerNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerNo.Location = new System.Drawing.Point(388, 15);
            this.lblCustomerNo.Name = "lblCustomerNo";
            this.lblCustomerNo.Size = new System.Drawing.Size(71, 14);
            this.lblCustomerNo.TabIndex = 0;
            this.lblCustomerNo.Text = "Key Words：";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyWords.Location = new System.Drawing.Point(465, 13);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(143, 20);
            this.txtKeyWords.TabIndex = 0;
            this.txtKeyWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyWords_KeyPress);
            // 
            // FrmUserMag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 310);
            this.Controls.Add(this.userGrid);
            this.Controls.Add(this.gbSearch);
            this.Name = "FrmUserMag";
            this.Text = "FrmUserMag";
            this.Load += new System.EventHandler(this.FrmUserMag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl userGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView userView;
        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblCustomerNo;
        private DevExpress.XtraEditors.TextEdit txtKeyWords;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertRow;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteRow;
    }
}