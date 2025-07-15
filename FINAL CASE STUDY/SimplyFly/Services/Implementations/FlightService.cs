using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;
using SimplyFly.API.DAL.Repositories;
using SimplyFly.API.Services.Interfaces;

namespace SimplyFly.API.Services.Implementations
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _repo;

        public FlightService(IFlightRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Flight>> GetAllFlightsAsync() => await _repo.GetAllAsync();

        public async Task<Flight?> GetFlightByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<IEnumerable<Flight>> GetFlightsByOwnerAsync(int ownerId) => await _repo.GetByOwnerIdAsync(ownerId);

        public async Task CreateFlightAsync(Flight flight)
        {
            await _repo.AddAsync(flight);
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            _repo.Update(flight);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(int id)
        {
            var flight = await _repo.GetByIdAsync(id);
            if (flight != null)
            {
                _repo.Delete(flight);
                await _repo.SaveChangesAsync();
            }
        }

        //public async Task<IEnumerable<Flight>> SearchFlightsAsync(string origin, string destination, DateTime date)
        //{
        //    return await _context.Flights
        //        .Where(f => f.Origin == origin &&
        //                    f.Destination == destination &&
        //                    f.DepartureDate.Date == date.Date &&
        //                    f.IsApproved) // Optional: only show approved flights
        //        .ToListAsync();
        //}

        // for approval
        public async Task ApproveFlightAsync(int flightId)
        {
            await _repo.ApproveFlightAsync(flightId);
            await _repo.SaveChangesAsync();
        }
    }
}
