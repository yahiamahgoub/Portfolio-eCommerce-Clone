using eCommerceClone.Views;

namespace eCommerceClone;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		//Routing.RegisterRoute($"{nameof(UserPage)}/{nameof(NewItemPage)}", typeof(NewItemPage));
		Routing.RegisterRoute("MainPage/ItemDetailsPage", typeof(ItemDetailsPage));
	}
}
