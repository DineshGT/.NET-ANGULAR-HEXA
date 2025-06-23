using Event.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventDetails>> GetAllEventsAsync();
        Task<EventDetails?> GetEventByIdAsync(int eventId);
        Task AddEventAsync(EventDetails eventDetails);
        Task UpdateEventAsync(EventDetails eventDetails);
        Task DeleteEventAsync(int eventId);
    }

}
