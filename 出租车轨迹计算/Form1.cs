using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 出租车轨迹
{
    public partial class Form1 : Form
    {
        DataManger DataM;
        public Form1()
        {
            InitializeComponent();
            DataM = new DataManger();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            of.Title = "选择一个文本文件";
            if (of.ShowDialog() == DialogResult.OK)
            {
                DataM.DataReader(of.FileName);
            }
            of.Dispose();
        }

        private void Cal_Click(object sender, EventArgs e)
        {
            // ReportText.Text = DataM.ToString();
            ReportText.Text += BasicClass.DMS2RAD(179.59599999) + "\r\n";
            ReportText.Text += BasicClass.Dms2Rad(179.59599999);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if(sf.ShowDialog() == DialogResult.OK)
            {
                DataM.SaveReport(sf.ToString());
            }
            sf.Dispose();
        }
    }
}
