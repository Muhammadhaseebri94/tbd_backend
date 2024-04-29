using Data_Access.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data_Access.Generic_Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity); 
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query;
                query = _dbSet.AsQueryable().AsNoTracking();
            query = query.Where(filter);
            return query.FirstOrDefault();

        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter)
        {
            IQueryable<T> query = _dbSet.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
