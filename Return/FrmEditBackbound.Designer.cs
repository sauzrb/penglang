namespace PengLang
{
    partial class FrmEditBackbound
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditBackbound));
            this.groupInbound = new DevExpress.XtraEditors.GroupControl();
            this.cboCustomer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboSales = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.labMemo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateOrder = new DevExpress.XtraEditors.DateEdit();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.txtBackboundNo = new System.Windows.Forms.TextBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.labFahuodan = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupInbound)).BeginInit();
            this.groupInbound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrder.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrder.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupInbound
            // 
            this.groupInbound.Controls.Add(this.cboCustomer);
            this.groupInbound.Controls.Add(this.cboSales);
            this.groupInbound.Controls.Add(this.txtMemo);
            this.groupInbound.Controls.Add(this.labMemo);
            this.groupInbound.Controls.Add(this.labelControl2);
            this.groupInbound.Controls.Add(this.labelControl1);
            this.groupInbound.Controls.Add(this.dateOrder);
            this.groupInbound.Controls.Add(this.lblDate);
            this.groupInbound.Controls.Add(this.txtBackboundNo);
            this.groupInbound.Controls.Add(this.txtPONo);
            this.groupInbound.Controls.Add(this.labFahuodan);
            this.groupInbound.Location = new System.Drawing.Point(12, 12);
            this.groupInbound.Name = "groupInbound";
            this.groupInbound.Size = new System.Drawing.Size(464, 178);
            this.groupInbound.TabIndex = 8;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Location = new System.Drawing.Point(294, 58);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCustomer.Size = new System.Drawing.Size(121, 20);
            this.cboCustomer.TabIndex = 4;
            // 
            // cboSales
            // 
            this.cboSales.Location = new System.Drawing.Point(94, 61);
            this.cboSales.Name = "cboSales";
            this.cboSales.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSales.Size = new System.Drawing.Size(114, 20);
            this.cboSales.TabIndex = 3;
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(94, 87);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(321, 74);
            this.txtMemo.TabIndex = 5;
            // 
            // labMemo
            // 
            this.labMemo.Location = new System.Drawing.Point(43, 90);
            this.labMemo.Name = "labMemo";
            this.labMemo.Size = new System.Drawing.Size(45, 14);
            this.labMemo.TabIndex = 7;
            this.labMemo.Text = "Memo：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(49, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Sales：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(226, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Customer：";
            // 
            // dateOrder
            // 
            this.dateOrder.EditValue = null;
            this.dateOrder.Location = new System.Drawing.Point(293, 35);
            this.dateOrder.Name = "dateOrder";
            this.dateOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateOrder.Size = new System.Drawing.Size(122, 20);
            this.dateOrder.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(251, 38);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 14);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date：";
            // 
            // txtBackboundNo
            // 
            this.txtBackboundNo.Location = new System.Drawing.Point(5, 33);
            this.txtBackboundNo.Name = "txtBackboundNo";
            this.txtBackboundNo.ReadOnly = true;
            this.txtBackboundNo.Size = new System.Drawing.Size(25, 21);
            this.txtBackboundNo.TabIndex = 0;
            this.txtBackboundNo.TabStop = false;
            this.txtBackboundNo.Visible = false;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(94, 34);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(123, 21);
            this.txtPONo.TabIndex = 1;
            // 
            // labFahuodan
            // 
            this.labFahuodan.Location = new System.Drawing.Point(50, 37);
            this.labFahuodan.Name = "labFahuodan";
            this.labFahuodan.Size = new System.Drawing.Size(41, 14);
            this.labFahuodan.TabIndex = 3;
            this.labFahuodan.Text = "P.O#：";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(398, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 32);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(286, 206);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 32);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmEditBackbound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 250);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupInbound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditBackbound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请填写退货单信息";
            this.Load += new System.EventHandler(this.FrmEditInbound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupInbound)).EndInit();
            this.groupInbound.ResumeLayout(false);
            this.groupInbound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrder.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrder.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupInbound;
        private DevExpress.XtraEditors.DateEdit dateOrder;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private System.Windows.Forms.TextBox txtBackboundNo;
        private System.Windows.Forms.TextBox txtPONo;
        private DevExpress.XtraEditors.LabelControl labFahuodan;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraEditors.ComboBoxEdit cboCustomer;
        private DevExpress.XtraEditors.ComboBoxEdit cboSales;
        private System.Windows.Forms.TextBox txtMemo;
        private DevExpress.XtraEditors.LabelControl labMemo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}