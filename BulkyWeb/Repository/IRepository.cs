using System.Linq.Expressions;

namespace BulkyWeb.Repository
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll ();
        T GetFirstOrDefault(Expression<Func<T, bool>> logic);
        IEnumerable<T> Search(Expression<Func<T , bool>> logic);
        void Add (T item);
        void Remove (T item);
        void RemoveRange(IEnumerable<T> items);
    }
}
