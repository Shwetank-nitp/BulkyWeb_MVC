using BulkyWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyWeb.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _dbSet = context.Set<T>();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> logic)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(logic);
            return query.FirstOrDefault();
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            _dbSet.RemoveRange(items);
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> logic)
        {
            IQueryable<T> values = _dbSet.Where(logic);
            return values.ToList();
        }
    }
}
