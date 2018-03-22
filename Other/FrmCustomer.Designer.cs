namespace PengLang
{
    partial class FrmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomer));
            this.panClient = new DevExpress.XtraEditors.PanelControl();
            this.custGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.custView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblCustomerNo = new DevExpress.XtraEditors.LabelControl();
            this.txtKeyWords = new DevExpress.XtraEditors.TextEdit();
            this.mnuSyncOutbound = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.panClient)).BeginInit();
            this.panClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custGrid)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panClient
            // 
            this.panClient.Controls.Add(this.custGrid);
            this.panClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panClient.Location = new System.Drawing.Point(0, 43);
            this.panClient.Name = "panClient";
            this.panClient.Size = new System.Drawing.Size(861, 297);
            this.panClient.TabIndex = 3;
            // 
            // custGrid
            // 
            this.custGrid.ContextMenuStrip = this.ctxMenu;
            this.custGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custGrid.Location = new System.Drawing.Point(2, 2);
            this.custGrid.MainView = this.custView;
            this.custGrid.Name = "custGrid";
            this.custGrid.Size = new System.Drawing.Size(857, 293);
            this.custGrid.TabIndex = 0;
            this.custGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.custView});
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuDelete,
            this.mnuSyncOutbound});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(153, 92);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = ((System.Drawing.Image)(resources.GetObject("mnuEdit.Image")));
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(152, 22);
            this.mnuEdit.Text = "修改";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(152, 22);
            this.mnuDelete.Text = "删除";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // custView
            // 
            this.custView.GridControl = this.custGrid;
            this.custView.Name = "custView";
            this.custView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.custView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.custView.OptionsCustomization.AllowColumnMoving = false;
            this.custView.OptionsCustomization.AllowRowSizing = true;
            this.custView.OptionsMenu.EnableColumnMenu = false;
            this.custView.OptionsMenu.EnableFooterMenu = false;
            this.custView.OptionsNavigation.AutoFocusNewRow = true;
            this.custView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.custView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.custView.OptionsView.RowAutoHeight = true;
            this.custView.OptionsView.ShowGroupPanel = false;
            this.custView.DoubleClick += new System.EventHandler(this.custView_DoubleClick);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnExport);
            this.gbSearch.Controls.Add(this.btnDelete);
            this.gbSearch.Controls.Add(this.btnEdit);
            this.gbSearch.Controls.Add(this.btnAdd);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.lblTitle);
            this.gbSearch.Controls.Add(this.lblCustomerNo);
            this.gbSearch.Controls.Add(this.txtKeyWords);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.ShowCaption = false;
            this.gbSearch.Size = new System.Drawing.Size(861, 43);
            this.gbSearch.TabIndex = 2;
            this.gbSearch.Text = "检索";
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(312, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(67, 28);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(239, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 28);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(166, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(67, 28);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(93, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(67, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(770, 8);
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
            this.lblTitle.Text = "【客户管理】";
            // 
            // lblCustomerNo
            // 
            this.lblCustomerNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerNo.Location = new System.Drawing.Point(537, 15);
            this.lblCustomerNo.Name = "lblCustomerNo";
            this.lblCustomerNo.Size = new System.Drawing.Size(71, 14);
            this.lblCustomerNo.TabIndex = 0;
            this.lblCustomerNo.Text = "Key Words：";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyWords.Location = new System.Drawing.Point(614, 13);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(143, 20);
            this.txtKeyWords.TabIndex = 0;
            this.txtKeyWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyWords_KeyPress);
            // 
            // mnuSyncOutbound
            // 
            this.mnuSyncOutbound.Name = "mnuSyncOutbound";
            this.mnuSyncOutbound.Size = new System.Drawing.Size(152, 22);
            this.mnuSyncOutbound.Text = "同步出库表";
            this.mnuSyncOutbound.Click += new System.EventHandler(this.mnuSyncOutbound_Click);
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 340);
            this.Controls.Add(this.panClient);
            this.Controls.Add(this.gbSearch);
            this.Name = "FrmCustomer";
            this.Text = "FrmCustomer";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panClient)).EndInit();
            this.panClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.custGrid)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.custView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panClient;
        private DevExpress.XtraGrid.GridControl custGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView custView;
        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblCustomerNo;
        private DevExpress.XtraEditors.TextEdit txtKeyWords;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ToolStripMenuItem mnuSyncOutbound;
    }
}