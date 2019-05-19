using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int ProductionID { get; set; }
        public int GamePlatformID { get; set; }
        public int AgeRatingID { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual Production Production { get; set; }
        public virtual GamePlatform GamePlatform { get; set; }
        public virtual AgeRating AgeRating { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<GameGenre> GameGenres { get; set; }

        public virtual ICollection<GameCopy> GameCopies { get; set; }

    }
}
