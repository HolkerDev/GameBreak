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
    public interface IOrderGameCopyService
    {

    }

    public class OrderGameCopyService : IOrderGameCopyService
    {
        private OrderGameCopyRepository orderGameCopyRepository;
        private GameCopyRepository gameCopyRepository;
        public OrderGameCopyService(OrderGameCopyRepository orderGameCopyRepository, GameCopyRepository gameCopyRepository)
        {
            this.orderGameCopyRepository = orderGameCopyRepository;
            this.gameCopyRepository = gameCopyRepository;
        }

        public List<GameCopy> AddOrderGameCopies(Order order, List<OrderGameCopyDto> orderGameCopies)
        {
            return orderGameCopyRepository.AddOrderGameCopies(order, orderGameCopies);
        }
    }
}
