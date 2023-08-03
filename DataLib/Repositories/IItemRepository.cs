using DataLib.Models;

namespace DataLib.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<IEnumerable<Item>> GetItemsAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
		
		Task<IEnumerable<Item>> GetItemsAsync();
		
		Task<Item?> GetItemFullAsync(int itemId, int? userId);
		
		Task<IEnumerable<ItemMini>> GetItemsMiniAsync();

		Task<ItemList?> GetForSaleListForUserAsync(int userId);

		Task<ItemList?> GetFavListForUserAsync(int userId);

		Task<IEnumerable<Item>> GetFavItemsListForUserAsync(int userId);
		
		Task<IEnumerable<Item>> GetForSaleItemsListForUserAsync(int userId);
		
		Task<IEnumerable<Item>> GetListItemsAsync(int itemListId);
	}
}