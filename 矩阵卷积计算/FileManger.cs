using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace 矩阵卷积计算
{
    class FileManger
    {
        //读取数据
        public static double[,] DataReader(string path)
        {
            //
            List<string[]> listLines = new List<string[]>();
            StreamReader sr = new StreamReader(path);
            string line = null;
           
            while(sr.Peek() != -1)
            {
                line = sr.ReadLine();
                string[] lines = line.Split('	');
                listLines.Add(lines);
            }
            sr.Close();
            int row = 0, column = 0;
            if (listLines.Count > 0)
            {
                 row = listLines.Count;
                 column = listLines[0].Length;
            }
            double[,] matrix = new double[row , column];
            try
            {
                for (int i = 0; i < listLines.Count; i++)
                {
                    for (int t = 0; t < listLines[i].Length; t++)
                    {
                        matrix[i, t] = Convert.ToDouble(listLines[i][t]);
                    }
                }

                return matrix;
            }
            catch
            {
                return null; 
            }
        }

        //保存为文件
        public static void Save(string txt , string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(txt);
            sw.Close();
        }

    }
}
