using GB.Web.CustomAuthentication;
using GB.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace GB.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }

            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView loginView, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginView.Username, loginView.Password))
                {
                    var user = (CustomMembershipUser)Membership.GetUser(loginView.Username, false);
                    if(user != null)
                    {
                        CustomSerializeModel userModel = new Models.CustomSerializeModel()
                        {
                            UserID = user.UserID,
                            FullName = user.FullName,
                            Role = user.Role.RoleName
                        };

                        string userData = JsonConvert.SerializeObject(userModel);

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, loginView.Username, DateTime.Now, DateTime.Now.AddMinutes(15), true, userData);
                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, enTicket);
                        HttpContext.Response.Cookies.Add(authCookie);
                    }

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError("", "Username or Password invalid");
            return View(loginView);
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}