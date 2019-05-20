using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    [RoutePrefix("api/production")]
    public class ProductionController : ApiController
    {
        private ProductionService productionService;

        public ProductionController(ProductionService productionService)
        {
            this.productionService = productionService;
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(productionService.GetAll());
        }
    }
}