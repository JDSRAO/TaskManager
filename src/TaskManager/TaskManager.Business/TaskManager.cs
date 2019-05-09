using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Models.Entity;

namespace TaskManager.Business
{
    public class TaskManager : BaseManager
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

        public void PauseTask(Guid id)
        {
            var task = context.UserTasks.Where(x => x.ID == id).FirstOrDefault();
            if (task != null)
            {
                //var totalTime = task.TotalTimeTaken;
                task.IsSuspended = true;
                var elapsedTime = DateTime.Now - task.StartedAt;
                task.TotalTimeTaken = elapsedTime + task.TotalTimeTaken;
            }
            else
            {
                throw new KeyNotFoundException("Task not found");
            }
        }

        public void ResumeTask(Guid id)
        {
            var task = context.UserTasks.Where(x => x.ID == id).FirstOrDefault();
            if (task != null)
            {
                task.StartedAt = DateTime.Now;
                task.IsSuspended = false;
            }
            else
            {
                throw new KeyNotFoundException("Task not found");
            }
        }

        public void EndTask(Guid id)
        {
            var task = context.UserTasks.Where(x => x.ID == id).FirstOrDefault();
            if (task != null)
            {
                task.IsEnded = true;
            }
            else
            {
                throw new KeyNotFoundException("Task not found");
            }
        }

        public void AddTask()
        {
            var task = new UserTask()
            {
                Title = "",
                Description = "",
                CreatedAt = DateTime.Now,
                StartedAt = DateTime.Now,
            };
        }
    }
}
