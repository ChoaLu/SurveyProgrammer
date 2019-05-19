using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonosphereCorrection
{
    //三维空间点
  public  class Point
    {
        public double X;
        public double Y;
        public double Z;

        public  Point(double x , double y , double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point(string x , string y , string z)
        {
            this.X = Convert.ToDouble(x);
            this.Y = Convert.ToDouble(y);
            this.Z = Convert.ToDouble(z);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        

        //旋转矩阵计算
        public static Point operator *(double [,] rMat , Point dp)
        {
            double[,] dpmat = { { dp.X }, { dp.Y}  ,{ dp.Z} };
            dpmat = Algo.MatMulti(rMat , dpmat);
            return new Point(dpmat[0,0] , dpmat[1,0] , dpmat[2,0]);
        }
    }
}
