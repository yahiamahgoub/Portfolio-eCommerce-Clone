using DataLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLib.DataStorage
{
	public class AppDbContext : DbContext
	{
		const string _dbConnection = @"Data Source=tcp:ecommerceclonedbserver.database.windows.net,1433;Initial Catalog=eCommerceCloneDb;User Id=mainuser@ecommerceclonedbserver;Password=Masterpassword123";
		//const string _dbConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

		public DbSet<User> Users { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Category> ProductCategories { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Image> Images { get; set; }
		//public DbSet<Order> Orders { get; set; }
		//public DbSet<Company> Companies { get; set; }
		//public DbSet<PersonContact> PersonContacts { get; set; }

		public string DbPath { get; }
		public AppDbContext()
		{
			//var folder = Environment.SpecialFolder.LocalApplicationData;
			//var path = Environment.GetFolderPath(folder);
			//DbPath = System.IO.Path.Join(path, "eCommerceBE.db3");
		}

		// The following configures EF to create a Sqlite database file in the
		// special "local" folder for your platform.
		//protected override void OnConfiguring(DbContextOptionsBuilder options)
			//=> options.UseSqlite($"Data Source={DbPath}").LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
		
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlServer(_dbConnection).LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

		//private IEnumerable<Image> GetImages()
		//{
		//	var path = @"C:\Users\dragon\repos\courses\XAML Getting Started\eCommerceClone\eCommerceClone\Resources\Images\Sample Images\iPhone14";
		//	var filesNames = Directory.GetFiles(path);
		//	var pics = filesNames.Select(file => File.ReadAllBytes(file)).ToList();

		//	path = @"C:\Users\dragon\repos\courses\XAML Getting Started\eCommerceClone\eCommerceClone\Resources\Images\Sample Images\S22";
		//	filesNames = Directory.GetFiles(path);
		//	pics.AddRange(filesNames.Select(file => File.ReadAllBytes(file)));
		//	var imageList = new List<Image>();


		//	imageList.Add(new Image { ImageID = 1, ImageBytes = pics[0], IsMainImage = true, ItemId = 1 });
		//	imageList.Add(new Image { ImageID = 2, ImageBytes = pics[1], IsMainImage = false, ItemId = 1 });
		//	imageList.Add(new Image { ImageID = 3, ImageBytes = pics[2], IsMainImage = false, ItemId = 1 });

		//	imageList.Add(new Image { ImageID = 4, ImageBytes = pics[3], IsMainImage = true, ItemId = 2 });
		//	imageList.Add(new Image { ImageID = 5, ImageBytes = pics[4], IsMainImage = false, ItemId = 2 });
		//	imageList.Add(new Image { ImageID = 6, ImageBytes = pics[5], IsMainImage = false, ItemId = 2 });

		//	return imageList;
		//}

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Category>().HasData(
		//			  new Category { CategoryId = 1, Name = "Phones" },
		//			  new Category { CategoryId = 2, Name = "Cars" },
		//			  new Category { CategoryId = 3, Name = "TVs" },
		//			  new Category { CategoryId = 4, Name = "Personal Computers" },
		//			  new Category { CategoryId = 5, Name = "Laptops" },
		//			  new Category { CategoryId = 6, Name = "Camping & Hiking" }
		//			  );

		//	modelBuilder.Entity<Country>().HasData(
		//			  new Country { CountryId = 1, CountryName = "Sweden" },
		//			  new Country { CountryId = 2, CountryName = "Norway" },
		//			  new Country { CountryId = 3, CountryName = "Denmark" },
		//			  new Country { CountryId = 4, CountryName = "Finland" },
		//			  new Country { CountryId = 5, CountryName = "Germany" },
		//			  new Country { CountryId = 6, CountryName = "Spain" },
		//			  new Country { CountryId = 7, CountryName = "Italy" },
		//			  new Country { CountryId = 8, CountryName = "France" },
		//			  new Country { CountryId = 9, CountryName = "Belguim" });

		//	modelBuilder.Entity<User>().HasData(
		//			new User() { Name = "Daniel", PhoneNumber = "0123456789", UserId = 1 },
		//			new User() { Name = "Joanna", PhoneNumber = "0123456789", UserId = 2 },
		//			new User() { Name = "Lelland", PhoneNumber = "0123456789", UserId = 3 }
		//			);

		//	modelBuilder.Entity<Address>().HasData(
		//				new Address { AddressId = 1, AddressLine = "Stockholm", CountryId = 1, ZipOrPostalCode = "10145", IsMainAddress = true, UserId = 1 },
		//				new Address { AddressId = 2, AddressLine = "Gothenberg", CountryId = 2, ZipOrPostalCode = "10145", IsMainAddress = false, UserId = 1 },
		//				new Address { AddressId = 3, AddressLine = "Helsinki", CountryId = 4, ZipOrPostalCode = "10145", IsMainAddress = false, UserId = 1 },

		//				new Address { AddressId = 4, AddressLine = "Malmö", CountryId = 1, ZipOrPostalCode = "10145", IsMainAddress = true, UserId = 2 },
		//				new Address { AddressId = 5, AddressLine = "Copenhagen", CountryId = 3, ZipOrPostalCode = "10145", IsMainAddress = false, UserId = 2 },
		//				new Address { AddressId = 6, AddressLine = "Odense", CountryId = 3, ZipOrPostalCode = "10145", IsMainAddress = false, UserId = 2 },

		//				new Address { AddressId = 7, AddressLine = "Brussels", CountryId = 9, ZipOrPostalCode = "10145", IsMainAddress = true, UserId = 3 },
		//				new Address { AddressId = 8, AddressLine = "Antwerp", CountryId = 9, ZipOrPostalCode = "10145", IsMainAddress = false, UserId = 3 },
		//				new Address { AddressId = 9, AddressLine = "Ghent", CountryId = 9, ZipOrPostalCode = "10145", IsMainAddress = false, UserId = 3 }
		//				);

		//	modelBuilder.Entity<Item>().HasData(
		//				new Item() { ItemId = 1, ItemName = "iPhone 14", ItemDescription = "unused iPhone 14", ItemPrice = 1300, UserId = 1, AddressId = 1, CategoryId = 1, Currency = Currency.EGP },
		//				new Item() { ItemId = 2, ItemName = "Samsung S22", ItemDescription = "unused Samsung S22", ItemPrice = 1200, UserId = 2, AddressId = 4, CategoryId = 1, Currency = Currency.EURO }
		//				);

		//	modelBuilder.Entity<Image>().HasData(GetImages());

		//	base.OnModelCreating(modelBuilder);
		//}
	}
}