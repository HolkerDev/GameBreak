using GB.Data.Repositories;
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
    }
}
