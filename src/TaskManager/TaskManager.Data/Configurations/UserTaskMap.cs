using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Models.Entity;

namespace TaskManager.Data.Configurations
{
    public class UserTaskMap : EntityTypeConfiguration<UserTask>
    {
        public UserTaskMap()
        {
            HasKey(x => x.ID);

            Property(x => x.Title);
            Property(x => x.Description);
            Property(x => x.IsSuspended);
            Property(x => x.CreatedAt);
            Property(x => x.StartedAt);
            Property(x => x.TotalTimeTaken);

            HasEntitySetName("UserTasks");
        }
    }
}
