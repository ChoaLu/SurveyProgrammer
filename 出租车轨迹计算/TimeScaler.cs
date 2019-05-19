using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 出租车轨迹
{
    //表示每段数据
    class TimeScaler
    {
        Data Fdata;
        Data Bdata;
        bool isIni = false;//表示是否被初始化
        public Data FData
        {
            get
            {
                if(isIni)
                {
                    return Fdata;
                }
                else
                {
                    return new Data();//返回一个空的行对象
                }
            }
        }
        public Data BData
        {
            get
            {
                if (isIni)
                {
                    return Bdata;
                }
                else
                {
                    return new Data();//返回一个空的行对象
                    //这是个问题目前还没想好解决的办法
                }
            }
        }
        //速度
        public double Vectory
        {
            get
            {
                double dtime = BData.MDJTime - FData.MDJTime;
                double dx = BData.X - FData.X;
                double dy = BData.Y - FData.Y;
                double distace = Math.Sqrt(dx * dx + dy * dy);
                return distace / (dtime*24) / 1000 ;
            }
        }
        public string Code
        {
            get
            {
                if(BData.Code == FData.Code)
                {
                    return FData.Code;
                }
                return null;
            }
        }
        public double Azimuth
        {
            get
            {
                double dx = BData.X - FData.X;
                double dy = BData.Y - FData.Y;
                double fangwei =  BasicClass.Azimuth(dx , dy);
                fangwei = Math.Round(fangwei , 3);
                return fangwei;
            }
        }
        public double Length
        {
            get
            {
                double dx = Bdata.X - FData.X;
                double dy = BData.Y - FData.Y;
                return BasicClass.GetDis(dx, dy);
            }
        }
        public TimeScaler(Data data1, Data data2)
        {
            isIni = true;
            Fdata = data1;
            Bdata = data2;
        }

    }

   
}
