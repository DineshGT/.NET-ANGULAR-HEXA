using Event.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<SessionInfo>> GetAllSessionsAsync();
        Task<SessionInfo?> GetSessionByIdAsync(int sessionId);
        Task AddSessionAsync(SessionInfo session);
        Task UpdateSessionAsync(SessionInfo session);
        Task DeleteSessionAsync(int sessionId);
    }

}
