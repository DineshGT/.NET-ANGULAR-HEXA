using SimplyFly.API.DAL.Entities;

namespace SimplyFly.API.DAL.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task<IEnumerable<Seat>> GetByRouteIdAsync(int routeId);
    }
}
