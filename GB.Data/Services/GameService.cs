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
    public interface IGameService
    {
    }

    //!  Serwis GameService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci GameRepository a  Api w postaci GameController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
    public class GameService : IGameService
    {
        private readonly GameRepository gameRepo;
        private readonly GameGenreService gameGenreService;

        public GameService(GameRepository gameRepository, GameGenreService gameGenreService)
        {
            gameRepo = gameRepository;
            this.gameGenreService = gameGenreService;
        }

        public GameDto Get(int id)
        {
            GameDto game = gameRepo.Get(id);
            return game;
        }

        public Game AddGame(CreateGameDto game)
        {
            Game g = gameRepo.AddGame(game);
            g.GameGenres = gameGenreService.AddGameGenres(game.GameGenres, g.ID); 
            return g;
        }

        public Game UpdateGame(CreateGameDto game)
        {
            Game g = gameRepo.UpdateGame(game);
            g.GameGenres = gameGenreService.UpdateGameGenres(game.GameGenres, g.ID); 
            return g;
        }

        public List<GameDto> GetAll()
        {
            List<GameDto> games = gameRepo.GetAll();
            return games;
        }

        public void Remove(int id)
        {
            gameRepo.Remove(id);
        }
    }
}
