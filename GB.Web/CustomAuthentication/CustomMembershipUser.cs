﻿using GB.Entities.Models;
using GB.Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace GB.Web.CustomAuthentication
{
    //!  Klasa CustomMembershipUser. 
    /*!
       Realizuje klasę abstrakcyjną MembershipUser.
    */
    public class CustomMembershipUser : MembershipUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DARole Role { get; set; }

        public CustomMembershipUser(DAUser daUser) : base("CustomMembership", daUser.Username, daUser.UserID, daUser.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserID = daUser.UserID;
            FirstName = daUser.FirstName;
            LastName = daUser.LastName;
            Role = new DARole()
            {
                RoleId = daUser.RoleID,
                RoleName = daUser.Role.RoleName
            };
        }
    }
}