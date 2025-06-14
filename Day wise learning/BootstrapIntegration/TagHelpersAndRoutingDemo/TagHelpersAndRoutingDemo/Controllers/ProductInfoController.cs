using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TagHelpersAndRoutingDemo.Models;

namespace TagHelpersAndRoutingDemo.Controllers
{
    [Route("Product")]
    //[Route("[controller]")]
    public class ProductInfoController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product{ProductId=100,ProductName="Monitor",ProductCategory="Electronics",ListPrice=5000},
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
            LoadCategories();//categories are loaded into ViewBag
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

        [Route("GetById/{{id:int}}", Name = "GetById")]
        public IActionResult GetProductById(int id)
        {
            var existingProduct=products.Where(pro=>pro.ProductId.Equals(id)).FirstOrDefault();
            return View(existingProduct);
        }

        [Route("GetByName/{{name:range(5,50)}}",Name = "GetByName")]
        public IActionResult GetProductByName(string name)
        {
            var existingProduct=products.Where(pro=>pro.ProductName.Equals(name)).FirstOrDefault();
            return View("GetProductById",existingProduct);
        }

        [Route("Delete",Name ="Delete")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = products.Where(pro => pro.ProductId.Equals(id)).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        [Route("RemoveProduct",Name = "RemoveProduct")]
        public IActionResult DeleteProduct(Product product)
        {
            var existingProduct = products.Where(pro => pro.ProductId.Equals(product.ProductId)).FirstOrDefault();
            products.Remove(existingProduct);
            return RedirectToRoute("List");
        }

        [Route("Edit/{id}",Name ="Edit")]
        public IActionResult EditProduct(int id)
        {
            LoadCategories();
            var existingProduct = products.Where(pro => pro.ProductId.Equals(id)).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        [Route("EditProduct",Name = "EditProduct")]
        public IActionResult EditProduct(Product product)
        {
            var existingProduct = products.Where(pro => pro.ProductId.Equals(product.ProductId)).FirstOrDefault();
            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductCategory = product.ProductCategory;
            existingProduct.ListPrice= product.ListPrice;
            return RedirectToRoute("List");
        }

        [NonAction]
        public void LoadCategories()
        {
            var categories =new List<SelectListItem>{
                new SelectListItem{Text="FMCG",Value="FMCG"},
                new SelectListItem{Text="Gadget",Value="Gadget"},
                new SelectListItem{Text="Electronics",Value="Electronics"}
            };

            ViewBag.Categories = categories;
        }
    }
}
