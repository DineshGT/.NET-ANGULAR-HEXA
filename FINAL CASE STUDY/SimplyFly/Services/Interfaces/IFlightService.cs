using SimplyFly.API.DAL.Entities;

namespace SimplyFly.API.Services.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetAllFlightsAsync();
        Task<Flight?> GetFlightByIdAsync(int id);
        Task<IEnumerable<Flight>> GetFlightsByOwnerAsync(int ownerId);
        Task CreateFlightAsync(Flight flight);
        Task UpdateFlightAsync(Flight flight);
        Task DeleteFlightAsync(int id);

        //Task SearchFlightAsync(string origin, string destination, DateTime date);
        Task ApproveFlightAsync(int flightId);
    }
}
