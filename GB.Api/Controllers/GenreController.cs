using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    //!  Api Controller GenreController. 
    /*!
       Klasa do opracowania przesłanych akcji HTTP w związku z działaniami na modelu Genre.
    */
    [RoutePrefix("api/genre")]
    public class GenreController : ApiController
    {
        private GenreService genreService;

        //! Konstruktor klasy GenreController. 
        /*!
          Konstruktor klasy GenreController, z inicjalizacją serwisu GenreService.
        */
        public GenreController(GenreService genreService)
        {
            this.genreService = genreService;
        }

        //!  Akcja GetAll. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu GenreService zwraca wszystkie gatunki w systemie.
        */
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(genreService.GetAll());
        }
    }
}