namespace PengLang
{
    partial class FrmEditInbound
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditInbound));
            this.groupInbound = new DevExpress.XtraEditors.GroupControl();
            this.dateOrder = new DevExpress.XtraEditors.DateEdit();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.txtProductNo = new System.Windows.Forms.TextBox();
            this.labFahuodan = new DevExpress.XtraEditors.LabelControl();
            this.txtInboundNo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupInbound)).BeginInit();
            this.groupInbound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrder.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrder.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupInbound
            // 
            this.groupInbound.Controls.Add(this.dateOrder);
            this.groupInbound.Controls.Add(this.lblDate);
            this.groupInbound.Controls.Add(this.txtProductNo);
            this.groupInbound.Controls.Add(this.labFahuodan);
            this.groupInbound.Location = new System.Drawing.Point(12, 12);
            this.groupInbound.Name = "groupInbound";
            this.groupInbound.Size = new System.Drawing.Size(402, 76);
            this.groupInbound.TabIndex = 8;
            // 
            // dateOrder
            // 
            this.dateOrder.EditValue = null;
            this.dateOrder.Location = new System.Drawing.Point(259, 34);
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
            this.lblDate.Location = new System.Drawing.Point(214, 38);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 14);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "DATE：";
            // 
            // txtProductNo
            // 
            this.txtProductNo.Location = new System.Drawing.Point(76, 34);
            this.txtProductNo.Name = "txtProductNo";
            this.txtProductNo.Size = new System.Drawing.Size(123, 21);
            this.txtProductNo.TabIndex = 1;
            // 
            // labFahuodan
            // 
            this.labFahuodan.Location = new System.Drawing.Point(18, 37);
            this.labFahuodan.Name = "labFahuodan";
            this.labFahuodan.Size = new System.Drawing.Size(52, 14);
            this.labFahuodan.TabIndex = 3;
            this.labFahuodan.Text = "Order#：";
            // 
            // txtInboundNo
            // 
            this.txtInboundNo.Location = new System.Drawing.Point(12, 98);
            this.txtInboundNo.Name = "txtInboundNo";
            this.txtInboundNo.ReadOnly = true;
            this.txtInboundNo.Size = new System.Drawing.Size(53, 21);
            this.txtInboundNo.TabIndex = 0;
            this.txtInboundNo.TabStop = false;
            this.txtInboundNo.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(337, 98);
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
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(249, 98);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 32);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmEditInbound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 138);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtInboundNo);
            this.Controls.Add(this.groupInbound);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditInbound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请填写入库单信息";
            this.Load += new System.EventHandler(this.FrmEditInbound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupInbound)).EndInit();
            this.groupInbound.ResumeLayout(false);
            this.groupInbound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrder.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrder.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupInbound;
        private DevExpress.XtraEditors.DateEdit dateOrder;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private System.Windows.Forms.TextBox txtInboundNo;
        private System.Windows.Forms.TextBox txtProductNo;
        private DevExpress.XtraEditors.LabelControl labFahuodan;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}