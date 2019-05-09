namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTargetDateProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTasks", "TargetDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserTasks", "TargetDate");
        }
    }
}
