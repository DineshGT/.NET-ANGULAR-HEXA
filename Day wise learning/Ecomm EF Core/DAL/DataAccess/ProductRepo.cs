using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.DataAccess
{
    public class ProductRepo : IProductRepo<Product>
    {
        public Product AddProduct(Product product)
        {
            using (ECommerceContext dbContext = new ECommerceContext())
            {
                dbContext.Products.Add(product); //This method will change entity state from Unchanged to ADDED
                dbContext.SaveChanges();//This method will observes current state of an entity and generates t-sql statement (insert into Product values(...)) 
                return product;
            }
        }

        public List<Product> GetAllProducts()
        {
            using (ECommerceContext dbContext = new ECommerceContext())
            {
                return dbContext.Products.ToList();
            }
        }

        public Product GetProductById(int id)
        {
            using (ECommerceContext dbContext = new ECommerceContext())
            {
                var existingProduct = dbContext.Products.Where(product => product.ProductId.Equals(id)).FirstOrDefault();

                return existingProduct;

            }
        }

        public Product RemoveProduct(int id)
        {
            using (ECommerceContext dbContext = new ECommerceContext())
            {
                var existingProduct = dbContext.Products.Where(product => product.ProductId.Equals(id)).FirstOrDefault();
                if (existingProduct != null)
                {
                    dbContext.Products.Remove(existingProduct);//This method will change entity state from Unchanged to REMOVED
                    dbContext.SaveChanges();//This method will observe current entity state and generate t-sql statement (delete from product where productid=id)
                }
                return existingProduct;

            }
        }

        public Product UpdateProduct(Product product)
        {
            using (ECommerceContext dbContext = new ECommerceContext())
            {
                var existingProduct = dbContext.Products.Where(prod => prod.ProductId.Equals(product.ProductId)).FirstOrDefault();

                if (existingProduct != null)
                {
                    //This will change an entity state from Unchanged to Modified

                    existingProduct.ProductName = product.ProductName;
                    existingProduct.Category = product.Category;
                    existingProduct.ListPrice = product.ListPrice;

                    dbContext.SaveChanges();//This method will observe current entity state and generates t-sql statement (update product set....)

                }
                return product;
            }
        }
    }
}
