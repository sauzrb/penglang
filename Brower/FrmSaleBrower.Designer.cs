namespace PengLang
{
    partial class FrmSaleBrower
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaleBrower));
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtInQnt = new System.Windows.Forms.TextBox();
            this.cboArtNo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labInQnt = new DevExpress.XtraEditors.LabelControl();
            this.resGrid = new DevExpress.XtraGrid.GridControl();
            this.resView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.lblFilter = new DevExpress.XtraEditors.LabelControl();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.txtSelection = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboArtNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.lblFilter);
            this.gbSearch.Controls.Add(this.btnOK);
            this.gbSearch.Controls.Add(this.txtSelection);
            this.gbSearch.Controls.Add(this.txtInQnt);
            this.gbSearch.Controls.Add(this.cboArtNo);
            this.gbSearch.Controls.Add(this.btnExport);
            this.gbSearch.Controls.Add(this.btnSelect);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.labInQnt);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.ShowCaption = false;
            this.gbSearch.Size = new System.Drawing.Size(851, 50);
            this.gbSearch.TabIndex = 7;
            this.gbSearch.Text = "检索";
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(667, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtInQnt
            // 
            this.txtInQnt.Location = new System.Drawing.Point(585, 15);
            this.txtInQnt.Name = "txtInQnt";
            this.txtInQnt.Size = new System.Drawing.Size(68, 21);
            this.txtInQnt.TabIndex = 2;
            // 
            // cboArtNo
            // 
            this.cboArtNo.Location = new System.Drawing.Point(50, 16);
            this.cboArtNo.Name = "cboArtNo";
            this.cboArtNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboArtNo.Size = new System.Drawing.Size(137, 20);
            this.cboArtNo.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(742, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(65, 27);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(436, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 27);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "统计";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labInQnt
            // 
            this.labInQnt.Location = new System.Drawing.Point(507, 18);
            this.labInQnt.Name = "labInQnt";
            this.labInQnt.Size = new System.Drawing.Size(72, 14);
            this.labInQnt.TabIndex = 1;
            this.labInQnt.Text = "新订单数量：";
            // 
            // resGrid
            // 
            this.resGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resGrid.Location = new System.Drawing.Point(0, 50);
            this.resGrid.MainView = this.resView;
            this.resGrid.Name = "resGrid";
            this.resGrid.Size = new System.Drawing.Size(851, 342);
            this.resGrid.TabIndex = 9;
            this.resGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.resView});
            // 
            // resView
            // 
            this.resView.CustomizationFormBounds = new System.Drawing.Rectangle(708, 368, 222, 224);
            this.resView.GridControl = this.resGrid;
            this.resView.Name = "resView";
            this.resView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.resView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.resView.OptionsBehavior.ReadOnly = true;
            this.resView.OptionsCustomization.AllowBandMoving = false;
            this.resView.OptionsCustomization.AllowSort = false;
            this.resView.OptionsHint.ShowBandHeaderHints = false;
            this.resView.OptionsHint.ShowCellHints = false;
            this.resView.OptionsHint.ShowColumnHeaderHints = false;
            this.resView.OptionsHint.ShowFooterHints = false;
            this.resView.OptionsMenu.EnableColumnMenu = false;
            this.resView.OptionsMenu.EnableFooterMenu = false;
            this.resView.OptionsSelection.MultiSelect = true;
            this.resView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.resView.OptionsView.ColumnAutoWidth = false;
            this.resView.OptionsView.ShowColumnHeaders = false;
            this.resView.OptionsView.ShowGroupPanel = false;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(12, 18);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(38, 14);
            this.lblFilter.TabIndex = 15;
            this.lblFilter.Text = "Art#：";
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(193, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(61, 27);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "选中";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtSelection
            // 
            this.txtSelection.Location = new System.Drawing.Point(260, 15);
            this.txtSelection.Name = "txtSelection";
            this.txtSelection.Size = new System.Drawing.Size(170, 21);
            this.txtSelection.TabIndex = 2;
            // 
            // FrmSaleBrower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 392);
            this.Controls.Add(this.resGrid);
            this.Controls.Add(this.gbSearch);
            this.Name = "FrmSaleBrower";
            this.Text = "FrmSaleBrower";
            this.Load += new System.EventHandler(this.FrmSaleBrower_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboArtNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cboArtNo;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.GridControl resGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView resView;
        private System.Windows.Forms.TextBox txtInQnt;
        private DevExpress.XtraEditors.LabelControl labInQnt;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraEditors.LabelControl lblFilter;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private System.Windows.Forms.TextBox txtSelection;
    }
}