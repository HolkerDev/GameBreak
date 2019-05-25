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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [Route("Get")]
        [HttpGet]
        public IHttpActionResult Get(int userID)
        {
            return Json(userService.Get(userID));
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(userService.GetAll());
        }

        [HttpPost]
        [Route("Post/Create")]
        public IHttpActionResult Create([FromBody] UserDto user)
        {
            userService.AddUser(user);
            return Json(true);
        }


        [HttpPost]
        [Route("Post/Remove")]
        public IHttpActionResult Remove([FromBody] int id)
        {
            userService.Remove(id);
            return Json(true);
        }
    }
}