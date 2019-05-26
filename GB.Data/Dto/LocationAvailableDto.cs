using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    //!  Klasa DTO LocationAvailable. 
    /*!
       Klasa, która służy do transferu danych modelu Location pomiędzy warstwą MVC a Api.
    */
    public class LocationAvailableDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
