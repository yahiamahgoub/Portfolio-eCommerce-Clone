using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataLib.Models;
using eCommerceClone.Service;

namespace eCommerceClone.ViewModels
{
	public partial class UserInfoPageViewModel : ObservableObject
	{
		private readonly IUserService userService;
		private readonly IMapper mapper;

		public UserInfoPageViewModel(IUserService _userService, IMapper mapper)
		{
			userService = _userService;
			this.mapper = mapper;
		}

		[ObservableProperty]
		UserForRead user;
		
		//[ObservableProperty]
		//int userId;

		//[ObservableProperty]
		//string firstName;

		//[ObservableProperty]
		//string lastName;

		//[ObservableProperty]
		//string phoneNumber;

		//[ObservableProperty]
		//byte[] profileImage;

		[RelayCommand]
		public async Task LoadUserInfo()
		{
			User = await userService.GetUserAsync(userId:1);
			//FirstName = user.FirstName;
			//LastName = user.LastName;
			//PhoneNumber = user.PhoneNumber;
			//ProfileImage = user.ProfileImage.ImageBytes;
		}

		[RelayCommand]
		public async Task UpdateUserInfo()
		{
			await userService.UpdateUserAsync(User.UserId, mapper.Map<UserForUpdate>(User));
			//await userService
			//	.UpdateUserAsync(user.UserId, new UserForUpdate 
			//	{ UserId = UserId, FirstName = FirstName, LastName = LastName, PhoneNumber = PhoneNumber, ProfileImage = ProfileImage});
		}
	}
}
