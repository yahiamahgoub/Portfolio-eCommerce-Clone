using eCommerceClone.ViewModels;

namespace eCommerceClone.Views;

public partial class UserInfoPage : ContentPage
{
	private readonly UserInfoPageViewModel userInfoPageViewModel;

	public UserInfoPage(UserInfoPageViewModel userInfoPageViewModel)
	{
		InitializeComponent();
		this.userInfoPageViewModel = userInfoPageViewModel;
		BindingContext = userInfoPageViewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		var vm = (UserInfoPageViewModel)BindingContext;

		await vm.LoadUserInfoCommand.ExecuteAsync(null);
	}
}