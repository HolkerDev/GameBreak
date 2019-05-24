using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    [RoutePrefix("api/a_order")]
    public class A_OrderController : ApiController
    {
        private OrderService orderService;

        public A_OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(orderService.GetAll());
        }

        [Route("GetOrdersWithPenalties")]
        [HttpGet]
        public IHttpActionResult GetOrdersWithPenalties()
        {
            return Json(orderService.GetOrdersWithPenalties());
        }


        [Route("Post/FinishOrder")]
        [HttpPost]
        public IHttpActionResult FinishOrder([FromBody] int orderID)
        {
            return Json(orderService.FinishOrder(orderID));
        }
    }
}