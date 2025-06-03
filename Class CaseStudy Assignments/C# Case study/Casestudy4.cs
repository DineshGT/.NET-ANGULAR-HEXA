using System;

class Program
{
    static void Main()
    {
        string[] products = { "Laptop", "Smartphone", "Tablet", "Monitor", "Keyboard" };
        Console.Write("Enter product to search: ");
        string search = Console.ReadLine();
        bool found = false;
        foreach (string product in products)
        {
            if (product.Equals(search, StringComparison.OrdinalIgnoreCase))
            {
                found = true;
                break;
            }
        }
        Console.WriteLine(found ? "Product is Available." : "Product is Not Available.");

        Console.WriteLine();

        string[] students = { "Alice", "Bob", "Charlie" };
        int[,] marks = {
            {85, 90, 78},
            {75, 80, 88},
            {92, 81, 76}
        };

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Student: {students[i]}");
            int total = 0;
            Console.Write("Marks: ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{marks[i, j]} ");
                total += marks[i, j];
            }
            double avg = total / 3.0;
            Console.WriteLine($"\nTotal: {total}");
            Console.WriteLine($"Average: {avg:F2}\n");
        }

        Console.WriteLine();

        string[] subjects = { "Math", "Science", "English" };
        int[][] scores = new int[3][];
        scores[0] = new int[] { 80, 85, 90 };
        scores[1] = new int[] { 75, 78 };
        scores[2] = new int[] { 88, 84, 79, 91 };

        for (int i = 0; i < scores.Length; i++)
        {
            Console.WriteLine($"Subject: {subjects[i]}");
            int total = 0;
            Console.Write("Scores: ");
            foreach (int score in scores[i])
            {
                Console.Write($"{score} ");
                total += score;
            }
            double avg = (double)total / scores[i].Length;
            Console.WriteLine($"\nAverage: {avg:F2}\n");
        }
    }
}
