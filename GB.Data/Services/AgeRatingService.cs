using GB.Data.Dto;
using GB.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface IAgeRatingService
    {

    }

    public class AgeRatingService : IAgeRatingService
    {
        private readonly AgeRatingRepository ageRatingRepo;

        public AgeRatingService(AgeRatingRepository ageRatingRepository)
        {
            ageRatingRepo = ageRatingRepository;
        }

        public List<AgeRatingDto> GetAll()
        {
            List<AgeRatingDto> ageRatings = ageRatingRepo.GetAll();
            return ageRatings;
        }
    }
}
