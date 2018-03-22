using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sau.Util
{
    public partial class FrmTip : Form
    {
        private int showTime = 2; //显示2秒钟后自动关闭窗体。

        static private FrmTip instatnce = new FrmTip(); 

        public String Tip {

            get { return lblTip.Text; }
            set { lblTip.Text = value; }
        }


        public FrmTip()
        {
            InitializeComponent();
        }

        private void FrmTip_Load(object sender, EventArgs e)
        {
            ResizeUI();
        }

        /// <summary>
        /// 重新设计界面布局
        /// </summary>
        private void ResizeUI() { 
        

        
        }

        static public void HideTip() {

            if (instatnce != null)
            {
                instatnce.showTime = 0;
                instatnce.timer.Enabled = false;
                instatnce.Hide();
            }
        }

        static public void ShowTip() {
            
            if (instatnce == null)
                instatnce = new FrmTip();
            instatnce.showTime = 0;
            instatnce.timer.Enabled = true;
            instatnce.Show();

        }

        static public void ShowTip(String tip)
        {
            instatnce.Tip = tip;
            ShowTip();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
            showTime++;
            if (showTime == 2) {

                showTime = 0;
                timer.Enabled = false;
                this.Hide();
            }
        }

        
    }
}
