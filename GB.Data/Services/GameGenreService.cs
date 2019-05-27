using GB.Data.Dto;
using GB.Data.Repositories;
using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface IGameGenreService
    {
    }

    //!  Serwis GameGenreService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci GameGenreRepository a  Api w postaci GameGenreController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
    public class GameGenreService :  IGameGenreService 
    {
        private readonly GameGenreRepository gameGenreRepo;
        public GameGenreService( GameGenreRepository gameGenreRepository)
        {
            gameGenreRepo = gameGenreRepository;
        }

        public List<GameGenre> AddGameGenres( List<int> gameGenres, int gameId)
        {
            List<GameGenre> gameGenresAdded = gameGenreRepo.AddGameGenres(gameGenres, gameId);
            return gameGenresAdded;
        }

        public List<GameGenre> UpdateGameGenres( List<int> gameGenres, int gameId)
        {
            List<GameGenre> gameGenresAdded = gameGenreRepo.AddGameGenres(gameGenres, gameId);
            return gameGenresAdded;
        }

    }
}
