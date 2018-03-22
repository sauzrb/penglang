using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.Utils;
using Sau.Util;


namespace PengLang
{
    public partial class FrmManage : Form,InnerForm
    {
        private FrmShelf shelfForm;
        private FrmClothes clothesForm;
        private FrmUserMag userForm;
        private FrmSystemCode systemForm;
        private FrmEditInventroy inventoryForm;
        private FrmCustomer customerForm;
        private FrmClothesStyle styleForm;

        private Form []childForms;

        public FrmManage()
        {
            InitializeComponent();

            childForms = new Form[7];
            childForms[0] = userForm;
            childForms[1] = clothesForm;
            childForms[2] = shelfForm;
            childForms[3] = systemForm;
            childForms[4] = inventoryForm;
            childForms[5] = customerForm;
            childForms[6] = styleForm;
            
        }

        public void Save() { }
        public bool IsEdit() { return false; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        private void splitContainer_Panel1_Resize(object sender, EventArgs e)
        {
            if( lblBase.Width < splitContainer.Panel1.Width)
                lblBase.Left = splitContainer.Panel1.Width / 2 - lblBase.Width / 2;
        }
      
        private void FrmManage_Load(object sender, EventArgs e)
        {
            if (AppConfig.LoginUser.UserKind == User.UserKind_Admin )
                navBarItemInventroy.Visible = true;
            else
                navBarItemInventroy.Visible = false;

            xtraTab.ShowTabHeader = DefaultBoolean.False;
            xtraTab.SelectedTabPage = tpClothes;

            if (clothesForm == null)
            {
                clothesForm = LoadChildForm(tpClothes, "PengLang.FrmClothes") as FrmClothes;
                childForms[1] = clothesForm;
            }

        }
        
        //货架管理
        private void navBarItemShelf_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (shelfForm == null)
            {
                shelfForm = LoadChildForm(tpShelf, "PengLang.FrmShelf") as FrmShelf;
                childForms[2] = shelfForm;

                if (AppConfig.LoginUser.IsSunSail() == true )
                    shelfForm.CanEdit = true;

            }
            SwitchChildForm(tpShelf);
        }
        
        //服装管理
        private void navBarItemClothes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        { 
            if (clothesForm == null)
            {
                clothesForm = LoadChildForm(tpClothes, "PengLang.FrmClothes") as FrmClothes; 
                childForms[1] = clothesForm; 
            }
            SwitchChildForm(tpClothes);
        }
       
        //修改密码
        private void navBarItemChangePsw_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        { 
            FrmPasswordEdit dlg = new FrmPasswordEdit();
            dlg.UserID = AppConfig.LoginUser.UserCode;
            dlg.Password = AppConfig.LoginUser.UserPsw;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                MsgBox.Infometion("修改秘密成功！");
            }
        }

        //系统代码管理
        private void navBarItemSystemCode_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (AppConfig.LoginUser.UserKind != User.UserKind_Admin)
            {
                MsgBox.Warn("您无权访问该操作！");
                return;
            }

            if (systemForm == null)
            {
                systemForm = LoadChildForm(tpSystemCode, "PengLang.FrmSystemCode") as FrmSystemCode;
                childForms[3] = systemForm;
            }
             
            SwitchChildForm(tpSystemCode);
        }
        
        //加载子窗体
        private Form LoadChildForm(XtraTabPage tabPage, string frmName)
        { 
            Form childForm;
            tabPage.Controls.Clear();
            Type t = Type.GetType(frmName);
            childForm = (Form)Activator.CreateInstance(t);
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            tabPage.Controls.Add(childForm);

            childForm.Show();

            return childForm;
        }
  
        //切换窗体
        private void SwitchChildForm(XtraTabPage tabPage)
        {
            for (int i = 0; i < xtraTab.TabPages.Count; i++)
            {
                if (tabPage == xtraTab.TabPages[i])
                    xtraTab.TabPages[i].PageVisible = true;
                else 
                    xtraTab.TabPages[i].PageVisible = false;
             }
        }

        //修改库存
        private void navBarItemInventroy_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (AppConfig.LoginUser.UserKind != User.UserKind_Admin)
            {
                MsgBox.Warn("您无权访问该操作！");
                return;
            }

            if (inventoryForm == null)
            {
                inventoryForm = LoadChildForm(tpInventory, "PengLang.FrmEditInventroy") as FrmEditInventroy;
                childForms[4] = inventoryForm;
            }

            SwitchChildForm(tpInventory);

            //if( xtraTab.SelectedTabPage != tpInventory)
            //    inventoryForm.ResetUI();
        }

        //顾客管理 
        private void navBarItemCustomer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (customerForm == null)
            {
                customerForm = LoadChildForm(tpCustomer, "PengLang.FrmCustomer") as FrmCustomer;
                childForms[5] = customerForm;
            }
            SwitchChildForm(tpCustomer);
        }
     
        //服装款式
        private void navBarItemStyle_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
            if (styleForm == null)
            {
                styleForm = LoadChildForm(tpStyle, "PengLang.FrmClothesStyle") as FrmClothesStyle;
                childForms[6] = styleForm;
            }
            SwitchChildForm(tpStyle);
        }

        //用户管理
        private void navBarItemUserManage_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (AppConfig.LoginUser.UserKind != User.UserKind_Admin)
            {
                MsgBox.Warn("您无权访问该操作！");
                return;
            }
            if (userForm == null)
            {
                userForm = LoadChildForm(tpUser, "PengLang.FrmUserMag") as FrmUserMag;
                childForms[0] = userForm;
            }

            SwitchChildForm(tpUser);;
        }
        
    }
}
