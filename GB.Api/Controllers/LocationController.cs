using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    [RoutePrefix("api/location")]
    public class LocationController : ApiController
    {
        private GameService gameService;
        private LocationService locationService;

        public LocationController(GameService gameService, LocationService locationService)
        {
            this.gameService = gameService;
            this.locationService = locationService;
        }

        [Route("GetAvailableLocationsForGame")]
        [HttpGet]
        public IHttpActionResult GetAvailableLocationsForGame(int gameID)
        {
            return Json(locationService.GetAvailableLocationsForGame(gameID));
        }
    }
}