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
        TaskDisplayer displayer = new TaskDisplayer();
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
                    newTask.Priority = TaskPriority.HighPriority;
                    break;
                case 2:
                    newTask.Priority = TaskPriority.MediumPriority;
                    break;
                case 3:
                    newTask.Priority = TaskPriority.LowPriority;
                    break;
            }

            taskList.Add(newTask);

            Console.WriteLine("Task Succesfully Added");
        }

        public void ShowTask()
        {
            var tasks = GetAllTasks();
            displayer.DisplayTasks(tasks);
        }

        public void TaskCompletion()
        {
            Console.WriteLine("Displaying all incomlete tasks: ");

            var incompleteTasks = GetAllIncompleteTasks();
            displayer.DisplayIncompleteTasks(incompleteTasks);

            while (true)
            {
                Console.WriteLine("Enter the name of your task: ");
                var IncompleteTaskName = Console.ReadLine();
                if ( !(string.IsNullOrEmpty(IncompleteTaskName)) && (taskList.Any(t => t.TaskName == IncompleteTaskName)))
                {
                    var index = taskList.FindIndex(t => t.TaskName == IncompleteTaskName);
                    taskList[index].Status = TaskStatus.Complete;
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
            displayer.DisplayIncompleteTasks(incompleteTasks);

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
                            taskList[index].Priority = TaskPriority.HighPriority;
                            break;
                        case 2:
                            taskList[index].Priority = TaskPriority.MediumPriority;
                            break;
                        case 3:
                            taskList[index].Priority = TaskPriority.LowPriority;
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
                    displayer.DisplayHighPriorityTasks(SortByTaskPriority(TaskPriority.HighPriority));
                    break;
                case 2:
                    displayer.DisplayMediumPriorityTasks(SortByTaskPriority(TaskPriority.MediumPriority));
                    break;
                case 3:
                    displayer.DisplayLowPriorityTasks(SortByTaskPriority(TaskPriority.LowPriority));
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
            List<UserTask> AllIncompleteTasks = (List<UserTask>)taskList.Where(UserTask => (UserTask.Status == TaskStatus.Incomplete)).ToList();
            return AllIncompleteTasks;
        }

        public List<UserTask> GetAllCompleteTasks()
        {
            List<UserTask> AllCompleteTasks = (List<UserTask>)taskList.Where(UserTask => (UserTask.Status == TaskStatus.Complete)).ToList();
            return AllCompleteTasks;
        }
        public void DisplayAllCompleteTasks()
        {
            var completeTasks = GetAllCompleteTasks();
            displayer.DisplayCompleteTasks(completeTasks);
        }

        public void DisplayIncompleteTasks()
        {
            var incompleteTasks = GetAllIncompleteTasks();
            displayer.DisplayIncompleteTasks(incompleteTasks);
        }

        public List<UserTask> SortByTaskPriority(TaskPriority priority)
        {
            var TaskList = GetAllTasks();
            var filterPriorityTask = new List<UserTask>();

            if (priority == TaskPriority.HighPriority) {
                filterPriorityTask = TaskList.Where(UserTask => (UserTask.Priority == TaskPriority.HighPriority)).ToList();
            }


            if (priority == TaskPriority.MediumPriority)
            {
                filterPriorityTask = TaskList.Where(UserTask => (UserTask.Priority == TaskPriority.MediumPriority)).ToList();
            }


            if (priority == TaskPriority.LowPriority)
            {
                filterPriorityTask = TaskList.Where(UserTask => (UserTask.Priority == TaskPriority.LowPriority)).ToList();
            }

            return filterPriorityTask;
        }
    }
}
