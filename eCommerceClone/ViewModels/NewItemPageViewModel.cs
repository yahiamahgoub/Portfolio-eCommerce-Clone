using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataLib.Models;
using eCommerceClone.Service;
using eCommerceClone.Views;
using MvvmHelpers;
using Image = DataLib.Models.Image;

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
		User currentUser;

		public ObservableRangeCollection<Address> AddressList { get; set; } = new ObservableRangeCollection<Address>();

		
		//[NotifyPropertyChangedFor(nameof(ImageList))]
		public ObservableRangeCollection<Image> ImageList { get; set; } = new ObservableRangeCollection<Image>();


		[ObservableProperty]
		byte[] image;

		[ObservableProperty]
		Currency selectedCurrency;

		public IEnumerable<Currency> CurrencyList { get; set; } = Enum.GetValues(typeof(Currency)) as Currency[];

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
			await LoadCurrency();
		}

		[RelayCommand]
		public async Task LoadCurrency()
		{
			SelectedCurrency = CurrencyList.FirstOrDefault();
		}

		[RelayCommand]
		public async Task LoadCategories()
		{
			var cats = await categoryService.GetCategoriesAsync();
			Categories.Clear();
			Categories.AddRange(cats);
			SelectedCategory = Categories.FirstOrDefault();
		}

		[RelayCommand]
		public async Task LoadAddressesForUser()
		{			
			var initList = await addressService.GetAddressesForUser(CurrentUser.UserId);
			AddressList.Clear();
			AddressList.AddRange(initList);
			SelectedAddress = AddressList.FirstOrDefault();
		}

		[RelayCommand]
		public async Task LoadUser()
		{
			//change later to load from login form			
			CurrentUser = await userService.GetUserAsync(1);
		}

		[RelayCommand]
		public async Task RemoveImage()
		{
			
		}


		//public async Task<FileResult> CaptureAsync(MediaPickerOptions options, bool photo)
		//{
		//	var captureUi = new CameraCaptureUI(options);

		//	var file = await captureUi.CaptureFileAsync(photo ? CameraCaptureUIMode.Photo : CameraCaptureUIMode.Video);

		//	if (file != null)
		//		return new FileResult(file.Path, file.ContentType);

		//	return null;
		//}

		[RelayCommand]
		public async Task SnapPhoto()
		{
			if (MediaPicker.Default.IsCaptureSupported)
			{
				FileResult photo = await MediaPicker.Default.PickPhotoAsync();

				if(photo is not null)
				{
					//using (var imgStream = await photo.OpenReadAsync())
					//{
					// Load file meta data with FileInfo
					FileInfo fileInfo = new FileInfo(photo.FullPath);

					// The byte[] to save the data in
					byte[] data = new byte[fileInfo.Length];

					// Load a filestream and put its content into the byte[]
					using (FileStream fs = fileInfo.OpenRead())
					{
						fs.Read(data, 0, data.Length);
					}
					ImageList.Add(DataLib.Models.Image.FromByteArray(data));
					Image = data;

					// Delete the temporary file
					//fileInfo.Delete();

					// Post byte[] to database

					//var streamReader = new StreamReader(imgStream);
					//while (streamReader.Peek() != 0)
					//{
					//	streamReader.readby
					//}
					//Image = System.Text.Encoding.UTF8.GetBytes(streamReader.ReadToEnd());					
					//}
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
		}

		[RelayCommand]
		public async Task SaveItem()
		{
			var itemForAdd = new ItemForAdd 
			{
				ItemName = ItemName,
				ItemDescription = ItemDescription,
				ItemPrice = ItemPrice,
				Currency = SelectedCurrency,
				Status = Status.Available,
				UserId = CurrentUser.UserId,				
				AddressId = SelectedAddress.AddressId,
				CategoryId = SelectedCategory.CategoryId,
				ImageList = GetImages()
			};
			
			await itemService.AddItemAsync(itemForAdd);
			
			await Shell.Current.GoToAsync($"//{nameof(ListingsPage)}");
		}		

		List<Image> GetImages()
		{
			var firstImage = ImageList.FirstOrDefault();
			
			if(firstImage is not null)
				firstImage.IsMainImage = true;
			
			return ImageList.ToList();
		}
	}
}
