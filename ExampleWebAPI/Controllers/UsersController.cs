using DataBaseAccessLayer.Data.Interfaces;
using DataBaseAccessLayer.Enitites;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger,
            IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get(string sortBy = "Id")
        {
            return await _userRepository.GetUsersAsync(sortBy);
        }

        [HttpGet("{id}")]
        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(User user)
        {
            return await _userRepository.CreateUserAsync(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userRepository.UpdateUser(id,user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userRepository.DeleteUser(id);

            return NoContent();
        }
    }
}