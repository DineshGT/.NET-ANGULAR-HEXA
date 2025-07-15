using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DTOs.Models.Route;

namespace SimplyFly.API.Services.Interfaces
{
    public interface IRoutesService
    {
        Task<IEnumerable<Routes>> GetAllRoutesAsync();
        Task<Routes?> GetRouteByIdAsync(int id);
        Task<IEnumerable<Routes>> SearchRoutesAsync(string origin, string destination, DateTime date);

        Task<IEnumerable<Routes>> GetRoutesByFlightIdAsync(int flightId);
        Task CreateRouteAsync(Routes route);
        Task<bool> UpdateRouteAsync(RouteCreateDTO dto);
        Task DeleteRouteAsync(int id);
    }
}
