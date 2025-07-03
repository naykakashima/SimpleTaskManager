using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Services
{
    public class Task
    {
        public string TaskName { get; set; }
        public string TaskPriority { get; set; }
        public bool IsTaskComplete { get; set; } = false;

        public Task()
        {
            
        }
    }


}
