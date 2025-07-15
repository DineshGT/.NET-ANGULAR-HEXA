using Moq;
using NUnit.Framework;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;
using SimplyFly.API.DTO.Models.Auth;
using SimplyFly.API.Services.Implementations;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace SimplyFly.Tests.Services
{
    [TestFixture]
    public class AuthServiceTests
    {
        private Mock<IUserRepository> _mockUserRepo;
        private Mock<IConfiguration> _mockConfig;
        private AuthService _authService;

        [SetUp]
        public void Setup()
        {
            _mockUserRepo = new Mock<IUserRepository>();
            _mockConfig = new Mock<IConfiguration>();

            _mockConfig.Setup(x => x["Jwt:Key"]).Returns("YourTestSecretKeyMustBeLongEnough");
            _mockConfig.Setup(x => x["Jwt:Issuer"]).Returns("TestIssuer");
            _mockConfig.Setup(x => x["Jwt:Audience"]).Returns("TestAudience");

            _authService = new AuthService(_mockUserRepo.Object, _mockConfig.Object);
        }

        [Test]
        public async Task RegisterAsync_NewEmail_ReturnsAuthResponse()
        {
            // Arrange
            var request = new RegisterRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Password = "password123",
                Role = "Admin"
            };

            _mockUserRepo.Setup(repo => repo.GetByEmailAsync(request.Email))
                         .ReturnsAsync((User)null);

            _mockUserRepo.Setup(repo => repo.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            _mockUserRepo.Setup(repo => repo.SaveChangesAsync()).Returns(Task.CompletedTask);

            // Act
            var result = await _authService.RegisterAsync(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(request.Email, result.Email);
            Assert.AreEqual(request.Role, result.Role);
            Assert.IsNotEmpty(result.Token);
        }

        [Test]
        public async Task RegisterAsync_ExistingEmail_ReturnsNull()
        {
            // Arrange
            var request = new RegisterRequest { Email = "exists@example.com" };
            _mockUserRepo.Setup(r => r.GetByEmailAsync(request.Email))
                         .ReturnsAsync(new User());

            // Act
            var result = await _authService.RegisterAsync(request);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task LoginAsync_ValidCredentials_ReturnsAuthResponse()
        {
            // Arrange
            var request = new LoginRequest { Email = "user@example.com", Password = "password123" };

            var user = new User
            {
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "Admin",
                UserId = 1
            };

            _mockUserRepo.Setup(r => r.GetByEmailAsync(request.Email))
                         .ReturnsAsync(user);

            // Act
            var result = await _authService.LoginAsync(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(request.Email, result.Email);
        }

        [Test]
        public async Task LoginAsync_InvalidPassword_ReturnsNull()
        {
            var request = new LoginRequest { Email = "user@example.com", Password = "wrongpass" };
            var user = new User
            {
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("correctpass"),
                Role = "Admin"
            };

            _mockUserRepo.Setup(r => r.GetByEmailAsync(request.Email)).ReturnsAsync(user);

            var result = await _authService.LoginAsync(request);

            Assert.IsNull(result);
        }
    }
}
