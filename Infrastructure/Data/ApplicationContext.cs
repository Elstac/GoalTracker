using ApplicationCore.Entities;
using System.Data.Entity;
namespace Infrastructure.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext():base("name=localserver")
        {

        }

        public DbSet<MainGoal> MainGoals { get; set; }
        public DbSet<GoalStep> GoalSteps { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskActivity> Activities { get; set; }
    }
}
