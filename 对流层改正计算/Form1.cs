using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace 对流层改正计算
{
    public partial class f : Form
    {
        List<OPoint> lisOpooint = new List<OPoint>();
        public f()
        {
            InitializeComponent();
        }

         

        private void FileBtn_Click(object sender, EventArgs e)
        {
            var of = new OpenFileDialog();
            of.Title = "选择一个txt文件";
            of.Filter = "文本文件(.txt)|*.txt";
            if(of.ShowDialog() == DialogResult.OK)
            {
                lisOpooint = FileHelp.DataReader(of.FileName);
                rxtx.Text = "";
                string temp = "ID      时间            经度           纬度           正高       高度角";
                foreach (var t in lisOpooint)
                {
                     
                    temp += string.Format("\r\n{0}   {1}      {2,-10}      {3,-10}      {4:000.000}       {5}",t.Id ,t.time.ToString("d") , t.B , t.L , t.H , t.El);
                }
                rxtx.Text += temp;
            }
            else
            {
                MessageBox.Show("已取消");
            }
            
        }

        private void calbtnn_Click(object sender, EventArgs e)
        {

            if (lisOpooint.Count < 1)
            {
                MessageBox.Show("请选择数据文件");
                return;
            }
            rxtx.Text = "";
            string temp = "ID      高度角     ZHD     m_d(E)      ZWD     m_w(E)      改成延迟";
            foreach (var t in lisOpooint)
            {

                temp += string.Format("\r\n{0}   {1,-5}       {2,-5}     {3,-5}    {4,-5}      {5,-5}       {6,-5}", t.Id, t.El,Math.Round(t.ZHD , 3),Math.Round(t.Md , 3)
                    ,Math.Round(t.ZWD , 3),Math.Round(t.Mw , 3) ,Math.Round(t.DS , 3));
            }
            rxtx.Text += temp;
        }
    }
}
