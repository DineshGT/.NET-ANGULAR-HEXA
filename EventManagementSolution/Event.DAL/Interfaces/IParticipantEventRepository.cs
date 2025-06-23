using Event.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Interfaces
{
    public interface IParticipantEventRepository
    {
        Task<IEnumerable<ParticipantEventDetails>> GetAllParticipantEventsAsync();
        Task<ParticipantEventDetails?> GetByIdAsync(int id);
        Task AddAsync(ParticipantEventDetails details);
        Task UpdateAsync(ParticipantEventDetails details);
        Task DeleteAsync(int id);
    }

}
