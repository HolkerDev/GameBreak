using GB.Data.Dto;
using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Web.DataAccess
{
    //!  Klasa DAUser. 
    /*!
       Zawiera dane, niezbędne do identyfikacji użytkownika przy walidacji oraz autoryzacji jego danych.
    */
    public class DAUser
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public virtual DARole Role { get; set; }
    }
}