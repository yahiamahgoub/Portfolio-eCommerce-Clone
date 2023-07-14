using Microsoft.EntityFrameworkCore;
using DataLib.DataStorage;
using System.Linq.Expressions;

namespace DataLib.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext appDbContext;
        public GenericRepository(AppDbContext _appDbContext) => appDbContext = _appDbContext;

        public async Task<IEnumerable<T>> GetAll() => await appDbContext.Set<T>().ToListAsync();		

        public async Task<T?> GetById(int id) => await appDbContext.Set<T>().FindAsync(id);

        public async Task AddAsync(T obj) => await appDbContext.Set<T>().AddAsync(obj);

        public async Task<bool> ExistsAsync(int id) => await GetById(id) is not null ? true : false;

        public void Delete(T obj) => appDbContext.Set<T>().Remove(obj);

        public async Task<bool> SaveChangesAsync() => await appDbContext.SaveChangesAsync() >= 0;

		protected virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
		{
			var query = appDbContext.Set<T>().Where(predicate);
			return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}
	}
}
