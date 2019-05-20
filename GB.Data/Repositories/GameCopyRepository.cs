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
    public class GameCopyRepository : DataRepository<GameCopy>, IGameCopyRepository
    {
        public GameCopyRepository(ApplicationContext db) : base(db)
        {

        }
    }
}
