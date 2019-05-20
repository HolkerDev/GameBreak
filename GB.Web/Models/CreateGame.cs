using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GB.Data.Dto;
using GB.Entities.Models;

namespace GB.Web.Models
{
    public class CreateGame
    {
        public int ID { get; set; }

        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Production")]
        [Required]
        public int ProductionID { get; set; }

        [DisplayName("Game Platform")]
        [Required]
        public int GamePlatformID { get; set; }

        [DisplayName("Age Rating")]
        [Required]
        public int AgeRatingID { get; set; }

        [DisplayName("Price")]
        [Required]
        public decimal Price { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Image")]
        public HttpPostedFileBase Image { get; set; }

        [DisplayName("GameGenres")]
        [Required]
        public List<int> GameGenres { get; set; }
    }
}