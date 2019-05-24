using GB.Data.Dto;
using GB.Web.CustomAuthentication;
using GB.Web.Logic;
using GB.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Web.Controllers
{
    [CustomAuthorize(Roles = "Client")]
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult Checkout()
        {
            NewOrderVM vm = new NewOrderVM();
            vm.OrderGameCopies = (List<AddToCartDto>)Session["cart"];
            vm.TotalPrice = vm.OrderGameCopies.Sum(x => x.Price);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Checkout(NewOrderVM vm)
        {
            CustomPrincipal user = HttpContext.User as CustomPrincipal;
            vm.UserID = user.UserID;
            if (ModelState.IsValid)
            {
                var result = new ApiClient().PostData<OrderDto>("api/order/Post/Create", new OrderDto()
                {
                    CreatedAt = DateTime.Now,
                    ExpiresAt = DateTime.Now.AddDays(14),
                    OrderGameCopies = vm.OrderGameCopies.Select(o => new OrderGameCopyDto {
                        GameID = o.GameID,
                        LocationID = o.LocationID
                    }).ToList(),
                    TotalPrice = vm.TotalPrice,
                    UserID = vm.UserID
                });
                return RedirectToAction("ClearCart", "Cart");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ViewUserOrders()
        {
            ViewOrdersVM vm = new ViewOrdersVM();
            CustomPrincipal user = HttpContext.User as CustomPrincipal;
            vm.Orders = new ApiClient().GetData<List<OrderDto>>("api/order/GetUserOrders?userID=" + user.UserID);
            return View(vm);
        }

        [HttpGet]
        public ActionResult Get(int orderID)
        {
            OrderDto order = new ApiClient().GetData<OrderDto>("api/order/Get?orderID=" + orderID);
            return View(order);
        }
    }
}