namespace PengLang
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.pbtnLogout = new System.Windows.Forms.PictureBox();
            this.pbtnLogin = new System.Windows.Forms.PictureBox();
            this.UserCode = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // pbtnLogout
            // 
            this.pbtnLogout.BackColor = System.Drawing.Color.Transparent;
            this.pbtnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnLogout.Image = ((System.Drawing.Image)(resources.GetObject("pbtnLogout.Image")));
            this.pbtnLogout.Location = new System.Drawing.Point(288, 224);
            this.pbtnLogout.Name = "pbtnLogout";
            this.pbtnLogout.Size = new System.Drawing.Size(70, 28);
            this.pbtnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnLogout.TabIndex = 2;
            this.pbtnLogout.TabStop = false;
            this.pbtnLogout.Click += new System.EventHandler(this.pbtnLogout_Click);
            // 
            // pbtnLogin
            // 
            this.pbtnLogin.BackColor = System.Drawing.Color.Transparent;
            this.pbtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnLogin.Image = ((System.Drawing.Image)(resources.GetObject("pbtnLogin.Image")));
            this.pbtnLogin.Location = new System.Drawing.Point(201, 224);
            this.pbtnLogin.Name = "pbtnLogin";
            this.pbtnLogin.Size = new System.Drawing.Size(70, 28);
            this.pbtnLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnLogin.TabIndex = 1;
            this.pbtnLogin.TabStop = false;
            this.pbtnLogin.Click += new System.EventHandler(this.pbtnLogin_Click);
            // 
            // UserCode
            // 
            this.UserCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserCode.Location = new System.Drawing.Point(238, 133);
            this.UserCode.MaxLength = 64;
            this.UserCode.Name = "UserCode";
            this.UserCode.Size = new System.Drawing.Size(114, 16);
            this.UserCode.TabIndex = 0;
            this.UserCode.Text = "admin";
            this.UserCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Password_KeyPress);
            // 
            // Password
            // 
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Password.Location = new System.Drawing.Point(238, 178);
            this.Password.MaxLength = 64;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(114, 16);
            this.Password.TabIndex = 1;
            this.Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Password_KeyPress);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(547, 409);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserCode);
            this.Controls.Add(this.pbtnLogout);
            this.Controls.Add(this.pbtnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(547, 409);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(547, 409);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "鹏澜服装库存管理系统";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbtnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbtnLogout;
        private System.Windows.Forms.PictureBox pbtnLogin;
        private System.Windows.Forms.TextBox UserCode;
        private System.Windows.Forms.TextBox Password;
    }
}