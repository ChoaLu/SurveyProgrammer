using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 轨迹数据压缩算法实现
{
    class Trail
    {
        public double D;
        public List<point> lisData = new List<point>();//压缩前的轨迹数据
        List<int> lisRes = new List<int>();//存储压缩后的轨迹数据

      
        public Trail(List<point> lisdata )
        {
            this.lisData = lisdata;
            this.D = 0;
        }


        public List<point> StartZip(double dm)
        {
            D = dm;
            lisRes.Clear();
            lisRes.Add(0);
            lisRes.Add(lisData.Count - 1 );
            GetZip(0 , lisData.Count-1);
            lisRes.Sort();
            List<point> res = new List<point>();
            foreach(var t in lisRes)
            {
                res.Add(lisData[t]);
            }
           
            return res;

        }

        //轨迹数据压缩
        public void GetZip(int head , int back)
        {
            int mindex = 0;
            double  maxlength = 0;
            GetMaxLength(head, back, ref maxlength, ref mindex);
            if(maxlength > D)
            {
                lisRes.Add(mindex);
                GetZip(head , mindex);
                GetZip(mindex , back);
                
            }
        }

        //从listData中获取指定范围内的最大距离
        public void  GetMaxLength(int head , int back , ref double maxLength , ref int mIndex)
        {
            if(head > back && back > lisData.Count -1 && head < 0)
            {
                throw new Exception("数组的下标输d入错误！");
            }
            maxLength = double.MinValue;
            double a = 0, b = 0;
            GetPara(head , back,ref a ,ref b);
            for(int i = head+1; i < back; i++)
            {
                double length = Math.Abs(a * lisData[i].X - lisData[i].Y + b) / Math.Sqrt(a * a + 1);
                if(length > maxLength)
                {
                    maxLength = length;
                    mIndex = i;
                }
            }
             
        }

        //通过两点求一次函数参数
        private void GetPara(int headi , int backi , ref double a , ref double b)
        {
            
            point headp = lisData[headi];
            point backp = lisData[backi];
            if(headp == backp)
            {
                throw new Exception("输入的点的坐标相同！");
            }
            a = (backp.Y - headp.Y) / (backp.X - headp.X);
            b = backp.Y - a * backp.X;
        }



    

    }
    public class point
        {
            public string Id;
            public double X;
            public double Y;

            
            public point (string id , double  x, double y)
            {
                this.X = x;
                this.Y = y;
                this.Id = id;
            }

        public point (string id , string x , string y)
        {
            this.Id = id;
            this.X = Convert.ToDouble(x);
            this.Y = Convert.ToDouble(y);
        }

            public static bool operator ==(point p1, point p2)
            {
                if (p1.X == p2.X && p1.Y == p2.Y)
                {
                    return true;
                }
                return false;
            }

            public static bool operator !=(point p1, point p2)
            {
                if (p1.X != p2.X || p1.Y != p2.Y)
                {
                    return true;
                }
                return false;
            }


        public override string ToString()
        {
            return string.Format("Id:{0} , x:{1:0.000} , y:{2:0.000}\r\n" , Id , X , Y); 
        }
    }

}
