namespace Sau.Util
{
    partial class FrmReplace
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
            this.lblResearch = new System.Windows.Forms.Label();
            this.lblReplace = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tpSearch = new System.Windows.Forms.TabPage();
            this.lblOperationTip = new System.Windows.Forms.Label();
            this.lblOperation = new System.Windows.Forms.Label();
            this.txtKeyWordsSearch = new System.Windows.Forms.TextBox();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tpReplace = new System.Windows.Forms.TabPage();
            this.tabCtrl.SuspendLayout();
            this.tpSearch.SuspendLayout();
            this.tpReplace.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblResearch
            // 
            this.lblResearch.AutoSize = true;
            this.lblResearch.Location = new System.Drawing.Point(14, 19);
            this.lblResearch.Name = "lblResearch";
            this.lblResearch.Size = new System.Drawing.Size(65, 12);
            this.lblResearch.TabIndex = 0;
            this.lblResearch.Text = "查找内容：";
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(16, 49);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(53, 12);
            this.lblReplace.TabIndex = 1;
            this.lblReplace.Text = "替换为：";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(85, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(238, 21);
            this.txtSearch.TabIndex = 1;
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(85, 41);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(238, 21);
            this.txtReplace.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(187, 76);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "替换";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(267, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tpSearch);
            this.tabCtrl.Controls.Add(this.tpReplace);
            this.tabCtrl.Location = new System.Drawing.Point(6, 6);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(354, 135);
            this.tabCtrl.TabIndex = 4;
            // 
            // tpSearch
            // 
            this.tpSearch.BackColor = System.Drawing.SystemColors.Control;
            this.tpSearch.Controls.Add(this.lblOperationTip);
            this.tpSearch.Controls.Add(this.lblOperation);
            this.tpSearch.Controls.Add(this.txtKeyWordsSearch);
            this.tpSearch.Controls.Add(this.btnCancel2);
            this.tpSearch.Controls.Add(this.label1);
            this.tpSearch.Controls.Add(this.btnSearch);
            this.tpSearch.Location = new System.Drawing.Point(4, 22);
            this.tpSearch.Name = "tpSearch";
            this.tpSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpSearch.Size = new System.Drawing.Size(346, 109);
            this.tpSearch.TabIndex = 0;
            this.tpSearch.Text = "查找";
            // 
            // lblOperationTip
            // 
            this.lblOperationTip.Location = new System.Drawing.Point(88, 44);
            this.lblOperationTip.Name = "lblOperationTip";
            this.lblOperationTip.Size = new System.Drawing.Size(238, 23);
            this.lblOperationTip.TabIndex = 9;
            this.lblOperationTip.Text = "多关键词查询请用空格隔开";
            this.lblOperationTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.Location = new System.Drawing.Point(19, 49);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(41, 12);
            this.lblOperation.TabIndex = 8;
            this.lblOperation.Text = "选项：";
            // 
            // txtKeyWordsSearch
            // 
            this.txtKeyWordsSearch.Location = new System.Drawing.Point(88, 15);
            this.txtKeyWordsSearch.Name = "txtKeyWordsSearch";
            this.txtKeyWordsSearch.Size = new System.Drawing.Size(238, 21);
            this.txtKeyWordsSearch.TabIndex = 1;
            this.txtKeyWordsSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyWordsSearch_KeyPress);
            // 
            // btnCancel2
            // 
            this.btnCancel2.Location = new System.Drawing.Point(272, 74);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(56, 23);
            this.btnCancel2.TabIndex = 3;
            this.btnCancel2.Text = "取消";
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "查找内容：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(192, 74);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tpReplace
            // 
            this.tpReplace.BackColor = System.Drawing.SystemColors.Control;
            this.tpReplace.Controls.Add(this.txtSearch);
            this.tpReplace.Controls.Add(this.btnCancel);
            this.tpReplace.Controls.Add(this.lblResearch);
            this.tpReplace.Controls.Add(this.btnOK);
            this.tpReplace.Controls.Add(this.lblReplace);
            this.tpReplace.Controls.Add(this.txtReplace);
            this.tpReplace.Location = new System.Drawing.Point(4, 22);
            this.tpReplace.Name = "tpReplace";
            this.tpReplace.Padding = new System.Windows.Forms.Padding(3);
            this.tpReplace.Size = new System.Drawing.Size(346, 109);
            this.tpReplace.TabIndex = 1;
            this.tpReplace.Text = "替换";
            // 
            // FrmReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 148);
            this.Controls.Add(this.tabCtrl);
            this.MaximizeBox = false;
            this.Name = "FrmReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "鹏斓服装库存管理软件";
            this.Load += new System.EventHandler(this.FrmReplace_Load);
            this.tabCtrl.ResumeLayout(false);
            this.tpSearch.ResumeLayout(false);
            this.tpSearch.PerformLayout();
            this.tpReplace.ResumeLayout(false);
            this.tpReplace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblResearch;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tpSearch;
        private System.Windows.Forms.TabPage tpReplace;
        private System.Windows.Forms.TextBox txtKeyWordsSearch;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblOperationTip;
        private System.Windows.Forms.Label lblOperation;
    }
}