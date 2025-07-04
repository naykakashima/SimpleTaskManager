using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Helpers;
using TaskManager.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {
        List<UserTask> taskList = new List<UserTask>();

        IntInputValidator intInputValidator = new IntInputValidator();

        public int option;

        public void CreateTask()
        {
            var newTask = new UserTask();

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
                    newTask.TaskPriority = "High Priority";
                    break;
                case 2:
                    newTask.TaskPriority = "Medium Priority";
                    break;
                case 3:
                    newTask.TaskPriority = "Low Priority";
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
                var IncompleteTaskName = Console.ReadLine();
                if ( !(string.IsNullOrEmpty(IncompleteTaskName)) && (taskList.Any(t => t.TaskName == IncompleteTaskName)))
                {
                    var index = taskList.FindIndex(t => t.TaskName == IncompleteTaskName);
                    taskList[index].IsTaskComplete = true;
                    Console.WriteLine("Task Succesfully Complete!");
                    break;
                }

                Console.WriteLine("Task name is invalid! Please try again!");

            }
        }

        public void UpdatePriority()
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
                var UpdatePriorityTaskName = Console.ReadLine();
                if (!(string.IsNullOrEmpty(UpdatePriorityTaskName)) && (taskList.Any(t => t.TaskName == UpdatePriorityTaskName)))
                {
                    var index = taskList.FindIndex(t => t.TaskName == UpdatePriorityTaskName);

                    Console.WriteLine("What is the updated priority level of your task?");
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
                            taskList[index].TaskPriority = "High Priority";
                            break;
                        case 2:
                            taskList[index].TaskPriority = "Medium Priority";
                            break;
                        case 3:
                            taskList[index].TaskPriority = "Low Priority";
                            break;
                    }

                    Console.WriteLine("Task Priority Succesfully Updated!");
                    break;
                }

                Console.WriteLine("Task name is invalid! Please try again!");

            }

        }

        public void FilterByCompletion()
        {
            int option;
            Console.WriteLine("Would you like to view: ");
            Console.WriteLine("1. Completed Tasks");
            Console.WriteLine("2. Incompleted Tasks");
            option = intInputValidator.InputValidator();

            while (option < 1 || option > 2)
            {
                Console.WriteLine("Invalid number, please try again!");
            }

            switch (option)
            {
                case 1:
                    DisplayAllCompleteTasks();
                    break;
                case 2:
                    DisplayIncompleteTasks();
                    break;
            }
        }

        public void FilterByPriority()
        {
            int option;
            Console.WriteLine("Would you like to view: ");
            Console.WriteLine("1. High Priority Tasks");
            Console.WriteLine("2. Medium Priority Tasks");
            Console.WriteLine("3. Low Tasks");
            option = intInputValidator.InputValidator();

            while (option < 1 || option > 3)
            {
                Console.WriteLine("Invalid number, please try again!");
            }

            switch (option)
            {
                case 1:
                    DisplayHighPriorityTasks();
                    break;
                case 2:
                    DisplayMediumPriorityTasks();
                    break;
                case 3:
                    DisplayLowPriorityTasks();
                    break;
            }
        }

        public List<UserTask> GetAllTasks()
        {
            List<UserTask> AllTasks = taskList.ToList();
            return AllTasks;
        }

        public List<UserTask> GetAllIncompleteTasks()
        {
            List<UserTask> AllIncompleteTasks = (List<UserTask>)taskList.Where(UserTask => (UserTask.IsTaskComplete == false)).ToList();
            return AllIncompleteTasks;
        }

        public List<UserTask> GetAllCompleteTasks()
        {
            List<UserTask> AllCompleteTasks = (List<UserTask>)taskList.Where(UserTask => (UserTask.IsTaskComplete == true)).ToList();
            return AllCompleteTasks;
        }

        public void DisplayAllCompleteTasks()
        {
            var completeTasks = GetAllCompleteTasks();
            if (completeTasks == null)
            {
                Console.WriteLine("There are no completed tasks!");
            } else
            {
                Console.WriteLine("+-----------------------------------------+");
                foreach (var completeTask in completeTasks)
                {
                    Console.WriteLine("Task Name: " + completeTask.TaskName);
                    Console.WriteLine("Task Priority: " + completeTask.TaskPriority);
                    Console.WriteLine("Task Status: Completed");

                }
                Console.WriteLine("+-----------------------------------------+");
            }
        }

        public void DisplayIncompleteTasks()
        {
            var incompleteTasks = GetAllIncompleteTasks();
            if (incompleteTasks == null)
            {
                Console.WriteLine("There are no incomplete tasks!");
            }
            else 
            {
                Console.WriteLine("+-----------------------------------------+");
                foreach (var incompleteTask in incompleteTasks)
                {
                    Console.WriteLine("Task Name: " + incompleteTask.TaskName);
                    Console.WriteLine("Task Priority: " + incompleteTask.TaskPriority);
                    Console.WriteLine("Task Status: Incomplete");
                }
                Console.WriteLine("+-----------------------------------------+");
            }
        }

        public void DisplayHighPriorityTasks()
        {
            List<UserTask> AllHighPriorityTasks = (List<UserTask>)taskList.Where(UserTask => (UserTask.TaskPriority == "High Priority")).ToList();

            if (AllHighPriorityTasks.Count == 0)
            {
                Console.WriteLine("There are no high priority tasks!");
            }
            else
            {
                Console.WriteLine("+-----------------------------------------+");
                foreach (var highPriorityTask in AllHighPriorityTasks)
                {
                    Console.WriteLine("Task Name: " + highPriorityTask.TaskName);
                    Console.WriteLine("Task Priority: " + highPriorityTask.TaskPriority);
                    Console.WriteLine("Task Completion Status: " + highPriorityTask.IsTaskComplete);
                }
                Console.WriteLine("+-----------------------------------------+");
            }
        }

        public void DisplayMediumPriorityTasks()
        {
            List<UserTask> AllMediumPriorityTasks = (List<UserTask>)taskList.Where(UserTask => (UserTask.TaskPriority == "Medium Priority")).ToList();

            if (AllMediumPriorityTasks.Count == 0)
            {
                Console.WriteLine("There are no medium priority tasks!");
            }
            else
            {
                Console.WriteLine("+-----------------------------------------+");
                foreach (var mediumPriorityTask in AllMediumPriorityTasks)
                {
                    Console.WriteLine("Task Name: " + mediumPriorityTask.TaskName);
                    Console.WriteLine("Task Priority: " + mediumPriorityTask.TaskPriority);
                    Console.WriteLine("Task Completion Status: " + mediumPriorityTask.IsTaskComplete);
                }
                Console.WriteLine("+-----------------------------------------+");
            }
        }

        public void DisplayLowPriorityTasks()
        {
            List<UserTask> AllLowPriorityTasks = (List<UserTask>)taskList.Where(UserTask => (UserTask.TaskPriority == "Low Priority")).ToList();
            if (AllLowPriorityTasks.Count == 0)
            {
                Console.WriteLine("There are no low priority tasks!");
            } else
            {
                Console.WriteLine("+-----------------------------------------+");
                foreach (var lowPriorityTask in AllLowPriorityTasks)
                {
                    Console.WriteLine("Task Name: " + lowPriorityTask.TaskName);
                    Console.WriteLine("Task Priority: " + lowPriorityTask.TaskPriority);
                    Console.WriteLine("Task Completion Status: " + lowPriorityTask.IsTaskComplete);
                }
                Console.WriteLine("+-----------------------------------------+");
            }
        }
    }
}
