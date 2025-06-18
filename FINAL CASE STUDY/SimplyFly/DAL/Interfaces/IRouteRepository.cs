using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Repositories;

namespace SimplyFly.API.DAL.Interfaces
{
    public interface IRouteRepository : IRepository<Routes>
    {
        Task<IEnumerable<Routes>> GetByFlightIdAsync(int flightId);
        Task<IEnumerable<Routes>> SearchAsync(string origin, string destination, DateTime journeyDate);
    }
}
