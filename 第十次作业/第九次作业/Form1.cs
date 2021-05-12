using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 第九次作业
{
    public partial class Form1 : Form
    {
        static string labelText = "";
        Crawler crawler = new Crawler();
        public delegate void SetLabelText(string text);
        public SetLabelText set;
        public Form1()
        {
            InitializeComponent();
            crawler.WriteMessageToLabel += new Crawler.MessageWrite(this.LabelMessageRefresh);
            set += setText;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string startUrl = textBox1.Text;
            if (!startUrl.Contains("http"))
            {
                labelText += "Address error!\n";
                label2.Text = labelText;
            }
            else crawler.StartUrl(startUrl);
            Thread thread = new Thread(crawler.Crawl);
            thread.IsBackground = true;
            //crawler.Crawl();
            thread.Start();
        }

        private void LabelMessageRefresh()
        {
            if (label2.InvokeRequired)
            {
                label2.Invoke(set, crawler.text);
            }
        }

        public void setText(string text)
        {
            label2.Text = text;
        }
    }
}
