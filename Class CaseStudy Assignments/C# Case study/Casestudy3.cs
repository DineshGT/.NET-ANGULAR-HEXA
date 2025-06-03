using System;

namespace CaseStudy3_Looping
{
    class Program
    {
        static void Main()
        {
            double salary = 50000;
            double incrementRate = 5;

            Console.WriteLine("Salary Increment for the next 5 years:");
            for (int year = 1; year <= 5; year++)
            {
                salary += salary * (incrementRate / 100);
                Console.WriteLine($"Year {year}: ₹{salary:F2}");
            }

            Console.WriteLine();

            double stockPrice = 150.0;
            double targetPrice = 200.0;
            int day = 1;

            while (stockPrice <= targetPrice)
            {
                Console.WriteLine($"Day {day}: Stock Price = ₹{stockPrice}");
                stockPrice += 5;
                day++;
            }

            Console.WriteLine($"Stock price exceeded ₹200 on Day {day - 1}");

            Console.WriteLine();

            string[] products = { "Laptop", "Smartphone", "Headphones", "Tablet", "Smartwatch" };
            string[] outOfStock = { "Smartphone", "Tablet" };

            Console.WriteLine("Checking product availability:");
            foreach (string product in products)
            {
                bool isOut = false;
                foreach (string oos in outOfStock)
                {
                    if (product == oos)
                    {
                        isOut = true;
                        break;
                    }
                }
                Console.WriteLine($"{product}: {(isOut ? "Out of Stock" : "In Stock")}");
            }
        }
    }
}
