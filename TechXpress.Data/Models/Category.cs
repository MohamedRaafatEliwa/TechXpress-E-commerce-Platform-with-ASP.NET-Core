using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Data.Models
{
    public class Category:BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public bool IsDeleted { get; set; } = false;


        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}
