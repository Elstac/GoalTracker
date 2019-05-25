using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
