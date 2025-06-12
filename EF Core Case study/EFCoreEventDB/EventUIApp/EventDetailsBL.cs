using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUIApp
{
    public class EventDetailsBL
    {
        private readonly IEventDetailsRepo<EventDetails> _eventRepo;

        public EventDetailsBL(IEventDetailsRepo<EventDetails> eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public void AddEvent(EventDetails evt)
        {
            _eventRepo.Add(evt);
            _eventRepo.Save();
        }

        public List<EventDetails> GetAllEvents()
        {
            return _eventRepo.GetAll();
        }

        public EventDetails GetEventById(int id)
        {
            return _eventRepo.GetById(id);
        }

        public void UpdateEvent(EventDetails evt)
        {
            _eventRepo.Update(evt);
            _eventRepo.Save();
        }

        public void DeleteEvent(int id)
        {
            _eventRepo.Delete(id);
            _eventRepo.Save();
        }

        public void AddEventUsingSP(EventDetails evt)
        {
            _eventRepo.AddUsingSP(evt);
        }

        public void UpdateEventUsingSP(EventDetails evt)
        {
            _eventRepo.UpdateUsingSP(evt);
        }

        public void DeleteEventUsingSP(int id)
        {
            _eventRepo.DeleteUsingSP(id);
        }
    }

}
