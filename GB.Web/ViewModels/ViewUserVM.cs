﻿using GB.Data.Dto;
using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Web.ViewModels
{
    //!  Klasa ViewUserVM. 
    /*!
       Klasa typu ViewModel, reprezentująca dane do wyświetlenia użytkownika.
    */
    public class ViewUserVM
    {
        public UserDto User { get; set; }

    }
}
