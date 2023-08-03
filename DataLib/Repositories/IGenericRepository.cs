using System.Linq.Expressions;

namespace DataLib.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T obj);
        void Delete(T obj);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<bool> SaveChangesAsync();		
	}
}