using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManager.Services
{
    public class TaskService
    {
        List<Task> taskList = new List<Task>();

        IntInputValidator intInputValidator = new IntInputValidator();

        public string name { get; set; }
        public int option;

        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Task Manager!");
            Console.WriteLine("Enter your name to create an account: ");

            name = Console.ReadLine();

            Console.WriteLine($"Hello, {name} What would you like to do?");
        }

        public void CreateTask()
        {
            var newTask = new Task();

            while (true)
            {
                Console.WriteLine("Enter the name of your task: ");
                var taskName = Console.ReadLine();
                if ( !(string.IsNullOrEmpty(taskName)) && !(taskList.Any(t => t.TaskName == taskName)))
                {
                    newTask.TaskName = taskName;
                    break;
                }

                Console.WriteLine("Task name is invalid! Please try again!");

            }
            

            Console.WriteLine("What is the priority level of your task?");
            Console.WriteLine("Is it: ");
            Console.WriteLine("1. High-Priority");
            Console.WriteLine("2. Medium-Priority");
            Console.WriteLine("3. Low-Priority ");

            Console.WriteLine("Please enter the number corresponding to your option");
            option = intInputValidator.InputValidator();

            while (option < 1 || option > 3)
            {
                Console.WriteLine("Invalid number, please try again!");
            }

            switch (option)
            {
                case 1:
                    newTask.TaskPriority = "High-Priority";
                    break;
                case 2:
                    newTask.TaskPriority = "Medium-Priority";
                    break;
                case 3:
                    newTask.TaskPriority = "Low-Priority";
                    break;
            }

            taskList.Add(newTask);

            Console.WriteLine("Task Succesfully Added");
        }

        public void ShowTask()
        {
            Console.WriteLine("Displaying all tasks: ");
            Console.WriteLine("+-----------------------------------------+");
            var tasks = GetAllTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine("Task Name: " + task.TaskName);
                Console.WriteLine("Task Priority: " + task.TaskPriority);
                if (task.IsTaskComplete)
                {
                    Console.WriteLine("Task Status: Complete");
                }
                else
                {
                    Console.WriteLine("Task Status: Incomplete");
                }
            }
            Console.WriteLine("+-----------------------------------------+");

        }

        public void TaskCompletion()
        {
            Console.WriteLine("Displaying all incomlete tasks: ");

            var incompleteTasks = GetAllIncompleteTasks();
            Console.WriteLine("+-----------------------------------------+");
            foreach (var incompleteTask in incompleteTasks)
            {
                Console.WriteLine("Task Name: " + incompleteTask.TaskName);
                Console.WriteLine("Task Priority: " + incompleteTask.TaskPriority);
            }
            Console.WriteLine("+-----------------------------------------+");

            while (true)
            {
                Console.WriteLine("Enter the name of your task: ");
                var taskName = Console.ReadLine();
                if ( !(string.IsNullOrEmpty(taskName)) && (taskList.Any(t => t.TaskName == taskName)))
                {
                    var index = taskList.FindIndex(t => t.TaskName == taskName);
                    taskList[index].IsTaskComplete = true;
                    break;
                }

                Console.WriteLine("Task name is invalid! Please try again!");

            }
        }

        public List<Task> GetAllTasks()
        {
            var tasks = taskList.ToList();
            return tasks.ToList();
        }

        public List<Task> GetAllIncompleteTasks()
        {
            var incompleteTasks = taskList.Where(t => t.IsTaskComplete = false);
            return incompleteTasks.ToList();
        }


    }
}
