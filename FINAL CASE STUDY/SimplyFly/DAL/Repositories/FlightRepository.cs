using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Context;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;

namespace SimplyFly.API.DAL.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly SimplyFlyDbContext _context;

        public FlightRepository(SimplyFlyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetAllAsync() => await _context.Flights.ToListAsync();

        public async Task<Flight?> GetByIdAsync(int id) => await _context.Flights.FindAsync(id);

        public async Task<IEnumerable<Flight>> GetByOwnerIdAsync(int ownerId)
        {
            return await _context.Flights.Where(f => f.OwnerId == ownerId).ToListAsync();
        }

        public async Task AddAsync(Flight entity) => await _context.Flights.AddAsync(entity);

        public void Update(Flight entity) => _context.Flights.Update(entity);

        public void Delete(Flight entity) => _context.Flights.Remove(entity);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
