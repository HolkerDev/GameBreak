using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Dto
{
    public class OrderDto
    {
        public int ID { get; set; }
        public List<OrderGameCopyDto> OrderGameCopies { get; set; }
        public int UserID { get; set; }
        public UserDto User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? IsFinishedAt { get; set; }

    }
}
