using GB.Data.Dto;
using GB.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface ILocationService
    {
    }

    //!  Serwis LocationService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci LocationRepository a  Api w postaci LocationController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
    public class LocationService : ILocationService
    {
        private readonly LocationRepository locationRepo;

        public LocationService(LocationRepository locationRepository)
        {
            locationRepo = locationRepository;
        }

        public List<LocationAvailableDto> GetAvailableLocationsForGame(int gameID)
        {
            return locationRepo.GetAvailableLocationsForGame(gameID);
        }
    }
}
