using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Context;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;

namespace SimplyFly.API.DAL.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly SimplyFlyDbContext _context;

        public SeatRepository(SimplyFlyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetAllAsync() =>
            await _context.Seats.ToListAsync();

        public async Task<Seat?> GetByIdAsync(int id) =>
            await _context.Seats.FindAsync(id);

        public async Task<IEnumerable<Seat>> GetByRouteIdAsync(int routeId) =>
            await _context.Seats.Where(s => s.RouteId == routeId).ToListAsync();

        public async Task AddAsync(Seat entity) =>
            await _context.Seats.AddAsync(entity);

        public void Update(Seat entity) =>
            _context.Seats.Update(entity);

        public void Delete(Seat entity) =>
            _context.Seats.Remove(entity);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
