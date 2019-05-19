using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 对流层改正计算
{
   public static class Algo
    { 
        //角度转换为弧度
        public static double Dms2Rad(this double dms)
        {
            double deg, min, sec;
            deg = (int)dms;

            min = (int)((dms - deg) * 100);
            sec = ((dms - deg - min / 100.0) * 10000.0);
            double rad = (deg * 3600 + min * 60 + sec) / 180.0 / 3600.0 * Math.PI;
            return rad;
        }
    }
}
