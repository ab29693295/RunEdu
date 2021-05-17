using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Service.Service
{
  public  class TimeHelper
    {

        public static string TransTimeSecondIntToString(long second)
        {
            string str = "";
            long hour = second / 3600;
            long min = second % 3600 / 60;
            long sec = second % 60;
            if (hour < 10)
            {
                str += "0" + hour.ToString();
            }
            else
            {
                str += hour.ToString();
            }
            str += ":";
            if (min < 10)
            {
                str += "0" + min.ToString();
            }
            else
            {
                str += min.ToString();
            }
            str += ":";
            if (sec < 10)
            {
                str += "0" + sec.ToString();
            }
            else
            {
                str += sec.ToString();
            }
            return str;
        }
    }
}
