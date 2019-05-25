using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
    }
}
