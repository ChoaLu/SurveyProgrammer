using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace 出租车轨迹
{
    class DataManger
    {
        List<TimeScaler> ListTime;//存储时间段的链表
        List<string> ListName;//存储所有标识的队列
        public DataManger()
        {
            ListTime = new List<TimeScaler>();
            ListName = new List<string>();
        }

        public void DataReader(string dataPath)
        {
            StreamReader sr = new StreamReader(dataPath);
            try
            {
                string line = "";
                string[] arrayp = new string[5];
                List<Data> listdata = new List<Data>();
                while (sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    arrayp = line.Split(',');
                    string code = arrayp[0];
                    int status = (int)Convert.ToDouble(arrayp[1]);
                    string starttime = arrayp[2];
                    double x = Convert.ToDouble(arrayp[3]);
                    double y = Convert.ToDouble(arrayp[4]);
                    Data data = new Data(code, status, starttime, x, y);
                    if (!ListName.Contains(code))
                    {
                        ListName.Add(code);
                    }
                    listdata.Add(data);//将所有的行存储到队列中
                }
                for (int i = 0; i < ListName.Count; i++)
                {
                    Data fdata = new Data();
                    foreach (var t in listdata)
                    {
                        if (t.Code == ListName[i])
                        {
                            if (fdata.Code == null)
                            {
                                fdata = t;
                                continue;
                            }
                            ListTime.Add(new TimeScaler(fdata, t));
                            fdata = t;
                        }
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("文件读取错误" + e.Message);
            }
        }
        //保存文件
        public void SaveReport(string path)
        {
            var sw = new StreamWriter(path);
            sw.Write(this.ToString());
            sw.Close();
        }

        //输出报告
        public override string ToString()
        {
            int CurIndex = 0;
            string strReport = "------速度和方位角计算------\r\n";
            string strHuiZon = "------距离和计算结果------\r\n";
            double SumDis = 0;
            double fdDis = 0;
            for (int i = 0; i < ListName.Count; i++)
            {
                SumDis = 0;
                string CurName = ListName[i];
                for (int t = 0; t < ListTime.Count; t++)
                {
                    if (ListTime[t].Code == CurName)
                    {
                        SumDis += ListTime[t].Length;
                        double azimuth = BasicClass.Rad2Dms(ListTime[t].Azimuth);
                        strReport += String.Format("{0:D2},{1:F5}-{2:F5},{3:F5},{4:F5}\r\n", CurIndex++,
                        ListTime[t].FData.MDJTime, ListTime[t].BData.MDJTime, ListTime[t].Vectory, azimuth);
                    }
                }
                int minIndex = 0, maxIndex = 0;
                for (int j = 0; j < ListTime.Count; j++)
                {
                    if (ListTime[j].Code.Equals(CurName))
                    {
                        minIndex = j;
                        break;
                    }
                }//找到结尾行
                for (int j = 1; j < ListTime.Count; j++)
                {
                    if (ListTime[ListTime.Count - j].Code.Equals(CurName))
                    {
                        maxIndex = ListTime.Count - j;
                        break;
                    }
                }//找到起始行

                fdDis = BasicClass.GetDis(ListTime[minIndex].FData, ListTime[maxIndex].BData);
                strHuiZon += String.Format("车辆标识:{0}\r\n", ListTime[minIndex].FData.Code);
                strHuiZon += String.Format("累计距离:{0:F3}(Km)\r\n",Math.Round(SumDis/1000 , 3));
                strHuiZon += String.Format("首尾直线距离:{0:F3}(Km)\r\n", Math.Round(fdDis/1000 , 3));
                strReport += strHuiZon;
                strHuiZon = "";
            }
            return strReport + strHuiZon;

        }
    }
        public enum CarStatus
        {
            空车,
            载客,
            驻车,
            停运,
            其他
        }
    
}
