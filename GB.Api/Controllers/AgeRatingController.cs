using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    [RoutePrefix("api/ageRating")]
    public class AgeRatingController : ApiController
    {
        private AgeRatingService ageRatingService;

        public AgeRatingController(AgeRatingService ageRatingService)
        {
            this.ageRatingService = ageRatingService;
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(ageRatingService.GetAll());
        }
    }
}