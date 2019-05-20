using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    public class GameCopy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        public int GameID { get; set; }
        public int GameCopyStatusID { get; set; }
        public int? UserID { get; set; }
        public int LocationID { get; set; }

        public virtual Game Game { get; set; }
        public virtual GameCopyStatus GameCopyStatus { get; set; }
        public virtual User User { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<OrderGameCopy> OrderGameCopies { get; set; }
    }
}
