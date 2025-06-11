using DAL.DataAccess;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            ProductRepo repo=new ProductRepo();
           var newProduct= repo.AddProduct(new Product { ProductId = 1, ProductName = "Laptop", Category = "Gadget", ListPrice = 30000 });
            Console.WriteLine(newProduct!=null?"Product is Added":"Error");
        }
    }
}
