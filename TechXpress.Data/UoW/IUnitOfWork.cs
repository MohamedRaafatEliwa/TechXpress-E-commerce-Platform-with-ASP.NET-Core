using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Models;
using TechXpress.Data.Repositories;

namespace TechXpress.Data.UoW
{
    public interface IUnitOfWork
    {
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<OrderDetail> OrderDetails { get; }

        Task<int> SaveAsync();
    }
}
