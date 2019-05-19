using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace 对流层改正计算
{
   public static  class  FileHelp
    {
        public static List<OPoint> DataReader(string path)
        {
            List<OPoint> listOpoint = new List<OPoint>();
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {

                try
                {
                    string[] elements = sr.ReadLine().Split(',');
                    int year = Convert.ToInt32(elements[1].Substring(0 ,4));
                    int month = Convert.ToInt32(elements[1].Substring(4 , 2));
                    int day = Convert.ToInt32(elements[1].Substring(6, 2));
                    listOpoint.Add(new OPoint(elements[0] , elements[2] , elements[3] , elements[4] , elements[5] , new DateTime(year , month , day)));
                }catch
                {
                    //当某行读取错误的时候继续读取下一行，读取到文件末尾
                    continue;
                }
            }
            return listOpoint;
        }
        
    }
}
