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
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public String Uuid { get; set; } = Guid.NewGuid().ToString();

    }
}
