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
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly EventDbContext _context;

        public SpeakerRepository(EventDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpeakersDetails>> GetAllSpeakersAsync()
        {
            return await _context.Speakers.ToListAsync();
        }

        public async Task<SpeakersDetails?> GetSpeakerByIdAsync(int speakerId)
        {
            return await _context.Speakers.FindAsync(speakerId);
        }

        public async Task AddSpeakerAsync(SpeakersDetails speaker)
        {
            _context.Speakers.Add(speaker);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSpeakerAsync(SpeakersDetails speaker)
        {
            _context.Speakers.Update(speaker);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpeakerAsync(int speakerId)
        {
            var speaker = await _context.Speakers.FindAsync(speakerId);
            if (speaker != null)
            {
                _context.Speakers.Remove(speaker);
                await _context.SaveChangesAsync();
            }
        }
    }

}
