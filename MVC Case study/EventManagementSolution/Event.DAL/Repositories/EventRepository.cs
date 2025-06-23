using Event.DAL.Context;
using Event.DAL.Entities;
using Event.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _context;

        public EventRepository(EventDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventDetails>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<EventDetails?> GetEventByIdAsync(int eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }

        public async Task AddEventAsync(EventDetails eventDetails)
        {
            _context.Events.Add(eventDetails);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(EventDetails eventDetails)
        {
            _context.Events.Update(eventDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var eventDetails = await _context.Events.FindAsync(eventId);
            if (eventDetails != null)
            {
                _context.Events.Remove(eventDetails);
                await _context.SaveChangesAsync();
            }
        }
    }

}
