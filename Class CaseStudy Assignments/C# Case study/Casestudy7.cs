using System;

class Program
{
    // Function to calculate factorial
    static long Factorial(int number)
    {
        long result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }

    // Function to calculate Simple Interest and return it
    static double CalculateSimpleInterest(double principal, double rate, double time)
    {
        return (principal * rate * time) / 100;
    }

    // Function using out parameters to return interest and total amount
    static void CalculateInterestWithOut(double principal, double rate, double time, out double interest, out double totalAmount)
    {
        interest = (principal * rate * time) / 100;
        totalAmount = principal + interest;
    }

    // Function with optional parameter for rate
    static double CalculateSimpleInterestOptional(double principal, double time, double rate = 10)
    {
        return (principal * rate * time) / 100;
    }

    static void Main()
    {
        try
        {
            // Factorial calculation
            Console.Write("Enter a number for factorial: ");
            int num = int.Parse(Console.ReadLine());
            long fact = Factorial(num);
            Console.WriteLine($"Factorial of {num} is {fact}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in factorial calculation: " + ex.Message);
        }

        try
        {
            // Simple Interest using function with return
            Console.Write("\nEnter Principal: ");
            double principal = double.Parse(Console.ReadLine());
            Console.Write("Enter Rate: ");
            double rate = double.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            double time = double.Parse(Console.ReadLine());

            double interest = CalculateSimpleInterest(principal, rate, time);
            Console.WriteLine($"Simple Interest is: {interest}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in simple interest calculation: " + ex.Message);
        }

        try
        {
            // Simple Interest using out parameters
            Console.Write("\nEnter Principal: ");
            double principalOut = double.Parse(Console.ReadLine());
            Console.Write("Enter Rate: ");
            double rateOut = double.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            double timeOut = double.Parse(Console.ReadLine());

            CalculateInterestWithOut(principalOut, rateOut, timeOut, out double interestOut, out double totalOut);
            Console.WriteLine($"Interest: {interestOut}, Total Amount: {totalOut}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in out parameter calculation: " + ex.Message);
        }

        try
        {
            // Simple Interest using optional parameter

            Console.Write("\nEnter Principal: ");
            double principalOpt = double.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            double timeOpt = double.Parse(Console.ReadLine());

            double interestOpt = CalculateSimpleInterestOptional(principalOpt, timeOpt);
            Console.WriteLine($"Interest (with default rate 10%): {interestOpt}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in optional parameter calculation: " + ex.Message);
        }
    }
}
