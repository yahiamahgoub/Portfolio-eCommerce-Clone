using eCommerceClone.ViewModels;

namespace eCommerceClone.Views;


[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class ItemDetailsPage : ContentPage
{
	int itemId;
	public int ItemId
	{
		get => itemId;
		set
		{
			itemId = value;
			OnPropertyChanged();
		}
	}

	public ItemDetailsPage(ItemDetailsPageViewModel vm)
	{
		InitializeComponent();				
		BindingContext = vm;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var vm = (ItemDetailsPageViewModel)BindingContext;
		vm.ItemId = ItemId;
		await vm.LoadCommand.ExecuteAsync(null);		
	}
}