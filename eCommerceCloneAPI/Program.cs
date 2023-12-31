using DataLib.DataStorage;
using DataLib.Models;
using DataLib.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eCommerceClone
{
	public static class  ExtensionClass 
    {
		public static void RegisterServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddScoped<IGenericRepository<Address>, GenericRepository<Address>>();
			builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
			builder.Services.AddScoped<IGenericRepository<Country>, GenericRepository<Country>>();
			builder.Services.AddScoped<IGenericRepository<Image>, GenericRepository<Image>>();
			
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IItemRepository, ItemRepository>();
			builder.Services.AddScoped<IItemListToItemJoinRepository, ItemListToItemJoinRepository>();
		}
	}

    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			//public static IServiceCollection AddMiddleware(this IServiceCollection services)
			//{
			//	services.AddMvc().AddJsonOptions(options =>
			//	{
			//		options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			//	});

			//	return services;
			//}

			builder.Services
				.AddControllers()
				.AddJsonOptions( options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());			

			builder.Services.AddDbContext<AppDbContext>();

			builder.RegisterServices();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			//if (app.Environment.IsDevelopment())
			//{
			//	app.UseSwagger();
			//	app.UseSwaggerUI();
			//}

			app.UseSwagger();
			app.UseSwaggerUI();

			//app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}