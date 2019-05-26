using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    //!  Klasa DTO AgeRating. 
    /*!
       Klasa, która służy do transferu danych modelu Game pomiędzy warstwą MVC a Api.
    */
    public class GameDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ProductionDto Production { get; set; }
        public GamePlatformDto GamePlatform { get; set; }
        public AgeRatingDto AgeRating { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public List<GameGenreDto> GameGenres { get; set; }
        public List<GameCopyDto> GameCopies { get; set; }
        public List<LocationAvailableDto> LocationsWithGameCopiesAvailable { get; set; }
        public string LocationChosenID { get; set; }
    }
}
