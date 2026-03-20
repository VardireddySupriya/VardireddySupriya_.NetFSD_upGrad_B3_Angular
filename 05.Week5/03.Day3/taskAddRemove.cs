using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void addTask(List<string> obj)
    {
        Console.WriteLine("enter task");
        String input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            obj.Add(input);
            Console.WriteLine("completed task");
        }
        else
        {
            Console.WriteLine("task cannot be empty");
        }
    }
    static void removeTask(List<string> obj)
    {
        if (obj.Count == 0)
        {
            Console.WriteLine("No tasks to remove.");
            return;
        }

        Console.Write("Enter task number to remove: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int index))
        {
            if (index >= 1 && index <= obj.Count)
            {
                string removed = obj[index - 1];
                obj.RemoveAt(index - 1);
                Console.WriteLine($"Removed: {removed}");
            }
            else
            {
                Console.WriteLine("Invalid task number:" +input);
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }

    static void viewTasks(List<string> obj)
    {
        if (obj.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine("Tasks:");
        for (int i = 0; i < obj.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {obj[i]}");
        }
    }
    static void Main(string[] args)
    {
        List<string> list = new List<string>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nTo-Do List Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    addTask(list);
                    break;

                case "2":
                    viewTasks(list);
                    break;

                case "3":
                    removeTask(list);
                    break;

                case "4":
                    running = false;
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }



    }
}