using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sau.Util;

namespace PengLang
{
    public class MemoryTable
    {
        #region 常量
        
        public const string Shelf_88T88 = "88T88";
        public const string Shelf_99T99 = "99T99";
        public const string Shelf_77S77 = "77S77";
        public const string BackBound = "BackBound";//退货标志

        public const int Outbound_Kind_Gel = 0;//普遍出库
        public const int Outbound_Kind_99T = 1;//出库到99T99
        public const int Outbound_Kind_FBA = 2;//从99T99出库
        public const int Outbound_Kind_Amazon = 3;//AMAZON出库
        public const int Outbound_Kind_Sample = 4;//样品出库

        #endregion

        #region 实例

        private int shelfCapacity = 30;  //货架容量
        private int clothesWarnCntLow = 5;//服装库存预警-下限
        private int clothesWarnCntUp = 10;//服装库存预警-上限
       
        private List<String> listSize = new List<String>();
        private List<String> listShelf = new List<String>();
        private List<Clothes> listClothes = new List<Clothes>();
        
        public int ShelfCapacity
        {
            get { return shelfCapacity; }
            set { shelfCapacity = value; }
        }
       
        public int ClothesWarnCntLow
        {
            get { return clothesWarnCntLow; }
        }
        
        public int ClothesWarnCntUp
        {

            get { return clothesWarnCntUp; }
        }

        public List<String> ListShelfNo
        {
            set{listShelf = value;}
            get { return listShelf; }
        }

        public List<String> ListSizeNo
        {
            get { return listSize; }
            set { listSize = value; }
        }

        public List<Clothes> ListClothes
        {
            get { return listClothes; }
            set { listClothes = value; }
        }

        public static MemoryTable Instance
        {
            get {
                if (instance == null)
                    instance = new MemoryTable();

                return instance; 
            }
        }

        private static MemoryTable instance = new MemoryTable() ;

        private MemoryTable()
        {
            //Cursor.Current = Cursors.WaitCursor;
            PengLang.WaitingService.BeginLoading();
            LoadSystemCode();
            LoadSizeNo();
            LoadShelfNo();
            LoadClothes();
            LoadSales();
            PengLang.WaitingService.EndLoading();
            //Cursor.Current = Cursors.Default;
        }

        public bool UpdateShelfCapacity(int value)
        {
            shelfCapacity = value;
            string sql = String.Format("update t_systemcode set codevalue = '{0}' where codetype= 'ShelfCapacity'", value);

            int nres = Database.ExecuteSQL(sql, "MemoryTable-UpdateShelfCapacity");

            return nres == 0 ? false : true;
        }

        public bool UpdateClothesWarnCount(int min, int max)
        {
            clothesWarnCntLow = min;
            clothesWarnCntUp = max;

            string sql = String.Format("update t_systemcode set codevalue = '{0}' where codetype= 'WarnCountLow'", min);

            int nres = Database.ExecuteSQL(sql, "MemoryTable-UpdateClothesWarnCount");

            sql = String.Format("update t_systemcode set codevalue = '{0}' where codetype= 'WarnCountUp'", max);

            nres = Database.ExecuteSQL(sql, "MemoryTable-UpdateClothesWarnCount");

            return nres == 0 ? false : true;
        }

        public bool LoadSystemCode()
        {
            string sql = "select codetype , codevalue from t_systemcode order by codetype ";
            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return false;

            string codetype, codevalue;
            for (int i = 0; i < dt.Rows.Count; i++)
            { 
                codetype = dt.Rows[i][0].ToString().Trim();
                codevalue = dt.Rows[i][1].ToString();
                if (string.IsNullOrEmpty(codevalue))
                    codevalue = "0";
                if (codetype.ToLower() == "shelfcapacity")
                    shelfCapacity = Convert.ToInt32(codevalue);
                else if (codetype.ToLower() == "warncountup")
                    clothesWarnCntUp = Convert.ToInt32(codevalue);
                else if (codetype.ToLower() == "warncountlow")
                    clothesWarnCntLow  = Convert.ToInt32(codevalue);
            }
            dt.Clear();
            return true;
        }

        public bool LoadSizeNo()
        {
            listSize.Clear();
            string sql = "select SizeNo, SizeNum,SizeCategory from t_size order by SizeCategory, sizeNum ";
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            int cnt = dt.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                listSize.Add(dt.Rows[i][0].ToString());
            }
            dt.Clear();
            return true;
        }

        public bool LoadShelfNo()
        {
            listShelf.Clear();
            string sql = "select ShelfNo from t_shelf  ";
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            int cnt = dt.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                listShelf.Add(dt.Rows[i][0].ToString());
            }
            dt.Clear();
            return true;
        }
        
        public void LoadClothes()
        {
            listClothes.Clear();

            string sql = "select StyleNo, ShellNo, LotNo, Model, Color, Shell,Price, StyleRemark From T_Clothes order by StyleNo, ShellNo, LotNo ";
            DataTable dt = Database.Select(sql);

            if (dt == null) return;
            Clothes clothes = null;

            for (int i = 0, col = 0, cnt = dt.Rows.Count; i < cnt; i++)
            {
                col = 0;
                clothes = new Clothes();

                clothes.StyleNo = dt.Rows[i][col++].ToString();
                clothes.ShellNo = dt.Rows[i][col++].ToString();
                clothes.LotNo = dt.Rows[i][col++].ToString();
                clothes.Model = dt.Rows[i][col++].ToString();
                clothes.Color = dt.Rows[i][col++].ToString();
                clothes.Shell = dt.Rows[i][col++].ToString();
                clothes.Price = dt.Rows[i][col++].ToString();
                clothes.StyleRemark = dt.Rows[i][col++].ToString();

                listClothes.Add(clothes);
            }

            dt.Clear();
        }

        #endregion

        #region 销售代理

        public List<String> SalesList = new List<String>();

        public void LoadSales()
        {
            List<String> list = SalesList;
            list.Clear();

            string sql = "select Sales from V_Sales ";

            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return ;

            string item;
            for (int i = 0, col = 0; i < dt.Rows.Count; i++)
            {
                col = 0; 
                item  = dt.Rows[i][col].ToString();
                 
                list.Add(item);
            }

            dt.Clear();
            
        }

        public int FindSales(string name)
        {
            for (int i = 0; i < SalesList.Count; i++)
            {
                if (SalesList[i]  == name)
                    return  i;
            }

            return -1;
        }

        #endregion

        #region 销售类型

        public string[] PaymentArray = new string[] { "FAC", "CHECK", "CREDET", "CASH" };

        public string GetPayment(string text)
        { 
            text = text.ToUpper();
            for (int i = 0; i < PaymentArray.Length; i++)
            {
                if (text == PaymentArray[i])
                    return PaymentArray[i];
            }

            return string.Empty;
        }

        #endregion
    }

    //内存对象
    public class ItemTag
    {
        public string Key;
        public string Caption;

        public ItemTag() { }
        public ItemTag(string key, string text) { Key = key; Caption = text; }
        public override string ToString()
        {
            return Caption;
        }
    }
}
