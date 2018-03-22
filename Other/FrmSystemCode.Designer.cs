using System.Configuration;
namespace PengLang
{
    partial class FrmSystemCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystemCode));
            this.groupShelfCapacity = new DevExpress.XtraEditors.GroupControl();
            this.btnSaveShefCapacity = new System.Windows.Forms.Button();
            this.numShelfCapacity = new System.Windows.Forms.NumericUpDown();
            this.labShelfCapacity = new System.Windows.Forms.Label();
            this.groupClothesWarn = new DevExpress.XtraEditors.GroupControl();
            this.btnSaveWarnCount = new System.Windows.Forms.Button();
            this.labWarnCntUp = new System.Windows.Forms.Label();
            this.labWarnCntLow = new System.Windows.Forms.Label();
            this.numWarnCntUp = new System.Windows.Forms.NumericUpDown();
            this.numWarnCntLow = new System.Windows.Forms.NumericUpDown();
            this.groupCompany = new DevExpress.XtraEditors.GroupControl();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.FaxBox = new System.Windows.Forms.TextBox();
            this.TellBox = new System.Windows.Forms.TextBox();
            this.Emaillabel = new System.Windows.Forms.Label();
            this.FaxLabel = new System.Windows.Forms.Label();
            this.TellLabel = new System.Windows.Forms.Label();
            this.AdressBox = new System.Windows.Forms.TextBox();
            this.bntComp = new System.Windows.Forms.Button();
            this.AdressLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupShelfCapacity)).BeginInit();
            this.groupShelfCapacity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShelfCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupClothesWarn)).BeginInit();
            this.groupClothesWarn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWarnCntUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWarnCntLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCompany)).BeginInit();
            this.groupCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupShelfCapacity
            // 
            this.groupShelfCapacity.Controls.Add(this.btnSaveShefCapacity);
            this.groupShelfCapacity.Controls.Add(this.numShelfCapacity);
            this.groupShelfCapacity.Controls.Add(this.labShelfCapacity);
            this.groupShelfCapacity.Location = new System.Drawing.Point(107, 29);
            this.groupShelfCapacity.Name = "groupShelfCapacity";
            this.groupShelfCapacity.Size = new System.Drawing.Size(445, 91);
            this.groupShelfCapacity.TabIndex = 0;
            this.groupShelfCapacity.Text = "货架容量配置";
            // 
            // btnSaveShefCapacity
            // 
            this.btnSaveShefCapacity.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveShefCapacity.Image")));
            this.btnSaveShefCapacity.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveShefCapacity.Location = new System.Drawing.Point(182, 36);
            this.btnSaveShefCapacity.Name = "btnSaveShefCapacity";
            this.btnSaveShefCapacity.Size = new System.Drawing.Size(77, 29);
            this.btnSaveShefCapacity.TabIndex = 2;
            this.btnSaveShefCapacity.Text = "确定";
            this.btnSaveShefCapacity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveShefCapacity.UseVisualStyleBackColor = true;
            this.btnSaveShefCapacity.Click += new System.EventHandler(this.btnSaveShefCapacity_Click);
            // 
            // numShelfCapacity
            // 
            this.numShelfCapacity.Location = new System.Drawing.Point(84, 42);
            this.numShelfCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numShelfCapacity.Name = "numShelfCapacity";
            this.numShelfCapacity.Size = new System.Drawing.Size(82, 21);
            this.numShelfCapacity.TabIndex = 1;
            this.numShelfCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labShelfCapacity
            // 
            this.labShelfCapacity.AutoSize = true;
            this.labShelfCapacity.Location = new System.Drawing.Point(19, 46);
            this.labShelfCapacity.Name = "labShelfCapacity";
            this.labShelfCapacity.Size = new System.Drawing.Size(59, 12);
            this.labShelfCapacity.TabIndex = 0;
            this.labShelfCapacity.Text = "货架容量:";
            // 
            // groupClothesWarn
            // 
            this.groupClothesWarn.Controls.Add(this.btnSaveWarnCount);
            this.groupClothesWarn.Controls.Add(this.labWarnCntUp);
            this.groupClothesWarn.Controls.Add(this.labWarnCntLow);
            this.groupClothesWarn.Controls.Add(this.numWarnCntUp);
            this.groupClothesWarn.Controls.Add(this.numWarnCntLow);
            this.groupClothesWarn.Location = new System.Drawing.Point(107, 126);
            this.groupClothesWarn.Name = "groupClothesWarn";
            this.groupClothesWarn.Size = new System.Drawing.Size(445, 87);
            this.groupClothesWarn.TabIndex = 0;
            this.groupClothesWarn.Text = "服装库存告警配置";
            // 
            // btnSaveWarnCount
            // 
            this.btnSaveWarnCount.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveWarnCount.Image")));
            this.btnSaveWarnCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveWarnCount.Location = new System.Drawing.Point(284, 40);
            this.btnSaveWarnCount.Name = "btnSaveWarnCount";
            this.btnSaveWarnCount.Size = new System.Drawing.Size(77, 29);
            this.btnSaveWarnCount.TabIndex = 2;
            this.btnSaveWarnCount.Text = "确定";
            this.btnSaveWarnCount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveWarnCount.UseVisualStyleBackColor = true;
            this.btnSaveWarnCount.Click += new System.EventHandler(this.btnSaveWarnCount_Click);
            // 
            // labWarnCntUp
            // 
            this.labWarnCntUp.AutoSize = true;
            this.labWarnCntUp.Location = new System.Drawing.Point(164, 48);
            this.labWarnCntUp.Name = "labWarnCntUp";
            this.labWarnCntUp.Size = new System.Drawing.Size(35, 12);
            this.labWarnCntUp.TabIndex = 0;
            this.labWarnCntUp.Text = "上限:";
            // 
            // labWarnCntLow
            // 
            this.labWarnCntLow.AutoSize = true;
            this.labWarnCntLow.Location = new System.Drawing.Point(43, 48);
            this.labWarnCntLow.Name = "labWarnCntLow";
            this.labWarnCntLow.Size = new System.Drawing.Size(35, 12);
            this.labWarnCntLow.TabIndex = 0;
            this.labWarnCntLow.Text = "下限:";
            // 
            // numWarnCntUp
            // 
            this.numWarnCntUp.Location = new System.Drawing.Point(203, 44);
            this.numWarnCntUp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWarnCntUp.Name = "numWarnCntUp";
            this.numWarnCntUp.Size = new System.Drawing.Size(59, 21);
            this.numWarnCntUp.TabIndex = 1;
            this.numWarnCntUp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numWarnCntLow
            // 
            this.numWarnCntLow.Location = new System.Drawing.Point(84, 44);
            this.numWarnCntLow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWarnCntLow.Name = "numWarnCntLow";
            this.numWarnCntLow.Size = new System.Drawing.Size(59, 21);
            this.numWarnCntLow.TabIndex = 1;
            this.numWarnCntLow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupCompany
            // 
            this.groupCompany.Controls.Add(this.EmailBox);
            this.groupCompany.Controls.Add(this.FaxBox);
            this.groupCompany.Controls.Add(this.TellBox);
            this.groupCompany.Controls.Add(this.Emaillabel);
            this.groupCompany.Controls.Add(this.FaxLabel);
            this.groupCompany.Controls.Add(this.TellLabel);
            this.groupCompany.Controls.Add(this.AdressBox);
            this.groupCompany.Controls.Add(this.bntComp);
            this.groupCompany.Controls.Add(this.AdressLable);
            this.groupCompany.Location = new System.Drawing.Point(107, 220);
            this.groupCompany.Name = "groupCompany";
            this.groupCompany.Size = new System.Drawing.Size(445, 182);
            this.groupCompany.TabIndex = 1;
            this.groupCompany.Text = "公司信息配置";
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(84, 146);
            this.EmailBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(254, 21);
            this.EmailBox.TabIndex = 9;
            // 
            // FaxBox
            // 
            this.FaxBox.Location = new System.Drawing.Point(84, 114);
            this.FaxBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FaxBox.Name = "FaxBox";
            this.FaxBox.Size = new System.Drawing.Size(254, 21);
            this.FaxBox.TabIndex = 8;
            // 
            // TellBox
            // 
            this.TellBox.Location = new System.Drawing.Point(84, 81);
            this.TellBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TellBox.Name = "TellBox";
            this.TellBox.Size = new System.Drawing.Size(254, 21);
            this.TellBox.TabIndex = 7;
            // 
            // Emaillabel
            // 
            this.Emaillabel.AutoSize = true;
            this.Emaillabel.Location = new System.Drawing.Point(26, 149);
            this.Emaillabel.Name = "Emaillabel";
            this.Emaillabel.Size = new System.Drawing.Size(53, 12);
            this.Emaillabel.TabIndex = 6;
            this.Emaillabel.Text = "电子邮箱";
            // 
            // FaxLabel
            // 
            this.FaxLabel.AutoSize = true;
            this.FaxLabel.Location = new System.Drawing.Point(38, 116);
            this.FaxLabel.Name = "FaxLabel";
            this.FaxLabel.Size = new System.Drawing.Size(29, 12);
            this.FaxLabel.TabIndex = 5;
            this.FaxLabel.Text = "传真";
            // 
            // TellLabel
            // 
            this.TellLabel.AutoSize = true;
            this.TellLabel.Location = new System.Drawing.Point(38, 83);
            this.TellLabel.Name = "TellLabel";
            this.TellLabel.Size = new System.Drawing.Size(29, 12);
            this.TellLabel.TabIndex = 4;
            this.TellLabel.Text = "电话";
            // 
            // AdressBox
            // 
            this.AdressBox.Location = new System.Drawing.Point(84, 46);
            this.AdressBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AdressBox.Name = "AdressBox";
            this.AdressBox.Size = new System.Drawing.Size(254, 21);
            this.AdressBox.TabIndex = 3;
            // 
            // bntComp
            // 
            this.bntComp.Image = ((System.Drawing.Image)(resources.GetObject("bntComp.Image")));
            this.bntComp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntComp.Location = new System.Drawing.Point(354, 138);
            this.bntComp.Name = "bntComp";
            this.bntComp.Size = new System.Drawing.Size(77, 29);
            this.bntComp.TabIndex = 2;
            this.bntComp.Text = "确定";
            this.bntComp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bntComp.UseVisualStyleBackColor = true;
            this.bntComp.Click += new System.EventHandler(this.AdressButton_Click);
            // 
            // AdressLable
            // 
            this.AdressLable.AutoSize = true;
            this.AdressLable.Location = new System.Drawing.Point(38, 48);
            this.AdressLable.Name = "AdressLable";
            this.AdressLable.Size = new System.Drawing.Size(29, 12);
            this.AdressLable.TabIndex = 0;
            this.AdressLable.Text = "地址";
            // 
            // FrmSystemCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 490);
            this.Controls.Add(this.groupCompany);
            this.Controls.Add(this.groupClothesWarn);
            this.Controls.Add(this.groupShelfCapacity);
            this.Name = "FrmSystemCode";
            this.Text = "FrmSystemCode";
            this.Load += new System.EventHandler(this.FrmSystemCode_Load);
            this.Resize += new System.EventHandler(this.FrmSystemCode_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.groupShelfCapacity)).EndInit();
            this.groupShelfCapacity.ResumeLayout(false);
            this.groupShelfCapacity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShelfCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupClothesWarn)).EndInit();
            this.groupClothesWarn.ResumeLayout(false);
            this.groupClothesWarn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWarnCntUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWarnCntLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCompany)).EndInit();
            this.groupCompany.ResumeLayout(false);
            this.groupCompany.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupShelfCapacity;
        private System.Windows.Forms.Button btnSaveShefCapacity;
        private System.Windows.Forms.NumericUpDown numShelfCapacity;
        private System.Windows.Forms.Label labShelfCapacity;
        private DevExpress.XtraEditors.GroupControl groupClothesWarn;
        private System.Windows.Forms.Button btnSaveWarnCount;
        private System.Windows.Forms.Label labWarnCntUp;
        private System.Windows.Forms.Label labWarnCntLow;
        private System.Windows.Forms.NumericUpDown numWarnCntUp;
        private System.Windows.Forms.NumericUpDown numWarnCntLow;
        private DevExpress.XtraEditors.GroupControl groupCompany;
        private System.Windows.Forms.TextBox AdressBox;
        private System.Windows.Forms.Button bntComp;
        private System.Windows.Forms.Label AdressLable;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.TextBox FaxBox;
        private System.Windows.Forms.TextBox TellBox;
        private System.Windows.Forms.Label Emaillabel;
        private System.Windows.Forms.Label FaxLabel;
        private System.Windows.Forms.Label TellLabel;
    }
}