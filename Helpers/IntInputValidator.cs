using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Helpers
{
    public class IntInputValidator
    {
        public int InputValidator()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int validNumber))
                {
                    return validNumber;
                }
                Console.WriteLine("Invalid input! Try Again!");
            }
        }
    }
}
