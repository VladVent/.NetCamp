using BlackJack.DAL.Models;
using System.Linq.Expressions;

namespace BlackJack.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        T Create(T item);
        T FindById(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        void Remove(T item);
        void Remove(int item);
        void RemoveRange(IEnumerable<T> item);
        void Update(T item);
        void Update(SessionDB session);
    }
}