using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class GoalStep:Goal
    {
        public ICollection<Task> Tasks { get; set; }
    }
}
