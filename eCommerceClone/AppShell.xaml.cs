using eCommerceClone.Views;

namespace eCommerceClone;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		//Routing.RegisterRoute($"{nameof(UserPage)}/{nameof(NewItemPage)}", typeof(NewItemPage));
		Routing.RegisterRoute($"{nameof(ListingsPage)}/{nameof(ItemDetailsPage)}", typeof(ItemDetailsPage));
		Routing.RegisterRoute($"{nameof(UserPage)}/{nameof(ItemDetailsPage)}", typeof(ItemDetailsPage));
		Routing.RegisterRoute($"{nameof(UserPage)}/{nameof(UserInfoPage)}", typeof(UserInfoPage));
	}
}
