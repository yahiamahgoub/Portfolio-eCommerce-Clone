using AutoMapper;
using DataLib.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text;

namespace eCommerceClone.Service
{
	public interface IItemService
	{
		Task<IEnumerable<ItemMini>> GetItemsMini();
		Task<Item> AddItemAsync(ItemForAdd itemForAdd);
		//Task<Coffee> GetCoffee(int id);
		//Task RemoveCoffee(int id);
	}

	public class RequestSender
	{
		private readonly HttpClient client;

		public RequestSender()
		{
			client = new HttpClient { BaseAddress = new Uri($"{ServiceSettings.URL}/") };
		}

		public async Task<TKey> GetResponse<TKey>(HttpMethod httpMethod, string path)
		{
			if (httpMethod == HttpMethod.Get)
			{
				var jsonString = await client.GetStringAsync(path);
				return JsonConvert.DeserializeObject<TKey>(jsonString);
			}

			//if (httpMethod == HttpMethod.Post)
			//{
			//	var jsonString = await client.PostAsync(path);
			//	return JsonConvert.DeserializeObject<TKey>(jsonString);
			//}

			else
            {
				return default(TKey);
            }
        }
		//IDictionary<string, string> searchData
		public async Task<TOutput> GetResponse<TInput, TOutput>(HttpMethod httpMethod, string path, TInput input)
		{			
			if (httpMethod == HttpMethod.Post)
			{
				var inputToJson = JsonConvert.SerializeObject(input);
				var requestContent = new StringContent(inputToJson, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.PostAsync(path, requestContent);

				if (response.IsSuccessStatusCode)
				{
					// Get the URI of the created resource.
					var UrireturnUrl = response.Headers.Location;
					Console.WriteLine(UrireturnUrl);

					var stringContent = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<TOutput>(stringContent);
				}
			}
			return default(TOutput);
		}
	}

    public interface ICategoryService
    {
		Task<IEnumerable<Category>> GetCategories();
	}

	public interface IUserService
	{
		Task<User> GetUserAsync(int userId);
	}

	public class ServiceClient : IItemService, IAddressService, ICategoryService, IUserService
	{		
		private readonly RequestSender client;
		private readonly IMapper mapper;

		public ServiceClient(RequestSender client, IMapper mapper)
		{
			this.client = client;
			this.mapper = mapper;
		}
		public async Task<IEnumerable<Category>> GetCategories()
			=> await client.GetResponse<IEnumerable<Category>>(HttpMethod.Get, $"category");

		public async Task<IEnumerable<ItemMini>> GetItemsMini() 
			=>	await client.GetResponse<IEnumerable<ItemMini>>(HttpMethod.Get, "item");

		//public async Task<Item> AddItem(Item item)
		//{
		//	var addedItem = mapper.Map<ItemForAdd>(item);
		//	return await client.GetResponse<ItemForAdd, Item>(HttpMethod.Post, "item", addedItem);		
		//}

		public async Task<User> GetUserAsync(int userId)
			=> await client.GetResponse<User>(HttpMethod.Get, $"user/{userId}");

		public async Task<IEnumerable<Address>> GetAddressesForUser(int userId) 
			=> await client.GetResponse<IEnumerable<Address>>(HttpMethod.Get, $"user/{userId}/address/");

		public async Task<Item> AddItemAsync(ItemForAdd itemForAdd)
		{
			return await client.GetResponse<ItemForAdd, Item>(HttpMethod.Post, $"item/", itemForAdd);
		}
	}
}
