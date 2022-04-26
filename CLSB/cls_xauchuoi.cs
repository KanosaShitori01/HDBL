using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLSB
{
    public class cls_xauchuoi
    {
        private static string handleNumStr(int num)
        {
            string strN = "";
            if(num > 9)
            {
                strN = "0" + num; 
            }else if(num > 99)
            {
                strN = num.ToString();
            }
            strN = "00" + num;
            return strN;
        }
        public static string mahang_sieudang(string id, string date, int num = 1)
        {
            string number = handleNumStr(num);
            string mahsd = String.Format("{0}-{1}-{2}", id, date, number);
            return mahsd;
        }
    }
}
