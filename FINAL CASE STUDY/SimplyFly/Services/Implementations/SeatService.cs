using SimplyFly.API.DAL.Entities;
using SimplyFly.API.DAL.Interfaces;
using SimplyFly.API.DAL.Repositories;
using SimplyFly.API.Services.Interfaces;

namespace SimplyFly.API.Services.Implementations
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _repo;

        public SeatService(ISeatRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Seat>> GetSeatsByRouteAsync(int routeId)
            => await _repo.GetByRouteIdAsync(routeId);

        public async Task MarkSeatAsBookedAsync(int seatId)
        {
            var seat = await _repo.GetByIdAsync(seatId);
            if (seat != null)
            {
                seat.IsBooked = true;
                _repo.Update(seat);
                await _repo.SaveChangesAsync();
            }
        }

        public async Task CreateSeatAsync(Seat seat)
        {
            await _repo.AddAsync(seat);
            await _repo.SaveChangesAsync();
        }

        public async Task BulkCreateSeatsAsync(int routeId, int totalSeats)
        {
            var seats = new List<Seat>();
            for (int i = 1; i <= totalSeats; i++)
            {
                seats.Add(new Seat
                {
                    SeatNumber = $"S{i:D2}", // Example: S01, S02
                    IsBooked = false,
                    RouteId = routeId
                });
            }

            foreach (var seat in seats)
            {
                await _repo.AddAsync(seat);
            }

            await _repo.SaveChangesAsync();
        }

        public async Task ResetSeatAsync(int seatId)
        {
            var seat = await _repo.GetByIdAsync(seatId);
            if (seat != null)
            {
                seat.IsBooked = false;
                _repo.Update(seat);
                await _repo.SaveChangesAsync();
            }
        }
    }
}
