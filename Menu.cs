using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Helpers;
using TaskManager.Interfaces;
using TaskManager.Services;
using static System.Net.Mime.MediaTypeNames;
using Task = TaskManager.Services.UserTask;

namespace TaskManager
{
    public class Menu
    {

        public int number;
        public int option;
        public bool continueLoop;

        private readonly ITaskService _taskService;

        public Menu(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public void ShowMenu() 
        {

            IntInputValidator intInputValidator = new IntInputValidator();
            WelcomeMessage welcomeMessage = new WelcomeMessage();

            welcomeMessage.WelcomeMessageGenerator();

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

                if ( option == 7 )
                {
                    Console.WriteLine("Thank you for using the task manager!");
                    Thread.Sleep(100);
                    System.Environment.Exit(-1);
                }

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
                        _taskService.UpdatePriority();
                        break;
                    case 3:
                        _taskService.TaskCompletion();
                        break;
                    case 4:
                        _taskService.ShowTask();
                        break;
                    case 5:
                        _taskService.FilterByCompletion();
                        break;
                    case 6:
                        _taskService.FilterByPriority();
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
                    Console.WriteLine("Thank you for using the task manager!");
                    Console.WriteLine("Exiting");
                }

            } while (continueLoop);

        }

    }
}
