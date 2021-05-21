using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.Entity;
using System.Xml.Serialization;

namespace 第八次作业
{
	public class OrderService
	{
		public List<Order> orders;

		public List<Order> Orders
		{
			get
			{
				using (var ctx = new OrderContext())
				{
					return ctx.Orders.Include(o => o.OrderDetails).
					  ToList<Order>();
				}
			}
		}
		public OrderService()
		{
			orders = new List<Order>();
			
		}
		public void AddOrder(string number)
		{   //添加订单
			Order newOrder = new Order(number);
			try
			{
				foreach (Order ord in orders)
				{
					if (ord.Equals(newOrder)) throw new ApplicationException();
					//orders.Add(newOrder);
				}
			}
			catch { Console.WriteLine($"{number} has already existed"); }
			//orders.Add(newOrder);
			using (var ctx = new OrderContext())
			{
				ctx.Entry(newOrder).State = EntityState.Added;
				ctx.SaveChanges();
			}
		}

		public void RemoveOrder(string number)//删除订单
		{
			//Order removeOrder = new Order();
			//foreach (Order ord in orders)
			//if (ord.OrderId == number) removeOrder = ord;
			//orders.Remove(removeOrder);
			//catch { Console.WriteLine($"Can not find {number}"); }
			using (var ctx = new OrderContext())
			{
				var order = ctx.Orders.Include("OrderDetails").SingleOrDefault(o => o.OrderId == number);
				if (order == null) return;
				ctx.OrderDetails.RemoveRange(order.OrderDetails);
				ctx.Orders.Remove(order);
				ctx.SaveChanges();
			}
			}
		public override string ToString()                 //查看所有订单
		{
			string result = "";
			foreach (Order ord in orders)
				result = result + ord.OrderId + "\t" + ord.OrderTime() + "\n";
			return result;
		}

		public void AmendOrder(string oldNum, string newNum) //修改订单
		{
			try
			{
				foreach (Order ord in orders)
					if (ord.OrderId == oldNum) ord.OrderId = newNum;
			}
			catch { Console.WriteLine($"Can not find {oldNum}"); }
		}

		public void SortByNumber()  //按照订单号排序
		{
			Orders.Sort();
		}

		public List<Order> SearchByNumber(string number) //按照订单号查找
		{
			using (var ctx = new OrderContext())
			{
				var result = from s in ctx.Orders
							 where s.OrderId == number
							 orderby s.totalPrice
							 select s;
				return result.ToList();
			}
		}
		public List<string> SearchByName(string name)  //按照商品名称查找
        {
			List<string> resultOrders = new List<string>();
			using (var ctx = new OrderContext())
			{
				foreach (Order ord in ctx.Orders)
				{
					var aResult = from s in ord.OrderDetails
								  where s.OrderDetailId == name
								  select s.OrderId;
					resultOrders.AddRange(aResult.ToList());
				}
				return resultOrders;
			}
        }

		public List<Order> SearchByPrice(double price)  //按照订单金额查找
		{
			using (var ctx = new OrderContext())
			{
				var result = from s in ctx.Orders
							 where s.totalPrice <= price
							 select s;
				return result.ToList();
			}
		}

		public void Export()
		{ XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
			using (FileStream fs = new FileStream("orders.xml", FileMode.Create))
            {
				xmlSerializer.Serialize(fs, Orders);
				Console.WriteLine("Orders have serialized as XML:");
			}
			Console.WriteLine(File.ReadAllText("orders.xml"));
			
		}

		public void Inport()
		{ XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
			using (FileStream fs = new FileStream("orders.xml", FileMode.Open))
            {
				List<Order> orders2 = (List<Order>)xmlSerializer.Deserialize(fs);
				Console.WriteLine("Orders have deserialized from xml:");
				foreach(Order ord in orders2)
				{ Console.WriteLine(ord); }
			}
			
		}
	}
}
