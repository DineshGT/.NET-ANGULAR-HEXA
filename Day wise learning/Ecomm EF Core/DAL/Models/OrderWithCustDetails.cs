using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderWithCustDetails
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustEmail { get; set; }
        public string  Password { get; set; }
    }
}
