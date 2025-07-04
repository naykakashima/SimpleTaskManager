using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TaskManager.Helpers
{
    public class WelcomeMessage
    {
        public string name { get; set; }
        public void WelcomeMessageGenerator()
        {
            Console.WriteLine("Welcome to the Task Manager!");
            Console.WriteLine("Enter your name to create an account: ");

            name = Console.ReadLine();

            Console.WriteLine($"Hello, {name} What would you like to do?");
           }
    }
    
}
