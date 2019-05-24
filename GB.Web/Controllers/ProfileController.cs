using GB.Web.CustomAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Web.Controllers
{
    [CustomAuthorize(Roles = "Client")]
    public class ProfileController : Controller
    {

    }
}