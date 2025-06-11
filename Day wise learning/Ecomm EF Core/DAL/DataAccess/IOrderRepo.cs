using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IOrderRepo<T>
    {
        public List<OrderWithCustDetails> GetOrderDetailsWithCustomerInfo();
    }
}
