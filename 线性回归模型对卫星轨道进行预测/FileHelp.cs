using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace 线性回归模型对卫星轨道进行预测
{
    class FileHelp
    {
        //数据的读取
        public static List<AData> DataReader(string path)
        {
            List<AData> listData = new List<AData>();
            StreamReader sr = new StreamReader(path);
            while (sr.Peek() != -1)
            {
                try
                {
                    string[] temp = sr.ReadLine().Split(',');
                    listData.Add(new AData(temp[0], temp[1], temp[2], temp[3]));
                }
                catch
                {
                    continue;
                }
            }
            return listData;
        }

        //保存文件
        public static  status DataSave(string report , string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Write(report);
                return status.数据保存成功;
            }
            catch
            {
                return status.保存失败;
            }
        }

        public enum status
        {
            数据保存成功,
            保存失败
        }
    }
}
