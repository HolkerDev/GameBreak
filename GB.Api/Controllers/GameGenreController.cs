using GB.Data.Dto;
using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    [RoutePrefix("api/gameGenre")]
    public class GameGenreController : ApiController
    {
        private GameGenreService gameGenreService;

        public GameGenreController(GameGenreService gameGenreService)
        {
            this.gameGenreService = gameGenreService;
        }

        [HttpPost]
        [Route("Post/CreateAllForGame")]
        public IHttpActionResult Create([FromBody] List<int> gameGenres, int gameID)
        {
            gameGenreService.AddGameGenres(gameGenres, gameID);
            return Json(true);
        }

    }
}