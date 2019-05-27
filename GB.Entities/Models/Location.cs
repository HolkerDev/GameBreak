using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    //!  Model Location. 
    /*!
      Atrybuty klasy reprezentują pola oraz relacje tabeli Location z bazy danych. 
    */
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual ICollection<GameCopy> GameCopies { get; set; } = new List<GameCopy>();
    }
}
