using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Sau.Util;

namespace PengLang 
{
    public partial class FrmSystemCode :   Form, InnerForm
    {
        public void Save() { }
        public bool IsEdit() { return false; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        public FrmSystemCode()
        {
            InitializeComponent();
        }

        private void FrmSystemCode_Load(object sender, EventArgs e)
        {
           numShelfCapacity.Value =  MemoryTable.Instance.ShelfCapacity;
           numWarnCntLow.Value = MemoryTable.Instance.ClothesWarnCntLow;
           numWarnCntUp.Value = MemoryTable.Instance.ClothesWarnCntUp;
           GetCompanyInfo(AppConfig.CompanyInfo);
        }

        private void btnSaveShefCapacity_Click(object sender, EventArgs e)
        {
            MemoryTable.Instance.UpdateShelfCapacity( Convert.ToInt32( numShelfCapacity.Value) );
            MessageBox.Show("货架容量配置成功！");
        }

        private void btnSaveWarnCount_Click(object sender, EventArgs e)
        {
            MemoryTable.Instance.UpdateClothesWarnCount(
                Convert.ToInt32( numWarnCntLow.Value),
                Convert.ToInt32( numWarnCntUp.Value));
            MessageBox.Show("容量限制成功！");
        }

        private void FrmSystemCode_Resize(object sender, EventArgs e)
        {
            int height = groupClothesWarn.Height + groupShelfCapacity.Height + groupCompany.Height+ 20;

            groupShelfCapacity.Top = this.Height / 2 - height / 2;
            groupShelfCapacity.Left = this.Width/2  - groupShelfCapacity.Width / 3;

            groupClothesWarn.Top =  groupShelfCapacity.Bottom +10;
            groupClothesWarn.Left =  groupShelfCapacity.Left;

            groupCompany.Top = groupClothesWarn.Bottom + 10;
            groupCompany.Left = groupShelfCapacity.Left;
        }

        private void AdressButton_Click(object sender, EventArgs e)
        {
            Company comp = AppConfig.CompanyInfo;
            comp.Address = this.AdressBox.Text.Trim();
            comp.Tell = this.TellBox.Text.Trim();
            comp.Fax = this.FaxBox.Text.Trim();
            comp.Email = this.EmailBox.Text.Trim();

            if (false == CompanyAdo.UpdateCompanyInfo(comp))  
            {
                MsgBox.Error("修改公司信息失败！");
            }
            MessageBox.Show("公司信息修改成功！");
        }

        private void GetCompanyInfo(Company company)
        {
            this.AdressBox.Text = company.Address;
            this.TellBox.Text = company.Tell;
            this.FaxBox.Text = company.Fax;
            this.EmailBox.Text = company.Email; 
        }
    }
}
