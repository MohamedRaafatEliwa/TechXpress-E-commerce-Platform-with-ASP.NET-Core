using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Data.Models
{
    [Index(nameof(Uuid), IsUnique = true)]
    public class AppUser :IdentityUser<int>
    {
        public string Uuid { get; set; } = Guid.NewGuid().ToString();

        
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Address { get; set; }
        public string? ProfileImageUrl { get; set; }

        public ICollection<Order>? Orders { get; set; } = new List<Order>();

    }
}
