namespace PengLang
{
    partial class FrmRcvdEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRcvdEdit));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbBackground = new System.Windows.Forms.GroupBox();
            this.cboPayOff = new System.Windows.Forms.ComboBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRcvdAmt = new System.Windows.Forms.TextBox();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.txtInvAmt = new System.Windows.Forms.TextBox();
            this.txtPoNo = new System.Windows.Forms.TextBox();
            this.lblSales = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRcvdAmt = new System.Windows.Forms.Label();
            this.lblInvAmt = new System.Windows.Forms.Label();
            this.lblPO = new System.Windows.Forms.Label();
            this.gbBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(240, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 31);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(333, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbBackground
            // 
            this.gbBackground.Controls.Add(this.cboPayOff);
            this.gbBackground.Controls.Add(this.txtRemark);
            this.gbBackground.Controls.Add(this.lblRemark);
            this.gbBackground.Controls.Add(this.txtRcvdAmt);
            this.gbBackground.Controls.Add(this.txtSales);
            this.gbBackground.Controls.Add(this.txtInvAmt);
            this.gbBackground.Controls.Add(this.txtPoNo);
            this.gbBackground.Controls.Add(this.lblSales);
            this.gbBackground.Controls.Add(this.label1);
            this.gbBackground.Controls.Add(this.label3);
            this.gbBackground.Controls.Add(this.label2);
            this.gbBackground.Controls.Add(this.lblRcvdAmt);
            this.gbBackground.Controls.Add(this.lblInvAmt);
            this.gbBackground.Controls.Add(this.lblPO);
            this.gbBackground.Location = new System.Drawing.Point(10, 5);
            this.gbBackground.Name = "gbBackground";
            this.gbBackground.Size = new System.Drawing.Size(400, 157);
            this.gbBackground.TabIndex = 1;
            this.gbBackground.TabStop = false;
            // 
            // cboPayOff
            // 
            this.cboPayOff.FormattingEnabled = true;
            this.cboPayOff.Items.AddRange(new object[] {
            "",
            "YES"});
            this.cboPayOff.Location = new System.Drawing.Point(296, 77);
            this.cboPayOff.Name = "cboPayOff";
            this.cboPayOff.Size = new System.Drawing.Size(94, 20);
            this.cboPayOff.TabIndex = 5;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(102, 105);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(288, 42);
            this.txtRemark.TabIndex = 6;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemark.Location = new System.Drawing.Point(14, 107);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(68, 20);
            this.lblRemark.TabIndex = 2;
            this.lblRemark.Text = "REMARK";
            // 
            // txtRcvdAmt
            // 
            this.txtRcvdAmt.Location = new System.Drawing.Point(102, 77);
            this.txtRcvdAmt.Name = "txtRcvdAmt";
            this.txtRcvdAmt.Size = new System.Drawing.Size(93, 21);
            this.txtRcvdAmt.TabIndex = 4;
            this.txtRcvdAmt.TextChanged += new System.EventHandler(this.txtRcvdAmt_TextChanged);
            // 
            // txtSales
            // 
            this.txtSales.BackColor = System.Drawing.SystemColors.Info;
            this.txtSales.Location = new System.Drawing.Point(295, 20);
            this.txtSales.Name = "txtSales";
            this.txtSales.ReadOnly = true;
            this.txtSales.Size = new System.Drawing.Size(95, 21);
            this.txtSales.TabIndex = 2;
            // 
            // txtInvAmt
            // 
            this.txtInvAmt.BackColor = System.Drawing.SystemColors.Info;
            this.txtInvAmt.Location = new System.Drawing.Point(102, 50);
            this.txtInvAmt.Name = "txtInvAmt";
            this.txtInvAmt.ReadOnly = true;
            this.txtInvAmt.Size = new System.Drawing.Size(93, 21);
            this.txtInvAmt.TabIndex = 3;
            // 
            // txtPoNo
            // 
            this.txtPoNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtPoNo.Location = new System.Drawing.Point(102, 20);
            this.txtPoNo.Name = "txtPoNo";
            this.txtPoNo.ReadOnly = true;
            this.txtPoNo.Size = new System.Drawing.Size(118, 21);
            this.txtPoNo.TabIndex = 1;
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSales.Location = new System.Drawing.Point(239, 22);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(50, 20);
            this.lblSales.TabIndex = 0;
            this.lblSales.Text = "SALES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(201, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(224, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "PAY OFF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(201, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "$";
            // 
            // lblRcvdAmt
            // 
            this.lblRcvdAmt.AutoSize = true;
            this.lblRcvdAmt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRcvdAmt.Location = new System.Drawing.Point(15, 78);
            this.lblRcvdAmt.Name = "lblRcvdAmt";
            this.lblRcvdAmt.Size = new System.Drawing.Size(83, 20);
            this.lblRcvdAmt.TabIndex = 0;
            this.lblRcvdAmt.Text = "RCVD AMT";
            // 
            // lblInvAmt
            // 
            this.lblInvAmt.AutoSize = true;
            this.lblInvAmt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInvAmt.Location = new System.Drawing.Point(15, 51);
            this.lblInvAmt.Name = "lblInvAmt";
            this.lblInvAmt.Size = new System.Drawing.Size(65, 20);
            this.lblInvAmt.TabIndex = 0;
            this.lblInvAmt.Text = "INVAMT";
            // 
            // lblPO
            // 
            this.lblPO.AutoSize = true;
            this.lblPO.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPO.Location = new System.Drawing.Point(15, 22);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(45, 20);
            this.lblPO.TabIndex = 0;
            this.lblPO.Text = "P.O# ";
            // 
            // FrmRcvdEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 207);
            this.Controls.Add(this.gbBackground);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRcvdEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "领款";
            this.Load += new System.EventHandler(this.FrmRcvdEdit_Load);
            this.gbBackground.ResumeLayout(false);
            this.gbBackground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbBackground;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.TextBox txtInvAmt;
        private System.Windows.Forms.TextBox txtPoNo;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.Label lblRcvdAmt;
        private System.Windows.Forms.Label lblInvAmt;
        private System.Windows.Forms.Label lblPO;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtRcvdAmt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPayOff;
        private System.Windows.Forms.Label label3;
    }
}