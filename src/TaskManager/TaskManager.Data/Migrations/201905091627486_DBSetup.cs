namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        StartedAt = c.DateTime(nullable: false),
                        EndedAt = c.DateTime(),
                        TotalTimeTaken = c.Time(nullable: false, precision: 7),
                        IsSuspended = c.Boolean(nullable: false),
                        IsEnded = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTasks");
        }
    }
}
