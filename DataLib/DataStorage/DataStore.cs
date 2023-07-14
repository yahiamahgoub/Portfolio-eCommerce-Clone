using DataLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLib.DataStorage
{
    public class DataStore
	{
		private readonly AppDbContext dbContext;

		public DataStore(AppDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		public IEnumerable<ItemMini> GetItemsMini()
		{
			return null; // dbContext.Items.Include(item => item.ItemPhotos).Select(item => item.ToMini());			
		}

		private IEnumerable<byte[]> GetPicturesIphone()
		{
			var path = @"C:\Users\dragon\repos\courses\XAML Getting Started\eCommerceClone\eCommerceClone\Resources\Images\Sample Images\iPhone14";
			var filesNames = Directory.GetFiles(path);
			var pics = filesNames.Select(file => File.ReadAllBytes(file));
			return pics;
		}
		private IEnumerable<byte[]> GetPicturesS22()
		{
			var path = @"C:\Users\dragon\repos\courses\XAML Getting Started\eCommerceClone\eCommerceClone\Resources\Images\Sample Images\S22";
			var filesNames = Directory.GetFiles(path);
			var pics = filesNames.Select(file => File.ReadAllBytes(file));
			return pics;
		}
		//public void SeedData()
		//{			
		//	if (dbContext.Items.Count() > 0)
		//		return;

		//	dbContext.Items.AddRange(GenerateData());
		//	dbContext.SaveChanges();			
		//}


		//private List<Item> GenerateData()
		//{
		//	var iphones = new Category { Name = "phones" };
		//	var samsung = new Category { Name = "cars" };

		//	var sweden = new Country { CountryName = "Sweden" };

		//	var Address = new Address { AddressLine = "Stockholm", Country = sweden, ZipOrPostalCode = "10145" };

		//	var poster = new User() { Name = "demoposter", PhoneNumber = "012345" };
		//	poster.Addresses.Add(Address);

		//	var picbytes = GetPicturesIphone();
		//	var iphonePhotos = picbytes.Select(pic => new Image { ImageBytes = pic }).ToList();
		//	iphonePhotos.First().IsMainImage = true;
		//	var samsungbytes = GetPicturesS22();
		//	var samsungPhotos = samsungbytes.Select(pic => new Image { ImageBytes = pic }).ToList();
		//	samsungPhotos.First().IsMainImage = true;

		//	return new List<Item>()
		//	{
		//		new Item() { ItemName = "iphone 14", ItemDescription = "unused iphone 14", ItemPrice = 1200, Poster = poster, ItemPhotos = iphonePhotos},
		//		new Item() { ItemName = "S22", ItemDescription = "unused S22", ItemPrice = 1100, Poster = poster, ItemPhotos = samsungPhotos}
		//	};
		//}
	}
}
