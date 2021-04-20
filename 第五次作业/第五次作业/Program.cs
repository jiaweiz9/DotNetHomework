using System;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService myOrderService = new OrderService();
            myOrderService.AddOrder("1000");
            myOrderService.orders[0].AddDetail("手机", 1, 2000);
            myOrderService.orders[0].AddDetail("手机壳", 3, 50);

            myOrderService.AddOrder("1001");
            myOrderService.orders[1].AddDetail("牛奶", 20, 5);
            myOrderService.orders[1].AddDetail("鸡蛋", 30, 3.5);

            myOrderService.AddOrder("1002");
            myOrderService.orders[2].AddDetail("衣服", 3, 200);
            myOrderService.orders[2].AddDetail("鞋", 2, 400);

            Console.WriteLine(myOrderService);

            foreach (Order ord in myOrderService.SearchByNumber("1000"))
            { 
            foreach(OrderDetail det in ord.orderDetails)
                {
                    Console.WriteLine(det.commodityName+"\t"+det.count+"\t"+det.unitPrice);
                }
                Console.WriteLine($"No.{ord.number} Time:{ord.OrderTime()} Total:{ord.totalPrice}");
            }

            myOrderService.Export();
            myOrderService.Inport();
        }
    }
}
