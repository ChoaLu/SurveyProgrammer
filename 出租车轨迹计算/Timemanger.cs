using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 出租车轨迹
{
    //时间转换类
    class Timemanger
    {
        //将标准时间转换为格略日
        public static double Time2MJD(string time)
        {
            float YYYY = 0;
            float MM = 0;
            float DD = 0;
            float HH = 0;
            float NN = 0;
            float SS = 0;
            try
            {
                YYYY = (float)Convert.ToDouble(time.Substring(0, 4));
                MM = (float)Convert.ToDouble(time.Substring(4, 2));
                DD = (float)Convert.ToDouble(time.Substring(6, 2));
                HH = (float)Convert.ToDouble(time.Substring(8, 2));
                NN = (float)Convert.ToDouble(time.Substring(10, 2));
                SS = (float)Convert.ToDouble(time.Substring(12, 2));

            }
            catch (Exception)
            {
                return 0;
            }
            double t1 = (int)(7.0 / 4.0 * (YYYY + (int)((MM + 9) / 12)));
            double t2 = (int)((275.0 * MM)/9.0);
            double MJD = -678987 + 367.0 * YYYY - t1 - t2 + DD + HH / 24.0 + NN / 1440.0 + SS / 86400.0;
            return MJD;
        }
    }
}
