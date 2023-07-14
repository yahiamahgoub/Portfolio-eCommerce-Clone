using CommunityToolkit.Mvvm.ComponentModel;
using DataLib.Models;

namespace eCommerceClone.ViewModels
{
	public partial class ItemMiniViewModel : ObservableObject
	{
		[ObservableProperty]
		int itemId;
		[ObservableProperty]
		string itemName;
		[ObservableProperty]
		string itemDescription;
		[ObservableProperty]
		decimal itemPrice;
		[ObservableProperty]
		Status status;
		[ObservableProperty]
		DateTime datePosted;
		[ObservableProperty]
		string timeSincePost;
		[ObservableProperty]
		ImageSource mainPhoto;
	}
}
