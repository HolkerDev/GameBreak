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

    //!  Serwis GameCopyService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci GameCopyRepository a  Api w postaci GameCopyController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
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
