using DataLib.Models;

namespace eCommerceClone.UserControls;

public class ItemSearchHandler : SearchHandler
{

	public IList<ItemMini> ItemsMini
	{
		get { return (IList<ItemMini>)GetValue(ItemsMiniProperty); }
		set { SetValue(ItemsMiniProperty, value); }
	}

	// Using a BindableProperty as the backing store for ItemName.  This enables animation, styling, binding, etc...
	public static readonly BindableProperty ItemsMiniProperty =
		BindableProperty.CreateAttached("ItemsMini", typeof(IList<ItemMini>), typeof(ItemSearchHandler), null);

	public Type SelectedItemNavigationTarget { get; set; }
	protected override void OnQueryChanged(string oldValue, string newValue)
	{
		base.OnQueryChanged(oldValue, newValue);

		if (string.IsNullOrWhiteSpace(newValue))
		{
			ItemsSource = null;
		}
		else
		{
			ItemsSource = ItemsMini
				.Where(item => item.ItemName.Contains(newValue,StringComparison.CurrentCultureIgnoreCase))
				.ToList();
		}
	}
	protected override async void OnItemSelected(object item)
	{

		base.OnItemSelected(item);

		// Let the animation complete
		await Task.Delay(1000);

		var selectedItem = item as ItemMini;

		//ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
		// The following route works because route names are unique in this app.
		// await Shell.Current.GoToAsync($"{GetNavigationTarget()}?name={((Animal)item).Name}");

		await Shell.Current.GoToAsync($"//MainPage/ItemDetailsPage?ItemId={selectedItem.ItemId}");
	}

	//string GetNavigationTarget()
	//{
	//	return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
	//}
}