using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PengLang
{
    public class InventoryItem
    {

        #region Clothes Data

        private string id;
        private string shelfNo;
        private string shellNo;
        private string model;
        private string styleNo;
        private string lotNo;
        private string shell;
        private string color;
        private string price;

        public string ID { get { return id; } set { id = value; } }
        public string ShelfNo { get { return shelfNo; } set { shelfNo = value; } }
        public string Model { get { return model; } set { model = value; } }
        public string StyleNo { get { return styleNo; } set { styleNo = value; } }
        public string ShellNo { get { return shellNo; } set { shellNo = value; } }
        public string LotNo { get { return lotNo; } set { lotNo = value; } }
        public string Shell { get { return shell; } set { shell = value; } }
        public string Color { get { return color; } set { color = value; } }
        public string Price { get { return price; } set { price = value; } }

        #endregion

        #region Regular Size

        public int R36;
        public int R38;
        public int R40;
        public int R42;
        public int R44;
        public int R46;
        public int R48;
        public int R50;
        public int R52;
        public int R54;
        public int R56;
        public int R58;
        public int R60;
        public int R62;

        #endregion

        #region Long Size

        public int L38;
        public int L40;
        public int L42;
        public int L44;
        public int L46;
        public int L48;
        public int L50;
        public int L52;
        public int L54;
        public int L56;
        public int L58;
        public int L60;
        public int L62;

        #endregion

        #region Short Size

        public int S34;
        public int S36;
        public int S38;
        public int S40;
        public int S42;
        public int S44;
        public int S46;

        #endregion

        #region SubTotal

        private int subTotal;
        public int SubTotal { get { return subTotal; } set { subTotal = value; } }

        #endregion

        //计算合计
        public void GetTotal()
        {
        
        }
        //赋值
        public void Set(string sizeNo, int value)
        {
            string name = sizeNo; //GetProperty(sizeNo);

            if (name.IndexOf("L") > -1)
            {
                if (name == "L38")
                    L38 = value;
                else if (name == "L40")
                    L40 = value;
                else if (name == "L42")
                    L42 = value;
                else if (name == "L44")
                    L44 = value;
                else if (name == "L46")
                    L46 = value;
                else if (name == "L48")
                    L48 = value;
                else if (name == "L50")
                    L50 = value;
                else if (name == "L52")
                    L52 = value;
                else if (name == "L54")
                    L54 = value;
                else if (name == "L56")
                    L56 = value;
                else if (name == "L58")
                    L58 = value;
                else if (name == "L60")
                    L60 = value;
                else if (name == "L62")
                    L62 = value;
            }
            else if (name.IndexOf("R") > -1)
            {
                if (name == "R36")
                    R36 = value;
                else if (name == "R38")
                    R38 = value;
                else if (name == "R40")
                    R40 = value;
                else if (name == "R42")
                    R42 = value;
                else if (name == "R44")
                    R44 = value;
                else if (name == "R46")
                    R46 = value;
                else if (name == "R48")
                    R48 = value;
                else if (name == "R50")
                    R50 = value;
                else if (name == "R52")
                    R52 = value;
                else if (name == "R54")
                    R54 = value;
                else if (name == "R56")
                    R56 = value;
                else if (name == "R58")
                    R58 = value;
                else if (name == "R60")
                    R60 = value;
                else if (name == "R62")
                    R62 = value;
            }
            else
            {
                if (name == "S34")
                    S34 = value;
                else if (name == "S36")
                    S36 = value;
                else if (name == "S38")
                    S38 = value;
                else if (name == "S40")
                    S40 = value;
                else if (name == "S42")
                    S42 = value;
                else if (name == "S44")
                    S44 = value;
                else if (name == "S46")
                    S46 = value;
                 
            }
        }

        public string GetField(string sizeNo)
        {
            sizeNo = sizeNo.ToUpper();
            int idx = -1;
            string flag = "";
            if (sizeNo.IndexOf("L") > -1)
            {
                idx = sizeNo.IndexOf("L");
                flag = "L";
            }
            else if (sizeNo.IndexOf("R") > -1)
            {
                idx = sizeNo.IndexOf("R");
                flag = "R";
            }
            else
            {
                idx = sizeNo.IndexOf("S");
                flag = "S";
            }

            sizeNo = sizeNo.Remove(idx, 1);
             
            return flag + sizeNo ;

        }

        public string GetSizeNo(string colName)
        {
            string sizeNo = colName; 
            sizeNo = sizeNo.ToUpper();
            int idx = -1;
            string flag = "";
            if (sizeNo.IndexOf("L") > -1)
            {
                idx = sizeNo.IndexOf("L");
                flag = "L";
            }
            else if (sizeNo.IndexOf("R") > -1)
            {
                idx = sizeNo.IndexOf("R");
                flag = "R";
            }
            else
            {
                idx = sizeNo.IndexOf("S");
                flag = "S";
            }

            sizeNo = sizeNo.Remove(idx, 1);

            return sizeNo + flag;
           
        }

        static public string ConvertToSizeNo(string colName)
        {
            string sizeNo = colName;
            sizeNo = sizeNo.ToUpper();
            int idx = -1;
            string flag = "";
            if (sizeNo.IndexOf("L") > -1)
            {
                idx = sizeNo.IndexOf("L");
                flag = "L";
            }
            else if (sizeNo.IndexOf("R") > -1)
            {
                idx = sizeNo.IndexOf("R");
                flag = "R";
            }
            else
            {
                idx = sizeNo.IndexOf("S");
                flag = "S";
            }

            sizeNo = sizeNo.Remove(idx, 1);

            return sizeNo + flag;
        }
    }
}
