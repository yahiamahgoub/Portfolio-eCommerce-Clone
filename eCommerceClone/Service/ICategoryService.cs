using DataLib.Models;

namespace eCommerceClone.Service
{
	public interface ICategoryService
    {
		Task<IEnumerable<Category>> GetCategoriesAsync();

		Task<Category> GetCategoryAsync(int categoryId);
	}
}
