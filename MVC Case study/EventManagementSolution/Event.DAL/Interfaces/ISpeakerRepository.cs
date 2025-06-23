using Event.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Interfaces
{
    public interface ISpeakerRepository
    {
        Task<IEnumerable<SpeakersDetails>> GetAllSpeakersAsync();
        Task<SpeakersDetails?> GetSpeakerByIdAsync(int speakerId);
        Task AddSpeakerAsync(SpeakersDetails speaker);
        Task UpdateSpeakerAsync(SpeakersDetails speaker);
        Task DeleteSpeakerAsync(int speakerId);
    }

}
