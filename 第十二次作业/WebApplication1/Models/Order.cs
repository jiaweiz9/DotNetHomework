using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace WebApplication1.Models
{
	[Serializable]
	public class Order 
	{
		public List<OrderDetail> orderDetails;

		public List<OrderDetail> OrderDetails
		{
			get; set;
		}
		public int countOfSort { get; set; } //商品种类数
		public double totalPrice { get; set; }  //总价
		public string OrderId { get; set; } //订单号----主键
		public DateTime time { get; set; } //下单时间
		public string Client { get; set; }
	}
	public class OrderDetail
	{

		public string OrderDetailId { get; set; } // 商品名----主键
		public int count { get; set; }   // 商品数量
		public double unitPrice { get; set; }
		public double totalPrice { get; set; }
		public string OrderId { get; set; } //所在的订单序号----外键
	}
}
