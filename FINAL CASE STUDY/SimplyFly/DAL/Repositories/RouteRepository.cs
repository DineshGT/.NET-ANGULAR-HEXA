using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Context;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;

namespace SimplyFly.API.DAL.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly SimplyFlyDbContext _context;

        public RouteRepository(SimplyFlyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Routes>> GetAllAsync() => await _context.Routes.ToListAsync();

        public async Task<Routes?> GetByIdAsync(int id) =>
            await _context.Routes.FindAsync(id);

        public async Task<IEnumerable<Routes>> GetByFlightIdAsync(int flightId) =>
            await _context.Routes.Where(r => r.FlightId == flightId).ToListAsync();

        public async Task<IEnumerable<Routes>> SearchRoutesAsync(string origin, string destination, DateTime date)
        {
            return await _context.Routes
                .Include(r => r.Flight)
                .Where(r =>
                    r.Origin == origin &&
                    r.Destination == destination &&
                    r.DepartureTime.Date <= date.Date &&
                    r.Flight.IsApproved) 
                .ToListAsync();
        }


        public async Task AddAsync(Routes entity) =>
            await _context.Routes.AddAsync(entity);

        public void Update(Routes entity) =>
            _context.Routes.Update(entity);

        public void Delete(Routes entity) =>
            _context.Routes.Remove(entity);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        
    }
}
