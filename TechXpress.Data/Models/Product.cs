using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Data.Models
{
    public class Product:BaseEntity
    {
       
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required decimal Price { get; set; }

        public required string ImageUrl { get; set; }

        // FK
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        // Navigation
        public virtual Category? Category { get; set; }
    }
}
