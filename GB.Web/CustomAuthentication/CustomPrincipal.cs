﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace GB.Web.CustomAuthentication
{
    //!  Klasa CustomPrincipal. 
    /*!
       Realizuje interfejs IPrincipal oraz metody IsInRole i konstruktor z parametrem username.
    */
    public class CustomPrincipal : IPrincipal
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (Role == role)
                return true;
            else
                return false;
        }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }
    }
}