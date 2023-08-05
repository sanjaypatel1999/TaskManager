using System;
using System.Collections.Generic;

class Task
{
    public string Title { get; set; }=null!;
    public string Description { get; set; }=null!;
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Task Manager");
            Console.WriteLine("1. Add a Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Add_a_Task();
                        break;
                    case 2:
                        ViewTasks();
                        break;
                    case 3:
                        MarkTaskCompleted();
                        break;
                    case 4:
                        DeleteTask();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine();
        }
    }

    static void Add_a_Task()
    {
        Task task = new Task();
        Console.Write("Enter task title: ");
        task.Title = Console.ReadLine();
        Console.Write("Enter task description: ");
        task.Description = Console.ReadLine();
        Console.Write("Enter due date (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
        {
            task.DueDate = dueDate;
        }
        else
        {
            Console.WriteLine("Invalid date format.");
            return;
        }
        task.IsCompleted = true;
        tasks.Add(task);
        Console.WriteLine("Task added successfully.");
    }

    static void ViewTasks()
    {
        Console.WriteLine("Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Task task = tasks[i];
            Console.WriteLine($"{i + 1}. {task.Title} - Due: {task.DueDate.ToString("yyyy-MM-dd")} - Completed: {(task.IsCompleted ? "Yes" : "No")}");
        }
    }

    static void MarkTaskCompleted()
    {
        ViewTasks();
        Console.Write("Enter the task number to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
        {
            Task task = tasks[index - 1];
            task.IsCompleted = true;
            Console.WriteLine("Task marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    static void DeleteTask()
    {
        ViewTasks();
        Console.Write("Enter the task number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Task deleted.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}