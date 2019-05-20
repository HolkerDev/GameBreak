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

    }
}
