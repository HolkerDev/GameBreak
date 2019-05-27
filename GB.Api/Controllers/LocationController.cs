using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    //!  Api Controller LocationController. 
    /*!
       Klasa do opracowania przesłanych akcji HTTP w związku z działaniami na modelu Location.
    */
    [RoutePrefix("api/location")]
    public class LocationController : ApiController
    {
        private GameService gameService;
        private LocationService locationService;

        //! Konstruktor klasy LocationController. 
        /*!
          Konstruktor klasy LocationController, z inicjalizacją serwisu LocationService.
        */
        public LocationController(GameService gameService, LocationService locationService)
        {
            this.gameService = gameService;
            this.locationService = locationService;
        }

        //!  Akcja GetAll. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu LocationService zwraca wszystkie dostępne lokalizacje w systemie.
        */
        [Route("GetAvailableLocationsForGame")]
        [HttpGet]
        public IHttpActionResult GetAvailableLocationsForGame(int gameID)
        {
            return Json(locationService.GetAvailableLocationsForGame(gameID));
        }
    }
}