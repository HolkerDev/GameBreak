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

    //!  Serwis AgeRatingService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci AgeRatingRepository a  Api w postaci AgeRatingController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
    public class AgeRatingService : IAgeRatingService
    {
        private AgeRatingRepository ageRatingRepo;

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
