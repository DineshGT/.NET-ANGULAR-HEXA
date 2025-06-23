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
    public class SessionRepository : ISessionRepository
    {
        private readonly EventDbContext _context;

        public SessionRepository(EventDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SessionInfo>> GetAllSessionsAsync()
        {
            return await _context.Sessions.ToListAsync();
        }

        public async Task<SessionInfo?> GetSessionByIdAsync(int sessionId)
        {
            return await _context.Sessions.FindAsync(sessionId);
        }

        public async Task AddSessionAsync(SessionInfo session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSessionAsync(SessionInfo session)
        {
            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSessionAsync(int sessionId)
        {
            var session = await _context.Sessions.FindAsync(sessionId);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }
    }

}
