using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Context;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;

namespace SimplyFly.API.DAL.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly SimplyFlyDbContext _context;

        public PaymentRepository(SimplyFlyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync() =>
            await _context.Payments.ToListAsync();

        public async Task<Payment?> GetByIdAsync(int id) =>
            await _context.Payments.FindAsync(id);

        public async Task<IEnumerable<Payment>> GetByBookingIdAsync(int bookingId) =>
            await _context.Payments.Where(p => p.BookingId == bookingId).ToListAsync();

        public async Task AddAsync(Payment entity) =>
            await _context.Payments.AddAsync(entity);

        public void Update(Payment entity) =>
            _context.Payments.Update(entity);

        public void Delete(Payment entity) =>
            _context.Payments.Remove(entity);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
