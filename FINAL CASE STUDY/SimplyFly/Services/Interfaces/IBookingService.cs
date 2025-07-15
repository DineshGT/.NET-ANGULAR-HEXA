using SimplyFly.API.DAL.Entities;

namespace SimplyFly.API.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking?> GetBookingByIdAsync(int id);
        Task<IEnumerable<Booking>> GetBookingsByUserAsync(int userId);
        Task CreateBookingAsync(Booking booking);
        Task CancelBookingAsync(int id);
        Task<IEnumerable<Booking>> GetBookingsByOwnerAsync(int ownerId);

    }
}
