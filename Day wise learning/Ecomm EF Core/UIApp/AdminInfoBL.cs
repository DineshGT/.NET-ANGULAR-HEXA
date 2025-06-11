using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataAccess;
using DAL.Models;
namespace UIApp
{
    public class AdminInfoBL
    {
        private readonly IAdminInfoRepo<AdminInfo> _adminInfoRepo;
        public AdminInfoBL(IAdminInfoRepo<AdminInfo> adminInfoRepo)
        {
            this._adminInfoRepo = adminInfoRepo;
        }

        public bool ValidateAdmin(AdminInfo adminInfo)
        {
          var admin=  _adminInfoRepo.ValidateAdmin(adminInfo);
            if (admin != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
