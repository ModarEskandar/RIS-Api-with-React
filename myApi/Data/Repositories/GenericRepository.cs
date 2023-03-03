using System.Linq.Expressions;
using Data.Entities;
using Data.IRepository;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly RISDbContext _context;
        protected readonly DbSet<T> _db;
        public GenericRepository(RISDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);

        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> queryable = _db;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    queryable = queryable.Include(include);
                }
            }
            // if (expression != null)
            // {
            //     queryable = queryable.Where(expression);
            // }
            return await queryable.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> queryable = _db;
            if (expression != null)
            {
                queryable = queryable.Where(expression);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    queryable = queryable.Include(include);
                }
            }
            if (orderBy != null)
            {
                queryable = orderBy(queryable);
            }

            return await queryable.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<T>> GetAll(RequestParams requestParams, List<string> includes = null)
        {
            IQueryable<T> queryable = _db;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    queryable = queryable.Include(include);
                }
            }
            return await queryable.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        }

        public async Task<T> GetById(int id)
        {
            return await _db.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

        }
    }
}