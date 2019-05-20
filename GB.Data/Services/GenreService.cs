using GB.Data.Dto;
using GB.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface IGenreService
    {
        
    }
    public class GenreService : IGenreService
    {
        private readonly GenreRepository genreRepo;

        public GenreService(GenreRepository genreRepository)
        {
            genreRepo = genreRepository;
        }

        public List<GenreDto> GetAll()
        {
            List<GenreDto> genres = genreRepo.GetAll();
            return genres;
        }
    }
}
