using eCommerceClone.ViewModels;

namespace eCommerceClone.Views;

public partial class ListingsPage : ContentPage
{
	public ListingsPage(ListingsPageViewModel listingsPageViewModel)
	{
		InitializeComponent();
		BindingContext = listingsPageViewModel;		
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var vm = (ListingsPageViewModel)BindingContext;
		if (vm.ItemsMini.Count == 0)
			await vm.RefreshCommand.ExecuteAsync(null);
	}


	private void Button_Clicked(object sender, EventArgs e)
	{
		var list = collection.ItemsSource;
		return;
	}
}