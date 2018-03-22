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
    public partial class FrmReplace : Form
    {
        #region 操作模式
        public static int Mode_Search = 1;
        public static int Mode_Replace = 2;
        public static int Mode_None = 0;

        private bool bReplace = false;
        private bool bSearch = false;
        private int nMode = Mode_None;
        
        #endregion

        #region 属性

        /// <summary>
        /// 确定是否替换
        /// </summary>
        public bool CanReplace {

            get { return bReplace; }
            set { bReplace = true; }
        }
        /// <summary>
        /// 确定是否查找
        /// </summary>
        public bool CanSearch
        {
            get { return bSearch; }
            set { bSearch = value; }
        }
        /// <summary>
        /// 操作：查找 or 替换
        /// </summary>
        public int Operation
        {
            get { return nMode; }
            set { nMode = value; }
        }
        //查找内容
        public String SearchText {

            get { 
                if(nMode == Mode_Replace)
                  return txtSearch.Text.Trim();
                return txtKeyWordsSearch.Text.Trim();
            }
            set {
                if (nMode == Mode_Replace)
                    txtSearch.Text = value;
                txtKeyWordsSearch.Text = value;
            }
        }

        //替换内容
        public String ReplaceText {

            get { return txtReplace.Text.Trim(); }
            set { txtReplace.Text = value; }
        }

        //分离字符串
        private String splitString = " ";
        public String SplitString
        {
            get { return splitString; }
            set { splitString = value; }
        }
        #endregion

        #region 窗体初始化

        public FrmReplace()
        {
            InitializeComponent();
        }

        private void FrmReplace_Load(object sender, EventArgs e)
        {
            //试飞数据管理系统不需要替换
            tabCtrl.TabPages.Remove(tpReplace);

            if (nMode == Mode_Replace)
            {
                tabCtrl.SelectedTab = tpReplace;
                txtSearch.Focus();
            }
            else
            {
                tabCtrl.SelectedTab = tpSearch;
                txtKeyWordsSearch.Focus();
            }
        }

        #endregion

        #region 替换
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.bReplace = true;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.bReplace = false;
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region 查找

        private void btnSearch_Click(object sender, EventArgs e)
        {
        
            this.bSearch = true;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
                 
            this.bSearch = false;
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        private void txtKeyWordsSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSearch_Click(btnSearch, e);
        }

    }
}
