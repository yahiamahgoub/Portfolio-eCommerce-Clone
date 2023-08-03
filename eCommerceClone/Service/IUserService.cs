using DataLib.Models;

namespace eCommerceClone.Service
{
	public interface IUserService
	{
		Task<UserForRead> GetUserAsync(int userId);

		Task<UserForRead> AddUserAsync(UserForAdd user);

		Task<UserForRead> UpdateUserAsync(int userId, UserForUpdate user);
	}
}
