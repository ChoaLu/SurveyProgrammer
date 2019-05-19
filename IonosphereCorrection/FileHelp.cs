using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IonosphereCorrection
{
    class FileHelp
    {
        //读取卫星坐标信息
        public static List<OPoint> DataReader(string path)
        {
            StreamReader sr = new StreamReader(path);

            List<OPoint> lisOpoint = new List<OPoint>();
            string[] strLine = new string[4];
            
            while(sr.Peek () != -1)
            {
                try
                {
                    strLine = sr.ReadLine().Split(new char[]{ ' '} , StringSplitOptions.RemoveEmptyEntries);
                    lisOpoint.Add(new OPoint(strLine[0] , strLine[1] , strLine[2] , strLine[3]));
                }
                catch
                {
                    continue;
                }
            }
            return lisOpoint;
        }

        //读取测站信息
        public static CePoint CeReader(string path)
        {
            StreamReader sr = new StreamReader(path);
            try
            {
                Time dt = null; 
                if (sr.Peek()== '*')
                {
                    string[] str = sr.ReadLine().Split(new char[] { ' ' } , StringSplitOptions.RemoveEmptyEntries);
                    int year = Convert.ToInt32(str[1]);
                    int month = Convert.ToInt32(str[2]);
                    int day = Convert.ToInt32(str[3]);
                    int hour = Convert.ToInt32(str[4]);
                    int minut = Convert.ToInt32(str[5]);
                    double second = Convert.ToDouble(str[6]);
                    dt = new Time(year, month, day, hour, minut, second);
                }
                string[] line = sr.ReadLine().Split(',');
                double x = Convert.ToDouble(line[0]);
                double y = Convert.ToDouble(line[1]);
                double z = Convert.ToDouble(line[2]);
                
                line = sr.ReadLine().Split(',');
                double a = Convert.ToDouble(line[0]);
                double e = Convert.ToDouble(line[1]);
                sr.Dispose();
                return new CePoint(x , y , z, a , e , dt);
            }
            catch(Exception e)
            {
                string str = e.Message;
                //sr.Dispose();
                throw new Exception("文件的格式有误！");
            }
        }
    }
}
