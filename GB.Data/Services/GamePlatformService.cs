using GB.Data.Dto;
using GB.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface IGamePlatformService
    {
        
    }

    //!  Serwis GamePlatformService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci GamePlatformRepository a  Api w postaci GamePlatformController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
    public class GamePlatformService : IGamePlatformService
    {
        private readonly GamePlatformRepository gamePlatformRepo;

        public GamePlatformService(GamePlatformRepository gamePlatformRepository)
        {
            gamePlatformRepo = gamePlatformRepository;
        }

        public List<GamePlatformDto> GetAll()
        {
            List<GamePlatformDto> gamePlatforms = gamePlatformRepo.GetAll();
            return gamePlatforms;
        }
    }
}
