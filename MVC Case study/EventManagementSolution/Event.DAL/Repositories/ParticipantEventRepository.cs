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
    public class ParticipantEventRepository : IParticipantEventRepository
    {
        private readonly EventDbContext _context;

        public ParticipantEventRepository(EventDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParticipantEventDetails>> GetAllParticipantEventsAsync()
        {
            return await _context.ParticipantEvents.ToListAsync();
        }

        public async Task<ParticipantEventDetails?> GetByIdAsync(int id)
        {
            return await _context.ParticipantEvents.FindAsync(id);
        }

        public async Task AddAsync(ParticipantEventDetails details)
        {
            _context.ParticipantEvents.Add(details);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ParticipantEventDetails details)
        {
            _context.ParticipantEvents.Update(details);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _context.ParticipantEvents.FindAsync(id);
            if (record != null)
            {
                _context.ParticipantEvents.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }

}
