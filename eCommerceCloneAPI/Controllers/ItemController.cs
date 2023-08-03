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
		private readonly IItemRepository itemRepository;

		private readonly IUserRepository userRepository;
		
		private readonly IItemListToItemJoinRepository itemListToItemJoinRepository;
		
		private readonly ILogger<ItemController> logger;
		
		private readonly IMapper mapper;

		public ItemController(IItemRepository _repository, IUserRepository userRepository, IItemListToItemJoinRepository _itemListToItemJoinRepository, 
			ILogger<ItemController> _logger, IMapper _mapper)
		{
			itemRepository = _repository;
			this.userRepository = userRepository;
			itemListToItemJoinRepository = _itemListToItemJoinRepository;
			logger = _logger;
			mapper = _mapper;
		}

		//[HttpGet(Name = "GetItems")]
		//public async Task<IEnumerable<Item>> GetAll() => await repository.GetAll();

		[HttpGet(Name = "GetItemsMini")]
		public async Task<ActionResult<IEnumerable<ItemMini>>> GetItemsMini() => Ok(await itemRepository.GetItemsMiniAsync());

		[HttpGet("{itemId}/user/{userId}", Name = "GetItem")]
		public async Task<ActionResult<Item?>> GetItem(int itemId, int? userId) => Ok(await itemRepository.GetItemFullAsync(itemId, userId));		

		[HttpPost("user/{userId}")]
		public async Task<ActionResult<Item?>> Add(int userId, ItemForAdd itemForAdd)
		{
			if (!await userRepository.ExistsAsync(userId))
			{
				logger.LogInformation($"User with id {userId} wasn't found!");
				return NotFound();
			}

			var item = mapper.Map<Item>(itemForAdd);


			//Check whether the item is already added to the ForSaleList assigned to the user
			var forSaleItemList = await itemRepository.GetForSaleListForUserAsync(userId);
			
			if (item.ItemListToItemJoin.Count == 0 
			|| !item.ItemListToItemJoin.Any(itemList => itemList.ItemListId == forSaleItemList.ItemListId))
				item.ItemListToItemJoin.Add(new ItemListToItemJoin { Item = item, ItemList = forSaleItemList });

			await itemRepository.AddAsync(item);	
			await itemRepository.SaveChangesAsync();
			return CreatedAtAction("GetItem", new { itemId = item.ItemId}, item);
		}


		[HttpGet("user/{userId}/salelist", Name = "SaleList")]
		public async Task<ActionResult<ItemList?>> GetForSaleListAsync(int userId) => Ok(await itemRepository.GetForSaleListForUserAsync(userId));

		[HttpGet("user/{userId}/favlist", Name = "FavList")]
		public async Task<ActionResult<ItemList?>> GetFavListAsync(int userId) => Ok(await itemRepository.GetFavListForUserAsync(userId));



		[HttpGet("user/{userId}/salelistitems", Name = "SaleListItems")]
		public async Task<ActionResult<IEnumerable<ItemMini>>> GetForSaleItemsListAsync(int userId)
		{
			var forSaleItemlist = await itemRepository.GetForSaleItemsListForUserAsync(userId);
			return Ok(mapper.Map<IEnumerable<Item>, IEnumerable<ItemMini>>(forSaleItemlist));
		}


		[HttpGet("user/{userId}/favlistitems", Name = "FavListItems")]
		public async Task<ActionResult<IEnumerable<ItemMini>>> GetFavItemsListAsync(int userId)
		{
			var favItemlist = await itemRepository.GetFavItemsListForUserAsync(userId);
			return Ok(mapper.Map<IEnumerable<Item>, IEnumerable<ItemMini>>(favItemlist));
		}

		
		[HttpPost("favlist/{itemId}/user/{userId}")]
		public async Task<ActionResult<ItemListToItemJoin>> AddItemToFavListAsync(int userId, int itemId, ItemListToItemJoin itemList)
		{
			if (!await userRepository.ExistsAsync(userId))
			{
				logger.LogInformation($"User with id {userId} wasn't found!");
				return NotFound();
			}

			if (!await itemRepository.ExistsAsync(itemId))
			{
				logger.LogInformation($"Item with id {itemId} wasn't found!");
				return NotFound();
			}

			await itemListToItemJoinRepository.AddAsync(itemList);
			await itemListToItemJoinRepository.SaveChangesAsync();
			//return CreatedAtAction("FavList", new { itemList.ItemId, itemList.ItemListId}, itemList);
			return Ok(itemList);
		}

		[HttpDelete("{itemId}/user/{userId}")]
		public async Task<ActionResult> RemoveItemFromFavList(int userId, int itemId, ItemListToItemJoin itemList)
		{
			if (await userRepository.ExistsAsync(userId))
			{
				logger.LogInformation($"User with id {userId} wasn't found!");
				return NotFound();
			}

			if (await itemRepository.ExistsAsync(itemId))
			{
				logger.LogInformation($"Item with id {itemId} wasn't found!");
				return NotFound();
			}

			itemListToItemJoinRepository.Delete(itemList);
			await itemRepository.SaveChangesAsync();
			return NoContent();
		}


		[HttpPost("salelist/{itemId}/user/{userId}")]
		public async Task<ActionResult> AddItemToForSaleList(int userId, int itemId, ItemListToItemJoin itemList)
		{
			if (await userRepository.ExistsAsync(userId))
			{
				logger.LogInformation($"User with id {userId} wasn't found!");
				return NotFound();
			}

			if (await itemRepository.ExistsAsync(itemId))
			{
				logger.LogInformation($"Item with id {itemId} wasn't found!");
				return NotFound();
			}

			await itemListToItemJoinRepository.AddAsync(itemList);
			await itemListToItemJoinRepository.SaveChangesAsync();
			return CreatedAtAction("SaleList", new { itemList.ItemId, itemList.ItemListId }, itemList);
		}

		[HttpDelete("{itemId}")]
		public async Task<ActionResult> Delete(int itemId)
		{
			if (!await itemRepository.ExistsAsync(itemId))
			{
				logger.LogInformation($"Item with id {itemId} wasn't found!");
				return NotFound();
			}

			var item = await itemRepository.GetByIdAsync(itemId);

			itemRepository.Delete(item);
			await itemRepository.SaveChangesAsync();
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