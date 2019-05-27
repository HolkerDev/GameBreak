using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    //!  Api Controller Age Rating Controller. 
    /*!
        Klasa do opracowania przesłanych akcji HTTP w związku z działaniami na modelu Age Rating.
    */
    [RoutePrefix("api/ageRating")]
    public class AgeRatingController : ApiController
    {
        private AgeRatingService ageRatingService;

        //! Konstruktor klasy AgeRatingController. 
        /*!
          Konstruktor klasy AgeRatingController, z inicjalizacją serwisu AgeRatingService.
        */
        public AgeRatingController(AgeRatingService ageRatingService)
        {
            this.ageRatingService = ageRatingService;
        }

        //!  Akcja GetAll. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu AgeRatingService zwraca wszystkie ograniczenia wiekowe w systemie.
        */
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(ageRatingService.GetAll());
        }
    }
}