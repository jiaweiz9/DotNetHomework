using System;
using System.Collections.Generic;
using System.Linq;
namespace Order
{
	public class OrderService
	{
		public List<Order> orders;
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
			orders.Add(newOrder);
		}

		public void RemoveOrder(string number)//删除订单
		{
			foreach (Order ord in orders)
				if (ord.number == number) orders.Remove(ord);
			//catch { Console.WriteLine($"Can not find {number}"); }
		}
		public override string ToString()                 //查看所有订单
		{
			string result = "";
			foreach (Order ord in orders)
				result = result + ord.number + "\t" + ord.OrderTime() + "\n";
			return result;
		}

		public void AmendOrder(string oldNum, string newNum) //修改订单
		{
			try
			{
				foreach (Order ord in orders)
					if (ord.number == oldNum) ord.number = newNum;
			}
			catch { Console.WriteLine($"Can not find {oldNum}"); }
		}

		public void SortByNumber()  //按照订单号排序
		{
			orders.Sort();
		}

		public List<Order> SearchByNumber(string number) //按照订单号查找
		{
			var result = from s in orders
						 where s.number == number
						 orderby s.totalPrice
						 select s;
			return result.ToList();
		}
		public List<string> SearchByName(string name)  //按照商品名称查找
        {
			List<string> resultOrders = new List<string>();

			foreach (Order ord in orders)
			{
				var aResult = from s in ord.orderDetails
							 where s.commodityName == name
							 select s.InWhichOrder;
				resultOrders.AddRange(aResult.ToList());
			}
			return resultOrders;
        }

		public List<Order> SearchByPrice(int price)  //按照订单金额查找
		{
			var result = from s in orders
						 where s.totalPrice ==price
						 select s;
			return result.ToList();
		}
	}
}
