using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUIApp
{
    public class SessionInfoBL
    {
        private readonly ISessionInfoRepo<SessionInfo> _sessionRepo;

        public SessionInfoBL(ISessionInfoRepo<SessionInfo> sessionRepo)
        {
            _sessionRepo = sessionRepo;
        }

        public void AddSession(SessionInfo session)
        {
            _sessionRepo.Add(session);
            _sessionRepo.Save();
        }

        public List<SessionInfo> GetAllSessions()
        {
            return _sessionRepo.GetAll();
        }

        public SessionInfo GetSessionById(int id)
        {
            return _sessionRepo.GetById(id);
        }

        public void UpdateSession(SessionInfo session)
        {
            _sessionRepo.Update(session);
            _sessionRepo.Save();
        }

        public void DeleteSession(int id)
        {
            _sessionRepo.Delete(id);
            _sessionRepo.Save();
        }

        public List<SessionInfo> GetSessionsByEventId(int eventId)
        {
            return _sessionRepo.GetByEventId(eventId);
        }
    }

}
