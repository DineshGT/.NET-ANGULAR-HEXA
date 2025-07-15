using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;
using SimplyFly.API.DAL.Repositories;
using SimplyFly.API.Services.Interfaces;
using SimplyFly.API.DTOs.Models.Route;

namespace SimplyFly.API.Services.Implementations
{
    public class RoutesService : IRoutesService
    {
        private readonly IRouteRepository _repo;

        public RoutesService(IRouteRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Routes>> GetAllRoutesAsync() =>
            await _repo.GetAllAsync();

        public async Task<Routes?> GetRouteByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<IEnumerable<Routes>> SearchRoutesAsync(string origin, string destination, DateTime date) =>
            await _repo.SearchRoutesAsync(origin, destination, date);

        public async Task<IEnumerable<Routes>> GetRoutesByFlightIdAsync(int flightId) =>
            await _repo.GetByFlightIdAsync(flightId);

        public async Task CreateRouteAsync(Routes route)
        {
            await _repo.AddAsync(route);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool> UpdateRouteAsync(RouteCreateDTO dto)
        {
            var route = await _repo.GetByIdAsync(dto.RouteId);
            if (route == null) return false;

            route.Origin = dto.Origin;
            route.Destination = dto.Destination;
            route.DepartureTime = dto.DepartureTime;
            route.ArrivalTime = dto.ArrivalTime;
            route.Fare = dto.Fare;
            route.FlightId = dto.FlightId;

            _repo.Update(route);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task DeleteRouteAsync(int id)
        {
            var route = await _repo.GetByIdAsync(id);
            if (route != null)
            {
                _repo.Delete(route);
                await _repo.SaveChangesAsync();
            }
        }
    }

}
