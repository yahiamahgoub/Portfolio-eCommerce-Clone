using DataLib.Models;
using DataLib.DataStorage;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DataLib.Repositories
{
	public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private int PAGESIZE = 20;
		private readonly IMapper mapper;

		public ItemRepository(AppDbContext _appDbContext, IMapper mapper) : base(_appDbContext)
		{
			this.mapper = mapper;
		}

		//public async Task<IEnumerable<ItemMini>> GetItemsAsync() => appDbContext.Items.Include(item => item.ImageList);

		public async Task<IEnumerable<ItemMini>> GetItemsMiniAsync()
		{			
			//var items = appDbContext.Items.Include(item => item.ImageList).Where(item => item.ImageList.Any(img => img.IsMainImage));
			var items = appDbContext.Items.Include(item => item.ImageList).Where(item => item.ImageList.Count == 0 || item.ImageList.Any(img => img.IsMainImage));
			return mapper.Map<IEnumerable<Item>, IEnumerable<ItemMini>>(items);
		}


		public async Task<IEnumerable<ItemMini>> GetItemFullAsync()
		{
			var items = appDbContext.Items.Include(item => item.ImageList).Where(item => item.ImageList.Any(img => img.IsMainImage));
			return mapper.Map<IEnumerable<Item>, IEnumerable<ItemMini>>(items);
		}


		public async Task<IEnumerable<Item>> GetItemsAsync() => appDbContext.Items.Include(item => item.ImageList);

		public async Task<Item?> GetItemFullAsync(int id) => await appDbContext.Items.Include(item => item.ImageList).FirstOrDefaultAsync();
		

		public async Task<IEnumerable<Item>> GetItemsAsync(string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            //if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(searchQuery))
            //    return await GetCitiesAsync();

            //var cityCollection = context.Cities as IQueryable<City>;
            //if (!string.IsNullOrEmpty(name))
            //{
            //	name.Trim();
            //	cityCollection.Where(c => c.Name == name);
            //}

            //if (!string.IsNullOrEmpty(searchQuery))
            //{
            //	searchQuery.Trim();
            //	cityCollection.Where(c => c.Name.Contains(name.Trim()) || (c.Description != null && c.Description.Contains(searchQuery)));
            //}

            //if (pageSize > PAGESIZE)
            //	pageSize = PAGESIZE;
            //return await cityCollection
            //	.OrderBy(c => c.Name)
            //	.Skip(pageSize * (pageNumber - 1))
            //	.Take(pageSize)
            //	.ToListAsync();

            return null;
        }
    }
}
