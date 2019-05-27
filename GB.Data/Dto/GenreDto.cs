using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    //!  Klasa DTO Genre. 
    /*!
       Klasa, która służy do transferu danych modelu Genre pomiędzy warstwą MVC a Api.
    */
    public class GenreDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
