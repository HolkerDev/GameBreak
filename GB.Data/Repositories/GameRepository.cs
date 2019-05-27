using GB.Data.DAL;
using GB.Data.Dto;
using GB.Entities.Models;
using GB.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GB.Data.Repositories
{
    //!  Repozytorium GameRepository. 
    /*!
       Klasa, która zawiera wszystkie elementy logiki dostępu do danych dla tabeli Game.
    */
    public class GameRepository : DataRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationContext db) : base(db)
        {

        }

        //!  Metoda repozytorium Get. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu pobrania konkretnej gry.
        */
        public GameDto Get(int id)
        {
            try
            {
                var query = _dbContext.Games
                    .Include(x => x.GameGenres).ThenInclude(gg=>gg.Genre)
                    .Include(x => x.GameGenres).ThenInclude(gg => gg.Game)
                    .Include(x => x.GameCopies).ThenInclude(gp=>gp.Location)
                    .Include(x=>x.Production)
                    .Include(x=>x.AgeRating)
                    .Include(x=>x.GamePlatform)
                    .Where(x=>x.ID == id);
                if (query == null)
                    throw new Exception("Game not found");
                GameDto game = query.Select(g => new GameDto() {
                    ID = g.ID,
                    Name = g.Name,
                    ReleaseDate = g.ReleaseDate,
                    Production = new ProductionDto {
                        ID = g.Production.ID,
                        Name = g.Production.Name
                    },
                    GamePlatform = new GamePlatformDto()
                    {
                        ID = g.GamePlatform.ID,
                        Name = g.GamePlatform.Name
                    },
                    AgeRating = new AgeRatingDto()
                    {
                        ID = g.AgeRating.ID,
                        Name = g.AgeRating.Name
                    },
                    Price = g.Price,
                    Description = g.Description,
                    GameGenres = g.GameGenres.Select(gg => new GameGenreDto
                    {
                        ID = gg.ID,
                        GameID = gg.GameID,
                        GenreID = gg.GenreID,
                        GameName = gg.Game.Name,
                        GenreName = gg.Genre.Name
                    }).ToList(),
                    Image = g.Image,
                    GameCopies = g.GameCopies.Select(gp => new GameCopyDto
                    {
                        ID = gp.ID,
                        GameID = gp.GameID,
                        GameCopyStatusID = gp.GameCopyStatusID,
                        GameCopyStatus = new GameCopyStatusDto {
                            ID = gp.GameCopyStatus.ID,
                            Name = gp.GameCopyStatus.Name
                        },
                        UserID = gp.UserID,
                        LocationID = gp.LocationID
                    }).ToList(),
                    LocationsWithGameCopiesAvailable = g.GameCopies.Where(gp=>gp.GameCopyStatusID==1).Select( gp => new LocationAvailableDto {
                        ID = gp.Location.ID,
                        Name = gp.Location.Name
                    }).Distinct().ToList()

                    }).SingleOrDefault();
                return game;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //!  Metoda repozytorium AddGame. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu dodania nowej gry w bazie danych.
        */
        public Game AddGame(CreateGameDto game)
        {
            try
            {
                var gameExists = _dbContext.Games.SingleOrDefault(x => x.Name == game.Name && x.GamePlatformID == game.GamePlatformID);
                if (gameExists != null)
                    throw new Exception(string.Format("Game with that name and game platform already exists"));
                Game g = new Game
                {
                    Name = game.Name,
                    ReleaseDate = game.ReleaseDate,
                    ProductionID = game.ProductionID,
                    GamePlatformID = game.GamePlatformID,
                    AgeRatingID = game.AgeRatingID,
                    Price = game.Price,
                    Description = game.Description,
                    Image = game.Image
                };
   
                this.Add(g);

                return g;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //!  Metoda repozytorium UpdateGame. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu zapisania zmian do danych gry.
        */
        public Game UpdateGame(CreateGameDto game)
        {
            try
            {
                var g = _dbContext.Games.SingleOrDefault(x => x.ID == game.ID);
                if (g == null)
                    throw new Exception(string.Format("Cannot edit game, because game is not found."));
                g.Name = game.Name;
                g.ReleaseDate = game.ReleaseDate;
                g.ProductionID = game.ProductionID;
                g.GamePlatformID = game.GamePlatformID;
                g.AgeRatingID = game.AgeRatingID;
                g.Price = game.Price;
                g.Description = game.Description;
                g.Image = game.Image;
                this.Update(g);

                return g;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //!  Metoda repozytorium GetAll. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu pobrania listy gier.
        */
        public List<GameDto> GetAll()
        {
            try
            {
                List<GameDto> games = new List<GameDto>();
                var query = _dbContext.Games.Include(x => x.GameGenres).ThenInclude(gg => gg.Genre)
                     .Include(x => x.GameGenres).ThenInclude(gg => gg.Game);
                games = query.Select(g => new GameDto
                {
                    ID = g.ID,
                    Name = g.Name,
                    ReleaseDate = g.ReleaseDate,
                    Production = new ProductionDto() {
                        ID = g.Production.ID,
                        Name = g.Production.Name
                    },
                    GamePlatform = new GamePlatformDto()
                    {
                        ID = g.GamePlatform.ID,
                        Name = g.GamePlatform.Name
                    },
                    AgeRating = new AgeRatingDto()
                    {
                        ID = g.AgeRating.ID,
                        Name = g.AgeRating.Name
                    },
                    Price = g.Price,
                    Description = g.Description,
                    GameGenres = g.GameGenres.Select(gg => new GameGenreDto {
                        ID = gg.ID,
                        GameID = gg.GameID,
                        GenreID = gg.GenreID,
                        GameName = gg.Game.Name,
                        GenreName = gg.Genre.Name
                    }).ToList(),
                    Image = g.Image
                }).OrderBy(g=>g.Name).ToList();

                return games;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //!  Metoda repozytorium Remove. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu usunięcia gry z bazy.
        */
        public void Remove(int id)
        {
            Game g = _dbContext.Games.SingleOrDefault(x => x.ID == id);
            if (g == null)
                throw new Exception(string.Format("Game already does not exist"));
            this.Delete(g);
        }
    }
}
