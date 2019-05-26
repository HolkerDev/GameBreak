using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Web.Controllers
{
    //!  Mvc Controller HomeController. 
    /*!
        Klasa HomeController służy do przekierowania akcji Http na Api Controller oraz przekazania danych do wyświetlenia na widokach.
    */
    public class HomeController : Controller
    {
        //!  Akcja ActionResult typu HttpGet. 
        /*!
           Służy do wyświetlenia strony głównej na widoku \Home\Index.
        */
        public ActionResult Index()
        {
            return View();
        } 
    }
}