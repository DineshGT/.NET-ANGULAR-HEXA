using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Context;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;

namespace SimplyFly.API.DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly SimplyFlyDbContext _context;

        public BookingRepository(SimplyFlyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync() =>
            await _context.Bookings.ToListAsync();

        public async Task<Booking?> GetByIdAsync(int id) =>
            await _context.Bookings.FindAsync(id);

        public async Task<IEnumerable<Booking>> GetByUserIdAsync(int userId) =>
            await _context.Bookings.Where(b => b.UserId == userId).ToListAsync();

        public async Task AddAsync(Booking entity) =>
            await _context.Bookings.AddAsync(entity);

        public void Update(Booking entity) =>
            _context.Bookings.Update(entity);

        public void Delete(Booking entity) =>
            _context.Bookings.Remove(entity);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
