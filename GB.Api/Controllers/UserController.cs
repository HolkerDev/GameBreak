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
    //!  Api Controller UserController. 
    /*!
       Klasa do opracowania przesłanych akcji HTTP w związku z działaniami na modelu User.
    */
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserService userService;

        //! Konstruktor klasy UserController. 
        /*!
          Konstruktor klasy UserController, z inicjalizacją serwisu UserService.
        */
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        //!  Akcja Get. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu UserService zwraca użytkownika z ID, przekazanym jako parametr.
        */
        [Route("Get")]
        [HttpGet]
        public IHttpActionResult Get(int userID)
        {
            return Json(userService.Get(userID));
        }

        //!  Akcja GetAll. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu UserService zwraca wszystkich użytkowników w systemie.
        */
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(userService.GetAll());
        }

        //!  Akcja Create. 
        /*!
          Akcja typu HttpPost, używająć metody serwisu CreateService, zapisuje nowego użytkownika do bazy oraz zwraca wynik.
        */
        [HttpPost]
        [Route("Post/Create")]
        public IHttpActionResult Create([FromBody] UserDto user)
        {
            userService.AddUser(user);
            return Json(true);
        }

        //!  Akcja Remove. 
        /*!
          Akcja typu HttpPost, używająć metody serwisu UserService, usuwa użytkownika z przesłanym ID z bazy danych.
        */
        [HttpPost]
        [Route("Post/Remove")]
        public IHttpActionResult Remove([FromBody] int id)
        {
            userService.Remove(id);
            return Json(true);
        }
    }
}