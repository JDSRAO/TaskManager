using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Business
{
    public class TaskManager
    {
        private TaskDataContext context = new TaskDataContext();

        public List<UserTask> GetAllTasks()
        {
            return context.UserTasks.ToList();
        }
    }
}
