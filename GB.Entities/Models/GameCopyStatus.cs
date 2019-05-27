using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    //!  Model GameCopyStatus. 
    /*!
      Atrybuty klasy reprezentują pola oraz relacje tabeli GameCopyStatus z bazy danych. 
    */
    public class GameCopyStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<GameCopy> GameCopies { get; set; } = new List<GameCopy>();
    }
}
