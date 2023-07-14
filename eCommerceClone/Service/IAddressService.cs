using DataLib.Models;

namespace eCommerceClone.Service
{
	public interface IAddressService
	{
		Task<IEnumerable<Address>> GetAddressesForUser(int userId);
	}
}