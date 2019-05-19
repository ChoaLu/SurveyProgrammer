using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 出租车轨迹
{
    //存储一行数据的类型
    public struct Data
    {
        public string Code;
        public int Status;
        public double MDJTime;
        public double X;
        public double Y;

        public Data(string code, int status, string strTime, double X, double Y)
        {
            this.Code = code;
            this.Status = status;
            this.MDJTime = Timemanger.Time2MJD(strTime);
            this.X = X;
            this.Y = Y;
        }
         

    }

}
