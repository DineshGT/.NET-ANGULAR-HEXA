using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class AdminInfoRepo : IAdminInfoRepo<AdminInfo>
    {
        public AdminInfo ValidateAdmin(AdminInfo adminInfo)
        {
            using (ECommerceContext dbContext=new ECommerceContext())
            {
                var validatedAdmin = dbContext.AdminInfos.Where(
                    admin=>admin.EmailId.Equals(adminInfo.EmailId) &&
                    admin.Password.Equals(adminInfo.Password) &&
                    admin.Role.Equals(adminInfo.Role)
                    ).FirstOrDefault();
                return  validatedAdmin;
            }
        }
    }
}
