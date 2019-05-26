using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    //!  Api Controller Production Controller. 
    /*!
       Klasa do opracowania przesłanych akcji HTTP w związku z działaniami na modelu Production.
    */
    [RoutePrefix("api/production")]
    public class ProductionController : ApiController
    {
        private ProductionService productionService;

        //! Konstruktor klasy GameController. 
        /*!
          Konstruktor klasy ProductionController, z inicjalizacją serwisu ProductionService.
        */
        public ProductionController(ProductionService productionService)
        {
            this.productionService = productionService;
        }

        //!  Akcja GetAll. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu ProductionService zrwaca wszystkich producentów w systemie.
        */
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(productionService.GetAll());
        }
    }
}