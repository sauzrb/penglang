namespace PengLang
{
    partial class FrmClothesStyle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClothesStyle));
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.styleGrid = new DevExpress.XtraGrid.GridControl();
            this.styleView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStyleNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnRefresh);
            this.gbSearch.Controls.Add(this.lblTitle);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.ShowCaption = false;
            this.gbSearch.Size = new System.Drawing.Size(616, 43);
            this.gbSearch.TabIndex = 8;
            this.gbSearch.Text = "检索";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(520, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 27);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 14);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "【服装款式】";
            // 
            // styleGrid
            // 
            this.styleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleGrid.Location = new System.Drawing.Point(0, 43);
            this.styleGrid.MainView = this.styleView;
            this.styleGrid.Name = "styleGrid";
            this.styleGrid.Size = new System.Drawing.Size(616, 319);
            this.styleGrid.TabIndex = 9;
            this.styleGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.styleView});
            // 
            // styleView
            // 
            this.styleView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStyleNo,
            this.colRemark});
            this.styleView.GridControl = this.styleGrid;
            this.styleView.Name = "styleView";
            this.styleView.OptionsView.ShowGroupPanel = false;
            this.styleView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.styleView_ValidatingEditor);
            // 
            // colStyleNo
            // 
            this.colStyleNo.Caption = "Style#";
            this.colStyleNo.FieldName = "StyleNo";
            this.colStyleNo.Name = "colStyleNo";
            this.colStyleNo.Visible = true;
            this.colStyleNo.VisibleIndex = 0;
            this.colStyleNo.Width = 120;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "Memo";
            this.colRemark.FieldName = "StyleRemark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 1;
            this.colRemark.Width = 478;
            // 
            // FrmClothesStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 362);
            this.Controls.Add(this.styleGrid);
            this.Controls.Add(this.gbSearch);
            this.Name = "FrmClothesStyle";
            this.Text = "服装款式";
            this.Load += new System.EventHandler(this.FrmClothesStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraGrid.GridControl styleGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView styleView;
        private DevExpress.XtraGrid.Columns.GridColumn colStyleNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}