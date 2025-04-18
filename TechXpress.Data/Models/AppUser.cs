using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Data.Models
{
    [Index(nameof(Uuid), IsUnique = true)]
    public class AppUser :IdentityUser<int>
    {
        public string Uuid { get; set; } = Guid.NewGuid().ToString();

    }
}
