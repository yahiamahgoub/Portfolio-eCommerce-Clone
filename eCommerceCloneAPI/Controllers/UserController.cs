using AutoMapper;
using DataLib.Models;
using DataLib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceClone.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private IUserRepository repository;
		private readonly IMapper mapper;
		private IGenericRepository<Address> genericRepository;

		private readonly ILogger<AddressController> logger;

		public UserController(ILogger<AddressController> _logger, IUserRepository _repository, IMapper mapper)
		{
			logger = _logger;
			repository = _repository;
			this.mapper = mapper;
		}

		[HttpGet]
		public List<string> GetUsers()
		{
			return new List<string>{"Ok", "Test"};
		}

		[HttpGet("{userId}", Name = "GetUserById")]
		public async Task<User> GetUserById(int userid, bool includeAddressList = true)
		{
			var user = await repository.GetById(userid, includeAddressList);
			return user;
		}
	}
}