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
		Item currentItem;

		[ObservableProperty]
		User user;

		[ObservableProperty]
		Category category;	
        
		[RelayCommand]
		async Task Load()
		{
			//should get from global store somehow
			var currentUser = 1;

			CurrentItem = await itemService.GetItemAsync(ItemId, currentUser);
			//User = await userService.GetUserAsync(CurrentItem.userid);
			User = CurrentItem.ItemListToItemJoin
				.Single(itemListJoin => itemListJoin.ItemList.ItemListType == ItemListType.ForSaleByUser)
				.ItemList.User;			
			Category = await categoryService.GetCategoryAsync(CurrentItem.CategoryId);
		}

		[RelayCommand]
		async Task Back()
		{
			await Shell.Current.GoToAsync("MainPage");
		}
	}
}
