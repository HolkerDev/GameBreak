using GB.Data.Dto;
using GB.Data.Services;
using GB.Entities.Models;
using GB.Web.CustomAuthentication;
using GB.Web.Logic;
using GB.Web.Models;
using GB.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Web.Controllers
{
    //!  Mvc Controller UserController. 
    /*!
       Klasa UserController służy do przekierowania akcji Http na Api Controller oraz przekazania danych użytkowników do wyświetlenia na widokach.
    */
    public class UserController : Controller
    {
        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia listy użytkowników na widoku \User\Indexs, otrzymanej z warstwy Api.
        */
        [CustomAuthorize(Roles="Administrator")]
        public ActionResult Index()
        {
            var data = new ApiClient().GetData<List<UserDto>>("api/user/GetAll");
            
            return View(data);
        }

        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia formularza dodania nowego użytkownika na widoku \User\Add.
        */
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Add()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Account", new { area = ""});
            CreateUser user = new CreateUser();

            return View(user);
        }

        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia formularza edytowania istniejącego użytkownika na widoku \User\Edit.
        */
        [CustomAuthorize(Roles = "Client")]
        [HttpGet]
        public ActionResult Edit(int userID)
        {
            var data = new ApiClient().GetData<UserDto>("api/order/Get?orderID=" + userID);
            return View(data);
        }

        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do przekazania danych z formularza dodania nowego użytkownika na widoku \User\Add do warstwy Api.
        */
        [HttpPost]
        public ActionResult Add(CreateUser user)
        {
            user.RoleID = 2;
            if (ModelState.IsValid)
            {
                var result = new ApiClient().PostData<UserDto>("api/user/Post/Create", new UserDto()
                {
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber,
                    RoleID = user.RoleID,
                    BirthDate = user.BirthDate
                });
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            return View(user);
        }

        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do przekazania danych z formularza edycji istniejącego użytkownika na widoku \User\Edit do warstwy Api.
        */
        [HttpPost]
        public ActionResult Edit(CreateUser user)
        {
            user.RoleID = 2;
            if (ModelState.IsValid)
            {
                var result = new ApiClient().PostData<UserDto>("api/user/Post/Update", new UserDto()
                {
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber,
                    RoleID = user.RoleID,
                    BirthDate = user.BirthDate
                });
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            return View(user);
        }

        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do przekazania polecenia o usunięciu użytkownika o podany ID.
        */
        public ActionResult Remove(int id)
        {
            var result = new ApiClient().PostData<int>("api/user/Post/Remove", id);
            return RedirectToAction("Index");
        }
    }
}