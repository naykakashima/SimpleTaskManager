using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Helpers;
using TaskManager.Services;
using static System.Net.Mime.MediaTypeNames;
using Task = TaskManager.Services.Task;

namespace TaskManager
{
    public class Menu
    {
        private readonly TaskService _taskService;

        public int number;
        public int option;
        public bool continueLoop;

        public Menu() 
        {
            IntInputValidator intInputValidator = new IntInputValidator();

            _taskService.WelcomeMessage();

            do
            {
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("1. Add tasks");
                Console.WriteLine("2. Assign priority to tasks");
                Console.WriteLine("3. Mark tasks as complete");
                Console.WriteLine("4. Show all tasks");
                Console.WriteLine("5. Filter by completion status");
                Console.WriteLine("6. Sort by priority");
                Console.WriteLine("7. Exit");
                Console.WriteLine("+----------------------------+");

                Console.WriteLine("Please enter the number corresponding to your option");
                option = intInputValidator.InputValidator();

                while (option < 1 || option > 7)
                {
                    Console.WriteLine("Invalid number, please try again!");
                }

                switch (option)
                {
                    case 1:
                        _taskService.CreateTask();
                        break;
                    case 2:
                        //Assign Priority to tasks
                        break;
                    case 3:
                        _taskService.TaskCompletion();
                        break;
                    case 4:
                        _taskService.ShowTask();
                        break;
                    case 5:
                        //filter, show only complete/incomplete tasks
                        break;
                    case 6:
                        //sort by priority
                        break;
                }

                Console.WriteLine("Would you like to continue (y/n) ?: ");
                string input = Console.ReadLine();
                if (input == "y" || input == "Y")
                {
                    continueLoop = true;
                }
                else
                {
                    continueLoop = false;
                    Console.WriteLine("Thank you for using the calculator!");
                    Console.WriteLine("Exiting");
                }

            } while (continueLoop);

        }
    }
}
