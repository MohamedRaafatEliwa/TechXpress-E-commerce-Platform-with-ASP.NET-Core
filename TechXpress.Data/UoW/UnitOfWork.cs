using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Models;
using TechXpress.Data.Repositories;

namespace TechXpress.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechXpressDbContext _context;



        private IGenericRepository<Category>? _categories;
        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);

        
        private IGenericRepository<Product>? _products;
        public IGenericRepository<Product> Products => _products ??= new GenericRepository<Product>(_context);

        
        private IGenericRepository<Order>? _orders;
        public IGenericRepository<Order> Orders => _orders ??= new GenericRepository<Order>(_context);

       
        private IGenericRepository<OrderDetail>? _orderDetails;
        public IGenericRepository<OrderDetail> OrderDetails => _orderDetails ??= new GenericRepository<OrderDetail>(_context);


        public UnitOfWork(TechXpressDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
