namespace PengLang
{
    partial class FrmAccountCash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccountCash));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.labDate = new System.Windows.Forms.Label();
            this.dateRcvt = new DevExpress.XtraEditors.DateEdit();
            this.labAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboRvdKind = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtFactFee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labDol = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labRvdKind = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dateRcvt.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRcvt.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRvdKind.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(398, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 32);
            this.btnCancel.TabIndex = 2;
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
            this.btnOK.Location = new System.Drawing.Point(297, 215);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 32);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labDate
            // 
            this.labDate.AutoSize = true;
            this.labDate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDate.Location = new System.Drawing.Point(22, 24);
            this.labDate.Name = "labDate";
            this.labDate.Size = new System.Drawing.Size(79, 20);
            this.labDate.TabIndex = 13;
            this.labDate.Text = "收款日期：";
            // 
            // dateRcvt
            // 
            this.dateRcvt.EditValue = null;
            this.dateRcvt.Location = new System.Drawing.Point(103, 21);
            this.dateRcvt.Name = "dateRcvt";
            this.dateRcvt.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRcvt.Properties.Appearance.Options.UseFont = true;
            this.dateRcvt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateRcvt.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateRcvt.Size = new System.Drawing.Size(121, 26);
            this.dateRcvt.TabIndex = 1;
            // 
            // labAmount
            // 
            this.labAmount.AutoSize = true;
            this.labAmount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAmount.Location = new System.Drawing.Point(247, 24);
            this.labAmount.Name = "labAmount";
            this.labAmount.Size = new System.Drawing.Size(79, 20);
            this.labAmount.TabIndex = 13;
            this.labAmount.Text = "收款金额：";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAmount.Location = new System.Drawing.Point(330, 21);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(95, 26);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboRvdKind);
            this.groupBox1.Controls.Add(this.dateRcvt);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.txtFactFee);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.labDol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labAmount);
            this.groupBox1.Controls.Add(this.labRvdKind);
            this.groupBox1.Controls.Add(this.labDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cboRvdKind
            // 
            this.cboRvdKind.Location = new System.Drawing.Point(103, 60);
            this.cboRvdKind.Name = "cboRvdKind";
            this.cboRvdKind.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRvdKind.Properties.Appearance.Options.UseFont = true;
            this.cboRvdKind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRvdKind.Properties.Items.AddRange(new object[] {
            "",
            "AMZ",
            "FAC",
            "ZL"});
            this.cboRvdKind.Size = new System.Drawing.Size(121, 26);
            this.cboRvdKind.TabIndex = 3;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(103, 94);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(338, 91);
            this.txtRemark.TabIndex = 5;
            // 
            // txtFactFee
            // 
            this.txtFactFee.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFactFee.Location = new System.Drawing.Point(330, 58);
            this.txtFactFee.Name = "txtFactFee";
            this.txtFactFee.Size = new System.Drawing.Size(95, 26);
            this.txtFactFee.TabIndex = 4;
            this.txtFactFee.Visible = false;
            this.txtFactFee.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtFactFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(429, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "$";
            this.label3.Visible = false;
            // 
            // labDol
            // 
            this.labDol.AutoSize = true;
            this.labDol.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDol.Location = new System.Drawing.Point(429, 23);
            this.labDol.Name = "labDol";
            this.labDol.Size = new System.Drawing.Size(17, 20);
            this.labDol.TabIndex = 13;
            this.labDol.Text = "$";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(275, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "费用：";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(34, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "备    注：";
            // 
            // labRvdKind
            // 
            this.labRvdKind.AutoSize = true;
            this.labRvdKind.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRvdKind.Location = new System.Drawing.Point(22, 61);
            this.labRvdKind.Name = "labRvdKind";
            this.labRvdKind.Size = new System.Drawing.Size(79, 20);
            this.labRvdKind.TabIndex = 13;
            this.labRvdKind.Text = "收款分类：";
            // 
            // FrmAccountCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 255);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAccountCash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "收款";
            this.Load += new System.EventHandler(this.FrmCash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateRcvt.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRcvt.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRvdKind.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labDate;
        private DevExpress.XtraEditors.DateEdit dateRcvt;
        private System.Windows.Forms.Label labAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labDol;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ComboBoxEdit cboRvdKind;
        private System.Windows.Forms.Label labRvdKind;
        private System.Windows.Forms.TextBox txtFactFee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}