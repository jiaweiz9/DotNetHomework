using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 第七次作业
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            radioButton5.Checked = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
          
        }
        void drawCayleyTree(int n, double x0, double y0, double leng, double th, double per1,double per2,double th1,double th2)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1,per1, per2, th1, th2);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2, per1, per2, th1, th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {

            if(radioButton1.Checked)
            graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
           else if(radioButton2.Checked)
                graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
            else if(radioButton3.Checked)
                graphics.DrawLine(Pens.Yellow, (int)x0, (int)y0, (int)x1, (int)y1);
            else if(radioButton4.Checked)
                graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
            else if(radioButton5.Checked)
                graphics.DrawLine(Pens.Pink, (int)x0, (int)y0, (int)x1, (int)y1);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            graphics.Clear(this.BackColor);
            drawCayleyTree(int.Parse(textBox1.Text),  550,  470,  double.Parse(textBox2.Text),  -Math.PI/2,  //递归深度，起始坐标，主干长度，起始角度
                double.Parse(textBox3.Text),double.Parse(textBox4.Text),  //左右长度比例
                double.Parse(textBox5.Text)*Math.PI/180, double.Parse(textBox6.Text)*Math.PI/180);  //左右角度
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
