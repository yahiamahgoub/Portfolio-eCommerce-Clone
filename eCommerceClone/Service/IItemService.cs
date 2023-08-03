using DataLib.Models;

namespace eCommerceClone.Service
{
	public interface IItemService
	{
		Task<IEnumerable<ItemMini>> GetItemsMiniAsync();

		Task<Item> GetItemAsync(int itemId, int? userId);
		
		Task<Item> AddItemAsync(ItemForAdd itemForAdd);

		Task<ItemList> GetForSaleListAsync(int userId);
		
		Task<ItemList> GetFavListAsync(int userId);

		Task<IEnumerable<ItemMini>> GetForSaleItemsListAsync(int userId);
		
		Task<IEnumerable<ItemMini>> GetFavItemsListAsync(int userId);
		
		Task<ItemListToItemJoin> AddItemToFavListAsync(int userId, int itemId, ItemListToItemJoin itemList);		
	}
}
