using GB.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GB.Api.Controllers
{
    //!  Api Controller RoleController. 
    /*!
       Klasa do opracowania przesłanych akcji HTTP w związku z działaniami na modelu Role.
    */
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        private readonly IRoleService roleService;

        //! Konstruktor klasy RoleController. 
        /*!
          Konstruktor klasy RoleController, z inicjalizacją serwisu RoleService.
        */
        public RoleController(RoleService roleService)
        {
            this.roleService = roleService;
        }

        //!  Akcja GetAll. 
        /*!
          Akcja typu HttpGet, używająć metody serwisu RoleService zwraca wszystkie role w systemie.
        */
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(roleService.GetAll());
        }
    }
}