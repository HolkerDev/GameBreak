using GB.Data.Dto;
using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    //!  Api Controller GameController. 
    /*!
        Api Controller do opracowania przesłanych akcji HTTP w związku z działaniami na modelu Game.
    */
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private GameService gameService;

        //! Konstruktor klasy GameController. 
        /*!
          Konstruktor klasy GameController, z inicjalizacją serwisu GameService.
        */
        public GameController(GameService gameService)
        {
            this.gameService = gameService;
        }

        //!  Akcja Get. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu OrderService zwraca grę z ID, przekazanym jako parametr.
        */
        [Route("Get")]
        [HttpGet]
        public IHttpActionResult Get(int gameID)
        {
            return Json(gameService.Get(gameID));
        }

        //!  Akcja GetAll. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu GameService zwraca wszystkie gry w systemie.
        */
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(gameService.GetAll());
        }

        //!  Akcja Create. 
        /*!
          Akcja typu HttpPost, używająć metody serwisu GameService, zapisuje nową grę do bazy oraz zwraca wynik.
        */
        [HttpPost]
        [Route("Post/Create")]
        public IHttpActionResult Create([FromBody] CreateGameDto game)
        {
            gameService.AddGame(game);
            return Json(true);
        }

        //!  Akcja Update. 
        /*!
          Akcja typu HttpPost, używająć metody serwisu GameService, zapisuje zmiany w informacjach o grze oraz zwraca wynik.
        */
        [HttpPost]
        [Route("Post/Update")]
        public IHttpActionResult Update([FromBody] CreateGameDto game)
        {
            gameService.UpdateGame(game);
            return Json(true);
        }
    }
}