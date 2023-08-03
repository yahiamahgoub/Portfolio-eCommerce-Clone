using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataLib.Models;
using eCommerceClone.Service;
using eCommerceClone.Views;
using MvvmHelpers;

namespace eCommerceClone.ViewModels
{
	public partial class ListingsPageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
		private readonly IItemService itemService;

		public ObservableRangeCollection<ItemMini> ItemsMini { get; set; } = new ObservableRangeCollection<ItemMini>();

		[ObservableProperty]
		ItemMini selectedItem;

		public ListingsPageViewModel(IItemService _dataService)
        {
			itemService = _dataService;			

		}

		[RelayCommand]
		async Task NavigateToDetailPage()
		{
			if(SelectedItem is not null)
				await Shell.Current.GoToAsync($"///{nameof(ListingsPage)}/{nameof(ItemDetailsPage)}?ItemId={SelectedItem.ItemId}");
			else
				await Shell.Current.GoToAsync($"//{nameof(ListingsPage)}/{nameof(ItemDetailsPage)}?ItemId=1");
		}

		[RelayCommand]
		async Task FavItem()
		{
			var itemMini = SelectedItem as ItemMini;
			
			if( itemMini != null )
			{
				var favList = await itemService.GetFavListAsync(userId: 1);

				var itemListToItemJoin = new ItemListToItemJoin { ItemId = itemMini.ItemId, ItemListId = favList.ItemListId };

				var result = await itemService.AddItemToFavListAsync(userId: 1, itemMini.ItemId, itemListToItemJoin);
			}
		}


		[ObservableProperty]
		//[NotifyPropertyChangedFor(nameof(IsNotBusy))]
		bool isBusy;

		[RelayCommand]
		async Task Refresh()
		{
			IsBusy = true;

			#if DEBUG
			await Task.Delay(500);
			#endif

			ItemsMini.Clear();

			var itemsMiniDTO = await itemService.GetItemsMiniAsync();

			ItemsMini.AddRange(itemsMiniDTO);
			IsBusy = false;
			//toaster?.MakeToast("Refreshed!");
		}
    }
}
