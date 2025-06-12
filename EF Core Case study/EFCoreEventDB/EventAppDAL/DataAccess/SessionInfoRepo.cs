using EventAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAppDAL.DataAccess
{
    public class SessionInfoRepo
    {
        private readonly EventDBContext _context;

        public SessionInfoRepo(EventDBContext context)
        {
            _context = context;
        }

        public List<SessionInfo> GetAll()
        {
            return _context.SessionInfos.ToList();
        }

        public SessionInfo GetById(int id)
        {
            return _context.SessionInfos.FirstOrDefault(s => s.SessionId == id);
        }

        public List<SessionInfo> GetByEventId(int eventId)
        {
            return _context.SessionInfos.Where(s => s.EventId == eventId).ToList();
        }

        public void Add(SessionInfo session)
        {
            _context.SessionInfos.Add(session);
        }

        public void Update(SessionInfo session)
        {
            _context.SessionInfos.Update(session);
        }

        public void Delete(int id)
        {
            var sess = GetById(id);
            if (sess != null)
                _context.SessionInfos.Remove(sess);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
