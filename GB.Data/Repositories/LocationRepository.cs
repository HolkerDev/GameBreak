﻿using GB.Data.DAL;
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
    //!  Repozytorium LocationRepository. 
    /*!
       Klasa, która zawiera wszystkie elementy logiki dostępu do danych dla tabeli Location.
    */
    public class LocationRepository : DataRepository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationContext db) : base(db)
        {

        }

        //!  Metoda repozytorium GetAvailableLocationsForGame. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu pobrania listy dostępnych lokalizacji dla wybranej gry.
        */
        public List<LocationAvailableDto> GetAvailableLocationsForGame(int gameID)
        {
            try
            {
                List<LocationAvailableDto> availableLocations  = new List<LocationAvailableDto>();
               
                var gameCopies = _dbContext.GameCopies.Where(gp => gp.GameID == gameID && gp.GameCopyStatusID == 1);
                var locations = gameCopies.Include(gp => gp.Location).Select(l=>l.Location).Distinct();
                availableLocations = locations.Select(l => new LocationAvailableDto {
                    ID = l.ID,
                    Name = l.Name 
                }).ToList();

                return availableLocations;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
