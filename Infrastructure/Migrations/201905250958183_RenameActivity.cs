namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameActivity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Activities", newName: "TaskActivities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TaskActivities", newName: "Activities");
        }
    }
}
