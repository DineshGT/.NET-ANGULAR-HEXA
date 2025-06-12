using EventAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAppDAL.DataAccess
{
    public interface IUserInfoRepo
    {
        List<UserInfo> GetAll();
        UserInfo GetByEmail(string email);
        void Add(UserInfo user);
        void Update(UserInfo user);
        void Delete(string email);
        void Save();
    }
}
