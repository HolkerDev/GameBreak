using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    public class UserDto
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
        public List<GameCopyDto> GameCopies { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
}
