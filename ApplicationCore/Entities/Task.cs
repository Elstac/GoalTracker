using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    class Task:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<Task> DependencyTasks { get; set; }
    }
}
