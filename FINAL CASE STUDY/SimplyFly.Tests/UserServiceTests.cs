using Moq;
using NUnit.Framework;
using SimplyFly.API.Services.Implementations;
using SimplyFly.API.DAL.Interfaces;
using SimplyFly.API.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyFly.Tests.Services
{
    public class UserServiceTests
    {
        private Mock<IUserRepository> _mockRepo;
        private UserService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IUserRepository>();
            _service = new UserService(_mockRepo.Object);
        }

        [Test]
        public async Task GetAllUsersAsync_ReturnsUserList()
        {
            // Arrange
            var mockUsers = new List<User>
            {
                new User { UserId = 1, Name = "Alice", Email = "alice@example.com" },
                new User { UserId = 2, Name = "Bob", Email = "bob@example.com" }
            };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(mockUsers);

            // Act
            var result = await _service.GetAllUsersAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            //Assert.That(result[0].Name, Is.EqualTo("Alice"));
        }

        [Test]
        public async Task DeleteUserAsync_CallsRepositoryDelete()
        {
            // Arrange
            var userId = 1;
            var user = new User { UserId = userId, Name = "Test" };
            _mockRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);

            // Act
            await _service.DeleteUserAsync(userId);

            // Assert
            _mockRepo.Verify(r => r.DeleteAsync(user), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetUserByIdAsync_UserNotFound_ReturnsNull()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((User)null);

            // Act
            var result = await _service.GetUserByIdAsync(999);

            // Assert
            Assert.IsNull(result);
        }
    }
}
