using GB.Data.DAL;
using GB.Data.Dto;
using GB.Entities.Models;
using GB.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GB.Data.Repositories
{
    public class GameGenreRepository : DataRepository<GameGenre>, IGameGenreRepository
    {
        public GameGenreRepository(ApplicationContext db) : base(db)
        {

        }

        public List<GameGenre> AddGameGenres(List<int> gameGenres, int gameID)
        {
            try
            {
                List<GameGenre> existingGenres = _dbContext.GameGenres.Where(x => x.GameID == gameID).ToList();
                List<GameGenre> genresToAdd = gameGenres.Select(g => new GameGenre {
                    GameID = gameID,
                    GenreID = g
                }).ToList();
                if(existingGenres!= null && genresToAdd != null)
                {
                    foreach (GameGenre existingGameGenre in existingGenres)
                    {
                        if (!genresToAdd.Contains(existingGameGenre))
                            this.Delete(existingGameGenre);
                    }
                    foreach (GameGenre gameGenreToAdd in genresToAdd)
                    {
                        if (!existingGenres.Contains(gameGenreToAdd))
                            this.Add(gameGenreToAdd);
                    }
                }
                else if(existingGenres == null && genresToAdd != null)
                {
                    foreach (GameGenre gameGenreToAdd in genresToAdd)
                    {
                        this.Add(gameGenreToAdd);
                    }
                }

                else if (existingGenres != null && genresToAdd == null)
                {
                    foreach (GameGenre existingGameGenre in existingGenres)
                    {
                        this.Delete(existingGameGenre);
                    }
                    List<GameGenre> gameGenresNone = new List<GameGenre>();
                    return gameGenresNone;
                }


                return genresToAdd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
