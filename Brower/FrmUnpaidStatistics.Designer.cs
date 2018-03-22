namespace PengLang
{
    partial class FrmUnpaidStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUnpaidStatistics));
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.cboKeyWords = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblFilter = new DevExpress.XtraEditors.LabelControl();
            this.lblKeyWords = new DevExpress.XtraEditors.LabelControl();
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.lblBeginDate = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.resGrid = new DevExpress.XtraGrid.GridControl();
            this.resView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKeyWords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.cboKeyWords);
            this.gbSearch.Controls.Add(this.cboFilter);
            this.gbSearch.Controls.Add(this.lblFilter);
            this.gbSearch.Controls.Add(this.lblKeyWords);
            this.gbSearch.Controls.Add(this.lblEndDate);
            this.gbSearch.Controls.Add(this.dateEnd);
            this.gbSearch.Controls.Add(this.dateBegin);
            this.gbSearch.Controls.Add(this.lblBeginDate);
            this.gbSearch.Controls.Add(this.btnExport);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.ShowCaption = false;
            this.gbSearch.Size = new System.Drawing.Size(896, 50);
            this.gbSearch.TabIndex = 7;
            this.gbSearch.Text = "检索";
            // 
            // cboKeyWords
            // 
            this.cboKeyWords.Location = new System.Drawing.Point(563, 15);
            this.cboKeyWords.Name = "cboKeyWords";
            this.cboKeyWords.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKeyWords.Size = new System.Drawing.Size(172, 20);
            this.cboKeyWords.TabIndex = 4;
            this.cboKeyWords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboKeyWords_KeyPress);
            // 
            // cboFilter
            // 
            this.cboFilter.Location = new System.Drawing.Point(348, 16);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFilter.Size = new System.Drawing.Size(137, 20);
            this.cboFilter.TabIndex = 3;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(305, 18);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(38, 14);
            this.lblFilter.TabIndex = 17;
            this.lblFilter.Text = "Filter：";
            // 
            // lblKeyWords
            // 
            this.lblKeyWords.Location = new System.Drawing.Point(492, 18);
            this.lblKeyWords.Name = "lblKeyWords";
            this.lblKeyWords.Size = new System.Drawing.Size(67, 14);
            this.lblKeyWords.TabIndex = 16;
            this.lblKeyWords.Text = "KeyWords：";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(177, 19);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(15, 14);
            this.lblEndDate.TabIndex = 11;
            this.lblEndDate.Text = "To";
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(198, 16);
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
            this.dateBegin.Location = new System.Drawing.Point(74, 16);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateBegin.TabIndex = 1;
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.Location = new System.Drawing.Point(12, 18);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(61, 14);
            this.lblBeginDate.TabIndex = 10;
            this.lblBeginDate.Text = "ShipDate：";
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(823, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(68, 27);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(742, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 27);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "统计";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // resGrid
            // 
            this.resGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.resGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.resGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.resGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.resGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.resGrid.Location = new System.Drawing.Point(0, 50);
            this.resGrid.MainView = this.resView;
            this.resGrid.Name = "resGrid";
            this.resGrid.Size = new System.Drawing.Size(896, 295);
            this.resGrid.TabIndex = 13;
            this.resGrid.UseEmbeddedNavigator = true;
            this.resGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.resView});
            // 
            // resView
            // 
            this.resView.GridControl = this.resGrid;
            this.resView.Name = "resView";
            this.resView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmUnpaidStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 345);
            this.Controls.Add(this.resGrid);
            this.Controls.Add(this.gbSearch);
            this.Name = "FrmUnpaidStatistics";
            this.Text = "未付款统计";
            this.Load += new System.EventHandler(this.FrmUnpaidStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKeyWords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.LabelControl lblBeginDate;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraGrid.GridControl resGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView resView;
        private DevExpress.XtraEditors.ComboBoxEdit cboKeyWords;
        private DevExpress.XtraEditors.ComboBoxEdit cboFilter;
        private DevExpress.XtraEditors.LabelControl lblFilter;
        private DevExpress.XtraEditors.LabelControl lblKeyWords;
    }
}