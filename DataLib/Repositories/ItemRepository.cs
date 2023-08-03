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
		
		public async Task<IEnumerable<ItemMini>> GetItemsMiniAsync()
		{			
			var items = await appDbContext.Items
				.Include(item => item.ImageList)
				//.Include(item => item.ItemListToItemJoin)
				.Where(item => item.ImageList.Count == 0 || item.ImageList.Any(img => img.IsMainImage))
				//.Where(item => item.ItemListToItemJoin.All(list => list.ItemList.ItemListType == ItemListType.ForSaleByUser))
				.ToListAsync();
			return mapper.Map<IEnumerable<Item>, IEnumerable<ItemMini>>(items);
		}

		public async Task<ItemList?> GetForSaleListForUserAsync(int userId) => 
			await appDbContext.ItemLists.SingleOrDefaultAsync(item => item.UserId == userId && item.ItemListType == ItemListType.ForSaleByUser);

		public async Task<ItemList?> GetFavListForUserAsync(int userId) =>
			await appDbContext.ItemLists.SingleOrDefaultAsync(item => item.UserId == userId && item.ItemListType == ItemListType.FavoriteByUser);

		public async Task<IEnumerable<Item>> GetFavItemsListForUserAsync(int userId)
		{
			var itemList = await appDbContext.ItemLists.SingleOrDefaultAsync(item => item.UserId == userId && item.ItemListType == ItemListType.FavoriteByUser);
			return await GetListItemsAsync(itemList.ItemListId);
		}

		public async Task<IEnumerable<Item>> GetForSaleItemsListForUserAsync(int userId)
		{
			var itemList = await appDbContext.ItemLists.SingleOrDefaultAsync(item => item.UserId == userId && item.ItemListType == ItemListType.ForSaleByUser);
			return await GetListItemsAsync(itemList.ItemListId);
		}

		public async Task<IEnumerable<Item>> GetListItemsAsync(int itemListId) =>
			await appDbContext.Items.Include(item => item.ImageList)
			.Where(item => item.ImageList.Count == 0 || item.ImageList.Any(img => img.IsMainImage))
			.Where(item => item.ItemListToItemJoin.Any(joinedItem => joinedItem.ItemListId == itemListId)).ToListAsync();		

		//public async Task AddItemToFavListAsync(int itemId, int userId)
		//{
		//	await 
		//	var items = appDbContext.Items.Include(item => item.ImageList).Where(item => item.ImageList.Count == 0 || item.ImageList.Any(img => img.IsMainImage));
		//	return mapper.Map<IEnumerable<Item>, IEnumerable<ItemMini>>(items);
		//}

		public async Task<Item?> GetItemFullAsync(int itemId, int? userId) => 
			//go back to poster?		
			await appDbContext.Items.Include(item => item.ImageList)
					.Where(item => item.ItemId == itemId &&
						item.ItemListToItemJoin.All(
							itemListJoin => itemListJoin.ItemList.ItemListType == ItemListType.ForSaleByUser // include the list of the poster plus
							|| itemListJoin.ItemList.User.UserId == userId)) // the current user's lists which contain this item
					.Include(item => item.Address)
					//.Include(item => item.ItemListToItemJoin.Select(itemJoin => itemJoin.ItemList.User))
					.Include(itemListJoin => itemListJoin.ItemListToItemJoin)
					.ThenInclude(itemList => itemList.ItemList)
					.ThenInclude(itemList => itemList.User)		
					//.FirstOrDefaultAsync(item => item.ItemId == itemId);
					.FirstOrDefaultAsync();

		//public async Task<Item?> GetItemFullAsync(int itemId)
		//{

		//	await appDbContext.Items.Include(item => item.ImageList)
		//	.Include(item => item.Address)
		//	.FirstOrDefaultAsync(item => item.ItemId == itemId);
		//}

		public async Task<IEnumerable<Item>> GetItemsAsync() => appDbContext.Items.Include(item => item.ImageList);		

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
