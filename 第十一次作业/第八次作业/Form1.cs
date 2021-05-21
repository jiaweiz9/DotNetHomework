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
    public partial class Form1 : Form
    {
        public OrderService myOrderService;
        Order currentOrder;
        Form2 form2;
        int n = 0;
        public Form1()
        {
            InitializeComponent();
            myOrderService = new OrderService();
            form2 = new Form2();
           
            sourceOrder.DataSource = myOrderService.Orders;
            
            btnAddOrder.Click += new System.EventHandler(this.BtnAddOrderClicked);
            btnDelOrder.Click += new System.EventHandler(this.BtnDeleteOrderClicked);
            dataGridViewOrder.CellClick += new DataGridViewCellEventHandler(this.RowCliked);
            btnChangeOrder.Click += new EventHandler(this.BtnChangeClicked);
            //form2.btnAddDetail.Click += new EventHandler(this.BtnAddDetailClicked);
            //form2.btnDelDetail.Click += new EventHandler(this.BtnDeleteDetailClicked);
            btnSearch.Click += new EventHandler(this.BtnSearchClicked);
            btnExpOrder.Click += new EventHandler(this.BtnExpOrderClicked);
            btnImpOrder.Click += new EventHandler(this.BtnImpOrderClicked);
        }
        public void BtnSearchClicked(object sender, System.EventArgs e)
        {
            int index;
            if (comboBox1.SelectedIndex == 0)   //按订单号查找
            {
                List<Order> selectedOrder = new List<Order>();
                selectedOrder = myOrderService.SearchByNumber(textBox1.Text);
                index = myOrderService.orders.IndexOf(selectedOrder[0]);
                dataGridViewOrder.Rows[index].Selected = true;
            }
            if (comboBox1.SelectedIndex == 1)   //按商品名查找
            {
                List<string> selectedNumber = new List<string>();
                selectedNumber = myOrderService.SearchByName(textBox1.Text);
                List<Order> selectedOrder = new List<Order>();
                selectedOrder = myOrderService.SearchByNumber(selectedNumber[0]);
                index = myOrderService.orders.IndexOf(selectedOrder[0]);
                dataGridViewOrder.Rows[index].Selected = true;
            }
            if (comboBox1.SelectedIndex == 2)   //按金额查找
            {
                List<Order> selectedOrder = new List<Order>();
                double price;
                double.TryParse(textBox1.Text, out price);
                selectedOrder = myOrderService.SearchByPrice(price);
                index = myOrderService.orders.IndexOf(selectedOrder[0]);
                dataGridViewOrder.Rows[index].Selected = true;
            }
        }
        public void BtnAddOrderClicked(object sender, System.EventArgs e)
        {
            using (var ctx = new OrderContext())
            {
                n = ctx.Orders.Count();
            }
            myOrderService.AddOrder(n.ToString().PadLeft(6,'0'));
            //sourceOrder.Add(myOrderService.orders.Last<Order>());
            sourceOrder.DataSource = myOrderService.Orders;
            sourceOrder.ResetBindings(false);
            n++;
        }
        /*public void BtnAddDetailClicked(object sender, System.EventArgs e)
        {
            //currentOrder.AddDetail("", 0, 0);
            //form2.orderDetailBindingSource.Add(currentOrder.orderDetails.Last<OrderDetail>());
        }*/
        public void BtnDeleteOrderClicked(object sender, System.EventArgs e)
        {
            //dataGridViewOrder.Rows.Remove(dataGridViewOrder.CurrentRow);
            //sourceOrderDetail.Clear();
            string removeOrderNum = currentOrder.OrderId;
            myOrderService.RemoveOrder(removeOrderNum);
            sourceOrder.DataSource = myOrderService.Orders;
            sourceOrder.ResetBindings(false);
        }
        /*public void BtnDeleteDetailClicked(object sender, System.EventArgs e)
        {
            form2.orderDetailBindingSource.Remove(form2.orderDetailBindingSource.Current);
            
        }*/
        public void RowCliked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                currentOrder = (Order)sourceOrder.Current;
                sourceOrderDetail.DataSource =currentOrder.OrderDetails; //form1 sourcedetail绑定orderdetail
                form2.orderDetailBindingSource.DataSource = currentOrder.OrderDetails;//form2 绑定orderdetail
            }
        }
        public void BtnChangeClicked(object sender, System.EventArgs e)
        {
            form2.getBindingOrder(currentOrder);
            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {
                //sourceOrderDetail.DataSource = currentOrder.orderDetails;
                sourceOrderDetail.DataSource = currentOrder.OrderDetails;
                sourceOrderDetail.ResetBindings(false);
                sourceOrder.DataSource = myOrderService.Orders;
                sourceOrder.ResetBindings(currentOrder.CalTotal());
            }
        }
        public void BtnExpOrderClicked(object sender, System.EventArgs e) //导出订单
        {
            myOrderService.Export();
        }
        public void BtnImpOrderClicked(object sender, System.EventArgs e)  //导入订单
        {
            myOrderService.Inport();
        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sourceOrder_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
