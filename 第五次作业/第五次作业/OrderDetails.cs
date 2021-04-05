using System;

namespace Order{

	public class OrderDetail
	{
		public string commodityName { get; set; } // 商品名
		public int count { get; set; }   // 商品数量
		public double unitPrice { get; set; }  
		
		public string InWhichOrder { get; set; }
		public OrderDetail(string name,int count,double unitPrice)
		{
			commodityName = name;
			this.count = count;
			this.unitPrice = unitPrice;
		}

        public override string ToString()
        {
            return commodityName+"\t"+count+"\t"+unitPrice;
        }
        public override bool Equals(object obj)
        {   var detail = obj as OrderDetail;
			return detail != null && commodityName == detail.commodityName;
		}
        public override int GetHashCode()
        {
            return commodityName.GetHashCode();
        }
    }
}
