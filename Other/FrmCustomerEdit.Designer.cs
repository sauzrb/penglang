namespace PengLang
{
    partial class FrmCustomerEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerEdit));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupOutbound = new DevExpress.XtraEditors.GroupControl();
            this.lblTip = new System.Windows.Forms.Label();
            this.txtCustomerNo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.nudTerm = new System.Windows.Forms.NumericUpDown();
            this.cboShipway = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtShipTo = new System.Windows.Forms.TextBox();
            this.lblCustmer = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblAddress = new DevExpress.XtraEditors.LabelControl();
            this.lblSellTo = new DevExpress.XtraEditors.LabelControl();
            this.labelEmail = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelFax = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblShipTo = new DevExpress.XtraEditors.LabelControl();
            this.labelTel = new DevExpress.XtraEditors.LabelControl();
            this.labSellTo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupOutbound)).BeginInit();
            this.groupOutbound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTerm)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(576, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 32);
            this.btnCancel.TabIndex = 6;
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
            this.btnOK.Location = new System.Drawing.Point(480, 347);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupOutbound
            // 
            this.groupOutbound.Controls.Add(this.lblTip);
            this.groupOutbound.Controls.Add(this.txtCustomerNo);
            this.groupOutbound.Controls.Add(this.btnCheck);
            this.groupOutbound.Controls.Add(this.txtFreight);
            this.groupOutbound.Controls.Add(this.nudTerm);
            this.groupOutbound.Controls.Add(this.cboShipway);
            this.groupOutbound.Controls.Add(this.txtAddress);
            this.groupOutbound.Controls.Add(this.txtEmail);
            this.groupOutbound.Controls.Add(this.txtFax);
            this.groupOutbound.Controls.Add(this.txtSales);
            this.groupOutbound.Controls.Add(this.txtTel);
            this.groupOutbound.Controls.Add(this.txtCompany);
            this.groupOutbound.Controls.Add(this.txtShipTo);
            this.groupOutbound.Controls.Add(this.lblCustmer);
            this.groupOutbound.Controls.Add(this.labelControl4);
            this.groupOutbound.Controls.Add(this.labelControl2);
            this.groupOutbound.Controls.Add(this.labelControl1);
            this.groupOutbound.Controls.Add(this.lblAddress);
            this.groupOutbound.Controls.Add(this.lblSellTo);
            this.groupOutbound.Controls.Add(this.labelEmail);
            this.groupOutbound.Controls.Add(this.labelControl3);
            this.groupOutbound.Controls.Add(this.labelFax);
            this.groupOutbound.Controls.Add(this.labelControl5);
            this.groupOutbound.Controls.Add(this.lblShipTo);
            this.groupOutbound.Controls.Add(this.labelTel);
            this.groupOutbound.Controls.Add(this.labSellTo);
            this.groupOutbound.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupOutbound.Location = new System.Drawing.Point(0, 0);
            this.groupOutbound.Name = "groupOutbound";
            this.groupOutbound.Size = new System.Drawing.Size(665, 338);
            this.groupOutbound.TabIndex = 5;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(444, 47);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(209, 12);
            this.lblTip.TabIndex = 11;
            this.lblTip.Text = "（Customer number must be unique）";
            // 
            // txtCustomerNo
            // 
            this.txtCustomerNo.Location = new System.Drawing.Point(94, 45);
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCustomerNo.Size = new System.Drawing.Size(265, 20);
            this.txtCustomerNo.TabIndex = 1;
            // 
            // btnCheck
            // 
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheck.Location = new System.Drawing.Point(372, 40);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(49, 26);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(442, 297);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(91, 21);
            this.txtFreight.TabIndex = 11;
            this.txtFreight.Visible = false;
            this.txtFreight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFreight_KeyPress);
            // 
            // nudTerm
            // 
            this.nudTerm.Location = new System.Drawing.Point(255, 298);
            this.nudTerm.Name = "nudTerm";
            this.nudTerm.Size = new System.Drawing.Size(66, 21);
            this.nudTerm.TabIndex = 10;
            this.nudTerm.Visible = false;
            // 
            // cboShipway
            // 
            this.cboShipway.FormattingEnabled = true;
            this.cboShipway.Items.AddRange(new object[] {
            "Standing box",
            "Regular box"});
            this.cboShipway.Location = new System.Drawing.Point(94, 298);
            this.cboShipway.Name = "cboShipway";
            this.cboShipway.Size = new System.Drawing.Size(108, 20);
            this.cboShipway.TabIndex = 9;
            this.cboShipway.Text = "Regular box";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(94, 111);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(265, 95);
            this.txtAddress.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(442, 174);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(211, 21);
            this.txtEmail.TabIndex = 7;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(442, 143);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(211, 21);
            this.txtFax.TabIndex = 6;
            // 
            // txtSales
            // 
            this.txtSales.Location = new System.Drawing.Point(442, 78);
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(211, 21);
            this.txtSales.TabIndex = 4;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(442, 111);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(211, 21);
            this.txtTel.TabIndex = 5;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(94, 78);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(265, 21);
            this.txtCompany.TabIndex = 2;
            // 
            // txtShipTo
            // 
            this.txtShipTo.Location = new System.Drawing.Point(94, 216);
            this.txtShipTo.Multiline = true;
            this.txtShipTo.Name = "txtShipTo";
            this.txtShipTo.Size = new System.Drawing.Size(559, 68);
            this.txtShipTo.TabIndex = 8;
            // 
            // lblCustmer
            // 
            this.lblCustmer.Location = new System.Drawing.Point(17, 48);
            this.lblCustmer.Name = "lblCustmer";
            this.lblCustmer.Size = new System.Drawing.Size(73, 14);
            this.lblCustmer.TabIndex = 3;
            this.lblCustmer.Text = "Customer#：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(539, 301);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(25, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "( $ )";
            this.labelControl4.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(331, 301);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "days";
            this.labelControl2.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(212, 301);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Term：";
            this.labelControl1.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(35, 112);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(55, 14);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Address：";
            // 
            // lblSellTo
            // 
            this.lblSellTo.Location = new System.Drawing.Point(45, 80);
            this.lblSellTo.Name = "lblSellTo";
            this.lblSellTo.Size = new System.Drawing.Size(45, 14);
            this.lblSellTo.TabIndex = 3;
            this.lblSellTo.Text = "SellTo：";
            // 
            // labelEmail
            // 
            this.labelEmail.Location = new System.Drawing.Point(397, 177);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(39, 14);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Email：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(378, 301);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Shipping：";
            this.labelControl3.Visible = false;
            // 
            // labelFax
            // 
            this.labelFax.Location = new System.Drawing.Point(405, 147);
            this.labelFax.Name = "labelFax";
            this.labelFax.Size = new System.Drawing.Size(30, 14);
            this.labelFax.TabIndex = 3;
            this.labelFax.Text = "Fax：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(395, 80);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(39, 14);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Sales：";
            // 
            // lblShipTo
            // 
            this.lblShipTo.Location = new System.Drawing.Point(36, 218);
            this.lblShipTo.Name = "lblShipTo";
            this.lblShipTo.Size = new System.Drawing.Size(54, 14);
            this.lblShipTo.TabIndex = 3;
            this.lblShipTo.Text = "Ship To：";
            // 
            // labelTel
            // 
            this.labelTel.Location = new System.Drawing.Point(405, 115);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(29, 14);
            this.labelTel.TabIndex = 3;
            this.labelTel.Text = "Tel：";
            // 
            // labSellTo
            // 
            this.labSellTo.Location = new System.Drawing.Point(6, 298);
            this.labSellTo.Name = "labSellTo";
            this.labSellTo.Size = new System.Drawing.Size(84, 14);
            this.labSellTo.TabIndex = 3;
            this.labSellTo.Text = "Shipping way：";
            // 
            // FrmCustomerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 388);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupOutbound);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCustomerEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer information";
            this.Load += new System.EventHandler(this.FrmCustomerEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupOutbound)).EndInit();
            this.groupOutbound.ResumeLayout(false);
            this.groupOutbound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTerm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraEditors.GroupControl groupOutbound;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.NumericUpDown nudTerm;
        private System.Windows.Forms.ComboBox cboShipway;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtShipTo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblSellTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblShipTo;
        private DevExpress.XtraEditors.LabelControl labSellTo;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtAddress;
        private DevExpress.XtraEditors.LabelControl lblAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtTel;
        private DevExpress.XtraEditors.LabelControl labelEmail;
        private DevExpress.XtraEditors.LabelControl labelFax;
        private DevExpress.XtraEditors.LabelControl labelTel;
        private DevExpress.XtraEditors.ComboBoxEdit txtCustomerNo;
        private DevExpress.XtraEditors.LabelControl lblCustmer;
        private System.Windows.Forms.TextBox txtSales;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}