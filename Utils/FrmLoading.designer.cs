namespace PengLang
{
    partial class FrmLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoading));
            this.btnCancle = new System.Windows.Forms.Button();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.panBg = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.panBg.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.Transparent;
            this.btnCancle.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.Image = ((System.Drawing.Image)(resources.GetObject("btnCancle.Image")));
            this.btnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancle.Location = new System.Drawing.Point(252, 11);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(53, 28);
            this.btnCancle.TabIndex = 0;
            this.btnCancle.Text = "关闭";
            this.btnCancle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // pbox
            // 
            this.pbox.Image = ((System.Drawing.Image)(resources.GetObject("pbox.Image")));
            this.pbox.Location = new System.Drawing.Point(7, 8);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(33, 33);
            this.pbox.TabIndex = 1;
            this.pbox.TabStop = false;
            // 
            // lblTip
            // 
            this.lblTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTip.Location = new System.Drawing.Point(45, 8);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(151, 32);
            this.lblTip.TabIndex = 2;
            this.lblTip.Text = "正在加载数据，请稍等...";
            this.lblTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBg
            // 
            this.panBg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panBg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBg.Controls.Add(this.lblTip);
            this.panBg.Controls.Add(this.btnCancle);
            this.panBg.Controls.Add(this.pbox);
            this.panBg.Dock = System.Windows.Forms.DockStyle.Top;
            this.panBg.Location = new System.Drawing.Point(0, 0);
            this.panBg.Name = "panBg";
            this.panBg.Size = new System.Drawing.Size(318, 48);
            this.panBg.TabIndex = 3;
            // 
            // FrmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 48);
            this.Controls.Add(this.panBg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.White;
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.panBg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Panel panBg;
    }
}