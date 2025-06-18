using SimplyFly.API.DAL.Entities;

namespace SimplyFly.API.DAL.Interfaces
{
    public interface IFlightRepository : IRepository<Flight>
    {
        Task<IEnumerable<Flight>> GetByOwnerIdAsync(int ownerId);
    }
}
