using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonosphereCorrection
{
    //表示一个卫星坐标对应的信息
    class OPoint
    {
        public string Id;
        private double a;
        private double e;
        private double tion;
        private Point ResP;//
                           //  private DateTime curTime;//表示当前时间

        public Point ForP;//地心坐标
        public double A
        {
            get
            {
                return a;
            }
        }
        public double E
        {
            get
            {
                return e;
            }
        }
        public double Tion
        {
            get
            {
                return tion;
            }
        }


        //初始化计算
        public void InitP(CePoint cpoint)
        {
            Point dp = ForP - cpoint;
            double radBp = 0 , radLp = 0 ,h = 0;
            cpoint.XYZ2BLH( ref radBp , ref radLp , ref h);
            double[,] Romat = Algo.RoMat(radBp, radLp);
            ResP = Romat * dp;


            a = Math.Atan(ResP.Y / ResP.X);
            if(a < 0)
            a = a + Math.PI;
            
            e = Math.Atan(ResP.Z / (Math.Sqrt(ResP.X * ResP.X + ResP.Y * ResP.Y)));

            //double dua = a * 180.0 / Math.PI;
            //double due = e * 180.0 / Math.PI;

            //计算穿刺点地磁纬度
            double X = 0.0137 / (e + 0.11) - 0.022;

            double fai = radBp + X * Math.Cos(a);
            double lanta = radLp + X * Math.Sin(a) / Math.Cos(fai);

            double faim = fai + 0.064 * Math.Cos(lanta - 1.617);

            //计算电离层延迟量
            double[] arfa = { 0.1397 * Math.Pow(10 , -7) , -0.7451 * Math.Pow(10, -8), -0.5960 * Math.Pow(10, -7), 0.1192 * Math.Pow(10, -6) };
            double[] beta = { 0.1270 * Math.Pow(10, 6), -0.1966 * Math.Pow(10, 6), 0.6554 * Math.Pow(10, 5), 0.2621 * Math.Pow(10, 6) };
            double A1 = 5 * Math.Pow(10, -9);//夜间时间常量
            double A3 = 50400.0;//表示取最大值时当地时间
            double A2 = arfa[0] + arfa[1] * faim + arfa[2] * faim * faim + arfa[3] * Math.Pow(faim , 3);
            double A4 = beta[0] + beta[1] * faim + beta[2] * faim * faim + beta[3] * Math.Pow(faim , 3);
            double t = cpoint.CurTime.SecondOfDay() + 43200.0 * lanta;//应该是这个时刻的秒数
            double ptemp = (Math.PI * 2 * (t - A3) / A4);
            double F = 1 + 16.0 * Math.Pow((0.53 - e) , 3);
           //电离层延时量
            if(Math.Abs(ptemp) < 1.57)
            {
                tion = F * (A1 + A2 * Math.Cos(ptemp));
            }
            else
            {
                tion = F * A1;
            }
            tion = tion * 299792458;

        }

        public OPoint (string id , Point p , CePoint cpoint )
        {
            this.Id = id;
            ForP = p;
           // curTime = dt;
            InitP(cpoint);
            
        }
        

        public  OPoint(string id, double x ,double y , double z)
        {
           // curTime = dt;
            this.Id = id;
            ForP = new Point(x , y , z);
        }

        public OPoint (string id , string x , string y , string z)
        {
            this.Id = id;
           // curTime = dt;
            double dx = Convert.ToDouble(x) * Math.Pow(10 , 3);
            double dy = Convert.ToDouble(y) * Math.Pow(10, 3);
            double dz = Convert.ToDouble(z) * Math.Pow(10 , 3);
            ForP = new Point(dx, dy , dz); 
        }

        public override string ToString()
        {
            return string.Format("\r\n{0}   {1:0.000}   {2:0.000}   {3:0.000}" , this.Id , this.E , this.A , this.Tion); 
        }

    }
}
  