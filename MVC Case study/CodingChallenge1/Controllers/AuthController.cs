using CodingChallenge1.Models;
using CodingChallenge1.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel user)
        {
            // Dummy check: username = admin, password = 1234
            if (user.Username == "admin" && user.Password == "1234")
            {
                var token = _jwtService.GenerateToken(user.Username);
                return Ok(new { token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
