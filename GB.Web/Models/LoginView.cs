using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GB.Web.Models
{
    public class LoginView
    {
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }

    public class CustomSerializeModel
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}