using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataLib.Models;
using eCommerceClone.Service;
using eCommerceClone.Views;
using MvvmHelpers;

namespace eCommerceClone.ViewModels
{
	public partial class UserPageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
	{
		enum LoadList
		{
			Fav, ForSale
		}

		private readonly IItemService itemService;

		public ObservableRangeCollection<ItemMini> ItemsMini { get; set; } = new ObservableRangeCollection<ItemMini>();

		[ObservableProperty]
		ItemMini selectedItem;

		public UserPageViewModel(IItemService _itemService)
		{
			itemService = _itemService;

		}

		[RelayCommand]
		async Task NavigateToDetailPage()
		{
			if (SelectedItem is not null)
				await Shell.Current.GoToAsync($"//{nameof(UserPage)}/{nameof(ItemDetailsPage)}?ItemId={SelectedItem.ItemId}");
			else
				await Shell.Current.GoToAsync($"//{nameof(UserPage)}/{nameof(ItemDetailsPage)}?ItemId=1");
		}


		[ObservableProperty]
		//[NotifyPropertyChangedFor(nameof(IsNotBusy))]
		bool isBusy;


		[RelayCommand]
		async Task NavigateToUserInfoPage()
		{
			await Shell.Current.GoToAsync($"//{nameof(UserPage)}/{nameof(UserInfoPage)}");
		}

		[RelayCommand]
		async Task LoadFavList()
		{
			await LoadMiniItems(LoadList.Fav);
		}

		[RelayCommand]
		async Task LoadForSaleList()
		{
			await LoadMiniItems(LoadList.ForSale);
		}

		async Task LoadMiniItems(LoadList loadList)
		{
			ItemsMini.Clear();

			await Task.Delay(500);

			IEnumerable<ItemMini> itemsMiniDTO;

			if (loadList == LoadList.Fav)
				itemsMiniDTO = await itemService.GetFavItemsListAsync(userId: 1);
			else
				itemsMiniDTO = await itemService.GetForSaleItemsListAsync(userId: 1);
			
			ItemsMini.AddRange(itemsMiniDTO);		
		}
	}
}
