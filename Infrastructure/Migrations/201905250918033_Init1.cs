namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Completed = c.Boolean(nullable: false),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.GoalSteps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        MainGoal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainGoals", t => t.MainGoal_Id)
                .Index(t => t.MainGoal_Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Completed = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Task_Id = c.Int(),
                        GoalStep_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .ForeignKey("dbo.GoalSteps", t => t.GoalStep_Id)
                .Index(t => t.Task_Id)
                .Index(t => t.GoalStep_Id);
            
            CreateTable(
                "dbo.MainGoals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.GoalSteps", "MainGoal_Id", "dbo.MainGoals");
            DropForeignKey("dbo.Tasks", "GoalStep_Id", "dbo.GoalSteps");
            DropForeignKey("dbo.Tasks", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.Activities", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.Tasks", new[] { "GoalStep_Id" });
            DropIndex("dbo.Tasks", new[] { "Task_Id" });
            DropIndex("dbo.GoalSteps", new[] { "MainGoal_Id" });
            DropIndex("dbo.Activities", new[] { "Task_Id" });
            DropTable("dbo.MainGoals");
            DropTable("dbo.Tasks");
            DropTable("dbo.GoalSteps");
            DropTable("dbo.Activities");
        }
    }
}
