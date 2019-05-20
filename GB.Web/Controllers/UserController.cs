﻿using GB.Data.Dto;
using GB.Data.Services;
using GB.Entities.Models;
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
        public ActionResult Index()
        {
            var data = new ApiClient().GetData<List<UserDto>>("api/user/GetAll");
            
            return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            CreateUser user = new CreateUser();

            return View(user);
        }

        public ActionResult Edit(CreateUser user)
        {
            return View(user);
        }

        [HttpPost]
        public ActionResult Add(CreateUser user)
        {
            if (ModelState.IsValid)
            {
                var result = new ApiClient().PostData<UserDto>("api/user/Post/Create", new UserDto()
                {
                    Username = user.Username,
                    FullName = user.FullName,
                    Email = user.Email,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber,
                    RoleID = user.RoleID,
                    BirthDate = user.BirthDate
                });
                return RedirectToAction("Index");
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