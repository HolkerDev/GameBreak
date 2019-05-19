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
    public class AgeRatingRepository :  DataRepository<AgeRating>, IAgeRatingRepository
    {
        public AgeRatingRepository(ApplicationContext db) : base(db)
        {

        }

        public List<AgeRatingDto> GetAll()
        {
            try
            {
                List<AgeRatingDto> ageRatings = new List<AgeRatingDto>();
                var query = _dbContext.AgeRatings;
                ageRatings = query.Select(u => new AgeRatingDto
                {
                    ID = u.ID,
                    Name = u.Name

                }).ToList();

                return ageRatings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
