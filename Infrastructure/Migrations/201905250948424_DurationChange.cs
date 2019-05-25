namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DurationChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tasks", "Duration");
            AddColumn("dbo.Tasks", "Duration", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Duration");
            AddColumn("dbo.Tasks", "Duration", c => c.Time(nullable: false, precision: 7));
        }
    }
}
