using EventAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAppDAL.DataAccess
{
    public class EventDetailsRepo
    {
        private readonly EventDBContext _context;

        public EventDetailsRepo(EventDBContext context)
        {
            _context = context;
        }

        public List<EventDetails> GetAll()
        {
            return _context.EventDetails.ToList();
        }

        public EventDetails GetById(int id)
        {
            return _context.EventDetails.FirstOrDefault(e => e.EventId == id);
        }

        public List<EventDetails> GetByCategory(string category)
        {
            return _context.EventDetails.Where(e => e.EventCategory == category).ToList();
        }

        public void Add(EventDetails eventDetail)
        {
            _context.EventDetails.Add(eventDetail);
        }

        public void Update(EventDetails eventDetail)
        {
            _context.EventDetails.Update(eventDetail);
        }

        public void Delete(int id)
        {
            var evt = GetById(id);
            if (evt != null)
                _context.EventDetails.Remove(evt);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
