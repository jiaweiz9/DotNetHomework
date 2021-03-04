using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            double value1 = 0;
            double value2 = 0;
            double  result = 0;
            double.TryParse(textBox1.Text, out value1);
            double.TryParse(textBox2.Text, out value2);

            result = value1 + value2;

            textBox3.Text = result.ToString();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            double value1 = 0;
            double value2 = 0;
            double result = 0;
            double.TryParse(textBox1.Text, out value1);
            double.TryParse(textBox2.Text, out value2);

            result = value1 - value2;

            textBox3.Text = result.ToString();
        }

        private void multiButton_Click(object sender, EventArgs e)
        {
            double value1 = 0;
            double value2 = 0;
            double result = 0;
            double.TryParse(textBox1.Text, out value1);
            double.TryParse(textBox2.Text, out value2);

            result = value1 * value2;

            textBox3.Text = result.ToString();
        }

        private void divButton_Click(object sender, EventArgs e)
        {
            double value1 = 0;
            double value2 = 0;
            double result = 0;
            double.TryParse(textBox1.Text, out value1);
            double.TryParse(textBox2.Text, out value2);

            result = value1 / value2;

            textBox3.Text = result.ToString();
        }
    }
}
