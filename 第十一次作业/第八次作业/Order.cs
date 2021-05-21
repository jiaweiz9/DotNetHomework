using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace 第八次作业{

	[Serializable]
	public class Order:IComparable
	{
		public List<OrderDetail> orderDetails;

		public List<OrderDetail> OrderDetails {
			get
			{
				using (var ctx = new OrderContext())
				{
					return ctx.OrderDetails.Where(b=>b.OrderId == this.OrderId).
					  ToList<OrderDetail>();
				}
			}
		}
		public int countOfSort { get; set; } //商品种类数
		public double totalPrice { get; set; }  //总价
		public string OrderId { get; set; } //订单号----主键
		public DateTime time { get; set; } //下单时间
		public string Client { get; set; }
		public Order(string number)
		{
			orderDetails = new List<OrderDetail>();
			countOfSort = 0;
			totalPrice = 0;
			this.OrderId = number;
			Client = "Zhang";
			time = DateTime.Now;
		}
		public Order()
        {
			orderDetails = new List<OrderDetail>();
			countOfSort = 0;
			totalPrice = 0;
			this.OrderId = "0000";
			time = DateTime.Now;
		}
		public bool CalTotal()
		{
			totalPrice = 0;
			if (orderDetails.Count != 0)
			{
				foreach (OrderDetail s in OrderDetails)
				{
					totalPrice += s.unitPrice * s.count;
				}
				return true;
			}
			else return false;
		}
		public DateTime OrderTime()    //展示订单时间
		{ return time; }

		public void AddDetail(string newName, int newCount, double newPrice) //增加新的商品
		{
			OrderDetail newDetail = new OrderDetail(newName,newCount,newPrice);
			/*try
			{
				foreach (OrderDetail det in orderDetails)
				{
					if (det.Equals(newDetail)) throw new ApplicationException();
					//orders.Add(newOrder);
				}
			}
			catch { Console.WriteLine($"{newName} has already existed"); }
			orderDetails.Add(newDetail);*/
			newDetail.OrderId = this.OrderId;
			countOfSort++;
			totalPrice = totalPrice + newCount * newPrice;

			using (var ctx = new OrderContext())
            {
				ctx.Entry(newDetail).State = EntityState.Added;
				ctx.SaveChanges();
			}
		}

		public void RemoveDetail(string nam)  //删除商品
		{
			/*OrderDetail removeDetail = new OrderDetail();
			foreach (OrderDetail det in orderDetails)
				if (det.OrderDetailId == nam) removeDetail = det;
			orderDetails.Remove(removeDetail);*/
			using (var ctx = new OrderContext()) 
			{
				var orderDetal = ctx.OrderDetails.FirstOrDefault(p => p.OrderDetailId == nam);
				if (orderDetal != null)
					ctx.OrderDetails.Remove(orderDetal);
				ctx.SaveChanges();
			}
		}

        public override string ToString()
        {
			string result = OrderId+"\t"+time+"\n";
			foreach (OrderDetail det in orderDetails)
				result = result + det.ToString()+"\n";
            return result;
        }

		public int CompareTo(object obj)
		{
			Order ord = obj as Order;
			if (ord == null)
				throw new System.ArgumentException();
			return this.OrderId.CompareTo(ord.OrderId);
		}

		public override bool Equals(object obj) 
        {
			var order = obj as Order;
			return order != null && OrderId == order.OrderId;
		}
        public override int GetHashCode()
        {
            return OrderId.GetHashCode();
        }

    }
}
