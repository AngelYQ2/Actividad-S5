using System.Linq.Expressions;
using ActividadS5.Models;
using ActividadS5.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ActividadS5.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Actividads5Context _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(Actividads5Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}