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
    public class GenreRepository : DataRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationContext db) : base(db)
        {

        }

        public List<GenreDto> GetAll()
        {
            try
            {
                List<GenreDto> genres = new List<GenreDto>();
                var query = _dbContext.Genres;
                genres = query.Select(u => new GenreDto
                {
                    ID = u.ID,
                    Name = u.Name

                }).ToList();

                return genres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
