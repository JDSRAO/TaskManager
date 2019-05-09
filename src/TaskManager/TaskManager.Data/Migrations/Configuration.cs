namespace TaskManager.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskManager.Models.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManager.Data.TaskDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(TaskManager.Data.TaskDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var tasks = new List<UserTask>();

            for (int i = 0; i < 10; i++)
            {
                var task = new UserTask()
                {
                    ID = Guid.NewGuid(),
                    Title = $"Title {i}",
                    Description = $"Description {i}",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    TargetDate = DateTime.Now.AddDays(i),
                    IsEnded = false,
                    IsSuspended = false
                };
                tasks.Add(task);
            }
            context.UserTasks.AddRange(tasks);
            context.SaveChanges();
        }
    }
}
