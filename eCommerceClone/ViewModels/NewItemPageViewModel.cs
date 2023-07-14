using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataLib.Models;
using eCommerceClone.Service;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceClone.ViewModels
{
	public partial class NewItemPageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {

		private readonly ICategoryService categoryService;
		private readonly IAddressService addressService;
		private readonly IUserService userService;
		private readonly IItemService itemService;

		public NewItemPageViewModel(ICategoryService categoryService, IAddressService addressService, IUserService userService, IItemService itemService)
		{
			this.categoryService = categoryService;
			this.addressService = addressService;
			this.userService = userService;
			this.itemService = itemService;
		}

		[ObservableProperty]
		User user;

		public ObservableRangeCollection<Address> AddressList { get; set; } = new ObservableRangeCollection<Address>();

		//public ObservableRangeCollection<byte[]> ImageList { get; set; } = new ObservableRangeCollection<byte[]>();
		[ObservableProperty]
		byte[] image;

		[ObservableProperty]
		Address selectedAddress;

		public ObservableRangeCollection<Category> Categories { get; set; } = new ObservableRangeCollection<Category>();
		
		[ObservableProperty]
		Category selectedCategory;
			
		[ObservableProperty]
		Category category;
		[ObservableProperty]
		string name;
		[ObservableProperty]
		string phoneNumber;
		[ObservableProperty]
		string address;
		[ObservableProperty]
		string itemName;
		[ObservableProperty]
		string itemDescription;
		[ObservableProperty]
		decimal itemPrice;
		[ObservableProperty]
		IEnumerable<byte[]> itemImages;
		[ObservableProperty]
		byte[] mainImage;



		[RelayCommand]
		public async Task Load()
		{
			await LoadUser();
			await LoadCategories();
			await LoadAddressesForUser();
		}

		[RelayCommand]
		public async Task LoadCategories()
		{
			var cats = await categoryService.GetCategories();
			Categories.Clear();
			Categories.AddRange(cats);
		}

		[RelayCommand]
		public async Task LoadAddressesForUser()
		{			
			var initList = await addressService.GetAddressesForUser(user.UserId);
			AddressList.Clear();
			AddressList.AddRange(initList);
			SelectedAddress = AddressList.FirstOrDefault();
		}

		[RelayCommand]
		public async Task LoadUser()
		{
			//change later to load from login form			
			user = await userService.GetUserAsync(1);
		}

		[RelayCommand]
		public async Task SnapPhoto()
		{
			if (MediaPicker.Default.IsCaptureSupported)
			{
				FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

				using (var imgStream = await photo.OpenReadAsync())
				{
					var streamReader = new StreamReader(imgStream);
					Image = System.Text.Encoding.UTF8.GetBytes(streamReader.ReadToEnd());					
				}
				//if (photo != null)
				//{
				//	// save the file into local storage
				//	string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

				//	using Stream sourceStream = await photo.OpenReadAsync();
				//	using FileStream localFileStream = File.OpenWrite(localFilePath);

				//	await sourceStream.CopyToAsync(localFileStream);
				//}
			}

		}

		[RelayCommand]
		public async Task SaveItem()
		{
			var itemForAdd = new ItemForAdd 
			{
				ItemName = ItemName,
				ItemDescription = ItemDescription,
				ItemPrice = ItemPrice,
				Currency = Currency.SEK,
				Status = Status.Available,
				UserId = User.UserId,				
				AddressId = SelectedAddress.AddressId,
				CategoryId = SelectedCategory.CategoryId,
				ItemPhotos = GetImages()
			};
			await itemService.AddItemAsync(itemForAdd);
		}

		List<DataLib.Models.Image> GetImages()
		{
			return new List<DataLib.Models.Image>() { new DataLib.Models.Image { ImageBytes = Image, IsMainImage = true } };
			//return ImageList.Select(imgByte => new DataLib.Models.Image { ImageBytes = imgByte}).ToList();
		}
	}
}
