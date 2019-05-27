using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB.Data.DAL;
using GB.Data.Dto;
using GB.Data.Repositories;
using GB.Entities.Models;

namespace GB.Data.Test
{
    /// <summary>
    /// Summary description for OrderTest
    /// </summary>
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void AddOrder()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                OrderDto order = new OrderDto()
                {
                    CreatedAt = DateTime.Now,
                    ExpiresAt = DateTime.Now,
                    IsFinishedAt = null,
                    TotalPrice = 100,
                    UserID = 1
                };

                OrderRepository orderRepository = new OrderRepository(context);
                Order orderDb = orderRepository.AddOrder(order);

                Assert.AreEqual(order.TotalPrice, orderDb.TotalPrice);
            };
        }

        [TestMethod]
        public void GetOrder()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                OrderRepository orderRepository = new OrderRepository(context);
                OrderDto orderDb = orderRepository.Get(5);
                Assert.AreEqual(100, orderDb.TotalPrice);
            };
        }
    }
}
