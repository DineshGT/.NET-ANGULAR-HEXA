using DAL.DataAccess;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.Runtime.CompilerServices;

namespace UIApp
{
    class Program
    {
        static void Main()
        {
            IAdminInfoRepo<AdminInfo> adminInfoRepo = new AdminInfoRepo() ;
            AdminInfoBL adminInfoBL = new AdminInfoBL(adminInfoRepo);
          var isvalid=  adminInfoBL.ValidateAdmin(new AdminInfo { EmailId = "admin@gmail.com", Password = "admin123", Role = "Admin" });
            Console.WriteLine(isvalid?"LoggedIn":"Incorrect EmailId or Password");

            if (isvalid)
            {
                IProductRepo<Product> productRepo= new ProductRepo() ;
                ProductBL productBL = new ProductBL(productRepo);

                Console.Write("Enter 1.To Save 2.To Delete 3.To Update 4.Get Product By Id 5.Get All Products 6.Order With Customer:");
                var choice=Console.ReadLine();
                switch (choice)
                {
                    case "1":
                            Product product1=new Product() ;
                            product1.ProductId = 5;
                            product1.ProductName = "Shampoo";
                            product1.Category = "FMCG";
                            product1.ListPrice = 200;
                            var result1= productBL.AddProduct(product1);
                            Console.WriteLine(result1?"Product is Added":"Error");
                        break;
                    case "2":
                            int id = 1;
                            var result2= productBL.RemoveProduct(id);
                            Console.WriteLine(result2?"Product is Deleted":"Error");
                        break;
                    case "3":
                        Product product2 = new Product();
                        product2.ProductId = 2;
                        product2.ProductName = "tablet";
                        product2.Category = "Gadget";
                        product2.ListPrice = 10000;
                        var result3= productBL.UpdateProduct(product2);
                        Console.WriteLine(result3?"Product is Updated":"Error");
                        break;
                    case "4":
                        int id2 =2;
                        var product=productBL.GetProductById(id2);
                        Console.WriteLine($"{product.ProductId}\t{product.ProductName}\t{product.Category}\t{product.ListPrice}");
                        break;
                    case "5":
                        var products= productBL.GetAllProducts();
                        foreach (var prod in products)
                        {
                            Console.WriteLine($"{prod.ProductId}\t{prod.ProductName}\t{prod.Category}\t{prod.ListPrice}");
                        }
                        break;
                    case "6":
                        IOrderRepo<Order> repo = new OrderRepo();
                        OrderBL orderBL = new OrderBL(repo);
                        var details= orderBL.GetOrderWithCust();
                        foreach (var detail in details)
                        {
                            Console.WriteLine($"{detail.OrderId}\t{detail.OrderDate}\t{detail.CustEmail}\t{detail.Password}");
                        }
                        break;
                    default:
                        Console.WriteLine("invalid Choice");
                        break;
                }
            }
        }
    }
}