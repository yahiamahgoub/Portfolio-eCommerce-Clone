using AutoMapper;
using DataLib.DataStorage;
using DataLib.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

namespace DataLib.Repositories
{
	public class UserRepository : GenericRepository<User>, IUserRepository, IGenericRepository<User>
	{
		public UserRepository(AppDbContext _appDbContext) : base(_appDbContext)
		{
		}

		public async Task<IEnumerable<Address>> GetAddressListForUserAsync(int userId) =>
			await appDbContext.Addresses.Include(address => address.Country).Where(address => address.UserId == userId).ToListAsync();

		public async Task<Address?> GetAddressForUserAsync(int userId, int addressId) =>
			await appDbContext.Addresses.Include(address => address.Country).SingleOrDefaultAsync(address => address.UserId == userId && address.AddressId == addressId);

		public async Task AddAddressForUserAsync(int userId, Address Address)
		{
			var user = await GetByIdAsync(userId);
			if (user is not null)
				user.Addresses.Add(Address);
		}

		public async Task DeleteAddressForUserAsync(int userId, Address Address)
		{
			var user = await GetByIdAsync(userId);
			if (user is not null)
				user.Addresses.Remove(Address);
		}

		public async Task<User?> GetById(int userId, bool IncludeAddressList)
		=>
			!IncludeAddressList? await GetByIdAsync(userId) : 
			await appDbContext.Users
			.Include(user => user.Addresses)
			.ThenInclude(Address => Address.Country)
			.SingleOrDefaultAsync(user => user.UserId == userId);

		//System.InvalidOperationException: The expression 'Address.Country' is invalid inside an 'Include' operation, since it does not represent a property access: 't => t.MyProperty'. To target navigations declared on derived types, 
		//	use casting('t => ((Derived)t).MyProperty') or the 'as' operator ('t => (t as Derived).MyProperty').
		//	Collection navigation access can be filtered by composing Where, OrderBy(Descending), ThenBy(Descending), Skip or Take operations
		//	.For more information on including related data, see http://go.microsoft.com/fwlink/?LinkID=746393.

	}
}
