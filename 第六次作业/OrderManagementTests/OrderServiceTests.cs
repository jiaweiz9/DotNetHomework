using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {

        [TestMethod()]
        public void AddOrderTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.RemoveOrder("111");

        }

        [TestMethod()]
        public void ToStringTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.AddOrder("222");
            orderService.ToString();
        }

        [TestMethod()]
        public void AmendOrderTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.AmendOrder("111", "222");
        }

        [TestMethod()]
        public void SortByNumberTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.AddOrder("222");
            orderService.SortByNumber();
        }

        [TestMethod()]
        public void SearchByNumberTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.AddOrder("222");
            orderService.SearchByNumber("111");

        }

        [TestMethod()]
        public void SearchByNameTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.AddOrder("222");
            orderService.orders[0].AddDetail("鸡蛋", 10, 1);
            orderService.orders[0].AddDetail("牛奶", 5, 3);
            orderService.orders[1].AddDetail("鸡蛋", 20, 1);
            orderService.orders[1].AddDetail("面包", 5, 2);

        }

        [TestMethod()]
        public void SearchByPriceTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.AddOrder("222");
            orderService.orders[0].AddDetail("鸡蛋", 10, 1);
            orderService.orders[0].AddDetail("牛奶", 5, 3);
            orderService.orders[1].AddDetail("鸡蛋", 20, 1);
            orderService.orders[1].AddDetail("面包", 5, 2);
            orderService.SearchByPrice(20);
        }

        [TestMethod()]
        public void ExportTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.orders[0].AddDetail("鸡蛋", 10, 1);
            orderService.orders[0].AddDetail("牛奶", 5, 3);
            orderService.Export();
        }

        [TestMethod()]
        public void InportTest()
        {
            //ssert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.orders[0].AddDetail("鸡蛋", 10, 1);
            orderService.orders[0].AddDetail("牛奶", 5, 3);
            orderService.Export();
            orderService.Inport();
        }
    }
}