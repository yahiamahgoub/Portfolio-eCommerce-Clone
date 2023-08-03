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
		builder.Services.AddScoped<NewItemPage>();
		builder.Services.AddScoped<NewItemPageViewModel>();

		builder.Services.AddScoped<UserPage>();
		builder.Services.AddScoped<UserPageViewModel>();

		builder.Services.AddScoped<ItemDetailsPage>();
		builder.Services.AddScoped<ItemDetailsPageViewModel>();

		builder.Services.AddScoped<UserInfoPage>();
		builder.Services.AddScoped<UserInfoPageViewModel>();


		builder.Services.AddSingleton<IItemService, ServiceClient>();
		builder.Services.AddSingleton<IUserService, ServiceClient>();
		builder.Services.AddSingleton<IAddressService, ServiceClient>();
		builder.Services.AddSingleton<ICategoryService, ServiceClient>();
		builder.Services.AddSingleton<RequestSender, RequestSender>();
		return builder.Build();
	}
}
