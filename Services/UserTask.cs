using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Services
{
    public class UserTask
    {
        public string TaskName { get; set; }
        public string TaskPriority { get; set; }
        public bool IsTaskComplete { get; set; } = false;

        public UserTask()
        {
            
        }
    }


}
