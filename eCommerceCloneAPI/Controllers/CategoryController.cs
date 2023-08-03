using DataLib.Models;
using DataLib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceClone.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoryController : ControllerBase
	{
		private IGenericRepository<Category> repository;

		public CategoryController(IGenericRepository<Category> repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IEnumerable<Category>> GetCategories() => await repository.GetAllAsync();

		[HttpGet("{categoryId}")]
		public async Task<Category> GetCategory(int categoryId) => await repository.GetByIdAsync(categoryId);
	}
}