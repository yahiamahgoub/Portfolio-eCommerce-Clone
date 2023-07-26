using DataLib.Models;

namespace DataLib.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<IEnumerable<Item>> GetItemsAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
		Task<IEnumerable<Item>> GetItemsAsync();
		Task<Item?> GetItemFullAsync(int itemId);
		Task<IEnumerable<ItemMini>> GetItemsMiniAsync();
	}
}