using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Interfaces
{
    public interface ITaskService
    {
        void CreateTask();
        void ShowTask();
        void TaskCompletion();
        void WelcomeMessage();

    }
}
