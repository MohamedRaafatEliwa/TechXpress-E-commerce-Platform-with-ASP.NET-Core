using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Data.Models
{
    public class Brand : BaseEntity
    {
        public required string Name { get; set; }
        public string? LogoUrl { get; set; }


        // Navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
