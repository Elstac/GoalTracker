using System;

namespace ApplicationCore.Entities
{
    public class Goal:BaseEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
