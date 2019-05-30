namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true, defaultValueSql : "NEWID()"),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        StartedAt = c.DateTime(nullable: false),
                        TargetDate = c.DateTime(nullable: false),
                        EndedAt = c.DateTime(),
                        TotalTimeTakenInTicks = c.Long(nullable: false),
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
