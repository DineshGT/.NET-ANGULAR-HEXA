using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DTOs.Models.User;
using SimplyFly.API.Services.Interfaces;

namespace SimplyFly.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/user/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST: api/user
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        // PUT: api/user/5
        [Authorize(Roles = "Admin, User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO model)
        {
            // Validate path and body ID match
            if (id != model.UserId)
                return BadRequest("User ID mismatch");

            // Fetch existing user from DB (ensure they exist)
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound("User not found.");

            // Update only the allowed fields
            existingUser.Name = model.Name;
            existingUser.Gender = model.Gender;
            existingUser.Address = model.Address;
            existingUser.ContactNumber = model.ContactNumber;
            existingUser.Email = model.Email; // if editable

            // Save changes
            await _userService.UpdateUserAsync(existingUser);
            return NoContent(); // 204 success
        }



        //to get and update the profile

        [Authorize(Roles = "User,Owner,Admin")]
        [HttpGet("me")]
        public async Task<ActionResult<User>> GetMyProfile()
        {
            var userId = int.Parse(User.FindFirst("id")?.Value ?? "0");
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Authorize(Roles = "User,Owner,Admin")]
        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyProfile([FromBody] UserUpdateDTO dto)
        {
            var userId = int.Parse(User.FindFirst("id")?.Value ?? "0");
            if (userId != dto.UserId)
                return BadRequest("You are not authorized to update this profile.");

            var existingUser = await _userService.GetUserByIdAsync(userId);
            if (existingUser == null) return NotFound("User not found.");

            // Update only allowed fields
            existingUser.Name = dto.Name;
            existingUser.Gender = dto.Gender;
            existingUser.ContactNumber = dto.ContactNumber;
            existingUser.Address = dto.Address;

            await _userService.UpdateUserAsync(existingUser);
            return NoContent();
        }



        // DELETE: api/user/5
        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
