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
    //!  Repozytorium GamePlatformRepository. 
    /*!
       Klasa, która zawiera wszystkie elementy logiki dostępu do danych dla tabeli GamePlatform.
    */
    public class GamePlatformRepository : DataRepository<GamePlatform>, IGamePlatformRepository
    {
        public GamePlatformRepository(ApplicationContext db) : base(db)
        {

        }

        //!  Metoda repozytorium GetAll. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu pobrania listy platform.
        */
        public List<GamePlatformDto> GetAll()
        {
            try
            {
                List<GamePlatformDto> gamePlatforms = new List<GamePlatformDto>();
                var query = _dbContext.GamePlatforms;
                gamePlatforms = query.Select(u => new GamePlatformDto
                {
                    ID = u.ID,
                    Name = u.Name

                }).ToList();

                return gamePlatforms;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
