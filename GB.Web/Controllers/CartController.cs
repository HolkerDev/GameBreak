using GB.Data.Dto;
using GB.Web.CustomAuthentication;
using GB.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Web.Controllers
{
    [CustomAuthorize(Roles = "Client")]
    public class CartController : Controller
    {
        // GET: AddToCart  
        [HttpPost]
        public ActionResult Add(ViewGameVM vm)
        {

            if (Session["cart"] == null)
            {
                List<AddToCartDto> cartItems = new List<AddToCartDto>();
                cartItems.Add( new AddToCartDto {
                    GameID = vm.Game.ID,
                    GameName = vm.Game.Name,
                    LocationID = Convert.ToInt32(vm.Game.LocationChosenID),
                    LocationName = vm.Game.LocationsWithGameCopiesAvailable.Where(x=>x.ID == Convert.ToInt32(vm.Game.LocationChosenID)).Select(x=>x.Name).First(),
                    UserID = 1,
                    Price = vm.Game.Price,
                    ID = 1
                });
                Session["cart"] = cartItems;
                ViewBag.cart = cartItems.Count();
                Session["count"] = 1;
                Session["itemID"] = 1;
            }
            else
            {
                List<AddToCartDto> cartItems = (List<AddToCartDto>)Session["cart"];
                cartItems.Add(new AddToCartDto
                {
                    GameID = vm.Game.ID,
                    GameName = vm.Game.Name,
                    LocationID = Convert.ToInt32(vm.Game.LocationChosenID),
                    LocationName = vm.Game.LocationsWithGameCopiesAvailable.Where(x => x.ID == Convert.ToInt32(vm.Game.LocationChosenID)).Select(x => x.Name).First(),
                    UserID = 1,
                    Price = vm.Game.Price,
                    ID = Convert.ToInt32(Session["itemID"]) + 1
                });
                Session["cart"] = cartItems;
                ViewBag.cart = cartItems.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                Session["itemID"] = Convert.ToInt32(Session["itemID"]) + 1;

            }

            return RedirectToAction("Index", "Game");
        }

        public ActionResult UserCart()
        {

            return View((List<AddToCartDto>)Session["cart"]);

        }

        public ActionResult Remove(AddToCartDto cartItem)
        {
            List<AddToCartDto> cartItems = (List<AddToCartDto>)Session["cart"];
            cartItems.RemoveAll(x => x.ID == cartItem.ID);
            Session["cart"] = cartItems;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("UserCart", "Cart");
        }

        public ActionResult ClearCart()
        {
            Session["cart"] = new List<AddToCartDto>();
            Session["count"] = 0;
            return RedirectToAction("UserCart", "Cart");
        }
    }
}