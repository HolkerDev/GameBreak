using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    //!  Api Controller GamePlatformController. 
    /*!
        Klasa do opracowania przesłanych akcji HTTP w związku z działaniami na modelu GamePlatform.
    */
    [RoutePrefix("api/gamePlatform")]
    public class GamePlatformController : ApiController
    {
        private GamePlatformService gamePlatformService;

        //! Konstruktor klasy GamePlatformController. 
        /*!
          Konstruktor klasy GamePlatformController, z inicjalizacją serwisu GamePlatformService.
        */
        public GamePlatformController(GamePlatformService gamePlatformService)
        {
            this.gamePlatformService = gamePlatformService;
        }

        //!  Akcja GetAll. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu GamePlatformService zwraca wszystkie platformy w systemie.
        */
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(gamePlatformService.GetAll());
        }
    }
}