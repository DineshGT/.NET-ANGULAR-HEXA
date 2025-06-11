using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class CustomerInfoRepo : ICustomerInfoRepo<CustomerInfo>
    {
        public CustomerInfo DeleteCustomer(CustomerInfo customer)
        {
            using (ECommerceContext dbContext=new ECommerceContext())
            {
                var existingCust = dbContext.CustomerInfos.Where(cust=>cust.EmailId.Equals(customer.EmailId)).FirstOrDefault();
                if (existingCust != null)
                {
                    dbContext.CustomerInfos.Remove(existingCust);//Remove() method will change current state of an entity from Un-Changed to Removed
                    dbContext.SaveChanges();//SaveChanges() method will observe current state of an entity an build a t-Sql statement (Delete from CustomerInfo where...)
                    return existingCust;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<CustomerInfo> GetAllCustomers()
        {
            using (ECommerceContext dbContext=new ECommerceContext())
            {
                var customers=dbContext.CustomerInfos.ToList();
                return customers;
            }
        }

        public CustomerInfo GetCustomerById(string emailId)
        {
            using (ECommerceContext dbContext=new ECommerceContext())
            {
               var cust= dbContext.CustomerInfos.Where(cust => cust.EmailId.Equals(emailId)).FirstOrDefault();
                return cust;
            }
        }

        public CustomerInfo RegisterCustomer(CustomerInfo customer)
        {
            using (ECommerceContext dbContext=new ECommerceContext())
            {
                dbContext.CustomerInfos.Add(customer); //Add() method will change a state of an entity from Un-Changed to Added
                dbContext.SaveChanges(); //SaveChanges() will observe current state of an entity and it will build t-Sql statement (insert into CustomerInfo values(...))
                return customer;
            }
        }

        public CustomerInfo UpdateCustomerProfile(CustomerInfo customer)
        {
            using (ECommerceContext dbContext=new ECommerceContext())
            {
                var existingCust = dbContext.CustomerInfos.Where(cust => cust.EmailId.Equals(customer.EmailId)).FirstOrDefault();
                if (existingCust!=null)
                {
                    //Current entity state will be changed from Un-Changed to Modified
                    existingCust.Password = customer.Password;
                    existingCust.Role=customer.Role;
                    dbContext.SaveChanges();//SaveChanges() will observe current entity state and build t-Sql statement (Update CustomerInfo Set....)
                    return existingCust ;
                }
                else
                {
                    return null;
                }
            }
        }

        public CustomerInfo ValidateCustomer(CustomerInfo customer)
        {
            using (ECommerceContext dbContext=new ECommerceContext())
            {
                var validatedCust = dbContext.CustomerInfos.Where(
                    cust => cust.EmailId.Equals(customer.EmailId)&&
                    cust.Password.Equals(customer.Password)&&
                    cust.Role.Equals(customer.Role)
                    ).FirstOrDefault();
                return validatedCust;
            }
        }
    }
}
