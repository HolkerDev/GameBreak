using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    //!  Klasa DTO AddToCart. 
    /*!
       Klasa, która służy do transferu danych modelów User, Game oraz Location w ramach warstwy MVC projektu GB.Web.
    */
    public class AddToCartDto
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public string GameName { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public decimal Price { get; set; }
        public int UserID { get; set; }
    }
}
