using System.Windows.Input;

namespace eCommerceClone.UserControls;

public partial class ItemMiniView : ContentView
{
	public ItemMiniView()
	{
		InitializeComponent();	
	}

	public string ItemName	
	{
		get { return (string)GetValue(ItemNameProperty); }
		set { SetValue(ItemNameProperty, value); }
	}

	// Using a BindableProperty as the backing store for ItemName.  This enables animation, styling, binding, etc...
	public static readonly BindableProperty ItemNameProperty =
		BindableProperty.CreateAttached("ItemName", typeof(string), typeof(ItemMiniView), string.Empty, BindingMode.OneWay, propertyChanged: propertyChanged);

	private static void propertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var itemMiniView = (ItemMiniView)bindable;
	}

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


	public bool IsItemSaved
	{
		get { return (bool)GetValue(IsItemSavedProperty); }
		set { SetValue(IsItemSavedProperty, value); }
	}

	
	public static readonly BindableProperty IsItemSavedProperty =
		BindableProperty.CreateAttached("IsItemSaved", typeof(bool), typeof(ItemMiniView), false);

	public ICommand FavCommand
	{
		get => (ICommand)GetValue(FavCommandProperty);
		set => SetValue(FavCommandProperty, value);
	}

	public static readonly BindableProperty FavCommandProperty =
			   BindableProperty.Create(nameof(FavCommand), typeof(ICommand), typeof(ItemMiniView));



	public byte[] MainImage
	{
		get { return (byte[])GetValue(MainImageProperty); }
		set 
		{ 
			SetValue(MainImageProperty, value);		
		}
	}

	// Using a BindableProperty as the backing store for ItemName.  This enables animation, styling, binding, etc...
	public static readonly BindableProperty MainImageProperty =
		BindableProperty.CreateAttached("MainImage", typeof(byte[]), typeof(ItemMiniView), null);

	private void ImageButton_Clicked(object sender, EventArgs e)
	{
		IsItemSaved = !IsItemSaved;
	}
}