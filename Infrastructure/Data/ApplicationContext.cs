using ApplicationCore.Entities;
using System.Data.Entity;
namespace Infrastructure.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext():base("name=sqlite")
        {

        }

        public DbSet<Test> Tests { get; set; }
    }
}
