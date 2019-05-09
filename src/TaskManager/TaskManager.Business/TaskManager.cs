using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Business
{
    public class TaskManager
    {
        private TaskDataContext context = new TaskDataContext();

        public List<UserTask> GetTasks(Func<UserTask, bool> predicate)
        {
            return context.UserTasks.Where(predicate).ToList();
        }

        public UserTask GetTask(Guid id)
        {
            var task = context.UserTasks.Where(x => x.ID == id).FirstOrDefault();
            if (task != null)
            {
                return task;
            }
            throw new KeyNotFoundException("Task not found");
        }
    }
}
