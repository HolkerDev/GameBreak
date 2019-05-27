using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    //!  Model OrderGameCopy. 
    /*!
      Atrybuty klasy reprezentują pola oraz relacje tabeli OrderGameCopy z bazy danych. 
    */
    public class OrderGameCopy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        public int GameCopyID { get; set; }

        public int OrderID { get; set; }

        public virtual GameCopy GameCopy { get; set; }
        public virtual Order Order { get; set; }
    }
}
