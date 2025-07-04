using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services;

namespace TaskManager.Interfaces
{
    public interface ITaskService
    {
        void CreateTask();
        void ShowTask();
        void TaskCompletion();
        void UpdatePriority();
        void FilterByCompletion();
        void FilterByPriority();
        List<UserTask> GetAllTasks();
        List<UserTask> GetAllIncompleteTasks();
        List<UserTask> GetAllCompleteTasks();


    }
}
