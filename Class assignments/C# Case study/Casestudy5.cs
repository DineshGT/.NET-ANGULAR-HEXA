using System;
using System.Collections.Generic;

namespace C_CaseStudy
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class StudentManager
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(int id, string name)
        {
            students.Add(new Student { Id = id, Name = name });
            Console.WriteLine("Student added successfully.");
        }

        public void DisplayAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
            }
        }

        public void RemoveStudent(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student removed successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void SearchStudent(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine($"Found: ID={student.Id}, Name={student.Name}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void TotalStudents()
        {
            Console.WriteLine($"Total number of students: {students.Count}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            Console.WriteLine("---------Student Management System--------");

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("0. View All Students");
                Console.WriteLine("1. Add new Student");
                Console.WriteLine("2. Remove a Student");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Total strength");
                Console.WriteLine("5. Exit");

                Console.Write("Enter input: ");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 0:
                        manager.DisplayAllStudents();
                        break;

                    case 1:
                        Console.Write("Enter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        manager.AddStudent(id, name);
                        break;

                    case 2:
                        Console.Write("Enter ID to remove: ");
                        int removeId = Convert.ToInt32(Console.ReadLine());
                        manager.RemoveStudent(removeId);
                        break;

                    case 3:
                        Console.Write("Enter ID to search: ");
                        int searchId = Convert.ToInt32(Console.ReadLine());
                        manager.SearchStudent(searchId);
                        break;

                    case 4:
                        manager.TotalStudents();
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Enter valid input.");
                        break;
                }
            }
        }
    }
}
