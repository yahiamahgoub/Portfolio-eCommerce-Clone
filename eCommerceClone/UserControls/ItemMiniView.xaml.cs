using eCommerceClone.ViewModels;

namespace eCommerceClone.UserControls;

public partial class ItemMiniView : ContentView
{
	private readonly ItemMiniViewModel itemMiniViewModel;

	public ItemMiniView()
	{
		InitializeComponent();
		itemMiniViewModel = new ItemMiniViewModel();
		BindingContext = this;		
	}

	public string ItemName
	{
		get { return (string)GetValue(ItemNameProperty); }
		set { SetValue(ItemNameProperty, value); }
	}

	// Using a BindableProperty as the backing store for ItemName.  This enables animation, styling, binding, etc...
	public static readonly BindableProperty ItemNameProperty =
		BindableProperty.CreateAttached("ItemName", typeof(string), typeof(ItemMiniView), string.Empty);

	public string ItemDescription
	{
		get { return (string)GetValue(ItemDescriptionProperty); }
		set { SetValue(ItemDescriptionProperty, value); }
	}

	// Using a BindableProperty as the backing store for ItemName.  This enables animation, styling, binding, etc...
	public static readonly BindableProperty ItemDescriptionProperty =
		BindableProperty.CreateAttached("ItemDescription", typeof(string), typeof(ItemMiniView), string.Empty);

	public decimal ItemPrice
	{
		get { return (decimal)GetValue(ItemPriceProperty); }
		set { SetValue(ItemPriceProperty, value); }
	}

	// Using a BindableProperty as the backing store for ItemName.  This enables animation, styling, binding, etc...
	public static readonly BindableProperty ItemPriceProperty =
		BindableProperty.CreateAttached("ItemPrice", typeof(decimal), typeof(ItemMiniView), 0m);

	public byte[] MainImage
	{
		get { return (byte[])GetValue(MainImageProperty); }
		set { SetValue(MainImageProperty, value);}
	}

	// Using a BindableProperty as the backing store for ItemName.  This enables animation, styling, binding, etc...
	public static readonly BindableProperty MainImageProperty =
		BindableProperty.CreateAttached("MainImage", typeof(byte[]), typeof(ItemMiniView), null);
}