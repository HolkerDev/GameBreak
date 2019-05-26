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
    public class UserController : Controller
    {

        // GET: User
        [CustomAuthorize(Roles="Administrator")]
        public ActionResult Index()
        {
            var data = new ApiClient().GetData<List<UserDto>>("api/user/GetAll");
            
            return View(data);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Add()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Account", new { area = ""});
            CreateUser user = new CreateUser();

            return View(user);
        }

        [CustomAuthorize(Roles = "Client")]
        public ActionResult Edit(CreateUser user)
        {
            return View(user);
        }

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

        public ActionResult Remove(int id)
        {
            var result = new ApiClient().PostData<int>("api/user/Post/Remove", id);
            return RedirectToAction("Index");
        }
    }
}