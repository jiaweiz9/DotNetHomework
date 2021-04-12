using System;
using System.Collections.Generic;
namespace Order{

	[Serializable]
	public class Order:IComparable
	{
		public List<OrderDetail> orderDetails;
		public int countOfSort { get; set; } //商品种类数
		public double totalPrice { get; set; }  
		public string number { get; set; }
		private DateTime time;
		public Order(string number)
		{
			orderDetails = new List<OrderDetail>();
			countOfSort = 0;
			totalPrice = 0;
			this.number = number;
			time = DateTime.Now;
		}
		public Order()
        {
			orderDetails = new List<OrderDetail>();
			countOfSort = 0;
			totalPrice = 0;
			this.number = "0000";
			time = DateTime.Now;
		}
		public DateTime OrderTime()    //展示订单时间
		{ return time; }

		public void AddDetail(string newName, int newCount, double newPrice) //增加新的商品
		{
			OrderDetail newDetail = new OrderDetail(newName,newCount,newPrice);
			try
			{
				foreach (OrderDetail det in orderDetails)
				{
					if (det.Equals(newDetail)) throw new ApplicationException();
					//orders.Add(newOrder);
				}
			}
			catch { Console.WriteLine($"{newName} has already existed"); }
			orderDetails.Add(newDetail);
			newDetail.InWhichOrder = this.number;
			countOfSort++;
			totalPrice = totalPrice + newCount * newPrice;
		}

		public void RemoveDetail(string nam)  //删除商品
		{
			foreach (OrderDetail det in orderDetails)
				if (det.commodityName == nam) orderDetails.Remove(det);
		}

        public override string ToString()
        {
			string result = number+"\t"+time+"\n";
			foreach (OrderDetail det in orderDetails)
				result = result + det.ToString()+"\n";
            return result;
        }

		public int CompareTo(object obj)
		{
			Order ord = obj as Order;
			if (ord == null)
				throw new System.ArgumentException();
			return this.number.CompareTo(ord.number);
		}

		public override bool Equals(object obj) 
        {
			var order = obj as Order;
			return order != null && number == order.number;
		}
        public override int GetHashCode()
        {
            return number.GetHashCode();
        }

    }
}
