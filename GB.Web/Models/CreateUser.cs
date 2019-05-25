using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GB.Web.Models
{
    public class CreateUser
    {
        public int ID { get; set; }

        [DisplayName("Username")]
        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [DisplayName("Birth Date")]
        [Required]
        public DateTime BirthDate { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        [MinLength(8)]
        public string PhoneNumber { get; set; }

        [DisplayName("Role")]
        [Required]
        public int RoleID { get; set; }


    }
}