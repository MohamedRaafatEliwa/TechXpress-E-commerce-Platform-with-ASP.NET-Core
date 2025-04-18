using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Models;

namespace TechXpress.Data.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(bool trackChanges = true);
        Task<T?> GetByIdAsync(int id , bool trackChanges = true);
        Task<T?> GetByUuidAsync(string Uuid, bool trackChanges = true);
        Task AddAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task DeleteAsync(int id);
    }
}
