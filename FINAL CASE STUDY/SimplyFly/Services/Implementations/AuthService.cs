using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;
using SimplyFly.API.DTO.Models.Auth;
using SimplyFly.API.DTOs.Models.Auth;
using SimplyFly.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimplyFly.API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<AuthResponse?> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userRepo.GetByEmailAsync(request.Email);
            if (existingUser != null) return null;

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = request.Role,
                ContactNumber = "NA",
                Address = "NA",
                Gender = "NA"
            };

            await _userRepo.AddAsync(user);
            await _userRepo.SaveChangesAsync();

            return GenerateToken(user);
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userRepo.GetByEmailAsync(request.Email);
            if (user == null) return null;

            var isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isValid) return null;

            return GenerateToken(user);
        }

        private AuthResponse GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("id", user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new AuthResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Role = user.Role,
                Email = user.Email
            };
        }
    }
}
