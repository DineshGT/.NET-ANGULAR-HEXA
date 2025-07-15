using SimplyFly.API.DAL.Entities;

namespace SimplyFly.API.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void DeleteAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}
