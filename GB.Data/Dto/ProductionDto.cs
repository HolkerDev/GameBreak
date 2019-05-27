using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    //!  Klasa DTO Production. 
    /*!
       Klasa, która służy do transferu danych modelu Production pomiędzy warstwą MVC a Api.
    */
    public class ProductionDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
