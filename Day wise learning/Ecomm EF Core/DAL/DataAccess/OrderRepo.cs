using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class OrderRepo:IOrderRepo<Order>
    {
        public List<OrderWithCustDetails> GetOrderDetailsWithCustomerInfo()
        {
            using (ECommerceContext dbContext=new ECommerceContext())
            {
                var data = dbContext.Orders.Join(
                    dbContext.CustomerInfos,
                    o => o.EmailId,
                    c => c.EmailId,
                    (o, c) => new OrderWithCustDetails
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate,
                        CustEmail = c.EmailId,
                        Password = c.Password,
                    }
                    );

                return data.ToList();
            }
        }
    }
}
