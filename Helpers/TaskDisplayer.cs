using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services;
using TaskStatus = TaskManager.Services.TaskStatus;

namespace TaskManager.Helpers
{
    public class TaskDisplayer
    {
        public void DisplayTasks(List<UserTask> tasks)
        {
            if (tasks == null || tasks.Count == 0)
            {
                Console.WriteLine("There are no tasks yet!");
                return;
            }
            Console.WriteLine("Displaying all tasks: ");
            Console.WriteLine("+-----------------------------------------+");

            foreach (var task in tasks)
            {
                Console.WriteLine("Task Name: " + task.TaskName);
                Console.WriteLine("Task Priority: " + task.Priority);
                if (task.Status == TaskStatus.Complete)
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

        public void DisplayCompleteTasks(List<UserTask> completeTasks)
        {
            if (completeTasks == null)
            {
                Console.WriteLine("There are no completed tasks!");
            }
            else
            {
                Console.WriteLine("+-----------------------------------------+");
                foreach (var completeTask in completeTasks)
                {
                    Console.WriteLine("Task Name: " + completeTask.TaskName);
                    Console.WriteLine("Task Priority: " + completeTask.Priority);
                    Console.WriteLine("Task Status: Completed");

                }
                Console.WriteLine("+-----------------------------------------+");
            }
        }

        public void DisplayIncompleteTasks(List<UserTask> incompleteTasks)
        {
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
                    Console.WriteLine("Task Priority: " + incompleteTask.Priority);
                    Console.WriteLine("Task Status: Incomplete");
                }
                Console.WriteLine("+-----------------------------------------+");
            }
        }

        public void DisplayHighPriorityTasks(List<UserTask> HighPriorityTasks)
        {
            

            if (HighPriorityTasks.Count == 0)
            {
                Console.WriteLine("There are no high priority tasks!");
            }
            else
            {
                Console.WriteLine("+-----------------------------------------+");
                foreach (var highPriorityTask in HighPriorityTasks)
                {
                    Console.WriteLine("Task Name: " + highPriorityTask.TaskName);
                    Console.WriteLine("Task Priority: " + highPriorityTask.Priority);
                    Console.WriteLine("Task Completion Status: " + highPriorityTask.Status);
                }
                Console.WriteLine("+-----------------------------------------+");
            }
        }

        public void DisplayMediumPriorityTasks(List<UserTask> MediumPriorityTasks)
        {
            if (MediumPriorityTasks.Count == 0)
            {
                Console.WriteLine("There are no medium priority tasks!");
            }
            else
            {
                Console.WriteLine("+-----------------------------------------+");
                foreach (var mediumPriorityTask in MediumPriorityTasks)
                {
                    Console.WriteLine("Task Name: " + mediumPriorityTask.TaskName);
                    Console.WriteLine("Task Priority: " + mediumPriorityTask.Priority);
                    Console.WriteLine("Task Completion Status: " + mediumPriorityTask.Status);
                }
                Console.WriteLine("+-----------------------------------------+");
            }
        }

        public void DisplayLowPriorityTasks(List<UserTask> LowPriorityTasks)
        {
           
            if (LowPriorityTasks.Count == 0)
            {
                Console.WriteLine("There are no low priority tasks!");
            }
            else
            {
                Console.WriteLine("+-----------------------------------------+");
                foreach (var lowPriorityTask in LowPriorityTasks)
                {
                    Console.WriteLine("Task Name: " + lowPriorityTask.TaskName);
                    Console.WriteLine("Task Priority: " + lowPriorityTask.Priority);
                    Console.WriteLine("Task Completion Status: " + lowPriorityTask.Status);
                }
                Console.WriteLine("+-----------------------------------------+");
            }
        }

    }
}
