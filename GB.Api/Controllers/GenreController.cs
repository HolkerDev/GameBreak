using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    [RoutePrefix("api/genre")]
    public class GenreController : ApiController
    {
        private GenreService genreService;

        public GenreController(GenreService genreService)
        {
            this.genreService = genreService;
        }


        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(genreService.GetAll());
        }
    }
}