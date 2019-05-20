﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
    }
}