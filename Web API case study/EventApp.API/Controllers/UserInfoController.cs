using EventAppDAL.Entities;
using EventAppDAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IRepository<UserInfo> _userRepository;

        public UserInfoController(IRepository<UserInfo> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserById(string email)
        {
            var user = await _userRepository.GetByIdAsync(email);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserInfo user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
            return CreatedAtAction(nameof(GetUserById), new { email = user.EmailId }, user);
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> UpdateUser(string email, UserInfo user)
        {
            var existing = await _userRepository.GetByIdAsync(email);
            if (existing == null) return NotFound();

            existing.UserName = user.UserName;
            existing.Password = user.Password;
            existing.Role = user.Role;

            _userRepository.Update(existing);
            await _userRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            var user = await _userRepository.GetByIdAsync(email);
            if (user == null) return NotFound();

            _userRepository.Delete(user);
            await _userRepository.SaveAsync();
            return NoContent();
        }
    }
}
