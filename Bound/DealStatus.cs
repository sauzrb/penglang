using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PengLang
{
     public class DealStatus
    {
         public const string Complete = "complete"; //完成
 
         public const string Doing = "doing";//正在处理 
         public const string None = "";//空
         public const string Yes = "1";
         public const string No = "0";

         public const string PreInput = "0";
         public const string PreSell = "0";
         public const string Outbound = "2";
         public const string Inbound = "2";
         public const string Finish = "3"; 
         public const string Error = "-1";

         public const string Caption_Complete = "完成";
         public const string Caption_Unfinished = "未完成";
         public const string Caption_Doing = "正在处理";
         public const string Caption_None = "";
         public const string Caption_PreSell = "预销售";
         public const string Coption_Outbund = "正在出库";
         public const string Caption_Error = "失败";

    }
}
