using System;

namespace CaseStudy2_DecisionMaking
{
    class Program
    {
        static void Main()
        {
            int creditScore = 750;
            int income = 32000;

            if (creditScore >= 700 && income >= 30000)
                Console.WriteLine("Loan Approved");
            else
                Console.WriteLine("Loan Rejected");

            Console.WriteLine();

            int choice = 1;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Redirecting to Billing Department...");
                    break;
                case 2:
                    Console.WriteLine("Redirecting to Technical Support...");
                    break;
                case 3:
                    Console.WriteLine("Redirecting to Sales...");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            Console.WriteLine();

            string correctPassword = "CSharp@123";
            int attempts = 3;
            while (attempts > 0)
            {
                Console.Write("Enter Password: ");
                string userInput = Console.ReadLine();
                if (userInput == correctPassword)
                {
                    Console.WriteLine("Access Granted");
                    break;
                }
                attempts--;
                if (attempts > 0)
                    Console.WriteLine($"Incorrect Password! {attempts} attempts left.");
                else
                    Console.WriteLine("Account Locked!");
            }

            Console.WriteLine();

            double totalBill = 6000;
            double finalAmount = totalBill >= 5000 ? totalBill * 0.8 : totalBill;
            Console.WriteLine($"Final Bill Amount: ₹{finalAmount}");
        }
    }
}
