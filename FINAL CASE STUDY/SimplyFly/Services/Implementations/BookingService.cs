using Microsoft.EntityFrameworkCore;
using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;
using SimplyFly.API.DAL.Repositories;
using SimplyFly.API.Services.Interfaces;

namespace SimplyFly.API.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repo;

        public BookingService(IBookingRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync() => await _repo.GetAllAsync();

        public async Task<Booking?> GetBookingByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<IEnumerable<Booking>> GetBookingsByUserAsync(int userId)
            => await _repo.GetByUserIdAsync(userId);

        public async Task CreateBookingAsync(Booking booking)
        {
            booking.BookingDate = DateTime.Now;
            await _repo.AddAsync(booking);
            await _repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByOwnerAsync(int ownerId)
        {
            return await _repo.GetBookingsByOwnerAsync(ownerId);
        }


        public async Task CancelBookingAsync(int id)
        {
            var booking = await _repo.GetByIdAsync(id);
            if (booking != null)
            {
                booking.Status = "Cancelled";
                _repo.Update(booking);
                await _repo.SaveChangesAsync();
            }
        }
    }
}
