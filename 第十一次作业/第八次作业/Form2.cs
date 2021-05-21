using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 第八次作业
{
    public partial class Form2 : Form
    {
        Form3 form3;
        Order bindingOrder;
        public Form2()
        {
            InitializeComponent();
            //btnDelDetail.Click += new System.EventHandler(this.btnDelDetail_Click);
            form3 = new Form3();
            
        }

        public void getBindingOrder(Order order)
        {
            bindingOrder = order;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            form3.ShowDialog();
            if (form3.DialogResult == DialogResult.OK)
            {
                int y;
                double z;
                int.TryParse(form3.textBox_count.Text, out y);
                double.TryParse(form3.textBox_price.Text, out z);
                bindingOrder.AddDetail(form3.textBox_name.Text, y, z);
                orderDetailBindingSource.DataSource = bindingOrder.OrderDetails;
                orderDetailBindingSource.ResetBindings(false);
            }
        }

        private void btnDelDetail_Click(object sender, EventArgs e)
        {
            OrderDetail removeDetail = new OrderDetail();
            //string removeDetailName;
            removeDetail = (OrderDetail)orderDetailBindingSource.Current;
            bindingOrder.RemoveDetail(removeDetail.OrderDetailId);
            orderDetailBindingSource.DataSource = bindingOrder.OrderDetails;
            orderDetailBindingSource.ResetBindings(false);
        }
    }
}
