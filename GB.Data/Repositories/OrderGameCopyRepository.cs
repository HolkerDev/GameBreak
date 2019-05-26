using GB.Data.DAL;
using GB.Data.Dto;
using GB.Entities.Models;
using GB.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Repositories
{
    //!  Repozytorium OrderGameCopyRepository. 
    /*!
       Klasa, która zawiera wszystkie elementy logiki dostępu do danych dla tabeli OrderGameCopy.
    */
    public class OrderGameCopyRepository : DataRepository<OrderGameCopy>, IOrderGameCopyRepository
    {
        public OrderGameCopyRepository(ApplicationContext db) : base(db)
        {

        }

        //!  Metoda repozytorium AddOrderGameCopies. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu dodania do bazy danych listy pozycji wybranego zamówienia.
        */
        public List<GameCopy> AddOrderGameCopies( Order order, List<OrderGameCopyDto> orderGameCopies)
        {
            try
            {
                List<GameCopy> gameCopiesToUpdate = new List<GameCopy>();
                foreach(OrderGameCopyDto orderGameCopy in orderGameCopies)
                {
                    GameCopy o = _dbContext.GameCopies.FirstOrDefault(x=>x.GameID == orderGameCopy.GameID && x.LocationID == orderGameCopy.LocationID && x.GameCopyStatusID == 1);
                    if (o != null)
                    {
                        OrderGameCopy ogc = new OrderGameCopy()
                        {
                            GameCopyID = o.ID,
                            OrderID = order.ID
                        };
                        gameCopiesToUpdate.Add(o);
                        this.Add(ogc);
                    }
                    else {
                        var gameName = _dbContext.Games.FirstOrDefault(x => x.ID == orderGameCopy.GameID).Name;
                        throw new Exception("No game copy is longer available for game " + gameName);
                    }
                }

                return gameCopiesToUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //!  Metoda repozytorium GetAllGameCopiesToReturn. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu pobrania wszystkich pozycji zamówienia do oddania.
        */
        public List<int> GetAllGameCopiesToReturn(int orderID)
        {
            try
            {
                List<int> gameCopies = _dbContext.OrderGameCopies.Where(g => g.OrderID == orderID).Select(g => g.GameCopyID).ToList();
                return gameCopies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
