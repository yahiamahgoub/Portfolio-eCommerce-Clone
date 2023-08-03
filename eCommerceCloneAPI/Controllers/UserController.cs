using AutoMapper;
using DataLib.DataStorage;
using DataLib.Models;
using DataLib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceClone.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private IUserRepository userRepository;
		private readonly IMapper mapper;		
		private readonly ILogger<AddressController> logger;

		public UserController(ILogger<AddressController> _logger, IUserRepository _repository, IMapper mapper)
		{
			logger = _logger;
			userRepository = _repository;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserForRead>>> GetUsers()
		{
			var users = await userRepository.GetAllAsync();
			return Ok(mapper.Map<IEnumerable<UserForRead>>(users));
		}

		[HttpGet("{userId}", Name = "GetUserById")]
		public async Task<UserForRead> GetUserById(int userid, bool includeAddressList = true)
		{
			var user = await userRepository.GetById(userid, includeAddressList);
			return mapper.Map<UserForRead>(user);
		}

		[HttpPost]
		public async Task<ActionResult<UserForRead>> AddUser(UserForAdd userForAdd)
		{
			var user = mapper.Map<User>(userForAdd);

			await userRepository.AddAsync(user);
			await userRepository.SaveChangesAsync();

			var userForRead = mapper.Map<UserForRead>(user);

			return CreatedAtAction("GetUserById", new { userId = userForRead.UserId}, userForRead);
		}

		[HttpPut("{userId}")]
		public async Task<ActionResult> UpdateUser(int userId, UserForUpdate userForUpdate)
		{
			if(!await userRepository.ExistsAsync(userId))
			{
				logger.Log(LogLevel.Error, $"User with id {userId} was not found!");
				return NotFound();
			}

			var user = userRepository.GetByIdAsync(userId);
			mapper.Map(userForUpdate, user, typeof(UserForUpdate), typeof(User));
			
			await userRepository.SaveChangesAsync();			

			return NoContent();
		}
	}
}