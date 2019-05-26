using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    //!  Model ProductionGamePlatform. 
    /*!
      Atrybuty klasy reprezentują pola oraz relacje tabeli ProductionGamePlatform z bazy danych. 
    */
    public class ProductionGamePlatform
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        
        [Required]
        public int GamePlatformID { get; set; }

        [Required]
        public int ProductionID { get; set; }

        public virtual GamePlatform GamePlatform { get; set; }
        public virtual Production Production { get; set; }

    }
}
