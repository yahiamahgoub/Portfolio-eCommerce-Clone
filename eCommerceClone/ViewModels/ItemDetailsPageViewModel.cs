using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataLib.Models;
using eCommerceClone.Service;
using MvvmHelpers;
using System.Linq;

namespace eCommerceClone.ViewModels
{
	public partial class ItemDetailsPageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
		private readonly IItemService itemService;
		private readonly IUserService userService;
		private readonly ICategoryService categoryService;

		public ItemDetailsPageViewModel(IItemService itemService, IUserService userService, ICategoryService categoryService)
		{
			this.itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
			this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
			this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
		}

        public int ItemId { get; set; }

        [ObservableProperty]
		Item item;

		[ObservableProperty]
		User user;

		[ObservableProperty]
		Category category;	
        
		[RelayCommand]
		async Task Load()
		{
			Item = await itemService.GetItem(ItemId);
			User = await userService.GetUserAsync(Item.UserId);
			Category = await categoryService.GetCategoryAsync(Item.CategoryId);
		}

		[RelayCommand]
		async Task Back()
		{
			await Shell.Current.GoToAsync("MainPage");
		}
	}
}
