using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    class MainGoal:Goal
    {
        public ICollection<GoalStep> Steps { get; set; }
    }
}
