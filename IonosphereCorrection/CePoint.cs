using System;

namespace IonosphereCorrection
{
    //表示测站的信息
    class CePoint:Point
    {
        private double bp, lp;
        public double Bp
        {
            get
            {
                return bp;
            }
        }
        public double Lp
        {
            get
            {
                return lp;
            }
        }
        private Time curtime;
        public Time CurTime
        {
            get
            {
                return curtime;
            }
        }
        public CePoint(double x , double y , double z , double Bp , double Lp , Time Curtime):base(x , y , z)
        {
            curtime = Curtime;
            this.bp = Bp;
            this.lp = Lp;
        }


        public void XYZ2BLH( ref double radB, ref double radL, ref double H)
        {
            //暂且使用WGS84
            double a = 6378137.0;
            double b = 6356752.3142;
            double e2 = (a * a - b * b) / (a * a);
            double e12 = e2 / (1 - e2);
            double X1 = X;
            double Y1 = Y;
            double Z1 = Z;
            double L = Math.Atan(Y1 / X1);

            double sita = Math.Atan(Z1 * a / (Math.Sqrt(X1 * X1 + Y1 * Y1) * b));
            double B = Math.Atan((Z1 + e12 * b * Math.Pow(Math.Sin(sita), 3)) /
                (Math.Sqrt(X1 * X1 + Y1 * Y1) - e2 * a * Math.Pow(Math.Cos(sita), 3
                )));
            double N = a / (1 - e2 * Math.Pow(Math.Sin(b), 2));

            H = Math.Sqrt(X1 * X1 + Y1 * Y1) / Math.Cos(b) - N;

            if(L < 0)
            {
                L += Math.PI;
            }
            radB = B;
            radL = L;

        }

        public override string ToString()
        {
            return string.Format("测站信息\r\nX:{0:0.0000},    Y:{1:0.0000}    Z:{2:0.0000}\r\nBp:{3:0.0000}    Lp:{4:0.0000}" ,
                this.X , this.Y , this.Z , this.bp , this.lp); 
        }
    }
}
