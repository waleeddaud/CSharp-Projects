using System;
using System.IO;

class Program
{
    static string filePath = "students.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nStudent Record System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine() ?? "3");

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    ViewStudents();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter Department: ");
        string dept = Console.ReadLine() ?? "";

        Student s = new Student(id, name, age, dept);

        FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);

        sw.WriteLine(s.ToString());
        Console.WriteLine("Student record saved successfully!");

        sw.Close();
        fs.Close();
    }

    static void ViewStudents()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No records found.");
            return;
        }

        Console.WriteLine("\n--- Student Records ---");

        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);

        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] words = line.Split(',');
            Console.WriteLine($"ID: {words[0]} | Name: {words[1]} | Age: {words[2]} | Department: {words[3]}");
        }
        sr.Close();
        fs.Close();
    }
}
