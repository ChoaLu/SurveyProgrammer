using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace 短路径计算
{
    class TuLIne
    {
        Dictionary<string , int> DicNames;
        double[,] AdjMat;
        List<double> lisLength;//存储起点到各点的距离
        List<int> LisFo ;//已经求出最短路径的点

        public TuLIne(string path)
        {
            DicNames = new Dictionary<string , int >(); ;
            AdjMat = null;
            lisLength = new List<double>();
            LisFo = new List<int>();
            NameReader(path);
            MatInit(path);

        }

        //读取所有的地名
        public void NameReader(string path)
        {
            StreamReader sr = new StreamReader(path);
            string strtemp = "";
            int nameIndex = 0;
            while(sr.Peek () != -1)
            {
                strtemp = sr.ReadLine().Split(',')[0];
                int index = 0;
                if (!DicNames.TryGetValue(strtemp ,out index))
                {
                    DicNames.Add(strtemp , nameIndex++);
                }
            }
            sr.Close();
        }

        public void MatInit(string path)
        {
            AdjMat = new double[DicNames.Count , DicNames.Count];
            for(int t = 0; t < DicNames.Count; t++)
            {
                for(int w = 0; w < DicNames.Count; w++)
                {
                    if(t == w)
                    {
                        AdjMat[w, t] = 0;
                        continue;
                    }
                    AdjMat[t, w] = Double.MaxValue;
                }
            }
            StreamReader sr = new StreamReader(path);
            string[] StrLine = new string[3];
            int i, j;
            //初始化邻接矩阵
            while (sr.Peek() != -1)
            {
                try {
                    StrLine = sr.ReadLine().Split(',');
                    DicNames.TryGetValue(StrLine[0], out i);//入
                    DicNames.TryGetValue(StrLine[1], out j);//出
                    AdjMat[i, j] = Convert.ToDouble(StrLine[2]);
                }
                catch
                {
                    Console.WriteLine("文件的格式可能有问题！");
                }
            }
            sr.Close();          
        }

        //计算最短路径
        //用邻接矩阵来实现 
        public void ShortMat2()
        {
            for(int i = 0; i < DicNames.Count-1; i++)
            {
                double minvalue = Double.MaxValue;
                
                //求出第一个未求出最短路路径的点号
                int minj = 0;
                for(int j = 0; j < DicNames.Count; j++)
                {
                    if (!LisFo.Contains(j) && j != 0)
                    {
                        if(minvalue >= AdjMat[0 , j])
                        {                           
                            minvalue = AdjMat[0, j];
                            minj = j;
                        }
                    }
                }
                lisLength.Add(minvalue);            
                LisFo.Add(minj);
                //找出最短路径

                for(int t = 0; t < DicNames.Count; t ++)
                {
                    if (!LisFo.Contains(t)) {
                        if (AdjMat[0 , t]!= 0 && minvalue + AdjMat[minj, t] < AdjMat[0, t])
                        {
                            AdjMat[0, t] = minvalue + AdjMat[minj, t];
                        }
                    }
                }
                //修正未求得最短路径的点的距离
            }
            
        }


        //输出计算结果
        public string OutPut()
        {
            string res = ""; 
            if(LisFo.Count > 0)
            {
                for(int i = 0; i < LisFo.Count; i++)
                {
                    foreach(var t in DicNames)
                    {
                        if(t.Value == LisFo[i])
                        {
                            res += String.Format("\r\n{0}:  {1}" ,t.Key ,lisLength[i]);
                            break;
                        }
                    } 
                }
            }
            return res;
        }

        //输出矩阵
        public override string   ToString()
        {
            string str = "";
            for(int i = 0; i < AdjMat.GetLength(0); i++)
            {
                for (int j = 0; j < AdjMat.Length / AdjMat.GetLength(0); j++)
                {
                    if (AdjMat[i, j] == Double.MaxValue)
                    {
                        str += String.Format("{0,-7}", "NaN");
                    }
                    else
                    {
                        str +=String.Format("{0,-7}" , AdjMat[i, j].ToString());
                    }
                }
                str += "\r\n";
            }
            return str;
        }
    }
}
