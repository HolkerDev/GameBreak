using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    //!  Model GameGenre. 
    /*!
      Atrybuty klasy reprezentują pola oraz relacje tabeli GameGenre z bazy danych. 
    */
    public class GameGenre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [Required]
        public int GameID { get; set; }

        [Required]
        public int GenreID { get; set; }

        public virtual Game Game { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
