using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    [RoutePrefix("api/gamePlatform")]
    public class GamePlatformController : ApiController
    {
        private GamePlatformService gamePlatformService;

        public GamePlatformController(GamePlatformService gamePlatformService)
        {
            this.gamePlatformService = gamePlatformService;
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(gamePlatformService.GetAll());
        }
    }
}