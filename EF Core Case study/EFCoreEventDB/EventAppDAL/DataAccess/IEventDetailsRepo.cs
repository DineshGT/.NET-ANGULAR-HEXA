using EventAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAppDAL.DataAccess
{
    public interface IEventDetailsRepo
    {
        List<EventDetails> GetAll();
        EventDetails GetById(int id);
        List<EventDetails> GetByCategory(string category);
        void Add(EventDetails eventDetail);
        void Update(EventDetails eventDetail);
        void Delete(int id);
        void Save();
    }
}
