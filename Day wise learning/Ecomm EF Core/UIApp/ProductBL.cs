using DAL.DataAccess;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIApp
{
    public class ProductBL
    {
        private readonly IProductRepo<Product> _productRepo;
        public ProductBL(IProductRepo<Product> productRepo)
        {
            this._productRepo = productRepo;
        }

        public bool AddProduct(Product product)
        {
            var newProduct = _productRepo.AddProduct(product);
            if (newProduct != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveProduct(int id)
        {
            var delProduct = _productRepo.RemoveProduct(id);
            if (delProduct != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            var updatedProduct = _productRepo.UpdateProduct(product);
            if (updatedProduct != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Product GetProductById(int id) 
        {
            var product= _productRepo.GetProductById(id);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }
    }
}
