using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 轨迹数据压缩算法实现
{
    public partial class Form1 : Form
    {
        Trail tra;
        public Form1()
        {
            InitializeComponent();
        }

        private void OPenbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "选择一个文本文件";
            of.Filter = "文本文件(.txt)|*.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string str = "";
               tra = new Trail(FileHelp.DataReader(of.FileName));
                foreach(var t in tra.lisData)
                {
                    str += t.ToString();
                }
                Rtxt.Text = str;
            }

        }

        private void Calbtn_Click(object sender, EventArgs e)
        {
            if(tra.lisData != null)
            {
                
                Rtxt.Text += "\r\n压缩后的数据(5.0):\r\n";
                foreach(var t in tra.StartZip(5.0))
                {
                   
                    Rtxt.Text += t.ToString();
                }

                Rtxt.Text += "\r\n压缩后的数据(8.0):\r\n";
                foreach (var t in tra.StartZip(8.0))
                {

                    Rtxt.Text += t.ToString();
                }

            }
        }
    }
}
