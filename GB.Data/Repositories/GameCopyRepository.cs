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

        public bool UpdateGameCopies(List<GameCopy> gameCopies, int userID)
        {
            try
            {
                foreach(GameCopy gameCopy in gameCopies){
                    gameCopy.UserID = userID;
                    gameCopy.GameCopyStatusID = 2;
                    this.Update(gameCopy);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ReturnGameCopies(List<int> gameCopies)
        {
            try
            {
                foreach(int gameCopyID in gameCopies)
                {
                    GameCopy gameCopy = _dbContext.GameCopies.Where(g=>g.ID == gameCopyID).SingleOrDefault();
                    if (gameCopy!= null)
                    {
                        gameCopy.UserID = null;
                        gameCopy.GameCopyStatusID = 1;
                        this.Update(gameCopy);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
