using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 矩阵卷积计算
{
    class JUZhen
    {
        //算法1
        public static double[,] JuanJi1(double[,] N , double [,]M)
        {
            int MaxJ = N.GetLength(1);//列数
            int MaxI = N.Length / MaxJ;//行数
            double[,] ResM = new double[MaxJ,MaxI];
            for(int I = 0; I < MaxI; I++)
            {
                for(int J = 0; J < MaxJ; J++)
                {
                    double Md = 0, Nd = 0 ;
                    double fenzi = 0, fenmu = 0;
                    for (int i = 0; i <= 2; i++)
                    {
                        //写的时候没注意到应该是<=2
                        for (int j = 0; j <= 2; j++)
                        {
                            if (I - i - 1 < 0 || J - j - 1 < 0 || 
                                I - i - 1 > MaxI - 1 || J - j - 1 > MaxJ - 1)
                            {
                                break;
                            }
                            Md = M[i, j];
                            Nd = N[I - i - 1, J - j - 1];
                            fenzi += (Md * Nd);
                            fenmu += Md;

                        }

                    }
                    ResM[I, J] = fenzi / fenmu;
                }
            }
                return ResM;
        }


        //算法2
        public static double[,] JuanJi2(double[,] N, double[,] M)
        {
            int MaxJ = N.GetLength(1);//列数
            int MaxI = N.Length / MaxJ;//行数
            double[,] ResM = new double[MaxJ, MaxI];
            for (int I = 0; I < MaxI; I++)
            {
                for (int J = 0; J < MaxJ; J++)
                {
                    double Md = 0, Nd = 0;
                    double fenzi = 0, fenmu = 0;
                    for (int i = 0; i <= 2; i++)
                    {
                        //写的时候没注意到应该是<=2
                        for (int j = 0; j <= 2; j++)
                        {
                            if (I - i - 1 < 0 || J - j - 1 < 0 
                                || I - i - 1 > MaxI - 1 || J - j - 1 > MaxJ - 1)
                            {
                                break;
                            }
                            Md = M[i, j];
                            Nd = N[9-(I - i - 1),9-(J - j - 1)];
                            fenzi += (Md * Nd);
                            fenmu += Md;
                        }

                    }
                    ResM[I, J] = fenzi / fenmu;
                }
            }
            return ResM;
        }

        public static string MatrixToString(double[,] matrix)
        {
            string strmat = "";
            int I = 0, J = 0;
            if (matrix.Length > 0 && matrix != null)
            {
                I = matrix.GetLength(0);
                J = matrix.Length / I;

                for(int i = 0; i < I; i++)
                {
                    
                    for (int j = 0; j < J; j++)
                    {
                        strmat +=string.Format("{0:F1}  ", matrix[i , j]);
                    }
                    strmat += "\r\n";
                }
            }
            else
            {
                return null;
            }

            return strmat;
        }

    }
}
