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

    //!  Mvc Controller GameController. 
    /*!
       Klasa GameController służy do przekierowania akcji Http na Api Controller oraz przekazania danych gier do wyświetlenia na widokach.
    */
    public class GameController : Controller
    {
        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia listy gier na widoku \Game\Index, otrzymanej z warstwy Api.
        */
        public ActionResult Index()
        {
            var data = new ApiClient().GetData<List<GameDto>>("api/game/GetAll");
            return View(data);
        }

        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia formularza do dodania nowej gry na widoku \Game\Add.
        */
        [CustomAuthorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Add()
        {
            CreateGame game = new CreateGame();

            return View(game);
        }

        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia formularza do edytowania isniejącej gry na widoku \Game\Edit.
        */
        [CustomAuthorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Edit(int gameID)
        {
            var data = new ApiClient().GetData<GameDto>("api/game/Get?gameID=" + gameID);
            if(data.Image == null)
                data.Image = new byte[] { };
            CreateGame game = new CreateGame() {
                ID = data.ID,
                AgeRatingID = data.AgeRating.ID,
                Description = data.Description,
                GamePlatformID = data.GamePlatform.ID,
                Name = data.Name,
                Price = data.Price,
                ProductionID = data.Production.ID,
                ReleaseDate = data.ReleaseDate,
                ImageBase64 = Convert.ToBase64String(data.Image)
            };

            return View(game);
        }

        //!  Akcja ActionResult typu HttpPost. 
        /*!
           Służy do przekazania danych z formularza do edytowania isniejącej gry na widoku \Game\Edit do warstwy Api.
        */
        [CustomAuthorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(CreateGame game)
        {
            if (ModelState.IsValid)
            {
               byte[] fileData = null;
                if (game.Image!= null)
                {
                    var img = game.Image;
                    
                    using (var binaryReader = new BinaryReader(img.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(img.ContentLength);
                    }
                }

                var result = new ApiClient().PostData<CreateGameDto>("api/game/Post/Update", new CreateGameDto()
                {
                    ID = game.ID,
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

        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia danych wybranej gry na widoku \Game\ViewGame, otrzymanych z warstwy Api.
        */
        [AllowAnonymous]
        public ActionResult ViewGame(int gameID)
        {
            var data = new ApiClient().GetData<GameDto>("api/game/Get?gameID=" + gameID);
            ViewGameVM vm = new ViewGameVM();
            vm.CreateVM(data);
            return View(vm);
        }

        //!  Akcja ActionResult typu HttpPost. 
        /*!
           Służy do przekazania danych z formularza do dodania nowej gry na widoku \Game\Add do warstwy Api.
        */
        [CustomAuthorize(Roles = "Administrator")]
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

        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do usunięcia wybranej gry.
        */
        [CustomAuthorize(Roles = "Administrator")]
        public ActionResult Remove(int id)
        {
            var result = new ApiClient().PostData<int>("api/game/Post/Remove", id);
            return RedirectToAction("Index");
        }
    }
}