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
