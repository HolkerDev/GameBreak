using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    //!  Klasa DTO GameCopy. 
    /*!
       Klasa, która służy do transferu danych modelu GameCopy pomiędzy warstwą MVC a Api.
    */
    public class GameCopyDto
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int GameCopyStatusID { get; set; }
        public int? UserID { get; set; }
        public int LocationID { get; set; }

        public GameDto Game { get; set; }
        public GameCopyStatusDto GameCopyStatus { get; set; }
        public UserDto User { get; set; }
        public LocationAvailableDto Location { get; set; }
    }
}
