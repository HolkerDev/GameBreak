using GB.Web.CustomAuthentication;
using GB.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace GB.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest() {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                CustomSerializeModel userFromTicket = JsonConvert.DeserializeObject<CustomSerializeModel>(authTicket.UserData);
                Context.User = Thread.CurrentPrincipal = new CustomPrincipal(User.Identity.Name) {
                    UserID = userFromTicket.UserID,
                    FullName = userFromTicket.FullName,
                    Role = userFromTicket.Role
                };
            }
   
        }
    }
}
