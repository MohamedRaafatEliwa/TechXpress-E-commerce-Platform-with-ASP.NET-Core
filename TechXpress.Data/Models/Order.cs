using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Enums;

namespace TechXpress.Data.Models
{
    public class Order:BaseEntity
    {
        [ForeignKey(nameof(AppUser))]
        public required int UserId { get; set; } // FK from Identity
        public required string ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public AppUser? User { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;


        public required ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
