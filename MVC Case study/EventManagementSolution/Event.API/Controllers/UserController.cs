using Event.DAL.Entities;
using Event.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetAllUsers()
        {
            var users = await _userRepo.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UserInfo>> GetUser(string email)
        {
            var user = await _userRepo.GetUserByEmailAsync(email);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserInfo user)
        {
            await _userRepo.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { email = user.EmailId }, user);
        }

        [HttpPut("{email}")]
        public async Task<ActionResult> UpdateUser(string email, UserInfo user)
        {
            if (email != user.EmailId) return BadRequest();
            await _userRepo.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> DeleteUser(string email)
        {
            await _userRepo.DeleteUserAsync(email);
            return NoContent();
        }
    }

}
