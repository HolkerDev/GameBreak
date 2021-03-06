﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    //!  Klasa DTO Role. 
    /*!
       Klasa, która służy do transferu danych modelu Role pomiędzy warstwą MVC a Api.
    */
    public class RoleDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
