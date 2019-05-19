using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonosphereCorrection
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
        //弧度转换为角度
        public static double Rad2Dms(this double rad)
        {
            int sign, minAngle, degAngle;
            double secAngle, dmsAngle;
            sign = Math.Sign(rad);
            secAngle = Math.Abs(rad * 3600 * 180 / Math.PI);
            degAngle = (int)(secAngle / 3600 + 0.0001);
            minAngle = (int)((secAngle - degAngle * 3600.0) / 60.0 + 0.0001);
            secAngle = secAngle - degAngle * 3600.0 - minAngle * 60.0;
            if (secAngle < 0)
            {
                secAngle = 0;
            }
            dmsAngle = degAngle + minAngle / 100.0 + secAngle / 10000.0;
            dmsAngle *= sign;
            return dmsAngle;
        }

        //生成旋转矩阵
        public static double[,] RoMat(double radbp, double radlp)
        {
            
            double sinbp = Math.Sin(radbp);
            double cosbp = Math.Cos(radbp);
            double sinlp = Math.Sin(radlp);
            double coslp = Math.Cos(radlp);
            double[,] rMat = {
                { -sinbp * coslp , - sinbp * sinlp , cosbp },
                { -sinlp , coslp , 0},
                { cosbp * coslp , cosbp * sinlp , sinbp}
            };
            return rMat;
        }

        //矩阵乘法
        public static double[,] MatMulti(double[,] M1, double[,] M2)
        {

            //GetLength(0) 是获取行数
            //GetLenght(1) 是获取列数
            int hang1 = M1.GetLength(0);
            int lie1 = M1.GetLength(1);//第一个矩阵的列数

            int hang2 = M2.GetLength(0);//第二个矩阵的行数
            int lie2 = M2.GetLength(1);

            if (lie1 != hang2)
            {
                throw new Exception("输入的矩阵无法相乘！");
            }
            double[,] M3 = new double[hang1, lie2];

            for (int i = 0; i < hang1; i++)
            {
                for (int e = 0; e < lie2; e++)
                {
                    double sum1 = 0;
                    for (int j = 0; j < lie1; j++)
                    {
                        sum1 += M1[i, j] * M2[j, e];
                    }
                    M3[i, e] = sum1;
                }
            }
            return M3;
        }

       
        

        
    }
}
