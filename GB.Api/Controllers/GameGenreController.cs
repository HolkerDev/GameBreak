using GB.Data.Dto;
using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    //!  Api Controller GameGenreController. 
    /*!
       Klasa do opracowania przesłanych akcji HTTP w związku z działaniami na modelu GameGenre.
    */
    [RoutePrefix("api/gameGenre")]
    public class GameGenreController : ApiController
    {
        private GameGenreService gameGenreService;

        //! Konstruktor klasy GameGenreController. 
        /*!
          Konstruktor klasy GameGenreController, z inicjalizacją serwisu GameGenreService.
        */
        public GameGenreController(GameGenreService gameGenreService)
        {
            this.gameGenreService = gameGenreService;
        }

        //!  Akcja Create. 
        /*!
          Akcja typu HttpPost, używająć metody serwisu GameGenreService zapisuje wybrane gatunki do gry.
        */
        [HttpPost]
        [Route("Post/CreateAllForGame")]
        public IHttpActionResult Create([FromBody] List<int> gameGenres, int gameID)
        {
            gameGenreService.AddGameGenres(gameGenres, gameID);
            return Json(true);
        }

    }
}