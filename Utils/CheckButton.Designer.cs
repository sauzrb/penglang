namespace Sau.Util
{
    partial class CheckButton
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckButton));
            this.imgChecked = new System.Windows.Forms.PictureBox();
            this.imgUnCheck = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgUnCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // imgChecked
            // 
            this.imgChecked.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgChecked.Image = ((System.Drawing.Image)(resources.GetObject("imgChecked.Image")));
            this.imgChecked.Location = new System.Drawing.Point(0, 0);
            this.imgChecked.Name = "imgChecked";
            this.imgChecked.Size = new System.Drawing.Size(32, 32);
            this.imgChecked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgChecked.TabIndex = 0;
            this.imgChecked.TabStop = false;
            this.imgChecked.Click += new System.EventHandler(this.imgChecked_Click);
            // 
            // imgUnCheck
            // 
            this.imgUnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgUnCheck.Image = ((System.Drawing.Image)(resources.GetObject("imgUnCheck.Image")));
            this.imgUnCheck.Location = new System.Drawing.Point(0, 0);
            this.imgUnCheck.Name = "imgUnCheck";
            this.imgUnCheck.Size = new System.Drawing.Size(32, 32);
            this.imgUnCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgUnCheck.TabIndex = 0;
            this.imgUnCheck.TabStop = false;
            this.imgUnCheck.Click += new System.EventHandler(this.imgUnCheck_Click);
            // 
            // CheckButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgUnCheck);
            this.Controls.Add(this.imgChecked);
            this.Name = "CheckButton";
            this.Size = new System.Drawing.Size(32, 32);
            this.Load += new System.EventHandler(this.CheckButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgUnCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgChecked;
        private System.Windows.Forms.PictureBox imgUnCheck;
    }
}
