using GB.Data.Dto;
using GB.Data.Services;
using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    //!  Api Controller OrderController. 
    /*!
       Klasa do opracowania przesłanych akcji HTTP w związku z działaniami na modelu Order.
    */
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private OrderService orderService;
        private OrderGameCopyService orderGameCopyService;
        private GameCopyService gameCopyService;

        //! Konstruktor klasy OrderController. 
        /*!
          Konstruktor klasy OrderController, z inicjalizacją serwisu OrderService, OrderGameCopyService oraz GameCopyService.
        */
        public OrderController(OrderService orderService, OrderGameCopyService orderGameCopyService, GameCopyService gameCopyService)
        {
            this.orderService = orderService;
            this.orderGameCopyService = orderGameCopyService;
            this.gameCopyService = gameCopyService;
        }

        //!  Akcja Get. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu OrderService zwraca zamówienie z ID, przekazanym jako parametr.
        */
        [Route("Get")]
        [HttpGet]
        public IHttpActionResult Get(int orderID)
        {
            return Json(orderService.Get(orderID));
        }

        //!  Akcja Create. 
        /*!
          Akcja typu HttpPost, używająć metody serwisu OrderService, OrderGameCopyService oraz GameCopyService, zapisuje nowe zamówienie oraz jego pozycje do bazy i zwraca wynik.
        */
        [Route("Post/Create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] OrderDto ord)
        {
            Order order = orderService.AddOrder(ord);
            List<GameCopy> gameCopiesToUpdate = orderGameCopyService.AddOrderGameCopies(order, ord.OrderGameCopies);
            gameCopyService.UpdateGameCopies(gameCopiesToUpdate, order.UserID);
            return Json(true);
        }


        //!  Akcja GetUserOrders. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu OrderService zwraca wszystkie zamówienia konkretnego użytkownika w systemie.
        */
        [Route("GetUserOrders")]
        [HttpGet]
        public IHttpActionResult GetUserOrders(int userID)
        {
            return Json(orderService.GetUserOrders(userID));
        }
    }
}