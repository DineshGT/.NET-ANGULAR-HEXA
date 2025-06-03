using System;

namespace CaseStudy1_CSharpBasics
{
    class Employee { }
    class Manager : Employee { }
    class Developer : Employee { }
    class Intern : Employee { }

    class Customer { }
    class PremiumCustomer : Customer
    {
        public double DiscountRate => 0.15;
    }

    class Laptop
    {
        public const double TaxRate = 0.18;
        public readonly int ManufacturingYear;

        public Laptop(int year)
        {
            ManufacturingYear = year;
        }
    }

    class Program
    {
        static void Main()
        {
            Employee emp1 = new Manager();
            Employee emp2 = new Developer();
            Employee emp3 = new Intern();

            PrintRole(emp1);
            PrintRole(emp2);
            PrintRole(emp3);

            Customer cust = new PremiumCustomer();
            PremiumCustomer premium = cust as PremiumCustomer;

            if (premium != null)
                Console.WriteLine($"Discount applicable: {premium.DiscountRate * 100}%");
            else
                Console.WriteLine("No discount for regular customers.");

            int amount = 1500;
            double preciseAmount = (double)amount;
            int roundedAmount = (int)Math.Round(preciseAmount);
            Console.WriteLine($"Rounded Amount: {roundedAmount}");

            object price1 = 500;
            object price2 = 1200;
            int total = (int)price1 + (int)price2;
            Console.WriteLine($"Total Price: {total}");

            Laptop laptop = new Laptop(2024);
            Console.WriteLine($"Tax Rate: {Laptop.TaxRate * 100}%");
            Console.WriteLine($"Manufacturing Year: {laptop.ManufacturingYear}");
        }

        static void PrintRole(Employee emp)
        {
            if (emp is Manager)
                Console.WriteLine("Employee Role: Manager");
            else if (emp is Developer)
                Console.WriteLine("Employee Role: Developer");
            else if (emp is Intern)
                Console.WriteLine("Employee Role: Intern");
            else
                Console.WriteLine("Employee Role: Unknown");
        }
    }
}
