using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 线性回归模型对卫星轨道进行预测
{
    public partial class Form1 : Form
    {
        AWeiXingGuiDao awx;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            List<AData> listdata = new List<AData>();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "文本文件(.txt)|*.txt|所有文件|*.*";
            of.Title = "请选择要打开的文件";
            if (of.ShowDialog() == DialogResult.OK)
            {
                listdata = FileHelp.DataReader(of.FileName);
            }
            awx = new AWeiXingGuiDao(listdata);

        }

        private void CalBtn_Click(object sender, EventArgs e)
        {
           
            if (awx != null)
            {
                reportTxt.Text += awx.ToString();
            }
        }
    }
}
 