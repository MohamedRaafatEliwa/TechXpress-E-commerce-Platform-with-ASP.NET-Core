using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Models;

namespace TechXpress.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TechXpressDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(TechXpressDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges = true)
        {
            IQueryable<T> query = _dbSet;
            if (!trackChanges)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, bool trackChanges = true)
        {
            IQueryable<T> query = _dbSet;
            if (!trackChanges)
                query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T?> GetByUuidAsync(string uuid, bool trackChanges = true)
        {
            IQueryable<T> query = _dbSet;
            if (!trackChanges)
                query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync(e => e.Uuid == uuid);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task Update(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            _dbSet.Remove(entity);
        }
    }
}
