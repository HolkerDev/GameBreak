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
    public class GamePlatformRepository : DataRepository<GamePlatform>, IGamePlatformRepository
    {
        public GamePlatformRepository(ApplicationContext db) : base(db)
        {

        }

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
