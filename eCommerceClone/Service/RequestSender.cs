using Newtonsoft.Json;
//using Org.Apache.Http.Client;
using System.Text;

namespace eCommerceClone.Service
{

	//restsharp!

	public class RequestSender
	{
		private readonly HttpClient client;

		public RequestSender(HttpClient httpClient)
		{
			this.client = httpClient;
			//client = new HttpClient { BaseAddress = new Uri($"{ServiceSettings.URL}/") };
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
}
