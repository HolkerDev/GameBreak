using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    //!  Klasa DTO AgeRating. 
    /*!
       Klasa, która służy do transferu danych modelu GameCopyStatus pomiędzy warstwą MVC a Api.
    */
    public class GameCopyStatusDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
