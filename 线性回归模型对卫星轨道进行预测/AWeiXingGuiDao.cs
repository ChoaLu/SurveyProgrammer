using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线性回归模型对卫星轨道进行预测
{
    class AWeiXingGuiDao
    {
        List<AData> ListData;
        canshu Xc;
        canshu Yc;
        canshu Zc;
        bool IsInit;

        public AWeiXingGuiDao(List<AData> ldata) 
        {
            this.ListData = ldata;
            if (InitCan() == Status.ERROR)
            {
                Console.WriteLine("ERROR！");
            }
            
        }

        //初始化参数
        public Status InitCan()
        {
            if(ListData != null)
            {
                double Tt = 0 , Xt = 0, Yt = 0, Zt = 0;//平均值
                foreach (var t in ListData)
                {
                    Tt += t.Time;
                    Xt += t.X;
                    Yt += t.Y;
                    Zt += t.Z;
                }
                Tt = Tt / ListData.Count;
                Xt = Xt / ListData.Count;
                Yt = Yt / ListData.Count;
                Zt = Zt / ListData.Count;

                double fenzix = 0, fenziy = 0, fenziz = 0, fenmu = 0;
                foreach(var t in ListData)
                {
                    fenzix += (t.Time - Tt) * (t.X - Xt);
                    fenziy += (t.Time - Tt) * (t.Y - Yt);
                    fenziz += (t.Time - Tt) * (t.Z - Zt);
                    fenmu += Math.Pow((t.Time - Tt) , 2);
                }

                //计算六个参数
                Xc.beta1 = fenzix / fenmu;
                Xc.beta0 = Xt - Xc.beta1 * Tt;

                Yc.beta1 = fenziy / fenmu;
                Yc.beta0 = Yt - Yc.beta1 * Tt;

                Zc.beta1 = fenziz / fenmu;
                Zc.beta0 = Zt - Zc.beta1 * Tt;

                IsInit = true;
                return Status.OK;  
            }
            else
            {
                return Status.ERROR;
            }
        }

        //获取轨道预计位置
        public AData GetPreView(double time)
        {
            AData data = null;
            if (IsInit)//表示已经初始化
            {
                double x = 0, y = 0, z = 0, t = 0;
                x = GetP(Xc , time);
                y = GetP(Yc , time);
                z = GetP(Zc , time);
                data = new AData(time , x , y , z);
            }
            return data;
        }

        public override string ToString()
        {
            string strcan = "";
            strcan += "X    " + Xc.tostring();
            strcan += "\r\nY    " + Yc.tostring();
            strcan += "\r\nZ    " + Zc.tostring();
            return strcan;
        }

        double GetP(canshu can , double time )
        {
            return can.beta0 + can.beta1 * time;
        }
        //一个方程的参数
        struct canshu
        {
           public double beta0;
           public double beta1;

            public canshu(double beta0 , double beta1)
            {
                this.beta0 = beta0;
                this.beta1 = beta1;
            }
            public string tostring()
            {
                return "beta0:  " + Math.Round(this.beta0 , 5).ToString() + "   beta1:  " + Math.Round(this.beta1, 5).ToString();
            }
        }
    }
}
