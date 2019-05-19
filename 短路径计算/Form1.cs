using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 短路径计算
{
    public partial class Form1 : Form
    {
        TuLIne tl;
        public Form1()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog sf = new OpenFileDialog();
            sf.Filter = "文本文件(*.txt)|*.txt";
            sf.Title = "选择路径文件！";
            if(sf.ShowDialog() == DialogResult.OK)
            {
                tl = new TuLIne(sf.FileName);
                textBox1.Text += "输入的矩阵:\r\n";
                textBox1.Text = tl.ToString();
                textBox1.Text += "\r\n";
               
            }
            
        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tl != null)
            {
                tl.ShortMat2();
                textBox1.Text += "计算结果:";
                textBox1.Text += tl.OutPut();
            }
        }
    }
}
