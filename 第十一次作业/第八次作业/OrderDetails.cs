using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace 第八次作业{

	public class OrderDetail
	{
		
		public string OrderDetailId { get; set; } // 商品名----主键
		public int count { get; set; }   // 商品数量
		public double unitPrice { get; set; }  
		public double totalPrice { get; set; }
		public string OrderId { get; set; } //所在的订单序号----外键
		public OrderDetail(string name,int count,double unitPrice)
		{
			OrderDetailId = name;
			this.count = count;
			this.unitPrice = unitPrice;
			this.totalPrice = unitPrice * count;
		}
		public OrderDetail()
		{
			OrderDetailId = "";
			this.count = 0;
			this.unitPrice = 0;
			this.totalPrice = 0;
		}

        public override string ToString()
        {
            return OrderDetailId+"\t"+count+"\t"+unitPrice;
        }
        public override bool Equals(object obj)
        {   var detail = obj as OrderDetail;
			return detail != null && OrderDetailId == detail.OrderDetailId;
		}
        public override int GetHashCode()
        {
            return OrderDetailId.GetHashCode();
        }
    }
}
