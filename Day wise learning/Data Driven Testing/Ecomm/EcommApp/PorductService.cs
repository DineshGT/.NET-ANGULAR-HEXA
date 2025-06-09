using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommApp
{
    public class ProductService
    {
        private List<Product> _products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Pen", ListPrice = 25 },
            new Product { ProductId = 2, ProductName = "Notebook", ListPrice = 100 }
        };
        public ProductService()
        {
                 
        }

        public void AddProduct(Product product) 
        {
            _products.Add(product);
        }

        public bool RemoveProduct(int productId)
        {
            var product= _products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null) 
            {
                _products.Remove(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Product GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            return product;
        }

        public Product GetProductByName(string name)
        {
            var product=_products.FirstOrDefault(p=>p.ProductName == name);
            return product;
        }

        public List<Product> GetAllProducts() 
        { 
            return _products;
        }

        public Product[] GetProductsSortedByName()
        {
           var sortedByName= _products.OrderBy(p=>p.ProductName).ToArray();
            return sortedByName;
        }
    }
}
