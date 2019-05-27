using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    //!  Model AgeRating. 
    /*!
      Atrybuty klasy reprezentują pola oraz relacje tabeli AgeRating z bazy danych. 
    */
    public class AgeRating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
