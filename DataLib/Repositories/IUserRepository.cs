using DataLib.Models;

namespace DataLib.Repositories
{
	public interface IUserRepository : IGenericRepository<User>
	{
		Task AddAddressForUserAsync(int userId, Address Address);
		
		Task<User?> GetById(int userId, bool includeAddressList);
		
		Task<IEnumerable<Address>> GetAddressListForUserAsync(int userId);
		
		Task<Address?> GetAddressForUserAsync(int userId, int addressId);
		
		Task DeleteAddressForUserAsync(int userId, Address Address);		
	}
}