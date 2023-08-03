using AutoMapper;
using DataLib.Models;
using Newtonsoft.Json;
using System.Text;

namespace eCommerceClone.Service
{
	public class ServiceClient : IItemService, IAddressService, ICategoryService, IUserService
	{		
		private readonly RequestSender client;
		private readonly IMapper mapper;

		public ServiceClient(RequestSender client, IMapper mapper)
		{
			this.client = client;
			this.mapper = mapper;
		}
		public async Task<IEnumerable<Category>> GetCategoriesAsync()
			=> await client.GetResponse<IEnumerable<Category>>(HttpMethod.Get, $"category");

		public async Task<IEnumerable<ItemMini>> GetItemsMiniAsync() 
			=>	await client.GetResponse<IEnumerable<ItemMini>>(HttpMethod.Get, "item");

		public async Task<ItemList> GetForSaleListAsync(int userId) => 
			await client.GetResponse<ItemList>(HttpMethod.Get, $"item/user/{userId}/salelist");		

		public async Task<ItemList> GetFavListAsync(int userId) => 
			await client.GetResponse<ItemList>(HttpMethod.Get, $"item/user/{userId}/favlist");

		public async Task<IEnumerable<ItemMini>> GetFavItemsListAsync(int userId)
			=> await client.GetResponse<IEnumerable<ItemMini>>(HttpMethod.Get, $"item/user/{userId}/favlistitems");

		public async Task<IEnumerable<ItemMini>> GetForSaleItemsListAsync(int userId)
			=> await client.GetResponse<IEnumerable<ItemMini>>(HttpMethod.Get, $"item/user/{userId}/salelistitems");

		public async Task<ItemListToItemJoin> AddItemToFavListAsync(int userId, int itemId, ItemListToItemJoin itemList)
			=> await client.GetResponse<ItemListToItemJoin>(HttpMethod.Post, $"item/{itemList.ItemId}/user/{userId}");
		
		public async Task<UserForRead> GetUserAsync(int userId)
			=> await client.GetResponse<UserForRead>(HttpMethod.Get, $"user/{userId}");

		public async Task<UserForRead> AddUserAsync(UserForAdd user)
			=> await client.GetResponse<UserForAdd, UserForRead>(HttpMethod.Post, $"user", user);
		public async Task<UserForRead> UpdateUserAsync(int userId, UserForUpdate user)
			=> await client.GetResponse<UserForUpdate, UserForRead>(HttpMethod.Put, $"user/{userId}", user);

		public async Task<IEnumerable<Address>> GetAddressesForUser(int userId) 
			=> await client.GetResponse<IEnumerable<Address>>(HttpMethod.Get, $"user/{userId}/address/");

		public async Task<Item> AddItemAsync(ItemForAdd itemForAdd) 
			=> await client.GetResponse<ItemForAdd, Item>(HttpMethod.Post, $"item/user/{itemForAdd.UserId}", itemForAdd);

		public async Task<Item> GetItemAsync(int itemId, int? userId) 
			=> await client.GetResponse<Item>(HttpMethod.Get, $"item/{itemId}/user/{userId}");		

		public async Task<Category> GetCategoryAsync(int categoryId) 
			=> await client.GetResponse<Category>(HttpMethod.Get, $"category/{categoryId}");
	}
}
