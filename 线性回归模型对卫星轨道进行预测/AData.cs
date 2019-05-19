using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线性回归模型对卫星轨道进行预测
{
    class AData
    {
       public double Time;
       public double X;
       public double Y;
       public double Z;

        public AData(double t , double x , double y , double z )
        {
            this.Time = t;
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public AData(string t, string x, string y, string z)
        {
            this.Time = Convert.ToDouble(t);
            this.X = Convert.ToDouble(x);
            this.Y = Convert.ToDouble(y);
            this.Z = Convert.ToDouble(z);
        }
    }
}
