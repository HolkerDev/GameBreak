using GB.Data.DAL;
using GB.Entities.Models;
using GB.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Repositories
{
    //!  Repozytorium GameCopyStatusRepository. 
    /*!
       Klasa, która zawiera wszystkie elementy logiki dostępu do danych dla tabeli GameCopyStatus.
    */
    public class GameCopyStatusRepository : DataRepository<GameCopyStatus>, IGameCopyStatusRepository
    {
        public GameCopyStatusRepository(ApplicationContext db) : base(db)
        {

        }
    }
}
