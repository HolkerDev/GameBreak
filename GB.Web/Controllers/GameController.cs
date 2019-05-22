using GB.Data.Dto;
using GB.Web.CustomAuthentication;
using GB.Web.Logic;
using GB.Web.Models;
using GB.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GB.Web.Controllers
{
    [CustomAuthorize(Roles = "Client")]
    public class GameController : Controller
    {

        public ActionResult Index()
        {
            var data = new ApiClient().GetData<List<GameDto>>("api/game/GetAll");
            return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            CreateGame game = new CreateGame();

            return View(game);
        }

        public ActionResult Edit(CreateGame game)
        {
            return View(game);
        }

        public ActionResult ViewGame(int gameID)
        {
            var data = new ApiClient().GetData<GameDto>("api/game/Get?gameID=" + gameID);
            ViewGameVM vm = new ViewGameVM();
            vm.CreateVM(data);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(CreateGame game)
        {
            if (ModelState.IsValid)
            {
                var img = game.Image;
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(img.InputStream))
                {
                    fileData = binaryReader.ReadBytes(img.ContentLength);
                }

                var result = new ApiClient().PostData<CreateGameDto>("api/game/Post/Create", new CreateGameDto()
                {
                    Name = game.Name,
                    ReleaseDate = game.ReleaseDate,
                    ProductionID = game.ProductionID,
                    GamePlatformID = game.GamePlatformID,
                    AgeRatingID = game.AgeRatingID,
                    Price = game.Price,
                    Description = game.Description,
                    GameGenres = game.GameGenres,
                    Image = fileData
            });
                return RedirectToAction("Index");
            }

            return View(game);
        }

        public ActionResult Remove(int id)
        {
            var result = new ApiClient().PostData<int>("api/game/Post/Remove", id);
            return RedirectToAction("Index");
        }
    }
}