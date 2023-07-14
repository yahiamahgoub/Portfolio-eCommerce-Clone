using eCommerceClone.ViewModels;
using eCommerceClone.ViewModels;

namespace eCommerceClone.Views;

public partial class NewItemPage : ContentPage
{
	public NewItemPage(NewItemPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var vm = (NewItemPageViewModel)BindingContext;
		await vm.LoadUserCommand.ExecuteAsync(null);
		await vm.LoadCategoriesCommand.ExecuteAsync(null);
		await vm.LoadAddressesForUserCommand.ExecuteAsync(null);
	}

	public async Task TakePhoto()
	{
		if (MediaPicker.Default.IsCaptureSupported)
		{
			FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

			var imgStream = await photo.OpenReadAsync();			

			if (photo != null)
			{
				// save the file into local storage
				string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

				using Stream sourceStream = await photo.OpenReadAsync();
				using FileStream localFileStream = File.OpenWrite(localFilePath);

				await sourceStream.CopyToAsync(localFileStream);
			}
		}
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await TakePhoto();
	}
}