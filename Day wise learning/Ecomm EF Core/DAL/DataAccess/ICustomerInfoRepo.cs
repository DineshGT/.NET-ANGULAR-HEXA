using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface ICustomerInfoRepo<T>
    {
        T RegisterCustomer(T customer);

        T UpdateCustomerProfile(T customer);

        T DeleteCustomer(T customer);

        T ValidateCustomer(T customer);

        T GetCustomerById(string emailId);

        List<T> GetAllCustomers();
    }
}
