using Microsoft.AspNetCore.Mvc;
using TagHelpersAndRoutingDemo.Models;

namespace TagHelpersAndRoutingDemo.Controllers
{
    [Route("Product")]
    public class ProductInfoController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product{ProductId=100,ProductName="Monitor",ProductCategory="Electronic",ListPrice=5000},
            new Product{ProductId=101,ProductName="Laptop",ProductCategory="Gadget",ListPrice=30000},
            new Product{ProductId=102,ProductName="MobilePhone",ProductCategory="Gadget",ListPrice=10000}
        };

        [Route("/")] //start-up route
        [Route("List",Name = "List")] //localhost:{port}/product/List
        public IActionResult ProductList()
        {
            return View(products);
        }

        [Route("AddProduct",Name = "AddProduct")]
        public IActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveProduct",Name = "SaveProduct")]
        public IActionResult AddNewProduct(Product product)
        {
            products.Add(product);
            //return RedirectToAction("ProductList");
            return RedirectToRoute("List");
        }
    }
}
