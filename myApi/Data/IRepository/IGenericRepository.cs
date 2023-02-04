using System.Linq.Expressions;
using Data.Entities;
namespace Data.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null);
        Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
