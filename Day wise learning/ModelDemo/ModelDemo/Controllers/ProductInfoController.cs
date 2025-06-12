using Microsoft.AspNetCore.Mvc;
using ModelDemo.Models;

namespace ModelDemo.Controllers
{
    public class ProductInfoController : Controller
    {
        private readonly List<Product> products=new List<Product>
        {
            new Product{ProductId=100,ProductName="Laptop",ProductCategory="Gadgets",ListPrice=30000},
            new Product{ProductId=101,ProductName="HDD",ProductCategory="Gadgets",ListPrice=3000},
            new Product{ProductId=102,ProductName="Tablet",ProductCategory = "Gadgets", ListPrice=10000}
        };
        public IActionResult ProductList()
        {
            return View(products);
        }

        public IActionResult ProductById(int id)
        {
            var productById = products.Where(pro=>pro.ProductId.Equals(id)).FirstOrDefault();
            return View(productById);
        }
    }
}
