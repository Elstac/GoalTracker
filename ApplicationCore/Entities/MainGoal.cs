using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class MainGoal:Goal
    {
        public ICollection<GoalStep> Steps { get; set; }
    }
}
