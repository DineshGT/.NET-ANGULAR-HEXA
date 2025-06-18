using SimplyFly.API.DAL.Entities;

namespace SimplyFly.API.DAL.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetByUserIdAsync(int userId);
    }
}
