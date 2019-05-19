using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 出租车轨迹
{
    static class BasicClass
    {
        //这是直接照着书上来的写的方法
        public static double FangWeiJiao(double dx , double dy)
        {
            double dFan = Double.MaxValue;
            if(dx < 0)
            {
                dFan = Math.Atan(dy / dx) + Math.PI;
            }
            if(dx > 0)
            {
                dFan = Math.Atan(dy / dx);
            }
            if(dx == 0 && dy > 0)
            {
                dFan = Math.PI / 2;
            }
            if(dx == 0 && dy < 0)
            {
                dFan = Math.PI * 1.5;
            }
            if(dFan > Math.PI * 2)
            {
                dFan -= Math.PI * 2;
            }
            if(dFan < 0)
            {
                dFan += Math.PI * 2;
            }
            return dFan;
        }
        //方位角计算（优化版）
        public static double Azimuth(double dx , double dy)
        {
            double Fan = Math.Atan2(dy , dx);
            if(Fan < 0)
            {
                Fan += Math.PI;
            }
            return Fan;
        }

        //求距离

        public static double GetDis(double dx , double dy)
        {
            return Math.Sqrt(dx * dx + dy * dy);
        }
        public static double GetDis(Data fd, Data bd)
        {
            double dx = bd.X - fd.X;
            double dy = bd.Y - fd.Y;
            return GetDis(dx , dy);
        }
       //弧度转换为dms
        //public static double Rad2Dms(double rad)
        //{
        //    double deg = (rad * 180)/Math.PI;//保证进位
        //    double du = (int)(deg+0.01);
        //    double fen = (int)(60*(deg - du) + 0.01);
        //    double miao = (deg - du - fen / 60) * 3600;
        //    if(miao < 0)
        //    {
        //        miao = 0;
        //    }
        //    return du + fen / 100 + miao / 10000;
        //}
        public static double Rad2Dms(this double rad)
        {
            int sign, minAngle, degAngle;
            double secAngle, dmsAngle;
            sign = Math.Sign(rad);
            secAngle = Math.Abs(rad * 3600 * 180 / Math.PI);
            degAngle = (int)(secAngle / 3600 + 0.01);
            minAngle = (int)((secAngle - degAngle * 3600.0) / 60.0 + 0.01);
            secAngle = secAngle - degAngle * 3600.0 - minAngle * 60.0;
            if(secAngle < 0)
            {
                secAngle = 0;
            }
            dmsAngle = degAngle + minAngle / 60.0 + secAngle / 3600.0;
            dmsAngle *= sign;
            return dmsAngle;
        }
        public static double RAD2DMS(double radAngle)
        {
            int degAngle, minAngle, sign;
            double secAngle, dmsAngle;
            sign = 1;
            if (radAngle < 0)
            {
                sign = -1;
                radAngle = Math.Abs(radAngle);
            }
            secAngle = radAngle * 180.0 / Math.PI * 3600.0;
            degAngle = (int)(secAngle / 3600 + 0.01);
            minAngle = (int)((secAngle - degAngle * 3600.0) / 60.0 + 0.01);
            secAngle = secAngle - degAngle * 3600.0 - minAngle * 60.0;
            if (secAngle < 0) secAngle = 0;
            dmsAngle = degAngle + minAngle / 100.0 + secAngle / 10000.0;
            dmsAngle = dmsAngle * sign;
            return dmsAngle;
        }

        public static double Dms2Rad(double dms)
        {
            double deg, min, sec;
            deg = (int)dms;
            min = (int)((dms - deg)/60.0 * 100);
            sec = (int)((dms - deg - min) * 100.0 / 36.0);
            double rad = (deg * 3600 + min * 60 + sec) / 180.0 / 3600.0 * Math.PI;
            return rad;
        }
        public static double DMS2RAD(double dmsvalue)
        {
            int sign = 1;
            double radvalue = 0;
            double deg = 0, mm = 0, ss = 0;
            if (dmsvalue < 0)
            {
                sign = -1;
                dmsvalue = Math.Abs(dmsvalue);
            }
            deg = Math.Floor(dmsvalue + 0.0001);
            mm = Math.Floor((dmsvalue - deg) * 100 + 0.0001);
            ss = (dmsvalue - deg - mm / 100.0) * 10000;
            radvalue = (deg + mm / 60.0 + ss / 3600.0) * Math.PI / 180.0;
            radvalue = radvalue * sign;
            return radvalue;
        }

    }
}
