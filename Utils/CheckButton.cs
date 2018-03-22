using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sau.Util
{
    [DesignTimeVisible(true),
    ToolboxItem(true),
    ToolboxBitmap(typeof(CheckButton), "CheckButton.bmp")]
    public partial class CheckButton : UserControl
    {
        private bool bChecked = false;
        public CheckButton()
        {
            InitializeComponent();

            imgUnCheck.Left = 0;
            imgUnCheck.Top = 0;
            imgChecked.Location = imgUnCheck.Location;

            imgChecked.Visible = false;
            imgUnCheck.Visible = true;
            bChecked = false;
            imgChecked.SizeMode = PictureBoxSizeMode.StretchImage;
            imgUnCheck.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void CheckButton_Load(object sender, EventArgs e)
        {
            this.Refresh();
        }
        
        //选中状态
        public bool Checked 
        {
            get { return bChecked; }
            set {
                bChecked = value;
                imgChecked.Visible = value;
                imgUnCheck.Visible = !value;
            }
        }
      
        //使能设置
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;

                imgChecked.Enabled = value;
                imgUnCheck.Enabled = value;
                Checked = false;
            }
        }

        //图片的显示模式
        public PictureBoxSizeMode ImageSizeMode
        {
            get { return imgChecked.SizeMode; }
            set {
                imgChecked.SizeMode = value;
                imgUnCheck.SizeMode = value;
            }
        }

        #region 隐藏的属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set
            {
                base.BackgroundImage = value;

            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }


        #endregion

        #region 点击事件

        private void imgUnCheck_Click(object sender, EventArgs e)
        {
            ButtonClick();

            this.OnClick(e);
        }

        private void imgChecked_Click(object sender, EventArgs e)
        {
            ButtonClick();

            this.OnClick(e);
        }

        private void ButtonClick()
        {
            if (bChecked == true)
            {
                imgUnCheck.Visible = true;
                imgChecked.Visible = false;
                bChecked = false;
            }
            else
            {
                imgUnCheck.Visible = false;
                imgChecked.Visible = true;
                bChecked = true;
            }

            //委托代理
            if (CheckChanged != null)
                CheckChanged(this, new CheckChangedEventArgs(Checked));

        }

        #endregion

        #region 自定义事件

        //状态改变事件
        public delegate void CheckChangedEventHandler(object sender, CheckChangedEventArgs e);
         
        public event CheckChangedEventHandler CheckChanged;
         

        #endregion 

        #region 改变大小

        protected override void OnResize(EventArgs e)
        {
            imgUnCheck.Width = this.Width -2;
            imgChecked.Width = this.Width-2;
            imgChecked.Height = this.Height-2;
            imgUnCheck.Height = this.Height-2;
            this.Refresh();
        }

        #endregion


    }

    /// <summary>
    /// 改变选中状态事件
    /// </summary>
    public class CheckChangedEventArgs : EventArgs
    {

        private bool state;
         
        public CheckChangedEventArgs(bool cur)
        { 
            this.state = cur;
        }

        public bool Checked
        {

            get { return this.state; }
        }
    }
}
