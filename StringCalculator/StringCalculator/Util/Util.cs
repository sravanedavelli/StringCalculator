using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public static class Util
    {

         public static int if_int(object o, int default_int)
        {
            if (o == null)
            {
                return default_int;
            }
            else if (o == DBNull.Value)
            {
                return default_int;
            }
            else if (o.ToString() == "")
            {
                return default_int;
            }
            else if (Util.GetNumbersFromString(o.ToString()) == o.ToString().Trim())
            {
                return Convert.ToInt32(o);
            }
            else
            {
                return default_int;
            }
        }

         public static string GetNumbersFromString(string number)
         {
             return string.Join(null, System.Text.RegularExpressions.Regex.Split(number, "[^\\d]"));
         }
    }
}
