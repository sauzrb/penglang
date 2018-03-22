using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PengLang
{
	public class ColumnTag
	{
        public const int TagLength = 10;
        
        #region 索引
        
        public const int Index_DataType = 0;
        
        #endregion

        #region 数据类型

        public const int DataType_String = 0;
        public const int DataType_Integer = 1;
        public const int DataType_Long = 2;
        public const int DataType_Float = 3;
        public const int DataType_Double = 4;
        public const int DataType_Boolen = 5;
        public const int DataType_Object = 9;
        
        #endregion

        private int[] tag = new int[TagLength];

        public ColumnTag() 
        {
            //for (int i = 0; i < TagLength; i++)
            //    tag[i] = 0;
        }

        public int this[int index]
        {
            get
            {
                return tag[index];
            }
            set
            {
                tag[index] = value;
            }
        }

        public int DataType
        {
            get { return tag[Index_DataType]; }
            set { tag[Index_DataType] = value; }
        }

	}
}
