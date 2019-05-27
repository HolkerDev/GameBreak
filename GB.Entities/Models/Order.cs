using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    //!  Model Order. 
    /*!
      Atrybuty klasy reprezentują pola oraz relacje tabeli Order z bazy danych. 
    */
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public DateTime? IsFinishedAt { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<OrderGameCopy> OrderGameCopies { get; set; } = new List<OrderGameCopy>();
    }
}
