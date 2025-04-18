using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Data.Models
{
    public class Order:BaseEntity
    {
        [ForeignKey(nameof(AppUser))]
        public required string UserId { get; set; } // FK from Identity

        public AppUser? User { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }

        public required ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
