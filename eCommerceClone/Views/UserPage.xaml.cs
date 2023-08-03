using eCommerceClone.ViewModels;

namespace eCommerceClone.Views;

public partial class UserPage : ContentPage
{
	public UserPage(UserPageViewModel _userPageViewModel)
	{
		InitializeComponent();
		BindingContext = _userPageViewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var vm = (UserPageViewModel)BindingContext;
		if (vm.ItemsMini.Count == 0)
			await vm.LoadForSaleListCommand.ExecuteAsync(null);
	}
}