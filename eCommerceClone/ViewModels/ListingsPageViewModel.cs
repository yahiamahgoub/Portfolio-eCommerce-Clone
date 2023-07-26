using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataLib.Models;
using eCommerceClone.Service;
using MvvmHelpers;

namespace eCommerceClone.ViewModels
{
	public partial class ListingsPageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
		private readonly IItemService dataService;

		public ObservableRangeCollection<ItemMini> ItemsMini { get; set; } = new ObservableRangeCollection<ItemMini>();

		[ObservableProperty]
		ItemMini selectedItem;

		public ListingsPageViewModel(IItemService _dataService)
        {
			dataService = _dataService;			

		}

		[RelayCommand]
		async Task NavigateToDetailPage()
		{
			if(SelectedItem is not null)
				await Shell.Current.GoToAsync($"///MainPage/ItemDetailsPage?ItemId={SelectedItem.ItemId}");
			else
				await Shell.Current.GoToAsync($"//MainPage/ItemDetailsPage?ItemId=1");
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

			var coffees = await dataService.GetItemsMini();

			ItemsMini.AddRange(coffees);
			IsBusy = false;
			//toaster?.MakeToast("Refreshed!");
		}
    }
}
