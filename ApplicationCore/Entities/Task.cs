using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Task:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public ICollection<TaskActivity> Activities { get; set; }
        public ICollection<Task> DependencyTasks { get; set; }
    }
}
