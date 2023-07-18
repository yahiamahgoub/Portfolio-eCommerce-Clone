using CommunityToolkit.Maui;
using eCommerceClone.Service;
using eCommerceClone.ViewModels;
using eCommerceClone.Views;
using Microsoft.Extensions.Logging;

namespace eCommerceClone;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<ListingsPage>();
		builder.Services.AddSingleton<ListingsPageViewModel>();
		builder.Services.AddSingleton<NewItemPage>();
		builder.Services.AddSingleton<NewItemPageViewModel>();

		builder.Services.AddSingleton<IItemService, ServiceClient>();
		builder.Services.AddSingleton<IUserService, ServiceClient>();
		builder.Services.AddSingleton<IAddressService, ServiceClient>();
		builder.Services.AddSingleton<ICategoryService, ServiceClient>();
		builder.Services.AddSingleton<RequestSender, RequestSender>();
		return builder.Build();
	}
}
