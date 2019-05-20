using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    public class Production
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
        public virtual ICollection<ProductionGamePlatform> ProductionGamePlatforms { get; set; } = new List<ProductionGamePlatform>();

    }
}
