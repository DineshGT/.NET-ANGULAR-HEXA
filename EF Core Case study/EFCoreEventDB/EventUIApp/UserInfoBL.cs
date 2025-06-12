using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUIApp
{
    public class UserInfoBL
    {
        private readonly IUserInfoRepo<UserInfo> _userInfoRepo;

        public UserInfoBL(IUserInfoRepo<UserInfo> userInfoRepo)
        {
            _userInfoRepo = userInfoRepo;
        }

        public void AddUser(UserInfo user)
        {
            _userInfoRepo.Add(user);
            _userInfoRepo.Save();
        }

        public List<UserInfo> GetAllUsers()
        {
            return _userInfoRepo.GetAll();
        }

        public UserInfo GetUserById(string emailId)
        {
            return _userInfoRepo.GetById(emailId);
        }

        public void UpdateUser(UserInfo user)
        {
            _userInfoRepo.Update(user);
            _userInfoRepo.Save();
        }

        public void DeleteUser(string emailId)
        {
            _userInfoRepo.Delete(emailId);
            _userInfoRepo.Save();
        }
    }

}
