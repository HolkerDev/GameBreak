﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
    //!  Model User. 
    /*!
      Atrybuty klasy reprezentują pola oraz relacje tabeli User z bazy danych. 
    */
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [Required]
        public int RoleID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<GameCopy> GameCopies { get; set; } = new List<GameCopy>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
