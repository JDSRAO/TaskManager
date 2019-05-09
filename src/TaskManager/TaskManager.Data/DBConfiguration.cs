using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            base.Seed(context);
        }
    }
}
