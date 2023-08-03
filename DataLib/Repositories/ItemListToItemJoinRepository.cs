using DataLib.DataStorage;
using DataLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLib.Repositories
{
	public interface IItemListToItemJoinRepository : IGenericRepository<ItemListToItemJoin>
	{
		Task<bool> ExistsAsync(int itemListId, int itemId);
		Task<ItemListToItemJoin?> GetAsync(int itemListId, int itemId);
	}

	public class ItemListToItemJoinRepository : GenericRepository<ItemListToItemJoin>, IItemListToItemJoinRepository
	{
		public ItemListToItemJoinRepository(AppDbContext _appDbContext) : base(_appDbContext)
		{
		}

		public async Task<bool> ExistsAsync(int itemListId, int itemId) =>
			await appDbContext.ItemListToItemJoin.AnyAsync(itemJoin => itemJoin.ItemListId == itemListId && itemJoin.ItemId == itemId);

		public async Task<ItemListToItemJoin?> GetAsync(int itemListId, int itemId) =>
			await appDbContext.ItemListToItemJoin.SingleOrDefaultAsync(itemJoin => itemJoin.ItemListId == itemListId && itemJoin.ItemId == itemId);		
	}
}
