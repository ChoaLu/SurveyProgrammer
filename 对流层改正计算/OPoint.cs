using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 对流层改正计算
{
  public  class OPoint:Point
    {
        double _mv;
        double _md;
        double Rad2Dms = 180 / Math.PI;

        public double ZHD {
            get
            {
                return 2.29951 * Math.Pow(Math.E , -0.000116 * H);
            }
        }

        public double ZWD
        {
            get
            {
                return 0.1;
            }
        }

        public double DS {
            get
            {
                return ZHD * Md + ZWD * Mw;
            }
        }


       public double Mw
        {
            get
            {
                return _mv;
            }
        } 
        public double Md
        {
            get
            {
                return _md;
            }
        }

        public OPoint(string id , string b , string l , string h , string el , DateTime dt):base(id , b , l , h , el , dt)
        {
            InitMv();
            InitDv();
        }

        void InitDv()
        {
            double ad, bd, cd;
            double t = time.DayOfYear;
            double t0 = 28.0;
            double aht = 2.53 * Math.Pow(10 , -5);
            double bht = 5.49 * Math.Pow(10 , -3);
            double cht = 1.14 * Math.Pow(10 , -3);

            double[] ah_avg = { 0.0012769934, 0.0012683230, 0.0012465397,
                          0.0012196049, 0.0012045996 };
            double[] bh_avg = { 0.0029153695, 0.0029152299, 0.0029288445,
                          0.0029022565, 0.0029024912 };
            double[] ch_avg = { 0.062610505, 0.062837393, 0.063721774,
                          0.063824265, 0.064258455 };

            double [] ah_amp = { 0.062610505, 0.062837393, 0.063721774,
                          0.063824265, 0.064258455 };
            double[] bh_amp =  { 0.0, 0.000021414979, 0.000030160779,
                          0.000072562722, 0.00011723375 };
            double [] ch_amp = { 0.0, 0.000090128400, 0.000043497037,
                                0.00084795348, 0.0017037206 };
            double dt = Math.Cos(2 * Math.PI * (t - t0) / 365.25);
            if (L < 15)
            {
                
                ad = ah_avg[0] + ah_avg[0] * dt;
                bd = bh_avg[0] + bh_avg[0] * dt;
                cd = ch_avg[0] + ch_avg[0] * dt;
            }
            else if(L < 75)
            {
                int i = (int)(L / 15) - 1;
                double dfai = (L - (i + 1) * 15) / 15;
                ad = ah_avg[i] + (ah_avg[i + 1] - ah_avg[i]) * dfai +
                    (ah_avg[i] + (ah_avg[i + 1] - ah_avg[i]) * dfai * dt);
                bd = bh_avg[i] + (bh_avg[i + 1] - bh_avg[i]) * dfai +
                    (bh_avg[i] + (bh_avg[i + 1] - bh_avg[i]) * dfai * dt);
                cd = ch_avg[i] + (ch_avg[i + 1] - ch_avg[i]) * dfai +
                    (ch_avg[i] + (ch_avg[i + 1] - ch_avg[i]) * dfai * dt);
            }
            else
            {
                ad = ah_avg[4] + ah_avg[4] * dt;
                bd = bh_avg[4] + bh_avg[4] * dt;
                cd = ch_avg[4] + ch_avg[4] * dt;
            }

            double f1 = bd / (1.0 + cd);
            double f2 = ad / (1.0 + f1);
            double f3 =  1.0 + f2;

            double radEl = El.Dms2Rad();
            double sinE = Math.Sin(radEl);
            double m1 = bd / (sinE + cd);
            double m2 = ad / (sinE + m1);
            double m3 = sinE + m2;

            double t1 = bht / (1.0 + cht);
            double t2 = aht / (1.0 + t1);
            double t3 = 1.0 + t2;

            double g1 = bht / (sinE + cht);
            double g2 = aht / (sinE + g1);
            double g3 = sinE + g2;

            double d1 = H / 1000.0 * ((1.0 / sinE) - t3 / g3);

            _md = f3 / m3 + d1;
        }

        void InitMv()
        {
            double aw, bw, cw;
            double[] Pa_avg =  { 0.00058021897, 0.00056794847, 0.00058118019,
                           0.00059727542, 0.00061641693 }; 
            double[] Pb_avg = { 0.0014275268, 0.0015138625, 0.0014572752,
                           0.0015007428, 0.0017599082 };
            double[] Pc_avg =  { 0.043472961, 0.046729510, 0.043908931,
                                0.044626982, 0.054736038 }; 
            if(L < 15)
            {
                aw = Pa_avg[0];
                bw = Pb_avg[0];
                cw = Pc_avg[0];
            }
            else if(L < 75)
            {
                int i = (int)(L / 15) - 1;
                aw = Pa_avg[i] + (Pa_avg[i + 1] - Pa_avg[i]) * (L - (i+1) * 15.0) / 15.0;
                bw = Pb_avg[i] + (Pb_avg[i + 1] - Pb_avg[i]) * (L - (i + 1) * 15.0) / 15.0;
                cw = Pc_avg[i] + (Pc_avg[i + 1] - Pc_avg[i]) * (L - (i + 1) * 15.0) / 15.0;


                int t = (int)(L / 15.0) - 1;
                double frac = (L - 15.0 * (i + 1)) / 15.0;
                double a = Pa_avg[i] + frac * (Pa_avg[i + 1] - Pa_avg[i]);
                double b = Pb_avg[i] + frac * (Pb_avg[i + 1] - Pb_avg[i]);
                double c = Pc_avg[i] + frac * (Pc_avg[i + 1] - Pc_avg[i]);
            }
            else
            {
                aw = Pa_avg[4];
                bw = Pb_avg[4];
                cw = Pc_avg[4];
            }
            double sinE = Math.Sin(El / Rad2Dms);
            double t1 = bw / (1.0 + cw);
            double t2 = aw / (1.0 + t1);
            double t3 =  (1.0 + t2);
            
            double r1 = bw / (sinE + cw);
            double r2 = aw / (sinE + r1);
            double r3 =  (sinE + r2);
            _mv = t3 / r3;

        }

        public override string ToString()
        {
            string line = string.Format("\r\n{0}    {1:0.00}    {2:0.000}   {3:0.000}   {4:0.000}   {5:0.000}   {6:0.000}",
                Id , El , ZHD , Md , ZWD , Mw , DS);
            return line;
        }
    }
}
