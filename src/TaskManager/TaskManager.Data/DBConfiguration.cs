using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Entity;

namespace TaskManager.Data
{
    public sealed class DBConfiguration : DbMigrationsConfiguration<TaskDataContext>
    {
        public DBConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(TaskDataContext context)
        {
            var tasks = new List<UserTask>();

            for(int i=0; i<10;i++)
            {
                var task = new UserTask()
                {
                    ID = Guid.NewGuid(),
                    Title = $"Title {i}",
                    Description = $"Description {i}",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    IsEnded = false,
                    IsSuspended = false
                };
                tasks.Add(task);
            }
            context.UserTasks.AddRange(tasks);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
