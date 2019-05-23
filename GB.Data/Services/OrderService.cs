using GB.Data.Dto;
using GB.Data.Repositories;
using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface IOrderService
    {

    }

    public class OrderService : IOrderService
    {
        private OrderRepository orderRepository;
        public OrderService(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order AddOrder( OrderDto ord)
        {
            Order order = orderRepository.AddOrder(ord);
            return order;
        }

        public List<OrderDto> GetUserOrders(int userID)
        {
            return orderRepository.GetUserOrders(userID);
        }

        public OrderDto Get(int orderID)
        {
            return orderRepository.Get(orderID);
        }

        public List<OrderDto> GetAll()
        {
            return orderRepository.GetAll();
        }

        public List<OrderDto> GetOrdersWithPenalties()
        {
            return orderRepository.GetOrdersWithPenalties();
        }

        
    }
}
