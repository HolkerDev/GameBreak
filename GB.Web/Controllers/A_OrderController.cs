using GB.Data.Dto;
using GB.Web.CustomAuthentication;
using GB.Web.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Web.Controllers
{
    [CustomAuthorize(Roles = "Administrator")]
    public class A_OrderController : Controller
    {
        [HttpGet]
        public ActionResult GetOrders()
        {
            var data = new ApiClient().GetData<List<OrderDto>>("api/a_order/GetAll");
            return View(data);
        }

        [HttpGet]
        public ActionResult GetOrdersWithPenalties()
        {
            var data = new ApiClient().GetData<List<OrderDto>>("api/a_order/GetOrdersWithPenalties");
            return View(data);
        }


    }
}