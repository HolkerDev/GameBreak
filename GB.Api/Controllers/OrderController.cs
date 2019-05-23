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
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private OrderService orderService;
        private OrderGameCopyService orderGameCopyService;
        private GameCopyService gameCopyService;

        public OrderController(OrderService orderService, OrderGameCopyService orderGameCopyService, GameCopyService gameCopyService)
        {
            this.orderService = orderService;
            this.orderGameCopyService = orderGameCopyService;
            this.gameCopyService = gameCopyService;
        }

        [Route("Get")]
        [HttpGet]
        public IHttpActionResult Get(int orderID)
        {
            return Json(orderService.Get(orderID));
        }

        //[Route("GetAll")]
        //[HttpGet]
        //public IHttpActionResult GetAll()
        //{
        //    return Json(orderService.GetAll());
        //}
        [Route("Post/Create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] OrderDto ord)
        {
            Order order = orderService.AddOrder(ord);
            List<GameCopy> gameCopiesToUpdate = orderGameCopyService.AddOrderGameCopies(order, ord.OrderGameCopies);
            gameCopyService.UpdateGameCopies(gameCopiesToUpdate, order.UserID);
            return Json(true);
        }

        [Route("GetUserOrders")]
        [HttpGet]
        public IHttpActionResult GetUserOrders(int userID)
        {
            return Json(orderService.GetUserOrders(userID));
        }
    }
}