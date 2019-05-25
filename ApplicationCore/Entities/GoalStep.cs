using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    class GoalStep:Goal
    {
        public ICollection<Task> Tasks { get; set; }
    }
}
