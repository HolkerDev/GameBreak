using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Web.DataAccess
{
    //!  Klasa DARole. 
    /*!
       Zawiera dane, niezbędne do identyfikacji roli przy walidacji oraz autoryzacji użytkownika.
    */
    public class DARole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}