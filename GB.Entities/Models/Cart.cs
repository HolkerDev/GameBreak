using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }
        public string CartID { get; set; }
        [Required]
        public int GameID { get; set; }
        [Required]
        public int LocationID { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Game Game { get; set; }
        public virtual Location Location { get; set; }
    }
}

