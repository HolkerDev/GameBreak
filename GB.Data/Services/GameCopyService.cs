using GB.Data.Repositories;
using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface IGameCopyService
    {

    }

    public class GameCopyService : IGameCopyService
    {
        private GameCopyRepository gameCopyRepository;
        public GameCopyService(GameCopyRepository gameCopyRepository)
        {
            this.gameCopyRepository = gameCopyRepository;
        }

        public bool UpdateGameCopies(List<GameCopy> gameCopies, int userID){
            var gameCopiesUpdated = gameCopyRepository.UpdateGameCopies(gameCopies, userID);
            return gameCopiesUpdated;
        }
    }
}
