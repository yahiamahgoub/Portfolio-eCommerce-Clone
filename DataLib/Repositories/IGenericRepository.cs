using System.Linq.Expressions;

namespace DataLib.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T obj);
        void Delete(T obj);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task<bool> SaveChangesAsync();		
	}
}