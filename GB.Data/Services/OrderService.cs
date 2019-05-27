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

    //!  Serwis OrderService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci OrderRepository a  Api w postaci OrderController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
    public class OrderService : IOrderService
    {
        private OrderRepository orderRepository;
        private OrderGameCopyRepository orderGameCopyRepository;
        private GameCopyRepository gameCopyRepository;
        public OrderService(OrderRepository orderRepository, GameCopyRepository gameCopyRepository, OrderGameCopyRepository orderGameCopyRepository)
        {
            this.orderRepository = orderRepository;
            this.gameCopyRepository = gameCopyRepository;
            this.orderGameCopyRepository = orderGameCopyRepository;
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

        public bool FinishOrder(int ordID)
        {
            var orderID = orderRepository.FinishOrder(ordID);
            if (orderID != 0)
            {
                List<int> orderGameCopies = orderGameCopyRepository.GetAllGameCopiesToReturn(orderID);
                bool orderGameCopiesReturned = gameCopyRepository.ReturnGameCopies(orderGameCopies);
                return orderGameCopiesReturned;
            }
            else
                return false;
        }
    }
}
