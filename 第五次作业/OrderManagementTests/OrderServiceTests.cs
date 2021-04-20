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
            Assert.IsNotNull(orderService);
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.RemoveOrder("111");
            Assert.IsNull(orderService);

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
            OrderService orderService2 = new OrderService();
            orderService2.AddOrder("222");
            Assert.AreEqual(orderService, orderService2);
        }

        [TestMethod()]
        public void SortByNumberTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("101");
            orderService.AddOrder("100");
            orderService.SortByNumber();
            OrderService orderService2 = new OrderService();
            orderService2.AddOrder("100");
            orderService2.AddOrder("101");
            Assert.AreEqual(orderService, orderService2);
        }

        [TestMethod()]
        public void SearchByNumberTest()
        {
            //Assert.Fail();
            OrderService orderService = new OrderService();
            orderService.AddOrder("111");
            orderService.AddOrder("222");
            List<Order> orders=orderService.SearchByNumber("111");
            List<Order> orderTest = new List<Order>();
            Order order = new Order("111");
            orderTest.Add(order);
            Assert.AreEqual(orders, orderTest);
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
            List<string> names = orderService.SearchByName("牛奶");
            List<string> testName = new List<string>();
            testName.Add("111");
            Assert.AreEqual(names, testName);
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

            List<Order> orders = orderService.SearchByPrice(20);
            List<Order> testOrders = new List<Order>();
            testOrders.Add(orderService.orders[0]);
            testOrders.Add(orderService.orders[1]);
            Assert.AreEqual(orders, testOrders);
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