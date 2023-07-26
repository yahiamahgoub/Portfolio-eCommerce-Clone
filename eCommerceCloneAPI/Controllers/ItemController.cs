using AutoMapper;
using DataLib.Models;
using DataLib.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eCommerceClone.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ItemController : ControllerBase
	{		
		private readonly IItemRepository repository;
		private readonly ILogger<ItemController> logger;
		private readonly IMapper mapper;

		public ItemController(IItemRepository _repository, ILogger<ItemController> _logger, IMapper _mapper)
		{
			repository = _repository;
			logger = _logger;			
			mapper = _mapper;
		}

		//[HttpGet(Name = "GetItems")]
		//public async Task<IEnumerable<Item>> GetAll() => await repository.GetAll();

		[HttpGet(Name = "GetItemsMini")]
		public async Task<ActionResult<IEnumerable<ItemMini>>> GetItemsMini() => Ok(await repository.GetItemsMiniAsync());

		[HttpGet("{itemId}", Name = "GetItem")]
		public async Task<ActionResult<Item?>> GetItem(int itemId) => Ok(await repository.GetItemFullAsync(itemId));
		
		[HttpPost]
		public async Task<ActionResult<Item?>> Add(ItemForAdd itemForAdd)
		{
			var item = mapper.Map<Item>(itemForAdd);
			await repository.AddAsync(item);	
			await repository.SaveChangesAsync();
			return CreatedAtAction("GetItem", new { itemId = item.ItemId}, item);
		}

		[HttpDelete("{itemId}")]
		public async Task<ActionResult> Delete(int itemId)
		{
			if (!await repository.ExistsAsync(itemId))
			{
				logger.LogInformation($"Item with id {itemId} wasn't found!");
				return NotFound();
			}

			var item = await repository.GetById(itemId);

			repository.Delete(item);
			await repository.SaveChangesAsync();
			return NoContent();
		}

		//[HttpGet(Name = "GetWeatherForecast")]
		//public IEnumerable<WeatherForecast> Get()
		//{
		//	return Enumerable.Range(1, 5).Select(index => new WeatherForecast
		//	{
		//		Date = DateTime.Now.AddDays(index),
		//		TemperatureC = Random.Shared.Next(-20, 55),
		//		Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		//	})
		//	.ToArray();
		//}
	}
}