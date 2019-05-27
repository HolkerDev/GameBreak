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
    //!  Mvc Controller A_OrderController. 
    /*!
       Klasa A_OrderController służy do przekierowania akcji Http na Api Controller oraz przekazania danych do wyświetlenia na widokach, zarządzania zamówieniami przez administratora.
    */
    [CustomAuthorize(Roles = "Administrator")]
    public class A_OrderController : Controller
    {
        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia listy wszystkich zamówień na widoku \A_Order\GetOrders, otrzymanych z warstwy Api.
        */
        [HttpGet]
        public ActionResult GetOrders()
        {
            var data = new ApiClient().GetData<List<OrderDto>>("api/a_order/GetAll");
            return View(data);
        }

        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia listy zaległych zamówień na widoku \A_Order\GetOrdersWithPenalties, otrzymanych z warstwy Api.
        */
        [HttpGet]
        public ActionResult GetOrdersWithPenalties()
        {
            var data = new ApiClient().GetData<List<OrderDto>>("api/a_order/GetOrdersWithPenalties");
            return View(data);
        }

        //!  Akcja ActionResult typu HttpPost. 
        /*!
           Służy do przekazania informacji do warstwy Api o zamówieniu do zamknięcia z widoku \A_Order\Finish.
        */
        public ActionResult FinishOrder(int orderID)
        {
            var result = new ApiClient().PostData<int>("api/a_order/Post/FinishOrder", orderID);
            return RedirectToAction("Index");
        }
    }
}