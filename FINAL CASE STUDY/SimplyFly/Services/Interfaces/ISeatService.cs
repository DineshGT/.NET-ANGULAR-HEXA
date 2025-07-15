using SimplyFly.API.DAL.Entities;

namespace SimplyFly.API.Services.Interfaces
{
    public interface ISeatService
    {
        Task<IEnumerable<Seat>> GetSeatsByRouteAsync(int routeId);
        Task MarkSeatAsBookedAsync(int seatId);
        Task CreateSeatAsync(Seat seat);
        Task BulkCreateSeatsAsync(int routeId, int totalSeats);
        Task ResetSeatAsync(int seatId);



    }
}
