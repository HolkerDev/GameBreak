using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    //!  Api Controller A_OrderController. 
    /*!
       Klasa Controller do opracowania przesłanych akcji HTTP w związku z działaniami na modelu Order przez administratora.
    */
    [RoutePrefix("api/a_order")]
    public class A_OrderController : ApiController
    {
        private OrderService orderService;

        //! Konstruktor klasy A_OrderController. 
        /*!
          Konstruktor klasy A_OrderController, z inicjalizacją serwisu OrderService.
        */
        public A_OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        //!  Akcja GetAll. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu OrderService zwraca wszystkie zamówienia w systemie.
        */
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(orderService.GetAll());
        }

        //!  Akcja GetOrdersWithPenalties. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu OrderService zwraca wszystkie zaległe zamówienia w systemie.
        */
        [Route("GetOrdersWithPenalties")]
        [HttpGet]
        public IHttpActionResult GetOrdersWithPenalties()
        {
            return Json(orderService.GetOrdersWithPenalties());
        }

        //!  Akcja FinishOrder. 
        /*!
          Akcja typu HttpPost, używająć metody serwisu OrderService, zapisuje informacje o zamykaniu zamówienia oraz zwraca wynik.
        */
        [Route("Post/FinishOrder")]
        [HttpPost]
        public IHttpActionResult FinishOrder([FromBody] int orderID)
        {
            return Json(orderService.FinishOrder(orderID));
        }
    }
}