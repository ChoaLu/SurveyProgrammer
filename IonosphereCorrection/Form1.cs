using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IonosphereCorrection
{
    public partial class Form1 : Form
    {
        CorrctionManger cm;
        public Form1()
        {
            InitializeComponent();
            cm = new CorrctionManger(); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //读取测站信息
           cm.cpoint = FileHelp.CeReader("C:/Users/acer/Desktop/work/开发/c#/测量程序设计/IonosphereCorrection/bin/Debug/测站信息.txt");
            Rtxt.Text += cm.cpoint.ToString();
        }
        private void FileOpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog sf = new OpenFileDialog();
            sf.Title = "打开一个文本文件！";
            sf.Filter = "文本文件(.txt)|*.txt";
            if (sf.ShowDialog() == DialogResult.OK)
            {
               cm.lisOpoint = FileHelp.DataReader(sf.FileName);//计算
            }
            //调试完之后记得dispose
        }

        private void Calbtn_Click(object sender, EventArgs e)
        {
            Rtxt.Text = "";
            foreach (var t in cm.lisOpoint)
            {
                if(t.E >= 0)
                Rtxt.Text += t.ToString();
            }
             
        }
        
    }

}
