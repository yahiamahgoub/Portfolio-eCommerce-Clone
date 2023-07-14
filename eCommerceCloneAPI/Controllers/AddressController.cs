using AutoMapper;
using DataLib.Models;
using DataLib.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eCommerceClone.Controllers
{
	[ApiController]
	[Route("user/{userId}/[controller]")]
	public class AddressController : ControllerBase
	{		
		private IUserRepository repository;
		private IGenericRepository<Address> genericRepository;

		private readonly ILogger<AddressController> logger;

		public AddressController(ILogger<AddressController> _logger, IUserRepository _repository, IGenericRepository<Address> genericRepository)
		{
			logger = _logger;
			repository = _repository;
			this.genericRepository = genericRepository;
		}

		[HttpGet(Name = "GetAddressList")]
		public async Task<IEnumerable<Address>> GetAddressListForUser(int userid) => await repository.GetAddressListForUserAsync(userid);


		[HttpGet("{addressId}", Name = "GetAddress")]
		public async Task<Address?> GetAddressForUser (int userId, int addressId) => await repository.GetAddressForUserAsync(userId, addressId);

		[HttpPost]
		public async Task<ActionResult> Add(int userId, Address address)
		{
			if (!await repository.ExistsAsync(userId))
			{
				logger.LogInformation($"User with id {userId} wasn't found!");
				return NotFound();
			}
			await repository.AddAddressForUserAsync(userId, address);
			return CreatedAtAction("GetAddress", new { address.AddressId }, address);
		}

		[HttpDelete("{addressId}")]
		public async Task<ActionResult> Delete(int userId, int addressId)
		{
			if (!await repository.ExistsAsync(userId))
			{
				logger.LogInformation($"User with id {userId} wasn't found!");
				return NotFound();
			}

			var address = await repository.GetAddressForUserAsync(userId, addressId);

			await repository.DeleteAddressForUserAsync(userId, address);
			await repository.SaveChangesAsync();			
			return NoContent();
		}				
	}
}