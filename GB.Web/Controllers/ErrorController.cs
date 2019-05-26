using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Web.Controllers
{
    //!  Mvc Controller AccountController. 
    /*!
       Klasa AccountController służy do wyświetlenia błędów na widoku.
    */
    public class ErrorController : Controller
    {
        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia błędu na widoku \Error\Index.
        */
        public ActionResult Index()
        {
            return View();
        }
    }
}