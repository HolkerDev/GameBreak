using GB.Data.Dto;
using GB.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: AddToCart  
        [HttpPost]
        public ActionResult Add(ViewGameVM vm)
        {

            if (Session["cart"] == null)
            {
                List<AddToCartDto> gamesInCart = new List<AddToCartDto>();
                gamesInCart.Add( new AddToCartDto {
                    GameID = vm.Game.ID,
                    GameName = vm.Game.Name,
                    LocationID = Convert.ToInt32(vm.Game.LocationChosenID),
                    LocationName = vm.Game.LocationsWithGameCopiesAvailable.Where(x=>x.ID == Convert.ToInt32(vm.Game.LocationChosenID)).Select(x=>x.Name).First(),
                    UserID = 1,
                    Price = vm.Game.Price
                });
                Session["cart"] = gamesInCart;
                ViewBag.cart = gamesInCart.Count();
                Session["count"] = 1;
            }
            else
            {
                List<AddToCartDto> gamesInCart = (List<AddToCartDto>)Session["cart"];
                gamesInCart.Add(new AddToCartDto
                {
                    GameID = vm.Game.ID,
                    GameName = vm.Game.Name,
                    LocationID = Convert.ToInt32(vm.Game.LocationChosenID),
                    LocationName = vm.Game.LocationsWithGameCopiesAvailable.Where(x => x.ID == Convert.ToInt32(vm.Game.LocationChosenID)).Select(x => x.Name).First(),
                    UserID = 1,
                    Price = vm.Game.Price
                });
                Session["cart"] = gamesInCart;
                ViewBag.cart = gamesInCart.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }

            return RedirectToAction("Index", "Game");
        }

        public ActionResult UserCart()
        {

            return View((List<AddToCartDto>)Session["cart"]);

        }
    }
}