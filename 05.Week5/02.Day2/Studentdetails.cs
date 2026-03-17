using System;

namespace ConsoleApp3
{
    internal class Program
    {
        public record StudentDetails(int RollNo, string Name, string Course, int marks);

        static void Main(string[] args)
        {
            int max = 10;
            StudentDetails[] Students = new StudentDetails[max];
            int count = 0;

            while (true)
            {
                Console.WriteLine("\n----Student Record System----");
                Console.WriteLine("1. Add records");
                Console.WriteLine("2. Display records");
                Console.WriteLine("3. Search for record");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input!");
                   
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter number of students: ");
                        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
                        {
                            Console.WriteLine("Invalid number!");
                            break;
                        }

                        if (count + n > max)
                        {
                            Console.WriteLine("Not enough space in array!");
                            break;
                        }

                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"\nEnter details for student {i + 1}:");

                            int roll;
                            while (true)
                            {
                                Console.Write("Enter Roll Number: ");
                                if (int.TryParse(Console.ReadLine(), out roll) && roll > 0)
                                    break;
                                Console.WriteLine("Invalid Roll Number! Try again.");
                            }

                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Course: ");
                            string course = Console.ReadLine();

                            int marks;
                            while (true)
                            {
                                Console.Write("Enter Marks (0-100): ");
                                if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                                    break;
                                Console.WriteLine("Invalid Marks! Try again.");
                            }

                            Students[count] = new StudentDetails(roll, name, course, marks);
                            count++;
                        }
                        break;

                    case 2:
                        if (count == 0)
                        {
                            Console.WriteLine("No records to display!");
                            break;
                        }

                        Console.WriteLine("\nRollNo\tName\t\tCourse\tMarks");
                        Console.WriteLine("----------------------------------------");
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"{Students[i].RollNo}\t{Students[i].Name,-10}\t{Students[i].Course,-10}\t{Students[i].marks}");
                        }
                        break;

                    case 3:
                        if (count == 0)
                        {
                            Console.WriteLine("No records to search!");
                            break;
                        }

                        Console.Write("Enter Roll Number to search: ");
                        if (!int.TryParse(Console.ReadLine(), out int searchRoll))
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }

                        bool found = false;
                        for (int i = 0; i < count; i++)
                        {
                            if (Students[i].RollNo == searchRoll)
                            {
                                Console.WriteLine("\nRecord Found:");
                                Console.WriteLine($"Roll Number: {Students[i].RollNo}");
                                Console.WriteLine($"Name: {Students[i].Name}");
                                Console.WriteLine($"Course: {Students[i].Course}");
                                Console.WriteLine($"Marks: {Students[i].marks}");
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Record not found!");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}