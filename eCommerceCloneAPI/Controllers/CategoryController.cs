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
		public async Task<IEnumerable<Category>> GetItemsMini() => await repository.GetAll();
	}
}