using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 矩阵卷积计算
{
    public partial class Form1 : Form
    {
        double[,] M;
        double[,] N;

        public Form1()
        {
            InitializeComponent();
            M = null;
            N = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        //打开M矩阵
        private void OpenMBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            of.Title = "选择一个文本文件";
            if (of.ShowDialog() == DialogResult.OK)
            {
                M = FileManger.DataReader(of.FileName);
            }
            of.Dispose();
            ReportTbx.Text = "矩阵M:\r\n";
            ReportTbx.Text += JUZhen.MatrixToString(M);
        }
        //打开N矩阵
        private void OpenNBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";//filter中不能有空格，否则会无法选择文件
            if (of.ShowDialog() == DialogResult.OK)
            {
                N = FileManger.DataReader(of.FileName);
            }
            of.Dispose();
            ReportTbx.Text = "矩阵N:\r\n";
            ReportTbx.Text += JUZhen.MatrixToString(N);
        }
        //计算
        private void CalBtn_Click(object sender, EventArgs e)
        {
            double[,] res1, res2;
            if( N != null && M != null)
            {
                res1 = JUZhen.JuanJi1(N , M);
                res2 = JUZhen.JuanJi2(N, M);
                string strtmp = "算法结果1\r\n";
                strtmp += JUZhen.MatrixToString(res1);
                strtmp += "算法结果2\r\n";
                strtmp += JUZhen.MatrixToString(res2);
                ReportTbx.Text = strtmp;
            }
            else
            {
                MessageBox.Show("请选择M和N矩阵！");
            }
        }
        //保存文件
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本文件(*.txt) | *.txt | 所有文件(*.*) | *.* ";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileManger.Save(ReportTbx.Text, sf.FileName);
            }
          
        }
    }
}
