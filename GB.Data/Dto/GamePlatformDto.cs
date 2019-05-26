using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    //!  Klasa DTO GamePlatform. 
    /*!
       Klasa, która służy do transferu danych modelu GamePlatform pomiędzy warstwą MVC a Api.
    */
    public class GamePlatformDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
