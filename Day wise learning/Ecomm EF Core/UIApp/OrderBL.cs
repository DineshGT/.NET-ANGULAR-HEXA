using DAL.DataAccess;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIApp
{
    public class OrderBL
    {
        private readonly IOrderRepo<Order> _orderRepo;
        public OrderBL(IOrderRepo<Order> orderRepo)
        {
            this._orderRepo = orderRepo;
        }

        public List<OrderWithCustDetails> GetOrderWithCust()
        {
          var details=  _orderRepo.GetOrderDetailsWithCustomerInfo();
            return details;
        }
    }
}
