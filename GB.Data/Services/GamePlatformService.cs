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
