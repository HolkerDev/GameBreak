using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Models
{
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
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(RoleID))]
        public virtual Role Role { get; set; }

        public virtual ICollection<GameCopy> GameCopies { get; set; } = new List<GameCopy>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
