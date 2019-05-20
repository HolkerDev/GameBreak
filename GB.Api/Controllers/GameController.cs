using GB.Data.Dto;
using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private GameService gameService;

        public GameController(GameService gameService)
        {
            this.gameService = gameService;
        }

        [Route("Get")]
        [HttpGet]
        public IHttpActionResult Get(int gameID)
        {
            return Json(gameService.Get(gameID));
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(gameService.GetAll());
        }

        [HttpPost]
        [Route("Post/Create")]
        public IHttpActionResult Create([FromBody] CreateGameDto game)
        {
            gameService.AddGame(game);
            return Json(true);
        }
    }
}