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

    //!  Serwis OrderGameCopyService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci OrderGameCopyRepository a  Api w postaci OrderGameCopyController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
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
