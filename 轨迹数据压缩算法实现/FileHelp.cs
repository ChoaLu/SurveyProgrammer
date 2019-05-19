using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 轨迹数据压缩算法实现
{
    class FileHelp
    {
        public static List<point> DataReader(string path)
        {
            List<point> lisp = new List<point>();
            StreamReader sr = new StreamReader(path);
            string[] aline;
            while (sr.Peek() != -1)
            {
                try
                {
                    aline = sr.ReadLine().Split(',');
                    lisp.Add(new point(aline[0], aline[1], aline[2]));
                }
                catch
                {
                    continue;
                }
            }
            return lisp;
        }

    }
}
