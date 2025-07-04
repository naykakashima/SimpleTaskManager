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
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Incomplete;

        public UserTask()
        {
            
        }
    }
    public enum TaskPriority
    {
        HighPriority,
        MediumPriority,
        LowPriority
    }

    public enum TaskStatus
    {
        Incomplete,
        Complete
    }


}
